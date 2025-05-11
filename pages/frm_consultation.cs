using System;
using System.Windows.Forms;
using Markdig;
using IdeasAi.Ideas;
using IdeasAi.modals;
using IdeasAi.pages;
using Microsoft.Win32;
using IdeasAi.db;
using IdeasAi.ai_responses;
using System.Drawing;
using Microsoft.Web.WebView2.WinForms;
using System.Threading.Tasks;



namespace IdeasAi.PageForms
{
    public partial class frm_consultation : Form
    {
        

        public const string howToUse = @"Provide question to the prompt.

The program will generate ideas related to the topic inputted.

Click 'Save' button to save the generated idea into PDF file that can be accessed offline.

Click 'Print' button to directly print the generated idea from the program.

Click 'Workspace' button to save the generated idea into the program itself, 
 and can be accessed in the workspace tab.
        ";
        private MainForm mainForm;

        //PROPERTIES
        public DBObjectManager saver_obj;

        public frm_consultation(MainForm _mainForm)
        {
            InitializeComponent();
            this.mainForm = _mainForm;
            saver_obj = new DBObjectManager();
            //OptimizeInternetExplorerVersion();
            InitializeWebView2();

            if (mainForm.btn_toggleDarkMode.Dock == DockStyle.Right)
            {
                this.BackColor = ColorTranslator.FromHtml((string)mainForm.decors["Themes"]["LightTheme"]["primary100"]);
            }
            else
            {
                this.BackColor = ColorTranslator.FromHtml((string)mainForm.decors["Themes"]["DarkTheme"]["primary100"]);
            }

            //wb_container.Focus();
            webViewContainer.EnsureCoreWebView2Async();

        }
        /*private void OptimizeInternetExplorerVersion()
        {
            var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";

            using (var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
            {
                key.SetValue(appName, 99999, RegistryValueKind.DWord);
            }

            wb_container.Navigate("https://google.com/");

        }*/
        private async void InitializeWebView2()
        {
            try
            {
                await webViewContainer.EnsureCoreWebView2Async();
                webViewContainer.CoreWebView2.Navigate("https://google.com/");
            }
            catch (Exception ex)
            {
                MessageBox.Show("WebView2 failed to initialize: " + ex.Message);
            }
        }

        private string ConvertMarkdownToHtml(string markdownText)
        {
            try
            {
                var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
                return Markdig.Markdown.ToHtml(markdownText, pipeline);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting markdown to HTML: {ex.Message}");
                return "<p>Error processing markdown content.</p>";
            }
        }

        public async void displayResult(string markdownText)
        {
            try
            {
                var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
                string htmlText = Markdig.Markdown.ToHtml(markdownText, pipeline);

                string htmlContent = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='UTF-8'>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        margin: 20px;
                    }}
                    table {{
                        border-collapse: collapse;
                        width: 100%;
                    }}
                    th, td {{
                        border: 1px solid black;
                        padding: 8px;
                        text-align: left;
                    }}
                    tr:nth-child(even) {{
                        background-color: #b0d07e;
                    }}
                    th {{
                        background-color: #b0d07e;
                    }}
                </style>
            </head>
            <body>
                {htmlText}
            </body>
            </html>";

                await webViewContainer.EnsureCoreWebView2Async(); // Ensure WebView2 is ready
                webViewContainer.NavigateToString(htmlContent);
            }
            catch (Exception ex)
            {
                string errorHtml = $@"
            <html>
                <body>
                    <h2>Something went wrong</h2>
                    <p>Please check your internet connection and try again by asking appropriate questions in a clear manner.</p>
                    <p><strong>Error:</strong> {ex.Message}</p>
                </body>
            </html>";
                await webViewContainer.EnsureCoreWebView2Async();
                webViewContainer.NavigateToString(errorHtml);
            }
        }

        public async void loadConsultation(mdl_loading loader)
        {
            btn_send.Enabled = false;
            btn_save.Enabled = false;
            btn_print.Enabled = !true;
            btn_toWorkspace.Enabled = !true;

            var topic = this.txb_Consult.Text;
            var idea_obj = new AI_ResponseBuilder<AI_Consultant>()
                .WithInput(topic)
                .Build();

            try
            {
                idea_obj.Content = await idea_obj.GetResponse(mainForm.settings);
                mainForm.addNotification("success", "Successfully answered!", $"{idea_obj.Input}");
                displayResult(idea_obj.Content);

                saver_obj.UUID = idea_obj.UUID;
                saver_obj.Input = idea_obj.Input;
                saver_obj.Content = idea_obj.Content;
                saver_obj.DateCreated = idea_obj.DateCreated;
                btn_save.Enabled = true;
                btn_print.Enabled = true;
                btn_toWorkspace.Enabled = true;

            }
            catch (Exception ex)
            {
                string errorHtml = @"
        <html>
            <body>
                <h2>Something went wrong</h2>
                <p>Please check your internet connection and try again by asking appropriate questions in a clear manner. Thank you!</p>
            </body>
        </html>";

                webViewContainer.NavigateToString(errorHtml);
                mainForm.addNotification("error", "An error occurred!", $"{ex.Message}");
            }
            finally
            {
                btn_send.Enabled = true;
                loader.Close();
                mainForm.modalBG.Hide();

            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            mainForm.setModalBackground(this);
            var loader = new mdl_loading(mainForm, this);
            loader.state = MainForm.state_loadConsultation;
            mainForm.mdl_loading.getLblLoadInfo().Text = "Generating an answer..";
            ModalManager.ShowModal(mainForm, this, loader);
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            var saveLoader = new mdl_saveNotes(mainForm);
            saveLoader.saver_obj = saver_obj;

            ModalManager.ShowModal(mainForm, this, saveLoader);
        }
        private async void btn_print_Click(object sender, EventArgs e)
        {
            if (webViewContainer.CoreWebView2 != null)
            {
                await webViewContainer.CoreWebView2.ExecuteScriptAsync("window.print();");
            }
        }
        private void btn_toWorkspace_Click(object sender, EventArgs e)
        {
            mainForm.frm_workspace.saver_obj.UUID = Guid.NewGuid();
            mainForm.frm_workspace.getTxbDocsTitle().Text = saver_obj.Title;
            mainForm.frm_workspace.getTxbEditor().Text = MainForm.ConvertMarkdownToPlainText(saver_obj.Content);

            mainForm.loadForm(mainForm.frm_workspace, mainForm.getPnlContent());
            mainForm.setActiveBtn(mainForm.getBtnWorkspace(), mainForm.getPnlPageTabs());
        }
        private void txb_Consult_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_Consult.Text))
            {
                btn_send.Enabled = false;
            }
            else
            {
                btn_send.Enabled = true;
            }
        }
        private void txb_Consult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                
                txb_Consult.SelectedText = Clipboard.GetText();
            }
            else if (e.KeyCode ==  Keys.Enter)
            {
                btn_send.PerformClick();
            }
        }

        //GETTERS
        public ref Button getSaveBtn()
        {
            return ref btn_save;
        }
        public ref RichTextBox getTxbInput()
        {
            return ref txb_Consult;
        }
        public ref Button getPrintBtn()
        {
            return ref btn_print;
        }
        public ref Button getToWorkspaceBtn()
        {
            return ref btn_toWorkspace;
        }

        private async void btn_searchMode_Click(object sender, EventArgs e)
        {
            await webViewContainer.EnsureCoreWebView2Async();
            webViewContainer.Source = new Uri("https://www.google.com");
        }

        private void txb_Consult_Enter(object sender, EventArgs e)
        {
            Console.WriteLine("kineme");
        }

    }

}

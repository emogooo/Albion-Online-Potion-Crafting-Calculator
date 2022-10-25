using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Potion_Calculator
{
    public partial class ProductionMaterialPricesForm : Form
    {
        
        List<ProductionMaterial> productionMaterials;
        List<Settings> settings;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        private bool hotKeyListenerControl;

        public ProductionMaterialPricesForm()
        {
            InitializeComponent();
            fillDGV();
            customizeDesign();
            RegisterHotKey(this.Handle, 6016, 0, (int)Keys.F10);
            checkOCR();
        }
        private async void checkOCR()
        {
            await checkSettings();
            if (settings[0].ocrPath.Contains("tesseract.exe"))
            {
                hotKeyListenerControl = true;
            }
            else
            {
                hotKeyListenerControl = false;
            }
        }

        private Task checkSettings()
        {
            return Task.Factory.StartNew(() =>
            {
                using (StreamReader? r = new StreamReader(JSONOperations.settingsJSONPath))
                {
                    string json = r.ReadToEnd();
                    settings = JSONOperations.getItemsAsClass<Settings>(json);
                }
            });
        }

        private void fillDGV()
        {
            using (StreamReader r = new StreamReader(JSONOperations.productionMaterialsJSONPath))
            {
                string json = r.ReadToEnd();
                productionMaterials = JSONOperations.getItemsAsClass<ProductionMaterial>(json);
            }
            dataGridView.DataSource = productionMaterials;
        }
        private void customizeDesign()
        {
            dataGridView.Columns[0].ReadOnly = true;
            panelLoadingScreen.Opacity = 150;
        }
        private void ProductionMaterialPricesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string jsonString = JSONOperations.getItemsAsString(productionMaterials);
            File.WriteAllText(JSONOperations.productionMaterialsJSONPath, jsonString);
        }

        private void ProductionMaterialPricesForm_SizeChanged(object sender, EventArgs e)
        {
            dataGridView.Columns[0].Width = Size.Width * 300 / 483;
            dataGridView.Columns[1].Width = Size.Width * 183 / 483;
            int fontSize = (Size.Height + Size.Width) / 120;
            if (fontSize < 11)
                fontSize = 11;
            if (fontSize > 16)
                fontSize = 16;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", fontSize / 1.0f, GraphicsUnit.Pixel);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", fontSize + 2 / 1.0f, GraphicsUnit.Pixel);
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Lütfen seçili hücreye tamsayı girdiğinizden emin olun.", "Hata");
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x0312)
            {
                if (hotKeyListenerControl && m.WParam.ToInt32() == 6016)
                {
                    hotKeyListenerControl = false;
                    panelLoadingScreen.Visible = true;
                    processImage(AppContext.BaseDirectory + @"bin\PI\templates",
                            AppContext.BaseDirectory + @"bin\PI\ProcessImage.exe");
                }
            }
        }

        private string rawData;
        private async void processImage(string templatePath, string exePath)
        {
            ProcessStartInfo? psi = new()
            {
                FileName = exePath,
                Arguments = $"\"{templatePath}\" \"{settings[0].ocrPath}\" \"{"productionMaterial"}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            await startProcess(psi);

            panelLoadingScreen.Visible = false;
            hotKeyListenerControl = true;
            new System.Media.SoundPlayer(AppContext.BaseDirectory + @"media\beep.wav").Play();

            if (rawData[0] == '0')
            {
                MessageBox.Show(rawData[1..], "Hata");
            }

            else if (rawData[0] == '1')
            {

                processAndWritePrices();
            }
        }

        private Task startProcess(ProcessStartInfo psi)
        {
            return Task.Factory.StartNew(() =>
            {
                using Process? process = Process.Start(psi);
                rawData = process.StandardOutput.ReadToEnd();
            });
        }

        private void processAndWritePrices()
        {
            string[] rawResults = rawData[1..].Split('|');

            foreach (string rawResult in rawResults)
            {
                string[] result = rawResult.Split('-');
                string name;

                if (result[0].Contains("Comfrey"))
                {
                    name = "Brightleaf Comfrey";
                }
                else if (result[0].Contains("Burdock"))
                {
                    name = "Crenellated Burdock";
                }
                else if (result[0].Contains("Teasel"))
                {
                    name = "Dragon Teasel";
                }
                else if (result[0].Contains("Foxglove"))
                {
                    name = "Elusive Foxglove";
                }
                else if (result[0].Contains("Mullein"))
                {
                    name = "Firetouched Mullein";
                }
                else if (result[0].Contains("Yarrow"))
                {
                    name = "Ghoul Yarrow";
                }
                else if (result[0].Contains("Hen"))
                {
                    name = "Hen Eggs";
                }
                else if (result[0].Contains("Goose"))
                {
                    name = "Goose Eggs";
                }
                else if (result[0].Contains("Goat"))
                {
                    name = "Goat's Milk";
                }
                else if (result[0].Contains("Sheep"))
                {
                    name = "Sheep's Milk";
                }
                else if (result[0].Contains("Cow"))
                {
                    name = "Cow's Milk";
                }
                else if (result[0].Contains("Schnapps"))
                {
                    name = "Potato Schnapps";
                }
                else if (result[0].Contains("Hooch"))
                {
                    name = "Corn Hooch";
                }
                else if (result[0].Contains("Moonshine"))
                {
                    name = "Pumpkin Moonshine";
                }
                else if (result[0].Contains("Potatoes"))
                {
                    name = "Potatoes";
                }
                else if (result[0].Contains("Bundle"))
                {
                    name = "Bundle of Corn";
                }
                else if (Equals(result[0], "Pumpkin"))
                {
                    name = "Pumpkin";
                }
                else if (result[0].Contains("Adept"))
                {
                    name = "Adept's Arcane Essence";
                }
                else if (result[0].Contains("Expert"))
                {
                    name = "Expert's Arcane Essence";
                }
                else if (result[0].Contains("Master"))
                {
                    name = "Master's Arcane Essence";
                }
                else if (result[0].Contains("Grandmaster"))
                {
                    name = "Grandmaster's Arcane Essence";
                }
                else if (result[0].Contains("Elder"))
                {
                    name = "Elder's Arcane Essence";
                }
                else
                {
                    continue;
                }
                

                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    if (Equals(dataGridView.Rows[i].Cells[0].Value, name))
                    {
                        productionMaterials[i].price = Convert.ToInt32(result[1]);
                        dataGridView.Rows[i].Cells[1].Value = result[1];
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(23, 21, 50);
                        break;
                    }
                }
            }
        }
    }
}

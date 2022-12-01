using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Potion_Calculator
{
    public partial class ProductionMaterialPricesForm : Form
    {
        
        List<ProductionMaterial> productionMaterials;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        private bool hotKeyListenerControl;

        public ProductionMaterialPricesForm()
        {
            InitializeComponent();
            fillDGV();
            customizeDesign();
            RegisterHotKey(this.Handle, 6016, 0, (int)Keys.F10);
            hotKeyListenerControl = true;
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
                    processImage(AppContext.BaseDirectory + @"bin\sniffer.exe");
                }
            }
        }

        private string rawData;
        private async void processImage(string exePath)
        {
            ProcessStartInfo? psi = new()
            {
                FileName = exePath,
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

                if (result[0].Contains("COMFREY"))
                {
                    name = "Brightleaf Comfrey";
                }
                else if (result[0].Contains("BURDOCK"))
                {
                    name = "Crenellated Burdock";
                }
                else if (result[0].Contains("TEASEL"))
                {
                    name = "Dragon Teasel";
                }
                else if (result[0].Contains("FOXGLOVE"))
                {
                    name = "Elusive Foxglove";
                }
                else if (result[0].Contains("MULLEIN"))
                {
                    name = "Firetouched Mullein";
                }
                else if (result[0].Contains("YARROW"))
                {
                    name = "Ghoul Yarrow";
                }
                else if (result[0].Contains("T3_EGG"))
                {
                    name = "Hen Eggs";
                }
                else if (result[0].Contains("T5_EGG"))
                {
                    name = "Goose Eggs";
                }
                else if (result[0].Contains("T4_MILK"))
                {
                    name = "Goat's Milk";
                }
                else if (result[0].Contains("T6_MILK"))
                {
                    name = "Sheep's Milk";
                }
                else if (result[0].Contains("T8_MILK"))
                {
                    name = "Cow's Milk";
                }
                else if (result[0].Contains("T6_ALCOHOL"))
                {
                    name = "Potato Schnapps";
                }
                else if (result[0].Contains("T7_ALCOHOL"))
                {
                    name = "Corn Hooch";
                }
                else if (result[0].Contains("T8_ALCOHOL"))
                {
                    name = "Pumpkin Moonshine";
                }
                else if (result[0].Contains("T6_POTATO"))
                {
                    name = "Potatoes";
                }
                else if (result[0].Contains("T7_CORN"))
                {
                    name = "Bundle of Corn";
                }
                else if (result[0].Contains("T8_PUMPKIN"))
                {
                    name = "Pumpkin";
                }
                else if (result[0].Contains("T4_ESSENCE_POTION"))
                {
                    name = "Adept's Arcane Essence";
                }
                else if (result[0].Contains("T5_ESSENCE_POTION"))
                {
                    name = "Expert's Arcane Essence";
                }
                else if (result[0].Contains("T6_ESSENCE_POTION"))
                {
                    name = "Master's Arcane Essence";
                }
                else if (result[0].Contains("T7_ESSENCE_POTION"))
                {
                    name = "Grandmaster's Arcane Essence";
                }
                else if (result[0].Contains("T8_ESSENCE_POTION"))
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
                        int price = Convert.ToInt32(result[1]);
                        productionMaterials[i].price = price;
                        dataGridView.Rows[i].Cells[1].Value = price;
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(23, 21, 50);
                        break;
                    }
                }
            }
        }
    }
}

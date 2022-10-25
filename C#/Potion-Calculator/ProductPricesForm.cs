using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Potion_Calculator
{
    public partial class ProductPricesForm : Form
    {
        List<Product> products;
        List<Settings> settings;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        private bool hotKeyListenerControl;

        public ProductPricesForm()
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
            using (StreamReader? r = new StreamReader(JSONOperations.productsJSONPath))
            {
                string json = r.ReadToEnd();
                products = JSONOperations.getItemsAsClass<Product>(json);
            }
            dataGridView.DataSource = products;
        }

        private void customizeDesign()
        {
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.Columns[1].ReadOnly = true;
            dataGridView.Columns[2].ReadOnly = true;
            panelLoadingScreen.Opacity = 150;
        }

        private void ProductPricesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string jsonString = JSONOperations.getItemsAsString(products);
            File.WriteAllText(JSONOperations.productsJSONPath, jsonString);
        }

        private void ProductPricesForm_SizeChanged(object sender, EventArgs e)
        {
            dataGridView.Columns[0].Width = Size.Width * 155 / 483;
            dataGridView.Columns[1].Width = Size.Width * 110 / 483;
            dataGridView.Columns[2].Width = Size.Width * 109 / 483;
            dataGridView.Columns[3].Width = Size.Width * 109 / 483;
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
                    processImage("C:/Users/HP/Desktop/Kişisel/Github/Albion-Online-Potion-Crafting-Calculator/ProcessImage/templates", "C:/Users/HP/Desktop/Kişisel/Github/Albion-Online-Potion-Crafting-Calculator/ProcessImage/ProcessImage.exe");
                }
            }
        }

        private string rawData;
        private async void processImage(string templatePath, string exePath)
        {
            ProcessStartInfo? psi = new()
            {
                FileName = exePath,
                Arguments = $"\"{templatePath}\" \"{settings[0].ocrPath}\" \"{"product"}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            await startProcess(psi);

            panelLoadingScreen.Visible = false;
            hotKeyListenerControl = true;
            new System.Media.SoundPlayer(@"C:\Users\HP\Desktop\Kişisel\Github\Albion-Online-Potion-Crafting-Calculator\C#\Potion-Calculator\sound\beep.wav").Play();

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
                int tier;

                if (result[0].Contains("Minor"))
                {
                    name = "Poison Potion";
                    tier = 4;
                }
                else if (result[0].Contains("Major"))
                {
                    result[0] = result[0].Replace("Major" , "");
                    if (result[0].Contains("Energy"))
                    {
                        name = "Energy Potion";
                        tier = 6;
                    }
                    else if (result[0].Contains("Sticky"))
                    {
                        name = "Sticky Potion";
                        tier = 7;
                    }
                    else if (result[0].Contains("Healing"))
                    {
                        name = "Healing Potion";
                        tier = 6;
                    }
                    else if (result[0].Contains("Gigantify"))
                    {
                        name = "Gigantify Potion";
                        tier = 7;
                    }
                    else if (result[0].Contains("Resistance"))
                    {
                        name = "Resistance Potion";
                        tier = 7;
                    }
                    else if (result[0].Contains("Poison"))
                    {
                        name = "Poison Potion";
                        tier = 8;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if (result[0].Contains("Energy"))
                    {
                        name = "Energy Potion";
                        tier = 4;
                    }
                    else if (result[0].Contains("Sticky"))
                    {
                        name = "Sticky Potion";
                        tier = 5;
                    }
                    else if (result[0].Contains("Healing"))
                    {
                        name = "Healing Potion";
                        tier = 4;
                    }
                    else if (result[0].Contains("Gigantify"))
                    {
                        name = "Gigantify Potion";
                        tier = 5;
                    }
                    else if (result[0].Contains("Resistance"))
                    {
                        name = "Resistance Potion";
                        tier = 5;
                    }
                    else if (result[0].Contains("Poison"))
                    {
                        name = "Poison Potion";
                        tier = 6;
                    }
                    else if (result[0].Contains("Invisibility"))
                    {
                        name = "Invisibility Potion";
                        tier = 8;
                    }
                    else if (result[0].Contains("Potato"))
                    {
                        name = "Potato Schnapps";
                        tier = 6;
                    }
                    else if (result[0].Contains("Corn"))
                    {
                        name = "Corn Hooch";
                        tier = 7;
                    }
                    else if (result[0].Contains("Pumpkin"))
                    {
                        name = "Pumpkin Moonshine";
                        tier = 8;
                    }
                    else
                    {
                        continue;
                    }
                }

                int enc = Convert.ToInt32(result[1]);

                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    if (Equals(dataGridView.Rows[i].Cells[0].Value, name) && Equals(dataGridView.Rows[i].Cells[1].Value, tier) && Equals(dataGridView.Rows[i].Cells[2].Value, enc))
                    {
                        products[i].price = Convert.ToInt32(result[2]);
                        dataGridView.Rows[i].Cells[3].Value = result[2];
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(23, 21, 50);
                        break;
                    }
                }
            }
        }
    }
}

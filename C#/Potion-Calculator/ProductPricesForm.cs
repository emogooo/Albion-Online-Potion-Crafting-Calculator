using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Potion_Calculator
{
    public partial class ProductPricesForm : Form
    {
        List<Product> products;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        private bool hotKeyListenerControl;

        public ProductPricesForm()
        {
            InitializeComponent();
            fillDGV();
            customizeDesign();
            RegisterHotKey(this.Handle, 6016, 0, (int)Keys.F10);
            hotKeyListenerControl = true;
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
                int tier = Convert.ToInt32(result[0][1]) - 48;
                int enc = 0;
                if (result[0].Contains("POTION_REVIVE"))
                {
                    name = "Gigantify Potion";
                }
                else if (result[0].Contains("POTION_STONESKIN"))
                {
                    name = "Resistance Potion";
                }
                else if (result[0].Contains("POTION_COOLDOWN"))
                {
                    name = "Poison Potion";
                }
                else if (result[0].Contains("POTION_ENERGY"))
                {
                    name = "Energy Potion";
                }
                else if (result[0].Contains("POTION_SLOWFIELD"))
                {
                    name = "Sticky Potion";
                }
                else if (result[0].Contains("POTION_CLEANSE"))
                {
                    name = "Invisibility Potion";
                }
                else if (result[0].Contains("POTION_HEAL"))
                {
                    name = "Healing Potion";
                }
                else if (result[0].Contains("ALCOHOL"))
                {
                    if(tier == 6)
                    {
                        name = "Potato Schnapps";
                    }
                    else if(tier == 7)
                    {
                        name = "Corn Hooch";
                    }
                    else if (tier == 8)
                    {
                        name = "Pumpkin Moonshine";
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }

                if (result[0].Contains("@1"))
                {
                    enc = 1;
                }

                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    if (Equals(dataGridView.Rows[i].Cells[0].Value, name) && Equals(dataGridView.Rows[i].Cells[1].Value, tier) && Equals(dataGridView.Rows[i].Cells[2].Value, enc))
                    {
                        int price = Convert.ToInt32(result[1]);
                        products[i].price = price;
                        dataGridView.Rows[i].Cells[3].Value = price;
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(23, 21, 50);
                        break;
                    }
                }
            }
        }
    }
}

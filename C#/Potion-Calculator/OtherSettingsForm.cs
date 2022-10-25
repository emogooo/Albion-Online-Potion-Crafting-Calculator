using System.Diagnostics;

namespace Potion_Calculator
{
    public partial class OtherSettingsForm : Form
    {
        List<Settings> settings;
        public OtherSettingsForm()
        {
            InitializeComponent();
            fillTextBoxes();
        }

        private void fillTextBoxes()
        {
            using (StreamReader r = new StreamReader(JSONOperations.settingsJSONPath))
            {
                string json = r.ReadToEnd();
                settings = JSONOperations.getItemsAsClass<Settings>(json);
            }
            textBoxFocus.Text = Convert.ToString(settings[0].focus);
            textBoxFee.Text = Convert.ToString(settings[0].fee);
            textBoxReturnRate.Text = Convert.ToString(settings[0].returnRate);
            textBoxMinProductionQuantity.Text = Convert.ToString(settings[0].minProductionQuantity);
            textBoxMinProductionPercent.Text = Convert.ToString(settings[0].minProductionPercent);
            textBoxMaxProductionPercent.Text = Convert.ToString(settings[0].maxProductionPercent);
            textBoxOCRPath.Text = settings[0].ocrPath;
        }

        private void OtherSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                settings[0].focus = Convert.ToInt32(textBoxFocus.Text);
                settings[0].fee = Convert.ToInt32(textBoxFee.Text);
                settings[0].returnRate = Convert.ToDouble(textBoxReturnRate.Text);
                settings[0].minProductionQuantity = Convert.ToInt32(textBoxMinProductionQuantity.Text);
                settings[0].minProductionPercent = Convert.ToInt32(textBoxMinProductionPercent.Text);
                settings[0].maxProductionPercent = Convert.ToInt32(textBoxMaxProductionPercent.Text);
                settings[0].ocrPath = textBoxOCRPath.Text;
                string jsonString = JSONOperations.getItemsAsString(settings);
                File.WriteAllText(JSONOperations.settingsJSONPath, jsonString);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen doğru değerler girin.", "Hata");
            }
        }

        private void textBoxFocus_Leave(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(textBoxFocus.Text);
                if (x < 0)
                {
                    textBoxFocus.Text = "0";
                }
                else if (x > 150000)
                {
                    textBoxFocus.Text = "150000";
                }
            }
            catch (Exception)
            {
                textBoxFocus.Text = "0";
            }
        }

        private void textBoxSetupFee_Leave(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(textBoxFee.Text);
                if (x < 0)
                {
                    textBoxFee.Text = "0";
                }
            }
            catch (Exception)
            {

                textBoxFee.Text = "0";
            }
        }

        private void textBoxReturnRate_Leave(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(textBoxReturnRate.Text);
                if (x > 100)
                {
                    textBoxReturnRate.Text = "100";
                }else if (x < 0)
                {
                    textBoxReturnRate.Text = "0";
                }
            }
            catch (Exception)
            {

                textBoxReturnRate.Text = "0";
            }
        }

        private void textBoxMinProductionQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(textBoxMinProductionQuantity.Text);
                if (x < 0)
                {
                    textBoxMinProductionQuantity.Text = "0";
                }
            }
            catch (Exception)
            {

                textBoxMinProductionQuantity.Text = "0";
            }
        }

        private void textBoxMinProductionPercent_Leave(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(textBoxMinProductionPercent.Text);

                if (x >= Convert.ToInt32(textBoxMaxProductionPercent.Text))
                {
                    x = Convert.ToInt32(textBoxMaxProductionPercent.Text) - 1;
                    textBoxMinProductionPercent.Text = Convert.ToString(x);
                }
                else if (x > 99)
                {
                    textBoxMinProductionPercent.Text = "99";
                }
                else if (x < 1)
                {
                    textBoxMinProductionPercent.Text = "1";
                }
            }
            catch (Exception)
            {
                textBoxMinProductionPercent.Text = "1"; 
            }
        }

        private void textBoxMaxProductionPercent_Leave(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(textBoxMaxProductionPercent.Text);

                if (x <= Convert.ToInt32(textBoxMinProductionPercent.Text))
                {
                    x = Convert.ToInt32(textBoxMinProductionPercent.Text) + 1;
                    textBoxMaxProductionPercent.Text = Convert.ToString(x);
                }
                else if (x > 100)
                {
                    textBoxMaxProductionPercent.Text = "100";
                }
                else if (x < 2)
                {
                    textBoxMaxProductionPercent.Text = "2";
                }
            }
            catch (Exception)
            {
                textBoxMaxProductionPercent.Text = "100";
            }
        }

        private void textBoxOCRPath_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog file = new()
            {
                Filter = "exe Dosyası |*.exe",
                RestoreDirectory = true,
                Title = "\"tesseract.exe\" Dosyasını Seçiniz.."
            };

            if (file.ShowDialog() == DialogResult.OK)
            {
                if (Equals(file.SafeFileName, "tesseract.exe"))
                {
                   textBoxOCRPath.Text = file.FileName;
                }
                else
                {
                    MessageBox.Show("Seçtiğiniz dosya tesseract.exe dosyası değildir.", "Yanlış Dosya Hatası");
                }
            }
        }
    }
}

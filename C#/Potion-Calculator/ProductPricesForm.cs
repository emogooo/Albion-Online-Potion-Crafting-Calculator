using System.Text;

namespace Potion_Calculator
{
    public partial class ProductPricesForm : Form
    {
        List<Product> products;
        public ProductPricesForm()
        {
            InitializeComponent();
            fillDGV();
            customizeDesign();
        }

        private void fillDGV()
        {
            using (StreamReader r = new StreamReader(JSONOperations.productsJSONPath))
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
    }
}

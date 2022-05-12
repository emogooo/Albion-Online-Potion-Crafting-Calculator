namespace Potion_Calculator
{
    public partial class ProductFocusesForm : Form
    {
        List<Product> products;
        List<Product> tempProducts;
        public ProductFocusesForm()
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

            tempProducts = new List<Product>();
            foreach (Product item in products)
            {
                if (item.enchantment == 0)
                {
                    tempProducts.Add(item);
                }
            }

            dataGridView.DataSource = tempProducts;
        }

        private void customizeDesign()
        {
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.Columns[1].ReadOnly = true;
        }

        private void ProductFocusesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Product mainItem in products)
            {
                foreach (Product tempItem in tempProducts)
                {
                    if (tempItem.name == mainItem.name && tempItem.tier == mainItem.tier )
                    {
                        mainItem.focus = tempItem.focus;
                        break;
                    }
                }
            }

            string jsonString = JSONOperations.getItemsAsString(products);
            File.WriteAllText(JSONOperations.productsJSONPath, jsonString);
        }

        private void dataGridView_SizeChanged(object sender, EventArgs e)
        {
            dataGridView.Columns[0].Width = Size.Width * 245 / 483;
            dataGridView.Columns[1].Width = Size.Width * 119 / 483;
            dataGridView.Columns[2].Width = Size.Width * 119 / 483;
            int fontSize = (Size.Height + Size.Width) / 100;
            if (fontSize < 13)
                fontSize = 13;
            if (fontSize > 18)
                fontSize = 18;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", fontSize / 1.0f, GraphicsUnit.Pixel);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", fontSize + 2 / 1.0f, GraphicsUnit.Pixel);
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Lütfen seçili hücreye tamsayı girdiğinizden emin olun.", "Hata");
        }
    }
}

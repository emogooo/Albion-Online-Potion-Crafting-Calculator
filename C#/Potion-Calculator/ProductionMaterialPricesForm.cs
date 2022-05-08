namespace Potion_Calculator
{
    public partial class ProductionMaterialPricesForm : Form
    {
        
        List<ProductionMaterial> productionMaterials;
        public ProductionMaterialPricesForm()
        {
            InitializeComponent();
            fillDGV();
            customizeDesign();
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
        }
        private void ProductionMaterialPricesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string jsonString = JSONOperations.getItemsAsString(productionMaterials);
            File.WriteAllText(JSONOperations.productionMaterialsJSONPath, jsonString);
        }

        private void ProductionMaterialPricesForm_SizeChanged(object sender, EventArgs e)
        {
            dataGridView.Columns[0].Width = Size.Width * 290 / 483;
            dataGridView.Columns[1].Width = Size.Width * 170 / 483;
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

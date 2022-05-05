using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Potion_Calculator
{
    public partial class ProductionMaterialPricesForm : Form
    {
        private JArray productionMaterials;
        public ProductionMaterialPricesForm()
        {
            InitializeComponent();
            productionMaterials = JArray.Parse(File.ReadAllText(JSONOperations.productionMaterialsJSONPath));
            dataGridView.DataSource = productionMaterials;
        }

        private void ProductionMaterialPricesForm_SizeChanged(object sender, EventArgs e)
        {
            dataGridView.Columns[0].Width = Size.Width * 300 / 483;
            dataGridView.Columns[1].Width = Size.Width * 183 / 483;
            int fontSize = (Size.Height + Size.Width) / 100;
            if (fontSize < 13)
                fontSize = 13;
            if (fontSize > 18)
                fontSize = 18;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", fontSize / 1.0f, GraphicsUnit.Pixel);
        }

        private void ProductionMaterialPricesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string jsonString = JsonConvert.SerializeObject(productionMaterials);
            File.WriteAllText(JSONOperations.productionMaterialsJSONPath, jsonString);
        }
    }
}

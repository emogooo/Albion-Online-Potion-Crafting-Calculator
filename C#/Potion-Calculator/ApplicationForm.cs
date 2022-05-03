namespace Potion_Calculator
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            string dataFolderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\AlbionOnlinePCC";
            System.IO.Directory.CreateDirectory(dataFolderPath);
            if (!File.Exists(dataFolderPath + "\\production-materials.json"))
            {
                using (File.Create(dataFolderPath + "\\production-materials.json")) ;
            }
            if (!File.Exists(dataFolderPath + "\\products.json"))
            {
                using (File.Create(dataFolderPath + "\\products.json")) ;
            }
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            panelProductMaterialsSubmenu.Visible = false;
            panelProductSubmenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelProductMaterialsSubmenu.Visible)
            {
                panelProductMaterialsSubmenu.Visible = false;
            }
            if (panelProductSubmenu.Visible)
            {
                panelProductSubmenu.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btProduct_Click(object sender, EventArgs e)
        {
            showSubMenu(panelProductSubmenu);
        }

        private void btProductPrices_Click(object sender, EventArgs e)
        {

        }

        private void btProductFocuses_Click(object sender, EventArgs e)
        {

        }

        private void btProductDailySalesAmount_Click(object sender, EventArgs e)
        {

        }

        private void btProductionMaterials_Click(object sender, EventArgs e)
        {
            showSubMenu(panelProductMaterialsSubmenu);
        }

        private void btProductionMaterialsPrices_Click(object sender, EventArgs e)
        {

        }

        private void btOther_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btCalculate_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
    }
}
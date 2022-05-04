namespace Potion_Calculator
{
    public partial class ApplicationForm : Form
    {
        private bool mouseDown;
        private Point offSet;
        private double resizeCornerValue;

        public ApplicationForm()
        {         
            InitializeComponent();
            customizeDesign();
            createLocalJSONDatabase();
        }
        private void customizeDesign()
        {
            panelProductMaterialsSubmenu.Visible = false;
            panelProductSubmenu.Visible = false;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            resizeCornerValue = 0.03;
        }
        private void createLocalJSONDatabase() // AppData/Local konumunda, yoksa json dosyalarýný oluþturur.
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
        }

        #region Borderless Form Ekranýný Sürükleme ve Yeniden Boyutlandýrma
        
        protected override void WndProc(ref Message m) // Borderless Form ekranýnda yeniden boyutlandýrma yapar
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);

                if (pos.X <= this.ClientSize.Width * resizeCornerValue && pos.Y <= this.ClientSize.Height * resizeCornerValue) // sol üst
                {
                    m.Result = (IntPtr)13;
                    return;
                }

                if (pos.X >= this.ClientSize.Width * (1 - resizeCornerValue) && pos.Y <= this.ClientSize.Height * resizeCornerValue) // sað üst
                {
                    m.Result = (IntPtr)14;
                    return;
                }

                if (pos.X <= this.ClientSize.Width * resizeCornerValue && pos.Y >= this.ClientSize.Height * (1 - resizeCornerValue)) // sol alt
                {
                    m.Result = (IntPtr)16;
                    return;
                }

                if (pos.X >= this.ClientSize.Width * (1 - resizeCornerValue) && pos.Y >= this.ClientSize.Height * (1 - resizeCornerValue)) // sað alt
                {
                    m.Result = (IntPtr)17;
                    return;
                }

                if (pos.X <= this.ClientSize.Width / 2 && pos.Y >= this.ClientSize.Height * resizeCornerValue && pos.Y <= this.ClientSize.Height * (1 - resizeCornerValue)) // sol
                {
                    m.Result = (IntPtr)10;
                    return;
                }
                
                if (pos.X >= this.ClientSize.Width / 2 && pos.Y >= this.ClientSize.Height * resizeCornerValue && pos.Y <= this.ClientSize.Height * (1 - resizeCornerValue)) // sað
                {
                    m.Result = (IntPtr)11;
                    return;
                }

                if (pos.Y <= this.ClientSize.Height / 2 && pos.X >= this.ClientSize.Width * resizeCornerValue && pos.X <= this.ClientSize.Width * (1 - resizeCornerValue)) // üst
                {
                    m.Result = (IntPtr)12;
                    return;
                }
                if (pos.Y >= this.ClientSize.Height / 2 && pos.X >= this.ClientSize.Width * resizeCornerValue && pos.X <= this.ClientSize.Width * (1 - resizeCornerValue)) // alt
                {
                    m.Result = (IntPtr)15;
                    return;
                }

            }
            base.WndProc(ref m);
        }
        
        #region Form Ekranýný Özel Baþlýk Çubuðundan Tutup Sürükleme
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            offSet.X = e.X;
            offSet.Y = e.Y;
            mouseDown = true;

        }

        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offSet.X, currentScreenPos.Y - offSet.Y);
            }
        }

        private void panelTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion

        #endregion

        #region Menü Butonlarý

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


        #endregion

        #region Baþlýk Çubuðu Butonlarý
        private void btClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btFullScreen_Click(object sender, EventArgs e)
        {
            if (FormWindowState.Maximized == this.WindowState)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }     
        }

        private void btMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion
    }
}
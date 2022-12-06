namespace Potion_Calculator
{
    public partial class ResultForm : Form
    {
        List<Result> resultList;
        public ResultForm()
        {
            InitializeComponent();
            dataGridViewPercentageResult.Hide();
            btBack.Hide();
            listBox.Hide();
            fillDGV();
        }

        private void fillDGV()
        {
            dataGridView.DataSource = Calculator.getPercentageResults();
        }

        private void dataGridView_SizeChanged(object sender, EventArgs e)
        {
            dataGridView.Columns[0].Width = Size.Width * 160 / 483;
            dataGridView.Columns[1].Width = Size.Width * 159 / 483;
            dataGridView.Columns[2].Width = Size.Width * 159 / 483;
            int fontSize = (Size.Height + Size.Width) / 100;
            if (fontSize < 13)
                fontSize = 13;
            if (fontSize > 18)
                fontSize = 18;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", fontSize / 1.0f, GraphicsUnit.Pixel);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", fontSize + 2 / 1.0f, GraphicsUnit.Pixel);
        }

        private void dataGridViewPercentageResult_SizeChanged(object sender, EventArgs e)
        {
            dataGridViewPercentageResult.Columns[0].Width = Size.Width * 148 / 483;
            dataGridViewPercentageResult.Columns[1].Width = Size.Width * 67 / 483;
            dataGridViewPercentageResult.Columns[2].Width = Size.Width * 67 / 483;
            dataGridViewPercentageResult.Columns[3].Width = Size.Width * 67 / 483;
            dataGridViewPercentageResult.Columns[4].Width = Size.Width * 67 / 483;
            dataGridViewPercentageResult.Columns[5].Width = Size.Width * 67 / 483;
            int fontSize = (Size.Height + Size.Width) / 120;
            if (fontSize < 11)
                fontSize = 11;
            if (fontSize > 16)
                fontSize = 16;
            dataGridViewPercentageResult.DefaultCellStyle.Font = new Font("Segoe UI", fontSize / 1.0f, GraphicsUnit.Pixel);
            dataGridViewPercentageResult.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", fontSize + 1 / 1.0f, GraphicsUnit.Pixel);
        }
        private void listBox_SizeChanged(object sender, EventArgs e)
        {
            listBox.Size = new Size(Width, Height - (btBack.Height + dataGridViewPercentageResult.Height));
            listBox.Location = new Point(0, dataGridViewPercentageResult.Height);
            int fontSize = (Size.Height + Size.Width) / 120;
            if (fontSize < 13)
                fontSize = 13;
            if (fontSize > 18)
                fontSize = 18;
            listBox.Font = new Font("Segoe UI", fontSize / 1.0f, GraphicsUnit.Pixel);
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataGridView.Hide();
                resultList = Calculator.getResult(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value));
                dataGridViewPercentageResult.DataSource = resultList;
                dataGridViewPercentageResult.Size = new Size(dataGridView.Size.Width, 65 + (25 * dataGridViewPercentageResult.Rows.Count));
                dataGridViewPercentageResult.Show();
                btBack.Show();
                listBox.Show();
            }
        }
        private void dataGridViewPercentageResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridViewPercentageResult.RowCount - 1)
            {
                listBox.Items.Clear();
                listBox.Items.Add("");
                listBox.Items.Add("   Listedeki tüm ürünleri üretebilmeniz için almanız gerekenler:");
                listBox.Items.Add("");
                List<string> itemList = Calculator.getTotalProductionList(resultList);
                for (int i = 0; i < itemList.Count - 1; i++)
                {
                    listBox.Items.Add("     ·  " + itemList[i]);
                }
                listBox.Items.Add("");
                listBox.Items.Add("      " + itemList[itemList.Count - 1]);
            }
            else if (e.RowIndex != -1)
            {
                listBox.Items.Clear();
                listBox.Items.Add("");
                listBox.Items.Add(Convert.ToString("   " + dataGridViewPercentageResult.Rows[e.RowIndex].Cells[4].Value) + " adet " +
                    Convert.ToString( dataGridViewPercentageResult.Rows[e.RowIndex].Cells[0].Value) + " üretebilmeniz için almanız gerekenler:");
                listBox.Items.Add("");
                List<string> itemList = Calculator.getProductionList(resultList[e.RowIndex].product, resultList[e.RowIndex].productionAmount);
                for (int i = 0; i < itemList.Count - 1; i++)
                {
                    listBox.Items.Add("     ·  " + itemList[i]);
                }
                listBox.Items.Add("");
                listBox.Items.Add("      " + itemList[itemList.Count - 1]);
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            btBack.Hide();
            listBox.Items.Clear();
            listBox.Hide();
            dataGridViewPercentageResult.Hide();
            dataGridView.Show();
        }
    }
}

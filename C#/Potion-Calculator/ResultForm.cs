namespace Potion_Calculator
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
            fillDGV();
        }

        private void fillDGV()
        {
            dataGridView.DataSource = Calculator.getPercentageResults();
        }

        private void dataGridView_SizeChanged(object sender, EventArgs e)
        {
            dataGridView.Columns[0].Width = Size.Width * 155 / 483;
            dataGridView.Columns[1].Width = Size.Width * 155 / 483;
            dataGridView.Columns[2].Width = Size.Width * 155 / 483;
            int fontSize = (Size.Height + Size.Width) / 100;
            if (fontSize < 13)
                fontSize = 13;
            if (fontSize > 18)
                fontSize = 18;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", fontSize / 1.0f, GraphicsUnit.Pixel);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", fontSize + 2 / 1.0f, GraphicsUnit.Pixel);
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                MessageBox.Show(dataGridView.Rows[e.RowIndex].Cells[0].Value + "");
            }
        }
    }
}

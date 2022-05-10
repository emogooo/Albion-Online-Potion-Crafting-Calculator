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
    }
}

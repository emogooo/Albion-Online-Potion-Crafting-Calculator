namespace Potion_Calculator
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.resultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productionPercentageResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalProfitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.focusUsageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productionPercentageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionPercentageResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.totalProfitDataGridViewTextBoxColumn,
            this.focusUsageDataGridViewTextBoxColumn,
            this.productionPercentageDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.productionPercentageResultBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(484, 561);
            this.dataGridView.TabIndex = 0;
            // 
            // resultBindingSource
            // 
            this.resultBindingSource.DataSource = typeof(Potion_Calculator.Result);
            // 
            // productionPercentageResultBindingSource
            // 
            this.productionPercentageResultBindingSource.DataSource = typeof(Potion_Calculator.ProductionPercentageResult);
            // 
            // totalProfitDataGridViewTextBoxColumn
            // 
            this.totalProfitDataGridViewTextBoxColumn.DataPropertyName = "totalProfit";
            this.totalProfitDataGridViewTextBoxColumn.HeaderText = "totalProfit";
            this.totalProfitDataGridViewTextBoxColumn.Name = "totalProfitDataGridViewTextBoxColumn";
            this.totalProfitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // focusUsageDataGridViewTextBoxColumn
            // 
            this.focusUsageDataGridViewTextBoxColumn.DataPropertyName = "focusUsage";
            this.focusUsageDataGridViewTextBoxColumn.HeaderText = "focusUsage";
            this.focusUsageDataGridViewTextBoxColumn.Name = "focusUsageDataGridViewTextBoxColumn";
            this.focusUsageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productionPercentageDataGridViewTextBoxColumn
            // 
            this.productionPercentageDataGridViewTextBoxColumn.DataPropertyName = "productionPercentage";
            this.productionPercentageDataGridViewTextBoxColumn.HeaderText = "productionPercentage";
            this.productionPercentageDataGridViewTextBoxColumn.Name = "productionPercentageDataGridViewTextBoxColumn";
            this.productionPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.dataGridView);
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionPercentageResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView;
        private BindingSource resultBindingSource;
        private DataGridViewTextBoxColumn totalProfitDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn focusUsageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productionPercentageDataGridViewTextBoxColumn;
        private BindingSource productionPercentageResultBindingSource;
    }
}
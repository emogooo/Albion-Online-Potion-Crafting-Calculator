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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.productionPercentageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formattedFocusUsageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formattedTotalProfitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productionPercentageResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewPercentageResult = new System.Windows.Forms.DataGridView();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formattedProductionCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formattedProfitPerProductionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formattedTotalProfitDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formattedProductionAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formattedFocusUsageAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionPercentageResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPercentageResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeight = 40;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productionPercentageDataGridViewTextBoxColumn,
            this.formattedFocusUsageDataGridViewTextBoxColumn,
            this.formattedTotalProfitDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.productionPercentageResultBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 27;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(484, 561);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.dataGridView.SizeChanged += new System.EventHandler(this.dataGridView_SizeChanged);
            // 
            // productionPercentageDataGridViewTextBoxColumn
            // 
            this.productionPercentageDataGridViewTextBoxColumn.DataPropertyName = "productionPercentage";
            this.productionPercentageDataGridViewTextBoxColumn.HeaderText = "Üretim Yüzdesi";
            this.productionPercentageDataGridViewTextBoxColumn.Name = "productionPercentageDataGridViewTextBoxColumn";
            this.productionPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formattedFocusUsageDataGridViewTextBoxColumn
            // 
            this.formattedFocusUsageDataGridViewTextBoxColumn.DataPropertyName = "formattedFocusUsage";
            this.formattedFocusUsageDataGridViewTextBoxColumn.HeaderText = "Kullanılan Focus";
            this.formattedFocusUsageDataGridViewTextBoxColumn.Name = "formattedFocusUsageDataGridViewTextBoxColumn";
            this.formattedFocusUsageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formattedTotalProfitDataGridViewTextBoxColumn
            // 
            this.formattedTotalProfitDataGridViewTextBoxColumn.DataPropertyName = "formattedTotalProfit";
            this.formattedTotalProfitDataGridViewTextBoxColumn.HeaderText = "Toplam Kâr";
            this.formattedTotalProfitDataGridViewTextBoxColumn.Name = "formattedTotalProfitDataGridViewTextBoxColumn";
            this.formattedTotalProfitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productionPercentageResultBindingSource
            // 
            this.productionPercentageResultBindingSource.DataSource = typeof(Potion_Calculator.ProductionPercentageResult);
            // 
            // dataGridViewPercentageResult
            // 
            this.dataGridViewPercentageResult.AllowUserToAddRows = false;
            this.dataGridViewPercentageResult.AllowUserToDeleteRows = false;
            this.dataGridViewPercentageResult.AllowUserToResizeColumns = false;
            this.dataGridViewPercentageResult.AllowUserToResizeRows = false;
            this.dataGridViewPercentageResult.AutoGenerateColumns = false;
            this.dataGridViewPercentageResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPercentageResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.dataGridViewPercentageResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewPercentageResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPercentageResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPercentageResult.ColumnHeadersHeight = 55;
            this.dataGridViewPercentageResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPercentageResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullNameDataGridViewTextBoxColumn,
            this.formattedProductionCostDataGridViewTextBoxColumn,
            this.formattedProfitPerProductionDataGridViewTextBoxColumn,
            this.formattedTotalProfitDataGridViewTextBoxColumn1,
            this.formattedProductionAmountDataGridViewTextBoxColumn,
            this.formattedFocusUsageAmountDataGridViewTextBoxColumn});
            this.dataGridViewPercentageResult.DataSource = this.resultBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPercentageResult.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewPercentageResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewPercentageResult.EnableHeadersVisualStyles = false;
            this.dataGridViewPercentageResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.dataGridViewPercentageResult.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPercentageResult.Name = "dataGridViewPercentageResult";
            this.dataGridViewPercentageResult.ReadOnly = true;
            this.dataGridViewPercentageResult.RowHeadersVisible = false;
            this.dataGridViewPercentageResult.RowTemplate.Height = 25;
            this.dataGridViewPercentageResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewPercentageResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPercentageResult.Size = new System.Drawing.Size(484, 137);
            this.dataGridViewPercentageResult.TabIndex = 1;
            this.dataGridViewPercentageResult.SizeChanged += new System.EventHandler(this.dataGridViewPercentageResult_SizeChanged);
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "fullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "İsim";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formattedProductionCostDataGridViewTextBoxColumn
            // 
            this.formattedProductionCostDataGridViewTextBoxColumn.DataPropertyName = "formattedProductionCost";
            this.formattedProductionCostDataGridViewTextBoxColumn.HeaderText = "Üretim Maliyeti";
            this.formattedProductionCostDataGridViewTextBoxColumn.Name = "formattedProductionCostDataGridViewTextBoxColumn";
            this.formattedProductionCostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formattedProfitPerProductionDataGridViewTextBoxColumn
            // 
            this.formattedProfitPerProductionDataGridViewTextBoxColumn.DataPropertyName = "formattedProfitPerProduction";
            this.formattedProfitPerProductionDataGridViewTextBoxColumn.HeaderText = "Üretim Başına Kâr";
            this.formattedProfitPerProductionDataGridViewTextBoxColumn.Name = "formattedProfitPerProductionDataGridViewTextBoxColumn";
            this.formattedProfitPerProductionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formattedTotalProfitDataGridViewTextBoxColumn1
            // 
            this.formattedTotalProfitDataGridViewTextBoxColumn1.DataPropertyName = "formattedTotalProfit";
            this.formattedTotalProfitDataGridViewTextBoxColumn1.HeaderText = "Toplam Kâr";
            this.formattedTotalProfitDataGridViewTextBoxColumn1.Name = "formattedTotalProfitDataGridViewTextBoxColumn1";
            this.formattedTotalProfitDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // formattedProductionAmountDataGridViewTextBoxColumn
            // 
            this.formattedProductionAmountDataGridViewTextBoxColumn.DataPropertyName = "formattedProductionAmount";
            this.formattedProductionAmountDataGridViewTextBoxColumn.HeaderText = "Üretim Adedi";
            this.formattedProductionAmountDataGridViewTextBoxColumn.Name = "formattedProductionAmountDataGridViewTextBoxColumn";
            this.formattedProductionAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formattedFocusUsageAmountDataGridViewTextBoxColumn
            // 
            this.formattedFocusUsageAmountDataGridViewTextBoxColumn.DataPropertyName = "formattedFocusUsageAmount";
            this.formattedFocusUsageAmountDataGridViewTextBoxColumn.HeaderText = "Harcanan Focus";
            this.formattedFocusUsageAmountDataGridViewTextBoxColumn.Name = "formattedFocusUsageAmountDataGridViewTextBoxColumn";
            this.formattedFocusUsageAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // resultBindingSource
            // 
            this.resultBindingSource.DataSource = typeof(Potion_Calculator.Result);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.dataGridViewPercentageResult);
            this.Controls.Add(this.dataGridView);
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionPercentageResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPercentageResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn productionPercentageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn formattedFocusUsageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn formattedTotalProfitDataGridViewTextBoxColumn;
        private BindingSource productionPercentageResultBindingSource;
        private DataGridView dataGridViewPercentageResult;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn formattedProductionCostDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn formattedProfitPerProductionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn formattedTotalProfitDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn formattedProductionAmountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn formattedFocusUsageAmountDataGridViewTextBoxColumn;
        private BindingSource resultBindingSource;
    }
}
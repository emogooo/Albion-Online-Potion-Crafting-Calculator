﻿using System.ComponentModel;

namespace Potion_Calculator
{
    partial class ProductionMaterialPricesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.productionMaterialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelLoadingScreen = new ExtendedPanel();
            this.labelWait = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productionMaterialBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // productionMaterialBindingSource
            // 
            this.productionMaterialBindingSource.DataSource = typeof(Potion_Calculator.ProductionMaterial);
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
            this.name,
            this.priceDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.productionMaterialBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.dataGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 100;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(484, 561);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.name.DefaultCellStyle = dataGridViewCellStyle2;
            this.name.HeaderText = "İsim";
            this.name.MinimumWidth = 100;
            this.name.Name = "name";
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.name.Width = 300;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Fiyat";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.Width = 183;
            // 
            // panelLoadingScreen
            // 
            this.panelLoadingScreen.BackColor = System.Drawing.Color.Black;
            this.panelLoadingScreen.Controls.Add(this.labelWait);
            this.panelLoadingScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoadingScreen.Location = new System.Drawing.Point(0, 0);
            this.panelLoadingScreen.Name = "panelLoadingScreen";
            this.panelLoadingScreen.Size = new System.Drawing.Size(484, 561);
            this.panelLoadingScreen.TabIndex = 1;
            this.panelLoadingScreen.Visible = false;
            // 
            // labelWait
            // 
            this.labelWait.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWait.AutoSize = true;
            this.labelWait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(13)))));
            this.labelWait.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelWait.ForeColor = System.Drawing.Color.Coral;
            this.labelWait.Location = new System.Drawing.Point(200, 268);
            this.labelWait.Name = "labelWait";
            this.labelWait.Size = new System.Drawing.Size(131, 42);
            this.labelWait.TabIndex = 0;
            this.labelWait.Text = "Görüntü İşleniyor\r\nLütfen Bekleyin";
            this.labelWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductionMaterialPricesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.panelLoadingScreen);
            this.Controls.Add(this.dataGridView);
            this.Name = "ProductionMaterialPricesForm";
            this.Text = "ProductionMaterialPricesForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductionMaterialPricesForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.ProductionMaterialPricesForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.productionMaterialBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BindingSource productionMaterialBindingSource;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private ExtendedPanel panelLoadingScreen;
        private Label labelWait;
        public class ExtendedPanel : Panel
        {
            private const int WS_EX_TRANSPARENT = 0x20;
            public ExtendedPanel()
            {
                SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.Opaque, true);
                SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
                DoubleBuffered = false;
            }

            private int opacity = 1;

            [DefaultValue(1)]
            public int Opacity
            {
                get => opacity;
                set
                {
                    if (value < 0 || value > 255) throw new ArgumentException("value must be between 0 and 255");
                    opacity = value;
                    if (DesignMode) FindForm().Refresh();
                    Invalidate();
                }
            }
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                    return cp;
                }
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                using (var brush = new SolidBrush(Color.FromArgb(opacity, BackColor)))
                {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }
            }
        }
    }
}
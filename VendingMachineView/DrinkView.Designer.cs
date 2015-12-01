namespace VendingMachineView
{
    partial class DrinkView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._groupBoxName = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._textBoxCount = new System.Windows.Forms.TextBox();
            this._buttonBuy = new System.Windows.Forms.Button();
            this._groupBoxName.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBoxName
            // 
            this._groupBoxName.Controls.Add(this.tableLayoutPanel1);
            this._groupBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBoxName.Location = new System.Drawing.Point(0, 0);
            this._groupBoxName.Name = "_groupBoxName";
            this._groupBoxName.Size = new System.Drawing.Size(143, 142);
            this._groupBoxName.TabIndex = 0;
            this._groupBoxName.TabStop = false;
            this._groupBoxName.Text = "groupBox1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._buttonBuy, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._textBoxCount, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(137, 123);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество порций:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Купить";
            // 
            // _textBoxCount
            // 
            this.tableLayoutPanel1.SetColumnSpan(this._textBoxCount, 2);
            this._textBoxCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBoxCount.Location = new System.Drawing.Point(3, 16);
            this._textBoxCount.Name = "_textBoxCount";
            this._textBoxCount.Size = new System.Drawing.Size(131, 20);
            this._textBoxCount.TabIndex = 2;
            // 
            // _buttonBuy
            // 
            this._buttonBuy.Location = new System.Drawing.Point(51, 42);
            this._buttonBuy.Name = "_buttonBuy";
            this._buttonBuy.Size = new System.Drawing.Size(82, 75);
            this._buttonBuy.TabIndex = 3;
            this._buttonBuy.Text = "button1";
            this._buttonBuy.UseVisualStyleBackColor = true;
            this._buttonBuy.Click += new System.EventHandler(this._buttonSize_Click);
            // 
            // DrinkView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._groupBoxName);
            this.Name = "DrinkView";
            this.Size = new System.Drawing.Size(143, 142);
            this._groupBoxName.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBoxName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _textBoxCount;
        private System.Windows.Forms.Button _buttonBuy;
    }
}

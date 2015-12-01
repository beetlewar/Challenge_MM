namespace VendingMachineApp
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._operationView = new VendingMachineView.OperationVIew();
            this._userWalletView = new VendingMachineView.WalletView();
            this._machineWalletView = new VendingMachineView.WalletView();
            this._cookView = new VendingMachineView.CookView();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._operationView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(283, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 243);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Монеты";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._cookView, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 498);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._userWalletView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(283, 252);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 243);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пользовательсккий";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._machineWalletView);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 243);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Машины";
            // 
            // _viewOperation
            // 
            this._operationView.AutoSize = true;
            this._operationView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._operationView.Location = new System.Drawing.Point(3, 16);
            this._operationView.Name = "_viewOperation";
            this._operationView.Size = new System.Drawing.Size(268, 224);
            this._operationView.TabIndex = 0;
            // 
            // _userWalletView
            // 
            this._userWalletView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._userWalletView.Location = new System.Drawing.Point(3, 16);
            this._userWalletView.Name = "_userWalletView";
            this._userWalletView.Size = new System.Drawing.Size(268, 224);
            this._userWalletView.TabIndex = 0;
            // 
            // _machineWalletView
            // 
            this._machineWalletView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._machineWalletView.Location = new System.Drawing.Point(3, 16);
            this._machineWalletView.Name = "_machineWalletView";
            this._machineWalletView.Size = new System.Drawing.Size(268, 224);
            this._machineWalletView.TabIndex = 0;
            // 
            // cookView1
            // 
            this._cookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cookView.Location = new System.Drawing.Point(3, 3);
            this._cookView.Name = "cookView1";
            this._cookView.Size = new System.Drawing.Size(274, 243);
            this._cookView.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 498);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VendingMachineView.OperationVIew _operationView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private VendingMachineView.WalletView _userWalletView;
        private VendingMachineView.WalletView _machineWalletView;
        private VendingMachineView.CookView _cookView;
    }
}


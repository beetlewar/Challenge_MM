namespace VendingMachineView
{
    partial class CoinsPileView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _button
            // 
            this._button.Dock = System.Windows.Forms.DockStyle.Fill;
            this._button.Location = new System.Drawing.Point(0, 0);
            this._button.Name = "_button";
            this._button.Size = new System.Drawing.Size(82, 38);
            this._button.TabIndex = 0;
            this._button.Text = "button2";
            this._button.UseVisualStyleBackColor = true;
            this._button.Click += new System.EventHandler(this._button_Click);
            // 
            // CoinsPileView
            // 
            this.Controls.Add(this._button);
            this.Name = "CoinsPileView";
            this.Size = new System.Drawing.Size(82, 38);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _button;
    }
}

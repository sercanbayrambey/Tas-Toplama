namespace YazılımSınama_ODEV1
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Board = new System.Windows.Forms.TableLayoutPanel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Board
            // 
            this.Board.AutoSize = true;
            this.Board.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.Board.ColumnCount = 8;
            this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.Location = new System.Drawing.Point(12, 12);
            this.Board.Margin = new System.Windows.Forms.Padding(0);
            this.Board.Name = "Board";
            this.Board.RowCount = 8;
            this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.Board.Size = new System.Drawing.Size(1049, 625);
            this.Board.TabIndex = 1;
            this.Board.Click += new System.EventHandler(this.Board_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Brown;
            this.btnRestart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRestart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRestart.Location = new System.Drawing.Point(1073, 551);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(141, 86);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "Restart  Game";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLevel.Location = new System.Drawing.Point(1073, 9);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(224, 72);
            this.lblLevel.TabIndex = 3;
            this.lblLevel.Text = "LEVEL: 1";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1598, 688);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.Board);
            this.MaximumSize = new System.Drawing.Size(1614, 727);
            this.MinimumSize = new System.Drawing.Size(1614, 727);
            this.Name = "mainForm";
            this.Text = "Taş Toplama";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Board;
        private System.Windows.Forms.Button btnRestart;
        public System.Windows.Forms.Label lblLevel;
    }
}


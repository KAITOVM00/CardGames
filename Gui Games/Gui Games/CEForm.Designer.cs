namespace Gui_Games
{
    partial class CEForm
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
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SortBtn = new System.Windows.Forms.Button();
            this.DealBtn = new System.Windows.Forms.Button();
            this.PlayerText = new System.Windows.Forms.Label();
            this.CompText = new System.Windows.Forms.Label();
            this.DiscardPB = new System.Windows.Forms.PictureBox();
            this.DeckPB = new System.Windows.Forms.PictureBox();
            this.InstructionText = new System.Windows.Forms.Label();
            this.PlayerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CompPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.DiscardPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckPB)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(572, 522);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 28;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // SortBtn
            // 
            this.SortBtn.Location = new System.Drawing.Point(69, 520);
            this.SortBtn.Name = "SortBtn";
            this.SortBtn.Size = new System.Drawing.Size(75, 23);
            this.SortBtn.TabIndex = 27;
            this.SortBtn.Text = "Sort";
            this.SortBtn.UseVisualStyleBackColor = true;
            this.SortBtn.Click += new System.EventHandler(this.SortBtn_Click);
            // 
            // DealBtn
            // 
            this.DealBtn.Location = new System.Drawing.Point(69, 491);
            this.DealBtn.Name = "DealBtn";
            this.DealBtn.Size = new System.Drawing.Size(75, 23);
            this.DealBtn.TabIndex = 26;
            this.DealBtn.Text = "Deal";
            this.DealBtn.UseVisualStyleBackColor = true;
            this.DealBtn.Click += new System.EventHandler(this.DealBtn_Click);
            // 
            // PlayerText
            // 
            this.PlayerText.AutoSize = true;
            this.PlayerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerText.Location = new System.Drawing.Point(284, 491);
            this.PlayerText.Name = "PlayerText";
            this.PlayerText.Size = new System.Drawing.Size(85, 29);
            this.PlayerText.TabIndex = 25;
            this.PlayerText.Text = "Player";
            // 
            // CompText
            // 
            this.CompText.AutoSize = true;
            this.CompText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompText.Location = new System.Drawing.Point(256, 7);
            this.CompText.Name = "CompText";
            this.CompText.Size = new System.Drawing.Size(124, 29);
            this.CompText.TabIndex = 24;
            this.CompText.Text = "Computer";
            // 
            // DiscardPB
            // 
            this.DiscardPB.Location = new System.Drawing.Point(312, 192);
            this.DiscardPB.Name = "DiscardPB";
            this.DiscardPB.Size = new System.Drawing.Size(95, 118);
            this.DiscardPB.TabIndex = 23;
            this.DiscardPB.TabStop = false;
            // 
            // DeckPB
            // 
            this.DeckPB.Enabled = false;
            this.DeckPB.Location = new System.Drawing.Point(165, 192);
            this.DeckPB.Name = "DeckPB";
            this.DeckPB.Size = new System.Drawing.Size(95, 118);
            this.DeckPB.TabIndex = 22;
            this.DeckPB.TabStop = false;
            this.DeckPB.Click += new System.EventHandler(this.DeckPB_Click);
            // 
            // InstructionText
            // 
            this.InstructionText.AutoSize = true;
            this.InstructionText.BackColor = System.Drawing.Color.White;
            this.InstructionText.Location = new System.Drawing.Point(455, 215);
            this.InstructionText.Name = "InstructionText";
            this.InstructionText.Size = new System.Drawing.Size(168, 34);
            this.InstructionText.TabIndex = 19;
            this.InstructionText.Text = "                                        \r\n\r\n";
            // 
            // PlayerPanel
            // 
            this.PlayerPanel.AutoSize = true;
            this.PlayerPanel.ColumnCount = 13;
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.PlayerPanel.Location = new System.Drawing.Point(69, 339);
            this.PlayerPanel.Name = "PlayerPanel";
            this.PlayerPanel.RowCount = 1;
            this.PlayerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PlayerPanel.Size = new System.Drawing.Size(570, 95);
            this.PlayerPanel.TabIndex = 21;
            // 
            // CompPanel
            // 
            this.CompPanel.AutoSize = true;
            this.CompPanel.ColumnCount = 13;
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.CompPanel.Location = new System.Drawing.Point(69, 47);
            this.CompPanel.Name = "CompPanel";
            this.CompPanel.RowCount = 1;
            this.CompPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CompPanel.Size = new System.Drawing.Size(570, 95);
            this.CompPanel.TabIndex = 20;
            // 
            // CEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(716, 553);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SortBtn);
            this.Controls.Add(this.DealBtn);
            this.Controls.Add(this.PlayerText);
            this.Controls.Add(this.CompText);
            this.Controls.Add(this.DiscardPB);
            this.Controls.Add(this.DeckPB);
            this.Controls.Add(this.InstructionText);
            this.Controls.Add(this.PlayerPanel);
            this.Controls.Add(this.CompPanel);
            this.Name = "CEForm";
            this.Text = "CEForm";
            ((System.ComponentModel.ISupportInitialize)(this.DiscardPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SortBtn;
        private System.Windows.Forms.Button DealBtn;
        private System.Windows.Forms.Label PlayerText;
        private System.Windows.Forms.Label CompText;
        private System.Windows.Forms.PictureBox DiscardPB;
        private System.Windows.Forms.PictureBox DeckPB;
        private System.Windows.Forms.Label InstructionText;
        private System.Windows.Forms.TableLayoutPanel PlayerPanel;
        private System.Windows.Forms.TableLayoutPanel CompPanel;
    }
}
namespace Gui_Games
{
    partial class SuitSelection
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
            this.SpadesBtn = new System.Windows.Forms.RadioButton();
            this.HeartsBtn = new System.Windows.Forms.RadioButton();
            this.ClubsBtn = new System.Windows.Forms.RadioButton();
            this.DiamondsBtn = new System.Windows.Forms.RadioButton();
            this.SuitText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SpadesBtn
            // 
            this.SpadesBtn.AutoSize = true;
            this.SpadesBtn.Checked = true;
            this.SpadesBtn.Location = new System.Drawing.Point(74, 81);
            this.SpadesBtn.Name = "SpadesBtn";
            this.SpadesBtn.Size = new System.Drawing.Size(77, 21);
            this.SpadesBtn.TabIndex = 0;
            this.SpadesBtn.TabStop = true;
            this.SpadesBtn.Text = "Spades";
            this.SpadesBtn.UseVisualStyleBackColor = true;
            // 
            // HeartsBtn
            // 
            this.HeartsBtn.AutoSize = true;
            this.HeartsBtn.Location = new System.Drawing.Point(74, 108);
            this.HeartsBtn.Name = "HeartsBtn";
            this.HeartsBtn.Size = new System.Drawing.Size(71, 21);
            this.HeartsBtn.TabIndex = 1;
            this.HeartsBtn.Text = "Hearts";
            this.HeartsBtn.UseVisualStyleBackColor = true;
            // 
            // ClubsBtn
            // 
            this.ClubsBtn.AutoSize = true;
            this.ClubsBtn.Location = new System.Drawing.Point(74, 162);
            this.ClubsBtn.Name = "ClubsBtn";
            this.ClubsBtn.Size = new System.Drawing.Size(64, 21);
            this.ClubsBtn.TabIndex = 3;
            this.ClubsBtn.Text = "Clubs";
            this.ClubsBtn.UseVisualStyleBackColor = true;
            // 
            // DiamondsBtn
            // 
            this.DiamondsBtn.AutoSize = true;
            this.DiamondsBtn.Location = new System.Drawing.Point(74, 135);
            this.DiamondsBtn.Name = "DiamondsBtn";
            this.DiamondsBtn.Size = new System.Drawing.Size(92, 21);
            this.DiamondsBtn.TabIndex = 2;
            this.DiamondsBtn.Text = "Diamonds";
            this.DiamondsBtn.UseVisualStyleBackColor = true;
            // 
            // SuitText
            // 
            this.SuitText.AutoSize = true;
            this.SuitText.Location = new System.Drawing.Point(55, 61);
            this.SuitText.Name = "SuitText";
            this.SuitText.Size = new System.Drawing.Size(150, 17);
            this.SuitText.TabIndex = 4;
            this.SuitText.Text = "Please select your suit";
            // 
            // SuitSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 243);
            this.Controls.Add(this.SuitText);
            this.Controls.Add(this.ClubsBtn);
            this.Controls.Add(this.DiamondsBtn);
            this.Controls.Add(this.HeartsBtn);
            this.Controls.Add(this.SpadesBtn);
            this.Name = "SuitSelection";
            this.Text = "Suit Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton SpadesBtn;
        private System.Windows.Forms.RadioButton HeartsBtn;
        private System.Windows.Forms.RadioButton ClubsBtn;
        private System.Windows.Forms.RadioButton DiamondsBtn;
        private System.Windows.Forms.Label SuitText;
    }
}
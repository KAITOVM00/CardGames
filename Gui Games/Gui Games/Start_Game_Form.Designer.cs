namespace Gui_Games {
    partial class Start_Game_Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.GameSelect = new System.Windows.Forms.ComboBox();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Please Select A Game To Play";
            // 
            // GameSelect
            // 
            this.GameSelect.FormattingEnabled = true;
            this.GameSelect.Items.AddRange(new object[] {
            "Solitaire",
            "Crazy Eights"});
            this.GameSelect.Location = new System.Drawing.Point(91, 90);
            this.GameSelect.Name = "GameSelect";
            this.GameSelect.Size = new System.Drawing.Size(121, 24);
            this.GameSelect.TabIndex = 7;
            this.GameSelect.SelectedIndexChanged += new System.EventHandler(this.GameSelect_SelectedIndexChanged);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(91, 178);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(121, 52);
            this.ExitBtn.TabIndex = 6;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Enabled = false;
            this.StartBtn.Location = new System.Drawing.Point(91, 120);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(121, 52);
            this.StartBtn.TabIndex = 5;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // Start_Game_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 292);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GameSelect);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.StartBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Start_Game_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Which Game To Play";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox GameSelect;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button StartBtn;
    }
}


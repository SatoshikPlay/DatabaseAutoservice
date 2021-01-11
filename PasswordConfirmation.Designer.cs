namespace DBAutoServise
{
    partial class PasswordConfirmation
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
            this.textBoxConfirmation = new System.Windows.Forms.TextBox();
            this.labelConfirmation = new System.Windows.Forms.Label();
            this.labelPassCheckError = new System.Windows.Forms.Label();
            this.buttonConfirmation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxConfirmation
            // 
            this.textBoxConfirmation.Location = new System.Drawing.Point(75, 64);
            this.textBoxConfirmation.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxConfirmation.Name = "textBoxConfirmation";
            this.textBoxConfirmation.PasswordChar = '*';
            this.textBoxConfirmation.Size = new System.Drawing.Size(132, 22);
            this.textBoxConfirmation.TabIndex = 0;
            this.textBoxConfirmation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxConfirmation_KeyPress);
            // 
            // labelConfirmation
            // 
            this.labelConfirmation.Location = new System.Drawing.Point(31, 27);
            this.labelConfirmation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConfirmation.Name = "labelConfirmation";
            this.labelConfirmation.Size = new System.Drawing.Size(232, 33);
            this.labelConfirmation.TabIndex = 1;
            this.labelConfirmation.Text = "Введите один из существующих паролей чтобы создать новый";
            // 
            // labelPassCheckError
            // 
            this.labelPassCheckError.AutoSize = true;
            this.labelPassCheckError.ForeColor = System.Drawing.Color.Red;
            this.labelPassCheckError.Location = new System.Drawing.Point(77, 107);
            this.labelPassCheckError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassCheckError.Name = "labelPassCheckError";
            this.labelPassCheckError.Size = new System.Drawing.Size(126, 17);
            this.labelPassCheckError.TabIndex = 2;
            this.labelPassCheckError.Text = "Неверный пароль";
            this.labelPassCheckError.Visible = false;
            // 
            // buttonConfirmation
            // 
            this.buttonConfirmation.Location = new System.Drawing.Point(88, 150);
            this.buttonConfirmation.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConfirmation.Name = "buttonConfirmation";
            this.buttonConfirmation.Size = new System.Drawing.Size(108, 31);
            this.buttonConfirmation.TabIndex = 3;
            this.buttonConfirmation.Text = "Подтвердить";
            this.buttonConfirmation.UseVisualStyleBackColor = true;
            this.buttonConfirmation.Click += new System.EventHandler(this.ButtonConfirmation_Click);
            // 
            // PasswordConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 213);
            this.Controls.Add(this.buttonConfirmation);
            this.Controls.Add(this.labelPassCheckError);
            this.Controls.Add(this.labelConfirmation);
            this.Controls.Add(this.textBoxConfirmation);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PasswordConfirmation";
            this.Text = "Введите пароль";
            this.Load += new System.EventHandler(this.PasswordConfirmation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxConfirmation;
        private System.Windows.Forms.Label labelConfirmation;
        private System.Windows.Forms.Label labelPassCheckError;
        private System.Windows.Forms.Button buttonConfirmation;
    }
}
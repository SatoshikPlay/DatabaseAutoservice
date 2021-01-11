namespace DBAutoServise
{
    partial class CreatePass
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
            this.labelCreatePass = new System.Windows.Forms.Label();
            this.labelRepeatPass = new System.Windows.Forms.Label();
            this.labelCreatePassError = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxPassRepeat = new System.Windows.Forms.TextBox();
            this.buttonCreatePass = new System.Windows.Forms.Button();
            this.labelLongPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCreatePass
            // 
            this.labelCreatePass.AutoSize = true;
            this.labelCreatePass.Location = new System.Drawing.Point(132, 22);
            this.labelCreatePass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreatePass.Name = "labelCreatePass";
            this.labelCreatePass.Size = new System.Drawing.Size(122, 17);
            this.labelCreatePass.TabIndex = 0;
            this.labelCreatePass.Text = "Создайте пароль";
            // 
            // labelRepeatPass
            // 
            this.labelRepeatPass.AutoSize = true;
            this.labelRepeatPass.Location = new System.Drawing.Point(124, 117);
            this.labelRepeatPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRepeatPass.Name = "labelRepeatPass";
            this.labelRepeatPass.Size = new System.Drawing.Size(130, 17);
            this.labelRepeatPass.TabIndex = 1;
            this.labelRepeatPass.Text = "Повторите пароль";
            // 
            // labelCreatePassError
            // 
            this.labelCreatePassError.AutoSize = true;
            this.labelCreatePassError.ForeColor = System.Drawing.Color.Red;
            this.labelCreatePassError.Location = new System.Drawing.Point(119, 164);
            this.labelCreatePassError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreatePassError.Name = "labelCreatePassError";
            this.labelCreatePassError.Size = new System.Drawing.Size(153, 17);
            this.labelCreatePassError.TabIndex = 2;
            this.labelCreatePassError.Text = "Пароли не совпадают";
            this.labelCreatePassError.Visible = false;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(122, 91);
            this.textBoxPass.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(132, 22);
            this.textBoxPass.TabIndex = 3;
            this.textBoxPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPass_KeyPress);
            // 
            // textBoxPassRepeat
            // 
            this.textBoxPassRepeat.Location = new System.Drawing.Point(122, 138);
            this.textBoxPassRepeat.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassRepeat.Name = "textBoxPassRepeat";
            this.textBoxPassRepeat.PasswordChar = '*';
            this.textBoxPassRepeat.Size = new System.Drawing.Size(132, 22);
            this.textBoxPassRepeat.TabIndex = 4;
            this.textBoxPassRepeat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPassRepeat_KeyPress);
            // 
            // buttonCreatePass
            // 
            this.buttonCreatePass.Location = new System.Drawing.Point(129, 195);
            this.buttonCreatePass.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreatePass.Name = "buttonCreatePass";
            this.buttonCreatePass.Size = new System.Drawing.Size(121, 42);
            this.buttonCreatePass.TabIndex = 5;
            this.buttonCreatePass.Text = "Подтвердить";
            this.buttonCreatePass.UseVisualStyleBackColor = true;
            this.buttonCreatePass.Click += new System.EventHandler(this.ButtonCreatePass_Click);
            // 
            // labelLongPass
            // 
            this.labelLongPass.Location = new System.Drawing.Point(28, 50);
            this.labelLongPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLongPass.Name = "labelLongPass";
            this.labelLongPass.Size = new System.Drawing.Size(327, 37);
            this.labelLongPass.TabIndex = 6;
            this.labelLongPass.Text = "Пароль может содержать максимум 10 сиволов, пароль не может содержать знаки препи" +
    "нания";
            // 
            // CreatePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 267);
            this.Controls.Add(this.labelLongPass);
            this.Controls.Add(this.buttonCreatePass);
            this.Controls.Add(this.textBoxPassRepeat);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.labelCreatePassError);
            this.Controls.Add(this.labelRepeatPass);
            this.Controls.Add(this.labelCreatePass);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreatePass";
            this.Text = "Создание пароля";
            this.Load += new System.EventHandler(this.CreatePass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCreatePass;
        private System.Windows.Forms.Label labelRepeatPass;
        private System.Windows.Forms.Label labelCreatePassError;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxPassRepeat;
        private System.Windows.Forms.Button buttonCreatePass;
        private System.Windows.Forms.Label labelLongPass;
    }
}
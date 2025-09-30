namespace Crud_ConsultorioPsicologico
{
    partial class LoginMdi : System.Windows.Forms.Form // Aseguramos que herede de Form
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
        ///  Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Entrar = new Button();
            SuspendLayout();
            // 
            // btn_Entrar
            // 
            btn_Entrar.Location = new Point(304, 170);
            btn_Entrar.Name = "btn_Entrar";
            btn_Entrar.Size = new Size(75, 23);
            btn_Entrar.TabIndex = 0;
            btn_Entrar.Text = "Entrar";
            btn_Entrar.UseVisualStyleBackColor = true;
            btn_Entrar.Click += btn_Entrar_Click;
            // 
            // LoginMdi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Entrar);
            Name = "LoginMdi";
            Text = "LoginMdi";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Entrar;
    }
}

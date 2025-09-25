namespace GRAN_DT_MICA__MADY_
{
    partial class FrmMenuUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuUsuario));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(347, 51);
            label1.Name = "label1";
            label1.Size = new Size(166, 42);
            label1.TabIndex = 0;
            label1.Text = "FUTBOL ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(535, 51);
            label2.Name = "label2";
            label2.Size = new Size(64, 45);
            label2.TabIndex = 1;
            label2.Text = "⚽";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(241, 48);
            label3.Name = "label3";
            label3.Size = new Size(64, 45);
            label3.TabIndex = 2;
            label3.Text = "⚽";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(379, 176);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.SteelBlue;
            button1.Location = new Point(358, 176);
            button1.Name = "button1";
            button1.Size = new Size(139, 53);
            button1.TabIndex = 4;
            button1.Text = "INICIAR SESION";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.SteelBlue;
            button2.Location = new Point(358, 298);
            button2.Name = "button2";
            button2.Size = new Size(139, 53);
            button2.TabIndex = 5;
            button2.Text = "REGISTRARSE";
            button2.UseVisualStyleBackColor = false;
            // 
            // FrmMenuUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(909, 543);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmMenuUsuario";
            Text = "Menu de Usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
    }
}
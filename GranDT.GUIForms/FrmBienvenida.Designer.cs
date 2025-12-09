namespace GRAN_DT_MICA__MADY_
{
    partial class FrmBienvenida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBienvenida));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnContinuar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(117, 24);
            label1.Name = "label1";
            label1.Size = new Size(478, 86);
            label1.TabIndex = 0;
            label1.Text = "¡BIENVENID@ ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(296, 123);
            label2.Name = "label2";
            label2.Size = new Size(115, 86);
            label2.TabIndex = 1;
            label2.Text = "AL";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(126, 222);
            label3.Name = "label3";
            label3.Size = new Size(435, 86);
            label3.TabIndex = 2;
            label3.Text = "GRAN DT 12!";
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = Color.Transparent;
            btnContinuar.BackgroundImageLayout = ImageLayout.None;
            btnContinuar.FlatStyle = FlatStyle.Popup;
            btnContinuar.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnContinuar.ForeColor = Color.DarkSlateGray;
            btnContinuar.Location = new Point(226, 329);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(243, 87);
            btnContinuar.TabIndex = 3;
            btnContinuar.Text = "Continuar";
            btnContinuar.UseVisualStyleBackColor = false;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // FrmBienvenida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(747, 428);
            Controls.Add(btnContinuar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmBienvenida";
            Text = "¡Bienvenidos!";
            Load += FrmBienvenida_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnContinuar;
    }
}
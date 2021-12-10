
namespace Teste_logica
{
    partial class frmLogica
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
            this.lblValores = new System.Windows.Forms.Label();
            this.txtValues = new System.Windows.Forms.TextBox();
            this.btnLogica = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblValores
            // 
            this.lblValores.AutoSize = true;
            this.lblValores.Location = new System.Drawing.Point(13, 13);
            this.lblValores.Name = "lblValores";
            this.lblValores.Size = new System.Drawing.Size(33, 15);
            this.lblValores.TabIndex = 0;
            this.lblValores.Text = "Valor";
            // 
            // txtValues
            // 
            this.txtValues.Location = new System.Drawing.Point(12, 31);
            this.txtValues.Name = "txtValues";
            this.txtValues.Size = new System.Drawing.Size(100, 23);
            this.txtValues.TabIndex = 1;
            // 
            // btnLogica
            // 
            this.btnLogica.Location = new System.Drawing.Point(13, 179);
            this.btnLogica.Name = "btnLogica";
            this.btnLogica.Size = new System.Drawing.Size(75, 23);
            this.btnLogica.TabIndex = 2;
            this.btnLogica.Text = "Busca";
            this.btnLogica.UseVisualStyleBackColor = true;
            this.btnLogica.Click += new System.EventHandler(this.btnLogica_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(13, 79);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 23);
            this.txtResult.TabIndex = 3;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(13, 61);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(59, 15);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "Resultado";
            // 
            // frmLogica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 214);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnLogica);
            this.Controls.Add(this.txtValues);
            this.Controls.Add(this.lblValores);
            this.Name = "frmLogica";
            this.Text = "Lógica de programação";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValores;
        private System.Windows.Forms.TextBox txtValues;
        private System.Windows.Forms.Button btnLogica;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblResult;
    }
}


namespace Snake
{
    partial class Snake
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbCanves = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanves)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCanves
            // 
            this.pbCanves.Location = new System.Drawing.Point(13, 13);
            this.pbCanves.Name = "pbCanves";
            this.pbCanves.Size = new System.Drawing.Size(440, 447);
            this.pbCanves.TabIndex = 0;
            this.pbCanves.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(457, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Score:";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelScore.Location = new System.Drawing.Point(579, 13);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(0, 37);
            this.labelScore.TabIndex = 2;
            this.labelScore.Click += new System.EventHandler(this.label2_Click);
            // 
            // Snake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 517);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbCanves);
            this.Name = "Snake";
            this.Text = "Snake";
            ((System.ComponentModel.ISupportInitialize)(this.pbCanves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanves;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelScore;
    }
}


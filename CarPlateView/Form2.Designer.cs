
namespace CarPlateView
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.title = new System.Windows.Forms.Label();
            this.vers = new System.Windows.Forms.Label();
            this.loadtime = new System.Windows.Forms.Timer(this.components);
            this.loadbar = new System.Windows.Forms.Panel();
            this.loadper = new System.Windows.Forms.Panel();
            this.loadbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Vermin Vibes V", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(140, 149);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(709, 198);
            this.title.TabIndex = 1;
            this.title.Text = "Custom\r\n                license \r\n                                plate";
            // 
            // vers
            // 
            this.vers.AutoSize = true;
            this.vers.BackColor = System.Drawing.Color.Transparent;
            this.vers.Font = new System.Drawing.Font("Vermin Vibes V", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vers.ForeColor = System.Drawing.Color.White;
            this.vers.Location = new System.Drawing.Point(807, 344);
            this.vers.Name = "vers";
            this.vers.Size = new System.Drawing.Size(131, 79);
            this.vers.TabIndex = 2;
            this.vers.Text = "1.2";
            // 
            // loadtime
            // 
            this.loadtime.Interval = 1;
            this.loadtime.Tick += new System.EventHandler(this.loadtime_Tick);
            // 
            // loadbar
            // 
            this.loadbar.BackColor = System.Drawing.Color.Transparent;
            this.loadbar.Controls.Add(this.loadper);
            this.loadbar.Location = new System.Drawing.Point(0, 525);
            this.loadbar.Name = "loadbar";
            this.loadbar.Size = new System.Drawing.Size(1000, 25);
            this.loadbar.TabIndex = 3;
            // 
            // loadper
            // 
            this.loadper.BackColor = System.Drawing.Color.White;
            this.loadper.Location = new System.Drawing.Point(0, 0);
            this.loadper.Name = "loadper";
            this.loadper.Size = new System.Drawing.Size(50, 25);
            this.loadper.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.loadbar);
            this.Controls.Add(this.vers);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom licence plate";
            this.Load += new System.EventHandler(this.loadscreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.loadscreen_Paint);
            this.loadbar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label vers;
        private System.Windows.Forms.Timer loadtime;
        private System.Windows.Forms.Panel loadbar;
        private System.Windows.Forms.Panel loadper;
    }
}
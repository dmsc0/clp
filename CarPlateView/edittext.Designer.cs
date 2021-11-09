
namespace CarPlateView
{
    partial class edittext
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(edittext));
            this.text = new System.Windows.Forms.TextBox();
            this.info = new System.Windows.Forms.Label();
            this.titlebar = new System.Windows.Forms.Panel();
            this.exit = new System.Windows.Forms.Panel();
            this.done = new CarPlateView.RoundBtn();
            this.titlebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Location = new System.Drawing.Point(163, 90);
            this.text.MaxLength = 9;
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(388, 39);
            this.text.TabIndex = 0;
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.BackColor = System.Drawing.Color.Transparent;
            this.info.Font = new System.Drawing.Font("Vulpes", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.info.ForeColor = System.Drawing.Color.White;
            this.info.Location = new System.Drawing.Point(4, 43);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(487, 29);
            this.info.TabIndex = 2;
            this.info.Text = "Enter text for your license plate: ";
            // 
            // titlebar
            // 
            this.titlebar.Controls.Add(this.exit);
            this.titlebar.Location = new System.Drawing.Point(0, 0);
            this.titlebar.Name = "titlebar";
            this.titlebar.Size = new System.Drawing.Size(725, 30);
            this.titlebar.TabIndex = 3;
            this.titlebar.Paint += new System.Windows.Forms.PaintEventHandler(this.titlebar_Paint);
            this.titlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.titlebar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseMove);
            this.titlebar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseUp);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Location = new System.Drawing.Point(693, 4);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(20, 20);
            this.exit.TabIndex = 0;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            this.exit.Paint += new System.Windows.Forms.PaintEventHandler(this.exit_Paint);
            // 
            // done
            // 
            this.done.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.done.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.done.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.done.BorderRadius = 50;
            this.done.BorderSize = 0;
            this.done.Cursor = System.Windows.Forms.Cursors.Hand;
            this.done.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.done.FlatAppearance.BorderSize = 0;
            this.done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.done.ForeColor = System.Drawing.Color.White;
            this.done.Location = new System.Drawing.Point(283, 149);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(148, 55);
            this.done.TabIndex = 4;
            this.done.Text = "done";
            this.done.TextColor = System.Drawing.Color.White;
            this.done.UseVisualStyleBackColor = false;
            // 
            // edittext
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(724, 216);
            this.Controls.Add(this.done);
            this.Controls.Add(this.titlebar);
            this.Controls.Add(this.info);
            this.Controls.Add(this.text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "edittext";
            this.Text = "Custom license plate";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.titlebar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Panel titlebar;
        private System.Windows.Forms.Panel exit;
        private RoundBtn done;
    }
}
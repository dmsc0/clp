
namespace CarPlateView
{
    partial class edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(edit));
            this.cplate = new CarPlateView.CarPlate();
            this.titlebar = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Panel();
            this.info = new System.Windows.Forms.Label();
            this.cntry = new System.Windows.Forms.Label();
            this.editb = new System.Windows.Forms.Button();
            this.edtext = new System.Windows.Forms.Panel();
            this.screen = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.titlebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // cplate
            // 
            this.cplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.cplate.Cursor = System.Windows.Forms.Cursors.Default;
            this.cplate.Location = new System.Drawing.Point(20, 221);
            this.cplate.Name = "cplate";
            this.cplate.Size = new System.Drawing.Size(2460, 400);
            this.cplate.TabIndex = 0;
            // 
            // titlebar
            // 
            this.titlebar.BackColor = System.Drawing.Color.Maroon;
            this.titlebar.Controls.Add(this.title);
            this.titlebar.Controls.Add(this.exit);
            this.titlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlebar.Location = new System.Drawing.Point(0, 0);
            this.titlebar.Name = "titlebar";
            this.titlebar.Size = new System.Drawing.Size(2500, 48);
            this.titlebar.TabIndex = 1;
            this.titlebar.Paint += new System.Windows.Forms.PaintEventHandler(this.titlebar_Paint);
            this.titlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseDown);
            this.titlebar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseMove);
            this.titlebar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titlebar_MouseUp);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("The Bold Font", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(12, 7);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(408, 34);
            this.title.TabIndex = 1;
            this.title.Text = "C u s t o m    l i c e n s e    p l a t e";
            this.title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_MouseDown);
            this.title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title_MouseMove);
            this.title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.title_MouseUp);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Location = new System.Drawing.Point(2450, 3);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(40, 40);
            this.exit.TabIndex = 0;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            this.exit.Paint += new System.Windows.Forms.PaintEventHandler(this.exit_Paint);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.BackColor = System.Drawing.Color.Transparent;
            this.info.Font = new System.Drawing.Font("Neon 80s", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.info.ForeColor = System.Drawing.Color.White;
            this.info.Location = new System.Drawing.Point(20, 650);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(797, 174);
            this.info.TabIndex = 2;
            this.info.Text = resources.GetString("info.Text");
            // 
            // cntry
            // 
            this.cntry.AutoSize = true;
            this.cntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(59)))), ((int)(((byte)(72)))));
            this.cntry.Font = new System.Drawing.Font("Kredit", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cntry.ForeColor = System.Drawing.Color.White;
            this.cntry.Location = new System.Drawing.Point(1061, 77);
            this.cntry.Name = "cntry";
            this.cntry.Size = new System.Drawing.Size(0, 57);
            this.cntry.TabIndex = 3;
            // 
            // editb
            // 
            this.editb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(59)))), ((int)(((byte)(72)))));
            this.editb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editb.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.editb.FlatAppearance.BorderSize = 2;
            this.editb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(59)))), ((int)(((byte)(72)))));
            this.editb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.editb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editb.Font = new System.Drawing.Font("Kredit", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.editb.ForeColor = System.Drawing.Color.White;
            this.editb.Location = new System.Drawing.Point(985, 148);
            this.editb.Name = "editb";
            this.editb.Size = new System.Drawing.Size(150, 46);
            this.editb.TabIndex = 4;
            this.editb.Text = "edit";
            this.editb.UseVisualStyleBackColor = false;
            this.editb.Click += new System.EventHandler(this.editb_Click);
            this.editb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editb_KeyDown);
            this.editb.Leave += new System.EventHandler(this.editb_Leave);
            // 
            // edtext
            // 
            this.edtext.BackColor = System.Drawing.Color.Transparent;
            this.edtext.BackgroundImage = global::CarPlateView.others.edte;
            this.edtext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.edtext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edtext.Location = new System.Drawing.Point(2440, 631);
            this.edtext.Name = "edtext";
            this.edtext.Size = new System.Drawing.Size(40, 40);
            this.edtext.TabIndex = 5;
            this.edtext.Click += new System.EventHandler(this.edtext_Click);
            // 
            // screen
            // 
            this.screen.BackColor = System.Drawing.Color.Transparent;
            this.screen.BackgroundImage = global::CarPlateView.others.screenshot;
            this.screen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.screen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.screen.Location = new System.Drawing.Point(2383, 631);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(40, 40);
            this.screen.TabIndex = 6;
            this.screen.Click += new System.EventHandler(this.screen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Neon 80s", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(820, 650);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(640, 145);
            this.label1.TabIndex = 7;
            this.label1.Text = "To change the entire text: \r\n\r\n    1. Click on the button that has a pencil on it" +
    ".\r\n    2. Enter your text.\r\n    3. Click on the orange \'done\' button.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Neon 80s", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1486, 650);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(565, 145);
            this.label2.TabIndex = 8;
            this.label2.Text = "To change the country: \r\n\r\n    1. Click on the gray \'edit\' button.\r\n    2. Press " +
    "A or D to change the country.\r\n    3. Click on the gray \'save\' button.";
            // 
            // edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(2500, 860);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.edtext);
            this.Controls.Add(this.cntry);
            this.Controls.Add(this.editb);
            this.Controls.Add(this.info);
            this.Controls.Add(this.titlebar);
            this.Controls.Add(this.cplate);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom license plate";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.titlebar.ResumeLayout(false);
            this.titlebar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CarPlate cplate;
        private System.Windows.Forms.Panel titlebar;
        private System.Windows.Forms.Panel exit;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Label cntry;
        private System.Windows.Forms.Button editb;
        private System.Windows.Forms.Panel edtext;
        private System.Windows.Forms.Panel screen;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


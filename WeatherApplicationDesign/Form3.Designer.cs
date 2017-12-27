namespace WeatherApplicationDesign
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxLong = new System.Windows.Forms.TextBox();
            this.boxLat = new System.Windows.Forms.TextBox();
            this.boxTmZone = new System.Windows.Forms.TextBox();
            this.boxAdmin = new System.Windows.Forms.TextBox();
            this.boxCountry = new System.Windows.Forms.TextBox();
            this.boxRegion = new System.Windows.Forms.TextBox();
            this.boxElevation = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(32, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Region:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(29, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Country:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 157);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Admin Area:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(10, 176);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "TimeZone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(22, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Longitude:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(34, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Latitude:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(18, 89);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Elevation:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.boxLong);
            this.groupBox1.Controls.Add(this.boxLat);
            this.groupBox1.Controls.Add(this.boxTmZone);
            this.groupBox1.Controls.Add(this.boxAdmin);
            this.groupBox1.Controls.Add(this.boxCountry);
            this.groupBox1.Controls.Add(this.boxRegion);
            this.groupBox1.Controls.Add(this.boxElevation);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(430, 220);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // boxLong
            // 
            this.boxLong.Enabled = false;
            this.boxLong.Location = new System.Drawing.Point(93, 59);
            this.boxLong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.boxLong.Name = "boxLong";
            this.boxLong.Size = new System.Drawing.Size(93, 20);
            this.boxLong.TabIndex = 14;
            // 
            // boxLat
            // 
            this.boxLat.Enabled = false;
            this.boxLat.Location = new System.Drawing.Point(94, 37);
            this.boxLat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.boxLat.Name = "boxLat";
            this.boxLat.Size = new System.Drawing.Size(93, 20);
            this.boxLat.TabIndex = 13;
            // 
            // boxTmZone
            // 
            this.boxTmZone.Enabled = false;
            this.boxTmZone.Location = new System.Drawing.Point(93, 180);
            this.boxTmZone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.boxTmZone.Name = "boxTmZone";
            this.boxTmZone.Size = new System.Drawing.Size(93, 20);
            this.boxTmZone.TabIndex = 12;
            // 
            // boxAdmin
            // 
            this.boxAdmin.Enabled = false;
            this.boxAdmin.Location = new System.Drawing.Point(94, 157);
            this.boxAdmin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.boxAdmin.Name = "boxAdmin";
            this.boxAdmin.Size = new System.Drawing.Size(93, 20);
            this.boxAdmin.TabIndex = 11;
            // 
            // boxCountry
            // 
            this.boxCountry.Enabled = false;
            this.boxCountry.Location = new System.Drawing.Point(94, 133);
            this.boxCountry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.boxCountry.Name = "boxCountry";
            this.boxCountry.Size = new System.Drawing.Size(93, 20);
            this.boxCountry.TabIndex = 10;
            // 
            // boxRegion
            // 
            this.boxRegion.Enabled = false;
            this.boxRegion.Location = new System.Drawing.Point(94, 110);
            this.boxRegion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.boxRegion.Name = "boxRegion";
            this.boxRegion.Size = new System.Drawing.Size(93, 20);
            this.boxRegion.TabIndex = 9;
            this.boxRegion.TextChanged += new System.EventHandler(this.boxRegion_TextChanged);
            // 
            // boxElevation
            // 
            this.boxElevation.Enabled = false;
            this.boxElevation.Location = new System.Drawing.Point(94, 88);
            this.boxElevation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.boxElevation.Name = "boxElevation";
            this.boxElevation.Size = new System.Drawing.Size(93, 20);
            this.boxElevation.TabIndex = 8;
            this.boxElevation.TextChanged += new System.EventHandler(this.boxElevation_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(205, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 198);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 240);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form3";
            this.Text = "Info Window";
            this.Activated += new System.EventHandler(this.Form3_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.Form3_Validating);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox boxTmZone;
        private System.Windows.Forms.TextBox boxAdmin;
        private System.Windows.Forms.TextBox boxCountry;
        private System.Windows.Forms.TextBox boxRegion;
        private System.Windows.Forms.TextBox boxElevation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox boxLong;
        private System.Windows.Forms.TextBox boxLat;
    }
}
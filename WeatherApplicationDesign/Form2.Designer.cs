namespace WeatherApplicationDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.celsiusButton = new System.Windows.Forms.RadioButton();
            this.fahrenButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.homeLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Name = "label1";
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1")});
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // celsiusButton
            // 
            resources.ApplyResources(this.celsiusButton, "celsiusButton");
            this.celsiusButton.BackColor = System.Drawing.Color.Transparent;
            this.celsiusButton.Name = "celsiusButton";
            this.celsiusButton.TabStop = true;
            this.celsiusButton.UseVisualStyleBackColor = false;
            this.celsiusButton.CheckedChanged += new System.EventHandler(this.celsiusButton_CheckedChanged);
            this.celsiusButton.Click += new System.EventHandler(this.celsiusButton_Click);
            // 
            // fahrenButton
            // 
            resources.ApplyResources(this.fahrenButton, "fahrenButton");
            this.fahrenButton.BackColor = System.Drawing.Color.Transparent;
            this.fahrenButton.Name = "fahrenButton";
            this.fahrenButton.TabStop = true;
            this.fahrenButton.UseVisualStyleBackColor = false;
            this.fahrenButton.CheckedChanged += new System.EventHandler(this.fahrenButton_CheckedChanged);
            this.fahrenButton.Click += new System.EventHandler(this.fahrenButton_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // homeLabel
            // 
            resources.ApplyResources(this.homeLabel, "homeLabel");
            this.homeLabel.BackColor = System.Drawing.Color.Transparent;
            this.homeLabel.Name = "homeLabel";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.homeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fahrenButton);
            this.Controls.Add(this.celsiusButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton celsiusButton;
        private System.Windows.Forms.RadioButton fahrenButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label homeLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}
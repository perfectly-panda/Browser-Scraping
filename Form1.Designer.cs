namespace Browser
{
    partial class Form1
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.LogView = new System.Windows.Forms.ListBox();
            this.IgnoreListEntry = new System.Windows.Forms.TextBox();
            this.addignore = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(36, 106);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(15, 16);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(481, 395);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("http://google.com", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(36, 11);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(695, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 50);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(36, 78);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(695, 20);
            this.textBox2.TabIndex = 5;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(1042, 11);
            this.webBrowser2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(15, 16);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScriptErrorsSuppressed = true;
            this.webBrowser2.Size = new System.Drawing.Size(15, 16);
            this.webBrowser2.TabIndex = 12;
            this.webBrowser2.Visible = false;
            this.webBrowser2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser2_DocumentCompleted);
            // 
            // LogView
            // 
            this.LogView.FormattingEnabled = true;
            this.LogView.HorizontalScrollbar = true;
            this.LogView.Location = new System.Drawing.Point(590, 106);
            this.LogView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LogView.Name = "LogView";
            this.LogView.Size = new System.Drawing.Size(446, 394);
            this.LogView.TabIndex = 13;
            // 
            // IgnoreListEntry
            // 
            this.IgnoreListEntry.Location = new System.Drawing.Point(847, 8);
            this.IgnoreListEntry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IgnoreListEntry.Name = "IgnoreListEntry";
            this.IgnoreListEntry.Size = new System.Drawing.Size(192, 20);
            this.IgnoreListEntry.TabIndex = 14;
            // 
            // addignore
            // 
            this.addignore.Location = new System.Drawing.Point(847, 32);
            this.addignore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addignore.Name = "addignore";
            this.addignore.Size = new System.Drawing.Size(92, 24);
            this.addignore.TabIndex = 15;
            this.addignore.Text = "Ignore Keyword";
            this.addignore.UseVisualStyleBackColor = true;
            this.addignore.Click += new System.EventHandler(this.addignore_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 504);
            this.Controls.Add(this.addignore);
            this.Controls.Add(this.IgnoreListEntry);
            this.Controls.Add(this.LogView);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.webBrowser1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.ListBox LogView;
        private System.Windows.Forms.TextBox IgnoreListEntry;
        private System.Windows.Forms.Button addignore;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}


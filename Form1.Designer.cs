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
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(48, 131);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(641, 486);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("http://google.com", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(925, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(48, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(925, 22);
            this.textBox2.TabIndex = 5;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(1390, 13);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScriptErrorsSuppressed = true;
            this.webBrowser2.Size = new System.Drawing.Size(20, 20);
            this.webBrowser2.TabIndex = 12;
            this.webBrowser2.Visible = false;
            this.webBrowser2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser2_DocumentCompleted);
            // 
            // LogView
            // 
            this.LogView.FormattingEnabled = true;
            this.LogView.HorizontalScrollbar = true;
            this.LogView.ItemHeight = 16;
            this.LogView.Location = new System.Drawing.Point(786, 131);
            this.LogView.Name = "LogView";
            this.LogView.Size = new System.Drawing.Size(593, 484);
            this.LogView.TabIndex = 13;
            // 
            // IgnoreListEntry
            // 
            this.IgnoreListEntry.Location = new System.Drawing.Point(1129, 10);
            this.IgnoreListEntry.Name = "IgnoreListEntry";
            this.IgnoreListEntry.Size = new System.Drawing.Size(255, 22);
            this.IgnoreListEntry.TabIndex = 14;
            // 
            // addignore
            // 
            this.addignore.Location = new System.Drawing.Point(1129, 39);
            this.addignore.Name = "addignore";
            this.addignore.Size = new System.Drawing.Size(122, 30);
            this.addignore.TabIndex = 15;
            this.addignore.Text = "Ignore Keyword";
            this.addignore.UseVisualStyleBackColor = true;
            this.addignore.Click += new System.EventHandler(this.addignore_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 620);
            this.Controls.Add(this.addignore);
            this.Controls.Add(this.IgnoreListEntry);
            this.Controls.Add(this.LogView);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.webBrowser1);
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
    }
}


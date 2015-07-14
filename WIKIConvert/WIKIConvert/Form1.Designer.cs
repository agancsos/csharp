namespace WindowsFormsApplication1
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
   System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
   this.label1 = new System.Windows.Forms.Label();
   this.label2 = new System.Windows.Forms.Label();
   this.richTextBox1 = new System.Windows.Forms.RichTextBox();
   this.label3 = new System.Windows.Forms.Label();
   this.richTextBox2 = new System.Windows.Forms.RichTextBox();
   this.SuspendLayout();
   // 
   // label1
   // 
   this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
   this.label1.AutoSize = true;
   this.label1.Location = new System.Drawing.Point(1, 398);
   this.label1.Name = "label1";
   this.label1.Size = new System.Drawing.Size(35, 13);
   this.label1.TabIndex = 0;
   this.label1.Text = "label1";
   // 
   // label2
   // 
   this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
   this.label2.AutoSize = true;
   this.label2.Location = new System.Drawing.Point(606, 398);
   this.label2.Name = "label2";
   this.label2.Size = new System.Drawing.Size(35, 13);
   this.label2.TabIndex = 1;
   this.label2.Text = "label2";
   // 
   // richTextBox1
   // 
   this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
   this.richTextBox1.Location = new System.Drawing.Point(132, -1);
   this.richTextBox1.Name = "richTextBox1";
   this.richTextBox1.Size = new System.Drawing.Size(519, 396);
   this.richTextBox1.TabIndex = 2;
   this.richTextBox1.Text = "";
   // 
   // label3
   // 
   this.label3.AutoSize = true;
   this.label3.Location = new System.Drawing.Point(274, 398);
   this.label3.Name = "label3";
   this.label3.Size = new System.Drawing.Size(35, 13);
   this.label3.TabIndex = 3;
   this.label3.Text = "label3";
   // 
   // richTextBox2
   // 
   this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
   this.richTextBox2.BackColor = System.Drawing.SystemColors.MenuText;
   this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
   this.richTextBox2.ForeColor = System.Drawing.SystemColors.Window;
   this.richTextBox2.Location = new System.Drawing.Point(4, -1);
   this.richTextBox2.Name = "richTextBox2";
   this.richTextBox2.Size = new System.Drawing.Size(122, 396);
   this.richTextBox2.TabIndex = 4;
   this.richTextBox2.Text = "";
   // 
   // Form1
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.BackColor = System.Drawing.SystemColors.ControlLightLight;
   this.ClientSize = new System.Drawing.Size(653, 414);
   this.Controls.Add(this.richTextBox2);
   this.Controls.Add(this.label3);
   this.Controls.Add(this.richTextBox1);
   this.Controls.Add(this.label2);
   this.Controls.Add(this.label1);
   this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
   this.Name = "Form1";
   this.Text = "WIKIConvert";
   this.Load += new System.EventHandler(this.Form1_Load);
   this.ResumeLayout(false);
   this.PerformLayout();

  }

  #endregion

  private System.Windows.Forms.Label label1;
  private System.Windows.Forms.Label label2;
  private System.Windows.Forms.RichTextBox richTextBox1;
  private System.Windows.Forms.Label label3;
  private System.Windows.Forms.RichTextBox richTextBox2;
 }
}
 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1{
 public partial class Form1 : Form{
  public Form1(){
   InitializeComponent();
   label1.Text="(c) "+DateTime.Today.Year+" Abel Gancsos Productions";
   label2.Text="v. 1.1.0";
   label3.Text="";
   richTextBox1.EnableAutoDragDrop=true;
   richTextBox1.Font=new Font("Consolas",10,FontStyle.Regular);
   richTextBox2.Font=new Font("Consolas",10,FontStyle.Regular);
   richTextBox2.AutoScrollOffset=new Point(0,0);
   richTextBox2.ScrollBars=RichTextBoxScrollBars.None;
  }
  public static String wikiSource(String path){
   String final="";
   using (StreamReader sr = new StreamReader(path)){
    String line = sr.ReadToEnd();
    final+=line.Trim();
   }
   return wikiParse(final);
  }
 
  public static String wikiTable(String path){
   String final="{|class=\"wikitable\"\n";
   using (FileStream fs = File.Open(path, FileMode.Open)){
    byte[] b = new byte[1024];
    UTF8Encoding temp = new UTF8Encoding(true);
    int i=0;
    while (fs.Read(b, 0, b.Length) > 0){
     String line=temp.GetString(b);
     String[]cols=line.Split(',');
     if(i==0){
      for(int j=0;j<cols.Count();j++){
       if(j==0){
        final+="! ";
       }
       else{
        final+=" !! ";
       }
       final+=cols[j];
      }
      final+="\n|-\n";
     }
     else{
      final+="| ";
      for(int j=0;j<cols.Count();j++){
       if(j>0){
        final+="||";
       }
       final+=cols[j];
      }
      final+="\n|-\n"; 
     }
     i++;
    }
    final+="|}";
   }
   return final;
  }
  public static String wikiParse(String path){
   String final="";
   String[] lines=path.Split('\n');
   for(int i=0;i<lines.Count();i++){
    if(lines[i].Trim().Length>0){
     final+=" "+lines[i]+"\n";
    }
   }
   return final;
  }
  private void Form1_Load(object sender, EventArgs e){
   richTextBox1.TextChanged+=new EventHandler(RichTextBox1_changed);
   richTextBox1.VScroll += new EventHandler(RichTextBox1_changed);
  }
  protected override bool ProcessCmdKey(ref Message msg, Keys keyData){
   if (keyData == (Keys.Control | Keys.K)){
    if(richTextBox1.Text.Split('\n').Count()>1){
     richTextBox1.Text=wikiParse(richTextBox1.Text);
    }
    else if (richTextBox1.Text.Replace(".csv","")!=richTextBox1.Text){
     richTextBox1.Text = wikiTable(richTextBox1.Text);
    } 
    else{
     richTextBox1.Text=wikiSource(richTextBox1.Text);
    }
    return true;
   }
   else if(keyData==(Keys.Control | Keys.R)){
    label3.Text = "";
    richTextBox1.Text = "";
    return true;
   }
   return base.ProcessCmdKey(ref msg, keyData);
  }
  public void RichTextBox1_changed(object sender,EventArgs e){
   richTextBox2.Text="";
   var p1 = richTextBox1.GetPositionFromCharIndex(0);
   var p2 = richTextBox1.GetPositionFromCharIndex(richTextBox1.TextLength - 1);
   int start = -p1.Y;
   if (start > 0){
    start /= 15;
   }
   int max = p2.Y - p1.Y - richTextBox1.ClientSize.Height;
   for (int i = start; i < richTextBox1.Text.Split('\n').Count(); i++){
    richTextBox2.Text += i + "\n";
   }
  }
  private void button1_Click(object sender, EventArgs e){
   if (richTextBox1.Text.Split('\n').Count() > 1){
    richTextBox1.Text = wikiParse(richTextBox1.Text);
   }
   else if (richTextBox1.Text.Replace(".csv", "") != richTextBox1.Text){
    richTextBox1.Text = wikiTable(richTextBox1.Text);
   }
   else{
    richTextBox1.Text = wikiSource(richTextBox1.Text);
   }
  }
 }
}

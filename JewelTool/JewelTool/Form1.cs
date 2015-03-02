using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;


namespace JewelTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.myInitial();
            if (!this.sqliteInstalled())
            {
                /*label4.Text = "Please install SQLite...";
                button1.BackColor = System.Drawing.Color.White;
                button1.ForeColor = System.Drawing.Color.Blue;
                button1.Show();*/
            }
            label1.Text = "(c) " + System.DateTime.Today.Year + " Abel Gancsos Productions. All Rights Reserved.";
            label2.Text = "v. 1.0.0";
        }
        public void installSQLite()
        {
            System.Diagnostics.Process.Start("C:\\Windows\\System32\\cmd.exe","/c mkdir c:\\sqlite3\\");
            System.Diagnostics.Process.Start("C:\\Windows\\System32\\cmd.exe", "/c echo F | xcopy " + Application.StartupPath + "\\Properties\\sqlite3.exe c:\\sqlite3\\sqlite3.exe");
        }
        public bool sqliteInstalled()
        {
            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(';'))
            {
                if (System.IO.File.Exists(path))
                    return true;
            }
            return false;
        }
        public void hideCreate(bool a)
        {
            if (a)
            {
                dataGridView1.Hide();
            }
            else
            {
                dataGridView1.Show();
            }
        }
        public void runCMD(string command)
        {
            //System.Diagnostics.Process.Start("C:\\Windows\\System32\\cmd.exe", "/c "+command);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C "+command;
            process.StartInfo = startInfo;
            process.Start();
            //process.Kill();
        }
        public void createFile(string fiid, string logo, string profile)
        {
            //Create DB
            string dev = "CFD";
            if (System.IO.File.Exists(userPath + "\\My Documents\\jeweltool_developer"))
            {
                dev = System.IO.File.ReadAllLines(userPath + "\\My Documents\\jeweltool_developer")[0];
                if (dev == "")
                {
                    dev = "CFD";
                }
            }
            dbFilePath = dev + "_" + fiid + "_" + logo + "_" + profile + "_1.0.0.jwl";
            //Globals
            runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"CREATE TABLE GLOBALS(FIELD_NAME character,FIELD_VALUE character)\"");
            //Screens
            runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"CREATE TABLE SCREENS(ID integer primary key autoincrement,NAME character,BUTTON_FLAG integer default '0',TEXTFIELD_FLAG integer default '0',BACKGROUND text,BUTTONS_TYPE character)\"");
            //Lines
            runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"CREATE TABLE LINES(SCREEN_ID integer,LINE_NUMBER integer,LINE_TEXT character,FONT_FAMILY character default 'Arial',START_X float default '0.0',START_Y float default '0.0',FONT_SIZE float default '12')\"");
            //Button Types
            runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"CREATE TABLE BUTTON_TYPES(SCREEN_ID integer,TYPE character)\"");
            //Button Type Values
            runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"CREATE TABLE BUTTON_TYPE_VALUES(SCREEN_ID integer,VALUE character,POSITION integer)\"");
            //Images
            runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"CREATE TABLE IMAGES(IMAGE_DATA text)\"");
            //Hardware
            runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"CREATE TABLE HARDWARE(ID integer primary key autoincrement,HARDWARE_ID integer,CONFIG_FIELD character,CONFIG_VALUE character)\"");
            //Hardware Restrict
            runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"CREATE TABLE HARDWARE_RESTRICT(MODEL_ID character,ALLOW_FLAG integer default '1')\"");
            //Change Log
            runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"CREATE TABLE CHANGE_LOG(id integer primary key autoincrement,TABLE_NAME character,OLD_VALUE text,NEW_VALUE text,LAST_UPDATED timestamp default current_timestamp,UPDATED_BY character) \"");
            //Bins
            runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"CREATE TABLE BINS (CARD_NUM character)\"");
            
            //Update metadata

            //Open newly created file and refresh table
        }
        public void createFromMaskFile(string mask, string fiid, string logo, string profile)
        {
            //Copy
            string dev="CFD";
            if(System.IO.File.Exists(userPath+"\\My Documents\\jeweltool_developer"))
            {
                dev=System.IO.File.ReadAllLines(userPath+"\\My Documents\\jeweltool_developer")[0];
                if(dev=="")
                {
                    dev="CFD";
                }
            }
            runCMD("copy " + mask + " " + userPath + "\\Desktop\\" + dev + "_" + fiid + "_" + logo + "_" + profile + "_1.0.0");
            //Update metadata

            //Open masked file and refresh table
        }
        public string[] getSQLiteRows(string path, string query)
        {
            string[] final = new string[] { };
            runCMD(sqlite3Path + " \"" + path + "\" \"" + query + "\" > \""+userPath+"\\dbdata.txt\"");
            Thread.Sleep((int)TimeSpan.FromSeconds(.25).TotalMilliseconds);
            if(System.IO.File.Exists(userPath+"\\dbdata.txt"))
            {
                 final=System.IO.File.ReadAllLines(userPath+"\\dbdata.txt");
            }
            runCMD("del \"" + userPath + "\\dbdata.txt\"");
            return final;
        }
        public string[] getTableColumns(string dbPath, string query)
        {
            string[] finalArray = new string[]{};
            string[] tempArray = new string[]{};
            string tableName = "";
            if (Regex.Split(query," from ").Count() > 0)
            {
                if (Regex.Split(query," from ")[1] != "")
                {
                    tableName = Regex.Split(query," from ")[1].Split(' ')[0];
                }
                else
                {
                    tableName = "sqlite_master";
                }
            }
            if (query.Split(' ')[1] == "*")
            {
                tempArray = getSQLiteRows(dbPath, "pragma table_info('" + tableName + "')");
                string[] tempArray2 = tempArray;
                for (int i = 0; i < tempArray.Count(); i++)
                {
                    tempArray2[i] = tempArray[i].Split('|')[1];
                }
                finalArray = tempArray2;
            }
            else
            {
                tempArray = Regex.Split(Regex.Split(query.Replace("select", ""), " from ")[0], ",");
                finalArray = tempArray;
            }
            return finalArray;
        }
        public DataTable GenerateTable(String[] mrecords)
        {
            /*           Table                    */
            DataTable mtable = new DataTable();
            DataRow mrow;
            foreach(string column in currentColumns)
            {
                mtable.Columns.Add(column.ToUpper());
            }
            if (mrecords.Count() > 0)
            {
                for (int i = 0; i < mrecords.Count(); i++)
                {
                    string[] cols;
                    cols = mrecords[i].Split('|');
                    mrow = mtable.NewRow();
                    int j=0;
                    if (cols.Count() <= currentColumns.Count())
                    {
                        foreach (string title in cols)
                        {
                            mrow[currentColumns[j]] = title;
                            j++;
                        } 
                    }
                    mtable.Rows.Add(mrow);
                }
            }
            /***************************************************************************/
            return mtable;
        }
        public void drawTable(string[]records)
        {
            table = GenerateTable(objects);
            dataGridView1.DataSource = table;
            table.RowDeleted += new DataRowChangeEventHandler(Row_Deleted);
            table.ColumnChanged += new DataColumnChangeEventHandler(Column_Changed);
            table.TableNewRow += new DataTableNewRowEventHandler(Row_Added);
            mnu = new ContextMenuStrip();
            ToolStripMenuItem openFile = new ToolStripMenuItem("Open File");
            mnu.Items.AddRange(new ToolStripItem[] { openFile });
            openFile.Click += new EventHandler(pickFile);
            openFile.ShortcutKeys = Keys.Control | Keys.F;
            if (currentTable == "sqlite_master")
            {
                dataGridView1.ReadOnly = true;
                ToolStripMenuItem selTable = new ToolStripMenuItem("Select Table");
                selTable.Click += new EventHandler(selectTable);
                selTable.ShortcutKeys = Keys.Control | Keys.S;
                mnu.Items.AddRange(new ToolStripItem[] { selTable });
                dataGridView1.ContextMenuStrip = mnu;
                dataGridView1.ContextMenuStrip.Refresh();
                
            }
            if (dbFilePath != "")
            {
                ToolStripMenuItem allTables2 = new ToolStripMenuItem("Show all tables");
                allTables2.Click += new EventHandler(showAllTables);
                allTables2.ShortcutKeys = Keys.Control | Keys.H;
                mnu.Items.AddRange(new ToolStripItem[] { allTables2 });
                ToolStripMenuItem refresh = new ToolStripMenuItem("Refresh");
                refresh.Click += new EventHandler(refresh_click);
                refresh.ShortcutKeys = Keys.Control | Keys.R;
                mnu.Items.AddRange(new ToolStripItem[] { refresh,allTables2 });
            }
        }
        //API
        public void pickFile(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                dbFilePath = file.FileName;
                //Open file
                currentTable = "sqlite_master";
                publicQuery = "select name from sqlite_master where type='table' and name!='sqlite_sequence'";
                allTables = getSQLiteRows(dbFilePath, publicQuery);
                currentColumns = getTableColumns(dbFilePath, publicQuery);
                objects = allTables;
                label3.Text = "Records: " + objects.Count().ToString();
                label4.Text = dbFilePath;
                drawTable(objects);
            }
        }
        public void addRecordAction(object sender,EventArgs e) 
        {


        }
        public void deleteRecord(object sender, EventArgs e)
        {


        }
        public void showAllTables(object sender, EventArgs e)
        {
            currentTable = "sqlite_master";
            publicQuery = "select name from sqlite_master where type='table' and name!='sqlite_sequence'";
            currentColumns = getTableColumns(dbFilePath, publicQuery);
            objects = allTables;
            label3.Text = "Records: " + objects.Count().ToString();
            drawTable(objects);
          
        }
        public void refresh_click(object sender, EventArgs e)
        {
            objects = getSQLiteRows(dbFilePath,publicQuery);
            table = GenerateTable(objects);
            dataGridView1.DataSource = table;
            drawTable(objects);
        }
        public void selectTable(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex < objects.Count())
            {
                currentTable = objects[dataGridView1.CurrentCell.RowIndex];
                publicQuery = "select * from " + currentTable;
                currentColumns = getTableColumns(dbFilePath,publicQuery);
                objects = getSQLiteRows(dbFilePath, publicQuery);
                drawTable(objects);
            }
        }
        /********************************************************************************************/

        public void myInitial()
        {
            objects = new string[]{};
            dbFilePath = "";
            maskFile = "";
            dataGridView1.DataSource = null;
            sqlite3Path="c:\\sqlite3\\sqlite3.exe";
            if(!System.IO.File.Exists(sqlite3Path))
            {
                installSQLite();
            }
            userPath = System.Environment.GetEnvironmentVariable("USERPROFILE");
            /*if (System.IO.File.Exists(userPath + "\\My Documents\\jeweltool"))
            {
                string imagePath = System.IO.File.ReadAllLines(userPath + "\\My Documents\\jeweltool")[0];
                if (System.IO.File.Exists(imagePath))
                {
                    //Set background image and text color
                    this.BackgroundImage = (System.Drawing.Image.FromFile(imagePath));
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    dataGridView1.BackgroundImage = (System.Drawing.Image.FromFile(imagePath));
                    dataGridView1.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            else
            {
                this.BackColor = System.Drawing.Color.DarkBlue;
            }*/
            mnu = new ContextMenuStrip();
            this.BackColor = System.Drawing.Color.Black;
            dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            label1.ForeColor = System.Drawing.Color.White;
            label2.ForeColor = System.Drawing.Color.White;
            label3.ForeColor = System.Drawing.Color.White;
            label4.ForeColor = System.Drawing.Color.White;
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            label4.BackColor = System.Drawing.Color.Transparent;

            label3.Text = "Records: " + objects.Count().ToString();
            label4.Text  = dbFilePath; 
            ToolStripMenuItem openFile = new ToolStripMenuItem("Open File");
            mnu.Items.AddRange(new ToolStripItem[] { openFile });
            openFile.Click += new EventHandler(pickFile);
            openFile.ShortcutKeys = Keys.Control | Keys.F;
            if (dbFilePath == "" || dbFilePath==null)
            {
                
            }
            else
            {
                if (allTables != objects)
                {
                    ToolStripMenuItem addRecord = new ToolStripMenuItem("Add Record");
                    addRecord.Click += new EventHandler(addRecordAction);
                    addRecord.ShortcutKeys = Keys.Control | Keys.A;
                    ToolStripMenuItem delRecord = new ToolStripMenuItem("Delete Record");
                    delRecord.Click += new EventHandler(deleteRecord);
                    delRecord.ShortcutKeys = Keys.Control | Keys.D;
                    //mnu.Items.AddRange(new ToolStripItem[] { addRecord,delRecord });
                }
                ToolStripMenuItem allTables2 = new ToolStripMenuItem("Show all tables");
                allTables2.Click += new EventHandler(showAllTables);
                allTables2.ShortcutKeys = Keys.Control | Keys.H;
                mnu.Items.AddRange(new ToolStripItem[] { allTables2 });
            }
            dataGridView1.ContextMenuStrip = mnu;
        }
        public string getRowID(string dbPath,string mtable,int row)
        {
            string sql = "select rowid from " + mtable + " where ";
            string[] all_objects = Regex.Split(objects[row], "|");
            for (int i = 0; i < all_objects.Count(); i++)
            {
                sql = sql + currentColumns[i] + "='" + all_objects[i] + "'";
                if (i < all_objects.Count() - 2)
                {
                    sql += ",";
                }
                sql += ")";
            }
            return getSQLiteRows(dbFilePath, sql)[0];
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (maskFile == "")
            {
                createFile(textBox1.Text, textBox2.Text, textBox3.Text);
            }
            else
            {
                createFromMaskFile(maskFile, textBox1.Text, textBox2.Text, textBox3.Text);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                maskFile = file.FileName;
            }
        }

        //Table Updates
        public void Column_Changed(object sender, DataColumnChangeEventArgs e)
        {
            if (objects != allTables)
            {
                if (currentTable != "images")
                {
                    runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"update " + currentTable + " set " + currentColumns[dataGridView1.CurrentCell.ColumnIndex] + "='" + dataGridView1.CurrentCell.Value + "' where rowid='" + getRowID(dbFilePath, currentTable, dataGridView1.CurrentCell.RowIndex));
                }
                else
                {
                    if (System.IO.File.Exists(dataGridView1.CurrentCell.Value.ToString()))
                    {
                        runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"update " + currentTable + " set " + currentColumns[dataGridView1.CurrentCell.ColumnIndex] + "='" + System.IO.File.ReadAllBytes(dataGridView1.CurrentCell.Value.ToString()) + "' where rowid='" + getRowID(dbFilePath, currentTable, dataGridView1.CurrentCell.RowIndex));
                    }
                }
                refresh_click(null, null);
                label3.Text = "Records: " + System.IO.File.ReadAllLines(dbFilePath).Count().ToString();
            }
        }
        public void Row_Added(object sender, DataTableNewRowEventArgs e)
        {
            if (objects != allTables)
            {
                if (currentTable != "images")
                {
                    string values = "(";
                    for (int i = 0; i < currentColumns.Count(); i++)
                    {
                        values += currentColumns[i];
                        if (i < currentColumns.Count() - 2)
                        {
                            values += ",";
                        }
                    }
                    values += ") values (";
                    for (int i = 0; i < currentColumns.Count(); i++)
                    {
                        values += "'NEW RECORD'";
                        if (i < currentColumns.Count() - 2)
                        {
                            values += ",";
                        }
                    }
                    values += ")";
                    runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"insert into " + currentTable + values);
                }
                else
                {
                    if (System.IO.File.Exists(dataGridView1.CurrentCell.Value.ToString()))
                    {
                        runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"insert into " + currentTable + " (image_data) values=('" + System.IO.File.ReadAllBytes(dataGridView1.CurrentCell.Value.ToString()) + "' where rowid='" + getRowID(dbFilePath, currentTable, dataGridView1.CurrentCell.RowIndex));
                    }
                }
            }
            refresh_click(null, null);
            label3.Text = "Records: " + System.IO.File.ReadAllLines(dbFilePath).Count().ToString();

        }
        public void Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            if (objects != allTables)
            {
                runCMD(sqlite3Path + " \"" + dbFilePath + "\" \"delete from " + currentTable + " where rowid='"+getRowID(dbFilePath,currentTable,dataGridView1.CurrentCell.RowIndex));
            }
            refresh_click(null, null);
            dataGridView1.Refresh();
            label3.Text = "Records: " + System.IO.File.ReadAllLines(dbFilePath).Count().ToString();

        }
    }
}


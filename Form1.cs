using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

// Author:		Russell Mangel
// Date:		2002-05-01
// Email:		russell@tymer.net
// Program:		TV-LV-Basic Version 4.1
//
// Demostrates:	TreeView & ListView Control
// Intended audience: beginner level
//
// Original code downloaded from https://www.codeproject.com/Articles/2316/Windows-Explorer-in-C

// Modification notes:
// Using imageindex for sentinal on TopLevel Nodes (Drives).
// Add icons to imageList1 with care, logic depends on this.



public class Form1 : System.Windows.Forms.Form
{	
    // Counters for statusBar1 control
    private int iFiles = 0;
    private int iDirectories = 0;

    // Windows Designer variables

    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.MenuItem menuItem2;
    private System.Windows.Forms.StatusBar statusBar1;
    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.Splitter splitter1;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.MenuItem menuItem3;
    private System.Windows.Forms.MenuItem menuItem4;
    private System.ComponentModel.IContainer components;

    public string path;
    protected string filter;
    private Button buttonApply;
    private Label labelFilter;
    private Button buttonClear;
    private TextBox textFilter;


    public string Filter
    {
        get { return filter; }
        set
        {
            if (filter != value)
            {
                filter = value;
            }
        }
    }


    public Form1()
    {
        //
        // Required for Windows Form Designer support
        //
        InitializeComponent();

        //
        // TODO: Add any constructor code after InitializeComponent call
        //
    }
    
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
        if( disposing )
        {
            if (components != null) 
            {
                components.Dispose();
            }
        }
        base.Dispose( disposing );
    }


    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textFilter = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.labelFilter = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
            this.menuItem1.Text = "File";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Exit";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4});
            this.menuItem3.Text = "Help";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "About";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.buttonApply);
            this.panel1.Controls.Add(this.labelFilter);
            this.panel1.Controls.Add(this.textFilter);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.statusBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.panel1.Size = new System.Drawing.Size(792, 550);
            this.panel1.TabIndex = 0;
            // 
            // textFilter
            // 
            this.textFilter.Location = new System.Drawing.Point(191, 10);
            this.textFilter.Name = "textFilter";
            this.textFilter.Size = new System.Drawing.Size(140, 20);
            this.textFilter.TabIndex = 7;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(144, 40);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(648, 488);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 320;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Time";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(141, 40);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 488);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.HotTracking = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 40);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(141, 488);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 528);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(792, 22);
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "Ready";
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(142, 13);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(29, 13);
            this.labelFilter.TabIndex = 8;
            this.labelFilter.Text = "Filter";
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(338, 10);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(47, 21);
            this.buttonApply.TabIndex = 9;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(391, 10);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(47, 21);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 550);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "File Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

    }
    #endregion	

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {

        string sourcePath = "C:\\temp";
        string filter = "*.txt";

        //sourcePath = Directory.GetCurrentDirectory();

        if (args.Length > 0)
            sourcePath = args[0]; 

        if (args.Length > 1)
            filter = args[1];

        var form = new Form1();
        form.path = sourcePath;
        form.filter = filter;

        form.textFilter.DataBindings.Add("Text", form, "Filter");



        Application.Run(form);
    }

    // Methods
    private void AddDirectories(TreeNode tnSubNode)
    {	
        // This method is used to get directories (from disks, or from other directories)
        
        treeView1.BeginUpdate();
        iDirectories = 0;
            
        try
        {			
            DirectoryInfo diRoot;

            // If drive, get directories from drives
            if(tnSubNode.SelectedImageIndex < 11)	
            {
                diRoot = new DirectoryInfo(tnSubNode.FullPath + "\\");								
            }

            //  Else, get directories from directories
            else	
            {
                diRoot = new DirectoryInfo(tnSubNode.FullPath);									
            }
            DirectoryInfo[] dirs = diRoot.GetDirectories();

            // Must clear this first, else the directories will get duplicated in treeview
            tnSubNode.Nodes.Clear();

            // Add the sub directories to the treeView1
            foreach(DirectoryInfo dir in dirs)
            {
                iDirectories++;
                TreeNode subNode = new TreeNode(dir.Name);
                subNode.ImageIndex = 11;
                subNode.SelectedImageIndex = 12;					
                tnSubNode.Nodes.Add(subNode);					
            }

        }
        // Throw Exception when accessing directory: C:\System Volume Information	 // do nothing
        catch	{	;	}			 		
        
        treeView1.EndUpdate();
    }

    private void AddFiles(string strPath, string filter = null)
    {		
        listView1.BeginUpdate();

        listView1.Items.Clear();
        iFiles = 0;

        if (String.IsNullOrEmpty(filter))
            filter = this.Filter;

        if (String.IsNullOrEmpty(filter))
            filter = "*.*";


        try
        {
            DirectoryInfo di = new DirectoryInfo(strPath + "\\");
            FileInfo[] theFiles = di.GetFiles(filter);			
            foreach(FileInfo theFile in theFiles)
            {
                iFiles++;
                ListViewItem lvItem = new ListViewItem(theFile.Name);
                lvItem.SubItems.Add(theFile.Length.ToString());
                lvItem.SubItems.Add(theFile.LastWriteTime.ToShortDateString());
                lvItem.SubItems.Add(theFile.LastWriteTime.ToShortTimeString());
                listView1.Items.Add(lvItem);									
            }
        }
        catch(Exception Exc)	{	statusBar1.Text = Exc.ToString();	}

        listView1.EndUpdate();		
    }
    
    // Events
    private void menuItem2_Click(object sender, System.EventArgs e)
    {
        // The proper way to close any application.
        // This is better than using Application.Exit();
        this.Close();		
    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
        // This routine adds all computer drives to the root nodes of treeView1 control
            
        string[] aDrives = Environment.GetLogicalDrives();

        treeView1.BeginUpdate();

        foreach(string strDrive in aDrives)
        {		
            TreeNode dnMyDrives = new TreeNode(strDrive.Remove(2,1));
            
            switch (strDrive)
            {	
                case "A:\\":
                    dnMyDrives.SelectedImageIndex = 0;
                    dnMyDrives.ImageIndex = 0;
                    break;
                case "C:\\":
                    
                    // The next statement causes the treeView1_AfterSelect Event to fire once on startup.
                    // This effect can be seen just after intial program load. C:\ node is selected
                    // Automatically on program load, expanding the C:\ treeView1 node.
                    treeView1.SelectedNode = dnMyDrives;    
                    dnMyDrives.SelectedImageIndex = 1;		
                    dnMyDrives.ImageIndex = 1;
                    
                    break;
                case "D:\\":
                    dnMyDrives.SelectedImageIndex = 2;
                    dnMyDrives.ImageIndex = 2;
                    break;				
                default:
                    dnMyDrives.SelectedImageIndex = 3;
                    dnMyDrives.ImageIndex = 3;
                    break;
            }
            
            treeView1.Nodes.Add(dnMyDrives);			
        }		
        treeView1.EndUpdate();

        AddFiles(this.path, this.filter);

    }

    private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
    {

        return;

        // Get subdirectories from disk, add to treeView1 control
        AddDirectories(e.Node);		

        // if node is collapsed, expand it. This allows single click to open folders.
        treeView1.SelectedNode.Expand();			
        
        // Get files from disk, add to listView1 control
        AddFiles(e.Node.FullPath.ToString());
        statusBar1.Text = iDirectories.ToString() + " Folder(s)  " + iFiles.ToString() + " File(s)";
    }

    private void listView1_ItemActivate(object sender, System.EventArgs e)
    {
        try
        {
            string sPath = treeView1.SelectedNode.FullPath;
            sPath = this.path;
            string sFileName = listView1.FocusedItem.Text;
            
            Process.Start(sPath + "\\" + sFileName);
        }
        catch(Exception Exc)	{	MessageBox.Show(Exc.ToString());	}    
    }

    private void menuItem4_Click(object sender, System.EventArgs e)
    {
        MessageBox.Show("TV-LV-Basic 4.1\n\nQuestions? Send email:\nrussell@tymer.net");
    }

    private void buttonApply_Click(object sender, EventArgs e)
    {
        this.AddFiles(this.path);
    }

    private void buttonClear_Click(object sender, EventArgs e)
    {
        this.filter = "";
        textFilter.Text = "";
        this.AddFiles(this.path);
    }
}
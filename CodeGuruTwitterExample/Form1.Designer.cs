namespace CodeGuruTwitterExample
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
      this.pnlSearchBar = new System.Windows.Forms.Panel();
      this.btnShowAll = new System.Windows.Forms.Button();
      this.txtSearchTerm = new System.Windows.Forms.TextBox();
      this.btnSearch = new System.Windows.Forms.Button();
      this.lstFollowNames = new System.Windows.Forms.ListBox();
      this.lstTweetList = new System.Windows.Forms.ListBox();
      this.pnlSearchBar.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlSearchBar
      // 
      this.pnlSearchBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.pnlSearchBar.Controls.Add(this.btnShowAll);
      this.pnlSearchBar.Controls.Add(this.txtSearchTerm);
      this.pnlSearchBar.Controls.Add(this.btnSearch);
      this.pnlSearchBar.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlSearchBar.Location = new System.Drawing.Point(0, 0);
      this.pnlSearchBar.Name = "pnlSearchBar";
      this.pnlSearchBar.Size = new System.Drawing.Size(912, 49);
      this.pnlSearchBar.TabIndex = 0;
      // 
      // btnShowAll
      // 
      this.btnShowAll.Location = new System.Drawing.Point(825, 11);
      this.btnShowAll.Name = "btnShowAll";
      this.btnShowAll.Size = new System.Drawing.Size(75, 23);
      this.btnShowAll.TabIndex = 2;
      this.btnShowAll.Text = "Show All";
      this.btnShowAll.UseVisualStyleBackColor = true;
      this.btnShowAll.Click += new System.EventHandler(this.BtnShowAllClick);
      // 
      // txtSearchTerm
      // 
      this.txtSearchTerm.Location = new System.Drawing.Point(93, 14);
      this.txtSearchTerm.Name = "txtSearchTerm";
      this.txtSearchTerm.Size = new System.Drawing.Size(474, 20);
      this.txtSearchTerm.TabIndex = 1;
      // 
      // btnSearch
      // 
      this.btnSearch.Location = new System.Drawing.Point(12, 12);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(75, 23);
      this.btnSearch.TabIndex = 0;
      this.btnSearch.Text = "Search";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
      // 
      // lstFollowNames
      // 
      this.lstFollowNames.Dock = System.Windows.Forms.DockStyle.Left;
      this.lstFollowNames.FormattingEnabled = true;
      this.lstFollowNames.Location = new System.Drawing.Point(0, 49);
      this.lstFollowNames.Name = "lstFollowNames";
      this.lstFollowNames.Size = new System.Drawing.Size(188, 617);
      this.lstFollowNames.TabIndex = 1;
      this.lstFollowNames.SelectedIndexChanged += new System.EventHandler(this.LstFollowNamesSelectedIndexChanged);
      // 
      // lstTweetList
      // 
      this.lstTweetList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstTweetList.FormattingEnabled = true;
      this.lstTweetList.Location = new System.Drawing.Point(188, 49);
      this.lstTweetList.Name = "lstTweetList";
      this.lstTweetList.Size = new System.Drawing.Size(724, 617);
      this.lstTweetList.TabIndex = 2;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(912, 666);
      this.Controls.Add(this.lstTweetList);
      this.Controls.Add(this.lstFollowNames);
      this.Controls.Add(this.pnlSearchBar);
      this.Name = "Form1";
      this.Text = "My Basic Twitter App";
      this.pnlSearchBar.ResumeLayout(false);
      this.pnlSearchBar.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlSearchBar;
    private System.Windows.Forms.TextBox txtSearchTerm;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.ListBox lstFollowNames;
    private System.Windows.Forms.ListBox lstTweetList;
    private System.Windows.Forms.Button btnShowAll;
  }
}


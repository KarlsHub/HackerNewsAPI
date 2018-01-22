namespace HackerNewsApp1
{
    partial class BestStoriesDialog
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
            this.refresh = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.searchText = new System.Windows.Forms.TextBox();
            this._bestStoriesGrid = new System.Windows.Forms.DataGridView();
            this.status = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._bestStoriesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(13, 20);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 23);
            this.refresh.TabIndex = 1;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(95, 19);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 2;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(177, 20);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(485, 20);
            this.searchText.TabIndex = 3;
            this.searchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchText_KeyDown);
            // 
            // _bestStoriesGrid
            // 
            this._bestStoriesGrid.AllowUserToAddRows = false;
            this._bestStoriesGrid.AllowUserToDeleteRows = false;
            this._bestStoriesGrid.AllowUserToResizeRows = false;
            this._bestStoriesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._bestStoriesGrid.Location = new System.Drawing.Point(13, 50);
            this._bestStoriesGrid.MaximumSize = new System.Drawing.Size(649, 683);
            this._bestStoriesGrid.MultiSelect = false;
            this._bestStoriesGrid.Name = "_bestStoriesGrid";
            this._bestStoriesGrid.ReadOnly = true;
            this._bestStoriesGrid.Size = new System.Drawing.Size(649, 683);
            this._bestStoriesGrid.TabIndex = 4;
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(13, 740);
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Size = new System.Drawing.Size(649, 20);
            this.status.TabIndex = 5;
            // 
            // BestStoriesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 765);
            this.Controls.Add(this.status);
            this.Controls.Add(this._bestStoriesGrid);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.search);
            this.Controls.Add(this.refresh);
            this.Name = "BestStoriesDialog";
            this.Text = "Hacker News Best Stories";
            this.Activated += new System.EventHandler(this.BestStoriesDialog_Activated);
            this.Load += new System.EventHandler(this.BestStoriesDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this._bestStoriesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.DataGridView _bestStoriesGrid;
        private System.Windows.Forms.TextBox status;
    }
}


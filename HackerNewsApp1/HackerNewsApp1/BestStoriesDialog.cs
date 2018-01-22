using HackerNewsWebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


/// <summary>
/// Connect to HackerNews web service API and get beset stories  
/// Discovered RestClient while working in this which made the web service part real easy
/// Author: Karl Smart
/// </summary>
namespace HackerNewsApp1
{
    /// <summary>
    /// App to list the Best Stories from HackerNews and allow searching (actually filtering)
    /// </summary>
    public partial class BestStoriesDialog : Form
    {
        #region Variables
        private HackerNews _hackerNews = null;                  // Web Service wrapper
        private Dictionary<long, HackerNewsStory> _bestStories = null;    // cache
        /// <summary>
        /// Using a DataTable and DataGridView is overkill: a ListView or ListBox would have been easier.
        /// Used these two with the idea of wiring it to a DB (Azure) which I didn't get to.
        /// </summary>
        private DataTable _dataTable = null;
        private bool _loadOnce = false;
        #endregion

        #region Constructor
        public BestStoriesDialog()
        {
            InitializeComponent();
            _hackerNews = new HackerNews();
            _bestStories = new Dictionary<long, HackerNewsStory>();
            _dataTable = new DataTable();

            // setup the DataTable
            _dataTable.Columns.Add("#", typeof(int));
            _dataTable.Columns.Add("Title", typeof(string));
            _dataTable.Columns.Add("Author", typeof(string));

            // setup the DataGridView
            _bestStoriesGrid.AutoSize = true;
            _bestStoriesGrid.DataSource = _dataTable;
            // Configure the details DataGridView so that its columns automatically adjust their widths when the data changes
            _bestStoriesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _bestStoriesGrid.RowHeadersVisible = false;
        }
        #endregion

        #region Events
        /// <summary>
        /// Refresh the stories from the server
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void refresh_Click(object sender, EventArgs e)
        {
            RefreshBestStories();
        }

        /// <summary>
        /// Load the best stories on load
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void BestStoriesDialog_Load(object sender, EventArgs e)
        {
            //RefreshBestStories(); // better to load the list after the dialog appears
        }

        /// <summary>
        /// First time the form is active load the best stories 
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void BestStoriesDialog_Activated(object sender, EventArgs e)
        {
            if (!_loadOnce)
            {
                RefreshBestStories();
                _loadOnce = true;
            }
        }

        /// <summary>
        /// Search for text entered
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        /// <remarks>
        /// Could have wired this to Text Changed or Key Down but I like to enter my search string before searching.
        /// </remarks>
        private void search_Click(object sender, EventArgs e)
        {
            SearchText();
        }

        /// <summary>
        /// Search for text entered when Enter occurs in the text box
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        /// <remarks>
        /// Could have wired this to Text Changed or Key Down but I like to enter my search string before searching.
        /// </remarks>
        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchText();
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Load the best stories from HackerNews
        /// </summary>
        private void RefreshBestStories()
        {
            bool error = false;
            int count = 1;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                status.Text = "Loading stories, please wait...";
                List<long> storyIds = _hackerNews.GetBestStories();

                if (storyIds != null && storyIds.Count > 0)
                {
                    HackerNewsStory story = null;
                    _dataTable.Clear();

                    foreach (long storyId in storyIds)
                    {
                        // see if the story is in the cache
                        if (!_bestStories.TryGetValue(storyId, out story))
                        {
                            story = _hackerNews.GetStoryById(storyId);
                            if (story == null)
                            {
                                // this could mean it's no longer a best story but that would be some seriously bad timing
                                continue;
                            }

                            _bestStories.Add(storyId, story);
                        }

                        // add it to the data table
                        object[] rowValues = { count, story.Title, story.By };
                        _dataTable.Rows.Add(rowValues);
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                status.Text = ex.Message;
                error = true;
            }
            finally
            {
                if (!error)
                    status.Text = (count-1).ToString() + " best stories retrieved";

                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Filter Titles and Authors for anything that matches what was entered in the text box
        /// </summary>
        /// <remarks>
        /// Clear the text box to view all the rows.
        /// Although a search was called for this allows the user to see the results faster than next/previous functionality.
        /// Once this is wired to a DB this can be replaced with a query.
        /// </remarks>
        private void SearchText()
        {
            string filter = string.Empty;

            if (searchText.Text.Length != 0)
            {
                foreach (DataGridViewColumn column in _bestStoriesGrid.Columns)
                {
                    if (column.Index == 0)
                        continue; // skip Story Number

                    // search all other columns for anything that matches 
                    if (filter == string.Empty)
                    {
                        filter = column.Name + " LIKE '%" + searchText.Text + "%'";
                    }
                    else
                    {
                        filter += " OR ";
                        filter += column.Name + " LIKE '%" + searchText.Text + "%'";
                    }
                }
            }

            _dataTable.DefaultView.RowFilter = filter;
        }
        #endregion
    }
}

namespace WinFormsAppTasks
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource? currentCancelTokenSource = null;

        public Form1()
        {
            InitializeComponent();
        }

        void DoSearch(string path, string term, IProgress<FileInfo> progress, CancellationToken token)
        {
            var directory = new DirectoryInfo(path);
            foreach (var item in directory.GetFiles(txtSearch.Text))
            {
                progress.Report(item);
                token.ThrowIfCancellationRequested();
                //if(token.IsCancellationRequested)
                //{
                //    return; 
                //}
                // add to listview
            }

            foreach (var dir in directory.GetDirectories())
            {
                try
                {
                    DoSearch(dir.FullName, term, progress, token);
                    token.ThrowIfCancellationRequested();

                    //if (token.IsCancellationRequested)
                    //{
                    //    return;
                    //}
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    // write to log...
                }
            }
        }

        async Task DoSearchAsync(string path, string term, CancellationToken token)
        {
            var progress = new Progress<FileInfo>(UpdateListView);
            await Task.Run(() => DoSearch(path, term, progress, token), token);


        }

        void UpdateListView(FileInfo fileInfo)
        {
            var lvi = new ListViewItem(fileInfo.Name);
            lvi.SubItems.Add(fileInfo.Length.ToString());
            lvi.SubItems.Add(fileInfo.LastWriteTime.ToString());
            listView1.Items.Add(lvi);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            currentCancelTokenSource = new CancellationTokenSource();
            listView1.Items.Clear();
            lblStatus.Text = "Searching...";
            try
            {
                await DoSearchAsync("c:\\", txtSearch.SelectedText, currentCancelTokenSource.Token);
                lblStatus.Text = "Search complete.";

            }
            catch (OperationCanceledException ex)
            {
                lblStatus.Text = "Search stopped by user...";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            currentCancelTokenSource?.Cancel();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentCancelTokenSource?.Cancel();
        }
    }
}

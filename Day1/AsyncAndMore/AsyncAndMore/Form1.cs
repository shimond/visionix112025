namespace AsyncAndMore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string[] urls = new string[]
            {
                "https://www.example.com",
                "https://www.microsoft.com",
                "https://www.github.com",
                "https://www.stackoverflow.com"
            };
            int sum = 0;
            foreach (string url in urls)
            {
                try
                {
                    listBoxLogs.Items.Add($"Start Download from  {url}");
                    var bytes = await DownloadUrl(url);
                    sum += bytes;
                    listBoxLogs.Items.Add($"Downloaded {bytes} bytes from {url}");

                }
                catch (Exception ex)
                {
                    listBoxLogs.Items.Add($"Failed Downloaded from  {url} -  {ex.Message}");
                }
            }

            this.Text = $"Total bytes downloaded: {sum}";
        }

        private Task<int> DownloadUrl(string url)
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(Random.Shared.Next(2000, 10000));
                if (url.Contains("github"))
                {
                    throw new Exception("Simulated download error.");
                }
                return Random.Shared.Next(200000, 400000);

            });
            

        }
    }
}

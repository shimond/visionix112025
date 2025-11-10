namespace AsyncAndMore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                listBoxLogs.Items.Add($"Start Download from  {url}");
                DownloadUrl(url, bytes =>
                {
                    sum += bytes;
                    listBoxLogs.Items.Add($"Downloaded {bytes} bytes from {url}");
                }, ex =>
                {
                    listBoxLogs.Items.Add($"Failed Downloaded from  {url} -  {ex.Message}");
                });
            }                

            this.Text = $"Total bytes downloaded: {sum}";
        }

        private void DownloadUrl(string url, Action<int> OnSucess, Action<Exception> onError)
        {
            new Thread(()=> {
                if (url.Contains("github"))
                {
                    //throw new Exception("Simulated download error.");
                    onError(new Exception("Simulated download error."));
                }
                Thread.Sleep(Random.Shared.Next(2000, 10000)); // Simulate a delay
                OnSucess(Random.Shared.Next(200000, 400000));
            }).Start();
        }
    }
}

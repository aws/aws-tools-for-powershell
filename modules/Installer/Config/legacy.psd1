@{
    # Temporary repository name used for PowerShell Gallery installations
    AWSToolsTempRepoName = "AWSToolsTemp"
    
    # Current minimum AWS Tools Installer version for validation
    CurrentMinAWSToolsInstallerVersion = "0.0.0.0"
    
    # Parallel downloader C# class code for PowerShell Gallery operations
    ParallelDownloaderClassCode = @"
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class ParallelDownloader
{
    private readonly HttpClient Client;
    private readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

    public ParallelDownloader(HttpClient client)
    {
        Client = client;
    }

    public async Task DownloadToFile(string uri, string filePath)
    {
        using (var httpResponseMessage = await Client.GetAsync(uri, CancellationTokenSource.Token))
        using (var stream = await httpResponseMessage.EnsureSuccessStatusCode().Content.ReadAsStreamAsync())
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await stream.CopyToAsync(fileStream, 81920, CancellationTokenSource.Token);
        }
    }

    public void Cancel()
    {
        CancellationTokenSource.Cancel();
    }
}
"@
}

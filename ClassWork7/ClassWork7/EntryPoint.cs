using System;
using System.Net;

namespace ClassWork7
{
    /// <summary>
    /// Entry point to the program
    /// Download files from ftp server
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Main method downloads all exe files from ftp server
        /// Creates FtpFileDownloader class object
        /// </summary>
        static void Main()
        {
            try
            {
                var downloader = new FtpFileDownloader("ftp://ftp.planningpme.com/fiches/de/", "D:/DownloadedFiles/");
                var ListOfFileNames = downloader.GetListOfFileNames();
                downloader.TimeDisplayer(downloader.ParallelFilesDownloader(ListOfFileNames));
                downloader.TimeDisplayer(downloader.SequentialFilesDownloader(ListOfFileNames));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
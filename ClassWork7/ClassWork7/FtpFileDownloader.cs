using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ClassWork7
{
    /// <summary>
    /// Class downloads files from ftp server
    /// </summary>
    class FtpFileDownloader
    {
        public string PathToServer { get; private set; }
        public string DestinationPath { get; private set; }

        /// <summary>
        /// Constructor initializes properties
        /// Creates directory if doesn't exists
        /// </summary>
        /// <param name="PathToServer">Path of download server</param>
        /// <param name="DestinationPath">Path of directory download</param>
        public FtpFileDownloader(string PathToServer, string DestinationPath)
        {
            this.PathToServer = PathToServer;
            this.DestinationPath = DestinationPath;
            var directory = new DirectoryInfo(this.DestinationPath);

            if (!directory.Exists)
            {
                directory.Create();
            }
        }

        /// <summary>
        /// Returns a list of file names from the server
        /// </summary>
        /// <returns>List of file names</returns>
        public List<string> GetListOfFileNames()
        {
            var request = (FtpWebRequest)WebRequest.Create(this.PathToServer);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            var response = (FtpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var ListOfFileNames = new List<string>();
            string fileName = streamReader.ReadLine();

            while (fileName != null)
            {
                ListOfFileNames.Add(fileName);
                fileName = streamReader.ReadLine();
            }

            streamReader.Close();
            responseStream.Close();
            response.Close();

            return ListOfFileNames;
        }

        /// <summary>
        /// Downloads file from ftp server
        /// </summary>
        /// <param name="fileName">File name</param>
        public void DownloadFile(object fileName)
        {
            string DestinationPath = this.DestinationPath + fileName;
            Console.WriteLine($" {fileName} : Started downloading");
            var request = (FtpWebRequest)WebRequest.Create(this.PathToServer + fileName);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            var response = (FtpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();
            var fileStream = new FileStream(DestinationPath, FileMode.Create);
            byte[] buffer = new byte[64];
            int size = 0;

            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fileStream.Write(buffer, 0, size);
            }

            fileStream.Close();
            responseStream.Close();
            response.Close();
            Console.WriteLine($" {fileName} : Finished downloading");
        }

        /// <summary>
        /// Downloads files from server in order
        /// </summary>
        /// <param name="ListOfFileNames">List of file names</param>
        /// <returns>Time span of downloading</returns>
        public TimeSpan SequentialFilesDownloader(List<string> ListOfFileNames)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (string fileName in ListOfFileNames)
            {
                this.DownloadFile(fileName);
            }

            stopWatch.Stop();
            var timeInterval = stopWatch.Elapsed;
            Console.WriteLine("All files downloaded");

            return timeInterval;
        }

        /// <summary>
        /// Downloads files from server in parallel
        /// </summary>
        /// <param name="ListOfFileNames">List of file names</param>
        /// <returns>Time span of downloading</returns>
        public TimeSpan ParallelFilesDownloader(List<string> ListOfFileNames)
        {
            var tasks = new List<Task>();
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (string fileName in ListOfFileNames)
            {
                tasks.Add(Task.Factory.StartNew(this.DownloadFile, fileName));
            }

            Task.WaitAll(tasks.ToArray());
            stopWatch.Stop();
            var timeInterval = stopWatch.Elapsed;
            Console.WriteLine("All files downloaded");

            return timeInterval;
        }

        /// <summary>
        /// Displays elapsed time
        /// </summary>
        /// <param name="timeInterval">Time interval</param>
        public void TimeDisplayer(TimeSpan timeInterval)
        {
            Console.WriteLine($"Time span {timeInterval.Hours:00} hours {timeInterval.Minutes:00} minutes {timeInterval.Seconds:00} seconds {timeInterval.Milliseconds:00} milliseconds");
        }
    }
}
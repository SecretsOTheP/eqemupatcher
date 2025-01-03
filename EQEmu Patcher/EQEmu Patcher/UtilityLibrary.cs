using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Net.Http;
using System.Threading;
using YamlDotNet.Core.Tokens;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace EQEmu_Patcher
{
    /* General Utility Methods */
    class UtilityLibrary
    {
        //Download a file to current directory
        public static async Task<string> DownloadFile(CancellationTokenSource cts, string url, string outFile)
        {

            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cts.Token);
                response.EnsureSuccessStatusCode();
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var outPath = outFile.Replace("/", "\\");
                    if (outFile.Contains("\\"))
                    { //Make directory if needed.
                        string dir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + outFile.Substring(0, outFile.LastIndexOf("\\"));
                        Directory.CreateDirectory(dir);
                    }
                    outPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + outFile;

                    using (var w = File.Create(outPath))
                    {
                        await stream.CopyToAsync(w, 81920, cts.Token);
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                return "ArgumentNullException: " + e.Message;
            }
            catch (WebException e)
            {
                return "WebException (" + e.Status + "): " + e.Message + " (" + e.GetBaseException() + ")";
            }
            catch (HttpRequestException e)
            {
                return "HttpRequestException: " + e.Message + " (" + e.GetBaseException() + ")";
            }
            catch (Exception e)
            {
                return "Exception: " + e.Message + " (" + e.GetBaseException() + ")";
            }
            return "";      
        }

        // Download will grab a remote URL's file and return the data as a byte array
        public static async Task<byte[]> Download(CancellationTokenSource cts, string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cts.Token);
            response.EnsureSuccessStatusCode();
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                using (var w = new MemoryStream())
                {
                    await stream.CopyToAsync(w, 81920, cts.Token);
                    return w.ToArray();
                }
            }
        }

        public static string GetMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);

                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }

                    return sb.ToString();
                }
            }
        }

        public static System.Diagnostics.Process StartEverquest()
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\eqgame.exe",
                Arguments = "patchme",
                WorkingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
            };

            return System.Diagnostics.Process.Start(startInfo);
        }

        //Pass the working directory (or later, you can pass another directory) and it returns a hash if the file is found
        public static string GetEverquestExecutableHash(string path)
        {
            var di = new System.IO.DirectoryInfo(path);
            var files = di.GetFiles("eqgame.exe");
            if (files == null || files.Length == 0)
            {
                return "";
            }
            return UtilityLibrary.GetMD5(files[0].FullName);
        }

        // Returns true only if the path is a relative and does not contain ..
        public static bool IsPathChild(string path)
        {
            // get the absolute path
            var absPath = Path.GetFullPath(path);
            var basePath = Path.GetDirectoryName(Application.ExecutablePath);
            // check if absPath contains basePath
            if (!absPath.Contains(basePath))
            {
                return false;
            }
            if (path.Contains("..\\"))
            {
                return false;
            }
            return true;
        }
    }
}

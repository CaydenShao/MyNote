using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace MyNote.Common.Helpers
{
    public class FTPHelper
    {
        /// <summary>
        /// FTP连接地址
        /// </summary>
        private string ftpServerIP = string.Empty;
        /// <summary>
        /// FTP连接端口
        /// </summary>
        private string ftpServerPort = string.Empty;
        /// <summary>
        /// 指定FTP连接成功后的当前目录, 如果不指定即默认为根目录
        /// </summary>
        private string ftpRemotePath = string.Empty;
        /// <summary>
        /// 用户名
        /// </summary>
        private string ftpUserID = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        private string ftpPassword = string.Empty;
        /// <summary>
        /// FTP虚拟路径
        /// </summary>
        private string virtualPath = string.Empty;
        /// <summary>
        /// 当前目录的FTP完整地址
        /// </summary>
        private string ftpURI = string.Empty;

        /// <summary>  
        /// 连接FTP服务器
        /// </summary>  
        /// <param name="FtpServerIP">FTP连接地址</param>  
        /// <param name="_ftpServerPort">FTP连接端口</param>
        /// <param name="_virtualPath">FTP虚拟路径不带后缀“/”</param>
        /// <param name="_ftpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>  
        /// <param name="_ftpUserID">用户名</param>  
        /// <param name="_ftpPassword">密码</param>  
        public FTPHelper(string _ftpServerIP, string _ftpServerPort, string _virtualPath, string _ftpRemotePath, string _ftpUserID, string _ftpPassword)
        {
            this.ftpServerIP = _ftpServerIP;
            this.ftpServerPort = _ftpServerPort;
            this.virtualPath = _virtualPath;
            this.ftpRemotePath = _ftpRemotePath;
            this.ftpUserID = _ftpUserID;
            this.ftpPassword = _ftpPassword;

            if (string.IsNullOrEmpty(this.virtualPath))
            {
                this.ftpURI = "ftp://" + this.ftpServerIP + ":" + this.ftpServerPort + "/";
            }
            else
            {
                this.ftpURI = "ftp://" + this.ftpServerIP + ":" + this.ftpServerPort + "/" + this.virtualPath + "/";
            }

            if (!string.IsNullOrEmpty(this.ftpRemotePath))
            {
                this.ftpURI += this.ftpRemotePath + "/";
            }
        }

        /// <summary>  
        /// 上传  
        /// </summary>   
        public void Upload(string filename)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filename);
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpURI + fileInfo.Name));
                ftpRequest.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.KeepAlive = false;
                ftpRequest.UseBinary = true;
                ftpRequest.ContentLength = fileInfo.Length;

                using (FileStream fs = fileInfo.OpenRead())
                {
                    using (Stream strm = ftpRequest.GetRequestStream())
                    {
                        int buffLength = 2048;
                        byte[] buff = new byte[buffLength];
                        int contentLen;
                        contentLen = fs.Read(buff, 0, buffLength);

                        while (contentLen != 0)
                        {
                            strm.Write(buff, 0, contentLen);
                            contentLen = fs.Read(buff, 0, buffLength);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// 下载  
        /// </summary>   
        public void Download(string filePath, string fileName)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpURI + fileName));
                ftpRequest.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.UseBinary = true;

                using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    using (FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create))
                    {
                        using (Stream ftpStream = response.GetResponseStream())
                        {
                            long cl = response.ContentLength;
                            int bufferSize = 2048;
                            int readCount;
                            byte[] buffer = new byte[bufferSize];
                            readCount = ftpStream.Read(buffer, 0, bufferSize);

                            while (readCount > 0)
                            {
                                outputStream.Write(buffer, 0, readCount);
                                readCount = ftpStream.Read(buffer, 0, bufferSize);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// 删除文件  
        /// </summary>  
        public string Delete(string fileName)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpURI + fileName));
                ftpRequest.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                ftpRequest.KeepAlive = false;
                string result = string.Empty;

                using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    long size = response.ContentLength;

                    using (Stream datastream = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(datastream))
                        {
                            result = sr.ReadToEnd();
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// 获取当前目录下明细(包含文件和文件夹)  
        /// </summary>  
        public string[] GetFilesDetailList()
        {
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpURI));
                ftpRequest.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                using (WebResponse response = ftpRequest.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        while (line != null)
                        {
                            result.Append(line);
                            result.Append("\n");
                            line = reader.ReadLine();
                        }

                        result.Remove(result.ToString().LastIndexOf("\n"), 1);
                    }
                }

                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// 获取FTP文件列表(包括文件夹)
        /// </summary>   
        public List<string> GetAllList()
        {
            List<string> list = new List<string>();

            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.ftpURI));
                ftpRequest.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;

                using (FtpWebResponse res = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                    {
                        string s;

                        while ((s = sr.ReadLine()) != null)
                        {
                            list.Add(s);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return list;
        }

        /// <summary>  
        /// 获取当前目录下文件列表(不包括文件夹)  
        /// </summary>  
        public string[] GetFileList()
        {
            StringBuilder result = new StringBuilder();

            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpURI));
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                using (WebResponse response = ftpRequest.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string line = reader.ReadLine();

                        while (line != null)
                        {
                            if (line.IndexOf("<DIR>") == -1)
                            {
                                result.Append(Regex.Match(line, @"[\S]+ [\S]+", RegexOptions.IgnoreCase).Value.Split(' ')[1]);
                                result.Append("\n");
                            }

                            line = reader.ReadLine();
                        }

                        result.Remove(result.ToString().LastIndexOf('\n'), 1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToString().Split('\n');
        }

        /// <summary>  
        /// 判断当前目录下指定的文件是否存在  
        /// </summary>  
        /// <param name="RemoteFileName">远程文件名</param>  
        public bool FileExist(string remoteFileName)
        {
            string[] fileList = this.GetFileList();

            foreach (string str in fileList)
            {
                if (str.Trim() == remoteFileName.Trim())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 判断当前目录下指定的目录是否存在  
        /// </summary>
        /// <param name="dirName">远程目录名称</param>
        /// <returns></returns>
        public bool DirectoryExist(string dirName)
        {
            List<string> fileList = this.GetAllList();

            foreach (string str in fileList)
            {
                if (str.Trim() == dirName.Trim())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>  
        /// 创建文件夹  
        /// </summary>   
        public void MakeDir(string dirName)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpURI + dirName));
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);

                using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    using (Stream ftpStream = response.GetResponseStream())
                    { }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// 获取指定文件大小  
        /// </summary>  
        public long GetFileSize(string filename)
        {
            long fileSize = 0;

            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpURI + filename));
                ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);

                using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    using (Stream ftpStream = response.GetResponseStream())
                    {
                        fileSize = response.ContentLength;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return fileSize;
        }

        /// <summary>  
        /// 更改文件名  
        /// </summary> 
        public void ReName(string currentFilename, string newFilename)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.ftpURI + currentFilename));
                ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                ftpRequest.RenameTo = newFilename;
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);

                using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    using (Stream ftpStream = response.GetResponseStream())
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// 切换当前目录  
        /// </summary>  
        /// <param name="IsRoot">true:绝对路径 false:相对路径</param>   
        public void GotoDirectory(string directoryName, bool isRoot)
        {
            if (isRoot)
            {
                this.ftpRemotePath = directoryName;
            }
            else
            {
                this.ftpRemotePath += directoryName + "/";
            }

            this.ftpURI = "ftp://" + this.ftpServerIP + "/" + this.ftpRemotePath + "/";
        }
    }
}

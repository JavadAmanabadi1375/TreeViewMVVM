
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfTreeView
{
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// Gets all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrive()
        {
           return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();

        }

        /// <summary>
        /// Get the directory top-level content
        /// </summary>
        /// <param name="fullpath">The full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContent(string fullpath)
        {
            //Creat empty list
            var items=new List<DirectoryItem>(); 

            #region Get directories

            try
            {
                var dirs = Directory.GetDirectories(fullpath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem() {FullPath=dir, Type=DirectoryItemType.Folder }));
            }
            catch { }

            #endregion

            #region Get files

            try
            {
                var fs = Directory.GetFiles(fullpath);
                if (fs.Length > 0)
                    items.AddRange(fs.Select(File => new DirectoryItem() {FullPath=File, Type=DirectoryItemType.File }));
            }
            catch { }

            #endregion

            return items;

        }

        #region Helper 
        ///<summary>
        ///Find the file or folder name from a full path
        ///</summary>
        public static string GetFileFolderName(string path)
        {
            // If we have no path return empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            //Make all slashes back slashes
            var normalizedPath = path.Replace("/", "\\");

            //Find the latest backslashes in the path
            var lastIndex = normalizedPath.LastIndexOf("\\");

            // if we don't find a backslash, return the  path itselt
            if (lastIndex <= 0)
                return path;

            return path.Substring(lastIndex + 1);
        }
        #endregion


    }
}

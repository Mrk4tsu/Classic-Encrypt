using FolderBrowserEx;
using System.Windows.Forms;


namespace MaDES.Utils
{
    public class FolderUtilities
    {
        public static FolderUtilities instance { get; } = new FolderUtilities();
        public string GetUrlFile(string filter)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "Documents\\";
                openFileDialog.Filter = filter;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }
                string filePath = openFileDialog.FileName;
                return filePath;
            }
        }
        public string GetUrlFolder()
        {
            FolderBrowserEx.FolderBrowserDialog browserDialog = new FolderBrowserEx.FolderBrowserDialog();
            browserDialog.Title = "Select a folder";
            browserDialog.InitialFolder = @"C:\";
            browserDialog.AllowMultiSelect = false;
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = browserDialog.SelectedFolder;
                return folderPath;
            }
            return null;

            //using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            //{
            //    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string folderPath = folderBrowserDialog.SelectedPath;
            //        return folderPath;
            //    }
            //    return null;
            //}
        }
    }
}

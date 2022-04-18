using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;

namespace SRiazanov_ComputerVisionApp.Utilities
{
   public class FilePicker
    {
        private FileOpenPicker pick;
        private static FilePicker instance;
        public static FilePicker current
        {
            get
            {
                return instance;
            }
        }
        static FilePicker()
        {
            instance = new FilePicker();
        }
        private FilePicker()
        {
            pick = new FileOpenPicker();
            pick.FileTypeFilter.Add(".png");
            pick.FileTypeFilter.Add(".jpg");
            pick.FileTypeFilter.Add(".gif");
            pick.FileTypeFilter.Add(".bmp");
            pick.FileTypeFilter.Add(".jpeg");
        }
        public async Task<StorageFile> GetImage()
        {
        StorageFile s = await pick.PickSingleFileAsync();
           // var prp = await s.GetBasicPropertiesAsync();
            /*if (prp.Size > 4000000)
            {
                MessageDialog dialog = new MessageDialog("File size should be greater than 4 MB");
                await dialog.ShowAsync();
                s = null;
                goto repeat;
            }*/
            return s;
        }
        public async Task<StorageFile> GetFile(string filename, string foldername)
        {
            StorageFolder appFolder = Package.Current.InstalledLocation;
            StorageFolder folder = await appFolder.GetFolderAsync(foldername);
            var file = await folder.GetFileAsync(filename);
            return file;
        }
    }
}

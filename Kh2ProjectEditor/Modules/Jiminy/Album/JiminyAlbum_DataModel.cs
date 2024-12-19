using Kh2ProjectEditor.Modules.Common;
using Kh2ProjectEditor.Services;
using Kh2ProjectEditor.Services.Files;
using KhLib.Kh2.Jiminy;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kh2ProjectEditor.Modules.Jiminy.Album
{
    internal class JiminyAlbum_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<JiminyAlbum_Wrapper> LoadedEntries { get; set; }

        /******************************************
         * View settings
         ******************************************/
        public List<string> WorldOptions => new JmWorld_Converter().Options.Values.ToList();

        public JiminyAlbum_DataModel()
        {
            LoadedEntries = new ObservableCollection<JiminyAlbum_Wrapper>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!ProjectService.Instance.JiminyExists)
            {
                return;
            }

            LoadData(FileJiminy_Service.Instance.AlbuFile);
        }

        public void LoadData(AlbumFile khFile)
        {
            LoadedEntries.Clear();
            foreach (AlbumFile.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(new JiminyAlbum_Wrapper(entry));
            }
        }

        public void SaveFile()
        {
            FileJiminy_Service.Instance.AlbuFile.Entries.Clear();
            foreach (JiminyAlbum_Wrapper wrapper in LoadedEntries)
            {
                FileJiminy_Service.Instance.AlbuFile.Entries.Add(wrapper.ToEntry());
            }

            FileJiminy_Service.Instance.SaveBarFile("albu");
            FileJiminy_Service.Instance.SaveJiminyFile();
            FileJiminy_Service.Instance.LoadFromProject();
        }
    }
}

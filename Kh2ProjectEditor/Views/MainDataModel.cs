using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Services;

namespace Kh2ProjectEditor.Views
{
    public partial class MainDataModel : ObservableObject
    {
        [ObservableProperty]
        public string projectPath = "Select project Folder";

        [ObservableProperty]
        public string gameHookInfo = "Game not hooked";


        public void LoadProjectFolder(string selectedFolder)
        {
            ProjectPath = selectedFolder;
            ProjectService.Instance.LoadProject(selectedFolder);
        }
    }
}

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

        public GameHook_Service GHService { get => GameHook_Service.Instance; }
        public Process_Service ProcService { get => Process_Service.Instance; }

        public bool tess {  get; set; }


        public void LoadProjectFolder(string selectedFolder)
        {
            ProjectPath = selectedFolder;
            ProjectService.Instance.LoadProject(selectedFolder);
        }
    }
}

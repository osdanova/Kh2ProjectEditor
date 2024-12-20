using CommunityToolkit.Mvvm.ComponentModel;
using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Mixdata;
using static KhLib.Kh2.Mixdata.RecipesFile;

namespace Kh2ProjectEditor.Modules.MixData.Recipes
{
    internal partial class MixDataRecipes_Wrapper : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Recipe))] public ushort recipeId;
        [ObservableProperty] public UnlockType unlockType;
        [ObservableProperty] public Rank rank;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item1))] public ushort item1Id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Item2))] public ushort item2Id;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Material1))] public ushort material1Id;
        [ObservableProperty] public ushort material1Count;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Material2))] public ushort material2Id;
        [ObservableProperty] public ushort material2Count;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Material3))] public ushort material3Id;
        [ObservableProperty] public ushort material3Count;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Material4))] public ushort material4Id;
        [ObservableProperty] public ushort material4Count;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Material5))] public ushort material5Id;
        [ObservableProperty] public ushort material5Count;
        [ObservableProperty][NotifyPropertyChangedFor(nameof(Material6))] public ushort material6Id;
        [ObservableProperty] public ushort material6Count;
        public string Recipe => DataFetcher.GetItemName(RecipeId);
        public string Item1 => DataFetcher.GetItemName(Item1Id);
        public string Item2 => DataFetcher.GetItemName(Item2Id);
        public string Material1 => DataFetcher.GetItemName(Material1Id);
        public string Material2 => DataFetcher.GetItemName(Material2Id);
        public string Material3 => DataFetcher.GetItemName(Material3Id);
        public string Material4 => DataFetcher.GetItemName(Material4Id);
        public string Material5 => DataFetcher.GetItemName(Material5Id);
        public string Material6 => DataFetcher.GetItemName(Material6Id);

        public MixDataRecipes_Wrapper(RecipesFile.Entry entry)
        {
            recipeId = entry.RecipeId;
            unlockType = entry.UnlockType;
            rank = entry.Rank;
            item1Id = entry.Item1Id;
            item2Id = entry.Item2Id;
            material1Id = entry.Material1Id;
            material1Count = entry.Material1Count;
            material2Id = entry.Material2Id;
            material2Count = entry.Material2Count;
            material3Id = entry.Material3Id;
            material3Count = entry.Material3Count;
            material4Id = entry.Material4Id;
            material4Count = entry.Material4Count;
            material5Id = entry.Material5Id;
            material5Count = entry.Material5Count;
            material6Id = entry.Material6Id;
            material6Count = entry.Material6Count;
        }

        public RecipesFile.Entry ToEntry()
        {
            return new RecipesFile.Entry
            {
                RecipeId = recipeId,
                UnlockType = unlockType,
                Rank = rank,
                Item1Id = item1Id,
                Item2Id = item2Id,
                Material1Id = material1Id,
                Material1Count = material1Count,
                Material2Id = material2Id,
                Material2Count = material2Count,
                Material3Id = material3Id,
                Material3Count = material3Count,
                Material4Id = material4Id,
                Material4Count = material4Count,
                Material5Id = material5Id,
                Material5Count = material5Count,
                Material6Id = material6Id,
                Material6Count = material6Count,
            };
        }
    }
}

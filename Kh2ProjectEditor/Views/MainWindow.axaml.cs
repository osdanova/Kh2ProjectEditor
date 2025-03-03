using Avalonia.Controls;
using Kh2ProjectEditor.Utils;
using Kh2ProjectEditor.Views;
using System.Collections.Generic;
using System.IO;

namespace Kh2ProjectEditor;

public partial class MainWindow : Window
{
    MainDataModel dataModel;
    public MainWindow()
    {
        dataModel = new MainDataModel();
        this.DataContext = dataModel;
        InitializeComponent();
    }

    private async void Button_ProjectPath(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        List<string> openDialogResults = await AvaloniaDialogUtils.OpenFolderDialog(this, "Select the project folder");
        if(openDialogResults.Count == 0 || !Directory.Exists(openDialogResults[0])) {
            return;
        }
        dataModel.LoadProjectFolder(openDialogResults[0]);
    }

    /******************************************
    * Objentry
    ******************************************/
    private void MenuItem_ObjectEntries(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new ObjectEntries_Control();

    /******************************************
    * System
    ******************************************/
    private void MenuItem_SystemReactionCount(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemReactionCount_Control();
    private void MenuItem_SystemCommands(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemCommands_Control();
    private void MenuItem_SystemMemberTable(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemMemberTable_Control();
    private void MenuItem_SystemWeapons(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemWeapons_Control();
    private void MenuItem_SystemItems(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemItems_Control();
    private void MenuItem_SystemTreasures(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemTreasures_Control();
    private void MenuItem_SystemAreaInfo(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemAreaInfo_Control();
    private void MenuItem_SystemFontStyles(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemFontStyles_Control();
    private void MenuItem_SystemShops(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemShops_Control();
    private void MenuItem_SystemSkeleton(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemSkeleton_Control();
    private void MenuItem_SystemEventParams(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemEventParams_Control();
    private void MenuItem_SystemPrefPlayer(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemPrefPlayer_Control();
    private void MenuItem_SystemPrefFormAbilities(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemPrefFormAbilities_Control();
    private void MenuItem_SystemPrefParty(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemPrefParty_Control();
    private void MenuItem_SystemPrefSystem(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemPrefSstm_Control();
    private void MenuItem_SystemPrefMagic(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new SystemPrefMagic_Control();

    /******************************************
    * Battle
    ******************************************/
    private void MenuItem_BattleAtkp(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattleAttackParams_Control();
    private void MenuItem_BattlePtya(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattlePartyAttacks_Control();
    private void MenuItem_BattlePrzt(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattlePrizeTable_Control();
    private void MenuItem_BattleVtbl(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattleVoiceTable_Control();
    private void MenuItem_BattleLvup(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattleLevelUp_Control();
    private void MenuItem_BattleBons(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattleBonusLevels_Control();
    private void MenuItem_BattleBtlv(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattleBattleLevel_Control();
    private void MenuItem_BattleLvpm(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattleLevelParams_Control();
    private void MenuItem_BattleEnmp(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattleEnemyParams_Control();
    private void MenuItem_BattlePatn(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattlePatterns_Control();
    private void MenuItem_BattlePlrp(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattlePlayerParams_Control();
    private void MenuItem_BattleLimt(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattleLimits_Control();
    private void MenuItem_BattleSumn(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattleSummons_Control();
    private void MenuItem_BattleMagc(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattleMagic_Control();
    private void MenuItem_BattleFmlv(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattleFormLevels_Control();
    private void MenuItem_BattleStop(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BattleStop_Control();

    /******************************************
    * Jiminy
    ******************************************/
    private void MenuItem_JiminyWorl(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new JiminyWorlds_Control();
    private void MenuItem_JiminyStor(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new JiminyStory_Control();
    private void MenuItem_JiminyAlbu(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new JiminyAlbum_Control();
    private void MenuItem_JiminyChar(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new JiminyCharacters_Control();
    private void MenuItem_JiminyAnse(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new JiminyAnsemReports_Control();
    private void MenuItem_JiminyDiag(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new JiminyDiagrams_Control();
    private void MenuItem_JiminyLimi(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new JiminyLimits_Control();
    private void MenuItem_JiminyMini(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new JiminyMinigames_Control();
    private void MenuItem_JiminyQues(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new JiminyQuests_Control();
    private void MenuItem_JiminyPuzz(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new JiminyPuzzle_Control();

    /******************************************
    * MixData / Synthesis
    ******************************************/
    private void MenuItem_MixDataReci(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new MixDataRecipes_Control();
    private void MenuItem_MixDataCond(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new MixDataConditions_Control();
    private void MenuItem_MixDataLeve(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new MixDataLevels_Control();
    private void MenuItem_MixDataExp(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new MixDataExperience_Control();

    /******************************************
    * Misc.
    ******************************************/
    private void MenuItem_LocalSet(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new LocalSet_Control();

    /******************************************
    * Tools
    ******************************************/
    private void MenuItem_ToolsBarEditor(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new BarEditor_Control();
    private void MenuItem_ToolsTest(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new Test_Control();
    private void MenuItem_ToolsEntityList(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => ContentFrame.Content = new ToolsEntityList_Control();
}
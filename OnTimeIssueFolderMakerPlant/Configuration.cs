using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrayGarden.Reception.Services;
using TrayGarden.Services.PlantServices.UserConfig.Core.Interfaces;
using TrayGarden.Services.PlantServices.UserConfig.Core.Interfaces.TypeSpecific;

namespace OnTimeIssueFolderMakerPlant
{
  public class Configuration : IUserConfiguration
  {
    public const string FolderBasePathSettingName = "Folders base path";
    public const string FolderNameLengthLimiSettingName = "Folder name length limit";
    public const string ListenClipboardSettingName = "Listen clipboard for values";
    public static Configuration ActualConfig = new Configuration();

    public IPersonalUserSettingsSteward SettingsSteward { get; set; }

    public IStringUserSetting RootFolderPathSetting { get; protected set; }

    public IIntUserSetting FolderNameLimitSetting { get; protected set; }

    public IBoolUserSetting ListenClipboardSetting { get; protected set; }

    public void StoreAndFillPersonalSettingsSteward(IPersonalUserSettingsSteward personalSettingsSteward)
    {
      SettingsSteward = personalSettingsSteward;
      RootFolderPathSetting = personalSettingsSteward.DeclareStringSetting(FolderBasePathSettingName, FolderBasePathSettingName, @"C:\ISSUES");
      FolderNameLimitSetting = personalSettingsSteward.DeclareIntSetting(FolderNameLengthLimiSettingName, FolderNameLengthLimiSettingName, 65);
      ListenClipboardSetting = personalSettingsSteward.DeclareBoolSetting(ListenClipboardSettingName, ListenClipboardSettingName, true);

    }
  }
}

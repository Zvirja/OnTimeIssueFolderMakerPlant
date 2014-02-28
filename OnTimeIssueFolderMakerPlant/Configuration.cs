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
    #region Constants

    public const string FolderBasePathSettingName = "Folders base path";
    public const string FolderNameLengthLimiSettingName = "Folder name length limit";
    public const string ListenClipboardSettingName = "Listen clipboard for values";

    #endregion

    #region Static Fields

    public static Configuration ActualConfig = new Configuration();

    #endregion

    #region Public Properties

    public IIntUserSetting FolderNameLimitSetting { get; protected set; }

    public IBoolUserSetting ListenClipboardSetting { get; protected set; }
    public IStringUserSetting RootFolderPathSetting { get; protected set; }
    public IPersonalUserSettingsSteward SettingsSteward { get; set; }

    #endregion

    #region Public Methods and Operators

    public void StoreAndFillPersonalSettingsSteward(IPersonalUserSettingsSteward personalSettingsSteward)
    {
      this.SettingsSteward = personalSettingsSteward;
      this.RootFolderPathSetting = personalSettingsSteward.DeclareStringSetting(FolderBasePathSettingName, FolderBasePathSettingName, @"C:\ISSUES");
      this.FolderNameLimitSetting = personalSettingsSteward.DeclareIntSetting(FolderNameLengthLimiSettingName, FolderNameLengthLimiSettingName, 65);
      this.ListenClipboardSetting = personalSettingsSteward.DeclareBoolSetting(ListenClipboardSettingName, ListenClipboardSettingName, true);
    }

    #endregion
  }
}
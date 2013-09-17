using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrayGarden.Reception.Services;
using TrayGarden.Services.PlantServices.UserConfig.Core.Interfaces;

namespace OnTimeIssueFolderMakerPlant
{
  public class Configuration : IUserConfiguration
  {
    public const string FolderBasePathSettingName = "Folders base path";
    public const string FolderNameLengthLimiSettingName = "Folder name length limit";
    public const string ListenClipboardSettingName = "Listen clipboard for values";
    public static Configuration ActualConfig = new Configuration();

    public IUserSettingsBridge SettingsBridge { get; set; }

    public string RootFolder
    {
      get { return SettingsBridge.GetUserSetting(FolderBasePathSettingName).StringValue; }
    }

    public int FolderNameLimit
    {
      get { return SettingsBridge.GetUserSetting(FolderNameLengthLimiSettingName).IntValue; }
    }

    public bool ListenClipboard
    {
      get { return SettingsBridge.GetUserSetting(ListenClipboardSettingName).BoolValue; }
      set { SettingsBridge.GetUserSetting(ListenClipboardSettingName).BoolValue = value; }
    }

    public bool GetUserSettingsMetadata(IUserSettingsMetadataBuilder metadataBuilder)
    {
      metadataBuilder.DeclareStringSetting(FolderBasePathSettingName, "C:\\ISSUES");
      metadataBuilder.DeclareIntSetting(FolderNameLengthLimiSettingName, 65);
      metadataBuilder.DeclareBoolSetting(ListenClipboardSettingName, true);
      return true;
    }

    public void StoreUserSettingsBridge(IUserSettingsBridge userSettingsBridge)
    {
      SettingsBridge = userSettingsBridge;
    }

  }
}

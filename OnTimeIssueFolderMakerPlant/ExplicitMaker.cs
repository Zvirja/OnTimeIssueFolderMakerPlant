using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OnTimeIssueFolderMakerPlant.OnTime;
using OnTimeIssueFolderMakerPlant.Properties;
using TrayGarden.Reception.Services;
using TrayGarden.Services.FleaMarket.IconChanger;
using TrayGarden.Services.PlantServices.GlobalMenu.Core.ContextMenuCollecting;

namespace OnTimeIssueFolderMakerPlant
{
  public class ExplicitMaker : IChangesGlobalIcon, IExtendsGlobalMenu
  {
    #region Static Fields

    public static ExplicitMaker Maker = new ExplicitMaker();

    #endregion

    #region Public Properties

    public INotifyIconChangerClient NotifyIconChangerClient { get; set; }

    #endregion

    #region Public Methods and Operators

    public bool FillProvidedContextMenuBuilder(IMenuEntriesAppender menuAppender)
    {
      menuAppender.AppentMenuStripItem("Create issue folder based on clipboard", Resources.box_love, this.ProcessClipboardValue);
      menuAppender.AppentMenuStripItem("Open issue folders storage", Resources.box, this.OpenStorage);
      return true;
    }

    public void StoreGlobalIconChangingAssignee(INotifyIconChangerClient notifyIconChangerClient)
    {
      this.NotifyIconChangerClient = notifyIconChangerClient;
    }

    #endregion

    #region Methods

    private void OpenStorage(object sender, EventArgs e)
    {
      try
      {
        Process.Start(Configuration.ActualConfig.RootFolderPathSetting.Value);
      }
      catch
      {
        this.NotifyIconChangerClient.SetIcon(Resources.error);
      }
    }

    private void ProcessClipboardValue(object sender, EventArgs eventArgs)
    {
      string clipboardText = ClipboardManager.Manager.Provider.GetCurrentClipboardText();
      Tuple<int, string> resolveOnTimeValue = OnTimeValueResolver.Resolver.ResolveOnTimeValue(clipboardText);
      if (resolveOnTimeValue == null)
      {
        this.NotifyIconChangerClient.SetIcon(Resources.empty);
        return;
      }
      string madeFolder = FolderMaker.Maker.MakeFolder(resolveOnTimeValue);
      if (madeFolder == null)
      {
        this.NotifyIconChangerClient.SetIcon(Resources.error);
      }
      else
      {
        this.NotifyIconChangerClient.SetIcon(Resources.box_love);
        try
        {
          Process.Start(madeFolder);
        }
        catch
        {
        }
      }
    }

    #endregion
  }
}
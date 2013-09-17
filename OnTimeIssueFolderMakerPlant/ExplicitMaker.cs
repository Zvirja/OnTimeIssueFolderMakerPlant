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
  public class ExplicitMaker:IChangesGlobalIcon, IExtendsGlobalMenu
  {
    public static ExplicitMaker Maker = new ExplicitMaker();
    public INotifyIconChangerClient NotifyIconChangerClient { get; set; }

    public void StoreGlobalIconChangingAssignee(INotifyIconChangerClient notifyIconChangerClient)
    {
      NotifyIconChangerClient = notifyIconChangerClient;
    }

    public bool FillProvidedContextMenuBuilder(IMenuEntriesAppender menuAppender)
    {
      menuAppender.AppentMenuStripItem("Create issue folder based on clipboard",Resources.box_love,ProcessClipboardValue);
      menuAppender.AppentMenuStripItem("Open issue folders storage", Resources.box, OpenStorage);
      return true;
    }

    private void OpenStorage(object sender, EventArgs e)
    {
      try
      {
        Process.Start(Configuration.ActualConfig.RootFolder);
      }
      catch
      {
        NotifyIconChangerClient.SetIcon(Resources.error);
      }
    }

    private void ProcessClipboardValue(object sender, EventArgs eventArgs)
    {
      string clipboardText = ClipboardManager.Manager.Provider.GetCurrentClipboardText();
      Tuple<int, string> resolveOnTimeValue = OnTimeValueResolver.Resolver.ResolveOnTimeValue(clipboardText);
      if (resolveOnTimeValue == null) 
      {
        NotifyIconChangerClient.SetIcon(Resources.empty);
        return;
      }
      string madeFolder = FolderMaker.Maker.MakeFolder(resolveOnTimeValue);
      if (madeFolder == null)
      {
        NotifyIconChangerClient.SetIcon(Resources.error);
      }
      else
      {
        NotifyIconChangerClient.SetIcon(Resources.box_love);
        try
        {
          Process.Start(madeFolder);
        }
        catch
        {
          
        }
      }
    }
  }
}

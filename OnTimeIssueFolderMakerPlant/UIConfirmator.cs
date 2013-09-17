using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrayGarden.Helpers;
using TrayGarden.Reception.Services;
using TrayGarden.Services.PlantServices.UserNotifications.Core.Plants;
using TrayGarden.Services.PlantServices.UserNotifications.Core.UI.Displaying;
using TrayGarden.Services.PlantServices.UserNotifications.Core.UI.ResultDelivering;
using TrayGarden.Services.PlantServices.UserNotifications.Core.UI.SpecializedNotifications.Interfaces;

namespace OnTimeIssueFolderMakerPlant
{
  public class UIConfirmator:IGetPowerOfUserNotifications
  {
    public static UIConfirmator ActualConfirmator = new UIConfirmator();

    public ILordOfNotifications LordOfNotifications { get; set; }

    public void StoreLordOfNotifications(ILordOfNotifications lordOfNotifications)
    {
      LordOfNotifications = lordOfNotifications;
    }

    public ResultCode ShowConfirmDialog(string infoToDisplay)
    {
      IYesNoNotification notification = LordOfNotifications.CreateYesNoNotification(infoToDisplay);
      notification.HeaderTextOptions.Size = 14;
      INotificationResultCourier resultCourier = LordOfNotifications.DisplayNotification(notification);
      return resultCourier.GetResultWithWait().Code;
    }

    public void ShowInfoDialog(string infoToDisplay)
    {
      IInformNotification notification = LordOfNotifications.CreateInformNotification(infoToDisplay);
      notification.TextDisplayFont.Size = 14;
      LordOfNotifications.DisplayNotification(notification);
    }
  }
}

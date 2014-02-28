using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrayGarden.Reception.Services;
using TrayGarden.Services.PlantServices.UserNotifications.Core.Plants;
using TrayGarden.Services.PlantServices.UserNotifications.Core.UI.Displaying;
using TrayGarden.Services.PlantServices.UserNotifications.Core.UI.ResultDelivering;
using TrayGarden.Services.PlantServices.UserNotifications.Core.UI.SpecializedNotifications.Interfaces;

namespace OnTimeIssueFolderMakerPlant
{
  public class UIConfirmator : IGetPowerOfUserNotifications
  {
    #region Static Fields

    public static UIConfirmator ActualConfirmator = new UIConfirmator();

    #endregion

    #region Public Properties

    public ILordOfNotifications LordOfNotifications { get; set; }

    #endregion

    #region Public Methods and Operators

    public ResultCode ShowConfirmDialog(string infoToDisplay)
    {
      IYesNoNotification notification = this.LordOfNotifications.CreateYesNoNotification(infoToDisplay);
      notification.HeaderTextOptions.Size = 14;
      INotificationResultCourier resultCourier = this.LordOfNotifications.DisplayNotification(notification);
      return resultCourier.GetResultWithWait().Code;
    }

    public void ShowInfoDialog(string infoToDisplay)
    {
      IInformNotification notification = this.LordOfNotifications.CreateInformNotification(infoToDisplay);
      notification.TextDisplayFont.Size = 14;
      this.LordOfNotifications.DisplayNotification(notification);
    }

    public void StoreLordOfNotifications(ILordOfNotifications lordOfNotifications)
    {
      this.LordOfNotifications = lordOfNotifications;
    }

    #endregion
  }
}
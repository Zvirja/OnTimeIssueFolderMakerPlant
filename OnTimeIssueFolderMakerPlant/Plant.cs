using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrayGarden.Reception;

namespace OnTimeIssueFolderMakerPlant
{
  public class Plant : IPlant, TrayGarden.Reception.IServicesDelegation
  {
    #region Constructors and Destructors

    public Plant()
    {
      this.HumanSupportingName = "Folder maker for OnTime ticket";
      this.Description = "This plant allows to generate the folder for OnTime ticket.";
    }

    #endregion

    #region Public Properties

    public string Description { get; private set; }
    public string HumanSupportingName { get; private set; }

    #endregion

    #region Public Methods and Operators

    public List<object> GetServiceDelegates()
    {
      return new List<object>
      {
        UIConfirmator.ActualConfirmator,
        ClipboardManager.Manager,
        Configuration.ActualConfig,
        ExplicitMaker.Maker
      };
    }

    public void Initialize()
    {
    }

    public void PostServicesInitialize()
    {
    }

    #endregion
  }
}
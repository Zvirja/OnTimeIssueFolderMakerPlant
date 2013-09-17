using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrayGarden.Reception;

namespace OnTimeIssueFolderMakerPlant
{
  public class Plant : IPlant, TrayGarden.Reception.IServicesDelegation
  {
    public string HumanSupportingName { get; private set; }
    public string Description { get; private set; }


    public Plant()
    {
      HumanSupportingName = "Folder maker for OnTime ticket";
      Description = "This plant allows to generate the folder for OnTime ticket.";
    }

    public void Initialize()
    {

    }

    public void PostServicesInitialize()
    {

    }

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
  }
}

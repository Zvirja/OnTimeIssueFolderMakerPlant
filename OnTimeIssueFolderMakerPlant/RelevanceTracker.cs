using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnTimeIssueFolderMakerPlant.OnTime;
using TrayGarden.Services.PlantServices.GlobalMenu.Core.DynamicState;

namespace OnTimeIssueFolderMakerPlant
{
  public class RelevanceTracker
  {
    public RelevanceTracker(SimpleDynamicStateProvider stateProvider)
    {
      this.StateProvider = stateProvider;
      ClipboardManager.Manager.ClipboardValueChangedForRelevance += ManagerOnClipboardValueChangedForRelevance;
      this.OnTimeValueResolver = OnTimeValueResolver.Resolver;
    }

    public SimpleDynamicStateProvider StateProvider { get; set; }

    public OnTimeValueResolver OnTimeValueResolver { get; set; }

    protected virtual void ManagerOnClipboardValueChangedForRelevance(string newValue)
    {
      if(this.OnTimeValueResolver.ResolveOnTimeValue(newValue)!= null)
        StateProvider.UpdateStateWithNotification(RelevanceLevel.High);
      else
        StateProvider.UpdateStateWithNotification(RelevanceLevel.Irrelevant);
    }
  }
}

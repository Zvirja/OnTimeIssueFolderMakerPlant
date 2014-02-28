using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OnTimeIssueFolderMakerPlant.OnTime
{
  public class OnTimeValueResolver
  {
    #region Static Fields

    public static OnTimeValueResolver Resolver = new OnTimeValueResolver();

    #endregion

    #region Public Methods and Operators

    public Tuple<int, string> ResolveOnTimeValue(string headerValue)
    {
      return this.ResolveNewOntime(headerValue) ?? this.ResolveOldOntime(headerValue);
    }

    #endregion

    #region Methods

    private Tuple<int, string> ResolveNewOntime(string bufferValue)
    {
      string[] strArray = bufferValue.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
      if (strArray.Length != 2)
        return null;
      if (strArray[0].Length != 6)
        return null;
      int ticketID;
      if (!int.TryParse(strArray[0], out ticketID))
        return null;
      return new Tuple<int, string>(ticketID, strArray[1].Trim());
    }

    private Tuple<int, string> ResolveOldOntime(string bufferValue)
    {
      string[] strArray = bufferValue.Split(new char[] {'\n'});
      if (strArray.Length < 2)
      {
        return null;
      }
      Match match = Regex.Match(strArray[0], @"^\d{6}$");
      if (!match.Success)
      {
        return null;
      }
      string ticketIDStr = match.Value;
      int ticketID;
      if (!int.TryParse(ticketIDStr, out ticketID))
        return null;
      string[] strArray2 = strArray[1].Trim().Split(new char[] {':'}, 2);
      if (strArray2.Length < 2)
      {
        return null;
      }
      return new Tuple<int, string>(ticketID, strArray2[1].Trim());
    }

    #endregion
  }
}
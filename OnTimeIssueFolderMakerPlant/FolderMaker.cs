using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using TrayGarden.Helpers;

namespace OnTimeIssueFolderMakerPlant
{
  public class FolderMaker
  {
    public static FolderMaker Maker = new FolderMaker();
    private readonly char[] restrictedCharacters = "<>\"/\\|?:*".ToCharArray();

    public virtual string MakeFolder(Tuple<int, string> ticketInfo)
    {
      if (ticketInfo == null)
        return null;
      string folderName = DecorateName(ticketInfo);
      return CreateIssueFolder(folderName);
    }

    protected virtual string DecorateName(Tuple<int, string> ticketInfo)
    {
      var originalPath = "{0} - {1}".FormatWith(ticketInfo.Item1, ticketInfo.Item2);
      originalPath = NormalizeName(originalPath);
      if (originalPath.Length <= Configuration.ActualConfig.FolderNameLimitSetting.Value)
        return originalPath;
      return originalPath.Substring(0, Configuration.ActualConfig.FolderNameLimitSetting.Value);
    }

    private string NormalizeName(string input)
    {
      if (string.IsNullOrEmpty(input))
      {
        return input;
      }
      string str = input;
      foreach (char ch in this.restrictedCharacters)
      {
        str = str.Replace(ch.ToString(), string.Empty);
      }
      return str;
    }

    private string CreateIssueFolder(string folderPath)
    {
      try
      {
        string fullPath = Path.Combine(Configuration.ActualConfig.RootFolderPathSetting.Value, folderPath);
        if (Directory.Exists(fullPath))
        {
          return fullPath;
        }
        Directory.CreateDirectory(fullPath);
        return fullPath;
      }
      catch
      {
        return null;
      }
    }
  }
}

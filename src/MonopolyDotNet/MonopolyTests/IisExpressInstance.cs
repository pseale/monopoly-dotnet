/*
 * This IIS Express spawning code gleaned from the Seleno codebase at github.com/TestStack/TestStack.Seleno, which is under an MIT license.
 * 
 * I have modified the original files heavily.

The MIT License (MIT)

Copyright (c) 2011-2013 TestStack.Seleno Contributors

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
 * 
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MonopolyTests
{
  public static class IisExpressInstance
  {
    private static Process _webHostProcess;
    private static int _port;

    public static void Start(string webProjectFolderName, int port)
    {
      _port = port;
      string applicationPath = GetFullPathFromWebProjectFolderName(webProjectFolderName);
      var webHostStartInfo = ProcessStartInfo(applicationPath, port);
      _webHostProcess = Process.Start(webHostStartInfo);
    }

    public static void Stop()
    {
      if (_webHostProcess == null)
        return;
      if (!_webHostProcess.HasExited)
        _webHostProcess.Kill();
      _webHostProcess.Dispose();
      _webHostProcess = null;
    }

    public static int Port
    {
      get { return _port; }
    }

    private static ProcessStartInfo ProcessStartInfo(string applicationPath, int port)
    {
      var key = Environment.Is64BitOperatingSystem ? "programfiles(x86)" : "programfiles";
      var programfiles = Environment.GetEnvironmentVariable(key);

      return new ProcessStartInfo
      {
        WindowStyle = ProcessWindowStyle.Hidden,
        ErrorDialog = true,
        LoadUserProfile = true,
        CreateNoWindow = true,
        UseShellExecute = false,
        Arguments = String.Format("/path:\"{0}\" /port:{1}", applicationPath, port),
        FileName = string.Format("{0}\\IIS Express\\iisexpress.exe", programfiles)
      };
    }

    private static string GetFullPathFromWebProjectFolderName(string webProjectFolderName)
    {
      string solutionFolder = GetSolutionFolderPath();
      return FindSubFolderPath(solutionFolder, webProjectFolderName);
    }

    private static string GetSolutionFolderPath()
    {
      var directory = new DirectoryInfo(Environment.CurrentDirectory);

      while (directory.GetFiles("*.sln").Length == 0)
      {
        directory = directory.Parent;
      }
      return directory.FullName;
    }

    private static string FindSubFolderPath(string rootFolderPath, string folderName)
    {
      var directory = new DirectoryInfo(rootFolderPath);

      directory = (directory.GetDirectories("*", SearchOption.AllDirectories)
          .Where(folder => folder.Name.ToLower() == folderName.ToLower()))
          .FirstOrDefault();

      if (directory == null)
      {
        throw new DirectoryNotFoundException();
      }

      return directory.FullName;
    }
  }
}

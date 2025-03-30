#Requires AutoHotkey v2.0
#SingleInstance Force
#include "..\Acc-v2\Lib\Acc.ahk"

executable := "tabs.exe"
window := "Tabs test ahk_exe " executable
^!r::reload()
if not WinExist(window) {
  Run(A_ScriptDir "\bin\Debug\net9.0-windows\" executable)
}
oAcc := ""
While (oAcc = "") {
  if (hwnd := WinExist(window))
    oAcc := Acc.ElementFromHandle(hwnd)
  Sleep(200)
}
tabcontrol := oAcc.FindElement({Role: 60},4)
tabs := tabcontrol.FindElements({Role: 37},2)
Loop {
  if (tabs[1].State = 3145728)
    tabs[1].doDefaultAction()
  Sleep(2000)
}

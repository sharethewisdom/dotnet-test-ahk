#Requires AutoHotkey v2.0
#SingleInstance Force
#include "..\Acc-v2\Lib\Acc.ahk"

executable := "checkbox.exe"
window := "CheckBox test ahk_exe " executable
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

checkbox := oAcc.FindElement({Role: 44},4)
Loop {
  if not (hwnd := WinExist(window))
    break
  if not WinActive(hwnd)
    WinActivate(hwnd)
  if not WinWaitActive(hwnd,,1000)
    break
  if (checkbox.State = 1048577) ; Focusable 1048576 + disabled 1
    continue
  ; 1048592 ; checked = Focusable 1048576 + Checked 16
  ; 1048596 ; checked_focused = Focusable 1048576 + Checked 16 + Focused 4

  ; 1048576 ; unchecked = Focusable 1048576
  ; 1048580 ; unchecked_focused = Focusable 1048576 + Focused 4
  if (checkbox.State = 1048580 || checkbox.State = 1048576)
    checkbox.doDefaultAction()
  Sleep(1000)
}

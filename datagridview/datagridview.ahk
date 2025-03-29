#Requires AutoHotkey v2.0
#SingleInstance Force
#include "..\Acc-v2\Lib\Acc.ahk"

executable := "datagridview.exe"
window := "DataGridView test ahk_exe " executable
dialog := "DataGridView test dialog ahk_exe " executable
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

firstRealRow := oAcc.WaitElementExist("4,1,4,2", 4000, 1)
if (firstRealRow) {
  grid := oAcc[4,1,4]
  ; The top row has State set to zero
  ; 2097152 is a normal row
  ; 2097154 is a selected row
  ; 2162688 is a row that's out of view
  rows := grid.FindElements({Role: 28, not:{State:0}},4)
  Loop (rows.Length) {
    n := A_Index
    if not (hwnd := WinExist(window))
      break
    if not WinActive(hwnd)
      WinActivate(hwnd)
    if not WinWaitActive(hwnd,,1000)
      break
    if not rows[n].Exists
      break
    if (SubStr(rows[n][1].Value,1,4) = "done")
      continue
    SetTimer(() => rows[n].Highlight(1000), -1)
    rows[n].Select(Acc.SELECTIONFLAG[2])
    Sleep(200)
    rows[n][2].Click("Left", 2)
    if (hwnd := WinWaitActive(dialog,,2000)) {
      While WinActive(hwnd) {
        SetControlDelay(-1)
        Sleep(500)
        ControlClick("OK",dialog)
      }
      if not WinWaitNotActive(hwnd,,1000)
        break
    } else {
      break
    }
  }
  SetControlDelay(20)
}

# dotnet-test-ahk
testing .NET controls with autohotkey

![datagridview](https://github.com/user-attachments/assets/b531a876-8788-4ce2-8f1a-d7c3124408f2)

![tabs](https://github.com/user-attachments/assets/7be23d44-a3e0-4529-aa63-518fff85cc55)

![checkbox](https://github.com/user-attachments/assets/823ad3b2-12b3-474b-b446-7246d613f7de)

## install

run as administrator:

```powershell
choco install dotnet-sdk git.install autohotkey
```

run as a normal user:

```powershell
git clone https://github.com/sharethewisdom/dotnet-test-ahk
cd dotnet-test-ahk
git submodule update
```

## build and test

```powershell
cd datagridview
dotnet build
autohotkey datagridview.ahk
```

## must read

* [UI Automation and Active Accessibility](https://learn.microsoft.com/en-us/windows/win32/winauto/uiauto-msaa)
* [AccessibleRole Enum](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.accessiblerole)
* [AccessibleRole States](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.accessiblestates)

## how to record the screen

I changed the resolution ot the Windows VM to 640x480 and added this to the start of the script

```autohotkey
Sleep(2000)
Run("C:\ProgramData\Chocolatey\bin\ffmpeg.exe -f gdigrab -framerate 10 -i desktop output.mkv", A_ScriptDir)
WinWait("ahk_class ConsoleWindowClass ahk_exe ffmpeg.exe")
WinMinimize("ahk_class ConsoleWindowClass ahk_exe ffmpeg.exe")
WinWait("DataGridView test")
WinMove(10,100,,,"DataGridView test")
Sleep(1000)
```

The screen region options for gdigrab with `-i desktop` wouldn't work for me, so I then created a gif with something like below. 
It crops the video to a region, with frames from 2 seconds up to 22 seconds, creates a pallet and optimizes the gif.

```sh
ffmpeg -i output.mkv -ss 2 -to 22 -vf "fps=10,crop=400:300:0:50,scale=400:-1:flags=lanczos,split[s0][s1];[s0]palettegen[p];[s1][p]paletteuse" -loop 0 datagridview.gif
mogrify -layers optimize -fuzz 10% datagridview.gif
rm output.mkv
```

there are probably better ways to do it though


# dotnet-test-ahk
testing .NET controls with autohotkey

![datagridview](https://github.com/user-attachments/assets/b531a876-8788-4ce2-8f1a-d7c3124408f2)

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

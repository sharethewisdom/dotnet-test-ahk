# dotnet-test-ahk

testing .NET controls with autohotkey

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

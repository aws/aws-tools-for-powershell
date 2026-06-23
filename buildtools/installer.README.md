# Building and testing AWS.Tools.Installer

The AWS.Tools.Installer module ships a precompiled C# library
(`modules/Installer/AWS.Tools.Installer.Lib/AWS.Tools.Installer.dll`). Its tests
need that DLL staged into `Deployment/AWS.Tools/AWS.Tools.Installer/`, which a
full SDK build produces but is slow to run. The steps below build and test just
the Installer module.

Run all commands from the repository root.

## 1. Build and stage the module

Windows PowerShell:

```
powershell -NoProfile -File .\buildtools\Build-AWSToolsInstaller.ps1
```

pwsh (Windows):

```
pwsh -NoProfile -File .\buildtools\Build-AWSToolsInstaller.ps1
```

pwsh (Linux):

```
pwsh -NoProfile -File ./buildtools/Build-AWSToolsInstaller.ps1
```

This compiles `AWS.Tools.Installer.Lib` and copies the module assets (the .psd1,
.psm1, `Public/`, `Private/`, `Config/`, and the compiled DLL) into
`Deployment/AWS.Tools/AWS.Tools.Installer/`. It does not run the generator or
build any service modules.

## 2. Run the C# unit tests (xUnit)

The xUnit tests run on the .NET runtime, so the command is the same in every
shell:

```
dotnet test tests/dotnet/Installer.Tests/Installer.Tests.csproj
```

A few tests assert Windows file-attribute behavior (Hidden/ReadOnly) and run only
on Windows; they no-op on Linux and macOS.

`dotnet test` restores NuGet packages first. All referenced packages are public,
so a working nuget.org source is required. If restore fails with a missing local
source, list and clean stale sources:

```
dotnet nuget list source
dotnet nuget remove source <staleSourceName>
dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
```

## 3. Run the PowerShell tests (Pester unit + integration)

Build and stage the module first (step 1), then run from `tests/`:

Windows PowerShell:

```
cd tests
mkdir results -Force
powershell -NoProfile -Command "Invoke-Pester .\Installer -EnableExit -OutputFile results/PesterResults.xml -OutputFormat NUnitXML -ExcludeTag Disabled -Show All"
```

pwsh (Windows):

```
cd tests
mkdir results -Force
pwsh -NoProfile -Command "Invoke-Pester .\Installer -EnableExit -OutputFile results/PesterResults.xml -OutputFormat NUnitXML -ExcludeTag Disabled -Show All"
```

pwsh (Linux):

```
cd tests
mkdir -p results
pwsh -NoProfile -Command "Invoke-Pester ./Installer -EnableExit -OutputFile results/PesterResults.xml -OutputFormat NUnitXML -ExcludeTag Disabled -Show All"
```

The tests run as long as the staged module exists at
`Deployment/AWS.Tools/AWS.Tools.Installer/`; if it is missing, they skip.

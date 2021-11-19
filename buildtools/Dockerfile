# Use the latest Windows Server Core image with .NET Framework 4.8.
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2019

ARG POWERSHELL_SHA256=AA01A6F11C76BBD3786E274DD65F2C85FF28C08B2D778A5FC26127DFEC5E67B3

# Install .NET SDK
RUN Invoke-WebRequest "https://dot.net/v1/dotnet-install.ps1" -OutFile "dotnet-install.ps1"; \
    ./dotnet-install.ps1 -Channel "2.1" -InstallDir 'C:\Program Files\dotnet'; \
    Remove-Item "dotnet-install.ps1" -Force;

# Install PowerShell Core
RUN Invoke-WebRequest "https://github.com/PowerShell/PowerShell/releases/download/v6.1.3/PowerShell-6.1.3-win-x64.zip" -OutFile "PowerShell-6.1.3-win-x64.zip"; \
    $(If ((Get-FileHash PowerShell-6.1.3-win-x64.zip -Algorithm SHA256).Hash.ToUpper() -ne "$ENV:POWERSHELL_SHA256".ToUpper()) {throw 'The checksum did not match for PowerSHell.';}) ; \
    Expand-Archive -Path "PowerShell-6.1.3-win-x64.zip" -DestinationPath 'C:\PowerShell'; \
    Remove-Item PowerShell-6.1.3-win-x64.zip -Force; \
    $path = [System.Environment]::GetEnvironmentVariable('Path','Machine') + ';C:\PowerShell'; \
    [Environment]::SetEnvironmentVariable('PATH', $path, 'Machine')

# We want to use pwsh from now on
SHELL ["C:\\PowerShell\\pwsh.exe", "-command"]

# Install Pester
RUN Install-Module -Name Pester -RequiredVersion 4.8.1 -Scope AllUsers -Force -SkipPublisherCheck

# Install AWS CLI
RUN curl -sSL https://awscli.amazonaws.com/AWSCLIV2.msi -o AWSCLIV2.msi; \
    Start-Process AWSCLIV2.msi -ArgumentList '/quiet InstallAllUsers=1 PrependPath=1' -Wait; \
    Remove-Item AWSCLIV2.msi -Force;

# Add nuget.org to nuget sources
RUN dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org

# Uncomment the following line to build the repository locally.
# COPY . src/

ENTRYPOINT [ "C:\\PowerShell\\pwsh.exe" ]
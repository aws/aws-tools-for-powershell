BeforeDiscovery {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
}

BeforeAll {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'

    function New-FixtureManifest {
        param(
            [string]$ModuleName = 'AWS.Tools.S3',
            [string]$ModuleVersion = '5.0.151',
            [string]$Description = 'The S3 cmdlets for AWS Tools for PowerShell.',
            [string]$Author = 'Amazon.com, Inc',
            [string]$Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.',
            [string]$Guid = '12345678-1234-1234-1234-123456789012',
            [string]$Prerelease = '',
            [string[]]$Tags = @('AWS', 'cloud'),
            [string[]]$CmdletsToExport = @('Get-S3Object', 'Set-S3Object'),
            [object[]]$RequiredModules = @(
                @{ ModuleName = 'AWS.Tools.Common'; ModuleVersion = '5.0.151' }
            )
        )

        $tempDir = Join-Path ([System.IO.Path]::GetTempPath()) ("psgmi-fixture-" + [System.Guid]::NewGuid().ToString("N"))
        New-Item -ItemType Directory -Path $tempDir | Out-Null
        $psd1Path = Join-Path $tempDir "$ModuleName.psd1"

        $cmdletsLiteral = ($CmdletsToExport | ForEach-Object { "'$_'" }) -join ', '
        $tagsLiteral = ($Tags | ForEach-Object { "'$_'" }) -join ', '
        $reqModulesLiteral = ($RequiredModules | ForEach-Object {
            if ($_ -is [string]) { "'$_'" }
            else { "@{ ModuleName = '$($_.ModuleName)'; ModuleVersion = '$($_.ModuleVersion)' }" }
        }) -join ', '

        $prereleaseLine = if ($Prerelease) { "Prerelease = '$Prerelease'" } else { '' }

        $content = @"
@{
    ModuleVersion = '$ModuleVersion'
    GUID = '$Guid'
    Author = '$Author'
    CompanyName = 'Amazon.com, Inc'
    Description = '$Description'
    Copyright = '$Copyright'
    PowerShellVersion = '5.1'
    DotNetFrameworkVersion = '4.7.2'
    CmdletsToExport = @($cmdletsLiteral)
    RequiredModules = @($reqModulesLiteral)
    PrivateData = @{
        PSData = @{
            Tags = @($tagsLiteral)
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'Release notes here.'
            $prereleaseLine
        }
    }
}
"@
        Set-Content -Path $psd1Path -Value $content -NoNewline
        return @{ Path = $psd1Path; TempDir = $tempDir }
    }

    function Get-PSGmiNamespaceManager {
        param([System.Xml.XmlDocument]$Doc)
        $nsm = New-Object System.Xml.XmlNamespaceManager $Doc.NameTable
        $nsm.AddNamespace('ps', 'http://schemas.microsoft.com/powershell/2004/04')
        return ,$nsm   # comma to prevent PS from unwrapping single-item return
    }
}

Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "PSGetModuleInfoXmlBuilder - field generation" {

    Context "Critical scalar fields" {
        It "Emits Name, Version, Type, Author, CompanyName, Copyright, InstalledLocation" {
            $f = New-FixtureManifest
            try {
                $xml = [Amazon.PowerShell.Installer.PSGetModuleInfoXmlBuilder]::Generate($f.Path, '5.0.151', '/install/AWS.Tools.S3/5.0.151')
                $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml($xml)
                $nsm = Get-PSGmiNamespaceManager $doc

                $doc.SelectSingleNode("//ps:S[@N='Name']", $nsm).InnerText        | Should -Be 'AWS.Tools.S3'
                $doc.SelectSingleNode("//ps:Version[@N='Version']", $nsm).InnerText | Should -Be '5.0.151'
                $doc.SelectSingleNode("//ps:S[@N='Type']", $nsm).InnerText        | Should -Be 'Module'
                $doc.SelectSingleNode("//ps:S[@N='Author']", $nsm).InnerText      | Should -Be 'Amazon.com Inc'  # ", Inc$" → " Inc" replacement
                $doc.SelectSingleNode("//ps:S[@N='CompanyName']", $nsm).InnerText | Should -Be 'aws-dotnet-sdk-team'
                $doc.SelectSingleNode("//ps:S[@N='Copyright']", $nsm).InnerText   | Should -Match 'Copyright Amazon.com'
                $doc.SelectSingleNode("//ps:S[@N='InstalledLocation']", $nsm).InnerText | Should -Be '/install/AWS.Tools.S3/5.0.151'
                $doc.SelectSingleNode("//ps:S[@N='Repository']", $nsm).InnerText  | Should -Be 'PSGallery'
                $doc.SelectSingleNode("//ps:S[@N='PackageManagementProvider']", $nsm).InnerText | Should -Be 'NuGet'
            }
            finally { if (Test-Path $f.TempDir) { Remove-Item -Recurse -Force $f.TempDir } }
        }

        It "Emits LicenseUri, ProjectUri, IconUri from PSData" {
            $f = New-FixtureManifest
            try {
                $xml = [Amazon.PowerShell.Installer.PSGetModuleInfoXmlBuilder]::Generate($f.Path, '5.0.151', '/x')
                $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml($xml)
                $nsm = Get-PSGmiNamespaceManager $doc

                $doc.SelectSingleNode("//ps:URI[@N='LicenseUri']", $nsm).InnerText | Should -Be 'https://aws.amazon.com/apache-2-0/'
                $doc.SelectSingleNode("//ps:URI[@N='ProjectUri']", $nsm).InnerText | Should -Be 'https://github.com/aws/aws-tools-for-powershell'
                $doc.SelectSingleNode("//ps:URI[@N='IconUri']", $nsm).InnerText    | Should -Match 'AWSLogo128x128.png$'
            }
            finally { if (Test-Path $f.TempDir) { Remove-Item -Recurse -Force $f.TempDir } }
        }

        It "Emits valid PublishedDate and InstalledDate" {
            $f = New-FixtureManifest
            try {
                $xml = [Amazon.PowerShell.Installer.PSGetModuleInfoXmlBuilder]::Generate($f.Path, '5.0.151', '/x')
                $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml($xml)
                $nsm = Get-PSGmiNamespaceManager $doc

                $publishedNode = $doc.SelectSingleNode("//ps:DT[@N='PublishedDate']", $nsm)
                $publishedNode | Should -Not -BeNullOrEmpty
                { [datetime]::Parse($publishedNode.InnerText) } | Should -Not -Throw

                $installedDtNode = $doc.SelectSingleNode("//ps:Obj[@N='InstalledDate']/ps:DT", $nsm)
                $installedDtNode | Should -Not -BeNullOrEmpty
                { [datetime]::Parse($installedDtNode.InnerText) } | Should -Not -Throw
            }
            finally { if (Test-Path $f.TempDir) { Remove-Item -Recurse -Force $f.TempDir } }
        }
    }

    Context "Tags list" {
        It "Includes PSData.Tags plus PSModule" {
            $f = New-FixtureManifest -Tags @('AWS', 'cloud', 'Custom')
            try {
                $xml = [Amazon.PowerShell.Installer.PSGetModuleInfoXmlBuilder]::Generate($f.Path, '5.0.151', '/x')
                $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml($xml)
                $nsm = Get-PSGmiNamespaceManager $doc

                $tagsNodes = $doc.SelectNodes("//ps:Obj[@N='Tags']/ps:LST/ps:S", $nsm)
                $tags = $tagsNodes | ForEach-Object { $_.InnerText }

                $tags | Should -Contain 'AWS'
                $tags | Should -Contain 'cloud'
                $tags | Should -Contain 'Custom'
                $tags | Should -Contain 'PSModule'
            }
            finally { if (Test-Path $f.TempDir) { Remove-Item -Recurse -Force $f.TempDir } }
        }
    }

    Context "Includes/Cmdlet list" {
        It "Lists every cmdlet from CmdletsToExport" {
            $f = New-FixtureManifest -CmdletsToExport @('Get-S3Object', 'Set-S3Object', 'Remove-S3Object')
            try {
                $xml = [Amazon.PowerShell.Installer.PSGetModuleInfoXmlBuilder]::Generate($f.Path, '5.0.151', '/x')
                $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml($xml)
                $nsm = Get-PSGmiNamespaceManager $doc

                $cmdletNodes = $doc.SelectNodes("//ps:Obj[@N='Includes']/ps:DCT/ps:En[ps:S[@N='Key']/text()='Cmdlet']/ps:Obj/ps:LST/ps:S", $nsm)
                $cmdlets = $cmdletNodes | ForEach-Object { $_.InnerText }

                $cmdlets | Should -Contain 'Get-S3Object'
                $cmdlets | Should -Contain 'Set-S3Object'
                $cmdlets | Should -Contain 'Remove-S3Object'
            }
            finally { if (Test-Path $f.TempDir) { Remove-Item -Recurse -Force $f.TempDir } }
        }
    }

    Context "Dependencies from RequiredModules" {
        It "Emits Name + RequiredVersion + CanonicalId for hashtable form" {
            $f = New-FixtureManifest -RequiredModules @(
                @{ ModuleName = 'PowerShellGet'; ModuleVersion = '2.2.1' }
            )
            try {
                $xml = [Amazon.PowerShell.Installer.PSGetModuleInfoXmlBuilder]::Generate($f.Path, '5.0.151', '/x')
                $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml($xml)
                $nsm = Get-PSGmiNamespaceManager $doc

                $depEntries = $doc.SelectNodes("//ps:Obj[@N='Dependencies']/ps:LST/ps:Obj/ps:DCT/ps:En", $nsm)
                $depEntries.Count | Should -BeGreaterOrEqual 3

                $names = $doc.SelectNodes("//ps:Obj[@N='Dependencies']/ps:LST/ps:Obj/ps:DCT/ps:En[ps:S[@N='Key']/text()='Name']/ps:S[@N='Value']", $nsm)
                ($names | ForEach-Object { $_.InnerText }) | Should -Contain 'PowerShellGet'

                $versions = $doc.SelectNodes("//ps:Obj[@N='Dependencies']/ps:LST/ps:Obj/ps:DCT/ps:En[ps:S[@N='Key']/text()='RequiredVersion']/ps:S[@N='Value']", $nsm)
                ($versions | ForEach-Object { $_.InnerText }) | Should -Contain '2.2.1'

                $canonical = $doc.SelectNodes("//ps:Obj[@N='Dependencies']/ps:LST/ps:Obj/ps:DCT/ps:En[ps:S[@N='Key']/text()='CanonicalId']/ps:S[@N='Value']", $nsm)
                ($canonical | ForEach-Object { $_.InnerText }) | Should -Contain 'nuget:PowerShellGet/[2.2.1]'
            }
            finally { if (Test-Path $f.TempDir) { Remove-Item -Recurse -Force $f.TempDir } }
        }

        It "Emits dependency for string form using fallback version" {
            $f = New-FixtureManifest -RequiredModules @('AWS.Tools.Common')
            try {
                $xml = [Amazon.PowerShell.Installer.PSGetModuleInfoXmlBuilder]::Generate($f.Path, '5.0.151', '/x')
                $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml($xml)
                $nsm = Get-PSGmiNamespaceManager $doc

                $names = $doc.SelectNodes("//ps:Obj[@N='Dependencies']/ps:LST/ps:Obj/ps:DCT/ps:En[ps:S[@N='Key']/text()='Name']/ps:S[@N='Value']", $nsm)
                ($names | ForEach-Object { $_.InnerText }) | Should -Contain 'AWS.Tools.Common'
            }
            finally { if (Test-Path $f.TempDir) { Remove-Item -Recurse -Force $f.TempDir } }
        }
    }

    Context "AdditionalMetadata" {
        It "tags string includes PSCmdlet_X / PSCommand_X / PSIncludes_Cmdlet" {
            $f = New-FixtureManifest -CmdletsToExport @('Get-S3Object')
            try {
                $xml = [Amazon.PowerShell.Installer.PSGetModuleInfoXmlBuilder]::Generate($f.Path, '5.0.151', '/x')
                $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml($xml)
                $nsm = Get-PSGmiNamespaceManager $doc

                $tagsNode = $doc.SelectSingleNode("//ps:Obj[@N='AdditionalMetadata']/ps:MS/ps:S[@N='tags']", $nsm)
                $tagsNode | Should -Not -BeNullOrEmpty
                $tagsNode.InnerText | Should -Match 'PSCmdlet_Get-S3Object'
                $tagsNode.InnerText | Should -Match 'PSCommand_Get-S3Object'
                $tagsNode.InnerText | Should -Match 'PSIncludes_Cmdlet'
                $tagsNode.InnerText | Should -Match 'PSModule'
            }
            finally { if (Test-Path $f.TempDir) { Remove-Item -Recurse -Force $f.TempDir } }
        }

        It "Emits GUID, NormalizedVersion, PowerShellVersion, DotNetFrameworkVersion" {
            $f = New-FixtureManifest -Guid '11111111-2222-3333-4444-555555555555'
            try {
                $xml = [Amazon.PowerShell.Installer.PSGetModuleInfoXmlBuilder]::Generate($f.Path, '5.0.151', '/x')
                $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml($xml)
                $nsm = Get-PSGmiNamespaceManager $doc

                $doc.SelectSingleNode("//ps:Obj[@N='AdditionalMetadata']/ps:MS/ps:S[@N='GUID']", $nsm).InnerText | Should -Be '11111111-2222-3333-4444-555555555555'
                $doc.SelectSingleNode("//ps:Obj[@N='AdditionalMetadata']/ps:MS/ps:S[@N='NormalizedVersion']", $nsm).InnerText | Should -Be '5.0.151'
                $doc.SelectSingleNode("//ps:Obj[@N='AdditionalMetadata']/ps:MS/ps:S[@N='PowerShellVersion']", $nsm).InnerText | Should -Be '5.1'
                $doc.SelectSingleNode("//ps:Obj[@N='AdditionalMetadata']/ps:MS/ps:S[@N='DotNetFrameworkVersion']", $nsm).InnerText | Should -Be '4.7.2'
            }
            finally { if (Test-Path $f.TempDir) { Remove-Item -Recurse -Force $f.TempDir } }
        }
    }

    Context "Author normalization" {
        It "Replaces ', Inc' suffix with ' Inc'" {
            $f = New-FixtureManifest -Author 'Amazon.com, Inc'
            try {
                $xml = [Amazon.PowerShell.Installer.PSGetModuleInfoXmlBuilder]::Generate($f.Path, '5.0.151', '/x')
                $doc = New-Object System.Xml.XmlDocument; $doc.LoadXml($xml)
                $nsm = Get-PSGmiNamespaceManager $doc

                $doc.SelectSingleNode("//ps:S[@N='Author']", $nsm).InnerText | Should -Be 'Amazon.com Inc'
            }
            finally { if (Test-Path $f.TempDir) { Remove-Item -Recurse -Force $f.TempDir } }
        }
    }

    Context "Description CRLF encoding" {
        It "Encodes CRLF in description as _x000D__x000A_" {
            # Use a here-string to embed actual CRLF in the description.
            $tempDir = Join-Path ([System.IO.Path]::GetTempPath()) ("psgmi-crlf-" + [System.Guid]::NewGuid().ToString("N"))
            New-Item -ItemType Directory -Path $tempDir | Out-Null
            $psd1 = Join-Path $tempDir 'AWS.Tools.S3.psd1'
            try {
                # Write a manifest with a multi-line description.
                $content = @"
@{
    ModuleVersion = '5.0.151'
    GUID = '00000000-0000-0000-0000-000000000000'
    Author = 'Amazon'
    CompanyName = 'Amazon'
    Description = 'Line one`r`nLine two'
    Copyright = '(c)'
    CmdletsToExport = @()
    PrivateData = @{ PSData = @{ Tags = @('AWS') } }
}
"@
                Set-Content -Path $psd1 -Value $content -NoNewline
                $xml = [Amazon.PowerShell.Installer.PSGetModuleInfoXmlBuilder]::Generate($psd1, '5.0.151', '/x')
                $xml | Should -Match '_x000D__x000A_'
            }
            finally { if (Test-Path $tempDir) { Remove-Item -Recurse -Force $tempDir } }
        }
    }

    Context "Hidden file attribute" {
        It "Sets Hidden attribute on the written file" {
            $f = New-FixtureManifest
            try {
                # GenerateAndWrite writes PSGetModuleInfo.xml into the installedLocation
                # directory passed as the third argument. Use the fixture's temp dir so
                # the write resolves to a real path.
                $installedLocation = $f.TempDir
                [Amazon.PowerShell.Installer.PSGetModuleInfoXmlBuilder]::GenerateAndWrite($f.Path, '5.0.151', $installedLocation)
                $xmlPath = Join-Path $installedLocation 'PSGetModuleInfo.xml'
                Test-Path $xmlPath | Should -Be $true
                # On non-Windows the Hidden attribute may not be honored. Don't fail there;
                # just assert the file exists. On Windows, assert Hidden is set.
                if ($IsWindows -or $env:OS -eq 'Windows_NT') {
                    $attrs = (Get-Item $xmlPath -Force).Attributes
                    ($attrs -band [System.IO.FileAttributes]::Hidden) | Should -Be ([System.IO.FileAttributes]::Hidden)
                }
            }
            finally { if (Test-Path $f.TempDir) { Remove-Item -Recurse -Force $f.TempDir } }
        }
    }
}

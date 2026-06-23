BeforeDiscovery {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
}

BeforeAll {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
    $VerbosePreference  = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference  = 'SilentlyContinue'

    # Build a tiny AWS.Tools-shaped zip on the fly. Each (module, version) pair becomes
    # <Module>/<Version>/<Module>.psd1 with a placeholder .psm1 alongside, so
    # ProcessExtractedModule (in C#) can resolve the manifest after extraction.
    function global:New-AwsToolsTestZip {
        param(
            [Parameter(Mandatory)][string]$ZipPath,
            [Parameter(Mandatory)][hashtable[]]$Modules    # @{ Name='AWS.Tools.S3'; Version='5.0.151' }, ...
        )
        $stage = Join-Path $TestDrive ("stage-" + [Guid]::NewGuid().ToString("N"))
        New-Item -ItemType Directory -Path $stage -Force | Out-Null
        try {
            foreach ($m in $Modules) {
                $verDir = Join-Path $stage "$($m.Name)/$($m.Version)"
                New-Item -ItemType Directory -Path $verDir -Force | Out-Null
                $psd1 = Join-Path $verDir "$($m.Name).psd1"
@"
@{
    ModuleVersion = '$($m.Version)'
    GUID = '00000000-0000-0000-0000-000000000000'
    Author = 'Amazon.com, Inc'
    CompanyName = 'Amazon.com, Inc'
    Description = 'Synthetic test module.'
    Copyright = 'Copyright Amazon.com, Inc.'
    PowerShellVersion = '5.1'
    DotNetFrameworkVersion = '4.7.2'
    CmdletsToExport = @()
    RequiredModules = @()
    PrivateData = @{
        PSData = @{
            Tags = @('AWS','cloud')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://example.com/icon.png'
            ReleaseNotes = 'Test release notes.'
        }
    }
}
"@ | Set-Content -Path $psd1 -Encoding UTF8
                "# placeholder" | Set-Content -Path (Join-Path $verDir "$($m.Name).psm1")
            }
            if (Test-Path $ZipPath) { Remove-Item -Force $ZipPath }
            Compress-Archive -Path (Join-Path $stage '*') -DestinationPath $ZipPath -Force
        }
        finally {
            Remove-Item -Recurse -Force -ErrorAction SilentlyContinue $stage
        }
    }
}

InModuleScope AWS.Tools.Installer {

    Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "Installer - Install-AWSToolsModuleFromZip representative-version selection" {

        It "Picks the AWS.Tools rollup version when present" {
            # When the archive carries an 'AWS.Tools' rollup entry, the helper returns its
            # version regardless of what individual service modules report. Rollup is at
            # 5.0.151; service modules at 5.0.999 to prove the rollup wins (rather than
            # any-module-version coincidentally matching).
            $zip    = Join-Path $TestDrive 'rollup.zip'
            $target = Join-Path $TestDrive 'install-rollup'
            New-AwsToolsTestZip -ZipPath $zip -Modules @(
                @{ Name = 'AWS.Tools';        Version = '5.0.151' }
                @{ Name = 'AWS.Tools.Common'; Version = '5.0.999' }
                @{ Name = 'AWS.Tools.S3';     Version = '5.0.999' }
            )

            $result = Install-AWSToolsModuleFromZip -ZipPath $zip -TargetPath $target
            $result.Version | Should -Be '5.0.151'
        }

        It "Falls back to AWS.Tools.Common version when no rollup entry exists" {
            # No 'AWS.Tools' rollup. AWS.Tools.Installer is also in the archive at a different
            # version (2.0.1) - asserts that the helper prefers Common (5.0.151) over Installer
            # even when both are present.
            $zip    = Join-Path $TestDrive 'common.zip'
            $target = Join-Path $TestDrive 'install-common'
            New-AwsToolsTestZip -ZipPath $zip -Modules @(
                @{ Name = 'AWS.Tools.Installer'; Version = '2.0.1' }
                @{ Name = 'AWS.Tools.Common';    Version = '5.0.151' }
                @{ Name = 'AWS.Tools.S3';        Version = '5.0.151' }
            )

            $result = Install-AWSToolsModuleFromZip -ZipPath $zip -TargetPath $target
            $result.Version | Should -Be '5.0.151'
            $result.Version | Should -Not -Be '2.0.1'
        }

        It "Falls back to a module's version when neither rollup nor Common is present" {
            # No rollup, no Common. The helper falls back to the first module's version. We
            # don't assert WHICH module wins (hashtable enumeration order isn't guaranteed
            # across PS 5.1 vs 7+), only that the function returns a non-empty representative.
            $zip    = Join-Path $TestDrive 'first.zip'
            $target = Join-Path $TestDrive 'install-first'
            New-AwsToolsTestZip -ZipPath $zip -Modules @(
                @{ Name = 'AWS.Tools.S3';  Version = '5.0.151' }
                @{ Name = 'AWS.Tools.EC2'; Version = '5.0.151' }
            )

            $result = Install-AWSToolsModuleFromZip -ZipPath $zip -TargetPath $target
            $result.Version | Should -Be '5.0.151'
        }
    }

    Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "Installer - Install-AWSToolsModuleFromZip upgrade-over-existing-install" {

        It "Upgrade onto pre-existing older version emits no warnings and leaves old PSGetModuleInfo.xml untouched" {
            # Reproduces the customer-reported flow: AWS.Tools.Common 5.0.200 already on disk
            # (with its PSGetModuleInfo.xml in place) and we install 5.0.233 into the same target.
            # Pre-fix this would (a) walk into the 5.0.200 dir during post-process and (b) on
            # Windows fail to overwrite a Hidden xml. Post-fix: the call returns cleanly, the
            # 5.0.200 xml is byte-identical to its original contents, and the 5.0.233 xml is fresh.
            $target   = Join-Path $TestDrive 'install-upgrade'
            $oldDir   = Join-Path $target 'AWS.Tools.Common/5.0.200'
            $oldXml   = Join-Path $oldDir 'PSGetModuleInfo.xml'
            $sentinel = '<!-- pre-existing 5.0.200 -->'

            New-Item -ItemType Directory -Path $oldDir -Force | Out-Null
            # Minimal psd1 so the directory looks like a real prior install.
            "@{ ModuleVersion = '5.0.200' }" | Set-Content -Path (Join-Path $oldDir 'AWS.Tools.Common.psd1') -Encoding UTF8
            $sentinel | Set-Content -Path $oldXml -Encoding UTF8 -NoNewline
            $sentinelBytes = [System.IO.File]::ReadAllBytes($oldXml)
            if ($IsWindows -or $PSVersionTable.PSVersion.Major -lt 6) {
                # Mirror what PowerShellGet (and our own builder) does: Hidden bit on the xml.
                Set-ItemProperty -Path $oldXml -Name Attributes -Value ((Get-ItemProperty $oldXml).Attributes -bor [IO.FileAttributes]::Hidden)
            }

            $zip = Join-Path $TestDrive 'upgrade.zip'
            New-AwsToolsTestZip -ZipPath $zip -Modules @(
                @{ Name = 'AWS.Tools.Common'; Version = '5.0.233' }
            )

            $result = Install-AWSToolsModuleFromZip -ZipPath $zip -TargetPath $target -WarningVariable wv -WarningAction SilentlyContinue
            $result.Version | Should -Be '5.0.233'

            # No PSGetModuleInfo.xml warnings - the bug surfaced as one warning per module.
            ($wv | Where-Object { $_ -match 'PSGetModuleInfo.xml' }) | Should -BeNullOrEmpty

            # 5.0.200 xml byte-for-byte unchanged (scope bug check).
            $afterBytes = [System.IO.File]::ReadAllBytes($oldXml)
            $afterBytes.Length | Should -Be $sentinelBytes.Length
            for ($i = 0; $i -lt $sentinelBytes.Length; $i++) {
                $afterBytes[$i] | Should -Be $sentinelBytes[$i]
            }

            # 5.0.233 xml exists and is fresh (Name element present, parseable).
            $newXml = Join-Path $target 'AWS.Tools.Common/5.0.233/PSGetModuleInfo.xml'
            Test-Path $newXml | Should -BeTrue
            $doc = [xml](Get-Content -Raw -Path $newXml)
            $nameNode = $doc.SelectSingleNode("//*[local-name()='S' and @N='Name']")
            $nameNode.InnerText | Should -Be 'AWS.Tools.Common'
        }

        It "Reinstall of the same version onto a Hidden PSGetModuleInfo.xml emits no warnings" {
            # The -Force reinstall and same-version-overwrite paths both hit the Hidden-file
            # write failure pre-fix. Off-Windows Hidden has no effect, so the test still runs
            # but exercises only the same-target overwrite path.
            $target  = Join-Path $TestDrive 'install-force'
            $verDir  = Join-Path $target 'AWS.Tools.Common/5.0.151'
            $oldXml  = Join-Path $verDir 'PSGetModuleInfo.xml'

            New-Item -ItemType Directory -Path $verDir -Force | Out-Null
            "@{ ModuleVersion = '5.0.151' }" | Set-Content -Path (Join-Path $verDir 'AWS.Tools.Common.psd1') -Encoding UTF8
            '<old/>' | Set-Content -Path $oldXml -Encoding UTF8 -NoNewline
            if ($IsWindows -or $PSVersionTable.PSVersion.Major -lt 6) {
                Set-ItemProperty -Path $oldXml -Name Attributes -Value ((Get-ItemProperty $oldXml).Attributes -bor [IO.FileAttributes]::Hidden)
            }

            $zip = Join-Path $TestDrive 'force.zip'
            New-AwsToolsTestZip -ZipPath $zip -Modules @(
                @{ Name = 'AWS.Tools.Common'; Version = '5.0.151' }
            )

            $result = Install-AWSToolsModuleFromZip -ZipPath $zip -TargetPath $target -WarningVariable wv -WarningAction SilentlyContinue
            $result.Version | Should -Be '5.0.151'
            ($wv | Where-Object { $_ -match 'PSGetModuleInfo.xml' }) | Should -BeNullOrEmpty

            # Freshly written: contains the Name element from the new build.
            $doc = [xml](Get-Content -Raw -Path $oldXml)
            $nameNode = $doc.SelectSingleNode("//*[local-name()='S' and @N='Name']")
            $nameNode.InnerText | Should -Be 'AWS.Tools.Common'
        }
    }
}

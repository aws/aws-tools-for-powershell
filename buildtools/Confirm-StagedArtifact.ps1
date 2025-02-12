<#
.Synopsis
    Validates that the AWS Tools for PowerShell modules (AWSPowerShell and AWSPowerShell.NetCore) are
    both Authenticode signed and the module manifest has the expected version number.

.Description
    Validates that the built AWS Tools for PowerShell modules (for Windows PowerShell and PowerShell 6)
    are both Authenticode signed and have the expected version number in the module manifest and thus can
    be safely released.

.Notes
    The script must be run in a folder that contains subfolders holding the modules to be published
    (i.e. .\AWSPowerShell .\AWSPowerShell.NetCore and .\AWS.Tools).

.Example
    # On Windows Prod
    Confirm-StagedArtifact.ps1 -VerifySigning 'true' -AdditionalModuleChecks 'false'
.Example
    # On Windows Dev
    Confirm-StagedArtifact.ps1 -VerifySigning 'false' -AdditionalModuleChecks 'false'
.Example
    # On Linux
    Confirm-StagedArtifact.ps1 -VerifySigning 'false' -AdditionalModuleChecks 'true' -ExpectedVersion 4.1.724.1 -PreviewLabel 'preview003'
#>
Param (
    # The expected version of the module. This will be verified against
    # the module manifest and the running binary.
    [Parameter()]
    [string]$ExpectedVersion,

    # Determines if signing will be verified. This must be true for production
    # release environments.
    [Parameter()]
    [string] $VerifySigning = "true",

    # By default all modules AWSPowerShell, AWSPowerShell.NetCore and AWS.Tools modules are imported in pwsh on linux and (pwsh and windows powershell) on windows.
    # Get-S3Bucket ran for AWSPowerShell, AWSPowerShell.NetCore and AWS.Tools.S3.
    # Get-SFNStateMachineList ran for AWSPowerShell, AWSPowerShell.NetCore and AWS.Tools.StepFunctions.
    # $AdditionalModuleChecks test the following.
    # test module manifest,
    # test module manifest version,
    # test changelog
    [Parameter()]
    [string] $AdditionalModuleChecks = "true",

    # Specifies the type of build that is being verified. For PREVIEW build types AWSPowerShell.NetCore 
    # will be verified. Otherwise AWSPowerShell, AWSPowerShell.NetCore, and AWS.Tools.* will be verified.
    [Parameter()]
    [string] $BuildType = "RELEASE",

    [Parameter()]
    [string] $PreviewLabel = ""
)

function ValidateModule {
    param(
        [Parameter(Mandatory = $true)]
        [string]$modulePath, 
        [Parameter(Mandatory = $true)]
        [bool]$verifyChangeLog, 
        [Parameter(Mandatory = $true)]
        [bool]$testVersion, 
        [Parameter(Mandatory = $true)]
        [bool]$signingCheck, 
        [Parameter(Mandatory = $true)]
        [string]$cmdletToTest, 
        [Parameter(Mandatory = $true)]
        [bool]$testCmdlets,
        [string]$importCommonModuleCmd
    )

    Write-Host "Validating module $modulePath"

    $manifestPath = (Get-ChildItem -Path "$modulePath\*.psd1").FullName

    if ($testVersion) {
        Write-Host "Verifying version in manifest $manifestPath"
        $manifest = Test-ModuleManifest $manifestPath -ErrorAction 'Stop'
        $manifestVersion = $manifest.Version.ToString()
        Write-Host "Found version $manifestVersion"
    
        if ($manifestVersion -eq $ExpectedVersion) {
            Write-Host '...version check - PASS'
        }
        else {
            throw "Manifest has version $manifestVersion, not expected version $ExpectedVersion"
        }
        # validate pre-release
        if ($manifest.PrivateData.PSData.ContainsKey('Prerelease') -ne $isPreRelease) {
            throw "Unexpected Manifest Prerelease. For a prerelease version Prerelease tag should be set and for a non-prerelease version, the prerelease tag should not be set"
        }
        if ($isPreRelease -and $manifest.PrivateData.PSData.Prerelease -ne $PreviewLabel) {
            throw "Manifest has prerelease tag $($manifest.PrivateData.PSData.Prerelease), expected $PreviewLabel"
        }
    }

    if ($signingCheck) {
        Write-Host 'Verifying module files are Authenticode-signed'
        $filter = 
        @(
            '*.ps1',
            '*.psm1',
            '*.psd1',
            '*.ps1xml',
            'AWSPowerShell.dll',
            'AWSPowerShell.NetCore.dll',
            'AWS.Tools.*.dll'
        ) 
        $signableFiles = Get-ChildItem -Path $modulePath\* -Include $filter | Select-Object -ExpandProperty Name

        $signableFiles | ForEach-Object {
            Write-Host "...verifying module file $_"
            $fileToTest = Join-Path $modulePath $_
            $signature = Get-AuthenticodeSignature -FilePath $fileToTest
            if ($signature.Status -ne 'Valid') {
                Write-Host "...$fileToTest does not have a valid signature"
                $signature | Format-List | Out-String | Write-Host
                throw "Signature check failed for $fileToTest"
            }
        }
        Write-Host '...module files signing check - PASS'
    }

    if ($verifyChangeLog) {
        # validate that the change log contains the expected version header in the first line
        $changelogFile = Join-Path $modulePath 'CHANGELOG.txt'

        Write-Host "Verifying $changelogFile contains expected version details"
        $changelogHeader = Get-Content -TotalCount 1 -Path $changelogFile
        Write-Host "...inspecting latest changelog header: $changelogHeader"
        $headerParts = $changelogHeader.Split()
        if ($headerParts[1] -eq $expectedVersionWithPreviewLabel) {
            Write-Host '...changelog file version check - PASS'
        }
        else {
            throw "Changelog does not appear to contain details of the new version. Expected $expectedVersionWithPreviewLabel, Actual $($headerParts[1])"
        }
    }

    if ($testCmdlets) {
        if (-not($IsLinux -and $modulePath -eq 'AWSPowerShell')) {
            # Skip AWSPowerShell import in pwsh on Linux
            Write-Host 'Testing module in pwsh'
            if (-not ($PSVersionTable.PSVersion.Major -gt 6 -or ($PSVersionTable.PSVersion.Major -eq 6 -And $PSVersionTable.PSVersion.Minor -ge 1))) {
                throw "PowerShell version 6.1 or later is required, found version $($PSVersionTable.PSVersion)"
            }
            $testOutput = pwsh -noprofile -Command "`$ErrorActionPreference = 'Stop' ; $importCommonModuleCmd ; Import-Module '$manifestPath' ; $cmdletToTest"
            if ($LastExitCode -eq 0) {
                Write-Host '...module loading pwsh - PASS'
            }
            else {
                throw "The module failed to load PowerShell `n" + $testOutput
            }
        }
        if ($IsWindows -and $modulePath -ne 'AWSPowerShell.NetCore') {
            # Skip AWSPowerShell.NetCore import in Windows PowerShell
            Write-Host 'Testing module in powershell.exe'
            $testOutput = powershell -noprofile -Command "`$ErrorActionPreference = 'Stop' ; $importCommonModuleCmd ; Import-Module '$manifestPath' ; $cmdletToTest"
            if ($LastExitCode -eq 0) {
                Write-Host '...module loading in Windows PowerShell - PASS'
            }
            else {
                throw "The module failed to load in Windows PowerShell `n" + $testOutput
            }  
        }
    }
}
function StartBatchImportJobs {
    param (
        [Parameter(Mandatory = $true)]
        [array]$manifestBatches,
        [Parameter(Mandatory = $true)]
        [string]$cmdletTest,
        [Parameter(Mandatory = $true)]
        [string]$shellType,
        [int]$maxConcurrentJobs = 5
    )

    Write-Host "Testing AWS tools modules import in $shellType"
    $jobs = @()

    foreach ($batch in $manifestBatches) {
        $jobs += ImportModulesBatch -manifestBatch $batch -cmdletTest $cmdletTest -shellType $shellType
        
        # Wait if maximum concurrent jobs is reached
        while ((Get-Job -State Running).Count -ge $maxConcurrentJobs) {
            Start-Sleep -Seconds 1
        }
    }

    return $jobs
}
function TestImportModule {
    param (
        [Parameter(Mandatory = $true)]
        [string[]]$manifestPaths,
        [Parameter(Mandatory = $true)]
        [string]$cmdletTest,
        [int]$batchSize = 25,
        [int]$maxConcurrentJobs = 5
    )

    # Split into batches
    $manifestBatches = SplitIntoBatches -manifestPaths $manifestPaths -batchSize $batchSize

    # for preview, add common module for every batch
    if ($isPreRelease) {
        $commonModuleManifest = $manifestPaths.Where{ $_ -like '*AWS.Tools.Common*' }
        foreach ($index in 0..($manifestBatches.Count - 1)) {
            $manifestBatches[$index] = @($commonModuleManifest) + $manifestBatches[$index]
        }
    }
    # Test in pwsh
    $pwshJobs = StartBatchImportJobs -manifestBatches $manifestBatches -cmdletTest $cmdletTest -shellType 'pwsh' -maxConcurrentJobs $maxConcurrentJobs
    ProcessImportJobs -jobs $pwshJobs -shellName 'PowerShell'

    # Test in Windows PowerShell if on Windows
    if ($IsWindows) {
        $winPsJobs = StartBatchImportJobs -manifestBatches $manifestBatches -cmdletTest $cmdletTest -shellType 'powershell' -maxConcurrentJobs $maxConcurrentJobs
        ProcessImportJobs -jobs $winPsJobs -shellName 'Windows PowerShell'
    }
}
function ImportModulesBatch {
    param (
        [string[]]$manifestBatch,
        [string]$cmdletTest,
        [string]$shellType  # 'pwsh' or 'powershell'
    )
    
    $job = Start-Job -ScriptBlock {
        param($manifests, $cmdletTest, $shell)
        
        & $shell -noprofile -Command {
            param($manifests, $cmdletTest)
            $ErrorActionPreference = 'Stop'
            
            foreach ($manifest in $manifests) {
                Import-Module -Name $manifest
            }
            
            # Execute the test cmdlet after all modules are imported
            Invoke-Expression $cmdletTest
        } -Args $manifests, $cmdletTest
        
    } -ArgumentList $manifestBatch, $cmdletTest, $shellType
    
    return $job
}
function ProcessImportJobs {
    param (
        [System.Management.Automation.Job[]]$jobs,
        [string]$shellName
    )
    
    $jobs | Wait-Job | ForEach-Object {
        $result = Receive-Job -Job $_
        if ($_.State -eq 'Failed' -or $_.ChildJobs[0].Error) {
            Remove-Job -Job $_
            throw "The modules failed to load in $shellName `n" + $result
        }
        Write-Host "...batch module loading in $shellName - PASS"
        Remove-Job -Job $_
    }
}
function SplitIntoBatches {
    param (
        [string[]]$manifestPaths,
        [int]$batchSize
    )
    
    $manifestBatches = @()
    for ($i = 0; $i -lt $manifestPaths.Count; $i += $batchSize) {
        $batch = $manifestPaths[$i..([Math]::Min($i + $batchSize - 1, $manifestPaths.Count - 1))]
        $manifestBatches += , $batch
    }
    return $manifestBatches
}

$isPreRelease = ![string]::IsNullOrEmpty($PreviewLabel)
$expectedVersionWithPreviewLabel = $ExpectedVersion
if ($isPreRelease) {
    $expectedVersionWithPreviewLabel = "$ExpectedVersion-$PreviewLabel"
}


if (Get-Module AWSPowerShell, AWSPowerShell.NetCore, AWS.Tools.*) {
    throw 'Cannot validate modules if any AWS Tools for PowerShell module is already imported'
}

if ($AdditionalModuleChecks -eq 'true' -and [string]::IsNullOrEmpty($ExpectedVersion)) {
    throw '$ExpectedVersion is required when $AdditionalModuleChecks is true'
}
$signingCheck = $true
if ($VerifySigning -eq 'false') {
    $signingCheck = $false
}

$testCmdlets = $true

$testVersion = $true
$verifyChangeLog = $true

if ($AdditionalModuleChecks -eq 'false') {
    $testVersion = $false
    $verifyChangeLog = $false
}

$validateModules = @('AWSPowerShell', 'AWSPowerShell.NetCore')
if ($BuildType -eq 'PREVIEW') {
    $validateModules = @('AWSPowerShell.NetCore')
    $testVersion = $false
}

$validateModules | ForEach-Object {
    try {
        ValidateModule $_ $verifyChangeLog $testVersion $signingCheck { Get-S3Bucket -ProfileName test-runner; Get-SFNStateMachineList -Region us-west-2 -ProfileName test-runner } $testCmdlets ""
        Write-Host "PASSED validation for module $_"
    }
    catch {
        throw "FAILED validation for module $_, error $error"
    }
}

if ($BuildType -ne 'PREVIEW') {
    $awsToolsDeploymentPath = Resolve-Path "$PSScriptRoot/AWS.Tools"

    Import-Module PowerShellGet

    $OldPath = $Env:PSModulePath
    $envPathSeperator = ':'
    if ($IsWindows) {
        $envPathSeperator = ';'
    }
    $Env:PSModulePath = $Env:PSModulePath + $envPathSeperator + $awsToolsDeploymentPath

    # Import Common module for Preview Release Tools Modules as they don't auto-import it.
    $importCommonModuleCmd = ""
    if ($isPreRelease) {
        $importCommonModuleCmd = "Import-Module '" + [IO.Path]::Combine($awsToolsDeploymentPath, 'AWS.Tools.Common', 'AWS.Tools.Common.psd1') + "'"
    }

    $awstoolsModules = Get-ChildItem $awsToolsDeploymentPath -Directory
    $awstoolsModules | ForEach-Object {
        # Only test module import and cmdlet for S3 and StepFunctions.
        # All other AWS Tools modules will be tested with TestImportModule to speed up testing
        try {
            if ($_.Name -eq 'AWS.Tools.S3') {
                ValidateModule $_ $false $testVersion $signingCheck { Get-S3Bucket -ProfileName test-runner } $testCmdlets $importCommonModuleCmd
            }
            elseif ($_.Name -eq 'AWS.Tools.StepFunctions') {
                ValidateModule $_ $false $testVersion $signingCheck { Get-SFNStateMachineList -Region us-west-2 -ProfileName test-runner } $testCmdlets $importCommonModuleCmd
            }
            elseif ($_.Name -eq 'AWS.Tools.Installer') {
                ValidateModule $_ $false $false $signingCheck { } $false $importCommonModuleCmd
            }
            else {
                ValidateModule $_ $false $testVersion $signingCheck { } $false $importCommonModuleCmd
            }
            Write-Host "PASSED validation for module $_"
        }
        catch {
            throw "FAILED validation for module $_, error $error"
        }
    }
    # Test Module Import for AWS Tools Modules
    $moduleManifestPaths = $awstoolsModules.where{ $_.Name -ne 'AWS.Tools.Installer' }.foreach{ $_.FullName + '/' + $_.Name + '.psd1' }
    TestImportModule -manifestPaths $moduleManifestPaths -cmdletTest 'Get-AWSPowerShellVersion'
    $Env:PSModulePath = $OldPath
}
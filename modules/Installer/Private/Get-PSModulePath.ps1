<#
.Synopsis
    Gets the PSModulePath for an operating system and scope.

.Description
    Determines the appropriate PowerShell module installation path based on the operating system,
    PowerShell edition, and installation scope.

.Parameter Scope
    Specifies the installation scope. AllUsers installs to a system-wide location,
    CurrentUser installs to a user-specific location. Default is 'CurrentUser'.

.Parameter OperatingSystem
    The operating system platform. Defaults to current OS platform.

.Parameter IfCoreCLR
    Whether PowerShell Core is being used. Defaults to $IsCoreCLR value.

.Parameter HomePath
    Base path for user-specific module installation. Defaults to user's Documents folder.

.Parameter PSModulePath
    Current PSModulePath environment variable value for validation.

.Parameter IfLambda
    Whether running in AWS Lambda environment. Uses special Lambda-compatible path.

.Example
    Get-PSModulePath -Scope CurrentUser
#>
function Get-PSModulePath
{
    [CmdletBinding()]
    param
    (
        [Parameter()]
        [String] $Scope = 'CurrentUser',

        [Parameter()]
        [String] $OperatingSystem = ([Environment]::OSVersion).Platform,

        [Parameter()]
        [Boolean] $IfCoreCLR = ($PSVersionTable.PSEdition -eq 'Core'),

        [Parameter()]
        [PSObject] $HomePath = [System.Environment]::GetFolderPath(
            [System.Environment+SpecialFolder]::MyDocuments),

        [Parameter()]
        [String] $PSModulePath = $env:PSModulePath,

        [Parameter()]
        [Boolean] $IfLambda = ($null -ne $env:LAMBDA_TASK_ROOT)
    )
    
    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - Scope=$Scope " +
            "OperatingSystem=$OperatingSystem IfCoreCLR=$IfCoreCLR IfLambda=$IfLambda")
    }

    Process {
        if ($OperatingSystem -like 'Win*')
        {
            if ($IfCoreCLR)
            {
                if ($Scope -eq 'AllUsers')
                {
                    $programFiles = [System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::ProgramFiles)
                    $targetPSModulePath = '{0}\PowerShell\Modules' -f $programFiles
                }
                else
                {
                    $targetPSModulePath = '{0}\PowerShell\Modules' -f $HomePath
                }
                $powerShellEdition = 'PowerShell Core'
            }
            else
            {
                if ($Scope -eq 'AllUsers')
                {
                    $programFiles = [System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::ProgramFiles)
                    $targetPSModulePath = '{0}\WindowsPowerShell\Modules' -f $programFiles
                }
                else
                {
                    $targetPSModulePath = ('{0}\WindowsPowerShell\Modules' -f $HomePath)
                }
                $powerShellEdition = 'Windows PowerShell'
            }
            $delimiter = ';'
            Write-Verbose -Message ("Determined PSModulePath: '$targetPSModulePath' for " +
                "$powerShellEdition and scope: '$Scope' on a Windows Operating System.")
        }
        else
        {
            # Non-Windows platforms (Linux, macOS, Unix)
            # Paths are the same for both Linux and macOS (following PSResourceGet pattern)
            # Ignore Scope parameter for Lambda since only /tmp is writable.
            # This path depends on the Lambda Layer. 
            # Needs to be in sync with AWS-PowerTools-LambdaRuntimeLayer repo
            if ($IfLambda)
            {
                $targetPSModulePath = '/tmp/powershell/modules'
            }
            else
            {
                if ($Scope -eq 'AllUsers')
                {
                    $targetPSModulePath = '/usr/local/share/powershell/Modules'
                }
                else
                {
                    # $Homepath redetermination is to fix an issue in AL2023 cloudshell with PS 7.4.1.
                    # Only override HomePath if it's the default Documents path (indicating no explicit path was provided)
                    $defaultDocumentsPath = [System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::MyDocuments)
                    if ($HomePath -eq $defaultDocumentsPath) {
                        [PSObject] $HomePath = [System.Environment]::GetFolderPath(
                            [System.Environment+SpecialFolder]::UserProfile)
                    }
                    $targetPSModulePath = '{0}/.local/share/powershell/Modules' -f $HomePath
                }
            }
            Write-Verbose -Message ("Determined PSModulePath: '$targetPSModulePath' for " +
                "PowerShell Core and scope: '$Scope' on a non-Windows Operating System.")
            $delimiter = ':'
        }
        
        $PSModulePaths = $PSModulePath -split $delimiter
        if ($PSModulePaths -notcontains $targetPSModulePath)
        {
            $errorMessage = ("The module install path '$targetPSModulePath' determined by the " +
                "AWS.Tools.Installer module is not listed as a path in `$ENV:PSModulePath. As a " +
                "result, modules installed with AWS.Tools.Installer may not be auto-loaded. These " +
                "modules would need to be imported by specifying the full path to a manifest (.psd1) " +
                "file or the directory of a well-formed module (stored in a directory that has the " +
                "same name as the base name of at least one file in the module directory).")
            Write-Error -Message $errorMessage
        }
        return $targetPSModulePath
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}

<#
.Synopsis
    Normalizes AWS Tools module names to their fully qualified form.

.Description
    Module names can be specified with or without the "AWS.Tools." prefix (i.e. "AWS.Tools.Common"
    or simply "Common"). This function adds the prefix to any name that does not contain a dot and
    returns names that already contain a dot unchanged. It performs no validation.

.Parameter Name
    The module name(s) to normalize.

.Example
    ConvertTo-AWSToolsModuleName -Name "Common", "AWS.Tools.S3"
    Returns "AWS.Tools.Common", "AWS.Tools.S3"
#>
function ConvertTo-AWSToolsModuleName {
    Param(
        [Parameter(ValueFromPipeline, Mandatory, Position = 0)]
        [AllowEmptyString()]
        [string[]]
        $Name
    )

    Begin {
        Write-Debug "[$($MyInvocation.MyCommand)] Begin"
    }

    Process {
        foreach ($moduleName in $Name) {
            if ($moduleName.Contains('.')) {
                $moduleName
            }
            else {
                "AWS.Tools.$moduleName"
            }
        }
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}

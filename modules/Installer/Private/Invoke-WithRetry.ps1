<#
.Synopsis
    Executes a script block with exponential backoff retry logic.

.Description
    This function provides a centralized retry mechanism with exponential backoff
    that can be applied to any operation. It handles transient failures gracefully
    and provides consistent retry behavior across the AWS Tools Installer module.

.Parameter ScriptBlock
    The script block to execute. This should contain the operation that may need retrying.

.Parameter MaxRetries
    The maximum number of retry attempts. Default is 3.

.Parameter BaseDelaySeconds
    The base delay in seconds for exponential backoff. Default is 1 second.
    The actual delay will be: BaseDelaySeconds * (2 ^ attempt)

.Parameter MaxDelaySeconds
    The maximum delay in seconds to prevent excessively long waits. Default is 30 seconds.

.Parameter RetryableExceptions
    Array of exception types that should trigger a retry. If not specified, all exceptions trigger 
    retries. Example: @('System.IO.IOException', 'System.Net.WebException')

.Parameter OperationName
    A descriptive name for the operation being retried (used in logging).

.Example
    Invoke-WithRetry -ScriptBlock { Remove-Item $path -Force } -OperationName "Remove file"

.Example
    Invoke-WithRetry -ScriptBlock { 
        Invoke-WebRequest -Uri $url -OutFile $path 
    } -MaxRetries 5 -BaseDelaySeconds 2 -OperationName "Download file"

.Example
    Invoke-WithRetry -ScriptBlock { 
        Get-Process -Name "notepad" -ErrorAction Stop 
    } -RetryableExceptions @('Microsoft.PowerShell.Commands.ProcessCommandException') `
        -OperationName "Get process"
#>
function Invoke-WithRetry {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [scriptblock]$ScriptBlock,
        
        [int]$MaxRetries = $script:Config.retry.DefaultMaxRetries,
        
        [double]$BaseDelaySeconds = $script:Config.retry.BaseDelaySeconds,
        
        [int]$MaxDelaySeconds = $script:Config.retry.MaxDelaySeconds,
        
        [string[]]$RetryableExceptions = @(),
        
        [string]$OperationName = "Operation"
    )
    
    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - OperationName=$OperationName " +
            "MaxRetries=$MaxRetries BaseDelaySeconds=$BaseDelaySeconds")
    }
    
    Process {
        $attempt = 0
        $lastException = $null
        
        while ($attempt -lt $MaxRetries) {
            try {
                Write-Debug ("[$($MyInvocation.MyCommand)] Executing $OperationName " +
                    "(attempt $($attempt + 1)/$MaxRetries)")
                
                # Execute the script block and return the result
                $result = . $ScriptBlock
                
                Write-Debug ("[$($MyInvocation.MyCommand)] $OperationName succeeded on " +
                    "attempt $($attempt + 1)")
                return $result
            }
            catch {
                $lastException = $_
                $attempt++
                
                # Check if this exception type should trigger a retry
                $shouldRetry = $true
                if ($RetryableExceptions.Count -gt 0) {
                    $exceptionTypeName = $_.Exception.GetType().FullName
                    $shouldRetry = $RetryableExceptions -contains $exceptionTypeName
                    
                    if (-not $shouldRetry) {
                        Write-Debug ("[$($MyInvocation.MyCommand)] Exception type " +
                            "'$exceptionTypeName' is not retryable")
                        throw
                    }
                }
                
                # If this was the last attempt, re-throw the exception
                if ($attempt -ge $MaxRetries) {
                    Write-Debug ("[$($MyInvocation.MyCommand)] $OperationName failed after " +
                        "$MaxRetries attempts")
                    throw
                }
                
                # Calculate delay with exponential backoff
                $exponentialDelay = $BaseDelaySeconds * [Math]::Pow(2, $attempt - 1)
                $delay = [Math]::Min($exponentialDelay, $MaxDelaySeconds)
                
                # Log the retry attempt (verbose only, no warnings)
                Write-Verbose ("[$($MyInvocation.MyCommand)] $OperationName attempt $attempt " +
                    "failed: $($_.Exception.Message). Retrying in $delay seconds...")
                
                # Wait before retrying
                Start-Sleep -Seconds $delay
            }
        }
        
        # This should never be reached, but just in case
        if ($lastException) {
            throw $lastException
        }
    }
    
    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}

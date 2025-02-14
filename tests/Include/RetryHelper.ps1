function Invoke-WithRetry {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [scriptblock]$ScriptBlock,
        
        [Parameter(Mandatory = $true)]
        [scriptblock]$ValidateBlock,
        
        [int]$MaxRetries = 10,
        [double]$BaseWaitSeconds = 1,
        [double]$MaxWaitSeconds = 32,
        [string]$OperationName = "Operation"
    )

    $retryCount = 0
    
    do {
        $result = & $ScriptBlock
        
        if (& $ValidateBlock $result) {
            return $result
        }
        
        if ($retryCount -ge $MaxRetries) {
            throw "$OperationName did not succeed within $MaxRetries retries"
        }
        
        # Calculate exponential backoff with jitter
        $exponentialWait = [Math]::Min($MaxWaitSeconds, $BaseWaitSeconds * [Math]::Pow(2, $retryCount))
        $jitter = Get-Random -Minimum 0 -Maximum 1000
        $waitTimeWithJitter = $exponentialWait + ($jitter / 1000)
        
        Write-Verbose "$OperationName not ready... (Attempt $($retryCount + 1) of $MaxRetries, waiting $([Math]::Round($waitTimeWithJitter, 2)) seconds)"
        Start-Sleep -Seconds $waitTimeWithJitter
        $retryCount++
        
    } while ($retryCount -lt $MaxRetries)
}
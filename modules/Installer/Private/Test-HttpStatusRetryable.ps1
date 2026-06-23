<#
.Synopsis
    Determines if an HTTP status code should trigger a retry based on configuration.

.Description
    This function evaluates HTTP status codes to determine if an operation should be retried.
    It uses the configuration from retry.psd1 to make consistent retry decisions across
    all network operations.

.Parameter StatusCode
    The HTTP status code to evaluate. Use 0 for network-level errors (DNS, timeout, etc.).

.Parameter RetryableStatusCodes
    Array of status codes that should trigger retries. If not provided, uses default configuration.

.Parameter NonRetryableStatusCodes
    Array of status codes that should NOT trigger retries. If not provided, uses default configuration.

.Example
    $shouldRetry = Test-HttpStatusRetryable -StatusCode 503
    # Returns $true because 503 (Service Unavailable) is retryable

.Example
    $shouldRetry = Test-HttpStatusRetryable -StatusCode 404
    # Returns $false because 404 (Not Found) is not retryable

.Example
    $shouldRetry = Test-HttpStatusRetryable -StatusCode 0
    # Returns $true because 0 indicates network-level error (DNS, timeout)
#>
function Test-HttpStatusRetryable {
    [CmdletBinding()]
    [OutputType([bool])]
    param(
        [Parameter(Mandatory = $true)]
        [int]$StatusCode,
        
        [Parameter(Mandatory = $false)]
        [int[]]$RetryableStatusCodes,
        
        [Parameter(Mandatory = $false)]
        [int[]]$NonRetryableStatusCodes
    )
    
    # Use default configuration if not provided
    if (-not $RetryableStatusCodes) {
        $RetryableStatusCodes = $script:Config.retry.HttpStatusCodes.Retryable
    }
    
    if (-not $NonRetryableStatusCodes) {
        $NonRetryableStatusCodes = $script:Config.retry.HttpStatusCodes.NonRetryable
    }
    
    Write-Verbose "[$($MyInvocation.MyCommand)] Evaluating status code: $StatusCode"
    
    # Status code 0 indicates network-level error (DNS failure, timeout, etc.) - these are retryable
    if ($StatusCode -eq 0) {
        Write-Verbose "[$($MyInvocation.MyCommand)] Status code 0 (network error) - retryable"
        return $true
    }
    
    # Check if explicitly non-retryable
    if ($StatusCode -in $NonRetryableStatusCodes) {
        Write-Verbose "[$($MyInvocation.MyCommand)] Status code $StatusCode is in non-retryable list"
        return $false
    }
    
    # Check if explicitly retryable
    if ($StatusCode -in $RetryableStatusCodes) {
        Write-Verbose "[$($MyInvocation.MyCommand)] Status code $StatusCode is in retryable list"
        return $true
    }
    
    # For status codes not in either list, apply default logic:
    # - 2xx success codes: not retryable (shouldn't happen in error scenarios)
    # - 3xx redirect codes: not retryable (Invoke-WebRequest handles redirects automatically)
    # - 4xx client errors: generally not retryable (except those explicitly listed)
    # - 5xx server errors: generally retryable (except those explicitly listed)
    
    if ($StatusCode -ge 200 -and $StatusCode -lt 300) {
        Write-Verbose "[$($MyInvocation.MyCommand)] Status code $StatusCode is 2xx success - not retryable"
        return $false
    }
    elseif ($StatusCode -ge 300 -and $StatusCode -lt 400) {
        Write-Verbose "[$($MyInvocation.MyCommand)] Status code $StatusCode is 3xx redirect - not retryable"
        return $false
    }
    elseif ($StatusCode -ge 400 -and $StatusCode -lt 500) {
        Write-Verbose "[$($MyInvocation.MyCommand)] Status code $StatusCode is 4xx client error - not retryable by default"
        return $false
    }
    elseif ($StatusCode -ge 500 -and $StatusCode -lt 600) {
        Write-Verbose "[$($MyInvocation.MyCommand)] Status code $StatusCode is 5xx server error - retryable by default"
        return $true
    }
    else {
        Write-Verbose "[$($MyInvocation.MyCommand)] Status code $StatusCode is outside standard HTTP range - not retryable"
        return $false
    }
}

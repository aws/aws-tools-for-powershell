<#
.Synopsis
    Generates appropriate error messages and handles retry logic based on HTTP status codes.

.Description
    This function consolidates the common pattern of HTTP status code error handling
    across network operations. It provides consistent error messages and retry decisions
    based on HTTP status codes.

.Parameter Response
    The response object from Invoke-WebRequestWithStatusHandling containing Success, StatusCode, Error, and Exception properties.

.Parameter Operation
    A description of the operation being performed (e.g., "downloading AWS.Tools.zip", "checking version availability").

.Parameter CustomMessages
    Optional hashtable of custom error messages for specific status codes. Keys should be status codes (int), values should be error messages (string).

.Example
    $response = Invoke-WebRequestWithStatusHandling -Uri $url
    if (-not $response.Success) {
        Get-HttpStatusErrorMessage -Response $response -Operation "downloading AWS.Tools.zip"
    }

.Example
    $customMessages = @{
        404 = "Version not found. Please check the version number."
        403 = "Access denied to version endpoint."
    }
    Get-HttpStatusErrorMessage -Response $response -Operation "checking version" -CustomMessages $customMessages
#>
function Get-HttpStatusErrorMessage {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$false)]
        [hashtable]$Response,
        
        [Parameter(Mandatory=$false)]
        [string]$Operation = "unknown operation",
        
        [Parameter()]
        [hashtable]$CustomMessages = @{}
    )
    
    # Check if we have a custom message for this status code
    if ($CustomMessages.ContainsKey($Response.StatusCode)) {
        $errorMessage = $CustomMessages[$Response.StatusCode]
    }
    else {
        # Generate standard error message based on status code
        $errorMessage = switch ($Response.StatusCode) {
            404 { "Resource not found while $Operation." }
            403 { "Access denied while $Operation." }
            503 { "Service temporarily unavailable while $Operation. This is usually temporary." }
            0   { 
                $msg = "Network error occurred while $Operation"
                if ($Response.Error) { $msg += ": $($Response.Error)" }
                $msg
            }
            default { 
                $msg = "HTTP $($Response.StatusCode) error while $Operation"
                if ($Response.Error) { $msg += ": $($Response.Error)" }
                $msg
            }
        }
    }
    
    # Determine if this should be retried
    $shouldRetry = Test-HttpStatusRetryable -StatusCode $Response.StatusCode
    
    if ($shouldRetry) {
        # For retryable errors, throw the original exception to trigger retry logic
        throw $Response.Exception
    } else {
        # For non-retryable errors, throw the descriptive error message
        throw $errorMessage
    }
}

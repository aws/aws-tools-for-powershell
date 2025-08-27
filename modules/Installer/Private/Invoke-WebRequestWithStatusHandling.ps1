<#
.Synopsis
    Wrapper for Invoke-WebRequest that provides consistent HTTP status code handling across PowerShell versions.

.Description
    This function wraps Invoke-WebRequest to handle the differences between PowerShell 5.1 and 7.x
    exception types, providing a consistent response object with HTTP status codes for better
    error handling and retry logic.

.Parameter Uri
    Specifies the Uniform Resource Identifier (URI) of the Internet resource to which the web request is sent.

.Parameter Method
    Specifies the method used for the web request. Default is 'GET'.

.Parameter TimeoutSec
    Specifies how long the request can be pending before it times out. Default is 300 seconds.

.Parameter Headers
    Specifies the headers of the web request as a hashtable.

.Parameter OutFile
    Specifies the output file for which this cmdlet saves the response body.

.Example
    $response = Invoke-WebRequestWithStatusHandling -Uri "https://example.com" -Method HEAD
    if ($response.Success) {
        Write-Host "Request succeeded with status $($response.StatusCode)"
    } else {
        Write-Warning "Request failed with status $($response.StatusCode): $($response.Error)"
    }

.Example
    $response = Invoke-WebRequestWithStatusHandling -Uri "https://example.com/file.zip" -OutFile "file.zip"
    if (-not $response.Success -and $response.StatusCode -eq 404) {
        Write-Error "File not found at the specified URL"
    }
#>
function Invoke-WebRequestWithStatusHandling {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$Uri,
        
        [Parameter(Mandatory = $false)]
        [string]$Method = 'GET',
        
        [Parameter(Mandatory = $false)]
        [int]$TimeoutSec = $script:Config.network.DefaultTimeout,
        
        [Parameter(Mandatory = $false)]
        [hashtable]$Headers,
        
        [Parameter(Mandatory = $false)]
        [string]$OutFile
    )
    
    Write-Verbose "[$($MyInvocation.MyCommand)] Making $Method request to: $Uri"
    
    try {
        # Build parameters for Invoke-WebRequest
        $webRequestParams = @{
            Uri = $Uri
            Method = $Method
            TimeoutSec = $TimeoutSec
        }
        
        if ($Headers) {
            $webRequestParams.Headers = $Headers
        }
        
        if ($OutFile) {
            $webRequestParams.OutFile = $OutFile
        }
        
        # Make the web request
        # Temporarily suppress progress if PowerShell version is less than 6
        if ($PSVersionTable.PSVersion.Major -lt 6) {
            $savedProgressPreference = $ProgressPreference
            $ProgressPreference = 'SilentlyContinue'
            try {
                $response = Invoke-WebRequest @webRequestParams
            }
            finally {
                $ProgressPreference = $savedProgressPreference
            }
        }
        else {
            $response = Invoke-WebRequest @webRequestParams
        }
        
        # Safely extract status code from successful response
        $statusCode = 200  # Default to 200 for successful requests
        if ($response.PSObject.Properties['StatusCode']) {
            $statusCode = [int]$response.StatusCode
        }
        elseif ($response.PSObject.Properties['BaseResponse'] -and $response.BaseResponse.PSObject.Properties['StatusCode']) {
            $statusCode = [int]$response.BaseResponse.StatusCode
        }
        
        Write-Verbose "[$($MyInvocation.MyCommand)] Request succeeded with status code: $statusCode"
        
        return @{
            Success = $true
            StatusCode = $statusCode
            Content = if ($OutFile) { $null } else { $response.Content }
            Headers = if ($response.PSObject.Properties['Headers']) { $response.Headers } else { @{} }
            RawResponse = $response
        }
    }
    catch {
        # Extract HTTP status code from exception (handles both PowerShell versions)
        $statusCode = $null
        $errorMessage = $_.Exception.Message
        
        # PowerShell 5.1 - System.Net.WebException
        if ($_.Exception -is [System.Net.WebException]) {
            if ($_.Exception.Response) {
                $statusCode = [int]$_.Exception.Response.StatusCode
                Write-Verbose "[$($MyInvocation.MyCommand)] WebException status code: $statusCode"
            }
        }
        # PowerShell 7.x - System.Net.Http.HttpRequestException
        elseif ($_.Exception -is [System.Net.Http.HttpRequestException]) {
            # Try to extract status code from the message or data
            if ($_.Exception.Data -and ($_.Exception.Data -is [System.Collections.IDictionary]) -and $_.Exception.Data.Contains('StatusCode')) {
                $statusCode = [int]$_.Exception.Data['StatusCode']
            }
            elseif ($_.Exception.Message -match 'Response status code does not indicate success: (\d+)') {
                $statusCode = [int]$matches[1]
            }
            # For PowerShell 7.x, we can also check if there's an HttpResponseMessage
            elseif ($_.Exception.PSObject.Properties['HttpResponseMessage']) {
                $statusCode = [int]$_.Exception.HttpResponseMessage.StatusCode
            }
            
            Write-Verbose "[$($MyInvocation.MyCommand)] HttpRequestException status code: $statusCode"
        }
        
        # If we couldn't extract a status code, it's likely a network-level error (DNS, timeout, etc.)
        if (-not $statusCode) {
            $statusCode = 0
            Write-Verbose "[$($MyInvocation.MyCommand)] Network-level error (no HTTP status code): $errorMessage"
        }
        
        Write-Verbose "[$($MyInvocation.MyCommand)] Request failed with status code: $statusCode, Error: $errorMessage"
        
        return @{
            Success = $false
            StatusCode = $statusCode
            Error = $errorMessage
            Exception = $_
            RawException = $_.Exception
        }
    }
}

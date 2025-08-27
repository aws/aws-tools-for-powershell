@{
    # Default maximum retry attempts for most operations
    DefaultMaxRetries = 1
    
    # Maximum retry attempts for version checking
    VersionCheckMaxRetries = 2
    
    # Maximum retry attempts for downloading files
    DownloadMaxRetries = 3
    
    # Maximum retry attempts for file operations
    FileOperationMaxRetries = 1
    
    # Base delay in seconds for exponential backoff
    BaseDelaySeconds = 1.0
    
    # Base delay for file operations (shorter for faster operations)
    FileOperationBaseDelaySeconds = 0.1
    
    # Base delay for download operations (longer for network operations)
    DownloadBaseDelaySeconds = 2.0
    
    # Maximum delay to prevent excessive waits
    MaxDelaySeconds = 30
    
    # Maximum delay for file operations
    FileOperationMaxDelaySeconds = 2
    
    # Exception types that should trigger retries
    # NOTE: Network exceptions differ between PowerShell versions due to underlying .NET implementation:
    # - Windows PowerShell 5.1 (built on .NET Framework): Uses System.Net.WebClient/HttpWebRequest -> throws System.Net.WebException
    # - PowerShell 7.x (built on .NET Core/.NET 5+): Uses System.Net.Http.HttpClient -> throws System.Net.Http.HttpRequestException
    # This is PowerShell version-specific, not operating system-specific. Both exception types are needed for cross-version compatibility.
    RetryableExceptions = @{
        Network = @(
            "System.Net.WebException"           # PowerShell 5.1 (Windows only)
            "System.Net.Http.HttpRequestException"  # PowerShell 7.x (all platforms)
            "System.TimeoutException"           # Both versions
        )
        FileSystem = @(
            "System.IO.IOException"
            "System.UnauthorizedAccessException"
            "System.IO.DirectoryNotFoundException"
            "System.IO.FileNotFoundException"
        )
        Archive = @(
            "System.IO.Compression.InvalidDataException"
        )
    }
    
    # HTTP status codes for retry decisions (preferred over exception-based approach)
    # These provide semantic meaning and work consistently across PowerShell versions
    HttpStatusCodes = @{
        # Status codes that should trigger retries (transient errors)
        Retryable = @(
            408,  # Request Timeout
            429,  # Too Many Requests
            500,  # Internal Server Error
            502,  # Bad Gateway
            503,  # Service Unavailable
            504   # Gateway Timeout
        )
        
        # Status codes that should NOT trigger retries (permanent errors)
        NonRetryable = @(
            400,  # Bad Request
            401,  # Unauthorized
            403,  # Forbidden
            404,  # Not Found
            410,  # Gone
            422   # Unprocessable Entity
        )
        
        # Success status codes (2xx range)
        Success = @(
            200,  # OK
            201,  # Created
            202,  # Accepted
            204   # No Content
        )
    }
}

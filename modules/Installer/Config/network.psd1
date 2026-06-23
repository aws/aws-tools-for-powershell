@{
    # CloudFront base URL for AWS Tools distribution
    CloudFrontBaseUrl = "https://sdk-for-net.amazonwebservices.com/ps"
    
    # Default timeout for network operations (seconds)
    DefaultTimeout = 300
    
    # Timeout for HEAD requests to check versions (seconds)
    HeadRequestTimeout = 30

    HeadRequestTimeoutFast = 3
    
    # Timeout limits for validation
    TimeoutLimits = @{
        Minimum = 10
        Maximum = 3600
    }
    
    # SHA512 validation configuration
    SHA512Validation = @{
        TimeoutSec = 30                    # Timeout for SHA512 file downloads (30 seconds is sufficient for small hash files)
        RetryCount = 3                     # Number of retry attempts for hash file downloads  
        EnableByDefault = $true            # Whether validation is enabled by default
    }
}

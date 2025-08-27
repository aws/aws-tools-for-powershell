BeforeDiscovery {
    # Import the module under test in BeforeDiscovery
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    # Use preference variables instead of mocking Write commands
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

InModuleScope AWS.Tools.Installer {
    Describe -Tag "Smoke", "Low", "Medium", "High" "Get-HttpStatusErrorMessage" {
        BeforeAll {
            # Mock Test-HttpStatusRetryable for consistent testing
            Mock Test-HttpStatusRetryable { return $false } # Default to non-retryable
        }

        Context "Standard error messages" {
            It "Should generate standard 404 error message" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 404
                    Error = "Not Found"
                    Exception = [System.Exception]::new("Test exception")
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" } | 
                Should -Throw "*Resource not found while testing*"
            }

            It "Should generate standard 403 error message" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 403
                    Error = "Forbidden"
                    Exception = [System.Exception]::new("Test exception")
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" } | 
                Should -Throw "*Access denied while testing*"
            }

            It "Should generate standard 503 error message" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 503
                    Error = "Service Unavailable"
                    Exception = [System.Exception]::new("Test exception")
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" } | 
                Should -Throw "*Service temporarily unavailable while testing*"
            }

            It "Should generate network error message for status code 0" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 0
                    Error = "Network timeout"
                    Exception = [System.Exception]::new("Test exception")
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" } | 
                Should -Throw "*Network error occurred while testing: Network timeout*"
            }

            It "Should generate network error message for status code 0 without error details" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 0
                    Error = $null
                    Exception = [System.Exception]::new("Test exception")
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" } | 
                Should -Throw "*Network error occurred while testing*"
            }

            It "Should generate generic HTTP error message for other status codes" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 500
                    Error = "Internal Server Error"
                    Exception = [System.Exception]::new("Test exception")
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" } | 
                Should -Throw "*HTTP 500 error while testing: Internal Server Error*"
            }

            It "Should generate generic HTTP error message without error details" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 500
                    Error = $null
                    Exception = [System.Exception]::new("Test exception")
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" } | 
                Should -Throw "*HTTP 500 error while testing*"
            }
        }

        Context "Custom error messages" {
            It "Should use custom error message when provided" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 404
                    Error = "Not Found"
                    Exception = [System.Exception]::new("Test exception")
                }
                $customMessages = @{
                    404 = "Custom 404 message for this operation"
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" -CustomMessages $customMessages } | 
                Should -Throw "*Custom 404 message for this operation*"
            }

            It "Should fall back to standard message when custom message not provided for status code" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 403
                    Error = "Forbidden"
                    Exception = [System.Exception]::new("Test exception")
                }
                $customMessages = @{
                    404 = "Custom 404 message"
                    # No 403 message provided
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" -CustomMessages $customMessages } | 
                Should -Throw "*Access denied while testing*"
            }

            It "Should handle multiple custom messages" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 503
                    Error = "Service Unavailable"
                    Exception = [System.Exception]::new("Test exception")
                }
                $customMessages = @{
                    404 = "Custom 404 message"
                    403 = "Custom 403 message"
                    503 = "Custom 503 message for this specific operation"
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" -CustomMessages $customMessages } | 
                Should -Throw "*Custom 503 message for this specific operation*"
            }
        }

        Context "Retry logic integration" {
            It "Should throw original exception for retryable errors" {
                # Arrange
                Mock Test-HttpStatusRetryable { return $true } # Make it retryable
                $originalException = [System.Exception]::new("Original network exception")
                $response = @{
                    Success = $false
                    StatusCode = 503
                    Error = "Service Unavailable"
                    Exception = $originalException
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" } | 
                Should -Throw -ExceptionType ([System.Exception])
                
                # Verify Test-HttpStatusRetryable was called
                Should -Invoke Test-HttpStatusRetryable -Times 1 -ParameterFilter { $StatusCode -eq 503 }
            }

            It "Should throw descriptive error message for non-retryable errors" {
                # Arrange
                Mock Test-HttpStatusRetryable { return $false } # Make it non-retryable
                $response = @{
                    Success = $false
                    StatusCode = 404
                    Error = "Not Found"
                    Exception = [System.Exception]::new("Original exception")
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" } | 
                Should -Throw "*Resource not found while testing*"
                
                # Verify Test-HttpStatusRetryable was called
                Should -Invoke Test-HttpStatusRetryable -Times 1 -ParameterFilter { $StatusCode -eq 404 }
            }

            It "Should pass status code to Test-HttpStatusRetryable" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 429
                    Error = "Too Many Requests"
                    Exception = [System.Exception]::new("Test exception")
                }

                # Act
                try {
                    Get-HttpStatusErrorMessage -Response $response -Operation "testing"
                } catch {
                    # Expected to throw
                }

                # Assert
                Should -Invoke Test-HttpStatusRetryable -Times 1 -ParameterFilter { $StatusCode -eq 429 }
            }
        }

        Context "Parameter validation" {
            It "Should require Response parameter" {
                # Act & Assert
                { Get-HttpStatusErrorMessage -Operation "testing" } | Should -Throw
            }

            It "Should require Operation parameter" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 404
                    Error = "Not Found"
                    Exception = [System.Exception]::new("Test exception")
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response } | Should -Throw
            }

            It "Should accept empty CustomMessages hashtable" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 404
                    Error = "Not Found"
                    Exception = [System.Exception]::new("Test exception")
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "testing" -CustomMessages @{} } | 
                Should -Throw "*Resource not found while testing*"
            }
        }

        Context "Operation description integration" {
            It "Should include operation description in error message" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 404
                    Error = "Not Found"
                    Exception = [System.Exception]::new("Test exception")
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "downloading AWS.Tools.zip" } | 
                Should -Throw "*Resource not found while downloading AWS.Tools.zip*"
            }

            It "Should handle complex operation descriptions" {
                # Arrange
                $response = @{
                    Success = $false
                    StatusCode = 0
                    Error = "Connection timeout"
                    Exception = [System.Exception]::new("Test exception")
                }

                # Act & Assert
                { Get-HttpStatusErrorMessage -Response $response -Operation "verifying version 4.1.754 availability" } | 
                Should -Throw "*Network error occurred while verifying version 4.1.754 availability: Connection timeout*"
            }
        }
    }
}

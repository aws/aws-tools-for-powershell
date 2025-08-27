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
    Describe -Tag "Smoke", "Low", "Medium", "High" "Test-HttpStatusRetryable" {
        BeforeAll {
            # Mock the script configuration for consistent testing
            $script:Config = @{
                retry = @{
                    HttpStatusCodes = @{
                        Retryable = @(408, 429, 500, 502, 503, 504)
                        NonRetryable = @(400, 401, 403, 404, 410, 422)
                    }
                }
            }
        }

        Context "Network-level errors (status code 0)" {
            It "Should return true for status code 0 (network error)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 0

                # Assert
                $result | Should -Be $true
            }
        }

        Context "Explicitly retryable status codes" {
            It "Should return true for 408 (Request Timeout)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 408

                # Assert
                $result | Should -Be $true
            }

            It "Should return true for 429 (Too Many Requests)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 429

                # Assert
                $result | Should -Be $true
            }

            It "Should return true for 500 (Internal Server Error)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 500

                # Assert
                $result | Should -Be $true
            }

            It "Should return true for 502 (Bad Gateway)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 502

                # Assert
                $result | Should -Be $true
            }

            It "Should return true for 503 (Service Unavailable)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 503

                # Assert
                $result | Should -Be $true
            }

            It "Should return true for 504 (Gateway Timeout)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 504

                # Assert
                $result | Should -Be $true
            }
        }

        Context "Explicitly non-retryable status codes" {
            It "Should return false for 400 (Bad Request)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 400

                # Assert
                $result | Should -Be $false
            }

            It "Should return false for 401 (Unauthorized)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 401

                # Assert
                $result | Should -Be $false
            }

            It "Should return false for 403 (Forbidden)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 403

                # Assert
                $result | Should -Be $false
            }

            It "Should return false for 404 (Not Found)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 404

                # Assert
                $result | Should -Be $false
            }

            It "Should return false for 410 (Gone)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 410

                # Assert
                $result | Should -Be $false
            }

            It "Should return false for 422 (Unprocessable Entity)" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 422

                # Assert
                $result | Should -Be $false
            }
        }

        Context "Default logic for unlisted status codes" {
            It "Should return false for 2xx success codes" {
                # Act & Assert
                Test-HttpStatusRetryable -StatusCode 200 | Should -Be $false
                Test-HttpStatusRetryable -StatusCode 201 | Should -Be $false
                Test-HttpStatusRetryable -StatusCode 204 | Should -Be $false
                Test-HttpStatusRetryable -StatusCode 299 | Should -Be $false
            }

            It "Should return false for 3xx redirect codes" {
                # Act & Assert
                Test-HttpStatusRetryable -StatusCode 301 | Should -Be $false
                Test-HttpStatusRetryable -StatusCode 302 | Should -Be $false
                Test-HttpStatusRetryable -StatusCode 304 | Should -Be $false
                Test-HttpStatusRetryable -StatusCode 399 | Should -Be $false
            }

            It "Should return false for unlisted 4xx client errors" {
                # Act & Assert
                Test-HttpStatusRetryable -StatusCode 405 | Should -Be $false
                Test-HttpStatusRetryable -StatusCode 409 | Should -Be $false
                Test-HttpStatusRetryable -StatusCode 418 | Should -Be $false # I'm a teapot
                Test-HttpStatusRetryable -StatusCode 499 | Should -Be $false
            }

            It "Should return true for unlisted 5xx server errors" {
                # Act & Assert
                Test-HttpStatusRetryable -StatusCode 501 | Should -Be $true
                Test-HttpStatusRetryable -StatusCode 505 | Should -Be $true
                Test-HttpStatusRetryable -StatusCode 507 | Should -Be $true
                Test-HttpStatusRetryable -StatusCode 599 | Should -Be $true
            }

            It "Should return false for codes outside standard HTTP range" {
                # Act & Assert
                Test-HttpStatusRetryable -StatusCode 100 | Should -Be $false
                Test-HttpStatusRetryable -StatusCode 600 | Should -Be $false
                Test-HttpStatusRetryable -StatusCode 999 | Should -Be $false
                Test-HttpStatusRetryable -StatusCode -1 | Should -Be $false
            }
        }

        Context "Custom status code arrays" {
            It "Should use custom retryable status codes when provided" {
                # Arrange
                $customRetryable = @(418, 451) # Custom retryable codes
                $customNonRetryable = @(503) # Override default retryable code

                # Act & Assert
                Test-HttpStatusRetryable -StatusCode 418 -RetryableStatusCodes $customRetryable -NonRetryableStatusCodes $customNonRetryable | Should -Be $true
                Test-HttpStatusRetryable -StatusCode 503 -RetryableStatusCodes $customRetryable -NonRetryableStatusCodes $customNonRetryable | Should -Be $false
                Test-HttpStatusRetryable -StatusCode 451 -RetryableStatusCodes $customRetryable -NonRetryableStatusCodes $customNonRetryable | Should -Be $true
            }

            It "Should prioritize non-retryable over retryable when both are specified" {
                # Arrange
                $customRetryable = @(500)
                $customNonRetryable = @(500) # Same code in both lists

                # Act
                $result = Test-HttpStatusRetryable -StatusCode 500 -RetryableStatusCodes $customRetryable -NonRetryableStatusCodes $customNonRetryable

                # Assert
                $result | Should -Be $false # Non-retryable takes precedence
            }
        }

        Context "Verbose logging" {
            It "Should write verbose messages for status code evaluation" {
                # Arrange
                Mock Write-Verbose

                # Act
                Test-HttpStatusRetryable -StatusCode 404 -Verbose

                # Assert
                Should -Invoke Write-Verbose -Times 2 # Evaluation message and result message
            }

            It "Should write verbose message for network error (status code 0)" {
                # Arrange
                Mock Write-Verbose

                # Act
                Test-HttpStatusRetryable -StatusCode 0 -Verbose

                # Assert
                Should -Invoke Write-Verbose -Times 2 # Evaluation and network error messages
            }
        }

        Context "Parameter validation" {
            It "Should accept negative status codes" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode -1

                # Assert
                $result | Should -Be $false
            }

            It "Should accept large status codes" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 9999

                # Assert
                $result | Should -Be $false
            }
        }

        Context "Return type validation" {
            It "Should always return a boolean value" {
                # Act & Assert
                $result = Test-HttpStatusRetryable -StatusCode 200
                $result | Should -BeOfType [bool]

                $result = Test-HttpStatusRetryable -StatusCode 404
                $result | Should -BeOfType [bool]

                $result = Test-HttpStatusRetryable -StatusCode 500
                $result | Should -BeOfType [bool]

                $result = Test-HttpStatusRetryable -StatusCode 0
                $result | Should -BeOfType [bool]
            }
        }

        Context "Edge cases" {
            It "Should handle empty custom arrays gracefully" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 500 -RetryableStatusCodes @() -NonRetryableStatusCodes @()

                # Assert
                $result | Should -Be $true # Should fall back to default 5xx logic
            }

            It "Should handle null custom arrays gracefully" {
                # Act
                $result = Test-HttpStatusRetryable -StatusCode 500 -RetryableStatusCodes $null -NonRetryableStatusCodes $null

                # Assert
                $result | Should -Be $true # Should fall back to default 5xx logic
            }
        }
    }
}

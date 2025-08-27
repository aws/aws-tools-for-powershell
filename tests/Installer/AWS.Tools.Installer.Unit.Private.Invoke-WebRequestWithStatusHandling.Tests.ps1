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
    Describe -Tag "Smoke", "Low", "Medium", "High" "Invoke-WebRequestWithStatusHandling" {
        BeforeEach {
            # Mock Invoke-WebRequest for all tests
            Mock Invoke-WebRequest
        }

        Context "Successful requests" {
            It "Should return success response for HTTP 200" {
                # Arrange
                $mockResponse = [PSCustomObject]@{
                    StatusCode = 200
                    Content = "Test content"
                    Headers = @{ 'Content-Type' = 'text/html' }
                }
                Mock Invoke-WebRequest { return $mockResponse }

                # Act
                $result = Invoke-WebRequestWithStatusHandling -Uri "https://example.com"

                # Assert
                $result.Success | Should -Be $true
                $result.StatusCode | Should -Be 200
                $result.Content | Should -Be "Test content"
                $result.Headers | Should -Not -BeNullOrEmpty
                $result.RawResponse | Should -Be $mockResponse
            }

            It "Should pass through all parameters to Invoke-WebRequest" {
                # Arrange
                $mockResponse = [PSCustomObject]@{
                    StatusCode = 200
                    Content = ""
                    Headers = @{}
                }
                Mock Invoke-WebRequest { return $mockResponse }

                # Act
                Invoke-WebRequestWithStatusHandling -Uri "https://example.com" -Method "POST" -TimeoutSec 60 -Headers @{ 'Authorization' = 'Bearer token' } -OutFile "test.txt"

                # Assert
                Should -Invoke Invoke-WebRequest -Times 1 -ParameterFilter {
                    $Uri -eq "https://example.com" -and
                    $Method -eq "POST" -and
                    $TimeoutSec -eq 60 -and
                    $Headers['Authorization'] -eq 'Bearer token' -and
                    $OutFile -eq "test.txt"
                }
            }
        }

        Context "PowerShell 5.1 WebException handling" {
            It "Should extract status code from WebException" {
                # Arrange
                $mockWebResponse = [PSCustomObject]@{
                    StatusCode = [System.Net.HttpStatusCode]::NotFound
                }
                $webException = [System.Net.WebException]::new("Not found")
                $webException | Add-Member -NotePropertyName Response -NotePropertyValue $mockWebResponse -Force
                
                Mock Invoke-WebRequest { throw $webException }

                # Act
                $result = Invoke-WebRequestWithStatusHandling -Uri "https://example.com"

                # Assert
                $result.Success | Should -Be $false
                $result.StatusCode | Should -Be 404
                $result.Error | Should -Be "Not found"
                $result.Exception | Should -Not -BeNullOrEmpty
            }

            It "Should handle WebException without response" {
                # Arrange
                $webException = [System.Net.WebException]::new("Network error")
                Mock Invoke-WebRequest { throw $webException }

                # Act
                $result = Invoke-WebRequestWithStatusHandling -Uri "https://example.com"

                # Assert
                $result.Success | Should -Be $false
                $result.StatusCode | Should -Be 0
                $result.Error | Should -Be "Network error"
            }
        }

        Context "PowerShell 7.x HttpRequestException handling" {
            It "Should extract status code from HttpRequestException message" {
                # Skip test on PowerShell 5.1
                if ($PSVersionTable.PSVersion.Major -lt 6) {
                    Set-ItResult -Skipped -Because "System.Net.Http.HttpRequestException is not available in PowerShell 5.1"
                    return
                }
                
                # Arrange
                $httpException = [System.Net.Http.HttpRequestException]::new("Response status code does not indicate success: 404 (Not Found)")
                Mock Invoke-WebRequest { throw $httpException }

                # Act
                $result = Invoke-WebRequestWithStatusHandling -Uri "https://example.com"

                # Assert
                $result.Success | Should -Be $false
                $result.StatusCode | Should -Be 404
                $result.Error | Should -Match "Response status code does not indicate success: 404"
            }

            It "Should extract status code from HttpRequestException Data" {
                # Skip test on PowerShell 5.1
                if ($PSVersionTable.PSVersion.Major -lt 6) {
                    Set-ItResult -Skipped -Because "System.Net.Http.HttpRequestException is not available in PowerShell 5.1"
                    return
                }
                
                # Arrange
                $httpException = [System.Net.Http.HttpRequestException]::new("HTTP error")
                $httpException.Data['StatusCode'] = 503
                Mock Invoke-WebRequest { throw $httpException }

                # Act
                $result = Invoke-WebRequestWithStatusHandling -Uri "https://example.com"

                # Assert
                $result.Success | Should -Be $false
                $result.StatusCode | Should -Be 503
                $result.Error | Should -Be "HTTP error"
            }

            It "Should handle HttpRequestException without status code" {
                # Skip test on PowerShell 5.1
                if ($PSVersionTable.PSVersion.Major -lt 6) {
                    Set-ItResult -Skipped -Because "System.Net.Http.HttpRequestException is not available in PowerShell 5.1"
                    return
                }
                
                # Arrange
                $httpException = [System.Net.Http.HttpRequestException]::new("Generic HTTP error")
                Mock Invoke-WebRequest { throw $httpException }

                # Act
                $result = Invoke-WebRequestWithStatusHandling -Uri "https://example.com"

                # Assert
                $result.Success | Should -Be $false
                $result.StatusCode | Should -Be 0
                $result.Error | Should -Be "Generic HTTP error"
            }
        }

        Context "Other exception types" {
            It "Should handle timeout exceptions" {
                # Skip test on PowerShell 5.1
                if ($PSVersionTable.PSVersion.Major -lt 6) {
                    Set-ItResult -Skipped -Because "System.Net.Http.HttpRequestException is not available in PowerShell 5.1"
                    return
                }
                
                # Arrange
                $timeoutException = [System.TimeoutException]::new("Request timed out")
                Mock Invoke-WebRequest { throw $timeoutException }

                # Act
                $result = Invoke-WebRequestWithStatusHandling -Uri "https://example.com"

                # Assert
                $result.Success | Should -Be $false
                $result.StatusCode | Should -Be 0
                $result.Error | Should -Be "Request timed out"
            }

            It "Should handle generic exceptions" {
                # Skip test on PowerShell 5.1
                if ($PSVersionTable.PSVersion.Major -lt 6) {
                    Set-ItResult -Skipped -Because "System.Net.Http.HttpRequestException is not available in PowerShell 5.1"
                    return
                }
                
                # Arrange
                $genericException = [System.Exception]::new("Generic error")
                Mock Invoke-WebRequest { throw $genericException }

                # Act
                $result = Invoke-WebRequestWithStatusHandling -Uri "https://example.com"

                # Assert
                $result.Success | Should -Be $false
                $result.StatusCode | Should -Be 0
                $result.Error | Should -Be "Generic error"
            }
        }

        Context "Parameter validation" {
            It "Should use default values for optional parameters" {
                # Arrange
                $mockResponse = [PSCustomObject]@{
                    StatusCode = 200
                    Content = ""
                    Headers = @{}
                }
                Mock Invoke-WebRequest { return $mockResponse }

                # Act
                Invoke-WebRequestWithStatusHandling -Uri "https://example.com"

                # Assert
                Should -Invoke Invoke-WebRequest -Times 1 -ParameterFilter {
                    $Method -eq "GET" -and $TimeoutSec -eq 300
                }
            }
        }

        Context "Verbose logging" {
            It "Should write verbose messages for successful requests" {
                # Arrange
                $mockResponse = [PSCustomObject]@{
                    StatusCode = 200
                    Content = ""
                    Headers = @{}
                }
                Mock Invoke-WebRequest { return $mockResponse }
                Mock Write-Verbose

                # Act
                Invoke-WebRequestWithStatusHandling -Uri "https://example.com" -Verbose

                # Assert
                Should -Invoke Write-Verbose -Times 2 # Start and success messages
            }

            It "Should write verbose messages for failed requests" {
                # Arrange
                $webException = [System.Net.WebException]::new("Not found")
                Mock Invoke-WebRequest { throw $webException }
                Mock Write-Verbose

                # Act
                Invoke-WebRequestWithStatusHandling -Uri "https://example.com" -Verbose

                # Assert
                Should -Invoke Write-Verbose -Times 3 # Start, network-level error, and final failure messages
            }
        }
    }
}

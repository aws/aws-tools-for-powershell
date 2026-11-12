BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
}

AfterAll {
}

Describe -Tag "Smoke" "Get-AWSService" {

    Context "Get-AWSService" {

        BeforeEach {
        }

        AfterEach {
        }

        It "should return more than 170 services with no arguments" {
            (Get-AWSService).Count | Should -BeGreaterThan 170
        }
        
        It "should support filtering by assembly name" {
            (Get-AWSService -Service 'SimpleSystemsManagement' | Where-Object { $_.service -eq 'SimpleSystemsManagement' }).Count | Should -BeGreaterThan 0
        }

        It "should support filtering by service name" {
            # Part of the name only: display names follow the service model and can change.
            (Get-AWSService -Service 'Systems Manager' | Where-Object { $_.service -eq 'SimpleSystemsManagement' }).Count | Should -BeGreaterThan 0
        }

        It "should support filtering by service prefix" {
            (Get-AWSService -Service 'ssm' | Where-Object { $_.service -eq 'SimpleSystemsManagement' }).Count | Should -BeGreaterThan 0
        }

        It "filtering by service prefix should use strict equality" {
            (Get-AWSService -Service 'S3').Count | Should -BeExactly 1
            (Get-AWSService -Service 'S3C').Count | Should -BeExactly 1
        }
    }
}

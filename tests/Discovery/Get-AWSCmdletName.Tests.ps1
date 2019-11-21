. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")

Describe -Tag "Smoke" "Get-AWSCmdletName" {

    BeforeAll {
    }

    AfterAll {
    }

    Context "Get-AWSCmdletName" {

        BeforeEach {
        }

        AfterEach {
        }

        It "should return more than 5000 cmdlets with no arguments" {
            (Get-AWSCmdletName).Count | Should BeGreaterThan 5000
        }
        
        It "should support filtering by assembly name" {
            (Get-AWSCmdletName -Service 'SimpleSystemsManagement' | Where-Object { $_.CmdletName -eq 'Add-SSMSSMResourceTag' }).Count | Should BeGreaterThan 0
        }

        It "should support filtering by service name" {
            (Get-AWSCmdletName -Service 'AWS Systems Manager' | Where-Object { $_.CmdletName -eq 'Add-SSMSSMResourceTag' }).Count | Should BeGreaterThan 0
        }

        It "should support filtering by service prefix" {
            (Get-AWSCmdletName -Service 'SSM' | Where-Object { $_.CmdletName -eq 'Add-SSMSSMResourceTag' }).Count | Should BeGreaterThan 0
        }

        It "filtering by service prefix should use strict equality" {
            (Get-AWSCmdletName -Service 'S3' | Where-Object { $_.CmdletName -eq 'Write-S3Object' }).Count | Should BeGreaterThan 0
            (Get-AWSCmdletName -Service 'S3C' | Where-Object { $_.CmdletName -eq 'Add-S3CS3CPublicAccessBlock' }).Count | Should BeGreaterThan 0
            (Get-AWSCmdletName -Service 'S3' | Where-Object { $_.CmdletName -eq 'Add-S3CS3CPublicAccessBlock' }).Count | Should BeExactly 0
        }

        It "should support filtering by operation and service" {
            (Get-AWSCmdletName -ApiOperation PutObject -Service S3).Count | Should BeGreaterThan 0
        }

        It "should support filtering by operation with regexes" {
            (Get-AWSCmdletName -ApiOperation '^Put.*$' -Service S3 -MatchWithRegex).Count | Should BeGreaterThan 0
        }

        It "should support filtering by cmdlet name" {
            (Get-AWSCmdletName -CmdletName Write-SSMSSMComplianceItem).Count | Should BeGreaterThan 0
        }

        It "should support filtering by cli command" {
            (Get-AWSCmdletName -AwsCliCommand 'ec2 describe-instances').Count | Should BeGreaterThan 0
            (Get-AWSCmdletName -AwsCliCommand 'aws ec2 describe-instances').Count | Should BeGreaterThan 0
        }
    }
}

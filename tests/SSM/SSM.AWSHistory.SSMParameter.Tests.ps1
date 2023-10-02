BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()
}

AfterAll {
    $helper.AfterAll()
}
# Response: Amazon.SimpleSystemsManagement.Model.GetParametersResponse
# Sensitive Parameter: List<Parameter> Parameters. Sensitive Property is Value in Parameter class
Describe -Tag "Smoke" "SSMParameter with nested sensitive property" {

    Context '$AWSHistory sensitive Data Redacted' {
        BeforeAll {
            $parameterName = 'integrationtests-awshistory-' + [DateTime]::Now.ToFileTime()
            $parameterValue = 'parameter value'
        }
        AfterAll {
            $deletedParameter = Remove-SSMParameter -Name $parameterName -Force
        }
        It '$AWSHistory Request is not recorded by default' {
            $ssmParameter = Write-SSMParameter -Name $parameterName -Type 'String' -Value $parameterValue

            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Write-SSMParameter'
            $AWSHistory.LastServiceRequest | Should -Be $null
        }
        It 'Command Result has sensitive value' {

            $ssmParameter = Get-SSMParameterValue -Name $parameterName -Select parameters

            $ssmparameter.Value | Should -BeExactly $parameterValue
        }
        It '$AWSHistory Response is redacted' {

            $ssmParameter = Get-SSMParameterValue -Name $parameterName -Select parameters

            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Get-SSMParameterValue'
            $AWSHistory.LastServiceResponse | Should -Not -Be $null
            $awShistory.LastServiceResponse.Parameters[0].Value | Should -BeNullOrEmpty 
        }
    }
    Context '$AWSHistory non-sensitive data is not redacted' {
        BeforeAll {
            $parameterName = 'integrationtests-awshistory-' + [DateTime]::Now.ToFileTime()
            $parameterValue = 'parameter value'
            $ssmParameter = Write-SSMParameter -Name $parameterName -Type 'String' -Value $parameterValue
        }
        AfterAll {
            $deletedParameter = Remove-SSMParameter -Name $parameterName -Force
        }
        It '$AWSHistory Response Non-Sensitive data is not Redacted' {

            $ssmParameter = Get-SSMParameterValue -Name $parameterName -Select parameters

            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Get-SSMParameterValue'
            $AWSHistory.LastServiceResponse | Should -Not -Be $null
            $AWSHistory.LastServiceResponse.Parameters[0].Name | Should -BeExactly $parameterName
        }
    }
    Context '$AWSHistory RecordServiceRequests is set' {
        BeforeAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests
            $parameterName = 'integrationtests-awshistory-' + [DateTime]::Now.ToFileTime()
            $parameterValue = 'parameter value'
        }
        AfterAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false
            $deletedParameter = Remove-SSMParameter -Name $parameterName -Force
        }
        It '$AWSHistory Request is redacted' {
            $ssmParameter = Write-SSMParameter -Name $parameterName -Type 'String' -Value $parameterValue

            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Write-SSMParameter'
            $AWSHistory.LastServiceRequest | Should -Not -Be $null
            $AWSHistory.LastServiceRequest.Value | Should -BeNullOrEmpty
        }
    }
    Context '$AWSHistory RecordServiceRequests and IncludeSensitiveData are set' {
        BeforeAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests -IncludeSensitiveData
            $parameterName = 'integrationtests-awshistory-' + [DateTime]::Now.ToFileTime()
            $parameterValue = 'parameter value'
        }
        AfterAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false -IncludeSensitiveData:$false
            $deletedParameter = Remove-SSMParameter -Name $parameterName -Force
        }
        It '$AWSHistory has full Request when RecordServiceRequests and IncludeSensitiveData are set' {
            $ssmParameter = Write-SSMParameter -Name $parameterName -Type 'String' -Value $parameterValue

            $AWSHistory.LastServiceRequest | Should -Not -Be $null
            $AWSHistory.LastServiceRequest.Value | Should -BeExactly $parameterValue 
        }
        It '$AWSHistory has full Response when IncludeSensitiveData is set' {
            $ssmParameter = Get-SSMParameterValue -Name $parameterName -Select parameters

            $AWSHistory.LastServiceResponse | Should -Not -Be $null
            $awShistory.LastServiceResponse.Parameters[0].Value | Should -BeExactly $parameterValue 
        }
    }
    Context '$AWSHistory RecordServiceRequests is false, IncludeSensitiveData is true' {
        BeforeAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false -IncludeSensitiveData:$true
            $parameterName = 'integrationtests-awshistory-' + [DateTime]::Now.ToFileTime()
            $parameterValue = 'parameter value'
        }
        AfterAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false -IncludeSensitiveData:$false
            $deletedParameter = Remove-SSMParameter -Name $parameterName -Force
        }
        It '$AWSHistory Request is not recorded when RecordServiceRequests is false' {
            $ssmParameter = Write-SSMParameter -Name $parameterName -Type 'String' -Value $parameterValue

            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Write-SSMParameter'
            $AWSHistory.LastServiceRequest | Should -Be $null
        }
    }
}
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
# Response: Amazon.SimpleSystemsManagement.Model.SendCommandRequest
# Sensitive Parameter: Dictionary<string, List<string>> Parameters
Describe -Tag "Smoke" "SSMCommand with sensitive property type Dictionary" {
    BeforeAll {
        $ssmTarget = @{Key = "tag:non-existent-tag"; Values = "non-existent tag" }
        $ssmCommand1 = 'hello world!'
        $ssmCommand2 = 'See you later!'
        $ssmParameter = @{commands = @($ssmCommand1, $ssmCommand2) }
        $ssmDocumentName = 'AWS-RunPowerShellScript'
    }

    Context '$AWSHistory sensitive data Redacted' {
        It '$AWSHistory Request is not recorded by default' {
            $ssmCommandResult = Send-SSMCommand -DocumentName $ssmDocumentName -Parameter $ssmParameter -Target $ssmTarget

            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Send-SSMCommand'
            $AWSHistory.LastServiceRequest | Should -Be $null
        }
        It '$AWSHistory Response redacted' {

            $ssmCommandResult = Send-SSMCommand -DocumentName $ssmDocumentName -Parameter $ssmParameter -Target $ssmTarget

            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Send-SSMCommand'
            $AWSHistory.LastServiceResponse | Should -Not -Be $null
            $AWSHistory.LastServiceResponse.Command.Parameters.Count | Should -Be 0
        }
    }
        Context '$AWSHistory non-sensitive data is not redacted' {

        It '$AWSHistory non-sensitive response is not redacted' {

            $ssmCommandResult = Send-SSMCommand -DocumentName $ssmDocumentName -Parameter $ssmParameter -Target $ssmTarget

            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Send-SSMCommand'
            $AWSHistory.LastServiceResponse | Should -Not -Be $null
            $AWSHistory.LastServiceResponse.Command.DocumentName | Should -BeExactly $ssmDocumentName
        }
    }
    Context '$AWSHistory RecordServiceRequests is set' {
        BeforeAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests
        }
        AfterAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false
        }
        It '$AWSHistory Request is redacted' {
            $ssmCommandResult = Send-SSMCommand -DocumentName $ssmDocumentName -Parameter $ssmParameter -Target $ssmTarget

            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Send-SSMCommand'
            $AWSHistory.LastServiceRequest | Should -Not -Be $null
            $AWSHistory.LastServiceRequest.Parameters.Count | Should -Be 0
        }
    }
    Context '$AWSHistory RecordServiceRequests and IncludeSensitiveData are set' {
        BeforeAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests -IncludeSensitiveData
        }
    
        It '$AWSHistory has full Request when RecordServiceRequests and IncludeSensitiveData are set' {
            $ssmCommandResult = Send-SSMCommand -DocumentName $ssmDocumentName -Parameter $ssmParameter -Target $ssmTarget

            $AWSHistory.LastServiceRequest | Should -Not -Be $null
            $AWSHistory.LastServiceRequest.Parameters["commands"].Count | Should -eq 2
        }
        It '$AWSHistory has full Response when IncludeSensitiveData is set' {
            $ssmCommandResult = Send-SSMCommand -DocumentName $ssmDocumentName -Parameter $ssmParameter -Target $ssmTarget

            $AWSHistory.LastServiceResponse | Should -Not -Be $null
            $AWSHistory.LastServiceResponse.Command.Parameters["commands"].Count | Should -eq 2
        }
    }
    Context '$AWSHistory RecordServiceRequests is false, IncludeSensitiveData is true' {
        BeforeAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false -IncludeSensitiveData:$true
        }
        AfterAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false -IncludeSensitiveData:$false
        }
        It '$AWSHistory Request is not recorded when RecordServiceRequests is false' {
            $ssmCommandResult = Send-SSMCommand -DocumentName $ssmDocumentName -Parameter $ssmParameter -Target $ssmTarget

            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Send-SSMCommand'
            $AWSHistory.LastServiceRequest | Should -Be $null
        }
    }
}
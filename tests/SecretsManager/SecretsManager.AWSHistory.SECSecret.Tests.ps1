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

Describe -Tag "Smoke" "SecretsManager" {

    Context '$AWSHistory Sensitive Data Redacted' {
        BeforeAll {
            $secretName = 'integrationtests-awshistory-' + [DateTime]::Now.ToFileTime()
            $secretValue = 'test'
        }
        AfterAll {
            $deletedSecret = Remove-SECSecret -SecretId $secretName -DeleteWithNoRecovery $true -Force
        }
        It '$AWSHistory Request is not recorded by default' {
            $secret = New-SECSecret -Name $secretName -SecretString $secretValue

            $AWSHistory.LastServiceRequest | Should -Be $null
        }
        It '$AWSHistory Response Redacted' {
            $secret = Get-SECSecretValue -SecretId $secretName

            $AWSHistory.LastServiceResponse | Should -Not -Be $null
            $AWSHistory.LastServiceResponse.SecretString | Should -BeNullOrEmpty 
        }
        It 'Command Result has sensitive value' {
            $secret = Get-SECSecretValue -SecretId $secretName

            $secret.SecretString | Should -BeExactly $secretValue
        }
    }
    Context '$AWSHistory RecordServiceRequests is set' {
        BeforeAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests
            $secretName = 'integrationtests-awshistory-' + [DateTime]::Now.ToFileTime()
            $secretValue = 'test'
        }
        AfterAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false
            $deletedSecret = Remove-SECSecret -SecretId $secretName -DeleteWithNoRecovery $true -Force
        }
        It '$AWSHistory Request Redacted' {
            $secret = New-SECSecret -Name $secretName -SecretString $secretValue

            $AWSHistory.LastServiceRequest | Should -Not -Be $null
            $AWSHistory.LastServiceRequest.SecretString | Should -BeNullOrEmpty
        }
    }
    Context '$AWSHistory RecordServiceRequests and IncludeSensitiveData are set' {
        BeforeAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests -IncludeSensitiveData
            $secretName = 'integrationtests-awshistory-' + [DateTime]::Now.ToFileTime()
            $secretValue = 'test'
        }
        AfterAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false -IncludeSensitiveData:$false
            $deletedSecret = Remove-SECSecret -SecretId $secretName -DeleteWithNoRecovery $true -Force
        }
        It '$AWSHistory has full Request when RecordServiceRequests and IncludeSensitiveData are set' {
            $secret = New-SECSecret -Name $secretName -SecretString $secretValue

            $AWSHistory.LastServiceRequest | Should -Not -Be $null
            $AWSHistory.LastServiceRequest.SecretString | Should -BeExactly $secretValue 
        }
        It '$AWSHistory has full Response when IncludeSensitiveData is set' {
            $secret = Get-SECSecretValue -SecretId $secretName

            $AWSHistory.LastServiceResponse | Should -Not -Be $null
            $AWSHistory.LastServiceResponse.SecretString | Should -BeExactly $secretValue 
        }
    }
    Context '$AWSHistory RecordServiceRequests is false, IncludeSensitiveData is true' {
        BeforeAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false -IncludeSensitiveData:$true
            $secretName = 'integrationtests-awshistory-' + [DateTime]::Now.ToFileTime()
            $secretValue = 'test'
        }
        AfterAll {
            Set-AWSHistoryConfiguration -RecordServiceRequests:$false -IncludeSensitiveData:$false
            $deletedSecret = Remove-SECSecret -SecretId $secretName -DeleteWithNoRecovery $true -Force
        }
        It '$AWSHistory Request is not recorded when RecordServiceRequests is false' {

            $secret = New-SECSecret -Name $secretName -SecretString $secretValue

            $AWSHistory.LastServiceRequest | Should -Be $null
        }
    }
}

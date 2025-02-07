BeforeAll {
  . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
  . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
  . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
  $helper = New-Object ServiceTestHelper
  $helper.BeforeAll()
  $script:region = 'us-west-2'
  $script:secretName = 'integrationtests-sensitive-data-redaction-' + [DateTime]::Now.ToFileTime()
  $script:secretValue = 'testvalue'
  $script:redactedValue = [Regex]::Escape('*** sensitive data redacted from host ***')
  $null = New-SECSecret -Name $script:secretName -SecretString $script:secretValue -Region $script:region }

AfterAll {
  $helper.AfterAll()
  $deletedSecret = Remove-SECSecret -SecretId $script:secretName -DeleteWithNoRecovery $true -Region $script:region -Force
}

Describe -Tag "Smoke" "AWSSensitiveDataConfiguration Default" {

  Context "Sensitive data redaction defaults" {
    BeforeAll {
      $secret = Get-SECSecretValue -SecretId $script:secretName -Region $script:region
    }
    It "Sensitive data not redacted when dereferenced" {
      $secret.SecretString | Should -BeExactly $script:secretValue
    }

    It "Sensitive data redacted in the host" {
      $secretInHost = ($secret | Out-String -Stream).Where({ $_ -like "SecretString*" })[0]
      $secretInHost | Should -MatchExactly $script:redactedValue
    }

    It "Null Sensitive data redacted in the host" {
      $secretInHost = ($secret | Out-String -Stream).Where({ $_ -like "SecretBinary*" })[0]
      $secretInHost | Should -MatchExactly $script:redactedValue
    }

    It 'Get-AWSSensitiveDataConfiguration should be $false' {
      (Get-AWSSensitiveDataConfiguration).ShowSensitiveData | Should -BeExactly $false
    }
  }
  Context "Sensitive data redaction ShowSensitiveData" {
    BeforeAll {
      Set-AWSSensitiveDataConfiguration -ShowSensitiveData $true
      $secret = Get-SECSecretValue -SecretId $script:secretName -Region $script:region
    }
    
    It "Sensitive data not redacted when dereferenced" {
      $secret.SecretString | Should -BeExactly $script:secretValue
    }

    It "Sensitive data not redacted in the host" {
      $secretInHost = ($secret | Out-String -Stream).Where({ $_ -like "SecretString*" })[0]
      $secretInHost | Should -MatchExactly $script:secretValue
    }

    It "Null Sensitive data not redacted in the host" {
      $secretInHost = ($secret | Out-String -Stream).Where({ $_ -like "SecretBinary*" })[0]
      $secretInHost | Should -Not -MatchExactly $script:redactedValue
    }

    It 'Get-AWSSensitiveDataConfiguration should be $true' {
      (Get-AWSSensitiveDataConfiguration).ShowSensitiveData | Should -BeExactly $true
    }
  }
  Context 'Sensitive data redaction ShowSensitiveData to $false' {
    BeforeAll {
      Set-AWSSensitiveDataConfiguration -ShowSensitiveData $false
      $secret = Get-SECSecretValue -SecretId $script:secretName -Region $script:region
    }

    It "Sensitive data not redacted when dereferenced" {
      $secret.SecretString | Should -BeExactly $script:secretValue
    }

    It "Sensitive data redacted in the host" {
      $secretInHost = ($secret | Out-String -Stream).Where({ $_ -like "SecretString*" })[0]
      $secretInHost | Should -MatchExactly $script:redactedValue
    }

    It "Null Sensitive data redacted in the host" {
      $secretInHost = ($secret | Out-String -Stream).Where({ $_ -like "SecretBinary*" })[0]
      $secretInHost | Should -MatchExactly $script:redactedValue
    }

    It 'Get-AWSSensitiveDataConfiguration should be $false' {
      (Get-AWSSensitiveDataConfiguration).ShowSensitiveData | Should -BeExactly $false
    }
  }
}
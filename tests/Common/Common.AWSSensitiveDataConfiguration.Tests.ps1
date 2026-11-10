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

Describe -Tag "Smoke" "Sensitive single-property default output" {
  BeforeEach {
    # The note is written once per cmdlet per session, so each test starts with none written.
    $noted = [Amazon.PowerShell.Common.SensitiveOutput].GetField('NotedCommands', [System.Reflection.BindingFlags]'NonPublic, Static').GetValue($null)
    $null = $noted.Remove([runspace]::DefaultRunspace)
  }

  AfterEach {
    Set-AWSSensitiveDataConfiguration -ShowSensitiveData $false
  }

  It "Should redact a sensitive string in the host and keep its value everywhere else" {
    function Get-Redacted {
      [CmdletBinding()]
      param()
      [Amazon.PowerShell.Common.SensitiveOutput]::RedactOnHost($script:secretValue, $PSCmdlet, 'RandomPassword')
    }

    $value = Get-Redacted -InformationAction Ignore

    $inHost = ($value | Out-String).Trim()
    $results = @(($value, 'x') -join '|'), ('{0}' -f $value), ($value -match '^testvalue$'), (ConvertTo-Json -InputObject $value -Compress)

    $inHost | Should -MatchExactly $script:redactedValue
    $value | Should -BeOfType [string]
    $results | Should -Be @("$($script:secretValue)|x", $script:secretValue, $true, "`"$($script:secretValue)`"")
  }

  It "Should return the plain <Case> without a note when ShowSensitiveData is on at call time" -ForEach @(
    @{ Case = 'string'; Method = 'RedactOnHost'; Value = 'testvalue' }
    @{ Case = 'tag map'; Method = 'TagForHost'; Value = $($map = [System.Collections.Generic.Dictionary[string, string]]::new(); $map['owner'] = 'testvalue'; $map['team'] = 'other'; $map) }
  ) {
    Set-AWSSensitiveDataConfiguration -ShowSensitiveData $true
    function Get-Sensitive {
      [CmdletBinding()]
      param($InputValue, $MethodName)
      [Amazon.PowerShell.Common.SensitiveOutput]::$MethodName($InputValue, $PSCmdlet, 'Value')
    }

    $expected = $Value | Out-String

    $output = Get-Sensitive -InputValue $Value -MethodName $Method *>&1

    @($output | Where-Object { $_ -is [System.Management.Automation.InformationRecord] }).Count | Should -Be 0
    $output | Out-String | Should -BeExactly $expected
  }

  It "Should show a sensitive string in the host when ShowSensitiveData is turned on later" {
    function Get-Redacted {
      [CmdletBinding()]
      param()
      [Amazon.PowerShell.Common.SensitiveOutput]::RedactOnHost($script:secretValue, $PSCmdlet, 'RandomPassword')
    }

    $value = Get-Redacted -InformationAction Ignore
    Set-AWSSensitiveDataConfiguration -ShowSensitiveData $true

    $inHost = ($value | Out-String).Trim()

    $inHost | Should -BeExactly $script:secretValue
  }

  It "Should write a host note only before the first redacted value of <Cmdlet>" -ForEach @(
    @{ Cmdlet = 'Get-SECRandomPassword'; Call = { Get-SECRandomPassword -Region $script:region }; Type = 'String'; Property = 'RandomPassword' }
    @{ Cmdlet = 'New-KMSRandom'; Call = { New-KMSRandom -NumberOfBytes 8 -Region $script:region }; Type = 'MemoryStream'; Property = 'Plaintext' }
  ) {
    $output = 1..2 | ForEach-Object { & $Call *>&1 }

    $output.ForEach({ $_.GetType().Name }) | Should -Be @('InformationRecord', $Type, $Type)
    $output[0].Tags | Should -Be @('PSHOST')
    "$($output[0].MessageData)" | Should -BeLike "Note: $Cmdlet output is redacted on display.*-Select $Property or*"
  }

  It "Should write one host note per call when the cmdlet selects several pages" {
    function Get-TwoPage {
      [CmdletBinding()]
      param()
      foreach ($page in 1..2) { [Amazon.PowerShell.Common.SensitiveOutput]::RedactOnHost($script:secretValue, $PSCmdlet, 'RandomPassword') }
    }

    $output = Get-TwoPage *>&1

    $output.ForEach({ $_.GetType().Name }) | Should -Be @('InformationRecord', 'String', 'String')
  }

  It "Should write a host note the first time each cmdlet redacts" {
    function Get-FirstSensitive {
      [CmdletBinding()]
      param()
      [Amazon.PowerShell.Common.SensitiveOutput]::RedactOnHost($script:secretValue, $PSCmdlet, 'RandomPassword')
    }
    function Get-SecondSensitive {
      [CmdletBinding()]
      param()
      [Amazon.PowerShell.Common.SensitiveOutput]::RedactOnHost($script:secretValue, $PSCmdlet, 'RandomPassword')
    }

    $output = & { Get-FirstSensitive; Get-SecondSensitive; Get-FirstSensitive } *>&1

    $output.ForEach({ $_.GetType().Name }) | Should -Be @('InformationRecord', 'String', 'InformationRecord', 'String', 'String')
    "$($output[2].MessageData)" | Should -BeLike 'Note: Get-SecondSensitive output*'
  }

  It "Should not write the note when a non-string output is <Case>" -ForEach @(
    @{ Case = 'null'; Value = $null }
    @{ Case = 'an empty collection'; Value = @() }
    @{ Case = 'an empty map'; Value = [System.Collections.Generic.Dictionary[string, string]]::new() }
  ) {
    function Get-SensitiveOutput {
      [CmdletBinding()]
      param($InputValue)
      [Amazon.PowerShell.Common.SensitiveOutput]::TagForHost($InputValue, $PSCmdlet, 'Tags')
    }

    $output = Get-SensitiveOutput -InputValue $Value *>&1

    @($output | Where-Object { $_ -is [System.Management.Automation.InformationRecord] }).Count | Should -Be 0
  }

  It "Should return the value without a note when <Case>" -ForEach @(
    @{ Case = 'InformationAction is Stop'; Parameters = @{ InformationAction = 'Stop' }; Preference = 'SilentlyContinue' }
    @{ Case = 'InformationAction is Inquire'; Parameters = @{ InformationAction = 'Inquire' }; Preference = 'SilentlyContinue' }
    @{ Case = 'InformationPreference is Stop'; Parameters = @{}; Preference = 'Stop' }
  ) {
    $InformationPreference = $Preference
    function Get-Redacted {
      [CmdletBinding()]
      param()
      [Amazon.PowerShell.Common.SensitiveOutput]::RedactOnHost($script:secretValue, $PSCmdlet, 'RandomPassword')
    }

    $output = Get-Redacted @Parameters *>&1

    @($output).Count | Should -Be 1
    "$output" | Should -BeExactly $script:secretValue
  }

  It "Should not write the note when <Case>" -ForEach @(
    @{ Case = 'the information stream is discarded'; Call = { Get-SECRandomPassword -Region $script:region 6>$null } }
    @{ Case = '-Select names the property'; Call = { Get-SECRandomPassword -Region $script:region -Select RandomPassword } }
    @{ Case = 'ShowSensitiveData is on'; Call = { Set-AWSSensitiveDataConfiguration -ShowSensitiveData $true; Get-SECRandomPassword -Region $script:region } }
  ) {
    $output = & $Call *>&1

    @($output).Count | Should -Be 1
    $output | Should -Not -BeOfType [System.Management.Automation.InformationRecord]
  }

  It "Should redact each element of a sensitive non-string value in the host" {
    $tags = [System.Collections.Generic.Dictionary[string, string]]::new()
    $tags['owner'] = $script:secretValue
    $list = [System.Collections.Generic.List[object]]@([pscustomobject]@{ Name = $script:secretValue })

    function Get-Tagged {
      [CmdletBinding()]
      param($InputValue)
      [Amazon.PowerShell.Common.SensitiveOutput]::TagForHost($InputValue, $PSCmdlet, 'Tags')
    }

    $inHost = (@($tags, $list) | ForEach-Object { Get-Tagged -InputValue $_ -InformationAction Ignore | Out-String }) -join ''

    $inHost | Should -Not -Match $script:secretValue
    $inHost | Should -Match $script:redactedValue
  }
}
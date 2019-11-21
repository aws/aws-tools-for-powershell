. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "ConfigService" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Recorders" {

        It "Can list recorders" {
            $recorders = Get-CFGConfigurationRecorders
            if ($recorders) {
                $recorders.Length | Should BeGreaterThan 0
            }
        }

        It "Can read a recorder" {
            $recorders = Get-CFGConfigurationRecorders
            if ($recorders) {
                $recorder = Get-CFGConfigurationRecorderStatus -ConfigurationRecorderName $recorders[0].Name
                $recorder | Should Not Be $null
            }
        }
    }
}

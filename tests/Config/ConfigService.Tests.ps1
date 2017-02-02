. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestIncludes.ps1")
Describe -Tag "Smoke" "ConfigService" {
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

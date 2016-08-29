Describe -Tag "Smoke" "ConfigService" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "List Recorders" {

        It "Can list recorders" {
            $recorders = Get-CFGConfigurationRecorders
            if ($recorders) {
                $recorders.Length | Should BeGreaterThan 0
            }
        }
    }

    Context "Read Recorder" {

        It "Can read a recorder" {
            $recorders = Get-CFGConfigurationRecorders
            if ($recorders) {
                $recorder = Get-CFGConfigurationRecorderStatus -ConfigurationRecorderName $recorders[0].Name
                $recorder | Should Not Be $null
            }
        }
    }
}

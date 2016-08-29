# Note that calling AWS Support requires an account with an AWS Premium Support
# subscription.
Describe -Tag "Smoke" "SupportService" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Can query services" {

        It "Can retrieve services" {
            $services = Get-ASAServices
            $services | Should Not Be $null
            $services.Length | Should BeGreaterThan 0
        }
    }
}

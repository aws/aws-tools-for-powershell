Describe -Tag "Smoke" "Route53Domains" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Domain Availability" {

        It "Can check domain availability" {
            $response = Get-R53DDomainAvailability -DomainName "amazon.com"
            $response | Should Not Be $null
            $response.Value | Should Be "UNAVAILABLE"
        }
    }
}

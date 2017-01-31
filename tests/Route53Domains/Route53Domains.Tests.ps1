Describe -Tag "Smoke" "Route53Domains" {
    Context "Domains" {

        It "Can check domain availability" {
            $response = Get-R53DDomainAvailability -DomainName "amazon.com"
            $response | Should Not Be $null
            $response.Value | Should Be "UNAVAILABLE"
        }
    }
}

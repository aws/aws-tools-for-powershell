Describe -Tag "Smoke" "CloudSearch" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "List and Enumerate Domains" {

        It "Can list domains" {
            $domains = Get-CSDomain
            if ($domains) {
                $domains.Count | Should BeGreaterThan 0
            }
        }

        It "Can enumerate domains" {
            $domains = Get-CSDomain
            if ($domains) {
                foreach ($domain in $domains) {
                    $dn = $domain.DomainName
                     Write-Verbose "Examining domain [$dn]"

                     $indexFields = Get-CSIndexField -DomainName $dn
                     if ($indexFields) {
                         $indexFields.Count | Should BeGreaterThan 0
                     }

                }
            }

        }
    }
}

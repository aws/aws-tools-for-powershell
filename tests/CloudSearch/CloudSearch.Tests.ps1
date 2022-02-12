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

Describe -Tag "Smoke" "CloudSearch" {

    Context "List and Enumerate Domains" {

        It "Can list domains" {
            $domains = Get-CSDomain
            if ($domains) {
                $domains.Count | Should -BeGreaterThan 0
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
                         $indexFields.Count | Should -BeGreaterThan 0
                     }

                }
            }

        }
    }
}

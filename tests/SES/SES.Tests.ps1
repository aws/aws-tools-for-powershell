. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestIncludes.ps1")
Describe -Tag "Smoke" "SES" {
    Context "Send statistics" {

        It "Can get send statistics" {
        	$stats = Get-SESSendStatistics
            if ($stats) {
                $stats.Count | Should BeGreaterThan 0
            }
        }
    }

    Context "Quotas" {

        It "Can get quotas" {
            $quota = Get-SESSendQuota
            $quota | Should Not Be $null
        }
    }

    Context "Identity" {

        It "Can get send identities" {
            $identities = Get-SESIdentity
            if ($identities) {
                $identities.Count | Should BeGreaterThan 0
            }
        }
    }
}

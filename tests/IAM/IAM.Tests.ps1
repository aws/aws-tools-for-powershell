Describe -Tag "Smoke" "IAM" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Roles" {

        It "Can list and read roles" {
            $roles = Get-IAMRoles
            if ($roles) {
                $roles.Count | Should BeGreaterThan 0

                foreach ($r in $roles)
                {
                    $role = Get-IAMRole -RoleName $r.RoleName
                    $role | Should Not Be $null
                }
            }
	
        }
    }

    Context "Instance Profiles" {

        It "Can list and read instance profiles" {

            $profiles = Get-IAMInstanceProfiles
            if ($profiles) {
                $profiles.Count | Should BeGreaterThan 0

                foreach ($p in $profiles) {
                    $profile = Get-IAMInstanceProfile -InstanceProfileName $p.InstanceProfileName
                    $profile | Should Not Be $null
                }
            }
        }
    }

    Context "Account Summary" {

        It "Can get account summary" {
            $summaryMap = Get-IAMAccountSummary
            $summaryMap | Should Not Be $null
            $summaryMap.Users | Should BeGreaterThan 0
            $summaryMap.GroupsQuota | Should BeGreaterThan 0
            $summaryMap.RolesQuota | Should BeGreaterThan 0
            $summaryMap.GroupPolicySizeQuota | Should BeGreaterThan 0
            $summaryMap.ServerCertificates | Should BeGreaterThan 0
            $summaryMap.ServerCertificatesQuota | Should BeGreaterThan 0
            $summaryMap.Roles | Should BeGreaterThan 0
            $summaryMap.InstanceProfiles | Should BeGreaterThan 0
        }
    }

    Context "Regions" {

        It "Signs ok when used with non-us-east-1 region" {
            $summaryMap = Get-IAMAccountSummary -Region ap-southeast-2
             $summaryMap | Should Not Be $null
        }

    }
}
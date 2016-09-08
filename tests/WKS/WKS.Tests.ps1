Describe -Tag "Smoke" "WKS" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Workspaces" {

        It "Can list workspaces" {
            $workspaces = Get-WKSWorkspaces
            if ($workspaces) {
                $workspaces.Count | Should BeGreaterThan 0
            }
        }
    }
}
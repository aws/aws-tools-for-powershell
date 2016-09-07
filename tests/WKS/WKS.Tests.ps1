Describe -Tag "Smoke" "WKS" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Workspace" {

        It "Can list workspaces" {
            $workspaces = Get-WKSWorkspaces
            if ($workspaces) {
                $workspaces.Count | Should BeGreaterThan 0
            }
        }
    }
}
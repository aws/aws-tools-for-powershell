Describe -Tag "Smoke" "WKS" {
    Context "Workspaces" {

        It "Can list workspaces" {
            $workspaces = Get-WKSWorkspaces
            if ($workspaces) {
                $workspaces.Count | Should BeGreaterThan 0
            }
        }
    }
}
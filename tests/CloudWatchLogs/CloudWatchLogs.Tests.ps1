Describe -Tag "Smoke" "CloudWatchLogs" {
    Context "Log Groups" {

        It "Can list log groups" {
            $logGroups = Get-CWLLogGroups
            if ($logGroups) {
                $logGroups.Count | Should BeGreaterThan 0
            }
        }
    }
}

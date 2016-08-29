Describe -Tag "Smoke" "CloudWatchLogs" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "List log groups" {

        It "Can list log groups" {
            $logGroups = Get-CWLLogGroups
            if ($logGroups) {
                $logGroups.Count | Should BeGreaterThan 0
            }
        }
    }
}

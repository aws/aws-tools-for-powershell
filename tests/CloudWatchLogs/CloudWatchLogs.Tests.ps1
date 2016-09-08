Describe -Tag "Smoke" "CloudWatchLogs" {

    BeforeAll{
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Log Groups" {

        It "Can list log groups" {
            $logGroups = Get-CWLLogGroups
            if ($logGroups) {
                $logGroups.Count | Should BeGreaterThan 0
            }
        }
    }
}

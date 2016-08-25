Describe -Tag "Smoke" "CodeCommit Tests" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "List repositories" {

        It "Can list repositories" {
            # if we have no real repos, we get null response
            $repos = Get-CCRepositoryList
            if ($repos) {
                $repos.Length | Should BeGreaterThan 0
            }
        }
    }
}

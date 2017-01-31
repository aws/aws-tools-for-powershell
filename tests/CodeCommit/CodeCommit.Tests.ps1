Describe -Tag "Smoke" "CodeCommit" {
    Context "Repositories" {

        It "Can list repositories" {
            # if we have no real repos, we get null response
            $repos = Get-CCRepositoryList
            if ($repos) {
                $repos.Length | Should BeGreaterThan 0
            }
        }
    }
}

Describe -Tag "Smoke" "STS" {
    Context "Temporary Credentials" {

        It "Can get temporary credentials" {
            $creds = Get-STSSessionToken
            $creds | Should Not Be $null
            $creds.AccessKeyId | Should Not BeNullOrEmpty
            $creds.SecretAccessKey | Should Not BeNullOrEmpty
            $creds.SessionToken | Should Not BeNullOrEmpty
        }
    }
}
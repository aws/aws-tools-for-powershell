Describe -Tag "Smoke" "OpsWorks" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Stacks" {

        It "Can list and summarize stacks" {

            $stacks = Get-OPSStacks
            if ($stacks) {
                $stacks.Count | Should BeGreaterThan 0

                $stack = Get-OPSStackSummary -StackId $stacks[0].StackId
                $stack | Should Not Be $null
                $stack.Arn | Should Be $stacks[0].Arn
            }
        }
    }
}

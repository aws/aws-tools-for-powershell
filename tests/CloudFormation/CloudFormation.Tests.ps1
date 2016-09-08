Describe -Tag "Smoke" "CloudFormation" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Stacks" {

        It "Can call Get-CFNStack to get all stacks" {
            $stacks = Get-CFNStack
            if ($stacks) {
                $stacks.Count | Should BeGreaterThan 0
            }
        }

        It "Can call Get-CFNStack with a stack name" {
            $stacks = Get-CFNStack
            if ($stacks) {
                $stack = Get-CFNStack -StackName $stacks[0].StackName

                $stack | Should Not Be $null
                $stack.StackId | Should Be $stacks[0].StackId
            }
        }

        It "Can get deleted stacks" {
            $deletedStacks = Get-CFNStackSummary -StackStatusFilter DELETE_COMPLETE
            if ($deletedStacks) {
                $deletedStacks.Count | Should BeGreaterThan 0
            }
        }

    }
}

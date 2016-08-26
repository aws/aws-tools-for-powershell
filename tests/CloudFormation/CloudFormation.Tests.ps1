Describe -Tag "Smoke" "CloudFormation General Tests" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "List all stacks" {

        It "Can call Get-CFNStack to get all stacks" {
            $stacks = Get-CFNStack
            if ($stacks) {
                $stacks.Count | Should BeGreaterThan 0 
            }
        }

    }

    Context "Get stack by name" {

        It "Can call Get-CFNStack with a stack name" {
            $stacks = Get-CFNStack
            if ($stacks) {
                $stack = Get-CFNStack -StackName $stacks[0].StackName

                $stack | Should Not Be $null
                $stack.StackId | Should Be $stacks[0].StackId
            }
        }
    }

    Context "Get stack summary" {

        It "Can get deleted stacks" {
            $deletedStacks = Get-CFNStackSummary -StackStatusFilter DELETE_COMPLETE
            if ($deletedStacks) {
                $deletedStacks.Count | Should BeGreaterThan 0
            }
        }

    }
}

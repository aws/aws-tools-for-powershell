BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()
}

AfterAll {
    $helper.AfterAll()
}

Describe -Tag "Smoke" "CloudFormation" {

    Context "Stacks" {

        It "Can call Get-CFNStack to get all stacks" {
            $stacks = Get-CFNStack
            if ($stacks) {
                $stacks.Count | Should -BeGreaterThan 0
            }
        }

        It "Can call Get-CFNStack with a stack name" {
            $stacks = Get-CFNStack
            if ($stacks) {
                $stack = Get-CFNStack -StackName $stacks[0].StackName

                $stack | Should -Not -Be $null
                $stack.StackId | Should -Be $stacks[0].StackId
            }
        }

        It "Can get deleted stacks" {
            $deletedStacks = Get-CFNStackSummary -StackStatusFilter DELETE_COMPLETE
            if ($deletedStacks) {
                $deletedStacks.Count | Should -BeGreaterThan 0
            }
        }

    }
}

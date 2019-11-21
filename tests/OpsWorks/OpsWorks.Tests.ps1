. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "OpsWorks" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
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

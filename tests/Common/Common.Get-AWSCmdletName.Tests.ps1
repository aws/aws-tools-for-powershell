BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
}

AfterAll {
    
}

Describe -Tag "Smoke" "Common.Get-AWSCmdletName" {

    Context "Get-AWSCmdletName" {

        It "Get-AWSCmdletName has no duplicate Cmdlets" {
            $cmdlets = Get-AWSCmdletName
            $duplicateCmdlets = $cmdlets | Group-Object -Property CmdletName | Where-Object {$_.Count -gt 1}

            $cmdlets.Count | Should -BeGreaterOrEqual 1
            $duplicateCmdlets | Should -Be $null
        }
    }
}
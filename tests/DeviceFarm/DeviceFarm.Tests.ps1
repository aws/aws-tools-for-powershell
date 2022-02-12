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

Describe -Tag "Smoke" "DeviceFarm" {

    Context "Projects" {
        It "Can list projects" {
            $projects = Get-DFProjectList -Region us-west-2
            if ($projects) {
                $projects.Count | Should -BeGreaterThan 0

                $project = Get-DFProject -Arn $projects[0].Arn -Region us-west-2

                $project.Name | Should -Be $projects[0].Name
            }
        }
    }
}
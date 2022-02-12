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


Describe -Tag "Smoke" "DirectoryService" {

    Context "Limits" {

        It "Can query limits" {
            $limits = Get-DSDirectoryLimit
            $limits | Should -Not -Be $null

        }
    }

    Context "Directories" {

        It "Can list and read directories" {
            $dirs = Get-DSDirectory
            if ($dirs) {
                $dirs.Count | Should -BeGreaterThan 0

                $dir = Get-DSDirectory -DirectoryId $dirs[0].DirectoryId
                $dir | Should -Not -Be $null

                $dir.Name | Should -Be $dirs[0].Name
            }
        }
    }
}
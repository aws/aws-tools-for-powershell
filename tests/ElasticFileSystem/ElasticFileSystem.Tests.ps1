. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "ElasticFileSystem" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "File Systems" {

        It "Can list file systems" {
            $allfs = Get-EFSFileSystem
            if ($allfs) {
                $allfs.Count | Should BeGreaterThan 0

                $fs = Get-EFSFileSystem -FileSystemId $allfs[0].FileSystemId
                $fs | Should Not Be $null

                $fs.FileSystemId | Should Be $allfs[0].FileSystemId
            }
        }
    }
}

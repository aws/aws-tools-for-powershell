Describe -Tag "Smoke" "ElasticFileSystem" {
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

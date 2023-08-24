BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
}

AfterAll {
    
}

Describe -Tag "Smoke" "Common.FileSize" {

    Context "FileSize" {

        It "FileSize without a suffix" {
            [Amazon.PowerShell.Common.FileSize]$filesize = New-Object -TypeName "Amazon.PowerShell.Common.FileSize" ("345678")
            $filesize | Should -Not -Be $null
            $filesize.FileSizeInBytes | Should -BeExactly 345678
        }

        It "FileSize with a suffix" {
            [Amazon.PowerShell.Common.FileSize]$filesize = New-Object -TypeName "Amazon.PowerShell.Common.FileSize" ("15KB")
            $filesize | Should -Not -Be $null
            $filesize.FileSizeInBytes | Should -BeExactly 15360
        }

        It "FileSize with space between value and suffix" {
            [Amazon.PowerShell.Common.FileSize]$filesize = New-Object -TypeName "Amazon.PowerShell.Common.FileSize" ("15 MB")
            $filesize | Should -Not -Be $null
            $filesize.FileSizeInBytes | Should -BeExactly 15728640
        }

        It "FileSize with double value" {
            [Amazon.PowerShell.Common.FileSize]$filesize = New-Object -TypeName "Amazon.PowerShell.Common.FileSize" ("15.5GB")
            $filesize | Should -Not -Be $null
            $filesize.FileSizeInBytes | Should -BeExactly 16642998272
        }

        It "FileSize with negative value" {
            [Amazon.PowerShell.Common.FileSize]$filesize = New-Object -TypeName "Amazon.PowerShell.Common.FileSize" ("-15MB")
            $filesize | Should -Not -Be $null
            $filesize.FileSizeInBytes | Should -BeExactly -15728640
        }

        It "FileSize with missing value" {
            { New-Object -TypeName "Amazon.PowerShell.Common.FileSize" ("") } | Should -Throw 'Exception calling ".ctor" with "1" argument(s): "Missing value for argument.*'
        }

        It "FileSize with invalid value" {
            { New-Object -TypeName "Amazon.PowerShell.Common.FileSize" ("15.12.45MB") } | Should -Throw 'Exception calling ".ctor" with "1" argument(s): "The input string ''15.12.45'' was not in a correct format."'
        }

        It "FileSize with unsupported suffix" {
            { New-Object -TypeName "Amazon.PowerShell.Common.FileSize" ("15.12PB") } | Should -Throw 'Exception calling ".ctor" with "1" argument(s): "Unsupported file size extension PB."'
        }
    }
}
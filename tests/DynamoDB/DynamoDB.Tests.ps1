
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

Describe -Tag "Smoke" "DynamoDB" {

    Context "Tables" {

        It "Can list and describe tables" {
            $tables = Get-DDBTables
            if ($tables) {
                $tables.Count | Should -BeGreaterThan 0

                $tablename = $tables | select -first 1 
                $table = $tablename | Get-DDBTable
                $table | Should -Not -Be $null
                $table.TableName | Should -Be $tablename
            }
        }
    }
}
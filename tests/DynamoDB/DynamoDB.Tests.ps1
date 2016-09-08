Describe -Tag "Smoke" "DynamoDB" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Tables" {

        It "Can list and describe tables" {
            $tables = Get-DDBTables
            if ($tables) {
                $tables.Count | Should BeGreaterThan 0

                $table = Get-DDBTable -TableName $tables[0]
                $table | Should Not Be $null
                $table.TableName | Should Be $tables[0]
            }
        }
    }
}
Describe -Tag "Smoke" "RDS" {
    Context "Engines" {

        It "Can get engines" {
            $engines = Get-RDSDBEngineVersion
            if ($engines) {
                $engines.Count | Should BeGreaterThan 0
            }
        }
    }
}

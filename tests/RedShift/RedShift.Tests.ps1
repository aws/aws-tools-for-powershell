Describe -Tag "Smoke" "RedShift" {
    Context "Clusters" {

        It "Can get Orderable Cluster Options" {
            $options = Get-RSOrderableClusterOptions
            if ($options) {
                $options.Count | Should BeGreaterThan 0
            }
        }
    }
}

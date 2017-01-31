Describe -Tag "Smoke" "Lambda" {
    Context "Functions" {

        It "Can list and read functions" {
            $fns = Get-LMFunctions
            if ($fns) {
                $fns.Count | Should BeGreaterThan 0

                $fn = Get-LMFunction -FunctionName $fns[0].FunctionName

                $fn | Should Not Be $null
            }
        }
    }
}

Describe -Tag "Smoke" "SSM" {
    Context "Documents" {

        It "Can list and read documents" {
            $docs = Get-SSMDocumentList
            if ($docs) {
                $docs.Count | Should BeGreaterThan 0

                $doc = Get-SSMDocument -Name $docs[0].Name
                $doc | Should Not Be $null
                $doc.Name | Should Be $docs[0].Name 
            }
        }
    }
}

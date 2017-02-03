. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "SSM" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

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

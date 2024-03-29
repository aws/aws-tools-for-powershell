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

Describe -Tag "Smoke" "EC2ContainerService" {

    Context "Clusters" {

        It "Can list and read clusters" {
            $clusters = Get-ECSClusters
            if ($clusters) {
                $clusters.Count | Should -BeGreaterThan 0

                $cluster = Get-ECSClusterDetail -Cluster $clusters[0]
                $cluster | Should -Not -Be $null
            }
        }
    }
}

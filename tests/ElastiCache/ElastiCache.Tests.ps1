. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "ElastiCache" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Clusters" {

        It "Can list and read clusters" {
            $clusters = Get-ECCacheCluster
            if ($clusters) {
                $clusters.Count | Should BeGreaterThan 0

                $cluster = Get-ECCacheCluster -CacheClusterId $clusters[0].CacheClusterId
                $cluster | Should Not Be $null
                $cluster.CacheClusterId | Should Be $clusters[0].CacheClusterId
            }
        }
    }

    Context "Cache Parameter Group" {

        It "Can list and read parameter groups" {
            $groups = Get-ECCacheParameterGroup
            if ($groups) {
                $groups.Count | Should BeGreaterThan 0

                $groupName = $groups[0].CacheParameterGroupName
                $groupFamily = $groups[0].CacheParameterGroupFamily

                # These tests commented out temporarily
                # https://tt.amazon.com/0106707358

                #$group = Get-ECCacheParameterGroup -CacheParameterGroupName $groupName
                #$group | Should Not Be $null
                
                #$group.CacheParameterGroupName | Should Be $groupName
                #$group.CacheParameterGroupFamily | Should Be $groupFamily

        		$parameters = Get-ECCacheParameter -CacheParameterGroupName $groupName
                $parameters | Should Not Be $null

		        $defaults = Get-ECEngineDefaultParameter -CacheParameterGroupFamily $groupFamily
                $defaults | Should Not Be $null
            }
        }
    }
}

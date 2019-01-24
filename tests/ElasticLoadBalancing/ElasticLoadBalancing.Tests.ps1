. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "ElasticLoadBalancing" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Load Balancers" {

        It "Can list and get load balancers" {
            $elblist = Get-ELBLoadBalancer
            if ($elblist) {
                $elblist.Count | Should BeGreaterThan 0

                $elb = Get-ELBLoadBalancer -LoadBalancerName $elblist[0].LoadBalancerName

                $elb | Should Not Be $null
                $elb.LoadBalancerName | Should Be $elblist[0].LoadBalancerName
            }
        }
    }
}

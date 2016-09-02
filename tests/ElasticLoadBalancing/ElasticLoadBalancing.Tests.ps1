Describe -Tag "Smoke" "ElasticLoadBalancing" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "List and get" {

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

    Context "Create and delete" {

        BeforeAll {
            $random = New-Object System.Random
            $testLBName = "ps-test-lb-" + $random.Next()
            $lbCreated = $false
        }

        It "Can create a load balancer" {
            $listener = New-Object Amazon.ElasticLoadBalancing.Model.Listener
            $listener.Protocol = "http"
            $listener.InstancePort = 80
            $listener.LoadBalancerPort = 80
            $dnsName = New-ELBLoadBalancer -LoadBalancerName $testLBName -Listeners $listener -AvailabilityZones "us-east-1a"

            $lbCreated = $true
            $dnsName | Should Not BeNullOrEmpty
        }

        It "Can retrieve the new load balancer" {
            Start-Sleep -Seconds 5
            $newLB = Get-ELBLoadBalancer -LoadBalancerName $testLBName
            $newLB | Should Not Be $null
        }

        It "Can delete the new load balancer" {
            Remove-ELBLoadBalancer -LoadBalancerName $testLBName -Force
            $lbCreated = $false
        }

        AfterAll {
            if ($lbCreated) {
                try {
                    Remove-ELBLoadBalancer -LoadBalancerName $testLBName -Force
                }
                catch {}
            }
        }
    }
}

Describe -Tag "Smoke" "ElasticLoadBalancing" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
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

        $random = New-Object System.Random
        $script:testLBName = "ps-test-lb-" + $random.Next()

        It "Can create a load balancer" {
            $listener = New-Object Amazon.ElasticLoadBalancing.Model.Listener
            $listener.Protocol = "http"
            $listener.InstancePort = 80
            $listener.LoadBalancerPort = 80
            $dnsName = New-ELBLoadBalancer -LoadBalancerName $script:testLBName -Listeners $listener -AvailabilityZones "us-east-1a"
            $dnsName | Should Not BeNullOrEmpty
        }

        It "Can retrieve the new load balancer" {
            Start-Sleep -Seconds 5
            $newLB = Get-ELBLoadBalancer -LoadBalancerName $script:testLBName
            $newLB | Should Not Be $null
        }

        It "Can delete the new load balancer" {
            Remove-ELBLoadBalancer -LoadBalancerName $script:testLBName -Force
        }
    }
}

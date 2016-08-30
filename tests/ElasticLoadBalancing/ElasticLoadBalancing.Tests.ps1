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

        It "Can create and delete a load balancer" {
            $random = New-Object System.Random
            $testLBName = "ps-test-lb-" + $random.Next()

            try {
                $listener = New-Object Amazon.ElasticLoadBalancing.Model.Listener
                $listener.Protocol = "http"
                $listener.InstancePort = 80
                $listener.LoadBalancerPort = 80
                New-ELBLoadBalancer -LoadBalancerName $testLBName -Listeners $listener -AvailabilityZones "us-east-1a"
        
                Start-Sleep -Seconds 5
                $newLB = Get-ELBLoadBalancer -LoadBalancerName $testLBName
                $newLB | Should Not Be $null
            }
            finally {
                Remove-ELBLoadBalancer -LoadBalancerName $testLBName -Force
            }
        }
    }
}


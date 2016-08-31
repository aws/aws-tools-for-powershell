Describe -Tag "Smoke","Disabled" "ElasticMapReduce" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Reading clusters" {

        It "Can read clusters" {
            $clusters = Get-EMRClusters
            if ($clusters) {
                $clusters.Count | Should BeGreaterThan 0
            }            
        }
    }

    Context "Job flows" {

        BeforeAll {
            $random = New-Object System.Random
            $JFName = "ps-test-jf-" + $random.Next()
            $flowId = $null
        }

        It "Can start a job flow" {
            # currently errors claiming 'InstanceProfile' is required.
            # service api doc mentions JobFlowRole but not that it is required,
            # as the service will use a default 'EMR_EC2_DefaultRole' but
            # it must be created.
            $params = @{
                Name = "Hive Interactive"
                LogUri = "s3://log-bucket"
                Instances_MasterInstanceType = "m1.small"
                Instances_SlaveInstanceType = "m1.small"
                Instances_InstanceCount = 5
                Instances_Ec2KeyName = "pavel2"
                Instances_KeepJobFlowAliveWhenNoSteps = $true
                Instances_HadoopVersion = "0.20"
            }
            $flowId = Start-EMRJobFlow @params 

            $flowId | Should Not BeNullOrEmpty
        }

        It "Can stop a job flow" {
        	Stop-EMRJobFlow -JobFlowIds $flowId
            $flowId = $null # skip cleanup
        }

        AfterAll {
            if ($flowId) {
                try {
                    Stop-EMRJobFlow -JobFlowId $flowId
                }
                catch {}
            }
        }
    }
}

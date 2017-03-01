. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke","Disabled" "ElasticMapReduce" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Clusters" {

        It "Can read clusters" {
            $clusters = Get-EMRClusters
            if ($clusters) {
                $clusters.Count | Should BeGreaterThan 0
            }            
        }
    }

    Context "Job Flows" {

        $random = New-Object System.Random
        $script:JFName = "ps-test-jf-" + $random.Next()
        $script:flowId = $null

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
            $script:flowId = Start-EMRJobFlow @params 

            $script:flowId | Should Not BeNullOrEmpty
        }

        It "Can stop a job flow" {
        	Stop-EMRJobFlow -JobFlowIds $script:flowId
        }
    }
}

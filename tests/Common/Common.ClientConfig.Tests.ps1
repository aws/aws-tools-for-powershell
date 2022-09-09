BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestModuleIncludes.ps1")
}

Describe -Tag "Smoke" "Common.ClientConfig" {

    Context "ClientConfig" {

        It "Only ClientConfig parameter" {
            $params=@{
              ClientConfig=@{
                ForcePathStyle=$true
                Timeout=[TimeSpan]::FromMilliseconds(150000)
                RegionEndPoint=([Amazon.RegionEndpoint]::USWest1)
              }
            }
            
            [Amazon.S3.AmazonS3Client]$clientObject = Test-S3ClientConfig @params
            $clientObject | Should -Not -Be $null
            [Amazon.S3.AmazonS3Config]$config = $clientObject.Config
            $config.ForcePathStyle | Should -BeTrue
            $config.Timeout.TotalMilliseconds | Should -BeExactly 150000
            $config.RegionEndpoint.SystemName | Should -Be "us-west-1"
        }

        It "ClientConfig and explicit Region parameter" {
            $params=@{
              ClientConfig=@{
                Timeout=[TimeSpan]::FromMilliseconds(160000)
                RegionEndPoint=([Amazon.RegionEndpoint]::USWest1)
              }
            }

            [Amazon.S3.AmazonS3Client]$clientObject = Test-S3ClientConfig @params -Region us-west-2
            $clientObject | Should -Not -Be $null
            [Amazon.S3.AmazonS3Config]$config = $clientObject.Config
            $config.Timeout.TotalMilliseconds | Should -BeExactly 160000
            $config.RegionEndpoint.SystemName | Should -Be "us-west-2"
        }

        It "ClientConfig and implicit Region" {
            $params=@{
              ClientConfig=@{
                Timeout=[TimeSpan]::FromMilliseconds(110000)
                RegionEndPoint=([Amazon.RegionEndpoint]::USWest1)
              }
              Region="us-west-2"
            }

            [Amazon.S3.AmazonS3Client]$clientObject = Test-S3ClientConfig @params
            $clientObject | Should -Not -Be $null
            [Amazon.S3.AmazonS3Config]$config = $clientObject.Config
            $config.Timeout.TotalMilliseconds | Should -BeExactly 110000
            $config.RegionEndpoint.SystemName | Should -Be "us-west-2"
        }

        It "ClientConfig, explicit Region and EndpointUrl parameters" {
            $params=@{
              ClientConfig=@{
                Timeout=[TimeSpan]::FromMilliseconds(110000)
                RegionEndPoint=([Amazon.RegionEndpoint]::USWest1)
              }
            }

            [Amazon.S3.AmazonS3Client]$clientObject = Test-S3ClientConfig @params -Region us-west-2 -EndpointUrl https://s3.us-east-2.amazonaws.com/
            $clientObject | Should -Not -Be $null
            [Amazon.S3.AmazonS3Config]$config = $clientObject.Config
            $config.ForcePathStyle | Should -BeTrue # ForcePathStyle should be $true if EndpointUrl is specified.
            $config.Timeout.TotalMilliseconds | Should -BeExactly 110000
            $config.RegionEndpoint | Should -Be $null
            $config.ServiceURL | Should -Be "https://s3.us-east-2.amazonaws.com/"
        }
    }
}
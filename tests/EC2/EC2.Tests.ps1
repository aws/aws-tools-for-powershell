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

Describe -Tag "Smoke" "EC2" {

    Context "Images" {

        It "Can get a filtered list of images" {
            $images = Get-EC2Image -Owner amazon -Filter @{Name="platform";Values="windows"},@{Name="architecture";Values="x86_64"}
            $images | Should -Not -Be $null
            $images.Count | Should -BeGreaterThan 0
        }
    }

    Context "DryRun" {

        It "Can validate instance creation permissions with DryRun parameter" {
            $amiId = Get-SSMLatestEC2Image -Path "ami-amazon-linux-latest" -ImageName "al2023-ami-kernel-6.1-x86_64" -Region "us-west-2"
            { New-EC2Instance -ImageId $amiId -InstanceType "t2.micro" -Region "us-west-2" -DryRun $true } | Should -Throw
        }

        It "Can copy an image with DryRun parameter" {
            $amiId = Get-SSMLatestEC2Image "ami-amazon-linux-latest" -ImageName "al2023-ami-kernel-6.1-x86_64" -Region "us-west-2"
            { Copy-EC2Image -SourceRegion "us-west-2" -SourceImageId $amiId -Region "us-west-2" -Name "Copy of image" -DryRun $true} | Should -Throw             
        }

        It "Can create a security group with DryRun parameter" {
            $vpcId = (Get-EC2Vpc | Select-Object -First 1).VpcId
            { New-EC2SecurityGroup -GroupName "TestGroup" -Description "Test Security Group" -VpcId $vpcId -DryRun $true } | Should -Throw            
            { Get-EC2SecurityGroup -GroupName "TestGroup" } | Should -Throw
        }

        It "Can get VPC with DryRun parameter" {
            { Get-EC2Vpc -DryRun $true } | Should -Throw
        }
    }
}


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

Describe -Tag "Smoke" "SSM" {

    Context "Documents" {

        It "Can list and read documents" {
            $docs = Get-SSMDocumentList
            if ($docs) {
                $docs.Count | Should -BeGreaterThan 0

                $doc = Get-SSMDocument -Name $docs[0].Name
                $doc | Should -Not -Be $null
                $doc.Name | Should -Be $docs[0].Name 
            }
        }
    }

    Context "Get-SSMLatestEC2Image" {

        It "Can list Linux images" {
            $results = Get-SSMLatestEC2Image -Path ami-amazon-linux-latest
            $results.Count | Should -BeGreaterThan 1
            $results | ForEach-Object { $_.GetType().FullName | Should -Be 'System.Management.Automation.PSCustomObject' }
            $results.Value | ForEach-Object { $_ -like 'ami-*' | Should -Be $true }
        }

        It "Can list Windows images" {
            $results = Get-SSMLatestEC2Image -Path ami-windows-latest
            $results.Count | Should -BeGreaterThan 1
            $results | ForEach-Object { $_.GetType().FullName | Should -Be 'System.Management.Automation.PSCustomObject' }
            $results.Value | ForEach-Object { $_ -like 'ami-*' | Should -Be $true }
        }

        It "Can match image names exactly" {
            $results = Get-SSMLatestEC2Image -Path ami-amazon-linux-latest -ImageName amzn2-ami-hvm-arm64-gp2
            $results.Count | Should -BeExactly 1
            $results.GetType().FullName | Should -Be 'System.String'
            $results | ForEach-Object { $_ -like 'ami-*' | Should -Be $true }
        }

        It "Can filter image names" {
            $results = Get-SSMLatestEC2Image -Path ami-windows-latest -ImageName *windows*2019*english*
            $results.Count | Should -BeGreaterThan 1
            $results | ForEach-Object { $_.GetType().FullName | Should -Be 'System.Management.Automation.PSCustomObject' }
            $results.Name | ForEach-Object { $_ -like '*Windows*2019*English*' | Should -Be $true }
            $results.Value | ForEach-Object { $_ -like 'ami-*' | Should -Be $true }
        }

        It "Should return different AMIs for different regions" {
            $usEast1Ami = Get-SSMLatestEC2Image -Path ami-amazon-linux-latest -ImageName amzn2-ami-hvm-arm64-gp2 -Region us-east-1
            $usEast1Ami.Count | Should -BeExactly 1
            $usWest2Ami = Get-SSMLatestEC2Image -Path ami-amazon-linux-latest -ImageName amzn2-ami-hvm-arm64-gp2 -Region us-west-2
            $usWest2Ami.Count | Should -BeExactly 1
            $usEast1Ami -eq $usWest2Ami | Should -Be $false
        }
    }
}

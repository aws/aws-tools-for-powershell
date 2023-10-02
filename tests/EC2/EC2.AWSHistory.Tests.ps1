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

Describe -Tag "Smoke" 'EC2 $AWSHistory non-sensitve commands not redacted' {

    Context "Images" {

        It '$AWSHistory non-sensitve command Response is not redacted' {
            $images = Get-EC2Image -Owner amazon -Filter @{Name="platform";Values="windows"},@{Name="architecture";Values="x86_64"}
            $AWSHistory.Commands.ToArray()[-1].CmdletName | Should -Be 'Get-EC2Image'
            $AWSHistory.LastServiceResponse.Images.Count | Should -BeGreaterThan 0
        }
    }
}



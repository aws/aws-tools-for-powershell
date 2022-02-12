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

Describe -Tag "Smoke" "Kinesis" {

    Context "Streams" {

        It "Can list and read streams" {
            $response = Get-KINStreams
            $response | Should -Not -Be $null
            if ($response.StreamNames.Count -gt 0) {
                $stream = Get-KINStream -StreamName $response.StreamNames[0]
                $stream | Should -Not -Be $null

                $stream.StreamName | Should -Be $response.StreamNames[0]
            }
        }
    }
}
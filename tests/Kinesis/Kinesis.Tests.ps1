Describe -Tag "Smoke" "Kinesis" {
    Context "Streams" {

        It "Can list and read streams" {
            $response = Get-KINStreams
            $response | Should Not Be $null
            if ($response.StreamNames.Count -gt 0) {
                $stream = Get-KINStream -StreamName $response.StreamNames[0]
                $stream | Should Not Be $null

                $stream.StreamName | Should Be $response.StreamNames[0]
            }
        }
    }
}
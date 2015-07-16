function Test.KIN.ListStreams
{
    $response = Get-KINStreams
    Assert $response -IsNotNull

    Assert $response.StreamNames.Count -ge 0

    if ($response.StreamNames.Count -gt 0)
    {
        $stream = Get-KINStream -StreamName $response.StreamNames[0]
        Assert $stream -IsNotNull
    }
}
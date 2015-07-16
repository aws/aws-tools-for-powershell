function Test.R53D.CheckDomainAvailability
{
    $response = Get-R53DDomainAvailability -DomainName "amazon.com"
    Assert $response -IsNotNull
    Assert $response.Value -IsNotNull

    # might as well :-)
    Assert $response.Value -eq "UNAVAILABLE"
}

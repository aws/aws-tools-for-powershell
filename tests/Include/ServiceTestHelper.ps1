class ServiceTestHelper : TestHelper
{
    ServiceTestHelper()
    {
    }

    [Void] BeforeAll()
    {
        ([TestHelper]$this).BeforeAll()        
        Set-AWSCredentials -AccessKey $this.AccessKey -SecretKey $this.SecretKey
    }

    [Void] AfterAll()
    {
        ([TestHelper]$this).AfterAll()
    }
}



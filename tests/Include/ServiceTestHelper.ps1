Set-AWSCredential -ProfileName test-runner

class ServiceTestHelper : TestHelper
{
    ServiceTestHelper()
    {
    }

    [Void] BeforeAll()
    {
        ([TestHelper]$this).BeforeAll()        
    }

    [Void] AfterAll()
    {
        ([TestHelper]$this).AfterAll()
    }
}



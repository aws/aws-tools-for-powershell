. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Credentials") "CredentialsTestHelper.ps1")
$helper = New-Object CredentialsTestHelper

# Test temporarily disabled due to changes in the underlying sdk instance profile class
# that affects the mocking
Describe -Tag "Smoke","Disabled" "Get-EC2Instance-Credentials" {

    BeforeAll {
        $helper.BeforeAll()
    }

    AfterAll {
        $helper.AfterAll()
    }

    Context "Get-EC2Instance" {
        BeforeEach {
           $helper.ClearAllCreds()
        }

        AfterEach {
          $helper.ClearAllCreds()
        }

        It "should work with environment variables set" {
            $env:AWS_ACCESS_KEY_ID = $helper.AccessKey
            $env:AWS_SECRET_ACCESS_KEY = $helper.SecretKey
            $env:AWS_REGION = $helper.Region

            $instances = Get-EC2Instance
            $instances.Count | Should BeGreaterThan 0
        }

        It "should work with a default profile in the .net credentials file" {
            $helper.RegisterProfile("default", $helper.AccessKey, $helper.SecretKey, $helper.Region, $null)

            $instances = Get-EC2Instance
            $instances.Count | Should BeGreaterThan 0
        }

        It "should work with a default profile in the shared credentials file" {
            $helper.RegisterProfile("default", $helper.AccessKey, $helper.SecretKey, $helper.Region, $helper.DefaultSharedPath)

            $instances = Get-EC2Instance
            $instances.Count | Should BeGreaterThan 0
        }

        It "should fail with invalid credentials from the shared credentials file in the default location" {

            $helper.RegisterProfile("invalid", "invalidAccessKey", "invalidSecretKey", $helper.Region, $helper.DefaultSharedPath)

            { Get-EC2Instance -ProfileName invalid } | Should Throw "AWS was not able to validate the provided access credentials"
        }

        It "should work with valid credentials from the shared credentials file in the default location" {
            $helper.RegisterProfile("valid", $helper.AccessKey, $helper.SecretKey, $helper.DefaultSharedPath)

            $instances = Get-EC2Instance -ProfileName valid
            $instances.Count | Should BeGreaterThan 0
        }

        It "should fail with invalid credentials from the shared credentials file in a custom location" {
            $helper.RegisterProfile("invalid", "invalidAccessKey", "invalidSecretKey", $helper.CustomSharedPath)

            { Get-EC2Instance -ProfileName invalid -ProfilesLocation $helper.CustomSharedPath } | Should Throw "AWS was not able to validate the provided access credentials"
        }

        It "should work with valid credentials from the shared credentials file in a custom location" {
            $helper.RegisterProfile("valid", $helper.AccessKey, $helper.SecretKey, $helper.CustomSharedPath)

            $instances = Get-EC2Instance -ProfileName valid -ProfilesLocation $helper.CustomSharedPath
            $instances.Count | Should BeGreaterThan 0
        }

        It "should work with basic credentials on the command line" {
            $instances = Get-EC2Instance -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey
            $instances.Count | Should BeGreaterThan 0
        }

        It "should accept session credentials on the command line" {
            { Get-EC2Instance -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey -SessionToken invalid_token } | Should Throw "AWS was not able to validate the provided access credentials"
        }
    }
}

BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()
    $script:iamroleName = "lambdatest-iamrole-" + [DateTime]::Now.ToFileTime()
}

AfterAll {
    $helper.AfterAll()
}

Describe -Tag "Smoke" "Lambda" {

    Context "Functions" {

        BeforeAll {
            # Reference: https://docs.aws.amazon.com/lambda/latest/dg/gettingstarted-awscli.html
            # Arrange: Create IAM role for Lambda function
            $jsLambdaFunctionZip = (Join-Path (Join-Path (Get-Location) "Include") "js-lambda-function.zip")
            $functionRuntime = "provided.al2"
            
            # Create an IAM role to be used when creating Lambda.
            $iamrole = New-IAMRole -RoleName $script:iamroleName -AssumeRolePolicyDocument '{"Version": "2012-10-17","Statement": [{ "Effect": "Allow", "Principal": {"Service": "lambda.amazonaws.com"}, "Action": "sts:AssumeRole"}]}'

            $publishSuccess = $false
            $retryCount = 0
            while ($publishSuccess -eq $false -and $retryCount -lt 5) {
                try {
                    Publish-LMFunction -FunctionName "test-lambda-function-isset" -ZipFilename $jsLambdaFunctionZip -Handler "index.handler" -Runtime $functionRuntime -Role $iamrole.Arn -Environment_Variable @{ EnvVar1 = "EnvVar1_Value"; EnvVar2 = "EnvVar2_Value" }
                    $publishSuccess = $true
                }
                catch [System.InvalidOperationException] {
                    # Might get exception "The role defined for the function cannot be assumed by Lambda."
                    $retryCount += 1
                    Start-Sleep -Seconds 5 # Wait for IAM role to propagate.
                }
            }
            
            # Wait for function creation to complete.
            while ((Get-LMFunctionConfiguration -FunctionName "test-lambda-function-isset").State -eq "Pending") {
                Start-Sleep -Seconds 1
            }
        }
    
        AfterAll {
            # Cleanup
            Remove-LMFunction -FunctionName "test-lambda-function-isset" -Force
            Remove-IAMRole -RoleName $script:iamroleName -Force
        }

        It "Can list and read functions" {
            $fns = Get-LMFunctions
            if ($fns) {
                $fns.Count | Should -BeGreaterThan 0

                $fn = Get-LMFunction -FunctionName $fns[0].FunctionName

                $fn | Should -Not -Be $null
            }
        }

        It "Validate IsSet customization" {
             # Act/Assert: Test the environment variables in function configuration
            (Get-LMFunctionConfiguration -FunctionName "test-lambda-function-isset").Environment.Variables.Count | Should -BeGreaterThan 0

            Update-LMFunctionConfiguration -FunctionName "test-lambda-function-isset" -Description "Test Description"
            # Wait for update function configuration to complete.
            while ((Get-LMFunctionConfiguration -FunctionName "test-lambda-function-isset").LastUpdateStatus -eq "InProgress") {
                Start-Sleep -Seconds 1
            }

            (Get-LMFunctionConfiguration -FunctionName "test-lambda-function-isset").Environment.Variables.Count | Should -BeGreaterThan 0

            Update-LMFunctionConfiguration -FunctionName "test-lambda-function-isset" -Description "Test Description" -Environment_Variable @{}
            # Wait for update function configuration to complete.
            while ((Get-LMFunctionConfiguration -FunctionName "test-lambda-function-isset").LastUpdateStatus -eq "InProgress") {
                Start-Sleep -Seconds 1
            }

            (Get-LMFunctionConfiguration -FunctionName "test-lambda-function-isset").Environment.Variables.Count | Should -BeExactly 0
        }
    }
}

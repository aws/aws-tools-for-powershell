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

Describe -Tag "Smoke" "SQS" {

    Context "Queues" {

        $script:QueueUrl = $null

        It "Can list queues" {
            $queues = Get-SQSQueue
            if ($queues) {
                $queues.Count | Should -BeGreaterThan 0
            }
        }

        It "Can create a queue" {
            $random = New-Object System.Random
            $queueName = "ps-test-" + $random.Next()
            $script:QueueUrl = New-SQSQueue -QueueName $queueName

            $script:QueueUrl | Should -Not -BeNullOrEmpty
        }

        It "Can send and receive" {
            $qu = $script:QueueUrl
            $msg = "testing testing 1 2 3"

            Send-SQSMessage -QueueUrl $qu -MessageBody $msg
            
            $messages = Receive-SQSMessage -QueueUrl $qu
            $messages | Should -Not -Be $null
            $messages.Count | Should -BeGreaterThan 0

            $body = $messages[0].Body
            $body | Should -Be $msg
        }

        It "Can delete a queue" {
            Remove-SQSQueue -QueueUrl $script:QueueUrl -Force
        }
    }
}

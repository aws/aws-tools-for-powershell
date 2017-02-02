. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestIncludes.ps1")
Describe -Tag "Smoke" "SNS" {
    Context "Topics" {

        $script:newTopicArn = $null

        It "Can list topics" {
        	$topics = Get-SNSTopic
            if ($topics) {
                $topics.Count | Should BeGreaterThan 0
            }
        }

        It "Can create a topic" {
            $random = New-Object System.Random
            $topicName = "snsPsTopic" + $random.Next()

            $script:newTopicArn = New-SNSTopic -Name $topicName
            $script:newTopicArn | Should Not BeNullOrEmpty

            $topics = Get-SNSTopic | select -ExpandProperty TopicArn
            $topics -contains $script:newTopicArn | Should Be $true
        }

        It "Can set and read an attribute on the new topic" {
            Set-SNSTopicAttribute -TopicArn $script:newTopicArn -AttributeName DisplayName -AttributeValue SNS_IntegTest_PS
            $attributes = Get-SNSTopicAttribute -TopicArn $script:newTopicArn
            $attributes | Should Not Be $null

            $displayName = $attributes["DisplayName"]
            $displayName | Should Not BeNullOrEmpty
        }

        It "Can delete the new topic" {
            Remove-SNSTopic -TopicArn $script:newTopicArn -Force
        }

        It "No longer sees the new topic" {
            $topics = Get-SNSTopic | select -ExpandProperty TopicArn
            $topics -contains $script:newTopicArn | Should Be $false
        }
    }
}

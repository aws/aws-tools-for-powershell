ForEach ($revision in (Get-CDApplicationRevisionList -ApplicationName CodeDeployDemoApplication -Deployed Ignore)) {
>>   If ($revision.RevisionType -Eq "S3") {
>>     Write-Output ("Type = S3, Bucket = " + $revision.S3Location.Bucket + ", BundleType = " + $revision.S3Location.BundleType + ", ETag = " + $revision.S3Location.ETag + ", Key = " + $revision.S3Location.Key)
>>   }
>>   If ($revision.RevisionType -Eq "GitHub") {
>>     Write-Output ("Type = GitHub, CommitId = " + $revision.GitHubLocation.CommitId + ", Repository = " + $revision.GitHubLocation.Repository)
>>   }
>> }
>>
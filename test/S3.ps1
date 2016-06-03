Function Test.S3.ListBuckets([switch] $Category_Smoke)
{
    $buckets = Get-S3Bucket
    if ($buckets -ne $null)
    {
        Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
    }
}

Function Init.S3.Buckets()
{
	$context.BucketNamePrefix = "PSTest-"
    $context.BucketName = $context.BucketNamePrefix + [DateTime]::Now.ToFileTime()
}
Function Test.S3.Buckets([switch] $Category_Smoke)
{
    New-S3Bucket -BucketName $context.BucketName
    
    $exists = Test-S3Bucket $context.BucketName
    Assert $exists -eq $True

    Remove-S3Bucket -BucketName $context.BucketName -force

	# continual eventual consistency issues with testing bucket no longer exists,
	# (even after various sleeps) so stopped verifying
	#sleep -Seconds 5

    #$exists = Test-S3Bucket $context.BucketName
    #Assert $exists -eq $False
}
Function Term.S3.Buckets()
{
}

Function Init.S3.Pipelines()
{
    $context.BucketName = "PSTest-" + [DateTime]::Now.ToFileTime()
}
Function Test.S3.Pipelines([switch] $Category_Smoke)
{
    # test pipe into Remove-S3Bucket
    $b = New-S3Bucket $context.BucketName
    $b | Remove-S3Bucket -force

	sleep -Seconds 5
	
    $exists = Test-S3Bucket $context.BucketName
    Assert $exists -eq $False
}
Function Term.S3.Pipelines()
{
}

#Function Init.S3.Iteration()
#{
#    $context.ItemCount = 1053
#    $context.BucketName = "PSTest-" + [DateTime]::Now.ToFileTime()
#    $b = New-S3Bucket $context.BucketName
#
#    foreach ($i in 1..$context.ItemCount) 
#    { 
#        write-s3object $context.BucketName -key $i -content "test" 
#    }
#}
#Function Test.S3.Iteration()
#{
#    write-host "--- test no-paging params gets all $context.ItemCount keys"
#    $allKeys = get-s3object $context.BucketName 
#    Assert $allKeys.Count -eq $context.ItemCount
#
#    write-host "--- test we can get the first 'n' records and next-page markers are set"
#    $keysToGet = 63
#    $subsetKeys  = get-s3object $context.BucketName -MaxKeys $keysToGet
#    Assert $subsetKeys.Count -eq $keysToGet
#    Assert $awshistory.LastServiceResponse.IsTruncated -eq $true
#    Assert $awshistory.LastServiceResponse.NextMarker -ne ''
#
#    write-host "--- test we can get the next 'm' records and next-marker is updated"
#    $oldNextMarker = $awshistory.LastServiceResponse.NextMarker
#    $keysToGet = 47
#    $subsetKeys2  = get-s3object $context.BucketName -MaxKeys $keysToGet
#    Assert $subsetKeys2.Count -eq $keysToGet
#    Assert $awshistory.LastServiceResponse.IsTruncated -eq $true
#    Assert $awshistory.LastServiceResponse.NextMarker -ne ''
#    Assert $awshistory.LastServiceResponse.NextMarker -ne $oldNextMarker
#
#    write-host "--- test we can get 'm' records and subsequent page using parameter aliases"
#    $keysToGet = 10
#    $subsetKeys3  = get-s3object $context.BucketName -MaxItems $keysToGet
#    Assert $subsetKeys3.Count -eq $keysToGet
#    Assert $awshistory.LastServiceResponse.NextMarker -ne ''
#    $subsetKeys4  = get-s3object $context.BucketName -MaxItems $keysToGet -NextToken $awshistory.LastServiceResponse.NextMarker
#    Assert $subsetKeys4.Count -eq $keysToGet
#}
#Function Term.S3.Iteration()
#{
#    Remove-S3Bucket -BucketName $context.BucketName -deleteobjects -force
#}

Function Init.S3.WriteObject()
{
    $context.BucketName = "PSTest-" + [DateTime]::Now.ToFileTime()
    $b = New-S3Bucket $context.BucketName
}
Function Test.S3.WriteObject([switch] $Category_Smoke)
{
	Write-S3Object -BucketName $context.BucketName -Key foo.txt -Content "this is a test" -ServerSideEncryption AES256
	Write-S3Object -BucketName $context.BucketName -Key foo.txt -Content "this is a test" -ServerSideEncryption Aes256
	Write-S3Object -BucketName $context.BucketName -Key foo.txt -Content "this is a test" -ServerSideEncryption None
	Write-S3Object -BucketName $context.BucketName -Key foo.txt -Content "this is a test" -ServerSideEncryption NoNe
	Write-S3Object -BucketName $context.BucketName -Key foo.txt -Stream (New-Object IO.MemoryStream)
	Write-S3Object -BucketName $context.BucketName -Key foo.txt -Stream (New-Object IO.MemoryStream(,[Text.Encoding]::UTF8.GetBytes("this is a test")))

	try
	{
		Write-S3Object -BucketName $context.BucketName -Key foo.txt -Content "this is a test" -ServerSideEncryption Naan
		$thrown = $false
	}
	catch
	{
		$thrown = $true
	}
	
	if (-not $thrown)
	{
		throw "Exception should have been thrown"
	}
}
Function Term.S3.WriteObject()
{
    Remove-S3Bucket -BucketName $context.BucketName -deleteobjects -force
}

Function Init.S3.ProgressOps()
{
    $context.BucketName = "PSTest-" + [DateTime]::Now.ToFileTime()
    $b = New-S3Bucket $context.BucketName
   
    $void = New-Item -Path temp\bar -Type directory -Force
    $void = New-Item -Path temp\bar\baz -Type directory -Force
	
    "sample text" | Out-File -FilePath ".\temp\bar\test.txt" -Force
    "more sample text" | Out-File -FilePath ".\temp\bar\test2.txt" -Force
    "another file" | Out-File -FilePath ".\temp\bar\baz\blah.txt" -Force
    "basic file" | Out-File -FilePath "temp\basic.txt" -Force
}
Function Test.S3.ProgressOps([switch] $Category_Smoke)
{
    $bucket = $context.BucketName

    Write-S3Object -BucketName $bucket -KeyPrefix bar2\ -Folder .\temp\bar -Recurse
    Write-S3Object -BucketName $bucket -Key bar2\foo.txt -Content "foo"
    Write-S3Object -BucketName $bucket -Key basic.txt -File "temp\basic.txt"

    Read-S3Object -BucketName $bucket -KeyPrefix bar2\ -Folder temp\new-bar

    Assert ((Get-Content ".\temp\new-bar\foo.txt").Length) -ne 0
    Assert ((Get-Content ".\temp\new-bar\test.txt").Length) -ne 0
    Assert ((Get-Content ".\temp\new-bar\test2.txt").Length) -ne 0
    Assert ((Get-Content ".\temp\new-bar\baz\blah.txt").Length) -ne 0

    Copy-S3Object -BucketName $bucket -Key "basic.txt" -LocalFile "$pwd\temp\blah.blah"
    Assert ((Get-Content "$pwd\temp\blah.blah").Length) -ne 0

    Read-S3Object -BucketName $bucket -Key "basic.txt" -File "temp\basic2.txt"
    Assert ((Get-Content "temp\basic2.txt").Length) -ne 0
}
Function Term.S3.ProgressOps()
{
    Remove-S3Bucket -BucketName $context.BucketName -deleteobjects -force
}

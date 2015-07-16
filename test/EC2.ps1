function Test.EC2.DescribeImages
{
    # use filters to cut down the time to run - this gives 221 images at time of writing
    $images = Get-EC2Image -Owner amazon -Filter @{Name="platform";Value="windows"},@{Name="architecture";Value="x86_64"}

    Assert $images -IsNotNull
    Assert $images.Count -eq $awshistory.LastCommand.EmittedObjectsCount
}

function Test.EC2.QueryImageByName
{
    $imageKeys = Get-EC2ImageByName
    Assert $imageKeys -IsNotNull
    Assert $imageKeys.Count -gt 0

    $image = Get-EC2ImageByName windows_2012r2_base
    Assert $image -IsNotNull
    Assert $image.ImageId -IsNotNull
    Assert $image.ImageId.Length -gt 0
}

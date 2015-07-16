function Test.KMS.ListKeys
{
    $keys = Get-KMSKeys
    if ($keys)
    {
        Assert $keys.Count -ge 0
        Assert $keys.Count -eq $awshistory.LastCommand.EmittedObjectsCount

        if ($keys.Count -gt 0)
        {
            if ($keys.Count -eq 1)
            {
                $key = Get-KMSKey -KeyId $keys.KeyId
            }
            else
            {
                $key = Get-KMSKey -KeyId $keys[0].KeyId
            }

            Assert $key -IsNotNull
        }
    }
}
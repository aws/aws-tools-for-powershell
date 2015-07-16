function Test.SSM.ListDocuments
{
    $docs = Get-SSMDocumentList
    if ($docs)
    {
        Assert $docs.Count -ge 0
        Assert $docs.Count -eq $awshistory.LastCommand.EmittedObjectsCount

        if ($docs.Count -gt 0)
        {
            if ($docs.Count -eq 1)
            {
                $doc = Get-SSMDocument -Name $docs.Name
            }
            else
            {
                $doc = Get-SSMDocument -Name $docs[0].Name
            }

            Assert $doc -IsNotNull
        }
    }
}

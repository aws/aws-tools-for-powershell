function Test.OPS.DescribeStacks
{
    $stacks = Get-OPSStacks
    if ($stacks)
    {
        Assert $stacks.Count -ge 0
        Assert $stacks.Count -eq $awshistory.LastCommand.EmittedObjectsCount

        if ($stacks.Count -gt 0)
        {
            if ($stacks.Count -eq 1)
            {
                $stackSummary = Get-OPSStackSummary -StackId $stacks.StackId
            }
            else
            {
                $stackSummary = Get-OPSStackSummary -StackId $stacks[0].StackId
            }

            Assert $stackSummary -IsNotNull
        }
    }
}

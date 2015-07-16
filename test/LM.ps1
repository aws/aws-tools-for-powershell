function Test.LM.ListFunctions
{
    $fns = Get-LMFunctions
    if ($fns)
    {
        Assert $fns.Count -ge 0
        Assert $fns.Count -eq $awshistory.LastCommand.EmittedObjectsCount

        if ($fns.Count -gt 0)
        {
            if ($fns.Count -eq 1)
            {
                $fn = Get-LMFunction -FunctionName $fns.FunctionName    
            }
            else
            {
                $fn = Get-LMFunction -FunctionName $fns[0].FunctionName    
            }

            Assert $fn -IsNotNull
        }
    }
}

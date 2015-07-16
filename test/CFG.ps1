function Test.CFG
{
    $recorders = Get-CFGConfigurationRecorders
    if ($recorders)
    {
        Assert $recorders.Count -ge 0
        if ($recorders.Count -gt 0)
        {
		    Assert $awshistory.LastCommand.EmittedObjectsCount -eq $recorders.Count

            if ($recorders.Count -eq 1)
            {
                $recorderName = $recorders.Name
            }
            else
            {
                $recorderName = $recorders[0].Name
            }

            $recorder = Get-CFGConfigurationRecorderStatus -ConfigurationRecorderName $recorderName
            
            Assert $recorder -IsNotNull 
        }
    }
}

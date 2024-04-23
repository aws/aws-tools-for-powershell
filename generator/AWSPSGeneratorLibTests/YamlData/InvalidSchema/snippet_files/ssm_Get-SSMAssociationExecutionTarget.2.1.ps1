$AssociationExecution= Get-SSMAssociationExecutionTarget -AssociationId 1c234567-890f-1aca-a234-5a678d901cb0 -ExecutionId 12345ca12-3456-2345-2b45-23456789012 | 
    Where-Object {$_.LastExecutionDate -gt (Get-Date -Hour 00 -Minute 00).AddDays(-1)} 

foreach ($execution in $AssociationExecution) {
    if($execution.Status -ne 'Success'){
        Write-Output "There was an issue executing the association $($execution.AssociationId) on $($execution.ResourceId)"
        Get-SSMCommandInvocation -CommandId $execution.OutputSource.OutputSourceId -Detail:$true | Select-Object -ExpandProperty CommandPlugins
    }
}
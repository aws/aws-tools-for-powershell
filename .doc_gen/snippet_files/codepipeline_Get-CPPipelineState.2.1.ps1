ForEach ($stageState in (Get-CPPipelineState -Name $arg).StageStates) {
  Write-Output ("For " + $stageState.StageName + ":")
  Write-Output ("  InboundTransitionState:")
  Write-Output ("    DisabledReason = " + $stageState.InboundTransitionState.DisabledReason)
  Write-Output ("    Enabled = " + $stageState.InboundTransitionState.Enabled)
  Write-Output ("    LastChangedAt = " + $stageState.InboundTransitionState.LastChangedAt)
  Write-Output ("    LastChangedBy = " + $stageState.InboundTransitionState.LastChangedBy)
  Write-Output ("  ActionStates:")
  ForEach ($actionState in $stageState.ActionStates) {
    Write-Output ("    For " + $actionState.ActionName + ":")
	Write-Output ("      CurrentRevision:")
    Write-Output ("        Created = " + $actionState.CurrentRevision.Created)
	Write-Output ("        RevisionChangeId = " + $actionState.CurrentRevision.RevisionChangeId)
	Write-Output ("        RevisionId = " + $actionState.CurrentRevision.RevisionId)
	Write-Output ("      EntityUrl = " + $actionState.EntityUrl)
	Write-Output ("      LatestExecution:")
    Write-Output ("        ErrorDetails:")
    Write-Output ("          Code = " + $actionState.LatestExecution.ErrorDetails.Code)
	Write-Output ("          Message = " + $actionState.LatestExecution.ErrorDetails.Message)
	Write-Output ("        ExternalExecutionId = " + $actionState.LatestExecution.ExternalExecutionId)
	Write-Output ("        ExternalExecutionUrl = " + $actionState.LatestExecution.ExternalExecutionUrl)
	Write-Output ("        LastStatusChange	= " + $actionState.LatestExecution.LastStatusChange)
	Write-Output ("        PercentComplete = " + $actionState.LatestExecution.PercentComplete)
	Write-Output ("        Status = " + $actionState.LatestExecution.Status)
	Write-Output ("        Summary = " + $actionState.LatestExecution.Summary)
	Write-Output ("      RevisionUrl = " + $actionState.RevisionUrl)
  }
}
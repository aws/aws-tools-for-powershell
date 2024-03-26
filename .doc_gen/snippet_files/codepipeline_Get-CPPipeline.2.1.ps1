$pipeline = Get-CPPipeline -Name CodePipelineDemo
Write-Output ("Name = " + $pipeline.Name)
Write-Output ("RoleArn = " + $pipeline.RoleArn)
Write-Output ("Version = " + $pipeline.Version)
Write-Output ("ArtifactStore:")
Write-Output ("  Location = " + $pipeline.ArtifactStore.Location)
Write-Output ("  Type = " + $pipeline.ArtifactStore.Type.Value)
Write-Output ("Stages:")
ForEach ($stage in $pipeline.Stages) {
  Write-Output ("  Name = " + $stage.Name)
  Write-Output ("    Actions:")
  ForEach ($action in $stage.Actions) {
    Write-Output ("      Name = " + $action.Name)
	Write-Output ("        Category = " + $action.ActionTypeId.Category)
	Write-Output ("        Owner = " + $action.ActionTypeId.Owner)
	Write-Output ("        Provider = " + $action.ActionTypeId.Provider)
	Write-Output ("        Version = " + $action.ActionTypeId.Version)
	Write-Output ("        Configuration:")
	ForEach ($key in $action.Configuration.Keys) {
	  $value = $action.Configuration.$key
	  Write-Output ("          " + $key + " = " + $value)
	}
	Write-Output ("        InputArtifacts:")
	ForEach ($ia in $action.InputArtifacts) {
	  Write-Output ("          " + $ia.Name)
	}
	ForEach ($oa in $action.OutputArtifacts) {
	  Write-Output ("          " + $oa.Name)
	}
	Write-Output ("        RunOrder = " + $action.RunOrder)
  }
}
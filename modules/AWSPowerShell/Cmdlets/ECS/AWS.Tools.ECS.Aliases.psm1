# ECS
Set-Alias -Name Get-ECSClusters -Value Get-ECSClusterList
Set-Alias -Name Get-ECSContainerInstances -Value Get-ECSContainerInstanceList
Set-Alias -Name Get-ECSTaskDefinitionFamilies -Value Get-ECSTaskDefinitionFamilyList
Set-Alias -Name Get-ECSTaskDefinitions -Value Get-ECSTaskDefinitionList
Set-Alias -Name Get-ECSTasks -Value Get-ECSTaskList

Export-ModuleMember -Alias *
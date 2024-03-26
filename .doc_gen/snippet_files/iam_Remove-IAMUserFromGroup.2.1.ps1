$groups = Get-IAMGroupForUser -UserName Theresa 
foreach ($group in $groups) { Remove-IAMUserFromGroup -GroupName $group.GroupName -UserName Theresa -Force }
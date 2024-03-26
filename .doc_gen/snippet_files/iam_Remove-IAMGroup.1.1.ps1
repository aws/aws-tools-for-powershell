(Get-IAMGroup -GroupName MyTestGroup).Users | Remove-IAMUserFromGroup -GroupName MyTestGroup -Force
Remove-IAMGroup -GroupName MyTestGroup -Force
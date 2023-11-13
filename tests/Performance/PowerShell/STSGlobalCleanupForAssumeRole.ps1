param($RoleName)
#Create Role that can be assumed as part of Performance Tests
Import-Module 'AWS.Tools.Common','AWS.Tools.SecurityToken', 'AWS.Tools.IdentityManagement'
Remove-IAMRole -RoleName $RoleName -Force
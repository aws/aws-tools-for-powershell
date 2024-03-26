Get-IAMAttachedRolePolicyList -RoleName MyNewRole | Unregister-IAMRolePolicy -RoleName MyNewRole
Remove-IAMRole -RoleName MyNewRole
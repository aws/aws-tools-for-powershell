$params = @{
    "PrincipalARN"="arn:aws:iam::012345678912:saml-provider/ADFS"
    "RoleARN"="arn:aws:iam::012345678912:role/ADFS-Dev"
}
Set-AWSSamlRoleProfile @params -StoreAs ADFS-Dev
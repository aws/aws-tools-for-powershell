# Framework tests

Function Test.DoNothing([switch] $Category_Smoke)
{
	Assert -Actual $context.Foo -Eq 4
	$context.Foo++
}
Function Init.DoNothing()
{
	$context.Foo = 4
}
Function Term.DoNothing()
{
	Assert -Actual $context.Foo -Eq 5
}
Function Test.Asserts()
{
	Assert 5 -Gt 4
	Assert 5 -Lt 6
	Assert 5 -IsNotNull
}


. .\General.ps1
. .\CommonCmdlets.ps1
. .\CFN.ps1
. .\CS.ps1
. .\CF.ps1
. .\CT.ps1
. .\CW.ps1
. .\DC.ps1
# . .\DDB.ps1
# . .\DP.ps1
. .\EB.ps1
. .\EC.ps1
. .\ELB.ps1
. .\EMR.ps1
. .\IAM.ps1
. .\R53.ps1
. .\RS.ps1
. .\S3.ps1
. .\SES.ps1
. .\SNS.ps1
. .\SQS.ps1
. .\StorageGateway.ps1

# provider removed currently
#. .\Providers.ps1

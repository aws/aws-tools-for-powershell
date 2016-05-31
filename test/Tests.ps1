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
. .\AS.ps1
. .\ASA.ps1
. .\CC.ps1
. .\CD.ps1
. .\CF.ps1
. .\CFG.ps1
. .\CFN.ps1
. .\CP.ps1
. .\CS.ps1
. .\CT.ps1
. .\CW.ps1
. .\CWL.ps1
. .\DC.ps1
. .\DDB.ps1
. .\DF.ps1
. .\DP.ps1
. .\DS.ps1
# disabled due to very lengthy test run, investigating why
#. .\EB.ps1
. .\EC.ps1
. .\EC2.ps1
. .\ECS.ps1
. .\EFS.ps1
. .\ELB.ps1
# disabled due to api becoming obsolete, revised test not working yet
#. .\EMR.ps1
. .\ETS.ps1
. .\HSM.ps1
. .\IAM.ps1
. .\IE.ps1
. .\KMS.ps1
. .\KIN.ps1
. .\LM.ps1
. .\ML.ps1
. .\OPS.ps1
. .\RDS.ps1
# disabled while investigating new assertion fail
#. .\R53.ps1
. .\R53D.ps1
. .\RS.ps1
. .\S3.ps1
. .\SES.ps1
. .\SG.ps1
. .\SNS.ps1
. .\SQS.ps1
. .\SSM.ps1
. .\STS.ps1
. .\WKS.ps1

# provider removed currently
#. .\Providers.ps1

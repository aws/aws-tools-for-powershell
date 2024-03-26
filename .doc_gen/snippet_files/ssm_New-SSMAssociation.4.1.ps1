$params = [Collections.Generic.Dictionary[String,Collections.Generic.List[String]]]::new()
$params["windowsRegistry"] ='[{"Path":"HKEY_LOCAL_MACHINE\SOFTWARE\Amazon\MachineImage","Recursive":false,"ValueNames":["AMIName"]}]'
$params["files"] = '[{"Path":"C:\Program Files","Pattern":["*.exe"],"Recursive":true}, {"Path":"C:\ProgramData","Pattern":["*.log"],"Recursive":true}]' 
New-SSMAssociation -AssociationName new-in-mum -Name AWS-GatherSoftwareInventory -Target @{Key="instanceids";Values="*"} -Parameter $params -region ap-south-1 -ScheduleExpression "rate(720 minutes)"
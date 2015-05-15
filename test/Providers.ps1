function Test.Providers
{
	$garbage = New-PSDrive aws -PSProvider AmazonWebServices -Root \ #-Credentials $creds -Region ap-southeast-1
	$items = ls aws:\
	Assert $items.Count -Eq 6
	$item1 = $items[0].Name
	Assert "$item1" -Eq "Beanstalk"
}
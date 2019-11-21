$AWS_EC2ImageByNameCompleter = {
	param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

	$keys = [Amazon.EC2.Util.ImageUtilities]::ImageKeys

	$keys |
	Sort-Object -Descending |
	Where-Object { $_ -like "$wordToComplete*" } |
	ForEach-Object {
		New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_
	}
}

_awsArgumentCompleterRegistration $AWS_EC2ImageByNameCompleter @{ "Name"=@("Get-EC2ImageByName") }

# The attribute name parameter for EC2 apis such as ModifyImageAttribute is modeled as a string
# in the service model rather than an enum type, which means by default we cannot auto-generate
# an argument completer. Api's use as DescribeImageAttribute do use an enum type (ImageAttributeName)
# and so don't have this problem.
$AWS_EC2ImageAttributeCompleter = {
	param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Taken from Amazon.EC2.ImageAttributeName
        "Edit-EC2ImageAttribute/Attribute"
        {
            $v = "description","kernel","ramdisk","launchPermission","productCodes","blockDeviceMapping","sriovNetSupport"
            break
        }
    }

    $v |
    Where-Object { $_ -like "$wordToComplete*" } |
    ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

_awsArgumentCompleterRegistration $AWS_EC2ImageAttributeCompleter @{ "Attribute"=@("Edit-EC2ImageAttribute") }
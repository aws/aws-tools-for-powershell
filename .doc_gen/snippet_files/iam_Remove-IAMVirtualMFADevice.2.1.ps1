$mfa = Get-IAMMFADevice -UserName Theresa
if ($mfa) { 
    Disable-IAMMFADevice -SerialNumber $mfa.SerialNumber -UserName $name 
    if ($mfa.SerialNumber -like "arn:*") { Remove-IAMVirtualMFADevice -SerialNumber $mfa.SerialNumber }
}
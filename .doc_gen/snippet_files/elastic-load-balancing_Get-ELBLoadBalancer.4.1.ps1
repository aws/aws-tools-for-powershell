Get-AWSRegion | % { Get-ELBLoadBalancer -Region $_ }
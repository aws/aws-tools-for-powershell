$start = (Get-Date).AddHours(24)
$params = @{
	"ResourceUri"="http://xyz.cloudfront.net/content/*.jpeg"
	"KeyPairId"="AKIAIOSFODNN7EXAMPLE"
	"PrivateKeyFile"="C:\pk-AKIAIOSFODNN7EXAMPLE.pem"
	"ExpiresOn"=$start.AddDays(7)
    "ActiveFrom"=$start
	"IpRange"="192.0.2.0/24"
}

New-CFSignedCookie @params
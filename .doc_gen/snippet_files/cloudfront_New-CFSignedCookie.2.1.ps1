$start = (Get-Date).AddHours(24)
$params = @{
	"ResourceUri"="http://xyz.cloudfront.net/content/*.jpeg"
	"KeyPairId"="AKIAIOSFODNN7EXAMPLE"
	"PrivateKeyFile"="C:\pk-AKIAIOSFODNN7EXAMPLE.pem"
	"ExpiresOn"=$start.AddDays(7)
    "ActiveFrom"=$start
}

New-CFSignedCookie @params
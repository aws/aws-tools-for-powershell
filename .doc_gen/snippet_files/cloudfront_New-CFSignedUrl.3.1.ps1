$start = (Get-Date).AddHours(24)
$params = @{
	"ResourceUri"="https://cdn.example.com/index.html"
	"KeyPairId"="AKIAIOSFODNN7EXAMPLE"
	"PrivateKeyFile"="C:\pk-AKIAIOSFODNN7EXAMPLE.pem"
	"ExpiresOn"=(Get-Date).AddDays(7)
    "ActiveFrom"=$start
    "IpRange"="192.0.2.0/24"	
}
New-CFSignedUrl @params
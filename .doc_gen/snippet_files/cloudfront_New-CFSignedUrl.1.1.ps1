$params = @{
	"ResourceUri"="https://cdn.example.com/index.html"
	"KeyPairId"="AKIAIOSFODNN7EXAMPLE"
	"PrivateKeyFile"="C:\pk-AKIAIOSFODNN7EXAMPLE.pem"
	"ExpiresOn"=(Get-Date).AddHours(1)
}
New-CFSignedUrl @params
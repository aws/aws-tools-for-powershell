$params = @{
	"ResourceUri"="http://xyz.cloudfront.net/image1.jpeg"
	"KeyPairId"="AKIAIOSFODNN7EXAMPLE"
	"PrivateKeyFile"="C:\pk-AKIAIOSFODNN7EXAMPLE.pem"
	"ExpiresOn"=(Get-Date).AddYears(1)
}
New-CFSignedCookie @params
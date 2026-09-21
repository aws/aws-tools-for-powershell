BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")

    # Static test credentials; the signing cmdlets never call AWS.
    $script:signingArgs = @{
        AccessKey    = "AKIDEXAMPLE"
        SecretKey    = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY"
        SessionToken = "SESSIONTOKENEXAMPLE"
        Region       = "us-west-2"
        Service      = "execute-api"
    }
    $script:apiUri = "https://abc123.execute-api.us-west-2.amazonaws.com/prod/items?b=2&a=1"
}

AfterAll {

}

Describe -Tag "Smoke" "Common.SigV4Signer" {
    Context "Get-AWSSigV4Signature" {
        It "Returns the SigV4 headers for a GET request" {
            $headers = Get-AWSSigV4Signature -Uri $script:apiUri @script:signingArgs

            $headers | Should -Not -BeNullOrEmpty
            $headers["Authorization"] | Should -Match "^AWS4-HMAC-SHA256 Credential=AKIDEXAMPLE/\d{8}/us-west-2/execute-api/aws4_request, SignedHeaders=host;x-amz-content-sha256;x-amz-date;x-amz-security-token, Signature=[0-9a-f]{64}$"
            $headers["X-Amz-Date"] | Should -Match "^\d{8}T\d{6}Z$"
            $headers["X-Amz-Security-Token"] | Should -BeExactly "SESSIONTOKENEXAMPLE"
            # SHA-256 of an empty payload
            $headers["X-Amz-Content-SHA256"] | Should -BeExactly "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855"
        }

        It "Header lookup is case-insensitive" {
            $headers = Get-AWSSigV4Signature -Uri $script:apiUri @script:signingArgs

            $headers["authorization"] | Should -BeExactly $headers["Authorization"]
        }

        It "Omits the security token header for long-term credentials" {
            $args = $script:signingArgs.Clone()
            $args.Remove("SessionToken")
            $headers = Get-AWSSigV4Signature -Uri $script:apiUri @args

            $headers.ContainsKey("X-Amz-Security-Token") | Should -BeFalse
            $headers["Authorization"] | Should -Match "SignedHeaders=host;x-amz-content-sha256;x-amz-date,"
        }

        It "Hashes a string body and signs additional headers" {
            $body = '{"foo":"bar"}'
            $expectedHash = "7a38bf81f383f69433ad6e900d35b3e2385593f76a7b7ab5d4355b8ba41ee24b"
            $headers = Get-AWSSigV4Signature -Uri $script:apiUri -Method post -Body $body -Header @{ "Content-Type" = "application/json" } @script:signingArgs

            $headers["X-Amz-Content-SHA256"] | Should -BeExactly $expectedHash
            $headers["Authorization"] | Should -Match "SignedHeaders=content-type;host;x-amz-content-sha256;x-amz-date;x-amz-security-token,"
        }

        It "Hashes a byte array body" {
            $bytes = [System.Text.Encoding]::UTF8.GetBytes('{"foo":"bar"}')
            $headers = Get-AWSSigV4Signature -Uri $script:apiUri -Method PUT -Body $bytes @script:signingArgs

            $headers["X-Amz-Content-SHA256"] | Should -BeExactly "7a38bf81f383f69433ad6e900d35b3e2385593f76a7b7ab5d4355b8ba41ee24b"
        }

        It "Hashes a stream body" {
            $stream = [System.IO.MemoryStream]::new([System.Text.Encoding]::UTF8.GetBytes('{"foo":"bar"}'))
            try {
                $headers = Get-AWSSigV4Signature -Uri $script:apiUri -Method PUT -Body $stream @script:signingArgs
                $headers["X-Amz-Content-SHA256"] | Should -BeExactly "7a38bf81f383f69433ad6e900d35b3e2385593f76a7b7ab5d4355b8ba41ee24b"
            }
            finally {
                $stream.Dispose()
            }
        }

        It "Supports unsigned payloads" {
            $headers = Get-AWSSigV4Signature -Uri $script:apiUri -Method PUT -Body "payload" -UnsignedPayload @script:signingArgs

            $headers["X-Amz-Content-SHA256"] | Should -BeExactly "UNSIGNED-PAYLOAD"
        }

        It "Honors a precomputed x-amz-content-sha256 header" {
            $precomputed = "0000000000000000000000000000000000000000000000000000000000000000"
            $headers = Get-AWSSigV4Signature -Uri $script:apiUri -Method PUT -Header @{ "x-amz-content-sha256" = $precomputed } @script:signingArgs

            $headers["X-Amz-Content-SHA256"] | Should -BeExactly $precomputed
        }

        It "Rejects unsigned payloads over plain HTTP" {
            { Get-AWSSigV4Signature -Uri "http://abc123.execute-api.us-west-2.amazonaws.com/prod" -UnsignedPayload @script:signingArgs } | Should -Throw "*HTTPS*"
        }

        It "Rejects unsupported body types" {
            { Get-AWSSigV4Signature -Uri $script:apiUri -Method POST -Body @{ foo = "bar" } @script:signingArgs } | Should -Throw "*Body must be a string*"
        }

        It "Rejects an empty method" {
            { Get-AWSSigV4Signature -Uri $script:apiUri -Method "" @script:signingArgs } | Should -Throw "*Method must be specified*"
        }
    }

    Context "Get-AWSSigV4PreSignedURL" {
        It "Returns a pre-signed URL carrying the signature in the query string" {
            $url = Get-AWSSigV4PreSignedURL -Uri "https://amzn-s3-demo-bucket.s3.us-west-2.amazonaws.com/my key.txt" -Service s3 -Expire (Get-Date).AddHours(1) -AccessKey $script:signingArgs.AccessKey -SecretKey $script:signingArgs.SecretKey -Region us-west-2

            $url | Should -BeOfType [System.String]
            $url | Should -Match "^https://amzn-s3-demo-bucket\.s3\.us-west-2\.amazonaws\.com/my%20key\.txt\?"
            $url | Should -Match "X-Amz-Algorithm=AWS4-HMAC-SHA256"
            $url | Should -Match "X-Amz-Credential=AKIDEXAMPLE%2F\d{8}%2Fus-west-2%2Fs3%2Faws4_request"
            $url | Should -Match "X-Amz-Expires=3600"
            $url | Should -Match "X-Amz-SignedHeaders=host"
            $url | Should -Match "X-Amz-Signature=[0-9a-f]{64}"
            $url | Should -Not -Match "X-Amz-Security-Token"
        }

        It "Includes the session token for temporary credentials" {
            $url = Get-AWSSigV4PreSignedURL -Uri "https://abc123.execute-api.us-west-2.amazonaws.com/prod/items" -Expire (Get-Date).AddMinutes(5) @script:signingArgs

            $url | Should -Match "X-Amz-Security-Token=SESSIONTOKENEXAMPLE"
            $url | Should -Match "X-Amz-Expires=300"
        }

        It "Warns about additional signed headers" {
            $url = Get-AWSSigV4PreSignedURL -Uri "https://abc123.execute-api.us-west-2.amazonaws.com/prod/items" -Header @{ "x-custom" = "1" } -Expire (Get-Date).AddMinutes(5) -WarningVariable warnings -WarningAction SilentlyContinue @script:signingArgs

            $url | Should -Match "X-Amz-SignedHeaders=host%3Bx-custom"
            $warnings | Should -Not -BeNullOrEmpty
            "$warnings" | Should -Match "x-custom"
        }

        It "Rejects expirations beyond seven days" {
            { Get-AWSSigV4PreSignedURL -Uri "https://abc123.execute-api.us-west-2.amazonaws.com/prod" -Expire (Get-Date).AddDays(8) @script:signingArgs } | Should -Throw "*7 days*"
        }

        It "Rejects expirations in the past" {
            { Get-AWSSigV4PreSignedURL -Uri "https://abc123.execute-api.us-west-2.amazonaws.com/prod" -Expire (Get-Date).AddMinutes(-1) @script:signingArgs } | Should -Throw "*at least 1 second*"
        }
    }
}

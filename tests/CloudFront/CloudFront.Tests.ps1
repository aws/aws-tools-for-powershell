BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()
}

AfterAll {
    $helper.AfterAll()
}

Describe -Tag "Smoke" "CloudFront" {

	Context "Distributions" {

		It "Can list distributions" {
			$distributions = Get-CFDistributions
			if ($distributions)
			{
				$distributions.Count | Should -BeGreaterThan 0
			}
		}

	    It "Can read distributions" {
			$distribution = Get-CFDistributions

			if ($distributions) {
				foreach ($dist in $distributions.Items) {
					$distribution = Get-CFDistribution -Id $dist.Id

					$distribution | Should -Not -Be $null
				}
			}
	    }
	}

	Context "Invalidations" {
		It "Can read invalidations" {
			$distributions = Get-CFDistributions

			if ($distributions) {
				foreach ($dist in $distributions.Items) {
					$invalidations = Get-CFInvalidations -DistributionId $dist.Id

					$invalidations | Should -Not -Be $null
				}
			}
		}
	}
}

Describe "CloudFront signing input validation" {

	# Regression coverage for the CloudFront signing path-normalization bypass.
	# ResourceUri is a [System.Uri], but the cmdlets sign the caller's original text
	# (Uri.OriginalString) rather than the normalized Uri.ToString(), so System.Uri
	# canonicalization (backslash to forward slash, dot-segment resolution,
	# percent-decoding) can no longer change the resource that is actually signed.
	# The signed resource equals the supplied text by construction; the only
	# rejection is the SDK signer's own ValidatePolicyInput, which refuses double
	# quotes, backslashes, and control characters on every canned/custom URL and
	# cookie path. These tests drive the cmdlets through PowerShell parameter
	# binding rather than calling the underlying .NET signer directly.

	BeforeAll {
		# A throwaway RSA key the signer can actually load, so the signed resource
		# can be asserted. It is generated here rather than committed: no key
		# material lands in the repo, and its public half is registered with no
		# distribution, so a URL signed with it grants access to nothing.
		#
		# The signer reads a PKCS#1 PEM. This suite runs under PowerShell 7, whose
		# RSA.ExportRSAPrivateKey() emits PKCS#1 DER directly; PemEncoding.Write wraps
		# it with the PEM delimiters from the label, so no key-header literal appears
		# in this source (which would otherwise trip secret scanners).
		$rsa = [System.Security.Cryptography.RSA]::Create(2048)
		try {
			$pem = -join [System.Security.Cryptography.PemEncoding]::Write([char[]]"RSA PRIVATE KEY", $rsa.ExportRSAPrivateKey())
		}
		finally {
			$rsa.Dispose()
		}

		$script:keyFile = Join-Path ([System.IO.Path]::GetTempPath()) ("cf-signing-test-{0}.pem" -f ([System.Guid]::NewGuid()))
		Set-Content -Path $script:keyFile -Value $pem
		$script:expiresOn = (Get-Date).AddHours(1)
	}

	AfterAll {
		if ($script:keyFile -and (Test-Path $script:keyFile)) {
			Remove-Item -Path $script:keyFile -Force
		}
	}

	# Inputs the SDK signer refuses outright: double quotes, backslashes, and
	# control characters. These are rejected whether the backslash arrives via a
	# traversal attempt or on its own.
	$invalidCharResources = @(
		@{ Name = "a single backslash";        Resource = 'https://distribution.example/allowed\secret.txt' }
		@{ Name = "a backslash dot traversal"; Resource = 'https://distribution.example/allowed\..\secret.txt' }
		@{ Name = "a double quote";            Resource = 'https://distribution.example/allowed"secret.txt' }
	)

	# Inputs that must be signed exactly as supplied. This includes forms that the
	# old Uri.ToString() path would have normalized - dot segments (plain, percent-
	# encoded, or behind an encoded slash) and percent-encoded backslashes/quotes -
	# which are now signed literally, so they match only the literal resource and do
	# not grant broader access. Percent-encoded and canonical forms are preserved
	# byte-for-byte because OriginalString is never decoded.
	$exactSignResources = @(
		@{ Name = "a clean https path";                      Resource = 'https://distribution.example/allowed/secret.txt' }
		@{ Name = "a percent-encoded space";                 Resource = 'https://distribution.example/my%20file.txt' }
		@{ Name = "a literal space";                         Resource = 'https://distribution.example/my file.txt' }
		@{ Name = "a non-ASCII path";                        Resource = "https://distribution.example/caf$([char]0x00E9).txt" }
		@{ Name = "an encoded unreserved tilde";             Resource = 'https://distribution.example/%7Euser/x' }
		@{ Name = "an encoded unreserved letter";            Resource = 'https://distribution.example/%41BC' }
		@{ Name = "a percent-encoded backslash";             Resource = 'https://distribution.example/a%5Cb' }
		@{ Name = "a percent-encoded quote";                 Resource = 'https://distribution.example/a%22b' }
		@{ Name = "a forward-slash dot traversal";           Resource = 'https://distribution.example/allowed/../secret.txt' }
		@{ Name = "a single-dot segment";                    Resource = 'https://distribution.example/allowed/./secret.txt' }
		@{ Name = "a percent-encoded dot traversal";         Resource = 'https://distribution.example/allowed/%2E%2E/secret.txt' }
		@{ Name = "a traversal behind an encoded slash";     Resource = 'https://distribution.example/allowed%2F..%2Fsecret.txt' }
		@{ Name = "dot segments only in the query";          Resource = 'https://distribution.example/allowed/secret.txt?redirect=../other' }
		@{ Name = "a bare RTMP stream name";                 Resource = 'my-stream-name' }
	)

	Context "New-CFSignedUrl" {
		It "rejects <Name>" -TestCases $invalidCharResources {
			param($Resource)
			{ New-CFSignedUrl -ResourceUri $Resource -KeyPairId "KEYPAIRID" -PrivateKeyFile $script:keyFile -ExpiresOn $script:expiresOn } |
				Should -Throw -ExpectedMessage "*invalid character*"
		}

		It "signs <Name> exactly as supplied" -TestCases $exactSignResources {
			param($Resource)
			# -AsString emits "<resource>?<query>", so the signed URL must begin with
			# the exact text supplied: no normalization has occurred.
			$signed = New-CFSignedUrl -ResourceUri $Resource -KeyPairId "KEYPAIRID" -PrivateKeyFile $script:keyFile -ExpiresOn $script:expiresOn -AsString
			$signed.StartsWith($Resource, [System.StringComparison]::Ordinal) | Should -BeTrue
		}

		It "signs <Name> exactly as supplied under the custom policy" -TestCases $exactSignResources {
			param($Resource)
			$signed = New-CFSignedUrl -ResourceUri $Resource -KeyPairId "KEYPAIRID" -PrivateKeyFile $script:keyFile -ExpiresOn $script:expiresOn -IpRange "192.168.0.1/24" -AsString
			$signed.StartsWith($Resource, [System.StringComparison]::Ordinal) | Should -BeTrue
		}
	}

	Context "New-CFSignedCookie" {
		It "rejects <Name>" -TestCases $invalidCharResources {
			param($Resource)
			{ New-CFSignedCookie -ResourceUri $Resource -KeyPairId "KEYPAIRID" -PrivateKeyFile $script:keyFile -ExpiresOn $script:expiresOn } |
				Should -Throw -ExpectedMessage "*invalid character*"
		}

		It "signs <Name> without rejecting it" -TestCases $exactSignResources {
			param($Resource)
			# The cookie resource is embedded in the signed (base64) policy rather
			# than returned in the clear, so assert the cmdlet accepts and signs it.
			$cookies = New-CFSignedCookie -ResourceUri $Resource -KeyPairId "KEYPAIRID" -PrivateKeyFile $script:keyFile -ExpiresOn $script:expiresOn
			$cookies | Should -Not -BeNullOrEmpty
		}

		It "signs <Name> without rejecting it under the custom policy" -TestCases $exactSignResources {
			param($Resource)
			$cookies = New-CFSignedCookie -ResourceUri $Resource -KeyPairId "KEYPAIRID" -PrivateKeyFile $script:keyFile -ExpiresOn $script:expiresOn -IpRange "192.168.0.1/24"
			$cookies | Should -Not -BeNullOrEmpty
		}
	}
}

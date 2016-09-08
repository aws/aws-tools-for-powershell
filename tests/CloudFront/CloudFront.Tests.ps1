Describe -Tag "Smoke" "CloudFront" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

	Context "Distributions" {

		It "Can list distributions" {
			$distributions = Get-CFDistributions

			$distributions | Should Not Be $null
			$distributions.Quantity | Should Be $distributions.Items.Count
		}

	    It "Can read distributions" {
			$distribution = Get-CFDistributions

			if ($distributions) {
				foreach ($dist in $distributions.Items) {
					$distribution = Get-CFDistribution -Id $dist.Id

					$distribution | Should Not Be $null
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

					$invalidations | Should Not Be $null
				}
			}
		}
	}
}

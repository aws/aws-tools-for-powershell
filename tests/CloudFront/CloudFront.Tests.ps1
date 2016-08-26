Describe -Tag "Smoke" "CloudFront Tests" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

	Context "List distributions" {

		It "Can list distributions" {
			$distributions = Get-CFDistributions

			$distributions | Should Not Be $null
			$distributions.Quantity | Should Be $distributions.Items.Count
		}
	}

	Context "Read distributions" {
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

	Context "Read invalidations" {
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

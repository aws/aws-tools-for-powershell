BeforeDiscovery {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
    $InformationPreference = 'Ignore'
}

Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "Installer - ConvertTo-AWSToolsModuleName Unit Tests" {

    Context "Name Normalization" {
        It "Should add the AWS.Tools prefix to unprefixed names" {
            InModuleScope AWS.Tools.Installer {
                # Act
                $result = ConvertTo-AWSToolsModuleName -Name @('S3', 'Common')

                # Assert
                $result | Should -Be @('AWS.Tools.S3', 'AWS.Tools.Common')
            }
        }

        It "Should return names that already contain a dot unchanged" {
            InModuleScope AWS.Tools.Installer {
                # Act
                $result = ConvertTo-AWSToolsModuleName -Name @('AWS.Tools.EC2', 'NotAWS.Module')

                # Assert
                $result | Should -Be @('AWS.Tools.EC2', 'NotAWS.Module')
            }
        }

        It "Should prefix an empty name rather than reject it" {
            # Preserves the behavior of the inline normalization this helper replaced, so invalid
            # input is still reported by the caller's validation rather than by parameter binding.
            InModuleScope AWS.Tools.Installer {
                # Act
                $result = ConvertTo-AWSToolsModuleName -Name @('S3', '')

                # Assert
                $result | Should -Be @('AWS.Tools.S3', 'AWS.Tools.')
            }
        }

        It "Should accept names from the pipeline" {
            InModuleScope AWS.Tools.Installer {
                # Act
                $result = 'S3', 'AWS.Tools.EC2' | ConvertTo-AWSToolsModuleName

                # Assert
                $result | Should -Be @('AWS.Tools.S3', 'AWS.Tools.EC2')
            }
        }
    }
}

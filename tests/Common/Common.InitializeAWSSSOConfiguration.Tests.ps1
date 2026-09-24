BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestModuleIncludes.ps1")

    # Isolate the shared config file to a throwaway location so the test never
    # touches the developer's real ~/.aws/config.
    $script:originalConfigFile = $env:AWS_CONFIG_FILE
    $script:originalSharedCreds = $env:AWS_SHARED_CREDENTIALS_FILE

    $script:tempRoot = Join-Path ([IO.Path]::GetTempPath()) ("aws-tools-sso-whatif-" + [guid]::NewGuid().ToString('N'))
    New-Item -ItemType Directory -Path $script:tempRoot | Out-Null
    $script:configPath = Join-Path $script:tempRoot "config"
    $script:credsPath = Join-Path $script:tempRoot "credentials"

    $env:AWS_CONFIG_FILE = $script:configPath
    $env:AWS_SHARED_CREDENTIALS_FILE = $script:credsPath
}

AfterAll {
    $env:AWS_CONFIG_FILE = $script:originalConfigFile
    $env:AWS_SHARED_CREDENTIALS_FILE = $script:originalSharedCreds
    if (Test-Path $script:tempRoot) { Remove-Item -Recurse -Force -Path $script:tempRoot }
}

Describe -Tag "Smoke" "Common.InitializeAWSSSOConfiguration" {

    Context "-WhatIf" {

        It "does not write the sso-session/profile to the config file" {
            Initialize-AWSSSOConfiguration `
                -ProfileName 'my-profile' `
                -SessionName 'my-session' `
                -AccountId '111111111111' `
                -RoleName 'ReadOnly' `
                -StartUrl 'https://d-1234567890.awsapps.com/start' `
                -SSORegion 'us-east-1' `
                -Region 'us-east-1' `
                -WhatIf

            # -WhatIf must not create the config file (or, if present, must not add the section).
            if (Test-Path $script:configPath) {
                $content = Get-Content -LiteralPath $script:configPath -Raw
                $content | Should -Not -Match '\[sso-session my-session\]'
                $content | Should -Not -Match '\[profile my-profile\]'
            }
            else {
                (Test-Path $script:configPath) | Should -BeFalse
            }
        }

        It "does not persist an injected profile/credential_process when the session name is malicious" {
            $maliciousSession = "candidate]`n[profile victim-profile]`ncredential_process = evil`n[sso-session tail"

            # Validation rejects the malicious name, so nothing is written regardless of -WhatIf.
            { Initialize-AWSSSOConfiguration `
                -ProfileName 'my-profile' `
                -SessionName $maliciousSession `
                -AccountId '111111111111' `
                -RoleName 'ReadOnly' `
                -StartUrl 'https://d-1234567890.awsapps.com/start' `
                -SSORegion 'us-east-1' `
                -Region 'us-east-1' `
                -WhatIf `
                -ErrorAction Stop } | Should -Throw

            if (Test-Path $script:configPath) {
                $content = Get-Content -LiteralPath $script:configPath -Raw
                $content | Should -Not -Match 'credential_process'
                $content | Should -Not -Match '\[profile victim-profile\]'
            }
        }
    }
}

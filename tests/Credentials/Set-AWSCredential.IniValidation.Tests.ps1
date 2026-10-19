$invalidNames = @(
    @{ Label = 'CR'; Name = "bad`rname" }
    @{ Label = 'LF'; Name = "bad`nname" }
    @{ Label = 'CRLF'; Name = "bad`r`nname" }
    @{ Label = 'left bracket'; Name = 'bad[name' }
    @{ Label = 'right bracket'; Name = 'bad]name' }
    @{ Label = 'whitespace'; Name = '   ' }
    @{ Label = 'injected section'; Name = "legit]`n[attacker]`ncredential_process=unused`n[tail" }
)
$saveCases = foreach ($invalid in $invalidNames) {
    foreach ($mode in 'Parameters', 'Object') {
        foreach ($exists in $true, $false) {
            @{ Label = $invalid.Label; Name = $invalid.Name; Mode = $mode; Exists = $exists }
        }
    }
}
$validCases = foreach ($name in 'my-profile', 'my profile', 'team.dev_1') {
    foreach ($mode in 'Parameters', 'Object', 'Copy') {
        @{ Name = $name; Mode = $mode }
    }
}

$invalidValueCases = foreach ($field in 'AccessKey', 'SecretKey', 'SessionToken') {
    foreach ($value in "bad`rvalue", "bad`nvalue", "bad`r`nvalue", "value`n[injected]`ncredential_process=unused") {
        foreach ($command in 'Set-AWSCredential', 'Initialize-AWSDefaultConfiguration') {
            foreach ($mode in 'Parameters', 'Object') {
                foreach ($exists in $true, $false) {
                    @{ Field = $field; Value = $value; Command = $command; Mode = $mode; Exists = $exists }
                }
            }
        }
    }
}

$invalidRegionCases = foreach ($region in "us-west-2`r[injected]", "us-west-2`n[injected]",
    "us-west-2`r`n[injected]", "us-west-2`n[injected]`ncredential_process=unused") {
    foreach ($mode in 'Parameters', 'Object', 'Copy') {
        foreach ($exists in $true, $false) {
            if ($mode -eq 'Copy' -and -not $exists) { continue }
            @{ Region = $region; Mode = $mode; Exists = $exists }
        }
    }
}

BeforeAll {
    if ($env:AWS_TOOLS_COMMON_TEST_MODULE_PATH) {
        Import-Module $env:AWS_TOOLS_COMMON_TEST_MODULE_PATH -ErrorAction Stop
    }
    else {
        . (Join-Path (Join-Path (Get-Location) 'Include') 'TestIncludes.ps1')
    }

    $originalRegion = Get-Variable -Name StoredAWSRegion -Scope Global -ErrorAction SilentlyContinue
    $script:hadOriginalRegion = $null -ne $originalRegion
    $script:originalRegionValue = if ($originalRegion) { $originalRegion.Value } else { $null }
    $script:tempDirectory = Join-Path ([IO.Path]::GetTempPath()) ([Guid]::NewGuid().ToString())
    [IO.Directory]::CreateDirectory($script:tempDirectory) | Out-Null
    $script:originalEnvironment = @{}
    foreach ($variable in 'AWS_SHARED_CREDENTIALS_FILE', 'AWS_CONFIG_FILE', 'AWS_EC2_METADATA_DISABLED') {
        $script:originalEnvironment[$variable] = [Environment]::GetEnvironmentVariable($variable, 'Process')
    }
    $env:AWS_SHARED_CREDENTIALS_FILE = Join-Path $script:tempDirectory 'credentials'
    $env:AWS_CONFIG_FILE = Join-Path $script:tempDirectory 'config'
    $env:AWS_EC2_METADATA_DISABLED = 'true'

    function Save-TestProfile($mode, $name, $path) {
        $parameters = @{ StoreAs = $name; ProfileLocation = $path; ErrorAction = 'Stop' }
        switch ($mode) {
            'Parameters' { Set-AWSCredential @parameters -AccessKey 'access_key' -SecretKey 'secret_key' }
            'Object' {
                $credentials = [Amazon.Runtime.BasicAWSCredentials]::new('access_key', 'secret_key')
                Set-AWSCredential @parameters -Credential $credentials
            }
            'Copy' { Set-AWSCredential @parameters -ProfileName 'source-profile' }
        }
    }

    function Get-TestFileBytes($path) {
        [Convert]::ToBase64String([IO.File]::ReadAllBytes($path))
    }
}

AfterAll {
    if ($script:hadOriginalRegion) {
        Set-Variable -Name StoredAWSRegion -Scope Global -Value $script:originalRegionValue
    }
    else {
        Remove-Variable -Name StoredAWSRegion -Scope Global -ErrorAction SilentlyContinue
    }
    foreach ($variable in $script:originalEnvironment.Keys) {
        [Environment]::SetEnvironmentVariable($variable, $script:originalEnvironment[$variable], 'Process')
    }
    Remove-Item $script:tempDirectory -Recurse -Force
}

Describe 'Credential profile INI validation' {
    BeforeEach {
        Clear-AWSCredential -Scope Global
        Clear-DefaultAWSRegion -Scope Global
        $script:profilePath = Join-Path $script:tempDirectory ([Guid]::NewGuid().ToString())
    }

    AfterEach {
        Clear-AWSCredential -Scope Global
        Clear-DefaultAWSRegion -Scope Global
    }

    It 'rejects <Label> through <Mode>, existing file: <Exists>' -ForEach $saveCases {
        if ($Exists) {
            Save-TestProfile 'Parameters' 'source-profile' $script:profilePath
            $before = Get-TestFileBytes $script:profilePath
        }

        { Save-TestProfile $Mode $Name $script:profilePath } | Should -Throw -ExpectedMessage '*StoreAs*'

        if ($Exists) {
            Get-TestFileBytes $script:profilePath | Should -BeExactly $before
        }
        else {
            Test-Path $script:profilePath | Should -BeFalse
        }
    }

    It 'rejects <Label> when copying a profile without changing the file' -ForEach $invalidNames {
        Save-TestProfile 'Parameters' 'source-profile' $script:profilePath
        $before = Get-TestFileBytes $script:profilePath

        { Save-TestProfile 'Copy' $Name $script:profilePath } | Should -Throw -ExpectedMessage '*StoreAs*'

        Get-TestFileBytes $script:profilePath | Should -BeExactly $before
    }

    It 'saves valid name <Name> through <Mode>' -ForEach $validCases {
        if ($Mode -eq 'Copy') {
            Save-TestProfile 'Parameters' 'source-profile' $script:profilePath
        }
        Save-TestProfile $Mode $Name $script:profilePath

        $credentials = Get-AWSCredential -ProfileName $Name -ProfileLocation $script:profilePath -ErrorAction Stop
        $credentials.GetCredentials().AccessKey | Should -BeExactly 'access_key'
        $credentials.GetCredentials().SecretKey | Should -BeExactly 'secret_key'
    }

    It 'rejects line breaks in <Field> through <Command> (<Mode>), existing file: <Exists>' -ForEach $invalidValueCases {
        if ($Exists) {
            Save-TestProfile 'Parameters' 'source-profile' $script:profilePath
            $before = Get-TestFileBytes $script:profilePath
        }

        $values = @{ AccessKey = 'access_key'; SecretKey = 'secret_key'; SessionToken = 'session_token' }
        $values[$Field] = $Value
        $parameters = @{ ProfileLocation = $script:profilePath; ErrorAction = 'Stop' }
        if ($Command -eq 'Set-AWSCredential') {
            $parameters.StoreAs = 'safe-profile'
        }
        else {
            $parameters.Region = 'us-west-2'
            $parameters.Scope = 'Global'
        }
        if ($Mode -eq 'Object') {
            $parameters.Credential = [Amazon.Runtime.SessionAWSCredentials]::new(
                $values.AccessKey, $values.SecretKey, $values.SessionToken)
        }
        else {
            foreach ($key in $values.Keys) { $parameters[$key] = $values[$key] }
        }

        { & $Command @parameters } | Should -Throw -ExpectedMessage '*Line breaks are not allowed*'

        if ($Exists) {
            Get-TestFileBytes $script:profilePath | Should -BeExactly $before
        }
        else {
            Test-Path $script:profilePath | Should -BeFalse
        }
    }

    It 'rejects line breaks in Region through <Mode>, existing file: <Exists>' -ForEach $invalidRegionCases {
        if ($Exists) {
            Save-TestProfile 'Parameters' 'source-profile' $script:profilePath
            $before = Get-TestFileBytes $script:profilePath
        }

        $parameters = @{ Region = $Region; ProfileLocation = $script:profilePath; Scope = 'Global'; ErrorAction = 'Stop' }
        switch ($Mode) {
            'Parameters' { $parameters.AccessKey = 'access_key'; $parameters.SecretKey = 'secret_key' }
            'Object' { $parameters.Credential = [Amazon.Runtime.BasicAWSCredentials]::new('access_key', 'secret_key') }
            'Copy' { $parameters.ProfileName = 'source-profile' }
        }

        # The SDK may reject the region before the shared persistence validator runs.
        { Initialize-AWSDefaultConfiguration @parameters } | Should -Throw

        if ($Exists) {
            Get-TestFileBytes $script:profilePath | Should -BeExactly $before
        }
        else {
            Test-Path $script:profilePath | Should -BeFalse
        }
    }

    It 'saves a valid Region through <Mode>' -ForEach @(
        @{ Mode = 'Parameters' }
        @{ Mode = 'Object' }
        @{ Mode = 'Copy' }
    ) {
        $parameters = @{ Region = 'us-west-2'; ProfileLocation = $script:profilePath; Scope = 'Global'; ErrorAction = 'Stop' }
        switch ($Mode) {
            'Parameters' { $parameters.AccessKey = 'access_key'; $parameters.SecretKey = 'secret_key' }
            'Object' { $parameters.Credential = [Amazon.Runtime.BasicAWSCredentials]::new('access_key', 'secret_key') }
            'Copy' {
                Save-TestProfile 'Parameters' 'source-profile' $script:profilePath
                $parameters.ProfileName = 'source-profile'
            }
        }

        Initialize-AWSDefaultConfiguration @parameters

        $store = [Amazon.Runtime.CredentialManagement.SharedCredentialsFile]::new($script:profilePath)
        $profile = $null
        $store.TryGetProfile('default', [ref]$profile) | Should -BeTrue
        $profile.Region.SystemName | Should -BeExactly 'us-west-2'
        $profile.Options.AccessKey | Should -BeExactly 'access_key'
        $profile.Options.SecretKey | Should -BeExactly 'secret_key'
    }

    It 'saves valid values through <Command> (<Mode>)' -ForEach @(
        @{ Command = 'Set-AWSCredential'; Mode = 'Parameters' }
        @{ Command = 'Set-AWSCredential'; Mode = 'Object' }
        @{ Command = 'Initialize-AWSDefaultConfiguration'; Mode = 'Parameters' }
        @{ Command = 'Initialize-AWSDefaultConfiguration'; Mode = 'Object' }
    ) {
        $parameters = @{ ProfileLocation = $script:profilePath; ErrorAction = 'Stop' }
        $name = 'default'
        if ($Command -eq 'Set-AWSCredential') {
            $name = 'safe-profile'
            $parameters.StoreAs = $name
        }
        else {
            $parameters.Region = 'us-west-2'
            $parameters.Scope = 'Global'
        }
        if ($Mode -eq 'Object') {
            $parameters.Credential = [Amazon.Runtime.SessionAWSCredentials]::new('access_key', 'secret_key', 'session_token')
        }
        else {
            $parameters.AccessKey = 'access_key'
            $parameters.SecretKey = 'secret_key'
            $parameters.SessionToken = 'session_token'
        }
        & $Command @parameters

        $saved = (Get-AWSCredential -ProfileName $name -ProfileLocation $script:profilePath -ErrorAction Stop).GetCredentials()
        $saved.AccessKey | Should -BeExactly 'access_key'
        $saved.SecretKey | Should -BeExactly 'secret_key'
        $saved.Token | Should -BeExactly 'session_token'
    }

    It 'preserves session use when StoreAs is absent or empty' -ForEach @(
        @{ Parameters = @{}; Label = 'absent' }
        @{ Parameters = @{ StoreAs = '' }; Label = 'empty' }
    ) {
        Set-AWSCredential -AccessKey 'access_key' -SecretKey 'secret_key' -Scope Global @Parameters
        (Get-AWSCredential -ErrorAction Stop).GetCredentials().AccessKey | Should -BeExactly 'access_key'
        Test-Path $env:AWS_SHARED_CREDENTIALS_FILE | Should -BeFalse
        Test-Path $env:AWS_CONFIG_FILE | Should -BeFalse
    }

    It 'rejects SAML StoreAs containing <Label> before endpoint resolution' -ForEach $invalidNames {
        { Set-AWSSamlRoleProfile -EndpointName 'unused-endpoint' -StoreAs $Name -ErrorAction Stop } |
            Should -Throw -ExpectedMessage '*StoreAs*'
        Test-Path $env:AWS_SHARED_CREDENTIALS_FILE | Should -BeFalse
        Test-Path $env:AWS_CONFIG_FILE | Should -BeFalse
    }
}

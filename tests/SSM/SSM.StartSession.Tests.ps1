BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()

    $script:isWindowsHost = $IsWindows -or $PSVersionTable.PSEdition -eq 'Desktop'
    $script:calls = [System.Collections.Concurrent.ConcurrentQueue[string]]::new()
    foreach ($attempt in 1..5) {
        $port = Get-Random -Minimum 20000 -Maximum 60000
        $candidate = [System.Net.HttpListener]::new()
        $candidate.Prefixes.Add("http://localhost:$port/")
        try {
            $candidate.Start()
            $script:listener = $candidate
            $script:endpoint = "http://localhost:$port"
            break
        }
        catch {
            $candidate.Close()
        }
    }
    if (-not $script:listener) {
        throw 'Could not start the mock SSM endpoint.'
    }

    $script:mockService = [powershell]::Create()
    $null = $mockService.AddScript({
        param($listener, $calls)
        while ($listener.IsListening) {
            try { $context = $listener.GetContext() } catch { break }
            $target = $context.Request.Headers['X-Amz-Target']
            $calls.Enqueue($target)
            $body = if ($target -like '*StartSession') {
                '{"SessionId":"s-1","TokenValue":"TOKEN-SECRET","StreamUrl":"wss://ssmmessages.us-east-1.amazonaws.com/v1/data-channel/s-1"}'
            } else {
                '{"SessionId":"s-1"}'
            }
            $bytes = [System.Text.Encoding]::UTF8.GetBytes($body)
            $context.Response.ContentType = 'application/x-amz-json-1.1'
            $context.Response.OutputStream.Write($bytes, 0, $bytes.Length)
            $context.Response.Close()
        }
    }).AddArgument($listener).AddArgument($calls)
    $null = $mockService.BeginInvoke()

    $script:sessionArgs = @{
        Target      = 'i-0123456789abcdef0'
        Region      = 'us-east-1'
        EndpointUrl = $endpoint
        AccessKey   = 'AKIDEXAMPLE'
        SecretKey   = 'secret'
    }
}

AfterAll {
    $listener.Stop()
    $mockService.Dispose()
    $helper.AfterAll()
}

Describe -Tag "Smoke" "Start-SSMSession plugin invocation" {

    BeforeEach {
        $script:originalPath = $env:PATH
        $script:originalDirectory = [Environment]::CurrentDirectory
        $item = $null
        while ($calls.TryDequeue([ref]$item)) { }
    }

    AfterEach {
        $env:PATH = $originalPath
        [Environment]::CurrentDirectory = $originalDirectory
    }

    It "Does not start a session-manager-plugin from the current directory and terminates the session" {
        $plantedDirectory = Join-Path $TestDrive 'planted'
        $marker = Join-Path $plantedDirectory 'ran.txt'
        $plantedName = if ($isWindowsHost) { 'session-manager-plugin.exe' } else { 'session-manager-plugin' }
        $planted = Join-Path $plantedDirectory $plantedName
        $null = New-Item -ItemType Directory -Path $plantedDirectory
        Set-Content -Path $planted -Value "#!/bin/sh`ntouch '$marker'"
        if (-not $isWindowsHost) { chmod +x $planted }
        $env:PATH = ".$([IO.Path]::PathSeparator)$([IO.Path]::PathSeparator)$(Join-Path $TestDrive 'empty')"
        [Environment]::CurrentDirectory = $plantedDirectory

        { Start-SSMSession @sessionArgs } | Should -Throw '*SessionManagerPlugin is not found*'
        Test-Path $marker | Should -BeFalse
        $calls.ToArray() | Should -Contain 'AmazonSSM.TerminateSession'
    }

    # Token hand-off and plugin version tests were removed because integrations test run only on Windows.
    # Add them back if Pester runs on Linux (see PR #727).
}

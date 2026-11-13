BeforeDiscovery {
    $deployment = Join-Path (Join-Path (Get-Location) '..') 'Deployment'
    $script:moduleFolders = @(
        @{ Name = 'AWS.Tools.Common'; Path = Join-Path $deployment 'AWS.Tools/AWS.Tools.Common' }
        @{ Name = 'AWSPowerShell.NetCore'; Path = Join-Path $deployment 'AWSPowerShell.NetCore' }
        @{ Name = 'AWSPowerShell'; Path = Join-Path $deployment 'AWSPowerShell' }
    ) | Where-Object { Test-Path (Join-Path $_.Path 'System.Text.Json.dll') }
}

Describe -Tag "Smoke" "Common.TransitiveDependencies" {

    # Windows PowerShell applies no binding redirects. If another System.Memory or System.Buffers with the version
    # System.Text.Json references is in the GAC or already loaded, a different shipped version makes the session load two copies.
    It "ships the System.Memory and System.Buffers versions System.Text.Json references in <Name>" -TestCases $moduleFolders {
        param($Path)

        $stream = [System.IO.File]::OpenRead((Join-Path $Path 'System.Text.Json.dll'))
        try {
            $reader = [System.Reflection.Metadata.PEReaderExtensions]::GetMetadataReader([System.Reflection.PortableExecutable.PEReader]::new($stream))
            $references = @{}
            foreach ($handle in $reader.AssemblyReferences) {
                $reference = $reader.GetAssemblyReference($handle)
                $references[$reader.GetString($reference.Name)] = $reference.Version
            }
        }
        finally {
            $stream.Dispose()
        }

        foreach ($name in 'System.Memory', 'System.Buffers') {
            $shipped = [System.Reflection.AssemblyName]::GetAssemblyName((Join-Path $Path "$name.dll")).Version
            "$name $shipped" | Should -Be "$name $($references[$name])"
        }
    }
}

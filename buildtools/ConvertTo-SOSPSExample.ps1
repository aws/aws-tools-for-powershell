<#
This script will be used one time to convert XML examples to a new format that can be published to AWS Examples in the developer center.

This script is being used interactively and the results are being verified manually/iteratively so it is not written to optimize reusability, testability, and modularity.

This script takes a dependency on Windows by using Out-GridView.

Example Invocation:

$ErrorActionPreference = 'Stop'
. .\buildtools\ConvertTo-SOSPSExample.ps1
Get-UnprocessedExampleFiles -SourceDirectory $path_to_aws_tools_for_powershell_repo | ForEach-Object {Write-Host "Processing: `$_`"; ConvertTo-SOSPSExampleFileSet -CmdletName $_ -SourceDirectory $path_to_aws_tools_for_powershell_repo -ErrorAction 'Stop'}
#>

function ConvertTo-SOSPSExampleFileSet
{
    <#
    .SYNOPSIS
    Converts a legacy XML-based AWS PS example file into an SOS metadata file and one or more snippet files.
    
    .DESCRIPTION
    Converts a legacy XML-based AWS PS example file into an SOS metadata file and one or more snippet files.
    
    .PARAMETER CmdletName
    The name of the cmdlet for which examples are being converted.
    
    .PARAMETER SourceDirectory
    The path to root of aws-tools-for-powershell repo.
    #>
    [CmdletBinding()]
    param
    (
        [Parameter(Mandatory)]
        [String]
        $CmdletName,

        [Parameter()]
        [String]
        $SourceDirectory = (Get-Location).Path
    )
    
    process
    {
        $serviceOperation = Get-AwsServiceOperation -CmdletName $CmdletName -SourceDirectory $SourceDirectory

        # Get the code content from the original XML example file.
        $examplesDirectory = [System.Io.Path]::Join($SourceDirectory, 'generator', 'AWSPSGeneratorLib', 'HelpMaterials', 'Examples')
        $destinationDirectory = [System.Io.Path]::Join($SourceDirectory, '.doc_gen')

        $cmdletFile = Get-ChildItem -Path $examplesDirectory -Filter '*.xml' -Recurse | Where-Object { $_.Name -eq "$CmdletName.xml" }

        $newSOSExcerptSetParams = @{ 
            Path            = $cmdletFile 
            CmdletName      = $CmdletName 
            ServiceName     = $serviceOperation.ServiceName
            SourceDirectory = $SourceDirectory
        }

        # Construct the object that will be converted into a metadata YAML file.
        $metadataHashtable = [Ordered]@{
            ($serviceOperation.ServiceName + '_' + $serviceOperation.ServiceOperation) = [Ordered]@{
                title        = "Use ${CmdletName}"
                title_abbrev = "$CmdletName"
                synopsis     = "use ${CmdletName}"
                languages    = [Ordered]@{
                    PowerShell = @{
                        versions = @(
                            [Ordered]@{
                                sdk_version = 4
                                excerpts    = New-SOSExcerptSet @newSOSExcerptSetParams
                            }
                        )
                    }
                }
                services     = @{
                    $serviceOperation.ServiceName = @{
                        $serviceOperation.ServiceOperation = $null
                    }
                }
            }
        }

        # Write the YAML content to a file.
        $metadataYaml = ConvertTo-Yaml -Data $metadataHashtable
        $metadataFileName = ($serviceOperation.ServiceName + '_' + $CmdletName + '_metadata.yaml')
        $metadataFilePath = [System.Io.Path]::Join($destinationDirectory, 'metadata', $metadataFileName)
        Set-Content -Path $metadataFilePath -Value ("---" + "`n" + $metadataYaml) -NoNewline

    }
}

function Get-AwsServiceOperation
{
    <#
    .SYNOPSIS
    Gets the service name and operation for an AWS cmdlet.
    
    .DESCRIPTION
    Gets the service name and operation for an AWS cmdlet.
    
    .PARAMETER CmdletName
    The name of the cmdlet for which examples are being converted.
    
    .PARAMETER SourceDirectory
    The path to root of aws-tools-for-powershell repo.
    #>
    [OutputType([Hashtable])]
    [CmdletBinding()]
    param
    (
        [Parameter(Mandatory)]
        [String]
        $CmdletName,

        [Parameter()]
        [String]
        $SourceDirectory = (Get-Location).Path
    )
    
    process
    {
        $awsCmdlet = Get-AWSCmdletName -CmdletName $CmdletName

        if ($null -eq $awsCmdlet)
        {
            # No result was returned by Get-AWSCmdletName. Check if the cmdlet is from the common module
            $awsToolsCommonModuleName = 'common'
            $examplesDirectory = [System.Io.Path]::Join($SourceDirectory, 'generator', 'AWSPSGeneratorLib', 'HelpMaterials', 'Examples')
            
            $commonCmdlets = (Get-ChildItem -Path (Join-Path -Path $examplesDirectory -ChildPath $awsToolsCommonModuleName)).BaseName
            if ($commonCmdlets -contains $CmdletName)
            {
                $serviceName = $awsToolsCommonModuleName
                $serviceOperation = $CmdletName
            }
            else
            {
                Write-Error "Unable to find a cmdlet named '$CmdletName'" -ErrorAction 'Stop'   
            }
        }
        else
        {
            <#
                Get-AWSCmdletName does not provide the required service name format.  
                Check the service config for the 'serviceName' and the short service name 'C2JFileName'.
            #>
            $serviceConfigs = New-Object System.Collections.Generic.List[XML]

            $serviceConfigDirectory = [System.Io.Path]::Join($SourceDirectory, 'generator', 'AWSPSGeneratorLib', 'Config', 'ServiceConfig')
            $serviceConfigFiles = Get-ChildItem -Path $serviceConfigDirectory -Filter '*.xml'
            foreach ($serviceConfigFile in $serviceConfigFiles)
            {
                if ($null -eq $serviceConfigFile)
                {
                    $serviceConfigFile = Get-ChildItem -Path $serviceConfigFile -Filter '*.xml' | Select-Object -Last 1
                }
                if ($null -eq $serviceConfigFile)
                {
                    Write-Warning "No metadata file found for service '$($serviceConfigFile.Name)'"
                }
                else
                {
                    $configObject = [XML](Get-Content -Path $serviceConfigFile -Raw)
                    $serviceConfigs.Add($configObject)                
                }
            }
            $serviceName = $serviceConfigs | Where-Object { $_.configModel.ServiceName -eq $awsCmdlet.ServiceName } | ForEach-Object { $_.configModel.C2jFilename }
        }

        # If a cmdlet is not based on a service operation, name the example after the cmdlet.
        if ([String]::IsNullOrEmpty($awsCmdlet.ServiceOperation))
        {
            $serviceOperation = $CmdletName
        }
        else
        {
            $serviceOperation = $awsCmdlet.ServiceOperation   
        }

        return @{
            ServiceName      = $serviceName
            ServiceOperation = $serviceOperation
        }

    }
}

function New-SOSExcerptSet
{
    <#
    .SYNOPSIS
    Creates a set of excerpts for one or more examples combined.
    
    .DESCRIPTION
    Creates a set of excerpts for one or more examples combined.
    
    .PARAMETER Path
    The path to an XML file containing examples for a cmdlet.

    .PARAMETER CmdletName
    The name of the cmdlet for which examples are being converted.
    
    .PARAMETER ServiceName
    The path to root of aws-tools-for-powershell repo.

    .PARAMETER SourceDirectory
    The path to root of aws-tools-for-powershell repo.
    #>
    [OutputType([System.Collections.Generic.List[Hashtable]])]
    [CmdletBinding()]
    param
    (
        [Parameter(Mandatory)]
        [String]
        $Path,

        [Parameter(Mandatory)]
        [String]
        $CmdletName,

        [Parameter(Mandatory)]
        [String]
        $ServiceName,

        [Parameter()]
        [String]
        $SourceDirectory = (Get-Location).Path        
    )
    
    process
    {
        $rawContent = Get-Content -Path $Path -Raw
        $xmlDocument = [Xml]$rawContent
        $excerpts = New-Object System.Collections.Generic.List[Hashtable]

        $exampleIndex = 0;
        foreach ($example in $xmlDocument.examples.example)
        {
            $exampleIndex++

            $excerpts.Add((New-SOSExcerpt -Type 'Heading' -Value "Example $($exampleIndex): $($example.description)"))
            # Trim leading and trailing whitespace.
            $exampleLines = ($example.code.Trim() -split "`n")

            # One line examples can be processed fully automatically.
            if ($exampleLines.count -eq 1)
            {
                $newSosSnippetFileParams = @{
                    ServiceName     = $ServiceName
                    CmdletName      = $CmdletName
                    ExampleIndex    = $exampleIndex
                    SnippetIndex    = 1
                    SourceDirectory = $SourceDirectory
                    Value           = $exampleLines
                }
                $snippetFile = New-SOSSnippetFile @newSosSnippetFileParams
                $excerpts.Add((New-SOSExcerpt -Type 'Code' -Value $snippetFile.RelativePath))
            }
            # Multiline examples may need to split lines of code versus lines of output.
            else
            {
                $snippetIndex = 0;
                while ($exampleLines.count -gt 0)
                {
                    $snippetIndex++

                    $splitStringSet = Split-StringSet -StringSet $exampleLines -Title "Select $CmdletName.$exampleIndex.$snippetIndex - Code"
                    $exampleLines = $splitStringSet.NotSelected

                    if ($splitStringSet.Selected.count -gt 0)
                    {
                        $newSosSnippetFileParams = @{
                            ServiceName     = $ServiceName
                            CmdletName      = $CmdletName
                            ExampleIndex    = $exampleIndex
                            SnippetIndex    = $snippetIndex
                            SourceDirectory = $SourceDirectory
                            Value           = $splitStringSet.Selected
                        }
                        $snippetFile = New-SOSSnippetFile @newSosSnippetFileParams
                        $excerpts.Add((New-SOSExcerpt -Type 'Code' -Value $snippetFile.RelativePath))
                    }

                    if (-not $splitStringSet.HasMoreContent)
                    {
                        break
                    }

                    if ($exampleLines.count -gt 0)
                    {
                        $splitStringSet = Split-StringSet -StringSet $exampleLines -Title "Select $CmdletName.$exampleIndex.$snippetIndex - Output"
                        if ($splitStringSet.Selected.count -gt 0)
                        {
                            $excerpts.Add((New-SOSExcerpt -Type 'Heading' -Value "Output:"))
                            $excerpts.Add((New-SOSExcerpt -Type 'Output' -Value $splitStringSet.Selected))
                            $exampleLines = $splitStringSet.NotSelected
                        }
                        else 
                        {
                            break
                        }
                    }

                    if (-not $splitStringSet.HasMoreContent)
                    {
                        break
                    }
                }
            }
        }
        return $excerpts
    }
}

function New-SOSExcerpt
{
    <#
    .SYNOPSIS
    Creates a single excerpt.
    
    .DESCRIPTION
    Creates a single excerpt.
    
    .PARAMETER Type
    Describes the type of excerpt content being added. Values include Heading, Paragraph, Code, and Output.
    
    .PARAMETER Value
    The content for the excerpt.
    #>
    [OutputType([System.Collections.Specialized.OrderedDictionary])]
    [CmdletBinding()]
    param
    (
        [Parameter(Mandatory)]
        [ValidateSet('Heading', 'Paragraph', 'Code', 'Output')]
        [String]
        $Type,

        [Parameter(Mandatory)]
        [AllowEmptyString()]
        [String[]]
        $Value
    )
    
    process
    {
        $joinedValue = ($Value -join "`n") -replace '&', '&amp;'
        $excerpt = [Ordered]@{
            description   = $null
            snippet_files = @()
        }

        switch ($Type)
        {
            'Heading'
            {
                $excerpt.description = "<emphasis role=`"bold`">$joinedValue</emphasis>"
            }
            'Paragraph'
            {
                # Cannot mention AWS without using this qualifier or example publishing will break.
                $excerpt.description = $joinedValue -replace 'AWS', '&AWS;'
            }
            'Output'
            {
                $excerpt.description = "<programlisting language=`"none`" role=`"nocopy`">$joinedValue</programlisting>"
            }
            'Code'
            {
                $excerpt.snippet_files = @(
                    $joinedValue
                )
            }            
        }

        return $excerpt
    }
}

function New-SOSSnippetFile
{
    <#
    .SYNOPSIS
    Creates a new snippet file.
    
    .DESCRIPTION
    Creates a new snippet file.
    
    .PARAMETER ServiceName
    The name of the AWS Service.
    
    .PARAMETER CmdletName
    The name of the AWS Tools for PowerShell cmdlet.
    
    .PARAMETER ExampleIndex
    Represents which example this snippet file is being created for.
    
    .PARAMETER SnippetIndex
    Represents which snippet this snippet file is being created for.
    
    .PARAMETER SourceDirectory
    The path to root of aws-tools-for-powershell repo.
    
    .PARAMETER Value
    The content to add to the snippet file.
    #>
    [CmdletBinding()]
    param
    (
        [Parameter(Mandatory)]
        [String]
        $ServiceName,

        [Parameter(Mandatory)]
        [String]
        $CmdletName,

        [Parameter(Mandatory)]
        [Int]
        $ExampleIndex,

        [Parameter(Mandatory)]
        [Int]
        $SnippetIndex,

        [Parameter()]
        [String]
        $SourceDirectory = (Get-Location).Path,

        [Parameter(Mandatory)]
        [AllowEmptyString()]
        [String[]]
        $Value
    )

    $joinedValue = ($Value -join "`n")
    $snippetFileName = ($ServiceName + '_' + $CmdletName + '.' + $ExampleIndex + '.' + $SnippetIndex + '.ps1')
    $snippetFilePath = [System.Io.Path]::Join($SourceDirectory, '.doc_gen', 'snippet_files', $snippetFileName)
    $snippetFileRelativePath = ".doc_gen/snippet_files/$snippetFileName"
    Set-Content -Path $snippetFilePath -Value $joinedValue -NoNewline

    return @{
        Path         = $snippetFilePath
        RelativePath = $snippetFileRelativePath
    }
}

function Split-StringSet
{
    <#
    .SYNOPSIS
    Use Out-GridView to select lines of content from a string array.
    
    .DESCRIPTION
    Use Out-GridView to select lines of content from a string array.
    
    .PARAMETER StringSet
    The string array that is being split.
    
    .PARAMETER Title
    A prompt to inform what selection needs to be made.
    #>
    [CmdletBinding()]
    param
    (
        [Parameter(Mandatory)]
        [AllowEmptyString()]
        [String[]]
        $StringSet,

        [Parameter(Mandatory)]
        [String]
        $Title
    )

    process
    {   
        $indexedStringSet = New-Object System.Collections.Generic.List[PSCustomObject]
        for ($index = 0; $index -lt $StringSet.count; $index++)
        {
            $indexedStringSet.Add(([PSCustomObject]@{
                        Index = $index
                        Value = $StringSet[$index]
                    }))
        }

        $selectedLines = $indexedStringSet | Out-GridView -PassThru -Title $Title
        $notSelectedLines = $indexedStringSet | Where-Object { $selectedLines.Index -notcontains $_.Index } 

        # Discard leading empty/whitespace lines.
        while ($notSelectedLines.count -gt 0 -and [String]::IsNullOrWhiteSpace($notSelectedLines[0].Value))
        {
            $notSelectedLines = $notSelectedLines | Select-Object -Skip 1
        }

        $joinedValue = $notSelectedLines.Value -join "`n"

        return @{
            Selected       = $selectedLines.Value
            NotSelected    = $notSelectedLines.Value
            HasMoreContent = -not ($selectedLines.count -eq 0 -or [String]::IsNullOrWhiteSpace($joinedValue))
        }
    }
}

function Get-UnprocessedExampleFiles
{
    <#
    .SYNOPSIS
    Used to identify XML files that have not been processed into a set of SOS metdata and snippet files.
    
    .DESCRIPTION
    Used to identify XML files that have not been processed into a set of SOS metdata and snippet files.
    
    .PARAMETER SourceDirectory
    The path to root of aws-tools-for-powershell repo.
    #>
    [CmdletBinding()]
    param
    (
        [Parameter()]
        [String]
        $SourceDirectory = (Get-Location).Path
    )

    process
    {
        $xmlFilePath = [System.Io.Path]::Join($SourceDirectory, 'generator', 'AWSPSGeneratorLib', 'HelpMaterials', 'Examples')
        $metadataFilePath = [System.Io.Path]::Join($SourceDirectory, '.doc_gen', 'metadata')

        $xmlFiles = Get-ChildItem -Path $xmlFilePath -Filter '*.xml' -Recurse | Where-Object { $_.BaseName -ne 'Template' }
        $metadataFiles = Get-ChildItem -Path $metadataFilePath -Filter '*_metadata.yaml'
        $processedCmdlets = $metadataFiles | ForEach-Object { (($_.BaseName -split '_')[1]) }
        if ($processedCmdlets.count -gt 1)
        {
            $unprocessedXmlFiles = (Compare-Object -ReferenceObject $xmlFiles.BaseName -DifferenceObject $processedCmdlets).InputObject
        }
        else
        {
            $unprocessedXmlFiles = $xmlFiles.BaseName
        }
        
        return $unprocessedXmlFiles
    }
}

function Set-ExampleServiceName
{
    <#
    .SYNOPSIS
    Used to change the service name in the filename and contents of example files.
    
    .DESCRIPTION
    Used to change the service name in the filename and contents of example files.
    
    .PARAMETER SourceDirectory
    The path to root of aws-tools-for-powershell repo.

    .PARAMETER Name
    The current service name used in example files.

    .PARAMETER NewName
    The new service name used in example files.
    #>
    [CmdletBinding()]
    param
    (
        [Parameter()]
        [String]
        $SourceDirectory = (Get-Location).Path,

        [Parameter(Mandatory)]
        [String]
        $Name,

        [Parameter(Mandatory)]
        [String]
        $NewName
    )

    process
    {
        $metadataFilePath = [System.Io.Path]::Join($SourceDirectory, '.doc_gen', 'metadata')

        $metadataFiles = Get-ChildItem -Path $metadataFilePath -Filter ("$Name" + "_*")
        
        foreach ($metadataFile in $metadataFiles)
        {
            $content = Get-Content -Path $metadataFile -Raw
            $content = $content -replace (($Name + "_"), ($NewName + "_"))
            $content = $content -replace (($Name + ":"), ($NewName + ":"))
            Set-Content -Path $metadataFile -Value $content
            $metadataFileNameParts = $metadataFile.Name -split '_'
            $metadataFileNameParts[0] =  $metadataFileNameParts[0] -replace $Name, $newName
            $newFileName = $metadataFileNameParts -join '_'
            Rename-Item -Path $metadataFile -NewName $newFileName
        }

        $snippetFilePath = [System.Io.Path]::Join($SourceDirectory, '.doc_gen', 'snippet_files')

        $snippetFiles = Get-ChildItem -Path $snippetFilePath -Filter ("$Name" + "_*")
        
        foreach ($snippetFile in $snippetFiles)
        {
            $snippetFileNameParts= $snippetFile.Name -split '_'
            $snippetFileNameParts[0] =  $snippetFileNameParts[0] -replace $Name, $newName
            $newFileName = $snippetFileNameParts -join '_'
            Rename-Item -Path $snippetFile -NewName $newFileName
        }        
    }
}
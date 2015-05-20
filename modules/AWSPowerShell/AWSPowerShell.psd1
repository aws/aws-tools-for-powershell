#
# Module manifest for module 'AWSPowerShell'
#

@{

# Script module or binary module file associated with this manifest
ModuleToProcess = 'AWSPowerShell.dll'

# Version number of this module.
ModuleVersion = '3.0.0.0'

# ID used to uniquely identify this module
GUID = '21f083f2-4c41-4b5d-88ec-7d24c9e88769'

# Author of this module
Author = 'Amazon.com, Inc'

# Company or vendor of this module
CompanyName = 'Amazon.com, Inc'

# Copyright statement for this module
Copyright = 'Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

# Description of the functionality provided by this module
Description = 'The AWS Tools for Windows PowerShell lets developers and administrators manage their AWS services from the Windows PowerShell scripting environment.'

# Minimum version of the Windows PowerShell engine required by this module
PowerShellVersion = '2.0'

# Name of the Windows PowerShell host required by this module
PowerShellHostName = ''

# Minimum version of the Windows PowerShell host required by this module
PowerShellHostVersion = ''

# Minimum version of the .NET Framework required by this module
DotNetFrameworkVersion = ''

# Minimum version of the common language runtime (CLR) required by this module
CLRVersion = ''

# Processor architecture (None, X86, Amd64, IA64) required by this module
ProcessorArchitecture = ''

# Modules that must be imported into the global environment prior to importing this module
RequiredModules = @()

# Assemblies that must be loaded prior to importing this module
RequiredAssemblies = @()

# Script files (.ps1) that are run in the caller's environment prior to importing this module
ScriptsToProcess = @()

# Type files (.ps1xml) to be loaded when importing this module
TypesToProcess = @('AWSPowerShell.TypeExtensions.ps1xml')

# Format files (.ps1xml) to be loaded when importing this module
FormatsToProcess = @('AWSPowerShell.Format.ps1xml')

# Modules to import as nested modules of the module specified in ModuleToProcess
NestedModules = @()

# Functions to export from this module
FunctionsToExport = '*'

# Cmdlets to export from this module
CmdletsToExport = '*'

# Variables to export from this module
VariablesToExport = '*'

# Aliases to export from this module
AliasesToExport = '*'

# List of all modules packaged with this module
ModuleList = @()

# List of all files packaged with this module
FileList =	'.\AWSPowerShell.dll-Help.xml'

# Private data to pass to the module specified in ModuleToProcess
PrivateData = @{

    PSData = @{
        LicenseUri = 'http://docs.aws.amazon.com/powershell/latest/reference/License.html'
        ProjectUri = 'http://aws.amazon.com/powershell/'
    }

}

}

# Auto-generated argument completers for parameters of SDK ConstantClass-derived type used in cmdlets.
# Do not modify this file; it may be overwritten during version upgrades.

$psMajorVersion = $PSVersionTable.PSVersion.Major
if ($psMajorVersion -eq 2) 
{ 
	Write-Verbose "Dynamic argument completion not supported in PowerShell version 2; skipping load."
	return 
}

# PowerShell's native Register-ArgumentCompleter cmdlet is available on v5.0 or higher. For lower
# version, we can use the version in the TabExpansion++ module if installed.
$registrationCmdletAvailable = ($psMajorVersion -ge 5) -Or !((Get-Command Register-ArgumentCompleter -ea Ignore) -eq $null)

# internal function to perform the registration using either cmdlet or manipulation
# of the options table
function _awsArgumentCompleterRegistration()
{
    param
    (
        [scriptblock]$scriptBlock,
        [hashtable]$param2CmdletsMap
    )

    if ($registrationCmdletAvailable)
    {
        foreach ($paramName in $param2CmdletsMap.Keys)
        {
             $args = @{
                "ScriptBlock" = $scriptBlock
                "Parameter" = $paramName
            }

            $cmdletNames = $param2CmdletsMap[$paramName]
            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                $args["Command"] = $cmdletNames
            }

            Register-ArgumentCompleter @args
        }
    }
    else
    {
        if (-not $global:options) { $global:options = @{ CustomArgumentCompleters = @{ }; NativeArgumentCompleters = @{ } } }

        foreach ($paramName in $param2CmdletsMap.Keys)
        {
            $cmdletNames = $param2CmdletsMap[$paramName]

            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                foreach ($cn in $cmdletNames)
                {
                    $fqn =  [string]::Concat($cn, ":", $paramName)
                    $global:options['CustomArgumentCompleters'][$fqn] = $scriptBlock
                }
            }
            else
            {
                $global:options['CustomArgumentCompleters'][$paramName] = $scriptBlock
            }
        }

        $function:tabexpansion2 = $function:tabexpansion2 -replace 'End\r\n{', 'End { if ($null -ne $options) { $options += $global:options} else {$options = $global:options}'
    }
}

# To allow for same-name parameters of different ConstantClass-derived types 
# each completer function checks on command name concatenated with parameter name.
# Additionally, the standard code pattern for completers is to pipe through 
# sort-object after filtering against $wordToComplete but we omit this as our members 
# are already sorted.

# Argument completions for service Amazon Location Service Routes V2


$GEOR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.GeoRoutes.DayOfWeek
        {
            ($_ -eq "Get-GEOROptimizedWaypoint/From_DayOfWeek") -Or
            ($_ -eq "Get-GEOROptimizedWaypoint/To_DayOfWeek")
        }
        {
            $v = "Friday","Monday","Saturday","Sunday","Thursday","Tuesday","Wednesday"
            break
        }

        # Amazon.GeoRoutes.GeometryFormat
        {
            ($_ -eq "Get-GEORIsoline/IsolineGeometryFormat") -Or
            ($_ -eq "Get-GEORRoute/LegGeometryFormat") -Or
            ($_ -eq "Get-GEORSnappedRoad/SnappedGeometryFormat")
        }
        {
            $v = "FlexiblePolyline","Simple"
            break
        }

        # Amazon.GeoRoutes.IsolineEngineType
        {
            ($_ -eq "Get-GEORIsoline/Car_EngineType") -Or
            ($_ -eq "Get-GEORIsoline/Scooter_EngineType") -Or
            ($_ -eq "Get-GEORIsoline/Truck_EngineType")
        }
        {
            $v = "Electric","InternalCombustion","PluginHybrid"
            break
        }

        # Amazon.GeoRoutes.IsolineOptimizationObjective
        "Get-GEORIsoline/OptimizeIsolineFor"
        {
            $v = "AccurateCalculation","BalancedCalculation","FastCalculation"
            break
        }

        # Amazon.GeoRoutes.IsolineTravelMode
        "Get-GEORIsoline/TravelMode"
        {
            $v = "Car","Pedestrian","Scooter","Truck"
            break
        }

        # Amazon.GeoRoutes.IsolineTruckType
        "Get-GEORIsoline/Truck_TruckType"
        {
            $v = "LightTruck","StraightTruck","Tractor"
            break
        }

        # Amazon.GeoRoutes.MatchingStrategy
        {
            ($_ -eq "Get-GEORIsoline/DestinationOptions_Matching_Strategy") -Or
            ($_ -eq "Get-GEORRoute/DestinationOptions_Matching_Strategy") -Or
            ($_ -eq "Get-GEORIsoline/OriginOptions_Matching_Strategy") -Or
            ($_ -eq "Get-GEORRoute/OriginOptions_Matching_Strategy")
        }
        {
            $v = "MatchAny","MatchMostSignificantRoad"
            break
        }

        # Amazon.GeoRoutes.MeasurementSystem
        "Get-GEORRoute/InstructionsMeasurementSystem"
        {
            $v = "Imperial","Metric"
            break
        }

        # Amazon.GeoRoutes.RoadSnapTravelMode
        "Get-GEORSnappedRoad/TravelMode"
        {
            $v = "Car","Pedestrian","Scooter","Truck"
            break
        }

        # Amazon.GeoRoutes.RouteEngineType
        {
            ($_ -eq "Get-GEORRoute/Car_EngineType") -Or
            ($_ -eq "Get-GEORRoute/Scooter_EngineType") -Or
            ($_ -eq "Get-GEORRoute/Truck_EngineType")
        }
        {
            $v = "Electric","InternalCombustion","PluginHybrid"
            break
        }

        # Amazon.GeoRoutes.RouteMatrixTravelMode
        "Get-GEORRouteMatrix/TravelMode"
        {
            $v = "Car","Pedestrian","Scooter","Truck"
            break
        }

        # Amazon.GeoRoutes.RouteMatrixTruckType
        "Get-GEORRouteMatrix/Truck_TruckType"
        {
            $v = "LightTruck","StraightTruck","Tractor"
            break
        }

        # Amazon.GeoRoutes.RouteTollVehicleCategory
        "Get-GEORRoute/Tolls_VehicleCategory"
        {
            $v = "Minibus"
            break
        }

        # Amazon.GeoRoutes.RouteTravelMode
        "Get-GEORRoute/TravelMode"
        {
            $v = "Car","Pedestrian","Scooter","Truck"
            break
        }

        # Amazon.GeoRoutes.RouteTravelStepType
        "Get-GEORRoute/TravelStepType"
        {
            $v = "Default","TurnByTurn"
            break
        }

        # Amazon.GeoRoutes.RouteTruckType
        "Get-GEORRoute/Truck_TruckType"
        {
            $v = "LightTruck","StraightTruck","Tractor"
            break
        }

        # Amazon.GeoRoutes.RoutingObjective
        {
            ($_ -eq "Get-GEORIsoline/OptimizeRoutingFor") -Or
            ($_ -eq "Get-GEORRoute/OptimizeRoutingFor") -Or
            ($_ -eq "Get-GEORRouteMatrix/OptimizeRoutingFor")
        }
        {
            $v = "FastestRoute","ShortestRoute"
            break
        }

        # Amazon.GeoRoutes.SideOfStreetMatchingStrategy
        {
            ($_ -eq "Get-GEORIsoline/DestinationOptions_SideOfStreet_UseWith") -Or
            ($_ -eq "Get-GEORRoute/DestinationOptions_SideOfStreet_UseWith") -Or
            ($_ -eq "Get-GEORIsoline/OriginOptions_SideOfStreet_UseWith") -Or
            ($_ -eq "Get-GEORRoute/OriginOptions_SideOfStreet_UseWith") -Or
            ($_ -eq "Get-GEOROptimizedWaypoint/SideOfStreet_UseWith")
        }
        {
            $v = "AnyStreet","DividedStreetOnly"
            break
        }

        # Amazon.GeoRoutes.TrafficUsage
        {
            ($_ -eq "Get-GEORIsoline/Traffic_Usage") -Or
            ($_ -eq "Get-GEOROptimizedWaypoint/Traffic_Usage") -Or
            ($_ -eq "Get-GEORRoute/Traffic_Usage") -Or
            ($_ -eq "Get-GEORRouteMatrix/Traffic_Usage")
        }
        {
            $v = "IgnoreTrafficData","UseTrafficData"
            break
        }

        # Amazon.GeoRoutes.WaypointOptimizationSequencingObjective
        "Get-GEOROptimizedWaypoint/OptimizeSequencingFor"
        {
            $v = "FastestRoute","ShortestRoute"
            break
        }

        # Amazon.GeoRoutes.WaypointOptimizationServiceTimeTreatment
        "Get-GEOROptimizedWaypoint/Driver_TreatServiceTimeAs"
        {
            $v = "Rest","Work"
            break
        }

        # Amazon.GeoRoutes.WaypointOptimizationTravelMode
        "Get-GEOROptimizedWaypoint/TravelMode"
        {
            $v = "Car","Pedestrian","Scooter","Truck"
            break
        }

        # Amazon.GeoRoutes.WaypointOptimizationTruckType
        "Get-GEOROptimizedWaypoint/Truck_TruckType"
        {
            $v = "StraightTruck","Tractor"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GEOR_map = @{
    "Car_EngineType"=@("Get-GEORIsoline","Get-GEORRoute")
    "DestinationOptions_Matching_Strategy"=@("Get-GEORIsoline","Get-GEORRoute")
    "DestinationOptions_SideOfStreet_UseWith"=@("Get-GEORIsoline","Get-GEORRoute")
    "Driver_TreatServiceTimeAs"=@("Get-GEOROptimizedWaypoint")
    "From_DayOfWeek"=@("Get-GEOROptimizedWaypoint")
    "InstructionsMeasurementSystem"=@("Get-GEORRoute")
    "IsolineGeometryFormat"=@("Get-GEORIsoline")
    "LegGeometryFormat"=@("Get-GEORRoute")
    "OptimizeIsolineFor"=@("Get-GEORIsoline")
    "OptimizeRoutingFor"=@("Get-GEORIsoline","Get-GEORRoute","Get-GEORRouteMatrix")
    "OptimizeSequencingFor"=@("Get-GEOROptimizedWaypoint")
    "OriginOptions_Matching_Strategy"=@("Get-GEORIsoline","Get-GEORRoute")
    "OriginOptions_SideOfStreet_UseWith"=@("Get-GEORIsoline","Get-GEORRoute")
    "Scooter_EngineType"=@("Get-GEORIsoline","Get-GEORRoute")
    "SideOfStreet_UseWith"=@("Get-GEOROptimizedWaypoint")
    "SnappedGeometryFormat"=@("Get-GEORSnappedRoad")
    "To_DayOfWeek"=@("Get-GEOROptimizedWaypoint")
    "Tolls_VehicleCategory"=@("Get-GEORRoute")
    "Traffic_Usage"=@("Get-GEORIsoline","Get-GEOROptimizedWaypoint","Get-GEORRoute","Get-GEORRouteMatrix")
    "TravelMode"=@("Get-GEORIsoline","Get-GEOROptimizedWaypoint","Get-GEORRoute","Get-GEORRouteMatrix","Get-GEORSnappedRoad")
    "TravelStepType"=@("Get-GEORRoute")
    "Truck_EngineType"=@("Get-GEORIsoline","Get-GEORRoute")
    "Truck_TruckType"=@("Get-GEORIsoline","Get-GEOROptimizedWaypoint","Get-GEORRoute","Get-GEORRouteMatrix")
}

_awsArgumentCompleterRegistration $GEOR_Completers $GEOR_map

$GEOR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.GEOR.$($commandName.Replace('-', ''))Cmdlet]"
    if (-not $cmdletType) {
        return
    }
    $awsCmdletAttribute = $cmdletType.GetCustomAttributes([Amazon.PowerShell.Common.AWSCmdletAttribute], $false)
    if (-not $awsCmdletAttribute) {
        return
    }
    $type = $awsCmdletAttribute.SelectReturnType
    if (-not $type) {
        return
    }

    $splitSelect = $wordToComplete -Split '\.'
    $splitSelect | Select-Object -First ($splitSelect.Length - 1) | ForEach-Object {
        $propertyName = $_
        $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')) | Where-Object { $_.Name -ieq $propertyName }
        if ($properties.Length -ne 1) {
            break
        }
        $type = $properties.PropertyType
        $prefix += "$($properties.Name)."

        $asEnumerableType = $type.GetInterface('System.Collections.Generic.IEnumerable`1')
        if ($asEnumerableType -and $type -ne [System.String]) {
            $type =  $asEnumerableType.GetGenericArguments()[0]
        }
    }

    $v = @( '*' )
    $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')).Name | Sort-Object
    if ($properties) {
        $v += ($properties | ForEach-Object { $prefix + $_ })
    }
    $parameters = $cmdletType.GetProperties(('Instance', 'Public')) | Where-Object { $_.GetCustomAttributes([System.Management.Automation.ParameterAttribute], $true) } | Select-Object -ExpandProperty Name | Sort-Object
    if ($parameters) {
        $v += ($parameters | ForEach-Object { "^$_" })
    }

    $v |
        Where-Object { $_ -match "^$([System.Text.RegularExpressions.Regex]::Escape($wordToComplete)).*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GEOR_SelectMap = @{
    "Select"=@("Get-GEORIsoline",
               "Get-GEORRouteMatrix",
               "Get-GEORRoute",
               "Get-GEOROptimizedWaypoint",
               "Get-GEORSnappedRoad")
}

_awsArgumentCompleterRegistration $GEOR_SelectCompleters $GEOR_SelectMap


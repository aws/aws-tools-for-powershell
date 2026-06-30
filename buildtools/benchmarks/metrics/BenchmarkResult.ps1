<#
.Synopsis
    Contract for a single benchmark measurement.
.Description
    A benchmark function returns one or more BenchmarkResult objects. The constructor requires every
    field, so a result cannot be emitted half-formed. Property names match the Catapult
    PerformanceTestResults schema and serialize directly via ConvertTo-Json.
#>
class BenchmarkResult {
    [string]   $name
    [string]   $description
    [long]     $date
    [string]   $unit
    [double[]] $measurements
    [object[]] $dimensions

    BenchmarkResult(
        [string]   $name,
        [string]   $description,
        [long]     $date,
        [string]   $unit,
        [double[]] $measurements,
        [object[]] $dimensions
    ) {
        $this.name = $name
        $this.description = $description
        $this.date = $date
        $this.unit = $unit
        $this.measurements = $measurements
        # @() keeps an empty or single-element list serializing as a JSON array, not a bare object.
        $this.dimensions = @($dimensions)
    }
}

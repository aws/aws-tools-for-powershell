BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()

    $script:collectionName = "pstest-" + [DateTime]::Now.ToFileTime()
    $script:geofenceId = "pstestId-" + [DateTime]::Now.ToFileTime()

    $script:geofenceGeometry = @(
        ,@(
            @(
                40.74746187192143,
                -73.98580134229194
            ),
            @(
                40.749445098931844,
                -73.9831835062934
            ),
            @(
                40.74671408244781,
                -73.98189604596625
            ),
            @(
                40.74746187192143,
                -73.98580134229194
            )
        )
    )

}

AfterAll {
    $helper.AfterAll()
}

Describe -Tag "Smoke","Disabled" "LocationService" {

    Context "Geofencing" {

        It "Can create a geofence collection " {

            New-LOCGeofenceCollection -CollectionName $script:collectionName
        
            Get-LOCGeofenceCollection -CollectionName $script:collectionName | Should -Not -Be $null
        }

        It "Can create a geofence " {
            Set-LOCGeofence -CollectionName $script:collectionName -GeofenceId $script:geofenceId -Geometry_Polygon $script:geofenceGeometry
        }

        It "Can get a geofence" {
            $getResponse = Get-LOCGeofence -CollectionName $script:collectionName -GeofenceId $script:geofenceId

            $getResponse.Geometry.Polygon.Count | Should -Be 1
            $getResponse.Geometry.Polygon[0].Count | Should -Be 4
 
            for ($i=0; $i -lt $getResponse.Geometry.Polygon[0].Count; $i++) {
                $getResponse.Geometry.Polygon[0][$i][0] | Should -Be $script:geofenceGeometry[0][$i][0]
                $getResponse.Geometry.Polygon[0][$i][1] | Should -Be $script:geofenceGeometry[0][$i][1]
            }
        }

        It "Can delete a geofence collection" {
            Remove-LOCGeofenceCollection -CollectionName $script:collectionName -Force

            $collections = Get-LOCGeofenceCollectionList | select -ExpandProperty CollectionName
            $collections -contains $script:collectionName | Should -Be $false
        }
    }
}

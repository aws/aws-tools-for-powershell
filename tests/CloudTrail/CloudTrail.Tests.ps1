Describe -Tag "Smoke" "CloudTrail" {
    Context "Trails" {

        It "Can list trails" {
            $trails = Get-CTTrail
            if ($trails) {
                $trails.Count | Should BeGreaterThan 0
            }
        }

        It "Can get a single trail by name" {
            $trails = Get-CTTrail
            if ($trails) {
                $trail = Get-CTTrail -TrailNameList $trails[0].Name
                $trail | Should Not Be $null
                $trail.Name | Should Be $trails[0].Name
            }
        }

        It "Can get all trails by name" {
            $trailNames = Get-CTTrail | select -ExpandProperty Name
            if ($trailNames) {
                $trails = Get-CTTrail -TrailNameList $trailNames
                $trails | Should Not Be $null
                $trails.Count | Should Be $trailNames.Count
            }
        }
    }
}

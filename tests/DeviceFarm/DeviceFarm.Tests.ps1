Describe -Tag "Smoke","Disabled" "DeviceFarm" {
    Context "Projects" {
        It "Can list projects" {
            $projects = Get-DFProjectList
            if ($projects) {
                $projects.Count | Should BeGreaterThan 0

                $project = Get-DFProject -Arn $projects[0].Arn

                $project.Name | Should Be $projects[0].Name
            }
        }
    }
}
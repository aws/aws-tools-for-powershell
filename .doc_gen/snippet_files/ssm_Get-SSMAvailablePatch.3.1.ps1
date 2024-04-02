Get-SSMAvailablePatch | Where-Object ReleaseDate -ge (Get-Date).AddDays(-20) | Where-Object Product -eq "WindowsServer2019" | Select-Object ReleaseDate, Product, Title
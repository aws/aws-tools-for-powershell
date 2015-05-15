# PSUnit: Setting the console output window size and color
$a = (Get-Host).UI.RawUI
$b = $a.BufferSize
$b.Width = 300
$b.Height = 600
$a.BufferSize = $b

$b = $a.WindowSize
$c = $a.MaxWindowSize
$b.Width = $c.Width
$b.Height = $c.Height
$a.WindowSize = $b

$a.BackgroundColor = "Black"
$a.ForegroundColor = "DarkGreen"

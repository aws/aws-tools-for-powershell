$UpdateFSXWinConfig = [Amazon.FSx.Model.UpdateFileSystemWindowsConfiguration]::new()
	$UpdateFSXWinConfig.AutomaticBackupRetentionDays = 35
	Update-FSXFileSystem -FileSystemId $FSX.FileSystemId -WindowsConfiguration $UpdateFSXWinConfig
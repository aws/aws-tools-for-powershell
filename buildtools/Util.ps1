function Invoke-WithExponentialBackoff {
  [CmdletBinding()]
  param (
    [Parameter(Mandatory)]
    [scriptblock]$ScriptBlock,
    
    [int]$MaxAttempts = 10,
    
    [int]$InitialDelaySeconds = 30,
    
    [int]$MaxDelaySeconds = 300,
    
    [double]$BackoffMultiplier = 2.0,
    
    [string]$ErrorMessage = "Operation failed after maximum retry attempts"
  )
  
  for ($attempt = 1; $attempt -le $MaxAttempts; $attempt++) {
    try {
      return & $ScriptBlock
    }
    catch {
      if ($attempt -eq $MaxAttempts) {
        throw "$ErrorMessage. $_"
      }
      
      $delay = [Math]::Min(
        $InitialDelaySeconds * [Math]::Pow($BackoffMultiplier, $attempt - 1),
        $MaxDelaySeconds
      )
      
      Write-Host "Attempt $attempt failed. Retrying in $delay seconds... $_"
      Start-Sleep -Seconds $delay
    }
  }
}
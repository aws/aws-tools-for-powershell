Get-RDSOrderableDBInstanceOption `
  -Engine aurora-postgresql `
  -EngineVersion 13.6 `
  -Region us-east-1  | `
Format-Table DBInstanceClass, SupportedEngineModes
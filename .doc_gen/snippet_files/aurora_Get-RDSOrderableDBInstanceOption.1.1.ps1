Get-RDSOrderableDBInstanceOption `
  -Engine aurora-postgresql `
  -DBInstanceClass db.r5.large `
  -Region us-east-1  | `
Format-Table EngineVersion, SupportedEngineModes
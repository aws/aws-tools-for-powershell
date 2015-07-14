function Test.DS.GetDirectoryLimits
{
    $limits = Get-DSDirectoryLimit
    Assert $limits -IsNotNull
}

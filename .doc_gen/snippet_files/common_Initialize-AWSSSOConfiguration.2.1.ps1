$params = @{
      ProfileName = 'sso-test-profile'
      AccountId = '012345678901'
      RoleName = 'ReadOnlyAccess'
      SessionName = 'sso-session-d-xxxxxxxxxx'
      StartUrl = 'https://d-xxxxxxxxxx.awsapps.com/start'
      SSORegion = 'us-east-1'
      };
      Initialize-AWSSSOConfiguration @params
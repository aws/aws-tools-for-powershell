$params = @{
      SessionName = 'ssosessioneast'
      StartUrl = 'https://d-xxxxxxxxxx.awsapps.com/start/'
      SSORegion = 'us-east-1'
      RegistrationScopes = 'sso:account:access'
      };
      Set-AWSSSOSessionConfiguration @params
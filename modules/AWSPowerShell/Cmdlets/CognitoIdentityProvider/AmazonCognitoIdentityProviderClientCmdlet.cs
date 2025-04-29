/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    [AWSClientCmdlet("Amazon Cognito Identity Provider", "CGIP", "2016-04-18", "CognitoIdentityProvider")]
    public abstract partial class AmazonCognitoIdentityProviderClientCmdlet : ServiceCmdlet
    {
        protected IAmazonCognitoIdentityProvider Client { get; private set; }
        
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public AmazonCognitoIdentityProviderConfig ClientConfig
        {
            get
            {
                return base._ClientConfig as AmazonCognitoIdentityProviderConfig;
            }
            set
            {
                base._ClientConfig = value;
            }
        }
        
        protected IAmazonCognitoIdentityProvider CreateClient(AWSCredentials credentials, RegionEndpoint region)
        {
            var config = this.ClientConfig ?? new AmazonCognitoIdentityProviderConfig();
            if (region != null) config.RegionEndpoint = region;
            if (!string.IsNullOrEmpty(ProfileName))
            {
                config.AWSTokenProvider = new ProfileTokenProvider(ProfileName);
            }
            Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);
            this.CustomizeClientConfig(config);
            var client = new AmazonCognitoIdentityProviderClient(credentials, config);
            client.BeforeRequestEvent += RequestEventHandler;
            client.AfterResponseEvent += ResponseEventHandler;
            return client;
        }
        
        protected override void BeginProcessing()
        {
            base.AWSServiceId = AmazonCognitoIdentityProviderConfig.ServiceId.ToString();
            
            base.BeginProcessing();
        }
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            Client = CreateClient(_CurrentCredentials, _RegionEndpoint);
        }
    }
    
    [AWSClientCmdlet("Amazon Cognito Identity Provider", "CGIP", "2016-04-18", "CognitoIdentityProvider")]
    public abstract partial class AnonymousAmazonCognitoIdentityProviderClientCmdlet : AnonymousServiceCmdlet
    {
        protected IAmazonCognitoIdentityProvider Client { get; private set; }
        
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public AmazonCognitoIdentityProviderConfig ClientConfig
        {
            get
            {
                return base._ClientConfig as AmazonCognitoIdentityProviderConfig;
            }
            set
            {
                base._ClientConfig = value;
            }
        }
        
        protected IAmazonCognitoIdentityProvider CreateClient(RegionEndpoint region)
        {
            var config = this.ClientConfig ?? new AmazonCognitoIdentityProviderConfig();
            if (region != null) config.RegionEndpoint = region;
            Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);
            this.CustomizeClientConfig(config);
            var client = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials(), config);
            client.BeforeRequestEvent += RequestEventHandler;
            client.AfterResponseEvent += ResponseEventHandler;
            return client;
        }
        
        protected override void BeginProcessing()
        {
            base.AWSServiceId = AmazonCognitoIdentityProviderConfig.ServiceId.ToString();
            
            base.BeginProcessing();
        }
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            Client = CreateClient(_RegionEndpoint);
        }
    }
}

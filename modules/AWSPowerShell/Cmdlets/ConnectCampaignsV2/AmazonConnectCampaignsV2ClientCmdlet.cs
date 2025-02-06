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
using Amazon.ConnectCampaignsV2;
using Amazon.ConnectCampaignsV2.Model;

namespace Amazon.PowerShell.Cmdlets.CCS2
{
    [AWSClientCmdlet("AmazonConnectCampaignServiceV2", "CCS2", "2024-04-23", "ConnectCampaignsV2")]
    public abstract partial class AmazonConnectCampaignsV2ClientCmdlet : ServiceCmdlet
    {
        protected IAmazonConnectCampaignsV2 Client { get; private set; }
        
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public AmazonConnectCampaignsV2Config ClientConfig
        {
            get
            {
                return base._ClientConfig as AmazonConnectCampaignsV2Config;
            }
            set
            {
                base._ClientConfig = value;
            }
        }
        
        protected IAmazonConnectCampaignsV2 CreateClient(AWSCredentials credentials, RegionEndpoint region)
        {
            var config = this.ClientConfig ?? new AmazonConnectCampaignsV2Config();
            if (region != null) config.RegionEndpoint = region;
            Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);
            this.CustomizeClientConfig(config);
            var client = new AmazonConnectCampaignsV2Client(credentials, config);
            client.BeforeRequestEvent += RequestEventHandler;
            client.AfterResponseEvent += ResponseEventHandler;
            return client;
        }
        
        protected override void BeginProcessing()
        {
            base.AWSServiceId = AmazonConnectCampaignsV2Config.ServiceId.ToString();
            
            base.BeginProcessing();
        }
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            Client = CreateClient(_CurrentCredentials, _RegionEndpoint);
        }
    }
}

/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Route53RecoveryControlConfig;
using Amazon.Route53RecoveryControlConfig.Model;

namespace Amazon.PowerShell.Cmdlets.R53RC
{
    [AWSClientCmdlet("AWS Route53 Recovery Control Config", "R53RC", "2020-11-02", "Route53RecoveryControlConfig")]
    public abstract partial class AmazonRoute53RecoveryControlConfigClientCmdlet : ServiceCmdlet
    {
        protected IAmazonRoute53RecoveryControlConfig Client { get; private set; }
        
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public AmazonRoute53RecoveryControlConfigConfig ClientConfig
        {
            get
            {
                return base._ClientConfig as AmazonRoute53RecoveryControlConfigConfig;
            }
            set
            {
                base._ClientConfig = value;
            }
        }
        
        protected IAmazonRoute53RecoveryControlConfig CreateClient(AWSCredentials credentials, RegionEndpoint region)
        {
            var config = this.ClientConfig ?? new AmazonRoute53RecoveryControlConfigConfig();
            if (region != null) config.RegionEndpoint = region;
            Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);
            this.CustomizeClientConfig(config);
            var client = new AmazonRoute53RecoveryControlConfigClient(credentials, config);
            client.BeforeRequestEvent += RequestEventHandler;
            client.AfterResponseEvent += ResponseEventHandler;
            return client;
        }
        
        protected override void BeginProcessing()
        {
            base.AWSServiceId = AmazonRoute53RecoveryControlConfigConfig.ServiceId.ToString();
            
            base.BeginProcessing();
        }
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            Client = CreateClient(_CurrentCredentials, _RegionEndpoint);
        }
    }
}

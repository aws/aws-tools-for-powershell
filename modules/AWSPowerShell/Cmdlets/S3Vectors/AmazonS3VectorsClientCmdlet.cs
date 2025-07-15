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
using Amazon.S3Vectors;
using Amazon.S3Vectors.Model;

namespace Amazon.PowerShell.Cmdlets.S3V
{
    [AWSClientCmdlet("Amazon S3 Vectors", "S3V", "2025-07-15", "S3Vectors")]
    public abstract partial class AmazonS3VectorsClientCmdlet : ServiceCmdlet
    {
        protected IAmazonS3Vectors Client { get; private set; }
        
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public AmazonS3VectorsConfig ClientConfig
        {
            get
            {
                return base._ClientConfig as AmazonS3VectorsConfig;
            }
            set
            {
                base._ClientConfig = value;
            }
        }
        
        protected IAmazonS3Vectors CreateClient(AWSCredentials credentials, RegionEndpoint region)
        {
            var config = this.ClientConfig ?? new AmazonS3VectorsConfig();
            if (region != null) config.RegionEndpoint = region;
            Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);
            this.CustomizeClientConfig(config);
            var client = new AmazonS3VectorsClient(credentials, config);
            client.BeforeRequestEvent += RequestEventHandler;
            client.AfterResponseEvent += ResponseEventHandler;
            return client;
        }
        
        protected override void BeginProcessing()
        {
            base.AWSServiceId = AmazonS3VectorsConfig.ServiceId.ToString();
            
            base.BeginProcessing();
        }
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            Client = CreateClient(_CurrentCredentials, _RegionEndpoint);
        }
    }
}

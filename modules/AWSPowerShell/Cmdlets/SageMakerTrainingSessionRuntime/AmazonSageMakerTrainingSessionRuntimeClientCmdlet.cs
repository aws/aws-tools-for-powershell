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
using Amazon.SageMakerTrainingSessionRuntime;
using Amazon.SageMakerTrainingSessionRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.SMTSR
{
    [AWSClientCmdlet("SageMaker Training Session Runtime", "SMTSR", "2025-02-10", "SageMakerTrainingSessionRuntime")]
    public abstract partial class AmazonSageMakerTrainingSessionRuntimeClientCmdlet : ServiceCmdlet
    {
        protected IAmazonSageMakerTrainingSessionRuntime Client { get; private set; }
        
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public AmazonSageMakerTrainingSessionRuntimeConfig ClientConfig
        {
            get
            {
                return base._ClientConfig as AmazonSageMakerTrainingSessionRuntimeConfig;
            }
            set
            {
                base._ClientConfig = value;
            }
        }
        
        protected IAmazonSageMakerTrainingSessionRuntime CreateClient(AWSCredentials credentials, RegionEndpoint region)
        {
            var config = this.ClientConfig ?? new AmazonSageMakerTrainingSessionRuntimeConfig();
            if (region != null) config.RegionEndpoint = region;
            if (!string.IsNullOrEmpty(ProfileName))
            {
                config.AWSTokenProvider = new ProfileTokenProvider(ProfileName);
            }
            Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);
            this.CustomizeClientConfig(config);
            var client = new AmazonSageMakerTrainingSessionRuntimeClient(credentials, config);
            client.BeforeRequestEvent += RequestEventHandler;
            client.AfterResponseEvent += ResponseEventHandler;
            return client;
        }
        
        protected override void BeginProcessing()
        {
            base.AWSServiceId = AmazonSageMakerTrainingSessionRuntimeConfig.ServiceId.ToString();
            
            base.BeginProcessing();
        }
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            Client = CreateClient(_CurrentCredentials, _RegionEndpoint);
        }
    }
}

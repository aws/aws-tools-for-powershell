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
using Amazon.SagemakerEdgeManager;
using Amazon.SagemakerEdgeManager.Model;

namespace Amazon.PowerShell.Cmdlets.SME
{
    [AWSClientCmdlet("Amazon Sagemaker Edge Manager", "SME", "2020-09-23", "SagemakerEdgeManager")]
    public abstract partial class AmazonSagemakerEdgeManagerClientCmdlet : ServiceCmdlet
    {
        protected IAmazonSagemakerEdgeManager Client { get; private set; }
        protected IAmazonSagemakerEdgeManager CreateClient(AWSCredentials credentials, RegionEndpoint region)
        {
            var config = new AmazonSagemakerEdgeManagerConfig { RegionEndpoint = region };
            Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);
            this.CustomizeClientConfig(config);
            var client = new AmazonSagemakerEdgeManagerClient(credentials, config);
            client.BeforeRequestEvent += RequestEventHandler;
            client.AfterResponseEvent += ResponseEventHandler;
            return client;
        }
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            Client = CreateClient(_CurrentCredentials, _RegionEndpoint);
        }
    }
}

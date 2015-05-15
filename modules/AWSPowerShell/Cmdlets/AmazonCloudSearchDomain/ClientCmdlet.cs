/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudSearchDomain;
using Amazon.CloudSearchDomain.Model;

namespace Amazon.PowerShell.Cmdlets.CSD
{
    [AWSClientCmdlet("Amazon CloudSearchDomain", "CSD", "2013-01-01")]
    public abstract class AmazonCloudSearchDomainClientCmdlet : ServiceCmdlet
    {        
        protected IAmazonCloudSearchDomain CreateClient(string serviceUrl)
        {
            var config = new AmazonCloudSearchDomainConfig
            {
                ServiceURL = serviceUrl
            };
            Amazon.PowerShell.Utils.Common.PopulateConfig(this, config);

            var client = new AmazonCloudSearchDomainClient(this.CurrentCredentials, config);
            client.BeforeRequestEvent += RequestEventHandler;
            client.AfterResponseEvent += ResponseEventHandler;
            return client;
        }
    }
}

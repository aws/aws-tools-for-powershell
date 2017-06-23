/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.AWSMarketplaceMetering;
using Amazon.AWSMarketplaceMetering.Model;

namespace Amazon.PowerShell.Cmdlets.MM
{
    /// <summary>
    /// ResolveCustomer is called by a SaaS application during the registration process. When
    /// a buyer visits your website during the registration process, the buyer submits a registration
    /// token through their browser. The registration token is resolved through this API to
    /// obtain a CustomerIdentifier and product code.
    /// </summary>
    [Cmdlet("Get", "MMCustomerMetadata")]
    [OutputType("Amazon.AWSMarketplaceMetering.Model.ResolveCustomerResponse")]
    [AWSCmdlet("Invokes the ResolveCustomer operation against AWS Marketplace Metering.", Operation = new[] {"ResolveCustomer"})]
    [AWSCmdletOutput("Amazon.AWSMarketplaceMetering.Model.ResolveCustomerResponse",
        "This cmdlet returns a Amazon.AWSMarketplaceMetering.Model.ResolveCustomerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMMCustomerMetadataCmdlet : AmazonAWSMarketplaceMeteringClientCmdlet, IExecutor
    {
        
        #region Parameter RegistrationToken
        /// <summary>
        /// <para>
        /// <para>When a buyer visits your website during the registration process, the buyer submits
        /// a registration token through the browser. The registration token is resolved to obtain
        /// a CustomerIdentifier and product code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RegistrationToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.RegistrationToken = this.RegistrationToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.AWSMarketplaceMetering.Model.ResolveCustomerRequest();
            
            if (cmdletContext.RegistrationToken != null)
            {
                request.RegistrationToken = cmdletContext.RegistrationToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.AWSMarketplaceMetering.Model.ResolveCustomerResponse CallAWSServiceOperation(IAmazonAWSMarketplaceMetering client, Amazon.AWSMarketplaceMetering.Model.ResolveCustomerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Metering", "ResolveCustomer");
            #if DESKTOP
            return client.ResolveCustomer(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ResolveCustomerAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String RegistrationToken { get; set; }
        }
        
    }
}

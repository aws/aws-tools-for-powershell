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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Get the information about an origin access identity.
    /// </summary>
    [Cmdlet("Get", "CFCloudFrontOriginAccessIdentity")]
    [OutputType("Amazon.CloudFront.Model.CloudFrontOriginAccessIdentity")]
    [AWSCmdlet("Invokes the GetCloudFrontOriginAccessIdentity operation against Amazon CloudFront.", Operation = new[] {"GetCloudFrontOriginAccessIdentity"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CloudFrontOriginAccessIdentity",
        "This cmdlet returns a CloudFrontOriginAccessIdentity object.",
        "The service call response (type GetCloudFrontOriginAccessIdentityResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: ETag (type String)"
    )]
    public class GetCFCloudFrontOriginAccessIdentityCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// The identity's id.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String Id { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Id = this.Id;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetCloudFrontOriginAccessIdentityRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetCloudFrontOriginAccessIdentity(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CloudFrontOriginAccessIdentity;
                notes = new Dictionary<string, object>();
                notes["ETag"] = response.ETag;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String Id { get; set; }
        }
        
    }
}

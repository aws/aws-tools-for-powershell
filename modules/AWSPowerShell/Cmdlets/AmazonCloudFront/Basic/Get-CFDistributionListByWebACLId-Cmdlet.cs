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
    /// List the distributions that are associated with a specified AWS WAF web ACL.
    /// </summary>
    [Cmdlet("Get", "CFDistributionListByWebACLId")]
    [OutputType("Amazon.CloudFront.Model.DistributionList")]
    [AWSCmdlet("Calls the Amazon CloudFront ListDistributionsByWebACLId API operation.", Operation = new[] {"ListDistributionsByWebACLId"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.DistributionList",
        "This cmdlet returns a DistributionList object.",
        "The service call response (type Amazon.CloudFront.Model.ListDistributionsByWebACLIdResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFDistributionListByWebACLIdCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter WebACLId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS WAF web ACL that you want to list the associated distributions.
        /// If you specify "null" for the ID, the request returns a list of the distributions
        /// that aren't associated with a web ACL. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WebACLId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use <code>Marker</code> and <code>MaxItems</code> to control pagination of results.
        /// If you have more than <code>MaxItems</code> distributions that satisfy the request,
        /// the response includes a <code>NextMarker</code> element. To get the next page of results,
        /// submit another request. For the value of <code>Marker</code>, specify the value of
        /// <code>NextMarker</code> from the last response. (For the first request, omit <code>Marker</code>.)
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of distributions that you want CloudFront to return in the response
        /// body. The maximum and default values are both 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
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
            
            context.Marker = this.Marker;
            context.MaxItems = this.MaxItem;
            context.WebACLId = this.WebACLId;
            
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
            var request = new Amazon.CloudFront.Model.ListDistributionsByWebACLIdRequest();
            
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItems != null)
            {
                request.MaxItems = cmdletContext.MaxItems;
            }
            if (cmdletContext.WebACLId != null)
            {
                request.WebACLId = cmdletContext.WebACLId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DistributionList;
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
        
        private Amazon.CloudFront.Model.ListDistributionsByWebACLIdResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.ListDistributionsByWebACLIdRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "ListDistributionsByWebACLId");
            try
            {
                #if DESKTOP
                return client.ListDistributionsByWebACLId(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListDistributionsByWebACLIdAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String Marker { get; set; }
            public System.String MaxItems { get; set; }
            public System.String WebACLId { get; set; }
        }
        
    }
}

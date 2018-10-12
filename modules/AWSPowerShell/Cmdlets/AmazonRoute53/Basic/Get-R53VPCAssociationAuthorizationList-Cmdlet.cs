/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets a list of the VPCs that were created by other accounts and that can be associated
    /// with a specified hosted zone because you've submitted one or more <code>CreateVPCAssociationAuthorization</code>
    /// requests. 
    /// 
    ///  
    /// <para>
    /// The response includes a <code>VPCs</code> element with a <code>VPC</code> child element
    /// for each VPC that can be associated with the hosted zone.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53VPCAssociationAuthorizationList")]
    [OutputType("Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 ListVPCAssociationAuthorizations API operation.", Operation = new[] {"ListVPCAssociationAuthorizations"})]
    [AWSCmdletOutput("Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse",
        "This cmdlet returns a Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetR53VPCAssociationAuthorizationListCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone for which you want a list of VPCs that can be associated
        /// with the hosted zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Id")]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para><i>Optional</i>: An integer that specifies the maximum number of VPCs that you want
        /// Amazon Route 53 to return. If you don't specify a value for <code>MaxResults</code>,
        /// Route 53 returns up to 50 VPCs per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.String MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para><i>Optional</i>: If a response includes a <code>NextToken</code> element, there are
        /// more VPCs that can be associated with the specified hosted zone. To get the next page
        /// of results, submit another request, and include the value of <code>NextToken</code>
        /// from the response in the <code>nexttoken</code> parameter in another <code>ListVPCAssociationAuthorizations</code>
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
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
            
            context.HostedZoneId = this.HostedZoneId;
            context.NextToken = this.NextToken;
            context.MaxResults = this.MaxResult;
            
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
            var request = new Amazon.Route53.Model.ListVPCAssociationAuthorizationsRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults;
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
        
        private Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListVPCAssociationAuthorizationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListVPCAssociationAuthorizations");
            try
            {
                #if DESKTOP
                return client.ListVPCAssociationAuthorizations(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListVPCAssociationAuthorizationsAsync(request);
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
            public System.String HostedZoneId { get; set; }
            public System.String NextToken { get; set; }
            public System.String MaxResults { get; set; }
        }
        
    }
}

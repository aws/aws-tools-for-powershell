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
using Amazon.ResourceGroups;
using Amazon.ResourceGroups.Model;

namespace Amazon.PowerShell.Cmdlets.RG
{
    /// <summary>
    /// Returns a list of ARNs of resources that are members of a specified resource group.
    /// </summary>
    [Cmdlet("Get", "RGGroupResourceList")]
    [OutputType("Amazon.ResourceGroups.Model.ListGroupResourcesResponse")]
    [AWSCmdlet("Calls the AWS Resource Groups ListGroupResources API operation.", Operation = new[] {"ListGroupResources"})]
    [AWSCmdletOutput("Amazon.ResourceGroups.Model.ListGroupResourcesResponse",
        "This cmdlet returns a Amazon.ResourceGroups.Model.ListGroupResourcesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRGGroupResourceListCmdlet : AmazonResourceGroupsClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Filters, formatted as ResourceFilter objects, that you want to apply to a ListGroupResources
        /// operation.</para><ul><li><para><code>resource-type</code> - Filter resources by their type. Specify up to five resource
        /// types in the format AWS::ServiceCode::ResourceType. For example, AWS::EC2::Instance,
        /// or AWS::S3::Bucket.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.ResourceGroups.Model.ResourceFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The name of the resource group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("Name")]
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of group member ARNs that are returned in a single call by ListGroupResources,
        /// in paginated output. By default, this number is 50.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The NextToken value that is returned in a paginated ListGroupResources request. To
        /// get the next page of results, run the call again, add the NextToken parameter, and
        /// specify the NextToken value.</para>
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
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.ResourceGroups.Model.ResourceFilter>(this.Filter);
            }
            context.GroupName = this.GroupName;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.ResourceGroups.Model.ListGroupResourcesRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.ResourceGroups.Model.ListGroupResourcesResponse CallAWSServiceOperation(IAmazonResourceGroups client, Amazon.ResourceGroups.Model.ListGroupResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Groups", "ListGroupResources");
            try
            {
                #if DESKTOP
                return client.ListGroupResources(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListGroupResourcesAsync(request);
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
            public List<Amazon.ResourceGroups.Model.ResourceFilter> Filters { get; set; }
            public System.String GroupName { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}

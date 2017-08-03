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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Amazon.ConfigService.IAmazonConfigService.GetDiscoveredResourceCounts
    /// </summary>
    [Cmdlet("Get", "CFGDiscoveredResourceCount")]
    [OutputType("Amazon.ConfigService.Model.ResourceCount")]
    [AWSCmdlet("Invokes the GetDiscoveredResourceCounts operation against AWS Config.", Operation = new[] {"GetDiscoveredResourceCounts"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ResourceCount",
        "This cmdlet returns a collection of ResourceCount objects.",
        "The service call response (type Amazon.ConfigService.Model.GetDiscoveredResourceCountsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String), TotalDiscoveredResources (type System.Int64)"
    )]
    public partial class GetCFGDiscoveredResourceCountCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The comma-separated list that specifies the resource types that you want the AWS Config
        /// to return. For example, (<code>"AWS::EC2::Instance"</code>, <code>"AWS::IAM::User"</code>).</para><para>If a value for <code>resourceTypes</code> is not specified, AWS Config returns all
        /// resource types that AWS Config is recording in the region for your account.</para><note><para>If the configuration recorder is turned off, AWS Config returns an empty list of <a>ResourceCount</a>
        /// objects. If the configuration recorder is not recording a specific resource type (for
        /// example, S3 buckets), that resource type is not returned in the list of <a>ResourceCount</a>
        /// objects.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of <a>ResourceCount</a> objects returned on each page. The default
        /// is 100. You cannot specify a limit greater than 100. If you specify 0, AWS Config
        /// uses the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> string returned on a previous page that you use to get
        /// the next page of results in a paginated response.</para>
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
            
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            if (this.ResourceType != null)
            {
                context.ResourceTypes = new List<System.String>(this.ResourceType);
            }
            
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
            var request = new Amazon.ConfigService.Model.GetDiscoveredResourceCountsRequest();
            
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ResourceTypes != null)
            {
                request.ResourceTypes = cmdletContext.ResourceTypes;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ResourceCounts;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
                notes["TotalDiscoveredResources"] = response.TotalDiscoveredResources;
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
        
        private Amazon.ConfigService.Model.GetDiscoveredResourceCountsResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetDiscoveredResourceCountsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetDiscoveredResourceCounts");
            #if DESKTOP
            return client.GetDiscoveredResourceCounts(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetDiscoveredResourceCountsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> ResourceTypes { get; set; }
        }
        
    }
}

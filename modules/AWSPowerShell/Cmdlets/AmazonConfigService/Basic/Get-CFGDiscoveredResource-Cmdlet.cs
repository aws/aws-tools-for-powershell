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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Accepts a resource type and returns a list of resource identifiers for the resources
    /// of that type. A resource identifier includes the resource type, ID, and (if available)
    /// the custom resource name. The results consist of resources that AWS Config has discovered,
    /// including those that AWS Config is not currently recording. You can narrow the results
    /// to include only resources that have specific resource IDs or a resource name.
    /// 
    ///  <note><para>
    /// You can specify either resource IDs or a resource name but not both in the same request.
    /// </para></note><para>
    /// The response is paginated. By default, AWS Config lists 100 resource identifiers on
    /// each page. You can customize this number with the <code>limit</code> parameter. The
    /// response includes a <code>nextToken</code> string. To get the next page of results,
    /// run the request again and specify the string for the <code>nextToken</code> parameter.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFGDiscoveredResource")]
    [OutputType("Amazon.ConfigService.Model.ResourceIdentifier")]
    [AWSCmdlet("Calls the AWS Config ListDiscoveredResources API operation.", Operation = new[] {"ListDiscoveredResources"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ResourceIdentifier",
        "This cmdlet returns a collection of ResourceIdentifier objects.",
        "The service call response (type Amazon.ConfigService.Model.ListDiscoveredResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCFGDiscoveredResourceCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter IncludeDeletedResource
        /// <summary>
        /// <para>
        /// <para>Specifies whether AWS Config includes deleted resources in the results. By default,
        /// deleted resources are not included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IncludeDeletedResources")]
        public System.Boolean IncludeDeletedResource { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The IDs of only those resources that you want AWS Config to list in the response.
        /// If you do not specify this parameter, AWS Config lists all resources of the specified
        /// type that it has discovered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceIds")]
        public System.String[] ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The custom name of only those resources that you want AWS Config to list in the response.
        /// If you do not specify this parameter, AWS Config lists all resources of the specified
        /// type that it has discovered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ResourceName { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of resources that you want AWS Config to list in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ConfigService.ResourceType")]
        public Amazon.ConfigService.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of resource identifiers returned on each page. The default is 100.
        /// You cannot specify a limit greater than 100. If you specify 0, AWS Config uses the
        /// default.</para>
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
            
            if (ParameterWasBound("IncludeDeletedResource"))
                context.IncludeDeletedResources = this.IncludeDeletedResource;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            if (this.ResourceId != null)
            {
                context.ResourceIds = new List<System.String>(this.ResourceId);
            }
            context.ResourceName = this.ResourceName;
            context.ResourceType = this.ResourceType;
            
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
            var request = new Amazon.ConfigService.Model.ListDiscoveredResourcesRequest();
            
            if (cmdletContext.IncludeDeletedResources != null)
            {
                request.IncludeDeletedResources = cmdletContext.IncludeDeletedResources.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ResourceIds != null)
            {
                request.ResourceIds = cmdletContext.ResourceIds;
            }
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ResourceIdentifiers;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
        
        private Amazon.ConfigService.Model.ListDiscoveredResourcesResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.ListDiscoveredResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "ListDiscoveredResources");
            try
            {
                #if DESKTOP
                return client.ListDiscoveredResources(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListDiscoveredResourcesAsync(request);
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
            public System.Boolean? IncludeDeletedResources { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> ResourceIds { get; set; }
            public System.String ResourceName { get; set; }
            public Amazon.ConfigService.ResourceType ResourceType { get; set; }
        }
        
    }
}

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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Retrieves aggregated statistics about the top URI paths accessed by bot traffic for
    /// a specified web ACL and time window. You can use this operation to analyze which paths
    /// on your web application receive the most bot traffic and identify the specific bots
    /// accessing those paths. The operation supports filtering by bot category, organization,
    /// or name, and allows you to drill down into specific path prefixes to view detailed
    /// URI-level statistics.
    /// </summary>
    [Cmdlet("Get", "WAF2TopPathStatisticsByTraffic")]
    [OutputType("Amazon.WAFV2.Model.GetTopPathStatisticsByTrafficResponse")]
    [AWSCmdlet("Calls the AWS WAF V2 GetTopPathStatisticsByTraffic API operation.", Operation = new[] {"GetTopPathStatisticsByTraffic"}, SelectReturnType = typeof(Amazon.WAFV2.Model.GetTopPathStatisticsByTrafficResponse))]
    [AWSCmdletOutput("Amazon.WAFV2.Model.GetTopPathStatisticsByTrafficResponse",
        "This cmdlet returns an Amazon.WAFV2.Model.GetTopPathStatisticsByTrafficResponse object containing multiple properties."
    )]
    public partial class GetWAF2TopPathStatisticsByTrafficCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BotCategory
        /// <summary>
        /// <para>
        /// <para>Filters the results to include only traffic from bots in the specified category. For
        /// example, you can filter by <c>ai</c> to see only AI crawler traffic, or <c>search_engine</c>
        /// to see only search engine bot traffic. When you apply this filter, the <c>Source</c>
        /// field is populated in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BotCategory { get; set; }
        #endregion
        
        #region Parameter BotName
        /// <summary>
        /// <para>
        /// <para>Filters the results to include only traffic from the specified bot. For example, you
        /// can filter by <c>gptbot</c> or <c>googlebot</c>. When you apply this filter, the <c>Source</c>
        /// field is populated in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BotName { get; set; }
        #endregion
        
        #region Parameter BotOrganization
        /// <summary>
        /// <para>
        /// <para>Filters the results to include only traffic from bots belonging to the specified organization.
        /// For example, you can filter by <c>openai</c> or <c>google</c>. When you apply this
        /// filter, the <c>Source</c> field is populated in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BotOrganization { get; set; }
        #endregion
        
        #region Parameter TimeWindow_EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range from which you want <c>GetSampledRequests</c> to return
        /// a sample of the requests that your Amazon Web Services resource received. You must
        /// specify the times in Coordinated Universal Time (UTC) format. UTC format includes
        /// the special designator, <c>Z</c>. For example, <c>"2016-09-27T14:50Z"</c>. You can
        /// specify any time range in the previous three hours.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? TimeWindow_EndTime { get; set; }
        #endregion
        
        #region Parameter NumberOfTopTrafficBotsPerPath
        /// <summary>
        /// <para>
        /// <para>The maximum number of top bots to include in the statistics for each path. Valid values
        /// are 1 to 10.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? NumberOfTopTrafficBotsPerPath { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>Specifies whether the web ACL is for an Amazon Web Services CloudFront distribution
        /// or for a regional application. A regional application can be an Application Load Balancer,
        /// an AppSync GraphQL API, an Amazon Cognito user pool, an Amazon Web Services App Runner
        /// service, or an Amazon Web Services Verified Access instance.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAFV2.Scope")]
        public Amazon.WAFV2.Scope Scope { get; set; }
        #endregion
        
        #region Parameter TimeWindow_StartTime
        /// <summary>
        /// <para>
        /// <para>The beginning of the time range from which you want <c>GetSampledRequests</c> to return
        /// a sample of the requests that your Amazon Web Services resource received. You must
        /// specify the times in Coordinated Universal Time (UTC) format. UTC format includes
        /// the special designator, <c>Z</c>. For example, <c>"2016-09-27T14:50Z"</c>. You can
        /// specify any time range in the previous three hours.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? TimeWindow_StartTime { get; set; }
        #endregion
        
        #region Parameter UriPathPrefix
        /// <summary>
        /// <para>
        /// <para>A URI path prefix to filter the results. When you specify this parameter, the operation
        /// returns statistics for individual URIs within the specified path prefix. For example,
        /// if you specify <c>/api</c>, the response includes statistics for paths like <c>/api/v1/users</c>
        /// and <c>/api/v2/orders</c>. If you don't specify this parameter, the operation returns
        /// top-level path statistics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UriPathPrefix { get; set; }
        #endregion
        
        #region Parameter WebAclArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the web ACL for which you want to retrieve path
        /// statistics.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String WebAclArn { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of path statistics to return. Valid values are 1 to 100.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextMarker
        /// <summary>
        /// <para>
        /// <para>When you request a list of objects with a <c>Limit</c> setting, if the number of objects
        /// that are still available for retrieval exceeds the limit, WAF returns a <c>NextMarker</c>
        /// value in the response. To retrieve the next batch of objects, provide the marker from
        /// the prior call in your next request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextMarker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.GetTopPathStatisticsByTrafficResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.GetTopPathStatisticsByTrafficResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.GetTopPathStatisticsByTrafficResponse, GetWAF2TopPathStatisticsByTrafficCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BotCategory = this.BotCategory;
            context.BotName = this.BotName;
            context.BotOrganization = this.BotOrganization;
            context.Limit = this.Limit;
            #if MODULAR
            if (this.Limit == null && ParameterWasBound(nameof(this.Limit)))
            {
                WriteWarning("You are passing $null as a value for parameter Limit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextMarker = this.NextMarker;
            context.NumberOfTopTrafficBotsPerPath = this.NumberOfTopTrafficBotsPerPath;
            #if MODULAR
            if (this.NumberOfTopTrafficBotsPerPath == null && ParameterWasBound(nameof(this.NumberOfTopTrafficBotsPerPath)))
            {
                WriteWarning("You are passing $null as a value for parameter NumberOfTopTrafficBotsPerPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scope = this.Scope;
            #if MODULAR
            if (this.Scope == null && ParameterWasBound(nameof(this.Scope)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeWindow_EndTime = this.TimeWindow_EndTime;
            #if MODULAR
            if (this.TimeWindow_EndTime == null && ParameterWasBound(nameof(this.TimeWindow_EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeWindow_EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeWindow_StartTime = this.TimeWindow_StartTime;
            #if MODULAR
            if (this.TimeWindow_StartTime == null && ParameterWasBound(nameof(this.TimeWindow_StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeWindow_StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UriPathPrefix = this.UriPathPrefix;
            context.WebAclArn = this.WebAclArn;
            #if MODULAR
            if (this.WebAclArn == null && ParameterWasBound(nameof(this.WebAclArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WebAclArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.WAFV2.Model.GetTopPathStatisticsByTrafficRequest();
            
            if (cmdletContext.BotCategory != null)
            {
                request.BotCategory = cmdletContext.BotCategory;
            }
            if (cmdletContext.BotName != null)
            {
                request.BotName = cmdletContext.BotName;
            }
            if (cmdletContext.BotOrganization != null)
            {
                request.BotOrganization = cmdletContext.BotOrganization;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.NextMarker != null)
            {
                request.NextMarker = cmdletContext.NextMarker;
            }
            if (cmdletContext.NumberOfTopTrafficBotsPerPath != null)
            {
                request.NumberOfTopTrafficBotsPerPath = cmdletContext.NumberOfTopTrafficBotsPerPath.Value;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            
             // populate TimeWindow
            var requestTimeWindowIsNull = true;
            request.TimeWindow = new Amazon.WAFV2.Model.TimeWindow();
            System.DateTime? requestTimeWindow_timeWindow_EndTime = null;
            if (cmdletContext.TimeWindow_EndTime != null)
            {
                requestTimeWindow_timeWindow_EndTime = cmdletContext.TimeWindow_EndTime.Value;
            }
            if (requestTimeWindow_timeWindow_EndTime != null)
            {
                request.TimeWindow.EndTime = requestTimeWindow_timeWindow_EndTime.Value;
                requestTimeWindowIsNull = false;
            }
            System.DateTime? requestTimeWindow_timeWindow_StartTime = null;
            if (cmdletContext.TimeWindow_StartTime != null)
            {
                requestTimeWindow_timeWindow_StartTime = cmdletContext.TimeWindow_StartTime.Value;
            }
            if (requestTimeWindow_timeWindow_StartTime != null)
            {
                request.TimeWindow.StartTime = requestTimeWindow_timeWindow_StartTime.Value;
                requestTimeWindowIsNull = false;
            }
             // determine if request.TimeWindow should be set to null
            if (requestTimeWindowIsNull)
            {
                request.TimeWindow = null;
            }
            if (cmdletContext.UriPathPrefix != null)
            {
                request.UriPathPrefix = cmdletContext.UriPathPrefix;
            }
            if (cmdletContext.WebAclArn != null)
            {
                request.WebAclArn = cmdletContext.WebAclArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.WAFV2.Model.GetTopPathStatisticsByTrafficResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.GetTopPathStatisticsByTrafficRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "GetTopPathStatisticsByTraffic");
            try
            {
                #if DESKTOP
                return client.GetTopPathStatisticsByTraffic(request);
                #elif CORECLR
                return client.GetTopPathStatisticsByTrafficAsync(request).GetAwaiter().GetResult();
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
            public System.String BotCategory { get; set; }
            public System.String BotName { get; set; }
            public System.String BotOrganization { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextMarker { get; set; }
            public System.Int32? NumberOfTopTrafficBotsPerPath { get; set; }
            public Amazon.WAFV2.Scope Scope { get; set; }
            public System.DateTime? TimeWindow_EndTime { get; set; }
            public System.DateTime? TimeWindow_StartTime { get; set; }
            public System.String UriPathPrefix { get; set; }
            public System.String WebAclArn { get; set; }
            public System.Func<Amazon.WAFV2.Model.GetTopPathStatisticsByTrafficResponse, GetWAF2TopPathStatisticsByTrafficCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

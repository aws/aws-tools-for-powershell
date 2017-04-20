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
    /// Returns a list of configuration items for the specified resource. The list contains
    /// details about each state of the resource during the specified time interval.
    /// 
    ///  
    /// <para>
    /// The response is paginated, and by default, AWS Config returns a limit of 10 configuration
    /// items per page. You can customize this number with the <code>limit</code> parameter.
    /// The response includes a <code>nextToken</code> string, and to get the next page of
    /// results, run the request again and enter this string for the <code>nextToken</code>
    /// parameter.
    /// </para><note><para>
    /// Each call to the API is limited to span a duration of seven days. It is likely that
    /// the number of records returned is smaller than the specified <code>limit</code>. In
    /// such cases, you can make another call, using the <code>nextToken</code>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGResourceConfigHistory")]
    [OutputType("Amazon.ConfigService.Model.ConfigurationItem")]
    [AWSCmdlet("Invokes the GetResourceConfigHistory operation against AWS Config.", Operation = new[] {"GetResourceConfigHistory"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConfigurationItem",
        "This cmdlet returns a collection of ConfigurationItem objects.",
        "The service call response (type Amazon.ConfigService.Model.GetResourceConfigHistoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCFGResourceConfigHistoryCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ChronologicalOrder
        /// <summary>
        /// <para>
        /// <para>The chronological order for configuration items listed. By default the results are
        /// listed in reverse chronological order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ConfigService.ChronologicalOrder")]
        public Amazon.ConfigService.ChronologicalOrder ChronologicalOrder { get; set; }
        #endregion
        
        #region Parameter EarlierTime
        /// <summary>
        /// <para>
        /// <para>The time stamp that indicates an earlier time. If not specified, the action returns
        /// paginated results that contain configuration items that start from when the first
        /// configuration item was recorded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EarlierTime { get; set; }
        #endregion
        
        #region Parameter LaterTime
        /// <summary>
        /// <para>
        /// <para>The time stamp that indicates a later time. If not specified, current time is taken.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime LaterTime { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the resource (for example., <code>sg-xxxxxx</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ConfigService.ResourceType")]
        public Amazon.ConfigService.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of configuration items returned on each page. The default is 10.
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
            
            context.ChronologicalOrder = this.ChronologicalOrder;
            if (ParameterWasBound("EarlierTime"))
                context.EarlierTime = this.EarlierTime;
            if (ParameterWasBound("LaterTime"))
                context.LaterTime = this.LaterTime;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            context.ResourceId = this.ResourceId;
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
            var request = new Amazon.ConfigService.Model.GetResourceConfigHistoryRequest();
            
            if (cmdletContext.ChronologicalOrder != null)
            {
                request.ChronologicalOrder = cmdletContext.ChronologicalOrder;
            }
            if (cmdletContext.EarlierTime != null)
            {
                request.EarlierTime = cmdletContext.EarlierTime.Value;
            }
            if (cmdletContext.LaterTime != null)
            {
                request.LaterTime = cmdletContext.LaterTime.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
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
                object pipelineOutput = response.ConfigurationItems;
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
        
        private Amazon.ConfigService.Model.GetResourceConfigHistoryResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetResourceConfigHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetResourceConfigHistory");
            #if DESKTOP
            return client.GetResourceConfigHistory(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetResourceConfigHistoryAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Amazon.ConfigService.ChronologicalOrder ChronologicalOrder { get; set; }
            public System.DateTime? EarlierTime { get; set; }
            public System.DateTime? LaterTime { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceId { get; set; }
            public Amazon.ConfigService.ResourceType ResourceType { get; set; }
        }
        
    }
}

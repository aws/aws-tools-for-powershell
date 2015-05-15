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
    /// details about each state of the resource during the specified time interval. You can
    /// specify a <code>limit</code> on the number of results returned on the page. If a limit
    /// is specified, a <code>nextToken</code> is returned as part of the result that you
    /// can use to continue this request. 
    /// 
    ///  <note><para>
    /// Each call to the API is limited to span a duration of seven days. It is likely that
    /// the number of records returned is smaller than the specified <code>limit</code>. In
    /// such cases, you can make another call, using the <code>nextToken</code> .
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGResourceConfigHistory")]
    [OutputType("Amazon.ConfigService.Model.ConfigurationItem")]
    [AWSCmdlet("Invokes the GetResourceConfigHistory operation against Amazon Config.", Operation = new[] {"GetResourceConfigHistory"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConfigurationItem",
        "This cmdlet returns a collection of ConfigurationItem objects.",
        "The service call response (type GetResourceConfigHistoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetCFGResourceConfigHistoryCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The chronological order for configuration items listed. By default the results are
        /// listed in reverse chronological order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public ChronologicalOrder ChronologicalOrder { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The time stamp that indicates an earlier time. If not specified, the action returns
        /// paginated results that contain configuration items that start from when the first
        /// configuration item was recorded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime EarlierTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The time stamp that indicates a later time. If not specified, current time is taken.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime LaterTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the resource (for example., <code>sg-xxxxxx</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ResourceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The resource type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public ResourceType ResourceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of configuration items returned in each page. The default is 10.
        /// You cannot specify a limit greater than 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Limit { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An optional parameter used for pagination of the results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
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
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetResourceConfigHistoryRequest();
            
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
                var response = client.GetResourceConfigHistory(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public ChronologicalOrder ChronologicalOrder { get; set; }
            public DateTime? EarlierTime { get; set; }
            public DateTime? LaterTime { get; set; }
            public Int32? Limit { get; set; }
            public String NextToken { get; set; }
            public String ResourceId { get; set; }
            public ResourceType ResourceType { get; set; }
        }
        
    }
}

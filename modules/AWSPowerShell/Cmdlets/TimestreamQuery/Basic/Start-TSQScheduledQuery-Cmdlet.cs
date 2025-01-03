/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.TimestreamQuery;
using Amazon.TimestreamQuery.Model;

namespace Amazon.PowerShell.Cmdlets.TSQ
{
    /// <summary>
    /// You can use this API to run a scheduled query manually. 
    /// 
    ///  
    /// <para>
    /// If you enabled <c>QueryInsights</c>, this API also returns insights and metrics related
    /// to the query that you executed as part of an Amazon SNS notification. <c>QueryInsights</c>
    /// helps with performance tuning of your query. For more information about <c>QueryInsights</c>,
    /// see <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/using-query-insights.html">Using
    /// query insights to optimize queries in Amazon Timestream</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "TSQScheduledQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Timestream Query ExecuteScheduledQuery API operation.", Operation = new[] {"ExecuteScheduledQuery"}, SelectReturnType = typeof(Amazon.TimestreamQuery.Model.ExecuteScheduledQueryResponse))]
    [AWSCmdletOutput("None or Amazon.TimestreamQuery.Model.ExecuteScheduledQueryResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.TimestreamQuery.Model.ExecuteScheduledQueryResponse) be returned by specifying '-Select *'."
    )]
    public partial class StartTSQScheduledQueryCmdlet : AmazonTimestreamQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InvocationTime
        /// <summary>
        /// <para>
        /// <para>The timestamp in UTC. Query will be run as if it was invoked at this timestamp. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? InvocationTime { get; set; }
        #endregion
        
        #region Parameter QueryInsights_Mode
        /// <summary>
        /// <para>
        /// <para>Provides the following modes to enable <c>ScheduledQueryInsights</c>:</para><ul><li><para><c>ENABLED_WITH_RATE_CONTROL</c> – Enables <c>ScheduledQueryInsights</c> for the
        /// queries being processed. This mode also includes a rate control mechanism, which limits
        /// the <c>QueryInsights</c> feature to 1 query per second (QPS).</para></li><li><para><c>DISABLED</c> – Disables <c>ScheduledQueryInsights</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamQuery.ScheduledQueryInsightsMode")]
        public Amazon.TimestreamQuery.ScheduledQueryInsightsMode QueryInsights_Mode { get; set; }
        #endregion
        
        #region Parameter ScheduledQueryArn
        /// <summary>
        /// <para>
        /// <para>ARN of the scheduled query.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ScheduledQueryArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Not used. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamQuery.Model.ExecuteScheduledQueryResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScheduledQueryArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-TSQScheduledQuery (ExecuteScheduledQuery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamQuery.Model.ExecuteScheduledQueryResponse, StartTSQScheduledQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.InvocationTime = this.InvocationTime;
            #if MODULAR
            if (this.InvocationTime == null && ParameterWasBound(nameof(this.InvocationTime)))
            {
                WriteWarning("You are passing $null as a value for parameter InvocationTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryInsights_Mode = this.QueryInsights_Mode;
            context.ScheduledQueryArn = this.ScheduledQueryArn;
            #if MODULAR
            if (this.ScheduledQueryArn == null && ParameterWasBound(nameof(this.ScheduledQueryArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledQueryArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TimestreamQuery.Model.ExecuteScheduledQueryRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InvocationTime != null)
            {
                request.InvocationTime = cmdletContext.InvocationTime.Value;
            }
            
             // populate QueryInsights
            var requestQueryInsightsIsNull = true;
            request.QueryInsights = new Amazon.TimestreamQuery.Model.ScheduledQueryInsights();
            Amazon.TimestreamQuery.ScheduledQueryInsightsMode requestQueryInsights_queryInsights_Mode = null;
            if (cmdletContext.QueryInsights_Mode != null)
            {
                requestQueryInsights_queryInsights_Mode = cmdletContext.QueryInsights_Mode;
            }
            if (requestQueryInsights_queryInsights_Mode != null)
            {
                request.QueryInsights.Mode = requestQueryInsights_queryInsights_Mode;
                requestQueryInsightsIsNull = false;
            }
             // determine if request.QueryInsights should be set to null
            if (requestQueryInsightsIsNull)
            {
                request.QueryInsights = null;
            }
            if (cmdletContext.ScheduledQueryArn != null)
            {
                request.ScheduledQueryArn = cmdletContext.ScheduledQueryArn;
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
        
        private Amazon.TimestreamQuery.Model.ExecuteScheduledQueryResponse CallAWSServiceOperation(IAmazonTimestreamQuery client, Amazon.TimestreamQuery.Model.ExecuteScheduledQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream Query", "ExecuteScheduledQuery");
            try
            {
                #if DESKTOP
                return client.ExecuteScheduledQuery(request);
                #elif CORECLR
                return client.ExecuteScheduledQueryAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.DateTime? InvocationTime { get; set; }
            public Amazon.TimestreamQuery.ScheduledQueryInsightsMode QueryInsights_Mode { get; set; }
            public System.String ScheduledQueryArn { get; set; }
            public System.Func<Amazon.TimestreamQuery.Model.ExecuteScheduledQueryResponse, StartTSQScheduledQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

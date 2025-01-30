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
using Amazon.IoTThingsGraph;
using Amazon.IoTThingsGraph.Model;

namespace Amazon.PowerShell.Cmdlets.IOTTG
{
    /// <summary>
    /// Searches for AWS IoT Things Graph workflow execution instances.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Search", "IOTTGFlowExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTThingsGraph.Model.FlowExecutionSummary")]
    [AWSCmdlet("Calls the AWS IoT Things Graph SearchFlowExecutions API operation.", Operation = new[] {"SearchFlowExecutions"}, SelectReturnType = typeof(Amazon.IoTThingsGraph.Model.SearchFlowExecutionsResponse))]
    [AWSCmdletOutput("Amazon.IoTThingsGraph.Model.FlowExecutionSummary or Amazon.IoTThingsGraph.Model.SearchFlowExecutionsResponse",
        "This cmdlet returns a collection of Amazon.IoTThingsGraph.Model.FlowExecutionSummary objects.",
        "The service call response (type Amazon.IoTThingsGraph.Model.SearchFlowExecutionsResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("since: 2022-08-30")]
    public partial class SearchIOTTGFlowExecutionCmdlet : AmazonIoTThingsGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The date and time of the latest flow execution to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter FlowExecutionId
        /// <summary>
        /// <para>
        /// <para>The ID of a flow execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FlowExecutionId { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The date and time of the earliest flow execution to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter SystemInstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the system instance that contains the flow.</para>
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
        public System.String SystemInstanceId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The string that specifies the next page of results. Use this when you're paginating
        /// results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Summaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTThingsGraph.Model.SearchFlowExecutionsResponse).
        /// Specifying the name of a property of type Amazon.IoTThingsGraph.Model.SearchFlowExecutionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Summaries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SystemInstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SystemInstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SystemInstanceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SystemInstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-IOTTGFlowExecution (SearchFlowExecutions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTThingsGraph.Model.SearchFlowExecutionsResponse, SearchIOTTGFlowExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SystemInstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndTime = this.EndTime;
            context.FlowExecutionId = this.FlowExecutionId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StartTime = this.StartTime;
            context.SystemInstanceId = this.SystemInstanceId;
            #if MODULAR
            if (this.SystemInstanceId == null && ParameterWasBound(nameof(this.SystemInstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter SystemInstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTThingsGraph.Model.SearchFlowExecutionsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.FlowExecutionId != null)
            {
                request.FlowExecutionId = cmdletContext.FlowExecutionId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.SystemInstanceId != null)
            {
                request.SystemInstanceId = cmdletContext.SystemInstanceId;
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
        
        private Amazon.IoTThingsGraph.Model.SearchFlowExecutionsResponse CallAWSServiceOperation(IAmazonIoTThingsGraph client, Amazon.IoTThingsGraph.Model.SearchFlowExecutionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Things Graph", "SearchFlowExecutions");
            try
            {
                #if DESKTOP
                return client.SearchFlowExecutions(request);
                #elif CORECLR
                return client.SearchFlowExecutionsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.String FlowExecutionId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.String SystemInstanceId { get; set; }
            public System.Func<Amazon.IoTThingsGraph.Model.SearchFlowExecutionsResponse, SearchIOTTGFlowExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Summaries;
        }
        
    }
}

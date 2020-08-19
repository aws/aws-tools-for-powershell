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
using Amazon.Appflow;
using Amazon.Appflow.Model;

namespace Amazon.PowerShell.Cmdlets.AF
{
    /// <summary>
    /// Fetches the execution history of the flow.
    /// </summary>
    [Cmdlet("Get", "AFFlowExecutionRecord")]
    [OutputType("Amazon.Appflow.Model.ExecutionRecord")]
    [AWSCmdlet("Calls the Amazon Appflow DescribeFlowExecutionRecords API operation.", Operation = new[] {"DescribeFlowExecutionRecords"}, SelectReturnType = typeof(Amazon.Appflow.Model.DescribeFlowExecutionRecordsResponse))]
    [AWSCmdletOutput("Amazon.Appflow.Model.ExecutionRecord or Amazon.Appflow.Model.DescribeFlowExecutionRecordsResponse",
        "This cmdlet returns a collection of Amazon.Appflow.Model.ExecutionRecord objects.",
        "The service call response (type Amazon.Appflow.Model.DescribeFlowExecutionRecordsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAFFlowExecutionRecordCmdlet : AmazonAppflowClientCmdlet, IExecutor
    {
        
        #region Parameter FlowName
        /// <summary>
        /// <para>
        /// <para> The specified name of the flow. Spaces are not allowed. Use underscores (_) or hyphens
        /// (-) only. </para>
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
        public System.String FlowName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> Specifies the maximum number of items that should be returned in the result set.
        /// The default for <code>maxResults</code> is 20 (for all paginated API operations).
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The pagination token for the next page of data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FlowExecutions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Appflow.Model.DescribeFlowExecutionRecordsResponse).
        /// Specifying the name of a property of type Amazon.Appflow.Model.DescribeFlowExecutionRecordsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FlowExecutions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FlowName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FlowName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FlowName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Appflow.Model.DescribeFlowExecutionRecordsResponse, GetAFFlowExecutionRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FlowName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FlowName = this.FlowName;
            #if MODULAR
            if (this.FlowName == null && ParameterWasBound(nameof(this.FlowName)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
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
            var request = new Amazon.Appflow.Model.DescribeFlowExecutionRecordsRequest();
            
            if (cmdletContext.FlowName != null)
            {
                request.FlowName = cmdletContext.FlowName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Appflow.Model.DescribeFlowExecutionRecordsResponse CallAWSServiceOperation(IAmazonAppflow client, Amazon.Appflow.Model.DescribeFlowExecutionRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Appflow", "DescribeFlowExecutionRecords");
            try
            {
                #if DESKTOP
                return client.DescribeFlowExecutionRecords(request);
                #elif CORECLR
                return client.DescribeFlowExecutionRecordsAsync(request).GetAwaiter().GetResult();
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
            public System.String FlowName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Appflow.Model.DescribeFlowExecutionRecordsResponse, GetAFFlowExecutionRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FlowExecutions;
        }
        
    }
}

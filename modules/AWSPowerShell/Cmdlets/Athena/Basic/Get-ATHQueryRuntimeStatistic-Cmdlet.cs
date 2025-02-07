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
using Amazon.Athena;
using Amazon.Athena.Model;

namespace Amazon.PowerShell.Cmdlets.ATH
{
    /// <summary>
    /// Returns query execution runtime statistics related to a single execution of a query
    /// if you have access to the workgroup in which the query ran. Statistics from the <c>Timeline</c>
    /// section of the response object are available as soon as <a>QueryExecutionStatus$State</a>
    /// is in a SUCCEEDED or FAILED state. The remaining non-timeline statistics in the response
    /// (like stage-level input and output row count and data size) are updated asynchronously
    /// and may not be available immediately after a query completes. The non-timeline statistics
    /// are also not included when a query has row-level filters defined in Lake Formation.
    /// </summary>
    [Cmdlet("Get", "ATHQueryRuntimeStatistic")]
    [OutputType("Amazon.Athena.Model.GetQueryRuntimeStatisticsResponse")]
    [AWSCmdlet("Calls the Amazon Athena GetQueryRuntimeStatistics API operation.", Operation = new[] {"GetQueryRuntimeStatistics"}, SelectReturnType = typeof(Amazon.Athena.Model.GetQueryRuntimeStatisticsResponse))]
    [AWSCmdletOutput("Amazon.Athena.Model.GetQueryRuntimeStatisticsResponse",
        "This cmdlet returns an Amazon.Athena.Model.GetQueryRuntimeStatisticsResponse object containing multiple properties."
    )]
    public partial class GetATHQueryRuntimeStatisticCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter QueryExecutionId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the query execution.</para>
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
        public System.String QueryExecutionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Athena.Model.GetQueryRuntimeStatisticsResponse).
        /// Specifying the name of a property of type Amazon.Athena.Model.GetQueryRuntimeStatisticsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Athena.Model.GetQueryRuntimeStatisticsResponse, GetATHQueryRuntimeStatisticCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.QueryExecutionId = this.QueryExecutionId;
            #if MODULAR
            if (this.QueryExecutionId == null && ParameterWasBound(nameof(this.QueryExecutionId)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryExecutionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Athena.Model.GetQueryRuntimeStatisticsRequest();
            
            if (cmdletContext.QueryExecutionId != null)
            {
                request.QueryExecutionId = cmdletContext.QueryExecutionId;
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
        
        private Amazon.Athena.Model.GetQueryRuntimeStatisticsResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.GetQueryRuntimeStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "GetQueryRuntimeStatistics");
            try
            {
                #if DESKTOP
                return client.GetQueryRuntimeStatistics(request);
                #elif CORECLR
                return client.GetQueryRuntimeStatisticsAsync(request).GetAwaiter().GetResult();
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
            public System.String QueryExecutionId { get; set; }
            public System.Func<Amazon.Athena.Model.GetQueryRuntimeStatisticsResponse, GetATHQueryRuntimeStatisticCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

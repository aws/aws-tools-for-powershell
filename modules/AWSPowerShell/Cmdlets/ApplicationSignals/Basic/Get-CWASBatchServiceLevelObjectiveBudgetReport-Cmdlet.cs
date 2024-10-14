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
using Amazon.ApplicationSignals;
using Amazon.ApplicationSignals.Model;

namespace Amazon.PowerShell.Cmdlets.CWAS
{
    /// <summary>
    /// Use this operation to retrieve one or more <i>service level objective (SLO) budget
    /// reports</i>.
    /// 
    ///  
    /// <para>
    /// An <i>error budget</i> is the amount of time or requests in an unhealthy state that
    /// your service can accumulate during an interval before your overall SLO budget health
    /// is breached and the SLO is considered to be unmet. For example, an SLO with a threshold
    /// of 99.95% and a monthly interval translates to an error budget of 21.9 minutes of
    /// downtime in a 30-day month.
    /// </para><para>
    /// Budget reports include a health indicator, the attainment value, and remaining budget.
    /// </para><para>
    /// For more information about SLO error budgets, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-ServiceLevelObjectives.html#CloudWatch-ServiceLevelObjectives-concepts">
    /// SLO concepts</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWASBatchServiceLevelObjectiveBudgetReport")]
    [OutputType("Amazon.ApplicationSignals.Model.BatchGetServiceLevelObjectiveBudgetReportResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Signals BatchGetServiceLevelObjectiveBudgetReport API operation.", Operation = new[] {"BatchGetServiceLevelObjectiveBudgetReport"}, SelectReturnType = typeof(Amazon.ApplicationSignals.Model.BatchGetServiceLevelObjectiveBudgetReportResponse))]
    [AWSCmdletOutput("Amazon.ApplicationSignals.Model.BatchGetServiceLevelObjectiveBudgetReportResponse",
        "This cmdlet returns an Amazon.ApplicationSignals.Model.BatchGetServiceLevelObjectiveBudgetReportResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWASBatchServiceLevelObjectiveBudgetReportCmdlet : AmazonApplicationSignalsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SloId
        /// <summary>
        /// <para>
        /// <para>An array containing the IDs of the service level objectives that you want to include
        /// in the report.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SloIds")]
        public System.String[] SloId { get; set; }
        #endregion
        
        #region Parameter Timestamp
        /// <summary>
        /// <para>
        /// <para>The date and time that you want the report to be for. It is expressed as the number
        /// of milliseconds since Jan 1, 1970 00:00:00 UTC.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? Timestamp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationSignals.Model.BatchGetServiceLevelObjectiveBudgetReportResponse).
        /// Specifying the name of a property of type Amazon.ApplicationSignals.Model.BatchGetServiceLevelObjectiveBudgetReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Timestamp parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Timestamp' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Timestamp' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationSignals.Model.BatchGetServiceLevelObjectiveBudgetReportResponse, GetCWASBatchServiceLevelObjectiveBudgetReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Timestamp;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.SloId != null)
            {
                context.SloId = new List<System.String>(this.SloId);
            }
            #if MODULAR
            if (this.SloId == null && ParameterWasBound(nameof(this.SloId)))
            {
                WriteWarning("You are passing $null as a value for parameter SloId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Timestamp = this.Timestamp;
            #if MODULAR
            if (this.Timestamp == null && ParameterWasBound(nameof(this.Timestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter Timestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ApplicationSignals.Model.BatchGetServiceLevelObjectiveBudgetReportRequest();
            
            if (cmdletContext.SloId != null)
            {
                request.SloIds = cmdletContext.SloId;
            }
            if (cmdletContext.Timestamp != null)
            {
                request.Timestamp = cmdletContext.Timestamp.Value;
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
        
        private Amazon.ApplicationSignals.Model.BatchGetServiceLevelObjectiveBudgetReportResponse CallAWSServiceOperation(IAmazonApplicationSignals client, Amazon.ApplicationSignals.Model.BatchGetServiceLevelObjectiveBudgetReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Signals", "BatchGetServiceLevelObjectiveBudgetReport");
            try
            {
                #if DESKTOP
                return client.BatchGetServiceLevelObjectiveBudgetReport(request);
                #elif CORECLR
                return client.BatchGetServiceLevelObjectiveBudgetReportAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> SloId { get; set; }
            public System.DateTime? Timestamp { get; set; }
            public System.Func<Amazon.ApplicationSignals.Model.BatchGetServiceLevelObjectiveBudgetReportResponse, GetCWASBatchServiceLevelObjectiveBudgetReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

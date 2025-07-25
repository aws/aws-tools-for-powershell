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
using System.Threading;
using Amazon.LookoutEquipment;
using Amazon.LookoutEquipment.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.L4E
{
    /// <summary>
    /// Updates a retraining scheduler.
    /// </summary>
    [Cmdlet("Update", "L4ERetrainingScheduler", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Lookout for Equipment UpdateRetrainingScheduler API operation.", Operation = new[] {"UpdateRetrainingScheduler"}, SelectReturnType = typeof(Amazon.LookoutEquipment.Model.UpdateRetrainingSchedulerResponse))]
    [AWSCmdletOutput("None or Amazon.LookoutEquipment.Model.UpdateRetrainingSchedulerResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.LookoutEquipment.Model.UpdateRetrainingSchedulerResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateL4ERetrainingSchedulerCmdlet : AmazonLookoutEquipmentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LookbackWindow
        /// <summary>
        /// <para>
        /// <para>The number of past days of data that will be used for retraining.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LookbackWindow { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>The name of the model whose retraining scheduler you want to update. </para>
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
        public System.String ModelName { get; set; }
        #endregion
        
        #region Parameter PromoteMode
        /// <summary>
        /// <para>
        /// <para>Indicates how the service will use new models. In <c>MANAGED</c> mode, new models
        /// will automatically be used for inference if they have better performance than the
        /// current model. In <c>MANUAL</c> mode, the new models will not be used <a href="https://docs.aws.amazon.com/lookout-for-equipment/latest/ug/versioning-model.html#model-activation">until
        /// they are manually activated</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LookoutEquipment.ModelPromoteMode")]
        public Amazon.LookoutEquipment.ModelPromoteMode PromoteMode { get; set; }
        #endregion
        
        #region Parameter RetrainingFrequency
        /// <summary>
        /// <para>
        /// <para>This parameter uses the <a href="https://en.wikipedia.org/wiki/ISO_8601#Durations">ISO
        /// 8601</a> standard to set the frequency at which you want retraining to occur in terms
        /// of Years, Months, and/or Days (note: other parameters like Time are not currently
        /// supported). The minimum value is 30 days (P30D) and the maximum value is 1 year (P1Y).
        /// For example, the following values are valid:</para><ul><li><para>P3M15D – Every 3 months and 15 days</para></li><li><para>P2M – Every 2 months</para></li><li><para>P150D – Every 150 days</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RetrainingFrequency { get; set; }
        #endregion
        
        #region Parameter RetrainingStartDate
        /// <summary>
        /// <para>
        /// <para>The start date for the retraining scheduler. Lookout for Equipment truncates the time
        /// you provide to the nearest UTC day.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RetrainingStartDate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutEquipment.Model.UpdateRetrainingSchedulerResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-L4ERetrainingScheduler (UpdateRetrainingScheduler)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutEquipment.Model.UpdateRetrainingSchedulerResponse, UpdateL4ERetrainingSchedulerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LookbackWindow = this.LookbackWindow;
            context.ModelName = this.ModelName;
            #if MODULAR
            if (this.ModelName == null && ParameterWasBound(nameof(this.ModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PromoteMode = this.PromoteMode;
            context.RetrainingFrequency = this.RetrainingFrequency;
            context.RetrainingStartDate = this.RetrainingStartDate;
            
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
            var request = new Amazon.LookoutEquipment.Model.UpdateRetrainingSchedulerRequest();
            
            if (cmdletContext.LookbackWindow != null)
            {
                request.LookbackWindow = cmdletContext.LookbackWindow;
            }
            if (cmdletContext.ModelName != null)
            {
                request.ModelName = cmdletContext.ModelName;
            }
            if (cmdletContext.PromoteMode != null)
            {
                request.PromoteMode = cmdletContext.PromoteMode;
            }
            if (cmdletContext.RetrainingFrequency != null)
            {
                request.RetrainingFrequency = cmdletContext.RetrainingFrequency;
            }
            if (cmdletContext.RetrainingStartDate != null)
            {
                request.RetrainingStartDate = cmdletContext.RetrainingStartDate.Value;
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
        
        private Amazon.LookoutEquipment.Model.UpdateRetrainingSchedulerResponse CallAWSServiceOperation(IAmazonLookoutEquipment client, Amazon.LookoutEquipment.Model.UpdateRetrainingSchedulerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Equipment", "UpdateRetrainingScheduler");
            try
            {
                return client.UpdateRetrainingSchedulerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LookbackWindow { get; set; }
            public System.String ModelName { get; set; }
            public Amazon.LookoutEquipment.ModelPromoteMode PromoteMode { get; set; }
            public System.String RetrainingFrequency { get; set; }
            public System.DateTime? RetrainingStartDate { get; set; }
            public System.Func<Amazon.LookoutEquipment.Model.UpdateRetrainingSchedulerResponse, UpdateL4ERetrainingSchedulerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

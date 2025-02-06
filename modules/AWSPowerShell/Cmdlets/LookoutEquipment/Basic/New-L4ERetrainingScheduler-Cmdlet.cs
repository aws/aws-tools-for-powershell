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
using Amazon.LookoutEquipment;
using Amazon.LookoutEquipment.Model;

namespace Amazon.PowerShell.Cmdlets.L4E
{
    /// <summary>
    /// Creates a retraining scheduler on the specified model.
    /// </summary>
    [Cmdlet("New", "L4ERetrainingScheduler", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LookoutEquipment.Model.CreateRetrainingSchedulerResponse")]
    [AWSCmdlet("Calls the Amazon Lookout for Equipment CreateRetrainingScheduler API operation.", Operation = new[] {"CreateRetrainingScheduler"}, SelectReturnType = typeof(Amazon.LookoutEquipment.Model.CreateRetrainingSchedulerResponse))]
    [AWSCmdletOutput("Amazon.LookoutEquipment.Model.CreateRetrainingSchedulerResponse",
        "This cmdlet returns an Amazon.LookoutEquipment.Model.CreateRetrainingSchedulerResponse object containing multiple properties."
    )]
    public partial class NewL4ERetrainingSchedulerCmdlet : AmazonLookoutEquipmentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LookbackWindow
        /// <summary>
        /// <para>
        /// <para>The number of past days of data that will be used for retraining.</para>
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
        public System.String LookbackWindow { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>The name of the model to add the retraining scheduler to. </para>
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the request. If you do not set the client request token, Amazon
        /// Lookout for Equipment generates one. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutEquipment.Model.CreateRetrainingSchedulerResponse).
        /// Specifying the name of a property of type Amazon.LookoutEquipment.Model.CreateRetrainingSchedulerResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-L4ERetrainingScheduler (CreateRetrainingScheduler)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutEquipment.Model.CreateRetrainingSchedulerResponse, NewL4ERetrainingSchedulerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.LookbackWindow = this.LookbackWindow;
            #if MODULAR
            if (this.LookbackWindow == null && ParameterWasBound(nameof(this.LookbackWindow)))
            {
                WriteWarning("You are passing $null as a value for parameter LookbackWindow which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelName = this.ModelName;
            #if MODULAR
            if (this.ModelName == null && ParameterWasBound(nameof(this.ModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PromoteMode = this.PromoteMode;
            context.RetrainingFrequency = this.RetrainingFrequency;
            #if MODULAR
            if (this.RetrainingFrequency == null && ParameterWasBound(nameof(this.RetrainingFrequency)))
            {
                WriteWarning("You are passing $null as a value for parameter RetrainingFrequency which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.LookoutEquipment.Model.CreateRetrainingSchedulerRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
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
        
        private Amazon.LookoutEquipment.Model.CreateRetrainingSchedulerResponse CallAWSServiceOperation(IAmazonLookoutEquipment client, Amazon.LookoutEquipment.Model.CreateRetrainingSchedulerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Equipment", "CreateRetrainingScheduler");
            try
            {
                #if DESKTOP
                return client.CreateRetrainingScheduler(request);
                #elif CORECLR
                return client.CreateRetrainingSchedulerAsync(request).GetAwaiter().GetResult();
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
            public System.String LookbackWindow { get; set; }
            public System.String ModelName { get; set; }
            public Amazon.LookoutEquipment.ModelPromoteMode PromoteMode { get; set; }
            public System.String RetrainingFrequency { get; set; }
            public System.DateTime? RetrainingStartDate { get; set; }
            public System.Func<Amazon.LookoutEquipment.Model.CreateRetrainingSchedulerResponse, NewL4ERetrainingSchedulerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

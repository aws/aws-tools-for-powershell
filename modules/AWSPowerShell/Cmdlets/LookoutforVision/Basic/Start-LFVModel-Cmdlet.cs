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
using Amazon.LookoutforVision;
using Amazon.LookoutforVision.Model;

namespace Amazon.PowerShell.Cmdlets.LFV
{
    /// <summary>
    /// Starts the running of the version of an Amazon Lookout for Vision model. Starting
    /// a model takes a while to complete. To check the current state of the model, use <a>DescribeModel</a>.
    /// 
    ///  
    /// <para>
    /// A model is ready to use when its status is <c>HOSTED</c>.
    /// </para><para>
    /// Once the model is running, you can detect custom labels in new images by calling <a>DetectAnomalies</a>.
    /// </para><note><para>
    /// You are charged for the amount of time that the model is running. To stop a running
    /// model, call <a>StopModel</a>.
    /// </para></note><para>
    /// This operation requires permissions to perform the <c>lookoutvision:StartModel</c>
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "LFVModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LookoutforVision.ModelHostingStatus")]
    [AWSCmdlet("Calls the Amazon Lookout for Vision StartModel API operation.", Operation = new[] {"StartModel"}, SelectReturnType = typeof(Amazon.LookoutforVision.Model.StartModelResponse))]
    [AWSCmdletOutput("Amazon.LookoutforVision.ModelHostingStatus or Amazon.LookoutforVision.Model.StartModelResponse",
        "This cmdlet returns an Amazon.LookoutforVision.ModelHostingStatus object.",
        "The service call response (type Amazon.LookoutforVision.Model.StartModelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartLFVModelCmdlet : AmazonLookoutforVisionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MaxInferenceUnit
        /// <summary>
        /// <para>
        /// <para>The maximum number of inference units to use for auto-scaling the model. If you don't
        /// specify a value, Amazon Lookout for Vision doesn't auto-scale the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxInferenceUnits")]
        public System.Int32? MaxInferenceUnit { get; set; }
        #endregion
        
        #region Parameter MinInferenceUnit
        /// <summary>
        /// <para>
        /// <para>The minimum number of inference units to use. A single inference unit represents 1
        /// hour of processing. Use a higher number to increase the TPS throughput of your model.
        /// You are charged for the number of inference units that you use. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MinInferenceUnits")]
        public System.Int32? MinInferenceUnit { get; set; }
        #endregion
        
        #region Parameter ModelVersion
        /// <summary>
        /// <para>
        /// <para>The version of the model that you want to start.</para>
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
        public System.String ModelVersion { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project that contains the model that you want to start.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>ClientToken is an idempotency token that ensures a call to <c>StartModel</c> completes
        /// only once. You choose the value to pass. For example, An issue might prevent you from
        /// getting a response from <c>StartModel</c>. In this case, safely retry your call to
        /// <c>StartModel</c> by using the same <c>ClientToken</c> parameter value. </para><para>If you don't supply a value for <c>ClientToken</c>, the AWS SDK you are using inserts
        /// a value for you. This prevents retries after a network error from making multiple
        /// start requests. You'll need to provide your own value for other use cases. </para><para>An error occurs if the other input parameters are not the same as in the first request.
        /// Using a different value for <c>ClientToken</c> is considered a new call to <c>StartModel</c>.
        /// An idempotency token is active for 8 hours. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutforVision.Model.StartModelResponse).
        /// Specifying the name of a property of type Amazon.LookoutforVision.Model.StartModelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-LFVModel (StartModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutforVision.Model.StartModelResponse, StartLFVModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.MaxInferenceUnit = this.MaxInferenceUnit;
            context.MinInferenceUnit = this.MinInferenceUnit;
            #if MODULAR
            if (this.MinInferenceUnit == null && ParameterWasBound(nameof(this.MinInferenceUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter MinInferenceUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelVersion = this.ModelVersion;
            #if MODULAR
            if (this.ModelVersion == null && ParameterWasBound(nameof(this.ModelVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LookoutforVision.Model.StartModelRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.MaxInferenceUnit != null)
            {
                request.MaxInferenceUnits = cmdletContext.MaxInferenceUnit.Value;
            }
            if (cmdletContext.MinInferenceUnit != null)
            {
                request.MinInferenceUnits = cmdletContext.MinInferenceUnit.Value;
            }
            if (cmdletContext.ModelVersion != null)
            {
                request.ModelVersion = cmdletContext.ModelVersion;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
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
        
        private Amazon.LookoutforVision.Model.StartModelResponse CallAWSServiceOperation(IAmazonLookoutforVision client, Amazon.LookoutforVision.Model.StartModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Vision", "StartModel");
            try
            {
                #if DESKTOP
                return client.StartModel(request);
                #elif CORECLR
                return client.StartModelAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxInferenceUnit { get; set; }
            public System.Int32? MinInferenceUnit { get; set; }
            public System.String ModelVersion { get; set; }
            public System.String ProjectName { get; set; }
            public System.Func<Amazon.LookoutforVision.Model.StartModelResponse, StartLFVModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}

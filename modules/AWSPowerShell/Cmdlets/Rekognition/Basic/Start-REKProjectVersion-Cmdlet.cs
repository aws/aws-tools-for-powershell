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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// <note><para>
    /// This operation applies only to Amazon Rekognition Custom Labels.
    /// </para></note><para>
    /// Starts the running of the version of a model. Starting a model takes a while to complete.
    /// To check the current state of the model, use <a>DescribeProjectVersions</a>. 
    /// </para><para>
    /// Once the model is running, you can detect custom labels in new images by calling <a>DetectCustomLabels</a>.
    /// </para><note><para>
    /// You are charged for the amount of time that the model is running. To stop a running
    /// model, call <a>StopProjectVersion</a>.
    /// </para></note><para>
    /// This operation requires permissions to perform the <c>rekognition:StartProjectVersion</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "REKProjectVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Rekognition.ProjectVersionStatus")]
    [AWSCmdlet("Calls the Amazon Rekognition StartProjectVersion API operation.", Operation = new[] {"StartProjectVersion"}, SelectReturnType = typeof(Amazon.Rekognition.Model.StartProjectVersionResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.ProjectVersionStatus or Amazon.Rekognition.Model.StartProjectVersionResponse",
        "This cmdlet returns an Amazon.Rekognition.ProjectVersionStatus object.",
        "The service call response (type Amazon.Rekognition.Model.StartProjectVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartREKProjectVersionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MaxInferenceUnit
        /// <summary>
        /// <para>
        /// <para>The maximum number of inference units to use for auto-scaling the model. If you don't
        /// specify a value, Amazon Rekognition Custom Labels doesn't auto-scale the model.</para>
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
        /// hour of processing. </para><para>Use a higher number to increase the TPS throughput of your model. You are charged
        /// for the number of inference units that you use. </para>
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
        
        #region Parameter ProjectVersionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name(ARN) of the model version that you want to start.</para>
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
        public System.String ProjectVersionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.StartProjectVersionResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.StartProjectVersionResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectVersionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-REKProjectVersion (StartProjectVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.StartProjectVersionResponse, StartREKProjectVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxInferenceUnit = this.MaxInferenceUnit;
            context.MinInferenceUnit = this.MinInferenceUnit;
            #if MODULAR
            if (this.MinInferenceUnit == null && ParameterWasBound(nameof(this.MinInferenceUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter MinInferenceUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectVersionArn = this.ProjectVersionArn;
            #if MODULAR
            if (this.ProjectVersionArn == null && ParameterWasBound(nameof(this.ProjectVersionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectVersionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Rekognition.Model.StartProjectVersionRequest();
            
            if (cmdletContext.MaxInferenceUnit != null)
            {
                request.MaxInferenceUnits = cmdletContext.MaxInferenceUnit.Value;
            }
            if (cmdletContext.MinInferenceUnit != null)
            {
                request.MinInferenceUnits = cmdletContext.MinInferenceUnit.Value;
            }
            if (cmdletContext.ProjectVersionArn != null)
            {
                request.ProjectVersionArn = cmdletContext.ProjectVersionArn;
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
        
        private Amazon.Rekognition.Model.StartProjectVersionResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.StartProjectVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "StartProjectVersion");
            try
            {
                return client.StartProjectVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MaxInferenceUnit { get; set; }
            public System.Int32? MinInferenceUnit { get; set; }
            public System.String ProjectVersionArn { get; set; }
            public System.Func<Amazon.Rekognition.Model.StartProjectVersionResponse, StartREKProjectVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}

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
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;

namespace Amazon.PowerShell.Cmdlets.SFN
{
    /// <summary>
    /// Updates an in-progress Map Run's configuration to include changes to the settings
    /// that control maximum concurrency and Map Run failure.
    /// </summary>
    [Cmdlet("Update", "SFNMapRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Step Functions UpdateMapRun API operation.", Operation = new[] {"UpdateMapRun"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.UpdateMapRunResponse))]
    [AWSCmdletOutput("None or Amazon.StepFunctions.Model.UpdateMapRunResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.StepFunctions.Model.UpdateMapRunResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSFNMapRunCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MapRunArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a Map Run.</para>
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
        public System.String MapRunArn { get; set; }
        #endregion
        
        #region Parameter MaxConcurrency
        /// <summary>
        /// <para>
        /// <para>The maximum number of child workflow executions that can be specified to run in parallel
        /// for the Map Run at the same time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxConcurrency { get; set; }
        #endregion
        
        #region Parameter ToleratedFailureCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of failed items before the Map Run fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ToleratedFailureCount { get; set; }
        #endregion
        
        #region Parameter ToleratedFailurePercentage
        /// <summary>
        /// <para>
        /// <para>The maximum percentage of failed items before the Map Run fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? ToleratedFailurePercentage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.UpdateMapRunResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MapRunArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MapRunArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MapRunArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MapRunArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SFNMapRun (UpdateMapRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.UpdateMapRunResponse, UpdateSFNMapRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MapRunArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MapRunArn = this.MapRunArn;
            #if MODULAR
            if (this.MapRunArn == null && ParameterWasBound(nameof(this.MapRunArn)))
            {
                WriteWarning("You are passing $null as a value for parameter MapRunArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxConcurrency = this.MaxConcurrency;
            context.ToleratedFailureCount = this.ToleratedFailureCount;
            context.ToleratedFailurePercentage = this.ToleratedFailurePercentage;
            
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
            var request = new Amazon.StepFunctions.Model.UpdateMapRunRequest();
            
            if (cmdletContext.MapRunArn != null)
            {
                request.MapRunArn = cmdletContext.MapRunArn;
            }
            if (cmdletContext.MaxConcurrency != null)
            {
                request.MaxConcurrency = cmdletContext.MaxConcurrency.Value;
            }
            if (cmdletContext.ToleratedFailureCount != null)
            {
                request.ToleratedFailureCount = cmdletContext.ToleratedFailureCount.Value;
            }
            if (cmdletContext.ToleratedFailurePercentage != null)
            {
                request.ToleratedFailurePercentage = cmdletContext.ToleratedFailurePercentage.Value;
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
        
        private Amazon.StepFunctions.Model.UpdateMapRunResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.UpdateMapRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "UpdateMapRun");
            try
            {
                #if DESKTOP
                return client.UpdateMapRun(request);
                #elif CORECLR
                return client.UpdateMapRunAsync(request).GetAwaiter().GetResult();
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
            public System.String MapRunArn { get; set; }
            public System.Int32? MaxConcurrency { get; set; }
            public System.Int64? ToleratedFailureCount { get; set; }
            public System.Single? ToleratedFailurePercentage { get; set; }
            public System.Func<Amazon.StepFunctions.Model.UpdateMapRunResponse, UpdateSFNMapRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

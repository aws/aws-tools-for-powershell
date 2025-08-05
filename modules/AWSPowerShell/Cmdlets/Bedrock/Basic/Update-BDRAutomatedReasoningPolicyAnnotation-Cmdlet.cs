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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Updates the annotations for an Automated Reasoning policy build workflow. This allows
    /// you to modify extracted rules, variables, and types before finalizing the policy.
    /// </summary>
    [Cmdlet("Update", "BDRAutomatedReasoningPolicyAnnotation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyAnnotationsResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock UpdateAutomatedReasoningPolicyAnnotations API operation.", Operation = new[] {"UpdateAutomatedReasoningPolicyAnnotations"}, SelectReturnType = typeof(Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyAnnotationsResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyAnnotationsResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyAnnotationsResponse object containing multiple properties."
    )]
    public partial class UpdateBDRAutomatedReasoningPolicyAnnotationCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Annotation
        /// <summary>
        /// <para>
        /// <para>The updated annotations containing modified rules, variables, and types for the policy.</para>
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
        [Alias("Annotations")]
        public Amazon.Bedrock.Model.AutomatedReasoningPolicyAnnotation[] Annotation { get; set; }
        #endregion
        
        #region Parameter BuildWorkflowId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the build workflow whose annotations you want to update.</para>
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
        public System.String BuildWorkflowId { get; set; }
        #endregion
        
        #region Parameter LastUpdatedAnnotationSetHash
        /// <summary>
        /// <para>
        /// <para>The hash value of the annotation set that you're updating. This is used for optimistic
        /// concurrency control to prevent conflicting updates.</para>
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
        public System.String LastUpdatedAnnotationSetHash { get; set; }
        #endregion
        
        #region Parameter PolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Automated Reasoning policy whose annotations
        /// you want to update.</para>
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
        public System.String PolicyArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyAnnotationsResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyAnnotationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PolicyArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PolicyArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PolicyArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BuildWorkflowId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BDRAutomatedReasoningPolicyAnnotation (UpdateAutomatedReasoningPolicyAnnotations)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyAnnotationsResponse, UpdateBDRAutomatedReasoningPolicyAnnotationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PolicyArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Annotation != null)
            {
                context.Annotation = new List<Amazon.Bedrock.Model.AutomatedReasoningPolicyAnnotation>(this.Annotation);
            }
            #if MODULAR
            if (this.Annotation == null && ParameterWasBound(nameof(this.Annotation)))
            {
                WriteWarning("You are passing $null as a value for parameter Annotation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BuildWorkflowId = this.BuildWorkflowId;
            #if MODULAR
            if (this.BuildWorkflowId == null && ParameterWasBound(nameof(this.BuildWorkflowId)))
            {
                WriteWarning("You are passing $null as a value for parameter BuildWorkflowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LastUpdatedAnnotationSetHash = this.LastUpdatedAnnotationSetHash;
            #if MODULAR
            if (this.LastUpdatedAnnotationSetHash == null && ParameterWasBound(nameof(this.LastUpdatedAnnotationSetHash)))
            {
                WriteWarning("You are passing $null as a value for parameter LastUpdatedAnnotationSetHash which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyArn = this.PolicyArn;
            #if MODULAR
            if (this.PolicyArn == null && ParameterWasBound(nameof(this.PolicyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyAnnotationsRequest();
            
            if (cmdletContext.Annotation != null)
            {
                request.Annotations = cmdletContext.Annotation;
            }
            if (cmdletContext.BuildWorkflowId != null)
            {
                request.BuildWorkflowId = cmdletContext.BuildWorkflowId;
            }
            if (cmdletContext.LastUpdatedAnnotationSetHash != null)
            {
                request.LastUpdatedAnnotationSetHash = cmdletContext.LastUpdatedAnnotationSetHash;
            }
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArn = cmdletContext.PolicyArn;
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
        
        private Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyAnnotationsResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyAnnotationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "UpdateAutomatedReasoningPolicyAnnotations");
            try
            {
                #if DESKTOP
                return client.UpdateAutomatedReasoningPolicyAnnotations(request);
                #elif CORECLR
                return client.UpdateAutomatedReasoningPolicyAnnotationsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Bedrock.Model.AutomatedReasoningPolicyAnnotation> Annotation { get; set; }
            public System.String BuildWorkflowId { get; set; }
            public System.String LastUpdatedAnnotationSetHash { get; set; }
            public System.String PolicyArn { get; set; }
            public System.Func<Amazon.Bedrock.Model.UpdateAutomatedReasoningPolicyAnnotationsResponse, UpdateBDRAutomatedReasoningPolicyAnnotationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

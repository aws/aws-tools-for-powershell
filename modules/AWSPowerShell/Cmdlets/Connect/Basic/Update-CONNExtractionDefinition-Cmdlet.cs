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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates an extraction definition in the specified Connect Customer instance.
    /// </summary>
    [Cmdlet("Update", "CONNExtractionDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateExtractionDefinition API operation.", Operation = new[] {"UpdateExtractionDefinition"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateExtractionDefinitionResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateExtractionDefinitionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateExtractionDefinitionResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNExtractionDefinitionCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExtractionConfiguration_NotFoundBehavior_Behavior
        /// <summary>
        /// <para>
        /// <para>The behavior type. <c>USE_DEFAULT_VALUE</c> returns the specified default value. <c>OMIT</c>
        /// excludes the field from the output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.NotFoundBehaviorType")]
        public Amazon.Connect.NotFoundBehaviorType ExtractionConfiguration_NotFoundBehavior_Behavior { get; set; }
        #endregion
        
        #region Parameter ExtractionConfiguration_NotFoundBehavior_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The default value to use when the behavior is <c>USE_DEFAULT_VALUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExtractionConfiguration_NotFoundBehavior_DefaultValue { get; set; }
        #endregion
        
        #region Parameter ExtractionDefinitionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the extraction definition to update.</para>
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
        public System.String ExtractionDefinitionId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Connect Customer instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Display_Label
        /// <summary>
        /// <para>
        /// <para>The label displayed in the agent workspace for this extraction definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Display_Label { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the extraction definition.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ExtractionConfiguration_PromptHint
        /// <summary>
        /// <para>
        /// <para>The prompt hint that guides the extraction. This text tells the generative AI model
        /// what data to look for in the customer interaction.</para>
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
        public System.String ExtractionConfiguration_PromptHint { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateExtractionDefinitionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExtractionDefinitionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNExtractionDefinition (UpdateExtractionDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateExtractionDefinitionResponse, UpdateCONNExtractionDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Display_Label = this.Display_Label;
            context.ExtractionConfiguration_NotFoundBehavior_Behavior = this.ExtractionConfiguration_NotFoundBehavior_Behavior;
            context.ExtractionConfiguration_NotFoundBehavior_DefaultValue = this.ExtractionConfiguration_NotFoundBehavior_DefaultValue;
            context.ExtractionConfiguration_PromptHint = this.ExtractionConfiguration_PromptHint;
            #if MODULAR
            if (this.ExtractionConfiguration_PromptHint == null && ParameterWasBound(nameof(this.ExtractionConfiguration_PromptHint)))
            {
                WriteWarning("You are passing $null as a value for parameter ExtractionConfiguration_PromptHint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExtractionDefinitionId = this.ExtractionDefinitionId;
            #if MODULAR
            if (this.ExtractionDefinitionId == null && ParameterWasBound(nameof(this.ExtractionDefinitionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExtractionDefinitionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.UpdateExtractionDefinitionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Display
            var requestDisplayIsNull = true;
            request.Display = new Amazon.Connect.Model.ExtractionDefinitionDisplay();
            System.String requestDisplay_display_Label = null;
            if (cmdletContext.Display_Label != null)
            {
                requestDisplay_display_Label = cmdletContext.Display_Label;
            }
            if (requestDisplay_display_Label != null)
            {
                request.Display.Label = requestDisplay_display_Label;
                requestDisplayIsNull = false;
            }
             // determine if request.Display should be set to null
            if (requestDisplayIsNull)
            {
                request.Display = null;
            }
            
             // populate ExtractionConfiguration
            var requestExtractionConfigurationIsNull = true;
            request.ExtractionConfiguration = new Amazon.Connect.Model.ExtractionConfiguration();
            System.String requestExtractionConfiguration_extractionConfiguration_PromptHint = null;
            if (cmdletContext.ExtractionConfiguration_PromptHint != null)
            {
                requestExtractionConfiguration_extractionConfiguration_PromptHint = cmdletContext.ExtractionConfiguration_PromptHint;
            }
            if (requestExtractionConfiguration_extractionConfiguration_PromptHint != null)
            {
                request.ExtractionConfiguration.PromptHint = requestExtractionConfiguration_extractionConfiguration_PromptHint;
                requestExtractionConfigurationIsNull = false;
            }
            Amazon.Connect.Model.ExtractionDefinitionNotFoundBehavior requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior = null;
            
             // populate NotFoundBehavior
            var requestExtractionConfiguration_extractionConfiguration_NotFoundBehaviorIsNull = true;
            requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior = new Amazon.Connect.Model.ExtractionDefinitionNotFoundBehavior();
            Amazon.Connect.NotFoundBehaviorType requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior_extractionConfiguration_NotFoundBehavior_Behavior = null;
            if (cmdletContext.ExtractionConfiguration_NotFoundBehavior_Behavior != null)
            {
                requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior_extractionConfiguration_NotFoundBehavior_Behavior = cmdletContext.ExtractionConfiguration_NotFoundBehavior_Behavior;
            }
            if (requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior_extractionConfiguration_NotFoundBehavior_Behavior != null)
            {
                requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior.Behavior = requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior_extractionConfiguration_NotFoundBehavior_Behavior;
                requestExtractionConfiguration_extractionConfiguration_NotFoundBehaviorIsNull = false;
            }
            System.String requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior_extractionConfiguration_NotFoundBehavior_DefaultValue = null;
            if (cmdletContext.ExtractionConfiguration_NotFoundBehavior_DefaultValue != null)
            {
                requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior_extractionConfiguration_NotFoundBehavior_DefaultValue = cmdletContext.ExtractionConfiguration_NotFoundBehavior_DefaultValue;
            }
            if (requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior_extractionConfiguration_NotFoundBehavior_DefaultValue != null)
            {
                requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior.DefaultValue = requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior_extractionConfiguration_NotFoundBehavior_DefaultValue;
                requestExtractionConfiguration_extractionConfiguration_NotFoundBehaviorIsNull = false;
            }
             // determine if requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior should be set to null
            if (requestExtractionConfiguration_extractionConfiguration_NotFoundBehaviorIsNull)
            {
                requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior = null;
            }
            if (requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior != null)
            {
                request.ExtractionConfiguration.NotFoundBehavior = requestExtractionConfiguration_extractionConfiguration_NotFoundBehavior;
                requestExtractionConfigurationIsNull = false;
            }
             // determine if request.ExtractionConfiguration should be set to null
            if (requestExtractionConfigurationIsNull)
            {
                request.ExtractionConfiguration = null;
            }
            if (cmdletContext.ExtractionDefinitionId != null)
            {
                request.ExtractionDefinitionId = cmdletContext.ExtractionDefinitionId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Connect.Model.UpdateExtractionDefinitionResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateExtractionDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateExtractionDefinition");
            try
            {
                return client.UpdateExtractionDefinitionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Display_Label { get; set; }
            public Amazon.Connect.NotFoundBehaviorType ExtractionConfiguration_NotFoundBehavior_Behavior { get; set; }
            public System.String ExtractionConfiguration_NotFoundBehavior_DefaultValue { get; set; }
            public System.String ExtractionConfiguration_PromptHint { get; set; }
            public System.String ExtractionDefinitionId { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateExtractionDefinitionResponse, UpdateCONNExtractionDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

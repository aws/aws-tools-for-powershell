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
using Amazon.IoT;
using Amazon.IoT.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates a provisioning template.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdateProvisioningTemplate</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTProvisioningTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT UpdateProvisioningTemplate API operation.", Operation = new[] {"UpdateProvisioningTemplate"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateProvisioningTemplateResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.UpdateProvisioningTemplateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.UpdateProvisioningTemplateResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTProvisioningTemplateCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DefaultVersionId
        /// <summary>
        /// <para>
        /// <para>The ID of the default provisioning template version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DefaultVersionId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the provisioning template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>True to enable the provisioning template, otherwise false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter PreProvisioningHook_PayloadVersion
        /// <summary>
        /// <para>
        /// <para>The payload that was sent to the target function.</para><para><i>Note:</i> Only Lambda functions are currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreProvisioningHook_PayloadVersion { get; set; }
        #endregion
        
        #region Parameter ProvisioningRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role associated with the provisioning template. This IoT role grants
        /// permission to provision a device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProvisioningRoleArn { get; set; }
        #endregion
        
        #region Parameter RemovePreProvisioningHook
        /// <summary>
        /// <para>
        /// <para>Removes pre-provisioning hook template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemovePreProvisioningHook { get; set; }
        #endregion
        
        #region Parameter PreProvisioningHook_TargetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the target function.</para><para><i>Note:</i> Only Lambda functions are currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreProvisioningHook_TargetArn { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the provisioning template.</para>
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
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateProvisioningTemplateResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTProvisioningTemplate (UpdateProvisioningTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateProvisioningTemplateResponse, UpdateIOTProvisioningTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DefaultVersionId = this.DefaultVersionId;
            context.Description = this.Description;
            context.Enabled = this.Enabled;
            context.PreProvisioningHook_PayloadVersion = this.PreProvisioningHook_PayloadVersion;
            context.PreProvisioningHook_TargetArn = this.PreProvisioningHook_TargetArn;
            context.ProvisioningRoleArn = this.ProvisioningRoleArn;
            context.RemovePreProvisioningHook = this.RemovePreProvisioningHook;
            context.TemplateName = this.TemplateName;
            #if MODULAR
            if (this.TemplateName == null && ParameterWasBound(nameof(this.TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoT.Model.UpdateProvisioningTemplateRequest();
            
            if (cmdletContext.DefaultVersionId != null)
            {
                request.DefaultVersionId = cmdletContext.DefaultVersionId.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            
             // populate PreProvisioningHook
            var requestPreProvisioningHookIsNull = true;
            request.PreProvisioningHook = new Amazon.IoT.Model.ProvisioningHook();
            System.String requestPreProvisioningHook_preProvisioningHook_PayloadVersion = null;
            if (cmdletContext.PreProvisioningHook_PayloadVersion != null)
            {
                requestPreProvisioningHook_preProvisioningHook_PayloadVersion = cmdletContext.PreProvisioningHook_PayloadVersion;
            }
            if (requestPreProvisioningHook_preProvisioningHook_PayloadVersion != null)
            {
                request.PreProvisioningHook.PayloadVersion = requestPreProvisioningHook_preProvisioningHook_PayloadVersion;
                requestPreProvisioningHookIsNull = false;
            }
            System.String requestPreProvisioningHook_preProvisioningHook_TargetArn = null;
            if (cmdletContext.PreProvisioningHook_TargetArn != null)
            {
                requestPreProvisioningHook_preProvisioningHook_TargetArn = cmdletContext.PreProvisioningHook_TargetArn;
            }
            if (requestPreProvisioningHook_preProvisioningHook_TargetArn != null)
            {
                request.PreProvisioningHook.TargetArn = requestPreProvisioningHook_preProvisioningHook_TargetArn;
                requestPreProvisioningHookIsNull = false;
            }
             // determine if request.PreProvisioningHook should be set to null
            if (requestPreProvisioningHookIsNull)
            {
                request.PreProvisioningHook = null;
            }
            if (cmdletContext.ProvisioningRoleArn != null)
            {
                request.ProvisioningRoleArn = cmdletContext.ProvisioningRoleArn;
            }
            if (cmdletContext.RemovePreProvisioningHook != null)
            {
                request.RemovePreProvisioningHook = cmdletContext.RemovePreProvisioningHook.Value;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
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
        
        private Amazon.IoT.Model.UpdateProvisioningTemplateResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateProvisioningTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateProvisioningTemplate");
            try
            {
                return client.UpdateProvisioningTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? DefaultVersionId { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.String PreProvisioningHook_PayloadVersion { get; set; }
            public System.String PreProvisioningHook_TargetArn { get; set; }
            public System.String ProvisioningRoleArn { get; set; }
            public System.Boolean? RemovePreProvisioningHook { get; set; }
            public System.String TemplateName { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateProvisioningTemplateResponse, UpdateIOTProvisioningTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

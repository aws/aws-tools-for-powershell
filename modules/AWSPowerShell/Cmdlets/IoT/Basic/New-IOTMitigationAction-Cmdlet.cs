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
    /// Defines an action that can be applied to audit findings by using StartAuditMitigationActionsTask.
    /// Only certain types of mitigation actions can be applied to specific check names. For
    /// more information, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/device-defender-mitigation-actions.html">Mitigation
    /// actions</a>. Each mitigation action can apply only one type of change.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreateMitigationAction</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTMitigationAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateMitigationActionResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateMitigationAction API operation.", Operation = new[] {"CreateMitigationAction"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateMitigationActionResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateMitigationActionResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreateMitigationActionResponse object containing multiple properties."
    )]
    public partial class NewIOTMitigationActionCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter UpdateCACertificateParams_Action
        /// <summary>
        /// <para>
        /// <para>The action that you want to apply to the CA certificate. The only supported value
        /// is <c>DEACTIVATE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionParams_UpdateCACertificateParams_Action")]
        [AWSConstantClassSource("Amazon.IoT.CACertificateUpdateAction")]
        public Amazon.IoT.CACertificateUpdateAction UpdateCACertificateParams_Action { get; set; }
        #endregion
        
        #region Parameter UpdateDeviceCertificateParams_Action
        /// <summary>
        /// <para>
        /// <para>The action that you want to apply to the device certificate. The only supported value
        /// is <c>DEACTIVATE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionParams_UpdateDeviceCertificateParams_Action")]
        [AWSConstantClassSource("Amazon.IoT.DeviceCertificateUpdateAction")]
        public Amazon.IoT.DeviceCertificateUpdateAction UpdateDeviceCertificateParams_Action { get; set; }
        #endregion
        
        #region Parameter ActionName
        /// <summary>
        /// <para>
        /// <para>A friendly name for the action. Choose a friendly name that accurately describes the
        /// action (for example, <c>EnableLoggingAction</c>).</para>
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
        public System.String ActionName { get; set; }
        #endregion
        
        #region Parameter EnableIoTLoggingParams_LogLevel
        /// <summary>
        /// <para>
        /// <para>Specifies the type of information to be logged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionParams_EnableIoTLoggingParams_LogLevel")]
        [AWSConstantClassSource("Amazon.IoT.LogLevel")]
        public Amazon.IoT.LogLevel EnableIoTLoggingParams_LogLevel { get; set; }
        #endregion
        
        #region Parameter AddThingsToThingGroupParams_OverrideDynamicGroup
        /// <summary>
        /// <para>
        /// <para>Specifies if this mitigation action can move the things that triggered the mitigation
        /// action even if they are part of one or more dynamic thing groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionParams_AddThingsToThingGroupParams_OverrideDynamicGroups")]
        public System.Boolean? AddThingsToThingGroupParams_OverrideDynamicGroup { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that is used to apply the mitigation action.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter EnableIoTLoggingParams_RoleArnForLogging
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role used for logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionParams_EnableIoTLoggingParams_RoleArnForLogging")]
        public System.String EnableIoTLoggingParams_RoleArnForLogging { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that can be used to manage the mitigation action.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoT.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ReplaceDefaultPolicyVersionParams_TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the template to be applied. The only supported value is <c>BLANK_POLICY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionParams_ReplaceDefaultPolicyVersionParams_TemplateName")]
        [AWSConstantClassSource("Amazon.IoT.PolicyTemplateName")]
        public Amazon.IoT.PolicyTemplateName ReplaceDefaultPolicyVersionParams_TemplateName { get; set; }
        #endregion
        
        #region Parameter AddThingsToThingGroupParams_ThingGroupName
        /// <summary>
        /// <para>
        /// <para>The list of groups to which you want to add the things that triggered the mitigation
        /// action. You can add a thing to a maximum of 10 groups, but you can't add a thing to
        /// more than one group in the same hierarchy.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionParams_AddThingsToThingGroupParams_ThingGroupNames")]
        public System.String[] AddThingsToThingGroupParams_ThingGroupName { get; set; }
        #endregion
        
        #region Parameter PublishFindingToSnsParams_TopicArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the topic to which you want to publish the findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionParams_PublishFindingToSnsParams_TopicArn")]
        public System.String PublishFindingToSnsParams_TopicArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateMitigationActionResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateMitigationActionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ActionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTMitigationAction (CreateMitigationAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateMitigationActionResponse, NewIOTMitigationActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionName = this.ActionName;
            #if MODULAR
            if (this.ActionName == null && ParameterWasBound(nameof(this.ActionName)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AddThingsToThingGroupParams_OverrideDynamicGroup = this.AddThingsToThingGroupParams_OverrideDynamicGroup;
            if (this.AddThingsToThingGroupParams_ThingGroupName != null)
            {
                context.AddThingsToThingGroupParams_ThingGroupName = new List<System.String>(this.AddThingsToThingGroupParams_ThingGroupName);
            }
            context.EnableIoTLoggingParams_LogLevel = this.EnableIoTLoggingParams_LogLevel;
            context.EnableIoTLoggingParams_RoleArnForLogging = this.EnableIoTLoggingParams_RoleArnForLogging;
            context.PublishFindingToSnsParams_TopicArn = this.PublishFindingToSnsParams_TopicArn;
            context.ReplaceDefaultPolicyVersionParams_TemplateName = this.ReplaceDefaultPolicyVersionParams_TemplateName;
            context.UpdateCACertificateParams_Action = this.UpdateCACertificateParams_Action;
            context.UpdateDeviceCertificateParams_Action = this.UpdateDeviceCertificateParams_Action;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoT.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.IoT.Model.CreateMitigationActionRequest();
            
            if (cmdletContext.ActionName != null)
            {
                request.ActionName = cmdletContext.ActionName;
            }
            
             // populate ActionParams
            var requestActionParamsIsNull = true;
            request.ActionParams = new Amazon.IoT.Model.MitigationActionParams();
            Amazon.IoT.Model.PublishFindingToSnsParams requestActionParams_actionParams_PublishFindingToSnsParams = null;
            
             // populate PublishFindingToSnsParams
            var requestActionParams_actionParams_PublishFindingToSnsParamsIsNull = true;
            requestActionParams_actionParams_PublishFindingToSnsParams = new Amazon.IoT.Model.PublishFindingToSnsParams();
            System.String requestActionParams_actionParams_PublishFindingToSnsParams_publishFindingToSnsParams_TopicArn = null;
            if (cmdletContext.PublishFindingToSnsParams_TopicArn != null)
            {
                requestActionParams_actionParams_PublishFindingToSnsParams_publishFindingToSnsParams_TopicArn = cmdletContext.PublishFindingToSnsParams_TopicArn;
            }
            if (requestActionParams_actionParams_PublishFindingToSnsParams_publishFindingToSnsParams_TopicArn != null)
            {
                requestActionParams_actionParams_PublishFindingToSnsParams.TopicArn = requestActionParams_actionParams_PublishFindingToSnsParams_publishFindingToSnsParams_TopicArn;
                requestActionParams_actionParams_PublishFindingToSnsParamsIsNull = false;
            }
             // determine if requestActionParams_actionParams_PublishFindingToSnsParams should be set to null
            if (requestActionParams_actionParams_PublishFindingToSnsParamsIsNull)
            {
                requestActionParams_actionParams_PublishFindingToSnsParams = null;
            }
            if (requestActionParams_actionParams_PublishFindingToSnsParams != null)
            {
                request.ActionParams.PublishFindingToSnsParams = requestActionParams_actionParams_PublishFindingToSnsParams;
                requestActionParamsIsNull = false;
            }
            Amazon.IoT.Model.ReplaceDefaultPolicyVersionParams requestActionParams_actionParams_ReplaceDefaultPolicyVersionParams = null;
            
             // populate ReplaceDefaultPolicyVersionParams
            var requestActionParams_actionParams_ReplaceDefaultPolicyVersionParamsIsNull = true;
            requestActionParams_actionParams_ReplaceDefaultPolicyVersionParams = new Amazon.IoT.Model.ReplaceDefaultPolicyVersionParams();
            Amazon.IoT.PolicyTemplateName requestActionParams_actionParams_ReplaceDefaultPolicyVersionParams_replaceDefaultPolicyVersionParams_TemplateName = null;
            if (cmdletContext.ReplaceDefaultPolicyVersionParams_TemplateName != null)
            {
                requestActionParams_actionParams_ReplaceDefaultPolicyVersionParams_replaceDefaultPolicyVersionParams_TemplateName = cmdletContext.ReplaceDefaultPolicyVersionParams_TemplateName;
            }
            if (requestActionParams_actionParams_ReplaceDefaultPolicyVersionParams_replaceDefaultPolicyVersionParams_TemplateName != null)
            {
                requestActionParams_actionParams_ReplaceDefaultPolicyVersionParams.TemplateName = requestActionParams_actionParams_ReplaceDefaultPolicyVersionParams_replaceDefaultPolicyVersionParams_TemplateName;
                requestActionParams_actionParams_ReplaceDefaultPolicyVersionParamsIsNull = false;
            }
             // determine if requestActionParams_actionParams_ReplaceDefaultPolicyVersionParams should be set to null
            if (requestActionParams_actionParams_ReplaceDefaultPolicyVersionParamsIsNull)
            {
                requestActionParams_actionParams_ReplaceDefaultPolicyVersionParams = null;
            }
            if (requestActionParams_actionParams_ReplaceDefaultPolicyVersionParams != null)
            {
                request.ActionParams.ReplaceDefaultPolicyVersionParams = requestActionParams_actionParams_ReplaceDefaultPolicyVersionParams;
                requestActionParamsIsNull = false;
            }
            Amazon.IoT.Model.UpdateCACertificateParams requestActionParams_actionParams_UpdateCACertificateParams = null;
            
             // populate UpdateCACertificateParams
            var requestActionParams_actionParams_UpdateCACertificateParamsIsNull = true;
            requestActionParams_actionParams_UpdateCACertificateParams = new Amazon.IoT.Model.UpdateCACertificateParams();
            Amazon.IoT.CACertificateUpdateAction requestActionParams_actionParams_UpdateCACertificateParams_updateCACertificateParams_Action = null;
            if (cmdletContext.UpdateCACertificateParams_Action != null)
            {
                requestActionParams_actionParams_UpdateCACertificateParams_updateCACertificateParams_Action = cmdletContext.UpdateCACertificateParams_Action;
            }
            if (requestActionParams_actionParams_UpdateCACertificateParams_updateCACertificateParams_Action != null)
            {
                requestActionParams_actionParams_UpdateCACertificateParams.Action = requestActionParams_actionParams_UpdateCACertificateParams_updateCACertificateParams_Action;
                requestActionParams_actionParams_UpdateCACertificateParamsIsNull = false;
            }
             // determine if requestActionParams_actionParams_UpdateCACertificateParams should be set to null
            if (requestActionParams_actionParams_UpdateCACertificateParamsIsNull)
            {
                requestActionParams_actionParams_UpdateCACertificateParams = null;
            }
            if (requestActionParams_actionParams_UpdateCACertificateParams != null)
            {
                request.ActionParams.UpdateCACertificateParams = requestActionParams_actionParams_UpdateCACertificateParams;
                requestActionParamsIsNull = false;
            }
            Amazon.IoT.Model.UpdateDeviceCertificateParams requestActionParams_actionParams_UpdateDeviceCertificateParams = null;
            
             // populate UpdateDeviceCertificateParams
            var requestActionParams_actionParams_UpdateDeviceCertificateParamsIsNull = true;
            requestActionParams_actionParams_UpdateDeviceCertificateParams = new Amazon.IoT.Model.UpdateDeviceCertificateParams();
            Amazon.IoT.DeviceCertificateUpdateAction requestActionParams_actionParams_UpdateDeviceCertificateParams_updateDeviceCertificateParams_Action = null;
            if (cmdletContext.UpdateDeviceCertificateParams_Action != null)
            {
                requestActionParams_actionParams_UpdateDeviceCertificateParams_updateDeviceCertificateParams_Action = cmdletContext.UpdateDeviceCertificateParams_Action;
            }
            if (requestActionParams_actionParams_UpdateDeviceCertificateParams_updateDeviceCertificateParams_Action != null)
            {
                requestActionParams_actionParams_UpdateDeviceCertificateParams.Action = requestActionParams_actionParams_UpdateDeviceCertificateParams_updateDeviceCertificateParams_Action;
                requestActionParams_actionParams_UpdateDeviceCertificateParamsIsNull = false;
            }
             // determine if requestActionParams_actionParams_UpdateDeviceCertificateParams should be set to null
            if (requestActionParams_actionParams_UpdateDeviceCertificateParamsIsNull)
            {
                requestActionParams_actionParams_UpdateDeviceCertificateParams = null;
            }
            if (requestActionParams_actionParams_UpdateDeviceCertificateParams != null)
            {
                request.ActionParams.UpdateDeviceCertificateParams = requestActionParams_actionParams_UpdateDeviceCertificateParams;
                requestActionParamsIsNull = false;
            }
            Amazon.IoT.Model.AddThingsToThingGroupParams requestActionParams_actionParams_AddThingsToThingGroupParams = null;
            
             // populate AddThingsToThingGroupParams
            var requestActionParams_actionParams_AddThingsToThingGroupParamsIsNull = true;
            requestActionParams_actionParams_AddThingsToThingGroupParams = new Amazon.IoT.Model.AddThingsToThingGroupParams();
            System.Boolean? requestActionParams_actionParams_AddThingsToThingGroupParams_addThingsToThingGroupParams_OverrideDynamicGroup = null;
            if (cmdletContext.AddThingsToThingGroupParams_OverrideDynamicGroup != null)
            {
                requestActionParams_actionParams_AddThingsToThingGroupParams_addThingsToThingGroupParams_OverrideDynamicGroup = cmdletContext.AddThingsToThingGroupParams_OverrideDynamicGroup.Value;
            }
            if (requestActionParams_actionParams_AddThingsToThingGroupParams_addThingsToThingGroupParams_OverrideDynamicGroup != null)
            {
                requestActionParams_actionParams_AddThingsToThingGroupParams.OverrideDynamicGroups = requestActionParams_actionParams_AddThingsToThingGroupParams_addThingsToThingGroupParams_OverrideDynamicGroup.Value;
                requestActionParams_actionParams_AddThingsToThingGroupParamsIsNull = false;
            }
            List<System.String> requestActionParams_actionParams_AddThingsToThingGroupParams_addThingsToThingGroupParams_ThingGroupName = null;
            if (cmdletContext.AddThingsToThingGroupParams_ThingGroupName != null)
            {
                requestActionParams_actionParams_AddThingsToThingGroupParams_addThingsToThingGroupParams_ThingGroupName = cmdletContext.AddThingsToThingGroupParams_ThingGroupName;
            }
            if (requestActionParams_actionParams_AddThingsToThingGroupParams_addThingsToThingGroupParams_ThingGroupName != null)
            {
                requestActionParams_actionParams_AddThingsToThingGroupParams.ThingGroupNames = requestActionParams_actionParams_AddThingsToThingGroupParams_addThingsToThingGroupParams_ThingGroupName;
                requestActionParams_actionParams_AddThingsToThingGroupParamsIsNull = false;
            }
             // determine if requestActionParams_actionParams_AddThingsToThingGroupParams should be set to null
            if (requestActionParams_actionParams_AddThingsToThingGroupParamsIsNull)
            {
                requestActionParams_actionParams_AddThingsToThingGroupParams = null;
            }
            if (requestActionParams_actionParams_AddThingsToThingGroupParams != null)
            {
                request.ActionParams.AddThingsToThingGroupParams = requestActionParams_actionParams_AddThingsToThingGroupParams;
                requestActionParamsIsNull = false;
            }
            Amazon.IoT.Model.EnableIoTLoggingParams requestActionParams_actionParams_EnableIoTLoggingParams = null;
            
             // populate EnableIoTLoggingParams
            var requestActionParams_actionParams_EnableIoTLoggingParamsIsNull = true;
            requestActionParams_actionParams_EnableIoTLoggingParams = new Amazon.IoT.Model.EnableIoTLoggingParams();
            Amazon.IoT.LogLevel requestActionParams_actionParams_EnableIoTLoggingParams_enableIoTLoggingParams_LogLevel = null;
            if (cmdletContext.EnableIoTLoggingParams_LogLevel != null)
            {
                requestActionParams_actionParams_EnableIoTLoggingParams_enableIoTLoggingParams_LogLevel = cmdletContext.EnableIoTLoggingParams_LogLevel;
            }
            if (requestActionParams_actionParams_EnableIoTLoggingParams_enableIoTLoggingParams_LogLevel != null)
            {
                requestActionParams_actionParams_EnableIoTLoggingParams.LogLevel = requestActionParams_actionParams_EnableIoTLoggingParams_enableIoTLoggingParams_LogLevel;
                requestActionParams_actionParams_EnableIoTLoggingParamsIsNull = false;
            }
            System.String requestActionParams_actionParams_EnableIoTLoggingParams_enableIoTLoggingParams_RoleArnForLogging = null;
            if (cmdletContext.EnableIoTLoggingParams_RoleArnForLogging != null)
            {
                requestActionParams_actionParams_EnableIoTLoggingParams_enableIoTLoggingParams_RoleArnForLogging = cmdletContext.EnableIoTLoggingParams_RoleArnForLogging;
            }
            if (requestActionParams_actionParams_EnableIoTLoggingParams_enableIoTLoggingParams_RoleArnForLogging != null)
            {
                requestActionParams_actionParams_EnableIoTLoggingParams.RoleArnForLogging = requestActionParams_actionParams_EnableIoTLoggingParams_enableIoTLoggingParams_RoleArnForLogging;
                requestActionParams_actionParams_EnableIoTLoggingParamsIsNull = false;
            }
             // determine if requestActionParams_actionParams_EnableIoTLoggingParams should be set to null
            if (requestActionParams_actionParams_EnableIoTLoggingParamsIsNull)
            {
                requestActionParams_actionParams_EnableIoTLoggingParams = null;
            }
            if (requestActionParams_actionParams_EnableIoTLoggingParams != null)
            {
                request.ActionParams.EnableIoTLoggingParams = requestActionParams_actionParams_EnableIoTLoggingParams;
                requestActionParamsIsNull = false;
            }
             // determine if request.ActionParams should be set to null
            if (requestActionParamsIsNull)
            {
                request.ActionParams = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IoT.Model.CreateMitigationActionResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateMitigationActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateMitigationAction");
            try
            {
                return client.CreateMitigationActionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActionName { get; set; }
            public System.Boolean? AddThingsToThingGroupParams_OverrideDynamicGroup { get; set; }
            public List<System.String> AddThingsToThingGroupParams_ThingGroupName { get; set; }
            public Amazon.IoT.LogLevel EnableIoTLoggingParams_LogLevel { get; set; }
            public System.String EnableIoTLoggingParams_RoleArnForLogging { get; set; }
            public System.String PublishFindingToSnsParams_TopicArn { get; set; }
            public Amazon.IoT.PolicyTemplateName ReplaceDefaultPolicyVersionParams_TemplateName { get; set; }
            public Amazon.IoT.CACertificateUpdateAction UpdateCACertificateParams_Action { get; set; }
            public Amazon.IoT.DeviceCertificateUpdateAction UpdateDeviceCertificateParams_Action { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.IoT.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoT.Model.CreateMitigationActionResponse, NewIOTMitigationActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

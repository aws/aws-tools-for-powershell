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
using Amazon.BedrockDataAutomation;
using Amazon.BedrockDataAutomation.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDA
{
    /// <summary>
    /// Async API: Invoke data automation library ingestion job
    /// </summary>
    [Cmdlet("Invoke", "BDADataAutomationLibraryIngestionJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Data Automation for Amazon Bedrock InvokeDataAutomationLibraryIngestionJob API operation.", Operation = new[] {"InvokeDataAutomationLibraryIngestionJob"}, SelectReturnType = typeof(Amazon.BedrockDataAutomation.Model.InvokeDataAutomationLibraryIngestionJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.BedrockDataAutomation.Model.InvokeDataAutomationLibraryIngestionJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BedrockDataAutomation.Model.InvokeDataAutomationLibraryIngestionJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeBDADataAutomationLibraryIngestionJobCmdlet : AmazonBedrockDataAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityId
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityIds")]
        public System.String[] InputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityId { get; set; }
        #endregion
        
        #region Parameter EntityType
        /// <summary>
        /// <para>
        /// <para>The entity type for which DataAutomationLibraryIngestionJob is being run</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.EntityType")]
        public Amazon.BedrockDataAutomation.EntityType EntityType { get; set; }
        #endregion
        
        #region Parameter NotificationConfiguration_EventBridgeConfiguration_EventBridgeEnabled
        /// <summary>
        /// <para>
        /// <para>Event bridge flag.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NotificationConfiguration_EventBridgeConfiguration_EventBridgeEnabled { get; set; }
        #endregion
        
        #region Parameter LibraryArn
        /// <summary>
        /// <para>
        /// <para>ARN generated at the server side when a DataAutomationLibrary is created</para>
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
        public System.String LibraryArn { get; set; }
        #endregion
        
        #region Parameter OperationType
        /// <summary>
        /// <para>
        /// <para>The operation to be performed by DataAutomationLibraryIngestionJob</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.LibraryIngestionJobOperationType")]
        public Amazon.BedrockDataAutomation.LibraryIngestionJobOperationType OperationType { get; set; }
        #endregion
        
        #region Parameter InputConfiguration_S3Object_S3Uri
        /// <summary>
        /// <para>
        /// <para>S3 uri.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfiguration_S3Object_S3Uri { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_S3Uri
        /// <summary>
        /// <para>
        /// <para>S3 Uri</para>
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
        public System.String OutputConfiguration_S3Uri { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>List of tags</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.BedrockDataAutomation.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter InputConfiguration_InlinePayload_UpsertEntitiesInfo
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.BedrockDataAutomation.Model.UpsertEntityInfo[] InputConfiguration_InlinePayload_UpsertEntitiesInfo { get; set; }
        #endregion
        
        #region Parameter InputConfiguration_S3Object_Version
        /// <summary>
        /// <para>
        /// <para>S3 object version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfiguration_S3Object_Version { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockDataAutomation.Model.InvokeDataAutomationLibraryIngestionJobResponse).
        /// Specifying the name of a property of type Amazon.BedrockDataAutomation.Model.InvokeDataAutomationLibraryIngestionJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LibraryArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BDADataAutomationLibraryIngestionJob (InvokeDataAutomationLibraryIngestionJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockDataAutomation.Model.InvokeDataAutomationLibraryIngestionJobResponse, InvokeBDADataAutomationLibraryIngestionJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.EntityType = this.EntityType;
            #if MODULAR
            if (this.EntityType == null && ParameterWasBound(nameof(this.EntityType)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityId != null)
            {
                context.InputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityId = new List<System.String>(this.InputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityId);
            }
            if (this.InputConfiguration_InlinePayload_UpsertEntitiesInfo != null)
            {
                context.InputConfiguration_InlinePayload_UpsertEntitiesInfo = new List<Amazon.BedrockDataAutomation.Model.UpsertEntityInfo>(this.InputConfiguration_InlinePayload_UpsertEntitiesInfo);
            }
            context.InputConfiguration_S3Object_S3Uri = this.InputConfiguration_S3Object_S3Uri;
            context.InputConfiguration_S3Object_Version = this.InputConfiguration_S3Object_Version;
            context.LibraryArn = this.LibraryArn;
            #if MODULAR
            if (this.LibraryArn == null && ParameterWasBound(nameof(this.LibraryArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LibraryArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotificationConfiguration_EventBridgeConfiguration_EventBridgeEnabled = this.NotificationConfiguration_EventBridgeConfiguration_EventBridgeEnabled;
            context.OperationType = this.OperationType;
            #if MODULAR
            if (this.OperationType == null && ParameterWasBound(nameof(this.OperationType)))
            {
                WriteWarning("You are passing $null as a value for parameter OperationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputConfiguration_S3Uri = this.OutputConfiguration_S3Uri;
            #if MODULAR
            if (this.OutputConfiguration_S3Uri == null && ParameterWasBound(nameof(this.OutputConfiguration_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfiguration_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.BedrockDataAutomation.Model.Tag>(this.Tag);
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
            var request = new Amazon.BedrockDataAutomation.Model.InvokeDataAutomationLibraryIngestionJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EntityType != null)
            {
                request.EntityType = cmdletContext.EntityType;
            }
            
             // populate InputConfiguration
            var requestInputConfigurationIsNull = true;
            request.InputConfiguration = new Amazon.BedrockDataAutomation.Model.InputConfiguration();
            Amazon.BedrockDataAutomation.Model.InlinePayload requestInputConfiguration_inputConfiguration_InlinePayload = null;
            
             // populate InlinePayload
            var requestInputConfiguration_inputConfiguration_InlinePayloadIsNull = true;
            requestInputConfiguration_inputConfiguration_InlinePayload = new Amazon.BedrockDataAutomation.Model.InlinePayload();
            List<Amazon.BedrockDataAutomation.Model.UpsertEntityInfo> requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_UpsertEntitiesInfo = null;
            if (cmdletContext.InputConfiguration_InlinePayload_UpsertEntitiesInfo != null)
            {
                requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_UpsertEntitiesInfo = cmdletContext.InputConfiguration_InlinePayload_UpsertEntitiesInfo;
            }
            if (requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_UpsertEntitiesInfo != null)
            {
                requestInputConfiguration_inputConfiguration_InlinePayload.UpsertEntitiesInfo = requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_UpsertEntitiesInfo;
                requestInputConfiguration_inputConfiguration_InlinePayloadIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.DeleteEntitiesInfo requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfo = null;
            
             // populate DeleteEntitiesInfo
            var requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfoIsNull = true;
            requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfo = new Amazon.BedrockDataAutomation.Model.DeleteEntitiesInfo();
            List<System.String> requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfo_inputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityId = null;
            if (cmdletContext.InputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityId != null)
            {
                requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfo_inputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityId = cmdletContext.InputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityId;
            }
            if (requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfo_inputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityId != null)
            {
                requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfo.EntityIds = requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfo_inputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityId;
                requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfoIsNull = false;
            }
             // determine if requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfo should be set to null
            if (requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfoIsNull)
            {
                requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfo = null;
            }
            if (requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfo != null)
            {
                requestInputConfiguration_inputConfiguration_InlinePayload.DeleteEntitiesInfo = requestInputConfiguration_inputConfiguration_InlinePayload_inputConfiguration_InlinePayload_DeleteEntitiesInfo;
                requestInputConfiguration_inputConfiguration_InlinePayloadIsNull = false;
            }
             // determine if requestInputConfiguration_inputConfiguration_InlinePayload should be set to null
            if (requestInputConfiguration_inputConfiguration_InlinePayloadIsNull)
            {
                requestInputConfiguration_inputConfiguration_InlinePayload = null;
            }
            if (requestInputConfiguration_inputConfiguration_InlinePayload != null)
            {
                request.InputConfiguration.InlinePayload = requestInputConfiguration_inputConfiguration_InlinePayload;
                requestInputConfigurationIsNull = false;
            }
            Amazon.BedrockDataAutomation.Model.S3Object requestInputConfiguration_inputConfiguration_S3Object = null;
            
             // populate S3Object
            var requestInputConfiguration_inputConfiguration_S3ObjectIsNull = true;
            requestInputConfiguration_inputConfiguration_S3Object = new Amazon.BedrockDataAutomation.Model.S3Object();
            System.String requestInputConfiguration_inputConfiguration_S3Object_inputConfiguration_S3Object_S3Uri = null;
            if (cmdletContext.InputConfiguration_S3Object_S3Uri != null)
            {
                requestInputConfiguration_inputConfiguration_S3Object_inputConfiguration_S3Object_S3Uri = cmdletContext.InputConfiguration_S3Object_S3Uri;
            }
            if (requestInputConfiguration_inputConfiguration_S3Object_inputConfiguration_S3Object_S3Uri != null)
            {
                requestInputConfiguration_inputConfiguration_S3Object.S3Uri = requestInputConfiguration_inputConfiguration_S3Object_inputConfiguration_S3Object_S3Uri;
                requestInputConfiguration_inputConfiguration_S3ObjectIsNull = false;
            }
            System.String requestInputConfiguration_inputConfiguration_S3Object_inputConfiguration_S3Object_Version = null;
            if (cmdletContext.InputConfiguration_S3Object_Version != null)
            {
                requestInputConfiguration_inputConfiguration_S3Object_inputConfiguration_S3Object_Version = cmdletContext.InputConfiguration_S3Object_Version;
            }
            if (requestInputConfiguration_inputConfiguration_S3Object_inputConfiguration_S3Object_Version != null)
            {
                requestInputConfiguration_inputConfiguration_S3Object.Version = requestInputConfiguration_inputConfiguration_S3Object_inputConfiguration_S3Object_Version;
                requestInputConfiguration_inputConfiguration_S3ObjectIsNull = false;
            }
             // determine if requestInputConfiguration_inputConfiguration_S3Object should be set to null
            if (requestInputConfiguration_inputConfiguration_S3ObjectIsNull)
            {
                requestInputConfiguration_inputConfiguration_S3Object = null;
            }
            if (requestInputConfiguration_inputConfiguration_S3Object != null)
            {
                request.InputConfiguration.S3Object = requestInputConfiguration_inputConfiguration_S3Object;
                requestInputConfigurationIsNull = false;
            }
             // determine if request.InputConfiguration should be set to null
            if (requestInputConfigurationIsNull)
            {
                request.InputConfiguration = null;
            }
            if (cmdletContext.LibraryArn != null)
            {
                request.LibraryArn = cmdletContext.LibraryArn;
            }
            
             // populate NotificationConfiguration
            var requestNotificationConfigurationIsNull = true;
            request.NotificationConfiguration = new Amazon.BedrockDataAutomation.Model.NotificationConfiguration();
            Amazon.BedrockDataAutomation.Model.EventBridgeConfiguration requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration = null;
            
             // populate EventBridgeConfiguration
            var requestNotificationConfiguration_notificationConfiguration_EventBridgeConfigurationIsNull = true;
            requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration = new Amazon.BedrockDataAutomation.Model.EventBridgeConfiguration();
            System.Boolean? requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration_notificationConfiguration_EventBridgeConfiguration_EventBridgeEnabled = null;
            if (cmdletContext.NotificationConfiguration_EventBridgeConfiguration_EventBridgeEnabled != null)
            {
                requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration_notificationConfiguration_EventBridgeConfiguration_EventBridgeEnabled = cmdletContext.NotificationConfiguration_EventBridgeConfiguration_EventBridgeEnabled.Value;
            }
            if (requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration_notificationConfiguration_EventBridgeConfiguration_EventBridgeEnabled != null)
            {
                requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration.EventBridgeEnabled = requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration_notificationConfiguration_EventBridgeConfiguration_EventBridgeEnabled.Value;
                requestNotificationConfiguration_notificationConfiguration_EventBridgeConfigurationIsNull = false;
            }
             // determine if requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration should be set to null
            if (requestNotificationConfiguration_notificationConfiguration_EventBridgeConfigurationIsNull)
            {
                requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration = null;
            }
            if (requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration != null)
            {
                request.NotificationConfiguration.EventBridgeConfiguration = requestNotificationConfiguration_notificationConfiguration_EventBridgeConfiguration;
                requestNotificationConfigurationIsNull = false;
            }
             // determine if request.NotificationConfiguration should be set to null
            if (requestNotificationConfigurationIsNull)
            {
                request.NotificationConfiguration = null;
            }
            if (cmdletContext.OperationType != null)
            {
                request.OperationType = cmdletContext.OperationType;
            }
            
             // populate OutputConfiguration
            var requestOutputConfigurationIsNull = true;
            request.OutputConfiguration = new Amazon.BedrockDataAutomation.Model.OutputConfiguration();
            System.String requestOutputConfiguration_outputConfiguration_S3Uri = null;
            if (cmdletContext.OutputConfiguration_S3Uri != null)
            {
                requestOutputConfiguration_outputConfiguration_S3Uri = cmdletContext.OutputConfiguration_S3Uri;
            }
            if (requestOutputConfiguration_outputConfiguration_S3Uri != null)
            {
                request.OutputConfiguration.S3Uri = requestOutputConfiguration_outputConfiguration_S3Uri;
                requestOutputConfigurationIsNull = false;
            }
             // determine if request.OutputConfiguration should be set to null
            if (requestOutputConfigurationIsNull)
            {
                request.OutputConfiguration = null;
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
        
        private Amazon.BedrockDataAutomation.Model.InvokeDataAutomationLibraryIngestionJobResponse CallAWSServiceOperation(IAmazonBedrockDataAutomation client, Amazon.BedrockDataAutomation.Model.InvokeDataAutomationLibraryIngestionJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Data Automation for Amazon Bedrock", "InvokeDataAutomationLibraryIngestionJob");
            try
            {
                return client.InvokeDataAutomationLibraryIngestionJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.BedrockDataAutomation.EntityType EntityType { get; set; }
            public List<System.String> InputConfiguration_InlinePayload_DeleteEntitiesInfo_EntityId { get; set; }
            public List<Amazon.BedrockDataAutomation.Model.UpsertEntityInfo> InputConfiguration_InlinePayload_UpsertEntitiesInfo { get; set; }
            public System.String InputConfiguration_S3Object_S3Uri { get; set; }
            public System.String InputConfiguration_S3Object_Version { get; set; }
            public System.String LibraryArn { get; set; }
            public System.Boolean? NotificationConfiguration_EventBridgeConfiguration_EventBridgeEnabled { get; set; }
            public Amazon.BedrockDataAutomation.LibraryIngestionJobOperationType OperationType { get; set; }
            public System.String OutputConfiguration_S3Uri { get; set; }
            public List<Amazon.BedrockDataAutomation.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.BedrockDataAutomation.Model.InvokeDataAutomationLibraryIngestionJobResponse, InvokeBDADataAutomationLibraryIngestionJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobArn;
        }
        
    }
}

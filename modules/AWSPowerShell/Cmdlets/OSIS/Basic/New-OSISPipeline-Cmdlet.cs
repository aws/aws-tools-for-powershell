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
using Amazon.OSIS;
using Amazon.OSIS.Model;

namespace Amazon.PowerShell.Cmdlets.OSIS
{
    /// <summary>
    /// Creates an OpenSearch Ingestion pipeline. For more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/creating-pipeline.html">Creating
    /// Amazon OpenSearch Ingestion pipelines</a>.
    /// </summary>
    [Cmdlet("New", "OSISPipeline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OSIS.Model.Pipeline")]
    [AWSCmdlet("Calls the Amazon OpenSearch Ingestion CreatePipeline API operation.", Operation = new[] {"CreatePipeline"}, SelectReturnType = typeof(Amazon.OSIS.Model.CreatePipelineResponse))]
    [AWSCmdletOutput("Amazon.OSIS.Model.Pipeline or Amazon.OSIS.Model.CreatePipelineResponse",
        "This cmdlet returns an Amazon.OSIS.Model.Pipeline object.",
        "The service call response (type Amazon.OSIS.Model.CreatePipelineResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewOSISPipelineCmdlet : AmazonOSISClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter VpcAttachmentOptions_AttachToVpc
        /// <summary>
        /// <para>
        /// <para>Whether a VPC is attached to the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcOptions_VpcAttachmentOptions_AttachToVpc")]
        public System.Boolean? VpcAttachmentOptions_AttachToVpc { get; set; }
        #endregion
        
        #region Parameter VpcAttachmentOptions_CidrBlock
        /// <summary>
        /// <para>
        /// <para>The CIDR block to be reserved for OpenSearch Ingestion to create elastic network interfaces
        /// (ENIs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcOptions_VpcAttachmentOptions_CidrBlock")]
        public System.String VpcAttachmentOptions_CidrBlock { get; set; }
        #endregion
        
        #region Parameter LogPublishingOptions_IsLoggingEnabled
        /// <summary>
        /// <para>
        /// <para>Whether logs should be published.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LogPublishingOptions_IsLoggingEnabled { get; set; }
        #endregion
        
        #region Parameter EncryptionAtRestOptions_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key used to encrypt buffer data. By default, data is encrypted
        /// using an Amazon Web Services owned key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionAtRestOptions_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogDestination_LogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs group to send pipeline logs to. You can specify an
        /// existing log group or create a new one. For example, <c>/aws/vendedlogs/OpenSearchService/pipelines</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogPublishingOptions_CloudWatchLogDestination_LogGroup")]
        public System.String CloudWatchLogDestination_LogGroup { get; set; }
        #endregion
        
        #region Parameter MaxUnit
        /// <summary>
        /// <para>
        /// <para>The maximum pipeline capacity, in Ingestion Compute Units (ICUs).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MaxUnits")]
        public System.Int32? MaxUnit { get; set; }
        #endregion
        
        #region Parameter MinUnit
        /// <summary>
        /// <para>
        /// <para>The minimum pipeline capacity, in Ingestion Compute Units (ICUs).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MinUnits")]
        public System.Int32? MinUnit { get; set; }
        #endregion
        
        #region Parameter BufferOptions_PersistentBufferEnabled
        /// <summary>
        /// <para>
        /// <para>Whether persistent buffering should be enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BufferOptions_PersistentBufferEnabled { get; set; }
        #endregion
        
        #region Parameter PipelineConfigurationBody
        /// <summary>
        /// <para>
        /// <para>The pipeline configuration in YAML format. The command accepts the pipeline configuration
        /// as a string or within a .yaml file. If you provide the configuration as a string,
        /// each new line must be escaped with <c>\n</c>.</para>
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
        public System.String PipelineConfigurationBody { get; set; }
        #endregion
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name of the OpenSearch Ingestion pipeline to create. Pipeline names are unique
        /// across the pipelines owned by an account within an Amazon Web Services Region.</para>
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
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter PipelineRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that provides the required permissions
        /// for a pipeline to read from the source and write to the sink. For more information,
        /// see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/pipeline-security-overview.html">Setting
        /// up roles and users in Amazon OpenSearch Ingestion</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineRoleArn { get; set; }
        #endregion
        
        #region Parameter VpcOptions_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of security groups associated with the VPC endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcOptions_SecurityGroupIds")]
        public System.String[] VpcOptions_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcOptions_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet IDs associated with the VPC endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcOptions_SubnetIds")]
        public System.String[] VpcOptions_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>List of tags to add to the pipeline upon creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.OSIS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VpcOptions_VpcEndpointManagement
        /// <summary>
        /// <para>
        /// <para>Defines whether you or Amazon OpenSearch Ingestion service create and manage the VPC
        /// endpoint configured for the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OSIS.VpcEndpointManagement")]
        public Amazon.OSIS.VpcEndpointManagement VpcOptions_VpcEndpointManagement { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Pipeline'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OSIS.Model.CreatePipelineResponse).
        /// Specifying the name of a property of type Amazon.OSIS.Model.CreatePipelineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Pipeline";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PipelineName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PipelineName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PipelineName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PipelineName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSISPipeline (CreatePipeline)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OSIS.Model.CreatePipelineResponse, NewOSISPipelineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PipelineName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BufferOptions_PersistentBufferEnabled = this.BufferOptions_PersistentBufferEnabled;
            context.EncryptionAtRestOptions_KmsKeyArn = this.EncryptionAtRestOptions_KmsKeyArn;
            context.CloudWatchLogDestination_LogGroup = this.CloudWatchLogDestination_LogGroup;
            context.LogPublishingOptions_IsLoggingEnabled = this.LogPublishingOptions_IsLoggingEnabled;
            context.MaxUnit = this.MaxUnit;
            #if MODULAR
            if (this.MaxUnit == null && ParameterWasBound(nameof(this.MaxUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter MaxUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinUnit = this.MinUnit;
            #if MODULAR
            if (this.MinUnit == null && ParameterWasBound(nameof(this.MinUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter MinUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PipelineConfigurationBody = this.PipelineConfigurationBody;
            #if MODULAR
            if (this.PipelineConfigurationBody == null && ParameterWasBound(nameof(this.PipelineConfigurationBody)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineConfigurationBody which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PipelineName = this.PipelineName;
            #if MODULAR
            if (this.PipelineName == null && ParameterWasBound(nameof(this.PipelineName)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PipelineRoleArn = this.PipelineRoleArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.OSIS.Model.Tag>(this.Tag);
            }
            if (this.VpcOptions_SecurityGroupId != null)
            {
                context.VpcOptions_SecurityGroupId = new List<System.String>(this.VpcOptions_SecurityGroupId);
            }
            if (this.VpcOptions_SubnetId != null)
            {
                context.VpcOptions_SubnetId = new List<System.String>(this.VpcOptions_SubnetId);
            }
            context.VpcAttachmentOptions_AttachToVpc = this.VpcAttachmentOptions_AttachToVpc;
            context.VpcAttachmentOptions_CidrBlock = this.VpcAttachmentOptions_CidrBlock;
            context.VpcOptions_VpcEndpointManagement = this.VpcOptions_VpcEndpointManagement;
            
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
            var request = new Amazon.OSIS.Model.CreatePipelineRequest();
            
            
             // populate BufferOptions
            var requestBufferOptionsIsNull = true;
            request.BufferOptions = new Amazon.OSIS.Model.BufferOptions();
            System.Boolean? requestBufferOptions_bufferOptions_PersistentBufferEnabled = null;
            if (cmdletContext.BufferOptions_PersistentBufferEnabled != null)
            {
                requestBufferOptions_bufferOptions_PersistentBufferEnabled = cmdletContext.BufferOptions_PersistentBufferEnabled.Value;
            }
            if (requestBufferOptions_bufferOptions_PersistentBufferEnabled != null)
            {
                request.BufferOptions.PersistentBufferEnabled = requestBufferOptions_bufferOptions_PersistentBufferEnabled.Value;
                requestBufferOptionsIsNull = false;
            }
             // determine if request.BufferOptions should be set to null
            if (requestBufferOptionsIsNull)
            {
                request.BufferOptions = null;
            }
            
             // populate EncryptionAtRestOptions
            var requestEncryptionAtRestOptionsIsNull = true;
            request.EncryptionAtRestOptions = new Amazon.OSIS.Model.EncryptionAtRestOptions();
            System.String requestEncryptionAtRestOptions_encryptionAtRestOptions_KmsKeyArn = null;
            if (cmdletContext.EncryptionAtRestOptions_KmsKeyArn != null)
            {
                requestEncryptionAtRestOptions_encryptionAtRestOptions_KmsKeyArn = cmdletContext.EncryptionAtRestOptions_KmsKeyArn;
            }
            if (requestEncryptionAtRestOptions_encryptionAtRestOptions_KmsKeyArn != null)
            {
                request.EncryptionAtRestOptions.KmsKeyArn = requestEncryptionAtRestOptions_encryptionAtRestOptions_KmsKeyArn;
                requestEncryptionAtRestOptionsIsNull = false;
            }
             // determine if request.EncryptionAtRestOptions should be set to null
            if (requestEncryptionAtRestOptionsIsNull)
            {
                request.EncryptionAtRestOptions = null;
            }
            
             // populate LogPublishingOptions
            var requestLogPublishingOptionsIsNull = true;
            request.LogPublishingOptions = new Amazon.OSIS.Model.LogPublishingOptions();
            System.Boolean? requestLogPublishingOptions_logPublishingOptions_IsLoggingEnabled = null;
            if (cmdletContext.LogPublishingOptions_IsLoggingEnabled != null)
            {
                requestLogPublishingOptions_logPublishingOptions_IsLoggingEnabled = cmdletContext.LogPublishingOptions_IsLoggingEnabled.Value;
            }
            if (requestLogPublishingOptions_logPublishingOptions_IsLoggingEnabled != null)
            {
                request.LogPublishingOptions.IsLoggingEnabled = requestLogPublishingOptions_logPublishingOptions_IsLoggingEnabled.Value;
                requestLogPublishingOptionsIsNull = false;
            }
            Amazon.OSIS.Model.CloudWatchLogDestination requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestination = null;
            
             // populate CloudWatchLogDestination
            var requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestinationIsNull = true;
            requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestination = new Amazon.OSIS.Model.CloudWatchLogDestination();
            System.String requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestination_cloudWatchLogDestination_LogGroup = null;
            if (cmdletContext.CloudWatchLogDestination_LogGroup != null)
            {
                requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestination_cloudWatchLogDestination_LogGroup = cmdletContext.CloudWatchLogDestination_LogGroup;
            }
            if (requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestination_cloudWatchLogDestination_LogGroup != null)
            {
                requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestination.LogGroup = requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestination_cloudWatchLogDestination_LogGroup;
                requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestinationIsNull = false;
            }
             // determine if requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestination should be set to null
            if (requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestinationIsNull)
            {
                requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestination = null;
            }
            if (requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestination != null)
            {
                request.LogPublishingOptions.CloudWatchLogDestination = requestLogPublishingOptions_logPublishingOptions_CloudWatchLogDestination;
                requestLogPublishingOptionsIsNull = false;
            }
             // determine if request.LogPublishingOptions should be set to null
            if (requestLogPublishingOptionsIsNull)
            {
                request.LogPublishingOptions = null;
            }
            if (cmdletContext.MaxUnit != null)
            {
                request.MaxUnits = cmdletContext.MaxUnit.Value;
            }
            if (cmdletContext.MinUnit != null)
            {
                request.MinUnits = cmdletContext.MinUnit.Value;
            }
            if (cmdletContext.PipelineConfigurationBody != null)
            {
                request.PipelineConfigurationBody = cmdletContext.PipelineConfigurationBody;
            }
            if (cmdletContext.PipelineName != null)
            {
                request.PipelineName = cmdletContext.PipelineName;
            }
            if (cmdletContext.PipelineRoleArn != null)
            {
                request.PipelineRoleArn = cmdletContext.PipelineRoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VpcOptions
            var requestVpcOptionsIsNull = true;
            request.VpcOptions = new Amazon.OSIS.Model.VpcOptions();
            List<System.String> requestVpcOptions_vpcOptions_SecurityGroupId = null;
            if (cmdletContext.VpcOptions_SecurityGroupId != null)
            {
                requestVpcOptions_vpcOptions_SecurityGroupId = cmdletContext.VpcOptions_SecurityGroupId;
            }
            if (requestVpcOptions_vpcOptions_SecurityGroupId != null)
            {
                request.VpcOptions.SecurityGroupIds = requestVpcOptions_vpcOptions_SecurityGroupId;
                requestVpcOptionsIsNull = false;
            }
            List<System.String> requestVpcOptions_vpcOptions_SubnetId = null;
            if (cmdletContext.VpcOptions_SubnetId != null)
            {
                requestVpcOptions_vpcOptions_SubnetId = cmdletContext.VpcOptions_SubnetId;
            }
            if (requestVpcOptions_vpcOptions_SubnetId != null)
            {
                request.VpcOptions.SubnetIds = requestVpcOptions_vpcOptions_SubnetId;
                requestVpcOptionsIsNull = false;
            }
            Amazon.OSIS.VpcEndpointManagement requestVpcOptions_vpcOptions_VpcEndpointManagement = null;
            if (cmdletContext.VpcOptions_VpcEndpointManagement != null)
            {
                requestVpcOptions_vpcOptions_VpcEndpointManagement = cmdletContext.VpcOptions_VpcEndpointManagement;
            }
            if (requestVpcOptions_vpcOptions_VpcEndpointManagement != null)
            {
                request.VpcOptions.VpcEndpointManagement = requestVpcOptions_vpcOptions_VpcEndpointManagement;
                requestVpcOptionsIsNull = false;
            }
            Amazon.OSIS.Model.VpcAttachmentOptions requestVpcOptions_vpcOptions_VpcAttachmentOptions = null;
            
             // populate VpcAttachmentOptions
            var requestVpcOptions_vpcOptions_VpcAttachmentOptionsIsNull = true;
            requestVpcOptions_vpcOptions_VpcAttachmentOptions = new Amazon.OSIS.Model.VpcAttachmentOptions();
            System.Boolean? requestVpcOptions_vpcOptions_VpcAttachmentOptions_vpcAttachmentOptions_AttachToVpc = null;
            if (cmdletContext.VpcAttachmentOptions_AttachToVpc != null)
            {
                requestVpcOptions_vpcOptions_VpcAttachmentOptions_vpcAttachmentOptions_AttachToVpc = cmdletContext.VpcAttachmentOptions_AttachToVpc.Value;
            }
            if (requestVpcOptions_vpcOptions_VpcAttachmentOptions_vpcAttachmentOptions_AttachToVpc != null)
            {
                requestVpcOptions_vpcOptions_VpcAttachmentOptions.AttachToVpc = requestVpcOptions_vpcOptions_VpcAttachmentOptions_vpcAttachmentOptions_AttachToVpc.Value;
                requestVpcOptions_vpcOptions_VpcAttachmentOptionsIsNull = false;
            }
            System.String requestVpcOptions_vpcOptions_VpcAttachmentOptions_vpcAttachmentOptions_CidrBlock = null;
            if (cmdletContext.VpcAttachmentOptions_CidrBlock != null)
            {
                requestVpcOptions_vpcOptions_VpcAttachmentOptions_vpcAttachmentOptions_CidrBlock = cmdletContext.VpcAttachmentOptions_CidrBlock;
            }
            if (requestVpcOptions_vpcOptions_VpcAttachmentOptions_vpcAttachmentOptions_CidrBlock != null)
            {
                requestVpcOptions_vpcOptions_VpcAttachmentOptions.CidrBlock = requestVpcOptions_vpcOptions_VpcAttachmentOptions_vpcAttachmentOptions_CidrBlock;
                requestVpcOptions_vpcOptions_VpcAttachmentOptionsIsNull = false;
            }
             // determine if requestVpcOptions_vpcOptions_VpcAttachmentOptions should be set to null
            if (requestVpcOptions_vpcOptions_VpcAttachmentOptionsIsNull)
            {
                requestVpcOptions_vpcOptions_VpcAttachmentOptions = null;
            }
            if (requestVpcOptions_vpcOptions_VpcAttachmentOptions != null)
            {
                request.VpcOptions.VpcAttachmentOptions = requestVpcOptions_vpcOptions_VpcAttachmentOptions;
                requestVpcOptionsIsNull = false;
            }
             // determine if request.VpcOptions should be set to null
            if (requestVpcOptionsIsNull)
            {
                request.VpcOptions = null;
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
        
        private Amazon.OSIS.Model.CreatePipelineResponse CallAWSServiceOperation(IAmazonOSIS client, Amazon.OSIS.Model.CreatePipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Ingestion", "CreatePipeline");
            try
            {
                #if DESKTOP
                return client.CreatePipeline(request);
                #elif CORECLR
                return client.CreatePipelineAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? BufferOptions_PersistentBufferEnabled { get; set; }
            public System.String EncryptionAtRestOptions_KmsKeyArn { get; set; }
            public System.String CloudWatchLogDestination_LogGroup { get; set; }
            public System.Boolean? LogPublishingOptions_IsLoggingEnabled { get; set; }
            public System.Int32? MaxUnit { get; set; }
            public System.Int32? MinUnit { get; set; }
            public System.String PipelineConfigurationBody { get; set; }
            public System.String PipelineName { get; set; }
            public System.String PipelineRoleArn { get; set; }
            public List<Amazon.OSIS.Model.Tag> Tag { get; set; }
            public List<System.String> VpcOptions_SecurityGroupId { get; set; }
            public List<System.String> VpcOptions_SubnetId { get; set; }
            public System.Boolean? VpcAttachmentOptions_AttachToVpc { get; set; }
            public System.String VpcAttachmentOptions_CidrBlock { get; set; }
            public Amazon.OSIS.VpcEndpointManagement VpcOptions_VpcEndpointManagement { get; set; }
            public System.Func<Amazon.OSIS.Model.CreatePipelineResponse, NewOSISPipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Pipeline;
        }
        
    }
}

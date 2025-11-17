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
using Amazon.MWAAServerless;
using Amazon.MWAAServerless.Model;

namespace Amazon.PowerShell.Cmdlets.MWAAS
{
    /// <summary>
    /// Updates an existing workflow with new configuration settings. This operation allows
    /// you to modify the workflow definition, role, and other settings. When you update a
    /// workflow, Amazon Managed Workflows for Apache Airflow Serverless automatically creates
    /// a new version with the updated configuration and disables scheduling on all previous
    /// versions to ensure only one version is actively scheduled at a time. The update operation
    /// maintains workflow history while providing a clean transition to the new configuration.
    /// </summary>
    [Cmdlet("Update", "MWAASWorkflow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MWAAServerless.Model.UpdateWorkflowResponse")]
    [AWSCmdlet("Calls the AmazonMWAAServerless UpdateWorkflow API operation.", Operation = new[] {"UpdateWorkflow"}, SelectReturnType = typeof(Amazon.MWAAServerless.Model.UpdateWorkflowResponse))]
    [AWSCmdletOutput("Amazon.MWAAServerless.Model.UpdateWorkflowResponse",
        "This cmdlet returns an Amazon.MWAAServerless.Model.UpdateWorkflowResponse object containing multiple properties."
    )]
    public partial class UpdateMWAASWorkflowCmdlet : AmazonMWAAServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DefinitionS3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket that contains the workflow definition file.</para>
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
        public System.String DefinitionS3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An updated description for the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version of the Amazon Managed Workflows for Apache Airflow Serverless engine that
        /// you want to use for the updated workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EngineVersion { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch log group where workflow execution logs are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfiguration_LogGroupName { get; set; }
        #endregion
        
        #region Parameter DefinitionS3Location_ObjectKey
        /// <summary>
        /// <para>
        /// <para>The key (name) of the workflow definition file within the S3 bucket.</para>
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
        public System.String DefinitionS3Location_ObjectKey { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Amazon Managed Workflows for Apache
        /// Airflow Serverless assumes when it executes the updated workflow.</para>
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
        
        #region Parameter NetworkConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of VPC security group IDs to associate with the workflow execution environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_SecurityGroupIds")]
        public System.String[] NetworkConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of VPC subnet IDs where the workflow execution environment is deployed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_SubnetIds")]
        public System.String[] NetworkConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter TriggerMode
        /// <summary>
        /// <para>
        /// <para>The trigger mode for the workflow execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TriggerMode { get; set; }
        #endregion
        
        #region Parameter DefinitionS3Location_VersionId
        /// <summary>
        /// <para>
        /// <para>Optional. The version ID of the workflow definition file in Amazon S3. If not specified,
        /// the latest version is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefinitionS3Location_VersionId { get; set; }
        #endregion
        
        #region Parameter WorkflowArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the workflow you want to update.</para>
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
        public System.String WorkflowArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MWAAServerless.Model.UpdateWorkflowResponse).
        /// Specifying the name of a property of type Amazon.MWAAServerless.Model.UpdateWorkflowResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkflowArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MWAASWorkflow (UpdateWorkflow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MWAAServerless.Model.UpdateWorkflowResponse, UpdateMWAASWorkflowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DefinitionS3Location_Bucket = this.DefinitionS3Location_Bucket;
            #if MODULAR
            if (this.DefinitionS3Location_Bucket == null && ParameterWasBound(nameof(this.DefinitionS3Location_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter DefinitionS3Location_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefinitionS3Location_ObjectKey = this.DefinitionS3Location_ObjectKey;
            #if MODULAR
            if (this.DefinitionS3Location_ObjectKey == null && ParameterWasBound(nameof(this.DefinitionS3Location_ObjectKey)))
            {
                WriteWarning("You are passing $null as a value for parameter DefinitionS3Location_ObjectKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefinitionS3Location_VersionId = this.DefinitionS3Location_VersionId;
            context.Description = this.Description;
            context.EngineVersion = this.EngineVersion;
            context.LoggingConfiguration_LogGroupName = this.LoggingConfiguration_LogGroupName;
            if (this.NetworkConfiguration_SecurityGroupId != null)
            {
                context.NetworkConfiguration_SecurityGroupId = new List<System.String>(this.NetworkConfiguration_SecurityGroupId);
            }
            if (this.NetworkConfiguration_SubnetId != null)
            {
                context.NetworkConfiguration_SubnetId = new List<System.String>(this.NetworkConfiguration_SubnetId);
            }
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TriggerMode = this.TriggerMode;
            context.WorkflowArn = this.WorkflowArn;
            #if MODULAR
            if (this.WorkflowArn == null && ParameterWasBound(nameof(this.WorkflowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MWAAServerless.Model.UpdateWorkflowRequest();
            
            
             // populate DefinitionS3Location
            var requestDefinitionS3LocationIsNull = true;
            request.DefinitionS3Location = new Amazon.MWAAServerless.Model.DefinitionS3Location();
            System.String requestDefinitionS3Location_definitionS3Location_Bucket = null;
            if (cmdletContext.DefinitionS3Location_Bucket != null)
            {
                requestDefinitionS3Location_definitionS3Location_Bucket = cmdletContext.DefinitionS3Location_Bucket;
            }
            if (requestDefinitionS3Location_definitionS3Location_Bucket != null)
            {
                request.DefinitionS3Location.Bucket = requestDefinitionS3Location_definitionS3Location_Bucket;
                requestDefinitionS3LocationIsNull = false;
            }
            System.String requestDefinitionS3Location_definitionS3Location_ObjectKey = null;
            if (cmdletContext.DefinitionS3Location_ObjectKey != null)
            {
                requestDefinitionS3Location_definitionS3Location_ObjectKey = cmdletContext.DefinitionS3Location_ObjectKey;
            }
            if (requestDefinitionS3Location_definitionS3Location_ObjectKey != null)
            {
                request.DefinitionS3Location.ObjectKey = requestDefinitionS3Location_definitionS3Location_ObjectKey;
                requestDefinitionS3LocationIsNull = false;
            }
            System.String requestDefinitionS3Location_definitionS3Location_VersionId = null;
            if (cmdletContext.DefinitionS3Location_VersionId != null)
            {
                requestDefinitionS3Location_definitionS3Location_VersionId = cmdletContext.DefinitionS3Location_VersionId;
            }
            if (requestDefinitionS3Location_definitionS3Location_VersionId != null)
            {
                request.DefinitionS3Location.VersionId = requestDefinitionS3Location_definitionS3Location_VersionId;
                requestDefinitionS3LocationIsNull = false;
            }
             // determine if request.DefinitionS3Location should be set to null
            if (requestDefinitionS3LocationIsNull)
            {
                request.DefinitionS3Location = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion.Value;
            }
            
             // populate LoggingConfiguration
            var requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.MWAAServerless.Model.LoggingConfiguration();
            System.String requestLoggingConfiguration_loggingConfiguration_LogGroupName = null;
            if (cmdletContext.LoggingConfiguration_LogGroupName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_LogGroupName = cmdletContext.LoggingConfiguration_LogGroupName;
            }
            if (requestLoggingConfiguration_loggingConfiguration_LogGroupName != null)
            {
                request.LoggingConfiguration.LogGroupName = requestLoggingConfiguration_loggingConfiguration_LogGroupName;
                requestLoggingConfigurationIsNull = false;
            }
             // determine if request.LoggingConfiguration should be set to null
            if (requestLoggingConfigurationIsNull)
            {
                request.LoggingConfiguration = null;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.MWAAServerless.Model.NetworkConfiguration();
            List<System.String> requestNetworkConfiguration_networkConfiguration_SecurityGroupId = null;
            if (cmdletContext.NetworkConfiguration_SecurityGroupId != null)
            {
                requestNetworkConfiguration_networkConfiguration_SecurityGroupId = cmdletContext.NetworkConfiguration_SecurityGroupId;
            }
            if (requestNetworkConfiguration_networkConfiguration_SecurityGroupId != null)
            {
                request.NetworkConfiguration.SecurityGroupIds = requestNetworkConfiguration_networkConfiguration_SecurityGroupId;
                requestNetworkConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_SubnetId = null;
            if (cmdletContext.NetworkConfiguration_SubnetId != null)
            {
                requestNetworkConfiguration_networkConfiguration_SubnetId = cmdletContext.NetworkConfiguration_SubnetId;
            }
            if (requestNetworkConfiguration_networkConfiguration_SubnetId != null)
            {
                request.NetworkConfiguration.SubnetIds = requestNetworkConfiguration_networkConfiguration_SubnetId;
                requestNetworkConfigurationIsNull = false;
            }
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.TriggerMode != null)
            {
                request.TriggerMode = cmdletContext.TriggerMode;
            }
            if (cmdletContext.WorkflowArn != null)
            {
                request.WorkflowArn = cmdletContext.WorkflowArn;
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
        
        private Amazon.MWAAServerless.Model.UpdateWorkflowResponse CallAWSServiceOperation(IAmazonMWAAServerless client, Amazon.MWAAServerless.Model.UpdateWorkflowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonMWAAServerless", "UpdateWorkflow");
            try
            {
                #if DESKTOP
                return client.UpdateWorkflow(request);
                #elif CORECLR
                return client.UpdateWorkflowAsync(request).GetAwaiter().GetResult();
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
            public System.String DefinitionS3Location_Bucket { get; set; }
            public System.String DefinitionS3Location_ObjectKey { get; set; }
            public System.String DefinitionS3Location_VersionId { get; set; }
            public System.String Description { get; set; }
            public System.Int32? EngineVersion { get; set; }
            public System.String LoggingConfiguration_LogGroupName { get; set; }
            public List<System.String> NetworkConfiguration_SecurityGroupId { get; set; }
            public List<System.String> NetworkConfiguration_SubnetId { get; set; }
            public System.String RoleArn { get; set; }
            public System.String TriggerMode { get; set; }
            public System.String WorkflowArn { get; set; }
            public System.Func<Amazon.MWAAServerless.Model.UpdateWorkflowResponse, UpdateMWAASWorkflowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

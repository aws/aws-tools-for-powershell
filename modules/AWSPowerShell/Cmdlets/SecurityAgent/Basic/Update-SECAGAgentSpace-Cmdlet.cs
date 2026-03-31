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
using Amazon.SecurityAgent;
using Amazon.SecurityAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SECAG
{
    /// <summary>
    /// Updates an agent space record
    /// </summary>
    [Cmdlet("Update", "SECAGAgentSpace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityAgent.Model.UpdateAgentSpaceResponse")]
    [AWSCmdlet("Calls the AWS Security Agent UpdateAgentSpace API operation.", Operation = new[] {"UpdateAgentSpace"}, SelectReturnType = typeof(Amazon.SecurityAgent.Model.UpdateAgentSpaceResponse))]
    [AWSCmdletOutput("Amazon.SecurityAgent.Model.UpdateAgentSpaceResponse",
        "This cmdlet returns an Amazon.SecurityAgent.Model.UpdateAgentSpaceResponse object containing multiple properties."
    )]
    public partial class UpdateSECAGAgentSpaceCmdlet : AmazonSecurityAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>ID of the agent space to update</para>
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
        public System.String AgentSpaceId { get; set; }
        #endregion
        
        #region Parameter CodeReviewSettings_ControlsScanning
        /// <summary>
        /// <para>
        /// <para>Whether Controls are utilized for code review analysis</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CodeReviewSettings_ControlsScanning { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Description of the agent space</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter CodeReviewSettings_GeneralPurposeScanning
        /// <summary>
        /// <para>
        /// <para>Whether general purpose analysis is performed for code review</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CodeReviewSettings_GeneralPurposeScanning { get; set; }
        #endregion
        
        #region Parameter AwsResources_IamRole
        /// <summary>
        /// <para>
        /// <para>IAM role ARNs that the Security Agent can assume to access customer resources</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsResources_IamRoles")]
        public System.String[] AwsResources_IamRole { get; set; }
        #endregion
        
        #region Parameter AwsResources_LambdaFunctionArn
        /// <summary>
        /// <para>
        /// <para>Lambda function ARNs or names used to retrieve tester credentials for pentests</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsResources_LambdaFunctionArns")]
        public System.String[] AwsResources_LambdaFunctionArn { get; set; }
        #endregion
        
        #region Parameter AwsResources_LogGroup
        /// <summary>
        /// <para>
        /// <para>CloudWatch log group ARNs or names used to store Security Agent logs</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsResources_LogGroups")]
        public System.String[] AwsResources_LogGroup { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the agent space</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter AwsResources_S3Bucket
        /// <summary>
        /// <para>
        /// <para>S3 bucket ARNs or names used to store Security Agent artifacts</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsResources_S3Buckets")]
        public System.String[] AwsResources_S3Bucket { get; set; }
        #endregion
        
        #region Parameter AwsResources_SecretArn
        /// <summary>
        /// <para>
        /// <para>SecretsManager secret ARNs or names used to store tester credentials for pentests</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsResources_SecretArns")]
        public System.String[] AwsResources_SecretArn { get; set; }
        #endregion
        
        #region Parameter TargetDomainId
        /// <summary>
        /// <para>
        /// <para>Target domain IDs to associate with the agent space</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetDomainIds")]
        public System.String[] TargetDomainId { get; set; }
        #endregion
        
        #region Parameter AwsResources_Vpc
        /// <summary>
        /// <para>
        /// <para>VPC configurations that the Security Agent accesses in the customer environment</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsResources_Vpcs")]
        public Amazon.SecurityAgent.Model.VpcConfig[] AwsResources_Vpc { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityAgent.Model.UpdateAgentSpaceResponse).
        /// Specifying the name of a property of type Amazon.SecurityAgent.Model.UpdateAgentSpaceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentSpaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SECAGAgentSpace (UpdateAgentSpace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityAgent.Model.UpdateAgentSpaceResponse, UpdateSECAGAgentSpaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AwsResources_IamRole != null)
            {
                context.AwsResources_IamRole = new List<System.String>(this.AwsResources_IamRole);
            }
            if (this.AwsResources_LambdaFunctionArn != null)
            {
                context.AwsResources_LambdaFunctionArn = new List<System.String>(this.AwsResources_LambdaFunctionArn);
            }
            if (this.AwsResources_LogGroup != null)
            {
                context.AwsResources_LogGroup = new List<System.String>(this.AwsResources_LogGroup);
            }
            if (this.AwsResources_S3Bucket != null)
            {
                context.AwsResources_S3Bucket = new List<System.String>(this.AwsResources_S3Bucket);
            }
            if (this.AwsResources_SecretArn != null)
            {
                context.AwsResources_SecretArn = new List<System.String>(this.AwsResources_SecretArn);
            }
            if (this.AwsResources_Vpc != null)
            {
                context.AwsResources_Vpc = new List<Amazon.SecurityAgent.Model.VpcConfig>(this.AwsResources_Vpc);
            }
            context.CodeReviewSettings_ControlsScanning = this.CodeReviewSettings_ControlsScanning;
            context.CodeReviewSettings_GeneralPurposeScanning = this.CodeReviewSettings_GeneralPurposeScanning;
            context.Description = this.Description;
            context.Name = this.Name;
            if (this.TargetDomainId != null)
            {
                context.TargetDomainId = new List<System.String>(this.TargetDomainId);
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
            var request = new Amazon.SecurityAgent.Model.UpdateAgentSpaceRequest();
            
            if (cmdletContext.AgentSpaceId != null)
            {
                request.AgentSpaceId = cmdletContext.AgentSpaceId;
            }
            
             // populate AwsResources
            var requestAwsResourcesIsNull = true;
            request.AwsResources = new Amazon.SecurityAgent.Model.AWSResources();
            List<System.String> requestAwsResources_awsResources_IamRole = null;
            if (cmdletContext.AwsResources_IamRole != null)
            {
                requestAwsResources_awsResources_IamRole = cmdletContext.AwsResources_IamRole;
            }
            if (requestAwsResources_awsResources_IamRole != null)
            {
                request.AwsResources.IamRoles = requestAwsResources_awsResources_IamRole;
                requestAwsResourcesIsNull = false;
            }
            List<System.String> requestAwsResources_awsResources_LambdaFunctionArn = null;
            if (cmdletContext.AwsResources_LambdaFunctionArn != null)
            {
                requestAwsResources_awsResources_LambdaFunctionArn = cmdletContext.AwsResources_LambdaFunctionArn;
            }
            if (requestAwsResources_awsResources_LambdaFunctionArn != null)
            {
                request.AwsResources.LambdaFunctionArns = requestAwsResources_awsResources_LambdaFunctionArn;
                requestAwsResourcesIsNull = false;
            }
            List<System.String> requestAwsResources_awsResources_LogGroup = null;
            if (cmdletContext.AwsResources_LogGroup != null)
            {
                requestAwsResources_awsResources_LogGroup = cmdletContext.AwsResources_LogGroup;
            }
            if (requestAwsResources_awsResources_LogGroup != null)
            {
                request.AwsResources.LogGroups = requestAwsResources_awsResources_LogGroup;
                requestAwsResourcesIsNull = false;
            }
            List<System.String> requestAwsResources_awsResources_S3Bucket = null;
            if (cmdletContext.AwsResources_S3Bucket != null)
            {
                requestAwsResources_awsResources_S3Bucket = cmdletContext.AwsResources_S3Bucket;
            }
            if (requestAwsResources_awsResources_S3Bucket != null)
            {
                request.AwsResources.S3Buckets = requestAwsResources_awsResources_S3Bucket;
                requestAwsResourcesIsNull = false;
            }
            List<System.String> requestAwsResources_awsResources_SecretArn = null;
            if (cmdletContext.AwsResources_SecretArn != null)
            {
                requestAwsResources_awsResources_SecretArn = cmdletContext.AwsResources_SecretArn;
            }
            if (requestAwsResources_awsResources_SecretArn != null)
            {
                request.AwsResources.SecretArns = requestAwsResources_awsResources_SecretArn;
                requestAwsResourcesIsNull = false;
            }
            List<Amazon.SecurityAgent.Model.VpcConfig> requestAwsResources_awsResources_Vpc = null;
            if (cmdletContext.AwsResources_Vpc != null)
            {
                requestAwsResources_awsResources_Vpc = cmdletContext.AwsResources_Vpc;
            }
            if (requestAwsResources_awsResources_Vpc != null)
            {
                request.AwsResources.Vpcs = requestAwsResources_awsResources_Vpc;
                requestAwsResourcesIsNull = false;
            }
             // determine if request.AwsResources should be set to null
            if (requestAwsResourcesIsNull)
            {
                request.AwsResources = null;
            }
            
             // populate CodeReviewSettings
            var requestCodeReviewSettingsIsNull = true;
            request.CodeReviewSettings = new Amazon.SecurityAgent.Model.CodeReviewSettings();
            System.Boolean? requestCodeReviewSettings_codeReviewSettings_ControlsScanning = null;
            if (cmdletContext.CodeReviewSettings_ControlsScanning != null)
            {
                requestCodeReviewSettings_codeReviewSettings_ControlsScanning = cmdletContext.CodeReviewSettings_ControlsScanning.Value;
            }
            if (requestCodeReviewSettings_codeReviewSettings_ControlsScanning != null)
            {
                request.CodeReviewSettings.ControlsScanning = requestCodeReviewSettings_codeReviewSettings_ControlsScanning.Value;
                requestCodeReviewSettingsIsNull = false;
            }
            System.Boolean? requestCodeReviewSettings_codeReviewSettings_GeneralPurposeScanning = null;
            if (cmdletContext.CodeReviewSettings_GeneralPurposeScanning != null)
            {
                requestCodeReviewSettings_codeReviewSettings_GeneralPurposeScanning = cmdletContext.CodeReviewSettings_GeneralPurposeScanning.Value;
            }
            if (requestCodeReviewSettings_codeReviewSettings_GeneralPurposeScanning != null)
            {
                request.CodeReviewSettings.GeneralPurposeScanning = requestCodeReviewSettings_codeReviewSettings_GeneralPurposeScanning.Value;
                requestCodeReviewSettingsIsNull = false;
            }
             // determine if request.CodeReviewSettings should be set to null
            if (requestCodeReviewSettingsIsNull)
            {
                request.CodeReviewSettings = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.TargetDomainId != null)
            {
                request.TargetDomainIds = cmdletContext.TargetDomainId;
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
        
        private Amazon.SecurityAgent.Model.UpdateAgentSpaceResponse CallAWSServiceOperation(IAmazonSecurityAgent client, Amazon.SecurityAgent.Model.UpdateAgentSpaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Agent", "UpdateAgentSpace");
            try
            {
                return client.UpdateAgentSpaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentSpaceId { get; set; }
            public List<System.String> AwsResources_IamRole { get; set; }
            public List<System.String> AwsResources_LambdaFunctionArn { get; set; }
            public List<System.String> AwsResources_LogGroup { get; set; }
            public List<System.String> AwsResources_S3Bucket { get; set; }
            public List<System.String> AwsResources_SecretArn { get; set; }
            public List<Amazon.SecurityAgent.Model.VpcConfig> AwsResources_Vpc { get; set; }
            public System.Boolean? CodeReviewSettings_ControlsScanning { get; set; }
            public System.Boolean? CodeReviewSettings_GeneralPurposeScanning { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<System.String> TargetDomainId { get; set; }
            public System.Func<Amazon.SecurityAgent.Model.UpdateAgentSpaceResponse, UpdateSECAGAgentSpaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

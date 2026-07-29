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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Updates a workspace. You can update only workspaces in the <c>ACTIVE</c> or <c>FAILED</c>
    /// state. Fields that you omit from the request are left unchanged. To recover a workspace
    /// in the <c>FAILED</c> state, call this operation and supply its encryption configuration
    /// again.
    /// </summary>
    [Cmdlet("Update", "IOTSWWorkspace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.WorkspaceStatus")]
    [AWSCmdlet("Calls the AWS IoT SiteWise UpdateWorkspace API operation.", Operation = new[] {"UpdateWorkspace"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.UpdateWorkspaceResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.WorkspaceStatus or Amazon.IoTSiteWise.Model.UpdateWorkspaceResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.WorkspaceStatus object.",
        "The service call response (type Amazon.IoTSiteWise.Model.UpdateWorkspaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTSWWorkspaceCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EncryptionConfiguration_EncryptionType
        /// <summary>
        /// <para>
        /// <para>The encryption scheme for the workspace. <c>SITEWISE_DEFAULT_ENCRYPTION</c> encrypts
        /// data with the IoT SiteWise default key. <c>KMS_BASED_ENCRYPTION</c> encrypts data
        /// with the customer managed KMS key identified by <c>kmsKeyId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.EncryptionType")]
        public Amazon.IoTSiteWise.EncryptionType EncryptionConfiguration_EncryptionType { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The customer managed KMS key used when <c>encryptionType</c> is <c>KMS_BASED_ENCRYPTION</c>.
        /// Accepts a key ID, key ARN, or key alias. Required for <c>KMS_BASED_ENCRYPTION</c>;
        /// must be omitted for <c>SITEWISE_DEFAULT_ENCRYPTION</c>. After a workspace's customer
        /// managed key configuration becomes active, the key can't be changed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter WorkspaceDescription
        /// <summary>
        /// <para>
        /// <para>A new description for the workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceDescription { get; set; }
        #endregion
        
        #region Parameter WorkspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the workspace to update.</para>
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
        public System.String WorkspaceName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure that the request is
        /// idempotent. If you retry a request that completed successfully using the same client
        /// token, the retry succeeds without performing any further actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WorkspaceStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.UpdateWorkspaceResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.UpdateWorkspaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WorkspaceStatus";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkspaceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSWWorkspace (UpdateWorkspace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.UpdateWorkspaceResponse, UpdateIOTSWWorkspaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.EncryptionConfiguration_EncryptionType = this.EncryptionConfiguration_EncryptionType;
            context.EncryptionConfiguration_KmsKeyId = this.EncryptionConfiguration_KmsKeyId;
            context.WorkspaceDescription = this.WorkspaceDescription;
            context.WorkspaceName = this.WorkspaceName;
            #if MODULAR
            if (this.WorkspaceName == null && ParameterWasBound(nameof(this.WorkspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSiteWise.Model.UpdateWorkspaceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.IoTSiteWise.Model.WorkspaceEncryptionConfiguration();
            Amazon.IoTSiteWise.EncryptionType requestEncryptionConfiguration_encryptionConfiguration_EncryptionType = null;
            if (cmdletContext.EncryptionConfiguration_EncryptionType != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_EncryptionType = cmdletContext.EncryptionConfiguration_EncryptionType;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_EncryptionType != null)
            {
                request.EncryptionConfiguration.EncryptionType = requestEncryptionConfiguration_encryptionConfiguration_EncryptionType;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = cmdletContext.EncryptionConfiguration_KmsKeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId != null)
            {
                request.EncryptionConfiguration.KmsKeyId = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.WorkspaceDescription != null)
            {
                request.WorkspaceDescription = cmdletContext.WorkspaceDescription;
            }
            if (cmdletContext.WorkspaceName != null)
            {
                request.WorkspaceName = cmdletContext.WorkspaceName;
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
        
        private Amazon.IoTSiteWise.Model.UpdateWorkspaceResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.UpdateWorkspaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "UpdateWorkspace");
            try
            {
                return client.UpdateWorkspaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.IoTSiteWise.EncryptionType EncryptionConfiguration_EncryptionType { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public System.String WorkspaceDescription { get; set; }
            public System.String WorkspaceName { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.UpdateWorkspaceResponse, UpdateIOTSWWorkspaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WorkspaceStatus;
        }
        
    }
}

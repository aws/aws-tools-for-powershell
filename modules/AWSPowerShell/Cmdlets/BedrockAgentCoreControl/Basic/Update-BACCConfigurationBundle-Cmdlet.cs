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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Updates a configuration bundle by creating a new version with the specified changes.
    /// Each update creates a new version in the version history.
    /// </summary>
    [Cmdlet("Update", "BACCConfigurationBundle", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.UpdateConfigurationBundleResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer UpdateConfigurationBundle API operation.", Operation = new[] {"UpdateConfigurationBundle"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.UpdateConfigurationBundleResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.UpdateConfigurationBundleResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.UpdateConfigurationBundleResponse object containing multiple properties."
    )]
    public partial class UpdateBACCConfigurationBundleCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreatedBy_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source, if applicable (for example, a user ARN
        /// or optimization job ARN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatedBy_Arn { get; set; }
        #endregion
        
        #region Parameter BranchName
        /// <summary>
        /// <para>
        /// <para>The branch name for this version. If not specified, inherits the parent's branch or
        /// defaults to <c>mainline</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BranchName { get; set; }
        #endregion
        
        #region Parameter BundleId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the configuration bundle to update.</para>
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
        public System.String BundleId { get; set; }
        #endregion
        
        #region Parameter BundleName
        /// <summary>
        /// <para>
        /// <para>The updated name for the configuration bundle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BundleName { get; set; }
        #endregion
        
        #region Parameter CommitMessage
        /// <summary>
        /// <para>
        /// <para>A commit message describing the changes in this version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CommitMessage { get; set; }
        #endregion
        
        #region Parameter Component
        /// <summary>
        /// <para>
        /// <para>The updated component configurations. Creates a new version of the bundle.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Components")]
        public System.Collections.Hashtable Component { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description for the configuration bundle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>Optional KMS key ARN for encrypting component configurations. If provided, components
        /// will be encrypted with this key. If the bundle already has a KMS key, this rotates
        /// to the new key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter CreatedBy_Name
        /// <summary>
        /// <para>
        /// <para>The name of the source (for example, <c>user</c>, <c>optimization-job</c>, or <c>system</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatedBy_Name { get; set; }
        #endregion
        
        #region Parameter ParentVersionId
        /// <summary>
        /// <para>
        /// <para>A list of parent version identifiers for lineage tracking. Regular commits have a
        /// single parent. Merge commits have two parents: the target branch parent and the source
        /// branch parent. If the branch already exists, the first parent must be the latest version
        /// on that branch.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParentVersionIds")]
        public System.String[] ParentVersionId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If you don't specify this field, a value is randomly generated for
        /// you. If this token matches a previous request, the service ignores the request, but
        /// doesn't return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.UpdateConfigurationBundleResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.UpdateConfigurationBundleResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BundleId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACCConfigurationBundle (UpdateConfigurationBundle)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.UpdateConfigurationBundleResponse, UpdateBACCConfigurationBundleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BranchName = this.BranchName;
            context.BundleId = this.BundleId;
            #if MODULAR
            if (this.BundleId == null && ParameterWasBound(nameof(this.BundleId)))
            {
                WriteWarning("You are passing $null as a value for parameter BundleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BundleName = this.BundleName;
            context.ClientToken = this.ClientToken;
            context.CommitMessage = this.CommitMessage;
            if (this.Component != null)
            {
                context.Component = new Dictionary<System.String, Amazon.BedrockAgentCoreControl.Model.ComponentConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.Component.Keys)
                {
                    context.Component.Add((String)hashKey, (Amazon.BedrockAgentCoreControl.Model.ComponentConfiguration)(this.Component[hashKey]));
                }
            }
            context.CreatedBy_Arn = this.CreatedBy_Arn;
            context.CreatedBy_Name = this.CreatedBy_Name;
            context.Description = this.Description;
            context.KmsKeyArn = this.KmsKeyArn;
            if (this.ParentVersionId != null)
            {
                context.ParentVersionId = new List<System.String>(this.ParentVersionId);
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
            var request = new Amazon.BedrockAgentCoreControl.Model.UpdateConfigurationBundleRequest();
            
            if (cmdletContext.BranchName != null)
            {
                request.BranchName = cmdletContext.BranchName;
            }
            if (cmdletContext.BundleId != null)
            {
                request.BundleId = cmdletContext.BundleId;
            }
            if (cmdletContext.BundleName != null)
            {
                request.BundleName = cmdletContext.BundleName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CommitMessage != null)
            {
                request.CommitMessage = cmdletContext.CommitMessage;
            }
            if (cmdletContext.Component != null)
            {
                request.Components = cmdletContext.Component;
            }
            
             // populate CreatedBy
            var requestCreatedByIsNull = true;
            request.CreatedBy = new Amazon.BedrockAgentCoreControl.Model.VersionCreatedBySource();
            System.String requestCreatedBy_createdBy_Arn = null;
            if (cmdletContext.CreatedBy_Arn != null)
            {
                requestCreatedBy_createdBy_Arn = cmdletContext.CreatedBy_Arn;
            }
            if (requestCreatedBy_createdBy_Arn != null)
            {
                request.CreatedBy.Arn = requestCreatedBy_createdBy_Arn;
                requestCreatedByIsNull = false;
            }
            System.String requestCreatedBy_createdBy_Name = null;
            if (cmdletContext.CreatedBy_Name != null)
            {
                requestCreatedBy_createdBy_Name = cmdletContext.CreatedBy_Name;
            }
            if (requestCreatedBy_createdBy_Name != null)
            {
                request.CreatedBy.Name = requestCreatedBy_createdBy_Name;
                requestCreatedByIsNull = false;
            }
             // determine if request.CreatedBy should be set to null
            if (requestCreatedByIsNull)
            {
                request.CreatedBy = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.ParentVersionId != null)
            {
                request.ParentVersionIds = cmdletContext.ParentVersionId;
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
        
        private Amazon.BedrockAgentCoreControl.Model.UpdateConfigurationBundleResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.UpdateConfigurationBundleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "UpdateConfigurationBundle");
            try
            {
                return client.UpdateConfigurationBundleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BranchName { get; set; }
            public System.String BundleId { get; set; }
            public System.String BundleName { get; set; }
            public System.String ClientToken { get; set; }
            public System.String CommitMessage { get; set; }
            public Dictionary<System.String, Amazon.BedrockAgentCoreControl.Model.ComponentConfiguration> Component { get; set; }
            public System.String CreatedBy_Arn { get; set; }
            public System.String CreatedBy_Name { get; set; }
            public System.String Description { get; set; }
            public System.String KmsKeyArn { get; set; }
            public List<System.String> ParentVersionId { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.UpdateConfigurationBundleResponse, UpdateBACCConfigurationBundleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

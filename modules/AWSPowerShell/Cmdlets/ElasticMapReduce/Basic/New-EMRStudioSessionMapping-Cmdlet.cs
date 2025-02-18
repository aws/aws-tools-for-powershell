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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Maps a user or group to the Amazon EMR Studio specified by <c>StudioId</c>, and applies
    /// a session policy to refine Studio permissions for that user or group. Use <c>CreateStudioSessionMapping</c>
    /// to assign users to a Studio when you use IAM Identity Center authentication. For instructions
    /// on how to assign users to a Studio when you use IAM authentication, see <a href="https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-studio-manage-users.html#emr-studio-assign-users-groups">Assign
    /// a user or group to your EMR Studio</a>.
    /// </summary>
    [Cmdlet("New", "EMRStudioSessionMapping", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce CreateStudioSessionMapping API operation.", Operation = new[] {"CreateStudioSessionMapping"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.CreateStudioSessionMappingResponse))]
    [AWSCmdletOutput("None or Amazon.ElasticMapReduce.Model.CreateStudioSessionMappingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticMapReduce.Model.CreateStudioSessionMappingResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewEMRStudioSessionMappingCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IdentityId
        /// <summary>
        /// <para>
        /// <para>The globally unique identifier (GUID) of the user or group from the IAM Identity Center
        /// Identity Store. For more information, see <a href="https://docs.aws.amazon.com/singlesignon/latest/IdentityStoreAPIReference/API_User.html#singlesignon-Type-User-UserId">UserId</a>
        /// and <a href="https://docs.aws.amazon.com/singlesignon/latest/IdentityStoreAPIReference/API_Group.html#singlesignon-Type-Group-GroupId">GroupId</a>
        /// in the <i>IAM Identity Center Identity Store API Reference</i>. Either <c>IdentityName</c>
        /// or <c>IdentityId</c> must be specified, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityId { get; set; }
        #endregion
        
        #region Parameter IdentityName
        /// <summary>
        /// <para>
        /// <para>The name of the user or group. For more information, see <a href="https://docs.aws.amazon.com/singlesignon/latest/IdentityStoreAPIReference/API_User.html#singlesignon-Type-User-UserName">UserName</a>
        /// and <a href="https://docs.aws.amazon.com/singlesignon/latest/IdentityStoreAPIReference/API_Group.html#singlesignon-Type-Group-DisplayName">DisplayName</a>
        /// in the <i>IAM Identity Center Identity Store API Reference</i>. Either <c>IdentityName</c>
        /// or <c>IdentityId</c> must be specified, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityName { get; set; }
        #endregion
        
        #region Parameter IdentityType
        /// <summary>
        /// <para>
        /// <para>Specifies whether the identity to map to the Amazon EMR Studio is a user or a group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.IdentityType")]
        public Amazon.ElasticMapReduce.IdentityType IdentityType { get; set; }
        #endregion
        
        #region Parameter SessionPolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the session policy that will be applied to the
        /// user or group. You should specify the ARN for the session policy that you want to
        /// apply, not the ARN of your user role. For more information, see <a href="https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-studio-user-role.html">Create
        /// an Amazon EMR Studio User Role with Session Policies</a>.</para>
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
        public System.String SessionPolicyArn { get; set; }
        #endregion
        
        #region Parameter StudioId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon EMR Studio to which the user or group will be mapped.</para>
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
        public System.String StudioId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.CreateStudioSessionMappingResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMRStudioSessionMapping (CreateStudioSessionMapping)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.CreateStudioSessionMappingResponse, NewEMRStudioSessionMappingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IdentityId = this.IdentityId;
            context.IdentityName = this.IdentityName;
            context.IdentityType = this.IdentityType;
            #if MODULAR
            if (this.IdentityType == null && ParameterWasBound(nameof(this.IdentityType)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionPolicyArn = this.SessionPolicyArn;
            #if MODULAR
            if (this.SessionPolicyArn == null && ParameterWasBound(nameof(this.SessionPolicyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionPolicyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StudioId = this.StudioId;
            #if MODULAR
            if (this.StudioId == null && ParameterWasBound(nameof(this.StudioId)))
            {
                WriteWarning("You are passing $null as a value for parameter StudioId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticMapReduce.Model.CreateStudioSessionMappingRequest();
            
            if (cmdletContext.IdentityId != null)
            {
                request.IdentityId = cmdletContext.IdentityId;
            }
            if (cmdletContext.IdentityName != null)
            {
                request.IdentityName = cmdletContext.IdentityName;
            }
            if (cmdletContext.IdentityType != null)
            {
                request.IdentityType = cmdletContext.IdentityType;
            }
            if (cmdletContext.SessionPolicyArn != null)
            {
                request.SessionPolicyArn = cmdletContext.SessionPolicyArn;
            }
            if (cmdletContext.StudioId != null)
            {
                request.StudioId = cmdletContext.StudioId;
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
        
        private Amazon.ElasticMapReduce.Model.CreateStudioSessionMappingResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.CreateStudioSessionMappingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "CreateStudioSessionMapping");
            try
            {
                return client.CreateStudioSessionMappingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IdentityId { get; set; }
            public System.String IdentityName { get; set; }
            public Amazon.ElasticMapReduce.IdentityType IdentityType { get; set; }
            public System.String SessionPolicyArn { get; set; }
            public System.String StudioId { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.CreateStudioSessionMappingResponse, NewEMRStudioSessionMappingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

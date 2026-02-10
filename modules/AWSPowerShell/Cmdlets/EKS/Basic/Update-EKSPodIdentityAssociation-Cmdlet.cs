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
using Amazon.EKS;
using Amazon.EKS.Model;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Updates a EKS Pod Identity association. In an update, you can change the IAM role,
    /// the target IAM role, or <c>disableSessionTags</c>. You must change at least one of
    /// these in an update. An association can't be moved between clusters, namespaces, or
    /// service accounts. If you need to edit the namespace or service account, you need to
    /// delete the association and then create a new association with your desired settings.
    /// 
    ///  
    /// <para>
    /// Similar to Amazon Web Services IAM behavior, EKS Pod Identity associations are eventually
    /// consistent, and may take several seconds to be effective after the initial API call
    /// returns successfully. You must design your applications to account for these potential
    /// delays. We recommend that you don’t include association create/updates in the critical,
    /// high-availability code paths of your application. Instead, make changes in a separate
    /// initialization or setup routine that you run less frequently.
    /// </para><para>
    /// You can set a <i>target IAM role</i> in the same or a different account for advanced
    /// scenarios. With a target role, EKS Pod Identity automatically performs two role assumptions
    /// in sequence: first assuming the role in the association that is in this account, then
    /// using those credentials to assume the target IAM role. This process provides your
    /// Pod with temporary credentials that have the permissions defined in the target role,
    /// allowing secure access to resources in another Amazon Web Services account.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "EKSPodIdentityAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.PodIdentityAssociation")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes UpdatePodIdentityAssociation API operation.", Operation = new[] {"UpdatePodIdentityAssociation"}, SelectReturnType = typeof(Amazon.EKS.Model.UpdatePodIdentityAssociationResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.PodIdentityAssociation or Amazon.EKS.Model.UpdatePodIdentityAssociationResponse",
        "This cmdlet returns an Amazon.EKS.Model.PodIdentityAssociation object.",
        "The service call response (type Amazon.EKS.Model.UpdatePodIdentityAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEKSPodIdentityAssociationCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssociationId
        /// <summary>
        /// <para>
        /// <para>The ID of the association to be updated.</para>
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
        public System.String AssociationId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the cluster that you want to update the association in.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter DisableSessionTag
        /// <summary>
        /// <para>
        /// <para>Disable the automatic sessions tags that are appended by EKS Pod Identity.</para><para>EKS Pod Identity adds a pre-defined set of session tags when it assumes the role.
        /// You can use these tags to author a single role that can work across resources by allowing
        /// access to Amazon Web Services resources based on matching tags. By default, EKS Pod
        /// Identity attaches six tags, including tags for cluster name, namespace, and service
        /// account name. For the list of tags added by EKS Pod Identity, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/pod-id-abac.html#pod-id-abac-tags">List
        /// of session tags added by EKS Pod Identity</a> in the <i>Amazon EKS User Guide</i>.</para><para>Amazon Web Services compresses inline session policies, managed policy ARNs, and session
        /// tags into a packed binary format that has a separate limit. If you receive a <c>PackedPolicyTooLarge</c>
        /// error indicating the packed binary format has exceeded the size limit, you can attempt
        /// to reduce the size by disabling the session tags added by EKS Pod Identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisableSessionTags")]
        public System.Boolean? DisableSessionTag { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>An optional IAM policy in JSON format (as an escaped string) that applies additional
        /// restrictions to this pod identity association beyond the IAM policies attached to
        /// the IAM role. This policy is applied as the intersection of the role's policies and
        /// this policy, allowing you to reduce the permissions that applications in the pods
        /// can use. Use this policy to enforce least privilege access while still leveraging
        /// a shared IAM role across multiple applications.</para><para><b>Important considerations</b></para><ul><li><para><b>Session tags:</b> When using this policy, <c>disableSessionTags</c> must be set
        /// to <c>true</c>.</para></li><li><para><b>Target role permissions:</b> If you specify both a <c>TargetRoleArn</c> and a
        /// policy, the policy restrictions apply only to the target role's permissions, not to
        /// the initial role used for assuming the target role.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The new IAM role to change in the association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter TargetRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the target IAM role to associate with the service
        /// account. This role is assumed by using the EKS Pod Identity association role, then
        /// the credentials for this role are injected into the Pod.</para><para>When you run applications on Amazon EKS, your application might need to access Amazon
        /// Web Services resources from a different role that exists in the same or different
        /// Amazon Web Services account. For example, your application running in “Account A”
        /// might need to access resources, such as buckets in “Account B” or within “Account
        /// A” itself. You can create a association to access Amazon Web Services resources in
        /// “Account B” by creating two IAM roles: a role in “Account A” and a role in “Account
        /// B” (which can be the same or different account), each with the necessary trust and
        /// permission policies. After you provide these roles in the <i>IAM role</i> and <i>Target
        /// IAM role</i> fields, EKS will perform role chaining to ensure your application gets
        /// the required permissions. This means Role A will assume Role B, allowing your Pods
        /// to securely access resources like S3 buckets in the target account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetRoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Association'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.UpdatePodIdentityAssociationResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.UpdatePodIdentityAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Association";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssociationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssociationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssociationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssociationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EKSPodIdentityAssociation (UpdatePodIdentityAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.UpdatePodIdentityAssociationResponse, UpdateEKSPodIdentityAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssociationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssociationId = this.AssociationId;
            #if MODULAR
            if (this.AssociationId == null && ParameterWasBound(nameof(this.AssociationId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DisableSessionTag = this.DisableSessionTag;
            context.Policy = this.Policy;
            context.RoleArn = this.RoleArn;
            context.TargetRoleArn = this.TargetRoleArn;
            
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
            var request = new Amazon.EKS.Model.UpdatePodIdentityAssociationRequest();
            
            if (cmdletContext.AssociationId != null)
            {
                request.AssociationId = cmdletContext.AssociationId;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.DisableSessionTag != null)
            {
                request.DisableSessionTags = cmdletContext.DisableSessionTag.Value;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.TargetRoleArn != null)
            {
                request.TargetRoleArn = cmdletContext.TargetRoleArn;
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
        
        private Amazon.EKS.Model.UpdatePodIdentityAssociationResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.UpdatePodIdentityAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "UpdatePodIdentityAssociation");
            try
            {
                #if DESKTOP
                return client.UpdatePodIdentityAssociation(request);
                #elif CORECLR
                return client.UpdatePodIdentityAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String AssociationId { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String ClusterName { get; set; }
            public System.Boolean? DisableSessionTag { get; set; }
            public System.String Policy { get; set; }
            public System.String RoleArn { get; set; }
            public System.String TargetRoleArn { get; set; }
            public System.Func<Amazon.EKS.Model.UpdatePodIdentityAssociationResponse, UpdateEKSPodIdentityAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Association;
        }
        
    }
}

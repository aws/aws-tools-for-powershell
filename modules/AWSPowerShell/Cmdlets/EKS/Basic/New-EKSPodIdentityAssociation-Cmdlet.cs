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
using Amazon.EKS;
using Amazon.EKS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Creates an EKS Pod Identity association between a service account in an Amazon EKS
    /// cluster and an IAM role with <i>EKS Pod Identity</i>. Use EKS Pod Identity to give
    /// temporary IAM credentials to Pods and the credentials are rotated automatically.
    /// 
    ///  
    /// <para>
    /// Amazon EKS Pod Identity associations provide the ability to manage credentials for
    /// your applications, similar to the way that Amazon EC2 instance profiles provide credentials
    /// to Amazon EC2 instances.
    /// </para><para>
    /// If a Pod uses a service account that has an association, Amazon EKS sets environment
    /// variables in the containers of the Pod. The environment variables configure the Amazon
    /// Web Services SDKs, including the Command Line Interface, to use the EKS Pod Identity
    /// credentials.
    /// </para><para>
    /// EKS Pod Identity is a simpler method than <i>IAM roles for service accounts</i>, as
    /// this method doesn't use OIDC identity providers. Additionally, you can configure a
    /// role for EKS Pod Identity once, and reuse it across clusters.
    /// </para><para>
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
    [Cmdlet("New", "EKSPodIdentityAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.PodIdentityAssociation")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes CreatePodIdentityAssociation API operation.", Operation = new[] {"CreatePodIdentityAssociation"}, SelectReturnType = typeof(Amazon.EKS.Model.CreatePodIdentityAssociationResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.PodIdentityAssociation or Amazon.EKS.Model.CreatePodIdentityAssociationResponse",
        "This cmdlet returns an Amazon.EKS.Model.PodIdentityAssociation object.",
        "The service call response (type Amazon.EKS.Model.CreatePodIdentityAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEKSPodIdentityAssociationCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// <para>The name of the cluster to create the EKS Pod Identity association in.</para>
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
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The name of the Kubernetes namespace inside the cluster to create the EKS Pod Identity
        /// association in. The service account and the Pods that use the service account must
        /// be in this namespace.</para>
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
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to associate with the service account.
        /// The EKS Pod Identity agent manages credentials to assume this role for applications
        /// in the containers in the Pods that use this service account.</para>
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
        
        #region Parameter ServiceAccount
        /// <summary>
        /// <para>
        /// <para>The name of the Kubernetes service account inside the cluster to associate the IAM
        /// credentials with.</para>
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
        public System.String ServiceAccount { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that assists with categorization and organization. Each tag consists of a
        /// key and an optional value. You define both. Tags don't propagate to any other cluster
        /// or Amazon Web Services resources.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource – 50</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length – 128 Unicode characters in UTF-8</para></li><li><para>Maximum value length – 256 Unicode characters in UTF-8</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case-sensitive.</para></li><li><para>Do not use <c>aws:</c>, <c>AWS:</c>, or any upper or lowercase combination of such
        /// as a prefix for either keys or values as it is reserved for Amazon Web Services use.
        /// You cannot edit or delete tag keys or values with this prefix. Tags with this prefix
        /// do not count against your tags per resource limit.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TargetRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the target IAM role to associate with the service
        /// account. This role is assumed by using the EKS Pod Identity association role, then
        /// the credentials for this role are injected into the Pod.</para><para>When you run applications on Amazon EKS, your application might need to access Amazon
        /// Web Services resources from a different role that exists in the same or different
        /// Amazon Web Services account. For example, your application running in “Account A”
        /// might need to access resources, such as Amazon S3 buckets in “Account B” or within
        /// “Account A” itself. You can create a association to access Amazon Web Services resources
        /// in “Account B” by creating two IAM roles: a role in “Account A” and a role in “Account
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.CreatePodIdentityAssociationResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.CreatePodIdentityAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Association";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EKSPodIdentityAssociation (CreatePodIdentityAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.CreatePodIdentityAssociationResponse, NewEKSPodIdentityAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DisableSessionTag = this.DisableSessionTag;
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceAccount = this.ServiceAccount;
            #if MODULAR
            if (this.ServiceAccount == null && ParameterWasBound(nameof(this.ServiceAccount)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceAccount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
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
            var request = new Amazon.EKS.Model.CreatePodIdentityAssociationRequest();
            
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
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.ServiceAccount != null)
            {
                request.ServiceAccount = cmdletContext.ServiceAccount;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.EKS.Model.CreatePodIdentityAssociationResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.CreatePodIdentityAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "CreatePodIdentityAssociation");
            try
            {
                return client.CreatePodIdentityAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String ClusterName { get; set; }
            public System.Boolean? DisableSessionTag { get; set; }
            public System.String Namespace { get; set; }
            public System.String RoleArn { get; set; }
            public System.String ServiceAccount { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TargetRoleArn { get; set; }
            public System.Func<Amazon.EKS.Model.CreatePodIdentityAssociationResponse, NewEKSPodIdentityAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Association;
        }
        
    }
}

/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates an Fargate profile for your Amazon EKS cluster. You must have at least one
    /// Fargate profile in a cluster to be able to run pods on Fargate.
    /// 
    ///  
    /// <para>
    /// The Fargate profile allows an administrator to declare which pods run on Fargate and
    /// specify which pods run on which Fargate profile. This declaration is done through
    /// the profile’s selectors. Each profile can have up to five selectors that contain a
    /// namespace and labels. A namespace is required for every selector. The label field
    /// consists of multiple optional key-value pairs. Pods that match the selectors are scheduled
    /// on Fargate. If a to-be-scheduled pod matches any of the selectors in the Fargate profile,
    /// then that pod is run on Fargate.
    /// </para><para>
    /// When you create a Fargate profile, you must specify a pod execution role to use with
    /// the pods that are scheduled with the profile. This role is added to the cluster's
    /// Kubernetes <a href="https://kubernetes.io/docs/reference/access-authn-authz/rbac/">Role
    /// Based Access Control</a> (RBAC) for authorization so that the <c>kubelet</c> that
    /// is running on the Fargate infrastructure can register with your Amazon EKS cluster
    /// so that it can appear in your cluster as a node. The pod execution role also provides
    /// IAM permissions to the Fargate infrastructure to allow read access to Amazon ECR image
    /// repositories. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/pod-execution-role.html">Pod
    /// Execution Role</a> in the <i>Amazon EKS User Guide</i>.
    /// </para><para>
    /// Fargate profiles are immutable. However, you can create a new updated profile to replace
    /// an existing profile and then delete the original after the updated profile has finished
    /// creating.
    /// </para><para>
    /// If any Fargate profiles in a cluster are in the <c>DELETING</c> status, you must wait
    /// for that Fargate profile to finish deleting before you can create any other profiles
    /// in that cluster.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/fargate-profile.html">Fargate
    /// profile</a> in the <i>Amazon EKS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EKSFargateProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.FargateProfile")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes CreateFargateProfile API operation.", Operation = new[] {"CreateFargateProfile"}, SelectReturnType = typeof(Amazon.EKS.Model.CreateFargateProfileResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.FargateProfile or Amazon.EKS.Model.CreateFargateProfileResponse",
        "This cmdlet returns an Amazon.EKS.Model.FargateProfile object.",
        "The service call response (type Amazon.EKS.Model.CreateFargateProfileResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEKSFargateProfileCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>The name of your cluster.</para>
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
        
        #region Parameter FargateProfileName
        /// <summary>
        /// <para>
        /// <para>The name of the Fargate profile.</para>
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
        public System.String FargateProfileName { get; set; }
        #endregion
        
        #region Parameter PodExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the <c>Pod</c> execution role to use for a <c>Pod</c>
        /// that matches the selectors in the Fargate profile. The <c>Pod</c> execution role allows
        /// Fargate infrastructure to register with your cluster as a node, and it provides read
        /// access to Amazon ECR image repositories. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/pod-execution-role.html"><c>Pod</c> execution role</a> in the <i>Amazon EKS User Guide</i>.</para>
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
        public System.String PodExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Selector
        /// <summary>
        /// <para>
        /// <para>The selectors to match for a <c>Pod</c> to use this Fargate profile. Each selector
        /// must have an associated Kubernetes <c>namespace</c>. Optionally, you can also specify
        /// <c>labels</c> for a <c>namespace</c>. You may specify up to five selectors in a Fargate
        /// profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Selectors")]
        public Amazon.EKS.Model.FargateProfileSelector[] Selector { get; set; }
        #endregion
        
        #region Parameter Subnet
        /// <summary>
        /// <para>
        /// <para>The IDs of subnets to launch a <c>Pod</c> into. A <c>Pod</c> running on Fargate isn't
        /// assigned a public IP address, so only private subnets (with no direct route to an
        /// Internet Gateway) are accepted for this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Subnets")]
        public System.String[] Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that assists with categorization and organization. Each tag consists of a
        /// key and an optional value. You define both. Tags don't propagate to any other cluster
        /// or Amazon Web Services resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FargateProfile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.CreateFargateProfileResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.CreateFargateProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FargateProfile";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FargateProfileName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EKSFargateProfile (CreateFargateProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.CreateFargateProfileResponse, NewEKSFargateProfileCmdlet>(Select) ??
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
            context.FargateProfileName = this.FargateProfileName;
            #if MODULAR
            if (this.FargateProfileName == null && ParameterWasBound(nameof(this.FargateProfileName)))
            {
                WriteWarning("You are passing $null as a value for parameter FargateProfileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PodExecutionRoleArn = this.PodExecutionRoleArn;
            #if MODULAR
            if (this.PodExecutionRoleArn == null && ParameterWasBound(nameof(this.PodExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PodExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Selector != null)
            {
                context.Selector = new List<Amazon.EKS.Model.FargateProfileSelector>(this.Selector);
            }
            if (this.Subnet != null)
            {
                context.Subnet = new List<System.String>(this.Subnet);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.EKS.Model.CreateFargateProfileRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.FargateProfileName != null)
            {
                request.FargateProfileName = cmdletContext.FargateProfileName;
            }
            if (cmdletContext.PodExecutionRoleArn != null)
            {
                request.PodExecutionRoleArn = cmdletContext.PodExecutionRoleArn;
            }
            if (cmdletContext.Selector != null)
            {
                request.Selectors = cmdletContext.Selector;
            }
            if (cmdletContext.Subnet != null)
            {
                request.Subnets = cmdletContext.Subnet;
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
        
        private Amazon.EKS.Model.CreateFargateProfileResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.CreateFargateProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "CreateFargateProfile");
            try
            {
                #if DESKTOP
                return client.CreateFargateProfile(request);
                #elif CORECLR
                return client.CreateFargateProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String ClusterName { get; set; }
            public System.String FargateProfileName { get; set; }
            public System.String PodExecutionRoleArn { get; set; }
            public List<Amazon.EKS.Model.FargateProfileSelector> Selector { get; set; }
            public List<System.String> Subnet { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.EKS.Model.CreateFargateProfileResponse, NewEKSFargateProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FargateProfile;
        }
        
    }
}

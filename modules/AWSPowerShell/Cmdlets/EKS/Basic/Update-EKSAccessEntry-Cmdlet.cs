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
    /// Updates an access entry.
    /// </summary>
    [Cmdlet("Update", "EKSAccessEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.AccessEntry")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes UpdateAccessEntry API operation.", Operation = new[] {"UpdateAccessEntry"}, SelectReturnType = typeof(Amazon.EKS.Model.UpdateAccessEntryResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.AccessEntry or Amazon.EKS.Model.UpdateAccessEntryResponse",
        "This cmdlet returns an Amazon.EKS.Model.AccessEntry object.",
        "The service call response (type Amazon.EKS.Model.UpdateAccessEntryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEKSAccessEntryCmdlet : AmazonEKSClientCmdlet, IExecutor
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
        
        #region Parameter KubernetesGroup
        /// <summary>
        /// <para>
        /// <para>The value for <c>name</c> that you've specified for <c>kind: Group</c> as a <c>subject</c>
        /// in a Kubernetes <c>RoleBinding</c> or <c>ClusterRoleBinding</c> object. Amazon EKS
        /// doesn't confirm that the value for <c>name</c> exists in any bindings on your cluster.
        /// You can specify one or more names.</para><para>Kubernetes authorizes the <c>principalArn</c> of the access entry to access any cluster
        /// objects that you've specified in a Kubernetes <c>Role</c> or <c>ClusterRole</c> object
        /// that is also specified in a binding's <c>roleRef</c>. For more information about creating
        /// Kubernetes <c>RoleBinding</c>, <c>ClusterRoleBinding</c>, <c>Role</c>, or <c>ClusterRole</c>
        /// objects, see <a href="https://kubernetes.io/docs/reference/access-authn-authz/rbac/">Using
        /// RBAC Authorization in the Kubernetes documentation</a>.</para><para>If you want Amazon EKS to authorize the <c>principalArn</c> (instead of, or in addition
        /// to Kubernetes authorizing the <c>principalArn</c>), you can associate one or more
        /// access policies to the access entry using <c>AssociateAccessPolicy</c>. If you associate
        /// any access policies, the <c>principalARN</c> has all permissions assigned in the associated
        /// access policies and all permissions in any Kubernetes <c>Role</c> or <c>ClusterRole</c>
        /// objects that the group names are bound to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KubernetesGroups")]
        public System.String[] KubernetesGroup { get; set; }
        #endregion
        
        #region Parameter PrincipalArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM principal for the <c>AccessEntry</c>.</para>
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
        public System.String PrincipalArn { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The username to authenticate to Kubernetes with. We recommend not specifying a username
        /// and letting Amazon EKS specify it for you. For more information about the value Amazon
        /// EKS specifies for you, or constraints before specifying your own username, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/access-entries.html#creating-access-entries">Creating
        /// access entries</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccessEntry'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.UpdateAccessEntryResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.UpdateAccessEntryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccessEntry";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PrincipalArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PrincipalArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PrincipalArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PrincipalArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EKSAccessEntry (UpdateAccessEntry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.UpdateAccessEntryResponse, UpdateEKSAccessEntryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PrincipalArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.KubernetesGroup != null)
            {
                context.KubernetesGroup = new List<System.String>(this.KubernetesGroup);
            }
            context.PrincipalArn = this.PrincipalArn;
            #if MODULAR
            if (this.PrincipalArn == null && ParameterWasBound(nameof(this.PrincipalArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PrincipalArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Username = this.Username;
            
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
            var request = new Amazon.EKS.Model.UpdateAccessEntryRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.KubernetesGroup != null)
            {
                request.KubernetesGroups = cmdletContext.KubernetesGroup;
            }
            if (cmdletContext.PrincipalArn != null)
            {
                request.PrincipalArn = cmdletContext.PrincipalArn;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
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
        
        private Amazon.EKS.Model.UpdateAccessEntryResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.UpdateAccessEntryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "UpdateAccessEntry");
            try
            {
                #if DESKTOP
                return client.UpdateAccessEntry(request);
                #elif CORECLR
                return client.UpdateAccessEntryAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> KubernetesGroup { get; set; }
            public System.String PrincipalArn { get; set; }
            public System.String Username { get; set; }
            public System.Func<Amazon.EKS.Model.UpdateAccessEntryResponse, UpdateEKSAccessEntryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccessEntry;
        }
        
    }
}

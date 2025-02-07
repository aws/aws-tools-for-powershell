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
    /// Updates the Kubernetes version or AMI version of an Amazon EKS managed node group.
    /// 
    ///  
    /// <para>
    /// You can update a node group using a launch template only if the node group was originally
    /// deployed with a launch template. If you need to update a custom AMI in a node group
    /// that was deployed with a launch template, then update your custom AMI, specify the
    /// new ID in a new version of the launch template, and then update the node group to
    /// the new version of the launch template.
    /// </para><para>
    /// If you update without a launch template, then you can update to the latest available
    /// AMI version of a node group's current Kubernetes version by not specifying a Kubernetes
    /// version in the request. You can update to the latest AMI version of your cluster's
    /// current Kubernetes version by specifying your cluster's Kubernetes version in the
    /// request. For information about Linux versions, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/eks-linux-ami-versions.html">Amazon
    /// EKS optimized Amazon Linux AMI versions</a> in the <i>Amazon EKS User Guide</i>. For
    /// information about Windows versions, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/eks-ami-versions-windows.html">Amazon
    /// EKS optimized Windows AMI versions</a> in the <i>Amazon EKS User Guide</i>. 
    /// </para><para>
    /// You cannot roll back a node group to an earlier Kubernetes version or AMI version.
    /// </para><para>
    /// When a node in a managed node group is terminated due to a scaling action or update,
    /// every <c>Pod</c> on that node is drained first. Amazon EKS attempts to drain the nodes
    /// gracefully and will fail if it is unable to do so. You can <c>force</c> the update
    /// if Amazon EKS is unable to drain the nodes as a result of a <c>Pod</c> disruption
    /// budget issue.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "EKSNodegroupVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.Update")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes UpdateNodegroupVersion API operation.", Operation = new[] {"UpdateNodegroupVersion"}, SelectReturnType = typeof(Amazon.EKS.Model.UpdateNodegroupVersionResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.Update or Amazon.EKS.Model.UpdateNodegroupVersionResponse",
        "This cmdlet returns an Amazon.EKS.Model.Update object.",
        "The service call response (type Amazon.EKS.Model.UpdateNodegroupVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEKSNodegroupVersionCmdlet : AmazonEKSClientCmdlet, IExecutor
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
        
        #region Parameter Enforce
        /// <summary>
        /// <para>
        /// <para>Force the update if any <c>Pod</c> on the existing node group can't be drained due
        /// to a <c>Pod</c> disruption budget issue. If an update fails because all Pods can't
        /// be drained, you can force the update after it fails to terminate the old node whether
        /// or not any <c>Pod</c> is running on the node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enforce { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Id
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template.</para><para>You must specify either the launch template ID or the launch template name in the
        /// request, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_Id { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the launch template.</para><para>You must specify either the launch template name or the launch template ID in the
        /// request, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_Name { get; set; }
        #endregion
        
        #region Parameter NodegroupName
        /// <summary>
        /// <para>
        /// <para>The name of the managed node group to update.</para>
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
        public System.String NodegroupName { get; set; }
        #endregion
        
        #region Parameter ReleaseVersion
        /// <summary>
        /// <para>
        /// <para>The AMI version of the Amazon EKS optimized AMI to use for the update. By default,
        /// the latest available AMI version for the node group's Kubernetes version is used.
        /// For information about Linux versions, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/eks-linux-ami-versions.html">Amazon
        /// EKS optimized Amazon Linux AMI versions</a> in the <i>Amazon EKS User Guide</i>. Amazon
        /// EKS managed node groups support the November 2022 and later releases of the Windows
        /// AMIs. For information about Windows versions, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/eks-ami-versions-windows.html">Amazon
        /// EKS optimized Windows AMI versions</a> in the <i>Amazon EKS User Guide</i>.</para><para>If you specify <c>launchTemplate</c>, and your launch template uses a custom AMI,
        /// then don't specify <c>releaseVersion</c>, or the node group update will fail. For
        /// more information about using launch templates with Amazon EKS, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Customizing
        /// managed nodes with launch templates</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReleaseVersion { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version number of the launch template to use. If no version is specified, then
        /// the template's default version is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_Version { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The Kubernetes version to update to. If no version is specified, then the Kubernetes
        /// version of the node group does not change. You can specify the Kubernetes version
        /// of the cluster to update the node group to the latest AMI version of the cluster's
        /// Kubernetes version. If you specify <c>launchTemplate</c>, and your launch template
        /// uses a custom AMI, then don't specify <c>version</c>, or the node group update will
        /// fail. For more information about using launch templates with Amazon EKS, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Customizing
        /// managed nodes with launch templates</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Update'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.UpdateNodegroupVersionResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.UpdateNodegroupVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Update";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NodegroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EKSNodegroupVersion (UpdateNodegroupVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.UpdateNodegroupVersionResponse, UpdateEKSNodegroupVersionCmdlet>(Select) ??
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
            context.Enforce = this.Enforce;
            context.LaunchTemplate_Id = this.LaunchTemplate_Id;
            context.LaunchTemplate_Name = this.LaunchTemplate_Name;
            context.LaunchTemplate_Version = this.LaunchTemplate_Version;
            context.NodegroupName = this.NodegroupName;
            #if MODULAR
            if (this.NodegroupName == null && ParameterWasBound(nameof(this.NodegroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter NodegroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReleaseVersion = this.ReleaseVersion;
            context.Version = this.Version;
            
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
            var request = new Amazon.EKS.Model.UpdateNodegroupVersionRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.Enforce != null)
            {
                request.Force = cmdletContext.Enforce.Value;
            }
            
             // populate LaunchTemplate
            var requestLaunchTemplateIsNull = true;
            request.LaunchTemplate = new Amazon.EKS.Model.LaunchTemplateSpecification();
            System.String requestLaunchTemplate_launchTemplate_Id = null;
            if (cmdletContext.LaunchTemplate_Id != null)
            {
                requestLaunchTemplate_launchTemplate_Id = cmdletContext.LaunchTemplate_Id;
            }
            if (requestLaunchTemplate_launchTemplate_Id != null)
            {
                request.LaunchTemplate.Id = requestLaunchTemplate_launchTemplate_Id;
                requestLaunchTemplateIsNull = false;
            }
            System.String requestLaunchTemplate_launchTemplate_Name = null;
            if (cmdletContext.LaunchTemplate_Name != null)
            {
                requestLaunchTemplate_launchTemplate_Name = cmdletContext.LaunchTemplate_Name;
            }
            if (requestLaunchTemplate_launchTemplate_Name != null)
            {
                request.LaunchTemplate.Name = requestLaunchTemplate_launchTemplate_Name;
                requestLaunchTemplateIsNull = false;
            }
            System.String requestLaunchTemplate_launchTemplate_Version = null;
            if (cmdletContext.LaunchTemplate_Version != null)
            {
                requestLaunchTemplate_launchTemplate_Version = cmdletContext.LaunchTemplate_Version;
            }
            if (requestLaunchTemplate_launchTemplate_Version != null)
            {
                request.LaunchTemplate.Version = requestLaunchTemplate_launchTemplate_Version;
                requestLaunchTemplateIsNull = false;
            }
             // determine if request.LaunchTemplate should be set to null
            if (requestLaunchTemplateIsNull)
            {
                request.LaunchTemplate = null;
            }
            if (cmdletContext.NodegroupName != null)
            {
                request.NodegroupName = cmdletContext.NodegroupName;
            }
            if (cmdletContext.ReleaseVersion != null)
            {
                request.ReleaseVersion = cmdletContext.ReleaseVersion;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
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
        
        private Amazon.EKS.Model.UpdateNodegroupVersionResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.UpdateNodegroupVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "UpdateNodegroupVersion");
            try
            {
                #if DESKTOP
                return client.UpdateNodegroupVersion(request);
                #elif CORECLR
                return client.UpdateNodegroupVersionAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Enforce { get; set; }
            public System.String LaunchTemplate_Id { get; set; }
            public System.String LaunchTemplate_Name { get; set; }
            public System.String LaunchTemplate_Version { get; set; }
            public System.String NodegroupName { get; set; }
            public System.String ReleaseVersion { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.EKS.Model.UpdateNodegroupVersionResponse, UpdateEKSNodegroupVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Update;
        }
        
    }
}

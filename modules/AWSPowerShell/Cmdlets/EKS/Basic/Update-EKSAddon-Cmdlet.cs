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
    /// Updates an Amazon EKS add-on.
    /// </summary>
    [Cmdlet("Update", "EKSAddon", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.Update")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes UpdateAddon API operation.", Operation = new[] {"UpdateAddon"}, SelectReturnType = typeof(Amazon.EKS.Model.UpdateAddonResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.Update or Amazon.EKS.Model.UpdateAddonResponse",
        "This cmdlet returns an Amazon.EKS.Model.Update object.",
        "The service call response (type Amazon.EKS.Model.UpdateAddonResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEKSAddonCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddonName
        /// <summary>
        /// <para>
        /// <para>The name of the add-on. The name must match one of the names returned by <a href="https://docs.aws.amazon.com/eks/latest/APIReference/API_ListAddons.html"><code>ListAddons</code></a>.</para>
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
        public System.String AddonName { get; set; }
        #endregion
        
        #region Parameter AddonVersion
        /// <summary>
        /// <para>
        /// <para>The version of the add-on. The version must match one of the versions returned by
        /// <a href="https://docs.aws.amazon.com/eks/latest/APIReference/API_DescribeAddonVersions.html"><code>DescribeAddonVersions</code></a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AddonVersion { get; set; }
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
        
        #region Parameter ConfigurationValue
        /// <summary>
        /// <para>
        /// <para>The set of configuration values for the add-on that's created. The values that you
        /// provide are validated against the schema returned by <code>DescribeAddonConfiguration</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationValues")]
        public System.String ConfigurationValue { get; set; }
        #endregion
        
        #region Parameter ResolveConflict
        /// <summary>
        /// <para>
        /// <para>How to resolve field value conflicts for an Amazon EKS add-on if you've changed a
        /// value from the Amazon EKS default value. Conflicts are handled based on the option
        /// you choose:</para><ul><li><para><b>None</b> – Amazon EKS doesn't change the value. The update might fail.</para></li><li><para><b>Overwrite</b> – Amazon EKS overwrites the changed value back to the Amazon EKS
        /// default value.</para></li><li><para><b>Preserve</b> – Amazon EKS preserves the value. If you choose this option, we recommend
        /// that you test any field and value changes on a non-production cluster before updating
        /// the add-on on your production cluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResolveConflicts")]
        [AWSConstantClassSource("Amazon.EKS.ResolveConflicts")]
        public Amazon.EKS.ResolveConflicts ResolveConflict { get; set; }
        #endregion
        
        #region Parameter ServiceAccountRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an existing IAM role to bind to the add-on's service
        /// account. The role must be assigned the IAM permissions required by the add-on. If
        /// you don't specify an existing IAM role, then the add-on uses the permissions assigned
        /// to the node IAM role. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/create-node-role.html">Amazon
        /// EKS node IAM role</a> in the <i>Amazon EKS User Guide</i>.</para><note><para>To specify an existing IAM role, you must have an IAM OpenID Connect (OIDC) provider
        /// created for your cluster. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/enable-iam-roles-for-service-accounts.html">Enabling
        /// IAM roles for service accounts on your cluster</a> in the <i>Amazon EKS User Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceAccountRoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Update'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.UpdateAddonResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.UpdateAddonResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Update";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AddonName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AddonName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AddonName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AddonName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EKSAddon (UpdateAddon)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.UpdateAddonResponse, UpdateEKSAddonCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AddonName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AddonName = this.AddonName;
            #if MODULAR
            if (this.AddonName == null && ParameterWasBound(nameof(this.AddonName)))
            {
                WriteWarning("You are passing $null as a value for parameter AddonName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AddonVersion = this.AddonVersion;
            context.ClientRequestToken = this.ClientRequestToken;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfigurationValue = this.ConfigurationValue;
            context.ResolveConflict = this.ResolveConflict;
            context.ServiceAccountRoleArn = this.ServiceAccountRoleArn;
            
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
            var request = new Amazon.EKS.Model.UpdateAddonRequest();
            
            if (cmdletContext.AddonName != null)
            {
                request.AddonName = cmdletContext.AddonName;
            }
            if (cmdletContext.AddonVersion != null)
            {
                request.AddonVersion = cmdletContext.AddonVersion;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.ConfigurationValue != null)
            {
                request.ConfigurationValues = cmdletContext.ConfigurationValue;
            }
            if (cmdletContext.ResolveConflict != null)
            {
                request.ResolveConflicts = cmdletContext.ResolveConflict;
            }
            if (cmdletContext.ServiceAccountRoleArn != null)
            {
                request.ServiceAccountRoleArn = cmdletContext.ServiceAccountRoleArn;
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
        
        private Amazon.EKS.Model.UpdateAddonResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.UpdateAddonRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "UpdateAddon");
            try
            {
                #if DESKTOP
                return client.UpdateAddon(request);
                #elif CORECLR
                return client.UpdateAddonAsync(request).GetAwaiter().GetResult();
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
            public System.String AddonName { get; set; }
            public System.String AddonVersion { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String ClusterName { get; set; }
            public System.String ConfigurationValue { get; set; }
            public Amazon.EKS.ResolveConflicts ResolveConflict { get; set; }
            public System.String ServiceAccountRoleArn { get; set; }
            public System.Func<Amazon.EKS.Model.UpdateAddonResponse, UpdateEKSAddonCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Update;
        }
        
    }
}

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
using Amazon.NetworkSecurityManager;
using Amazon.NetworkSecurityManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NSM
{
    /// <summary>
    /// Creates a deployment. A deployment applies one or more policies to the accounts and
    /// resources selected by a scope. Use <c>isPublished</c> to create the deployment in
    /// published (<c>ACTIVE</c>) or draft (<c>DRAFT</c>) state. The response includes coverage
    /// information and any warnings about the deployment.
    /// </summary>
    [Cmdlet("New", "NSMDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkSecurityManager.Model.CreateDeploymentResponse")]
    [AWSCmdlet("Calls the AWS Network Security Manager Customer API CreateDeployment API operation.", Operation = new[] {"CreateDeployment"}, SelectReturnType = typeof(Amazon.NetworkSecurityManager.Model.CreateDeploymentResponse))]
    [AWSCmdletOutput("Amazon.NetworkSecurityManager.Model.CreateDeploymentResponse",
        "This cmdlet returns an Amazon.NetworkSecurityManager.Model.CreateDeploymentResponse object containing multiple properties."
    )]
    public partial class NewNSMDeploymentCmdlet : AmazonNetworkSecurityManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssociatedPolicyList
        /// <summary>
        /// <para>
        /// <para>The policies associated with the deployment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.NetworkSecurityManager.Model.PolicyReference[] AssociatedPolicyList { get; set; }
        #endregion
        
        #region Parameter AssociatedScopeList
        /// <summary>
        /// <para>
        /// <para>The scope associated with the deployment. A deployment has exactly one scope.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.NetworkSecurityManager.Model.ScopeReference[] AssociatedScopeList { get; set; }
        #endregion
        
        #region Parameter DeploymentDescription
        /// <summary>
        /// <para>
        /// <para>A description of the deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentDescription { get; set; }
        #endregion
        
        #region Parameter DeploymentName
        /// <summary>
        /// <para>
        /// <para>The name of the deployment.</para>
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
        public System.String DeploymentName { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_EnableCrossAccountVisibility
        /// <summary>
        /// <para>
        /// <para>Specifies whether aggregate synchronization status details for the resources covered
        /// by this deployment are visible across accounts. Default: <c>false</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? DeploymentConfiguration_EnableCrossAccountVisibility { get; set; }
        #endregion
        
        #region Parameter IsPublished
        /// <summary>
        /// <para>
        /// <para>Specifies whether to publish the resource. When <c>true</c>, the resource is saved
        /// in published (<c>ACTIVE</c>) state. When <c>false</c>, it is saved as a draft (<c>DRAFT</c>).
        /// Default: <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsPublished { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the resource when it is created.</para><para />
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure that the operation completes
        /// no more than one time. If you retry a request with the same client token and the same
        /// parameters, the service returns the result of the original successful request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkSecurityManager.Model.CreateDeploymentResponse).
        /// Specifying the name of a property of type Amazon.NetworkSecurityManager.Model.CreateDeploymentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeploymentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NSMDeployment (CreateDeployment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkSecurityManager.Model.CreateDeploymentResponse, NewNSMDeploymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssociatedPolicyList != null)
            {
                context.AssociatedPolicyList = new List<Amazon.NetworkSecurityManager.Model.PolicyReference>(this.AssociatedPolicyList);
            }
            #if MODULAR
            if (this.AssociatedPolicyList == null && ParameterWasBound(nameof(this.AssociatedPolicyList)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociatedPolicyList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AssociatedScopeList != null)
            {
                context.AssociatedScopeList = new List<Amazon.NetworkSecurityManager.Model.ScopeReference>(this.AssociatedScopeList);
            }
            #if MODULAR
            if (this.AssociatedScopeList == null && ParameterWasBound(nameof(this.AssociatedScopeList)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociatedScopeList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DeploymentConfiguration_EnableCrossAccountVisibility = this.DeploymentConfiguration_EnableCrossAccountVisibility;
            #if MODULAR
            if (this.DeploymentConfiguration_EnableCrossAccountVisibility == null && ParameterWasBound(nameof(this.DeploymentConfiguration_EnableCrossAccountVisibility)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentConfiguration_EnableCrossAccountVisibility which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeploymentDescription = this.DeploymentDescription;
            context.DeploymentName = this.DeploymentName;
            #if MODULAR
            if (this.DeploymentName == null && ParameterWasBound(nameof(this.DeploymentName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IsPublished = this.IsPublished;
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
            var request = new Amazon.NetworkSecurityManager.Model.CreateDeploymentRequest();
            
            if (cmdletContext.AssociatedPolicyList != null)
            {
                request.AssociatedPolicyList = cmdletContext.AssociatedPolicyList;
            }
            if (cmdletContext.AssociatedScopeList != null)
            {
                request.AssociatedScopeList = cmdletContext.AssociatedScopeList;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DeploymentConfiguration
            var requestDeploymentConfigurationIsNull = true;
            request.DeploymentConfiguration = new Amazon.NetworkSecurityManager.Model.DeploymentConfiguration();
            System.Boolean? requestDeploymentConfiguration_deploymentConfiguration_EnableCrossAccountVisibility = null;
            if (cmdletContext.DeploymentConfiguration_EnableCrossAccountVisibility != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_EnableCrossAccountVisibility = cmdletContext.DeploymentConfiguration_EnableCrossAccountVisibility.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_EnableCrossAccountVisibility != null)
            {
                request.DeploymentConfiguration.EnableCrossAccountVisibility = requestDeploymentConfiguration_deploymentConfiguration_EnableCrossAccountVisibility.Value;
                requestDeploymentConfigurationIsNull = false;
            }
             // determine if request.DeploymentConfiguration should be set to null
            if (requestDeploymentConfigurationIsNull)
            {
                request.DeploymentConfiguration = null;
            }
            if (cmdletContext.DeploymentDescription != null)
            {
                request.DeploymentDescription = cmdletContext.DeploymentDescription;
            }
            if (cmdletContext.DeploymentName != null)
            {
                request.DeploymentName = cmdletContext.DeploymentName;
            }
            if (cmdletContext.IsPublished != null)
            {
                request.IsPublished = cmdletContext.IsPublished.Value;
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
        
        private Amazon.NetworkSecurityManager.Model.CreateDeploymentResponse CallAWSServiceOperation(IAmazonNetworkSecurityManager client, Amazon.NetworkSecurityManager.Model.CreateDeploymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Security Manager Customer API", "CreateDeployment");
            try
            {
                return client.CreateDeploymentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.NetworkSecurityManager.Model.PolicyReference> AssociatedPolicyList { get; set; }
            public List<Amazon.NetworkSecurityManager.Model.ScopeReference> AssociatedScopeList { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? DeploymentConfiguration_EnableCrossAccountVisibility { get; set; }
            public System.String DeploymentDescription { get; set; }
            public System.String DeploymentName { get; set; }
            public System.Boolean? IsPublished { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.NetworkSecurityManager.Model.CreateDeploymentResponse, NewNSMDeploymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

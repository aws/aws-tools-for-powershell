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
using Amazon.AppMesh;
using Amazon.AppMesh.Model;

namespace Amazon.PowerShell.Cmdlets.AMSH
{
    /// <summary>
    /// Updates an existing virtual service in a specified service mesh.
    /// </summary>
    [Cmdlet("Update", "AMSHVirtualService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppMesh.Model.VirtualServiceData")]
    [AWSCmdlet("Calls the AWS App Mesh UpdateVirtualService API operation.", Operation = new[] {"UpdateVirtualService"}, SelectReturnType = typeof(Amazon.AppMesh.Model.UpdateVirtualServiceResponse))]
    [AWSCmdletOutput("Amazon.AppMesh.Model.VirtualServiceData or Amazon.AppMesh.Model.UpdateVirtualServiceResponse",
        "This cmdlet returns an Amazon.AppMesh.Model.VirtualServiceData object.",
        "The service call response (type Amazon.AppMesh.Model.UpdateVirtualServiceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAMSHVirtualServiceCmdlet : AmazonAppMeshClientCmdlet, IExecutor
    {
        
        #region Parameter MeshName
        /// <summary>
        /// <para>
        /// <para>The name of the service mesh that the virtual service resides in.</para>
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
        public System.String MeshName { get; set; }
        #endregion
        
        #region Parameter MeshOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services IAM account ID of the service mesh owner. If the account ID
        /// is not your own, then it's the ID of the account that shared the mesh with your account.
        /// For more information about mesh sharing, see <a href="https://docs.aws.amazon.com/app-mesh/latest/userguide/sharing.html">Working
        /// with shared meshes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MeshOwner { get; set; }
        #endregion
        
        #region Parameter VirtualNode_VirtualNodeName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual node that is acting as a service provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Provider_VirtualNode_VirtualNodeName")]
        public System.String VirtualNode_VirtualNodeName { get; set; }
        #endregion
        
        #region Parameter VirtualRouter_VirtualRouterName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual router that is acting as a service provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Provider_VirtualRouter_VirtualRouterName")]
        public System.String VirtualRouter_VirtualRouterName { get; set; }
        #endregion
        
        #region Parameter VirtualServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual service to update.</para>
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
        public System.String VirtualServiceName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. Up to 36 letters, numbers, hyphens, and underscores are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VirtualService'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppMesh.Model.UpdateVirtualServiceResponse).
        /// Specifying the name of a property of type Amazon.AppMesh.Model.UpdateVirtualServiceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VirtualService";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VirtualServiceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VirtualServiceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VirtualServiceName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VirtualServiceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMSHVirtualService (UpdateVirtualService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppMesh.Model.UpdateVirtualServiceResponse, UpdateAMSHVirtualServiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VirtualServiceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.MeshName = this.MeshName;
            #if MODULAR
            if (this.MeshName == null && ParameterWasBound(nameof(this.MeshName)))
            {
                WriteWarning("You are passing $null as a value for parameter MeshName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MeshOwner = this.MeshOwner;
            context.VirtualNode_VirtualNodeName = this.VirtualNode_VirtualNodeName;
            context.VirtualRouter_VirtualRouterName = this.VirtualRouter_VirtualRouterName;
            context.VirtualServiceName = this.VirtualServiceName;
            #if MODULAR
            if (this.VirtualServiceName == null && ParameterWasBound(nameof(this.VirtualServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppMesh.Model.UpdateVirtualServiceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.MeshName != null)
            {
                request.MeshName = cmdletContext.MeshName;
            }
            if (cmdletContext.MeshOwner != null)
            {
                request.MeshOwner = cmdletContext.MeshOwner;
            }
            
             // populate Spec
            var requestSpecIsNull = true;
            request.Spec = new Amazon.AppMesh.Model.VirtualServiceSpec();
            Amazon.AppMesh.Model.VirtualServiceProvider requestSpec_spec_Provider = null;
            
             // populate Provider
            var requestSpec_spec_ProviderIsNull = true;
            requestSpec_spec_Provider = new Amazon.AppMesh.Model.VirtualServiceProvider();
            Amazon.AppMesh.Model.VirtualNodeServiceProvider requestSpec_spec_Provider_spec_Provider_VirtualNode = null;
            
             // populate VirtualNode
            var requestSpec_spec_Provider_spec_Provider_VirtualNodeIsNull = true;
            requestSpec_spec_Provider_spec_Provider_VirtualNode = new Amazon.AppMesh.Model.VirtualNodeServiceProvider();
            System.String requestSpec_spec_Provider_spec_Provider_VirtualNode_virtualNode_VirtualNodeName = null;
            if (cmdletContext.VirtualNode_VirtualNodeName != null)
            {
                requestSpec_spec_Provider_spec_Provider_VirtualNode_virtualNode_VirtualNodeName = cmdletContext.VirtualNode_VirtualNodeName;
            }
            if (requestSpec_spec_Provider_spec_Provider_VirtualNode_virtualNode_VirtualNodeName != null)
            {
                requestSpec_spec_Provider_spec_Provider_VirtualNode.VirtualNodeName = requestSpec_spec_Provider_spec_Provider_VirtualNode_virtualNode_VirtualNodeName;
                requestSpec_spec_Provider_spec_Provider_VirtualNodeIsNull = false;
            }
             // determine if requestSpec_spec_Provider_spec_Provider_VirtualNode should be set to null
            if (requestSpec_spec_Provider_spec_Provider_VirtualNodeIsNull)
            {
                requestSpec_spec_Provider_spec_Provider_VirtualNode = null;
            }
            if (requestSpec_spec_Provider_spec_Provider_VirtualNode != null)
            {
                requestSpec_spec_Provider.VirtualNode = requestSpec_spec_Provider_spec_Provider_VirtualNode;
                requestSpec_spec_ProviderIsNull = false;
            }
            Amazon.AppMesh.Model.VirtualRouterServiceProvider requestSpec_spec_Provider_spec_Provider_VirtualRouter = null;
            
             // populate VirtualRouter
            var requestSpec_spec_Provider_spec_Provider_VirtualRouterIsNull = true;
            requestSpec_spec_Provider_spec_Provider_VirtualRouter = new Amazon.AppMesh.Model.VirtualRouterServiceProvider();
            System.String requestSpec_spec_Provider_spec_Provider_VirtualRouter_virtualRouter_VirtualRouterName = null;
            if (cmdletContext.VirtualRouter_VirtualRouterName != null)
            {
                requestSpec_spec_Provider_spec_Provider_VirtualRouter_virtualRouter_VirtualRouterName = cmdletContext.VirtualRouter_VirtualRouterName;
            }
            if (requestSpec_spec_Provider_spec_Provider_VirtualRouter_virtualRouter_VirtualRouterName != null)
            {
                requestSpec_spec_Provider_spec_Provider_VirtualRouter.VirtualRouterName = requestSpec_spec_Provider_spec_Provider_VirtualRouter_virtualRouter_VirtualRouterName;
                requestSpec_spec_Provider_spec_Provider_VirtualRouterIsNull = false;
            }
             // determine if requestSpec_spec_Provider_spec_Provider_VirtualRouter should be set to null
            if (requestSpec_spec_Provider_spec_Provider_VirtualRouterIsNull)
            {
                requestSpec_spec_Provider_spec_Provider_VirtualRouter = null;
            }
            if (requestSpec_spec_Provider_spec_Provider_VirtualRouter != null)
            {
                requestSpec_spec_Provider.VirtualRouter = requestSpec_spec_Provider_spec_Provider_VirtualRouter;
                requestSpec_spec_ProviderIsNull = false;
            }
             // determine if requestSpec_spec_Provider should be set to null
            if (requestSpec_spec_ProviderIsNull)
            {
                requestSpec_spec_Provider = null;
            }
            if (requestSpec_spec_Provider != null)
            {
                request.Spec.Provider = requestSpec_spec_Provider;
                requestSpecIsNull = false;
            }
             // determine if request.Spec should be set to null
            if (requestSpecIsNull)
            {
                request.Spec = null;
            }
            if (cmdletContext.VirtualServiceName != null)
            {
                request.VirtualServiceName = cmdletContext.VirtualServiceName;
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
        
        private Amazon.AppMesh.Model.UpdateVirtualServiceResponse CallAWSServiceOperation(IAmazonAppMesh client, Amazon.AppMesh.Model.UpdateVirtualServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Mesh", "UpdateVirtualService");
            try
            {
                #if DESKTOP
                return client.UpdateVirtualService(request);
                #elif CORECLR
                return client.UpdateVirtualServiceAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String MeshName { get; set; }
            public System.String MeshOwner { get; set; }
            public System.String VirtualNode_VirtualNodeName { get; set; }
            public System.String VirtualRouter_VirtualRouterName { get; set; }
            public System.String VirtualServiceName { get; set; }
            public System.Func<Amazon.AppMesh.Model.UpdateVirtualServiceResponse, UpdateAMSHVirtualServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VirtualService;
        }
        
    }
}

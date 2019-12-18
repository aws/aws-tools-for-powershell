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
    /// Creates a service mesh. A service mesh is a logical boundary for network traffic between
    ///         the services that reside within it.
    /// 
    ///          
    /// <para>
    /// After you create your service mesh, you can create virtual services, virtual nodes,
    ///         virtual routers, and routes to distribute traffic between the applications
    /// in your         mesh.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AMSHMesh", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppMesh.Model.MeshData")]
    [AWSCmdlet("Calls the AWS App Mesh CreateMesh API operation.", Operation = new[] {"CreateMesh"}, SelectReturnType = typeof(Amazon.AppMesh.Model.CreateMeshResponse))]
    [AWSCmdletOutput("Amazon.AppMesh.Model.MeshData or Amazon.AppMesh.Model.CreateMeshResponse",
        "This cmdlet returns an Amazon.AppMesh.Model.MeshData object.",
        "The service call response (type Amazon.AppMesh.Model.CreateMeshResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAMSHMeshCmdlet : AmazonAppMeshClientCmdlet, IExecutor
    {
        
        #region Parameter MeshName
        /// <summary>
        /// <para>
        /// <para>The name to use for the service mesh.</para>
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
        public System.String MeshName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata that you can apply to the service mesh to assist with categorization
        ///         and organization. Each tag consists of a key and an optional value, both of
        /// which you         define. Tag keys can have a maximum character length of 128 characters,
        /// and tag values can have            a maximum length of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AppMesh.Model.TagRef[] Tag { get; set; }
        #endregion
        
        #region Parameter EgressFilter_Type
        /// <summary>
        /// <para>
        /// <para>The egress filter type. By default, the type is <code>DROP_ALL</code>, which allows
        ///         egress only from virtual nodes to other defined resources in the service mesh
        /// (and any         traffic to <code>*.amazonaws.com</code> for AWS API calls). You can
        /// set the egress filter         type to <code>ALLOW_ALL</code> to allow egress to any
        /// endpoint inside or outside of the         service mesh.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_EgressFilter_Type")]
        [AWSConstantClassSource("Amazon.AppMesh.EgressFilterType")]
        public Amazon.AppMesh.EgressFilterType EgressFilter_Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of therequest.
        /// Up to 36 letters, numbers, hyphens, and underscores are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Mesh'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppMesh.Model.CreateMeshResponse).
        /// Specifying the name of a property of type Amazon.AppMesh.Model.CreateMeshResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Mesh";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MeshName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MeshName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MeshName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MeshName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMSHMesh (CreateMesh)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppMesh.Model.CreateMeshResponse, NewAMSHMeshCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MeshName;
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
            context.EgressFilter_Type = this.EgressFilter_Type;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AppMesh.Model.TagRef>(this.Tag);
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
            var request = new Amazon.AppMesh.Model.CreateMeshRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.MeshName != null)
            {
                request.MeshName = cmdletContext.MeshName;
            }
            
             // populate Spec
            var requestSpecIsNull = true;
            request.Spec = new Amazon.AppMesh.Model.MeshSpec();
            Amazon.AppMesh.Model.EgressFilter requestSpec_spec_EgressFilter = null;
            
             // populate EgressFilter
            var requestSpec_spec_EgressFilterIsNull = true;
            requestSpec_spec_EgressFilter = new Amazon.AppMesh.Model.EgressFilter();
            Amazon.AppMesh.EgressFilterType requestSpec_spec_EgressFilter_egressFilter_Type = null;
            if (cmdletContext.EgressFilter_Type != null)
            {
                requestSpec_spec_EgressFilter_egressFilter_Type = cmdletContext.EgressFilter_Type;
            }
            if (requestSpec_spec_EgressFilter_egressFilter_Type != null)
            {
                requestSpec_spec_EgressFilter.Type = requestSpec_spec_EgressFilter_egressFilter_Type;
                requestSpec_spec_EgressFilterIsNull = false;
            }
             // determine if requestSpec_spec_EgressFilter should be set to null
            if (requestSpec_spec_EgressFilterIsNull)
            {
                requestSpec_spec_EgressFilter = null;
            }
            if (requestSpec_spec_EgressFilter != null)
            {
                request.Spec.EgressFilter = requestSpec_spec_EgressFilter;
                requestSpecIsNull = false;
            }
             // determine if request.Spec should be set to null
            if (requestSpecIsNull)
            {
                request.Spec = null;
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
        
        private Amazon.AppMesh.Model.CreateMeshResponse CallAWSServiceOperation(IAmazonAppMesh client, Amazon.AppMesh.Model.CreateMeshRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Mesh", "CreateMesh");
            try
            {
                #if DESKTOP
                return client.CreateMesh(request);
                #elif CORECLR
                return client.CreateMeshAsync(request).GetAwaiter().GetResult();
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
            public Amazon.AppMesh.EgressFilterType EgressFilter_Type { get; set; }
            public List<Amazon.AppMesh.Model.TagRef> Tag { get; set; }
            public System.Func<Amazon.AppMesh.Model.CreateMeshResponse, NewAMSHMeshCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Mesh;
        }
        
    }
}

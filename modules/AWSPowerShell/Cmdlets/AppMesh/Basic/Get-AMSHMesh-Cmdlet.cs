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
using Amazon.AppMesh;
using Amazon.AppMesh.Model;

namespace Amazon.PowerShell.Cmdlets.AMSH
{
    /// <summary>
    /// Describes an existing service mesh.
    /// </summary>
    [Cmdlet("Get", "AMSHMesh")]
    [OutputType("Amazon.AppMesh.Model.MeshData")]
    [AWSCmdlet("Calls the AWS App Mesh DescribeMesh API operation.", Operation = new[] {"DescribeMesh"}, SelectReturnType = typeof(Amazon.AppMesh.Model.DescribeMeshResponse))]
    [AWSCmdletOutput("Amazon.AppMesh.Model.MeshData or Amazon.AppMesh.Model.DescribeMeshResponse",
        "This cmdlet returns an Amazon.AppMesh.Model.MeshData object.",
        "The service call response (type Amazon.AppMesh.Model.DescribeMeshResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAMSHMeshCmdlet : AmazonAppMeshClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MeshName
        /// <summary>
        /// <para>
        /// <para>The name of the service mesh to describe.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Mesh'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppMesh.Model.DescribeMeshResponse).
        /// Specifying the name of a property of type Amazon.AppMesh.Model.DescribeMeshResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppMesh.Model.DescribeMeshResponse, GetAMSHMeshCmdlet>(Select) ??
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
            context.MeshName = this.MeshName;
            #if MODULAR
            if (this.MeshName == null && ParameterWasBound(nameof(this.MeshName)))
            {
                WriteWarning("You are passing $null as a value for parameter MeshName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MeshOwner = this.MeshOwner;
            
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
            var request = new Amazon.AppMesh.Model.DescribeMeshRequest();
            
            if (cmdletContext.MeshName != null)
            {
                request.MeshName = cmdletContext.MeshName;
            }
            if (cmdletContext.MeshOwner != null)
            {
                request.MeshOwner = cmdletContext.MeshOwner;
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
        
        private Amazon.AppMesh.Model.DescribeMeshResponse CallAWSServiceOperation(IAmazonAppMesh client, Amazon.AppMesh.Model.DescribeMeshRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Mesh", "DescribeMesh");
            try
            {
                #if DESKTOP
                return client.DescribeMesh(request);
                #elif CORECLR
                return client.DescribeMeshAsync(request).GetAwaiter().GetResult();
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
            public System.String MeshName { get; set; }
            public System.String MeshOwner { get; set; }
            public System.Func<Amazon.AppMesh.Model.DescribeMeshResponse, GetAMSHMeshCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Mesh;
        }
        
    }
}

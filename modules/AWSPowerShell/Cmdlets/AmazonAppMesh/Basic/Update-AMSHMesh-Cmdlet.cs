/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Updates an existing service mesh.
    /// </summary>
    [Cmdlet("Update", "AMSHMesh", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppMesh.Model.MeshData")]
    [AWSCmdlet("Calls the AWS App Mesh UpdateMesh API operation.", Operation = new[] {"UpdateMesh"})]
    [AWSCmdletOutput("Amazon.AppMesh.Model.MeshData",
        "This cmdlet returns a MeshData object.",
        "The service call response (type Amazon.AppMesh.Model.UpdateMeshResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAMSHMeshCmdlet : AmazonAppMeshClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of therequest.
        /// Up to 36 letters, numbers, hyphens, and underscores are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter MeshName
        /// <summary>
        /// <para>
        /// <para>The name of the service mesh to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String MeshName { get; set; }
        #endregion
        
        #region Parameter EgressFilter_Type
        /// <summary>
        /// <para>
        /// <para>The egress filter type. By default, the type is <code>DROP_ALL</code>, which allows
        ///         egress only from virtual nodes to other defined resources in the service mesh
        /// (and any traffic         to <code>*.amazonaws.com</code> for AWS API calls). You can
        /// set the egress filter type to            <code>ALLOW_ALL</code> to allow egress to
        /// any endpoint inside or outside of the service         mesh.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Spec_EgressFilter_Type")]
        [AWSConstantClassSource("Amazon.AppMesh.EgressFilterType")]
        public Amazon.AppMesh.EgressFilterType EgressFilter_Type { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("MeshName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMSHMesh (UpdateMesh)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientToken = this.ClientToken;
            context.MeshName = this.MeshName;
            context.Spec_EgressFilter_Type = this.EgressFilter_Type;
            
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
            var request = new Amazon.AppMesh.Model.UpdateMeshRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.MeshName != null)
            {
                request.MeshName = cmdletContext.MeshName;
            }
            
             // populate Spec
            bool requestSpecIsNull = true;
            request.Spec = new Amazon.AppMesh.Model.MeshSpec();
            Amazon.AppMesh.Model.EgressFilter requestSpec_spec_EgressFilter = null;
            
             // populate EgressFilter
            bool requestSpec_spec_EgressFilterIsNull = true;
            requestSpec_spec_EgressFilter = new Amazon.AppMesh.Model.EgressFilter();
            Amazon.AppMesh.EgressFilterType requestSpec_spec_EgressFilter_egressFilter_Type = null;
            if (cmdletContext.Spec_EgressFilter_Type != null)
            {
                requestSpec_spec_EgressFilter_egressFilter_Type = cmdletContext.Spec_EgressFilter_Type;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Mesh;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.AppMesh.Model.UpdateMeshResponse CallAWSServiceOperation(IAmazonAppMesh client, Amazon.AppMesh.Model.UpdateMeshRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Mesh", "UpdateMesh");
            try
            {
                #if DESKTOP
                return client.UpdateMesh(request);
                #elif CORECLR
                return client.UpdateMeshAsync(request).GetAwaiter().GetResult();
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
            public Amazon.AppMesh.EgressFilterType Spec_EgressFilter_Type { get; set; }
        }
        
    }
}

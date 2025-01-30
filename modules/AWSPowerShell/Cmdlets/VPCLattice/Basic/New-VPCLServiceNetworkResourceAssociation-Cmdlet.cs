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
using Amazon.VPCLattice;
using Amazon.VPCLattice.Model;

namespace Amazon.PowerShell.Cmdlets.VPCL
{
    /// <summary>
    /// Associates the specified service network with the specified resource configuration.
    /// This allows the resource configuration to receive connections through the service
    /// network, including through a service network VPC endpoint.
    /// </summary>
    [Cmdlet("New", "VPCLServiceNetworkResourceAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VPCLattice.Model.CreateServiceNetworkResourceAssociationResponse")]
    [AWSCmdlet("Calls the VPC Lattice CreateServiceNetworkResourceAssociation API operation.", Operation = new[] {"CreateServiceNetworkResourceAssociation"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.CreateServiceNetworkResourceAssociationResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.CreateServiceNetworkResourceAssociationResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.CreateServiceNetworkResourceAssociationResponse object containing multiple properties."
    )]
    public partial class NewVPCLServiceNetworkResourceAssociationCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceConfigurationIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the resource configuration to associate with the service network.</para>
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
        public System.String ResourceConfigurationIdentifier { get; set; }
        #endregion
        
        #region Parameter ServiceNetworkIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the service network to associate with the resource configuration.</para>
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
        public System.String ServiceNetworkIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for the association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you retry a request that completed successfully using the same client
        /// token and parameters, the retry succeeds without performing any actions. If the parameters
        /// aren't identical, the retry fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.CreateServiceNetworkResourceAssociationResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.CreateServiceNetworkResourceAssociationResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-VPCLServiceNetworkResourceAssociation (CreateServiceNetworkResourceAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.CreateServiceNetworkResourceAssociationResponse, NewVPCLServiceNetworkResourceAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ResourceConfigurationIdentifier = this.ResourceConfigurationIdentifier;
            #if MODULAR
            if (this.ResourceConfigurationIdentifier == null && ParameterWasBound(nameof(this.ResourceConfigurationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceConfigurationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceNetworkIdentifier = this.ServiceNetworkIdentifier;
            #if MODULAR
            if (this.ServiceNetworkIdentifier == null && ParameterWasBound(nameof(this.ServiceNetworkIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceNetworkIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VPCLattice.Model.CreateServiceNetworkResourceAssociationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ResourceConfigurationIdentifier != null)
            {
                request.ResourceConfigurationIdentifier = cmdletContext.ResourceConfigurationIdentifier;
            }
            if (cmdletContext.ServiceNetworkIdentifier != null)
            {
                request.ServiceNetworkIdentifier = cmdletContext.ServiceNetworkIdentifier;
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
        
        private Amazon.VPCLattice.Model.CreateServiceNetworkResourceAssociationResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.CreateServiceNetworkResourceAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "CreateServiceNetworkResourceAssociation");
            try
            {
                #if DESKTOP
                return client.CreateServiceNetworkResourceAssociation(request);
                #elif CORECLR
                return client.CreateServiceNetworkResourceAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceConfigurationIdentifier { get; set; }
            public System.String ServiceNetworkIdentifier { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.VPCLattice.Model.CreateServiceNetworkResourceAssociationResponse, NewVPCLServiceNetworkResourceAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

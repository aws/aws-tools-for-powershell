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
using Amazon.VPCLattice;
using Amazon.VPCLattice.Model;

namespace Amazon.PowerShell.Cmdlets.VPCL
{
    /// <summary>
    /// Updates the service network and VPC association. If you add a security group to the
    /// service network and VPC association, the association must continue to have at least
    /// one security group. You can add or edit security groups at any time. However, to remove
    /// all security groups, you must first delete the association and then recreate it without
    /// security groups.
    /// </summary>
    [Cmdlet("Update", "VPCLServiceNetworkVpcAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse")]
    [AWSCmdlet("Calls the VPC Lattice UpdateServiceNetworkVpcAssociation API operation.", Operation = new[] {"UpdateServiceNetworkVpcAssociation"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse object containing multiple properties."
    )]
    public partial class UpdateVPCLServiceNetworkVpcAssociationCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups.</para>
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
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ServiceNetworkVpcAssociationIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the association.</para>
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
        public System.String ServiceNetworkVpcAssociationIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceNetworkVpcAssociationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-VPCLServiceNetworkVpcAssociation (UpdateServiceNetworkVpcAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse, UpdateVPCLServiceNetworkVpcAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            #if MODULAR
            if (this.SecurityGroupId == null && ParameterWasBound(nameof(this.SecurityGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceNetworkVpcAssociationIdentifier = this.ServiceNetworkVpcAssociationIdentifier;
            #if MODULAR
            if (this.ServiceNetworkVpcAssociationIdentifier == null && ParameterWasBound(nameof(this.ServiceNetworkVpcAssociationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceNetworkVpcAssociationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationRequest();
            
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.ServiceNetworkVpcAssociationIdentifier != null)
            {
                request.ServiceNetworkVpcAssociationIdentifier = cmdletContext.ServiceNetworkVpcAssociationIdentifier;
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
        
        private Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "UpdateServiceNetworkVpcAssociation");
            try
            {
                #if DESKTOP
                return client.UpdateServiceNetworkVpcAssociation(request);
                #elif CORECLR
                return client.UpdateServiceNetworkVpcAssociationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> SecurityGroupId { get; set; }
            public System.String ServiceNetworkVpcAssociationIdentifier { get; set; }
            public System.Func<Amazon.VPCLattice.Model.UpdateServiceNetworkVpcAssociationResponse, UpdateVPCLServiceNetworkVpcAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

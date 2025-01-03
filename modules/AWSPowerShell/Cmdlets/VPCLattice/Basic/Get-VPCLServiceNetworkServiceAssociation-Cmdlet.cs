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
    /// Retrieves information about the specified association between a service network and
    /// a service.
    /// </summary>
    [Cmdlet("Get", "VPCLServiceNetworkServiceAssociation")]
    [OutputType("Amazon.VPCLattice.Model.GetServiceNetworkServiceAssociationResponse")]
    [AWSCmdlet("Calls the VPC Lattice GetServiceNetworkServiceAssociation API operation.", Operation = new[] {"GetServiceNetworkServiceAssociation"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.GetServiceNetworkServiceAssociationResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.GetServiceNetworkServiceAssociationResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.GetServiceNetworkServiceAssociationResponse object containing multiple properties."
    )]
    public partial class GetVPCLServiceNetworkServiceAssociationCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ServiceNetworkServiceAssociationIdentifier
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
        public System.String ServiceNetworkServiceAssociationIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.GetServiceNetworkServiceAssociationResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.GetServiceNetworkServiceAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.GetServiceNetworkServiceAssociationResponse, GetVPCLServiceNetworkServiceAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ServiceNetworkServiceAssociationIdentifier = this.ServiceNetworkServiceAssociationIdentifier;
            #if MODULAR
            if (this.ServiceNetworkServiceAssociationIdentifier == null && ParameterWasBound(nameof(this.ServiceNetworkServiceAssociationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceNetworkServiceAssociationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VPCLattice.Model.GetServiceNetworkServiceAssociationRequest();
            
            if (cmdletContext.ServiceNetworkServiceAssociationIdentifier != null)
            {
                request.ServiceNetworkServiceAssociationIdentifier = cmdletContext.ServiceNetworkServiceAssociationIdentifier;
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
        
        private Amazon.VPCLattice.Model.GetServiceNetworkServiceAssociationResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.GetServiceNetworkServiceAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "GetServiceNetworkServiceAssociation");
            try
            {
                #if DESKTOP
                return client.GetServiceNetworkServiceAssociation(request);
                #elif CORECLR
                return client.GetServiceNetworkServiceAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String ServiceNetworkServiceAssociationIdentifier { get; set; }
            public System.Func<Amazon.VPCLattice.Model.GetServiceNetworkServiceAssociationResponse, GetVPCLServiceNetworkServiceAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

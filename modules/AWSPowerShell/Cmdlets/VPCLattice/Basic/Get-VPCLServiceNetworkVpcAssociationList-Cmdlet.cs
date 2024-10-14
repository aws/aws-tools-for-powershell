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
    /// Lists the service network and VPC associations. You can filter the list either by
    /// VPC or service network. You must provide either the service network identifier or
    /// the VPC identifier.
    /// </summary>
    [Cmdlet("Get", "VPCLServiceNetworkVpcAssociationList")]
    [OutputType("Amazon.VPCLattice.Model.ServiceNetworkVpcAssociationSummary")]
    [AWSCmdlet("Calls the VPC Lattice ListServiceNetworkVpcAssociations API operation.", Operation = new[] {"ListServiceNetworkVpcAssociations"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.ListServiceNetworkVpcAssociationsResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.ServiceNetworkVpcAssociationSummary or Amazon.VPCLattice.Model.ListServiceNetworkVpcAssociationsResponse",
        "This cmdlet returns a collection of Amazon.VPCLattice.Model.ServiceNetworkVpcAssociationSummary objects.",
        "The service call response (type Amazon.VPCLattice.Model.ListServiceNetworkVpcAssociationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetVPCLServiceNetworkVpcAssociationListCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ServiceNetworkIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or Amazon Resource Name (ARN) of the service network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ServiceNetworkIdentifier { get; set; }
        #endregion
        
        #region Parameter VpcIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or Amazon Resource Name (ARN) of the VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcIdentifier { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A pagination token for the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.ListServiceNetworkVpcAssociationsResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.ListServiceNetworkVpcAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceNetworkIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceNetworkIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceNetworkIdentifier' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.ListServiceNetworkVpcAssociationsResponse, GetVPCLServiceNetworkVpcAssociationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceNetworkIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ServiceNetworkIdentifier = this.ServiceNetworkIdentifier;
            context.VpcIdentifier = this.VpcIdentifier;
            
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
            var request = new Amazon.VPCLattice.Model.ListServiceNetworkVpcAssociationsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ServiceNetworkIdentifier != null)
            {
                request.ServiceNetworkIdentifier = cmdletContext.ServiceNetworkIdentifier;
            }
            if (cmdletContext.VpcIdentifier != null)
            {
                request.VpcIdentifier = cmdletContext.VpcIdentifier;
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
        
        private Amazon.VPCLattice.Model.ListServiceNetworkVpcAssociationsResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.ListServiceNetworkVpcAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "ListServiceNetworkVpcAssociations");
            try
            {
                #if DESKTOP
                return client.ListServiceNetworkVpcAssociations(request);
                #elif CORECLR
                return client.ListServiceNetworkVpcAssociationsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ServiceNetworkIdentifier { get; set; }
            public System.String VpcIdentifier { get; set; }
            public System.Func<Amazon.VPCLattice.Model.ListServiceNetworkVpcAssociationsResponse, GetVPCLServiceNetworkVpcAssociationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}

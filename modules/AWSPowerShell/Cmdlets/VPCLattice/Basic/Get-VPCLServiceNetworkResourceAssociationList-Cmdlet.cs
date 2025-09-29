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
    /// Lists the associations between a service network and a resource configuration.
    /// </summary>
    [Cmdlet("Get", "VPCLServiceNetworkResourceAssociationList")]
    [OutputType("Amazon.VPCLattice.Model.ServiceNetworkResourceAssociationSummary")]
    [AWSCmdlet("Calls the VPC Lattice ListServiceNetworkResourceAssociations API operation.", Operation = new[] {"ListServiceNetworkResourceAssociations"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.ListServiceNetworkResourceAssociationsResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.ServiceNetworkResourceAssociationSummary or Amazon.VPCLattice.Model.ListServiceNetworkResourceAssociationsResponse",
        "This cmdlet returns a collection of Amazon.VPCLattice.Model.ServiceNetworkResourceAssociationSummary objects.",
        "The service call response (type Amazon.VPCLattice.Model.ListServiceNetworkResourceAssociationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetVPCLServiceNetworkResourceAssociationListCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IncludeChild
        /// <summary>
        /// <para>
        /// <para>Include service network resource associations of the child resource configuration
        /// with the grouped resource configuration.</para><para>The type is boolean and the default value is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeChildren")]
        public System.Boolean? IncludeChild { get; set; }
        #endregion
        
        #region Parameter ResourceConfigurationIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the resource configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfigurationIdentifier { get; set; }
        #endregion
        
        #region Parameter ServiceNetworkIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the service network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceNetworkIdentifier { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum page size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If there are additional results, a pagination token for the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.ListServiceNetworkResourceAssociationsResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.ListServiceNetworkResourceAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.ListServiceNetworkResourceAssociationsResponse, GetVPCLServiceNetworkResourceAssociationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IncludeChild = this.IncludeChild;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ResourceConfigurationIdentifier = this.ResourceConfigurationIdentifier;
            context.ServiceNetworkIdentifier = this.ServiceNetworkIdentifier;
            
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
            var request = new Amazon.VPCLattice.Model.ListServiceNetworkResourceAssociationsRequest();
            
            if (cmdletContext.IncludeChild != null)
            {
                request.IncludeChildren = cmdletContext.IncludeChild.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ResourceConfigurationIdentifier != null)
            {
                request.ResourceConfigurationIdentifier = cmdletContext.ResourceConfigurationIdentifier;
            }
            if (cmdletContext.ServiceNetworkIdentifier != null)
            {
                request.ServiceNetworkIdentifier = cmdletContext.ServiceNetworkIdentifier;
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
        
        private Amazon.VPCLattice.Model.ListServiceNetworkResourceAssociationsResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.ListServiceNetworkResourceAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "ListServiceNetworkResourceAssociations");
            try
            {
                #if DESKTOP
                return client.ListServiceNetworkResourceAssociations(request);
                #elif CORECLR
                return client.ListServiceNetworkResourceAssociationsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeChild { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceConfigurationIdentifier { get; set; }
            public System.String ServiceNetworkIdentifier { get; set; }
            public System.Func<Amazon.VPCLattice.Model.ListServiceNetworkResourceAssociationsResponse, GetVPCLServiceNetworkResourceAssociationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}

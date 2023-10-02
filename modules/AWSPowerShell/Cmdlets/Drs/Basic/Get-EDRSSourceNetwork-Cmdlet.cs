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
using Amazon.Drs;
using Amazon.Drs.Model;

namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Lists all Source Networks or multiple Source Networks filtered by ID.
    /// </summary>
    [Cmdlet("Get", "EDRSSourceNetwork")]
    [OutputType("Amazon.Drs.Model.SourceNetwork")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service DescribeSourceNetworks API operation.", Operation = new[] {"DescribeSourceNetworks"}, SelectReturnType = typeof(Amazon.Drs.Model.DescribeSourceNetworksResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.SourceNetwork or Amazon.Drs.Model.DescribeSourceNetworksResponse",
        "This cmdlet returns a collection of Amazon.Drs.Model.SourceNetwork objects.",
        "The service call response (type Amazon.Drs.Model.DescribeSourceNetworksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEDRSSourceNetworkCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_OriginAccountID
        /// <summary>
        /// <para>
        /// <para>Filter Source Networks by account ID containing the protected VPCs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_OriginAccountID { get; set; }
        #endregion
        
        #region Parameter Filters_OriginRegion
        /// <summary>
        /// <para>
        /// <para>Filter Source Networks by the region containing the protected VPCs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_OriginRegion { get; set; }
        #endregion
        
        #region Parameter Filters_SourceNetworkIDs
        /// <summary>
        /// <para>
        /// <para>An array of Source Network IDs that should be returned. An empty array means all Source
        /// Networks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filters_SourceNetworkIDs { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of Source Networks to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token of the next Source Networks to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.DescribeSourceNetworksResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.DescribeSourceNetworksResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.DescribeSourceNetworksResponse, GetEDRSSourceNetworkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filters_OriginAccountID = this.Filters_OriginAccountID;
            context.Filters_OriginRegion = this.Filters_OriginRegion;
            if (this.Filters_SourceNetworkIDs != null)
            {
                context.Filters_SourceNetworkIDs = new List<System.String>(this.Filters_SourceNetworkIDs);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Drs.Model.DescribeSourceNetworksRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Drs.Model.DescribeSourceNetworksRequestFilters();
            System.String requestFilters_filters_OriginAccountID = null;
            if (cmdletContext.Filters_OriginAccountID != null)
            {
                requestFilters_filters_OriginAccountID = cmdletContext.Filters_OriginAccountID;
            }
            if (requestFilters_filters_OriginAccountID != null)
            {
                request.Filters.OriginAccountID = requestFilters_filters_OriginAccountID;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_OriginRegion = null;
            if (cmdletContext.Filters_OriginRegion != null)
            {
                requestFilters_filters_OriginRegion = cmdletContext.Filters_OriginRegion;
            }
            if (requestFilters_filters_OriginRegion != null)
            {
                request.Filters.OriginRegion = requestFilters_filters_OriginRegion;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_SourceNetworkIDs = null;
            if (cmdletContext.Filters_SourceNetworkIDs != null)
            {
                requestFilters_filters_SourceNetworkIDs = cmdletContext.Filters_SourceNetworkIDs;
            }
            if (requestFilters_filters_SourceNetworkIDs != null)
            {
                request.Filters.SourceNetworkIDs = requestFilters_filters_SourceNetworkIDs;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Drs.Model.DescribeSourceNetworksResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.DescribeSourceNetworksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "DescribeSourceNetworks");
            try
            {
                #if DESKTOP
                return client.DescribeSourceNetworks(request);
                #elif CORECLR
                return client.DescribeSourceNetworksAsync(request).GetAwaiter().GetResult();
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
            public System.String Filters_OriginAccountID { get; set; }
            public System.String Filters_OriginRegion { get; set; }
            public List<System.String> Filters_SourceNetworkIDs { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Drs.Model.DescribeSourceNetworksResponse, GetEDRSSourceNetworkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}

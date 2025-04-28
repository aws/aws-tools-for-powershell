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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Lists the distribution tenants in your Amazon Web Services account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFDistributionTenantList")]
    [OutputType("Amazon.CloudFront.Model.DistributionTenantSummary")]
    [AWSCmdlet("Calls the Amazon CloudFront ListDistributionTenants API operation.", Operation = new[] {"ListDistributionTenants"}, SelectReturnType = typeof(Amazon.CloudFront.Model.ListDistributionTenantsResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.DistributionTenantSummary or Amazon.CloudFront.Model.ListDistributionTenantsResponse",
        "This cmdlet returns a collection of Amazon.CloudFront.Model.DistributionTenantSummary objects.",
        "The service call response (type Amazon.CloudFront.Model.ListDistributionTenantsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFDistributionTenantListCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssociationFilter_ConnectionGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the connection group to filter by. You can find distribution tenants associated
        /// with a specific connection group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssociationFilter_ConnectionGroupId { get; set; }
        #endregion
        
        #region Parameter AssociationFilter_DistributionId
        /// <summary>
        /// <para>
        /// <para>The distribution ID to filter by. You can find distribution tenants associated with
        /// a specific distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssociationFilter_DistributionId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The marker for the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of distribution tenants to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.Int32? MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DistributionTenantList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.ListDistributionTenantsResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.ListDistributionTenantsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DistributionTenantList";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.ListDistributionTenantsResponse, GetCFDistributionTenantListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociationFilter_ConnectionGroupId = this.AssociationFilter_ConnectionGroupId;
            context.AssociationFilter_DistributionId = this.AssociationFilter_DistributionId;
            context.Marker = this.Marker;
            context.MaxItem = this.MaxItem;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.CloudFront.Model.ListDistributionTenantsRequest();
            
            
             // populate AssociationFilter
            var requestAssociationFilterIsNull = true;
            request.AssociationFilter = new Amazon.CloudFront.Model.DistributionTenantAssociationFilter();
            System.String requestAssociationFilter_associationFilter_ConnectionGroupId = null;
            if (cmdletContext.AssociationFilter_ConnectionGroupId != null)
            {
                requestAssociationFilter_associationFilter_ConnectionGroupId = cmdletContext.AssociationFilter_ConnectionGroupId;
            }
            if (requestAssociationFilter_associationFilter_ConnectionGroupId != null)
            {
                request.AssociationFilter.ConnectionGroupId = requestAssociationFilter_associationFilter_ConnectionGroupId;
                requestAssociationFilterIsNull = false;
            }
            System.String requestAssociationFilter_associationFilter_DistributionId = null;
            if (cmdletContext.AssociationFilter_DistributionId != null)
            {
                requestAssociationFilter_associationFilter_DistributionId = cmdletContext.AssociationFilter_DistributionId;
            }
            if (requestAssociationFilter_associationFilter_DistributionId != null)
            {
                request.AssociationFilter.DistributionId = requestAssociationFilter_associationFilter_DistributionId;
                requestAssociationFilterIsNull = false;
            }
             // determine if request.AssociationFilter should be set to null
            if (requestAssociationFilterIsNull)
            {
                request.AssociationFilter = null;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextMarker;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudFront.Model.ListDistributionTenantsResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.ListDistributionTenantsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "ListDistributionTenants");
            try
            {
                #if DESKTOP
                return client.ListDistributionTenants(request);
                #elif CORECLR
                return client.ListDistributionTenantsAsync(request).GetAwaiter().GetResult();
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
            public System.String AssociationFilter_ConnectionGroupId { get; set; }
            public System.String AssociationFilter_DistributionId { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxItem { get; set; }
            public System.Func<Amazon.CloudFront.Model.ListDistributionTenantsResponse, GetCFDistributionTenantListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DistributionTenantList;
        }
        
    }
}

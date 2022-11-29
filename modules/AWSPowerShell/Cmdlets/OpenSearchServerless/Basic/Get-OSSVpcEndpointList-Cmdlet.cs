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
using Amazon.OpenSearchServerless;
using Amazon.OpenSearchServerless.Model;

namespace Amazon.PowerShell.Cmdlets.OSS
{
    /// <summary>
    /// Returns the OpenSearch Serverless-managed interface VPC endpoints associated with
    /// the current account. For more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/serverless-vpc.html">Access
    /// Amazon OpenSearch Serverless using an interface endpoint</a>.
    /// </summary>
    [Cmdlet("Get", "OSSVpcEndpointList")]
    [OutputType("Amazon.OpenSearchServerless.Model.VpcEndpointSummary")]
    [AWSCmdlet("Calls the OpenSearch Serverless ListVpcEndpoints API operation.", Operation = new[] {"ListVpcEndpoints"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.ListVpcEndpointsResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.VpcEndpointSummary or Amazon.OpenSearchServerless.Model.ListVpcEndpointsResponse",
        "This cmdlet returns a collection of Amazon.OpenSearchServerless.Model.VpcEndpointSummary objects.",
        "The service call response (type Amazon.OpenSearchServerless.Model.ListVpcEndpointsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetOSSVpcEndpointListCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        #region Parameter VpcEndpointFilters_Status
        /// <summary>
        /// <para>
        /// <para>The current status of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.OpenSearchServerless.VpcEndpointStatus")]
        public Amazon.OpenSearchServerless.VpcEndpointStatus VpcEndpointFilters_Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional parameter that specifies the maximum number of results to return. You
        /// can use <code>nextToken</code> to get the next page of results. The default is 20.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If your initial <code>ListVpcEndpoints</code> operation returns a <code>nextToken</code>,
        /// you can include the returned <code>nextToken</code> in subsequent <code>ListVpcEndpoints</code>
        /// operations, which returns results in the next page. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcEndpointSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.ListVpcEndpointsResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.ListVpcEndpointsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcEndpointSummaries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VpcEndpointFilters_Status parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VpcEndpointFilters_Status' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VpcEndpointFilters_Status' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.ListVpcEndpointsResponse, GetOSSVpcEndpointListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VpcEndpointFilters_Status;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.VpcEndpointFilters_Status = this.VpcEndpointFilters_Status;
            
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
            var request = new Amazon.OpenSearchServerless.Model.ListVpcEndpointsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate VpcEndpointFilters
            var requestVpcEndpointFiltersIsNull = true;
            request.VpcEndpointFilters = new Amazon.OpenSearchServerless.Model.VpcEndpointFilters();
            Amazon.OpenSearchServerless.VpcEndpointStatus requestVpcEndpointFilters_vpcEndpointFilters_Status = null;
            if (cmdletContext.VpcEndpointFilters_Status != null)
            {
                requestVpcEndpointFilters_vpcEndpointFilters_Status = cmdletContext.VpcEndpointFilters_Status;
            }
            if (requestVpcEndpointFilters_vpcEndpointFilters_Status != null)
            {
                request.VpcEndpointFilters.Status = requestVpcEndpointFilters_vpcEndpointFilters_Status;
                requestVpcEndpointFiltersIsNull = false;
            }
             // determine if request.VpcEndpointFilters should be set to null
            if (requestVpcEndpointFiltersIsNull)
            {
                request.VpcEndpointFilters = null;
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
        
        private Amazon.OpenSearchServerless.Model.ListVpcEndpointsResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.ListVpcEndpointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "ListVpcEndpoints");
            try
            {
                #if DESKTOP
                return client.ListVpcEndpoints(request);
                #elif CORECLR
                return client.ListVpcEndpointsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.OpenSearchServerless.VpcEndpointStatus VpcEndpointFilters_Status { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.ListVpcEndpointsResponse, GetOSSVpcEndpointListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcEndpointSummaries;
        }
        
    }
}

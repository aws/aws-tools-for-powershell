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
using System.Threading;
using Amazon.Private5G;
using Amazon.Private5G.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PV5G
{
    /// <summary>
    /// Lists network resources. Add filters to your request to return a more specific list
    /// of results. Use filters to match the Amazon Resource Name (ARN) of an order or the
    /// status of network resources.
    /// 
    ///  
    /// <para>
    /// If you specify multiple filters, filters are joined with an OR, and the request returns
    /// results that match all of the specified filters.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "PV5GNetworkResourceList")]
    [OutputType("Amazon.Private5G.Model.NetworkResource")]
    [AWSCmdlet("Calls the AWS Private 5G ListNetworkResources API operation.", Operation = new[] {"ListNetworkResources"}, SelectReturnType = typeof(Amazon.Private5G.Model.ListNetworkResourcesResponse))]
    [AWSCmdletOutput("Amazon.Private5G.Model.NetworkResource or Amazon.Private5G.Model.ListNetworkResourcesResponse",
        "This cmdlet returns a collection of Amazon.Private5G.Model.NetworkResource objects.",
        "The service call response (type Amazon.Private5G.Model.ListNetworkResourcesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPV5GNetworkResourceListCmdlet : AmazonPrivate5GClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><c>ORDER</c> - The Amazon Resource Name (ARN) of the order.</para></li><li><para><c>STATUS</c> - The status (<c>AVAILABLE</c> | <c>DELETED</c> | <c>DELETING</c> |
        /// <c>PENDING</c> | <c>PENDING_RETURN</c> | <c>PROVISIONING</c> | <c>SHIPPED</c>).</para></li></ul><para>Filter values are case sensitive. If you specify multiple values for a filter, the
        /// values are joined with an <c>OR</c>, and the request returns all results that match
        /// any of the specified values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public System.Collections.Hashtable Filter { get; set; }
        #endregion
        
        #region Parameter NetworkArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the network.</para>
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
        public System.String NetworkArn { get; set; }
        #endregion
        
        #region Parameter StartToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartToken { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkResources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Private5G.Model.ListNetworkResourcesResponse).
        /// Specifying the name of a property of type Amazon.Private5G.Model.ListNetworkResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkResources";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Private5G.Model.ListNetworkResourcesResponse, GetPV5GNetworkResourceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Filter.Keys)
                {
                    object hashValue = this.Filter[hashKey];
                    if (hashValue == null)
                    {
                        context.Filter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Filter.Add((String)hashKey, valueSet);
                }
            }
            context.MaxResult = this.MaxResult;
            context.NetworkArn = this.NetworkArn;
            #if MODULAR
            if (this.NetworkArn == null && ParameterWasBound(nameof(this.NetworkArn)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartToken = this.StartToken;
            
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
            var request = new Amazon.Private5G.Model.ListNetworkResourcesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NetworkArn != null)
            {
                request.NetworkArn = cmdletContext.NetworkArn;
            }
            if (cmdletContext.StartToken != null)
            {
                request.StartToken = cmdletContext.StartToken;
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
        
        private Amazon.Private5G.Model.ListNetworkResourcesResponse CallAWSServiceOperation(IAmazonPrivate5G client, Amazon.Private5G.Model.ListNetworkResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Private 5G", "ListNetworkResources");
            try
            {
                return client.ListNetworkResourcesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, List<System.String>> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NetworkArn { get; set; }
            public System.String StartToken { get; set; }
            public System.Func<Amazon.Private5G.Model.ListNetworkResourcesResponse, GetPV5GNetworkResourceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkResources;
        }
        
    }
}

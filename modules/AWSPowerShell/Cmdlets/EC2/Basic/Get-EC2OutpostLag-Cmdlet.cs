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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the Outposts link aggregation groups (LAGs).
    /// </summary>
    [Cmdlet("Get", "EC2OutpostLag")]
    [OutputType("Amazon.EC2.Model.OutpostLag")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeOutpostLags API operation.", Operation = new[] {"DescribeOutpostLags"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeOutpostLagsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.OutpostLag or Amazon.EC2.Model.DescribeOutpostLagsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.OutpostLag objects.",
        "The service call response (type Amazon.EC2.Model.DescribeOutpostLagsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2OutpostLagCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters to use for narrowing down the request. The following filters are supported:</para><ul><li><para><c>service-link-virtual-interface-id</c> - The ID of the service link virtual interface.</para></li><li><para><c>service-link-virtual-interface-arn</c> - The ARN of the service link virtual interface.</para></li><li><para><c>outpost-id</c> - The Outpost ID.</para></li><li><para><c>outpost-arn</c> - The Outpost ARN.</para></li><li><para><c>owner-id</c> - The ID of the Amazon Web Services account that owns the service
        /// link virtual interface.</para></li><li><para><c>vlan</c> - The ID of the address pool.</para></li><li><para><c>local-address</c> - The local address.</para></li><li><para><c>peer-address</c> - The peer address.</para></li><li><para><c>peer-bgp-asn</c> - The peer BGP ASN.</para></li><li><para><c>outpost-lag-id</c> - The Outpost LAG ID.</para></li><li><para><c>configuration-state</c> - The configuration state of the service link virtual
        /// interface.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter OutpostLagId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Outpost LAGs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutpostLagIds")]
        public System.String[] OutpostLagId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <c>nextToken</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OutpostLags'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeOutpostLagsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeOutpostLagsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OutpostLags";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeOutpostLagsResponse, GetEC2OutpostLagCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.OutpostLagId != null)
            {
                context.OutpostLagId = new List<System.String>(this.OutpostLagId);
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
            var request = new Amazon.EC2.Model.DescribeOutpostLagsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.OutpostLagId != null)
            {
                request.OutpostLagIds = cmdletContext.OutpostLagId;
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
        
        private Amazon.EC2.Model.DescribeOutpostLagsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeOutpostLagsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeOutpostLags");
            try
            {
                #if DESKTOP
                return client.DescribeOutpostLags(request);
                #elif CORECLR
                return client.DescribeOutpostLagsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> OutpostLagId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeOutpostLagsResponse, GetEC2OutpostLagCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OutpostLags;
        }
        
    }
}

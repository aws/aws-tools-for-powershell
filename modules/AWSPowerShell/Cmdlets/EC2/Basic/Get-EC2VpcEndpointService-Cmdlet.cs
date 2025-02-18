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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes available services to which you can create a VPC endpoint.
    /// 
    ///  
    /// <para>
    /// When the service provider and the consumer have different accounts in multiple Availability
    /// Zones, and the consumer views the VPC endpoint service information, the response only
    /// includes the common Availability Zones. For example, when the service provider account
    /// uses <c>us-east-1a</c> and <c>us-east-1c</c> and the consumer uses <c>us-east-1a</c>
    /// and <c>us-east-1b</c>, the response includes the VPC endpoint services in the common
    /// Availability Zone, <c>us-east-1a</c>.
    /// </para><br/><br/>In the AWS.Tools.EC2 module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2VpcEndpointService")]
    [OutputType("Amazon.EC2.Model.DescribeVpcEndpointServicesResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeVpcEndpointServices API operation.", Operation = new[] {"DescribeVpcEndpointServices"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeVpcEndpointServicesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.DescribeVpcEndpointServicesResponse",
        "This cmdlet returns an Amazon.EC2.Model.DescribeVpcEndpointServicesResponse object containing multiple properties."
    )]
    public partial class GetEC2VpcEndpointServiceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><c>owner</c> - The ID or alias of the Amazon Web Services account that owns the service.</para></li><li><para><c>service-name</c> - The name of the service.</para></li><li><para><c>service-region</c> - The Region of the service.</para></li><li><para><c>service-type</c> - The type of service (<c>Interface</c> | <c>Gateway</c> | <c>GatewayLoadBalancer</c>).</para></li><li><para><c>supported-ip-address-types</c> - The IP address type (<c>ipv4</c> | <c>ipv6</c>).</para></li><li><para><c>tag</c>:&lt;key&gt; - The key/value combination of a tag assigned to the resource.
        /// Use the tag key in the filter name and the tag value as the filter value. For example,
        /// to find all resources that have a tag with the key <c>Owner</c> and the value <c>TeamA</c>,
        /// specify <c>tag:Owner</c> for the filter name and <c>TeamA</c> for the filter value.</para></li><li><para><c>tag-key</c> - The key of a tag assigned to the resource. Use this filter to find
        /// all resources assigned a tag with a specific key, regardless of the tag value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The service names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceNames")]
        public System.String[] ServiceName { get; set; }
        #endregion
        
        #region Parameter ServiceRegion
        /// <summary>
        /// <para>
        /// <para>The service Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceRegions")]
        public System.String[] ServiceRegion { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this request. The request returns a token
        /// that you can specify in a subsequent call to get the next set of results.</para><para>Constraint: If the value is greater than 1,000, we return only 1,000 items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of items to return. (You received this token from a prior
        /// call.)</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.EC2 module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeVpcEndpointServicesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeVpcEndpointServicesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeVpcEndpointServicesResponse, GetEC2VpcEndpointServiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.ServiceName != null)
            {
                context.ServiceName = new List<System.String>(this.ServiceName);
            }
            if (this.ServiceRegion != null)
            {
                context.ServiceRegion = new List<System.String>(this.ServiceRegion);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeVpcEndpointServicesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceNames = cmdletContext.ServiceName;
            }
            if (cmdletContext.ServiceRegion != null)
            {
                request.ServiceRegions = cmdletContext.ServiceRegion;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
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
                    
                    _nextToken = response.NextToken;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeVpcEndpointServicesRequest();
            
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
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceNames = cmdletContext.ServiceName;
            }
            if (cmdletContext.ServiceRegion != null)
            {
                request.ServiceRegions = cmdletContext.ServiceRegion;
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
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.DescribeVpcEndpointServicesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeVpcEndpointServicesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeVpcEndpointServices");
            try
            {
                return client.DescribeVpcEndpointServicesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ServiceName { get; set; }
            public List<System.String> ServiceRegion { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeVpcEndpointServicesResponse, GetEC2VpcEndpointServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

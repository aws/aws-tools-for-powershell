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
using Amazon.TimestreamQuery;
using Amazon.TimestreamQuery.Model;

namespace Amazon.PowerShell.Cmdlets.TSQ
{
    /// <summary>
    /// DescribeEndpoints returns a list of available endpoints to make Timestream API calls
    /// against. This API is available through both Write and Query.
    /// 
    ///  
    /// <para>
    /// Because the Timestream SDKs are designed to transparently work with the service’s
    /// architecture, including the management and mapping of the service endpoints, <i>it
    /// is not recommended that you use this API unless</i>:
    /// </para><ul><li><para>
    /// You are using <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/VPCEndpoints">VPC
    /// endpoints (Amazon Web Services PrivateLink) with Timestream </a></para></li><li><para>
    /// Your application uses a programming language that does not yet have SDK support
    /// </para></li><li><para>
    /// You require better control over the client-side implementation
    /// </para></li></ul><para>
    /// For detailed information on how and when to use and implement DescribeEndpoints, see
    /// <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/Using.API.html#Using-API.endpoint-discovery">The
    /// Endpoint Discovery Pattern</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "TSQEndpointList")]
    [OutputType("Amazon.TimestreamQuery.Model.Endpoint")]
    [AWSCmdlet("Calls the Amazon Timestream Query DescribeEndpoints API operation.", Operation = new[] {"DescribeEndpoints"}, SelectReturnType = typeof(Amazon.TimestreamQuery.Model.DescribeEndpointsResponse))]
    [AWSCmdletOutput("Amazon.TimestreamQuery.Model.Endpoint or Amazon.TimestreamQuery.Model.DescribeEndpointsResponse",
        "This cmdlet returns a collection of Amazon.TimestreamQuery.Model.Endpoint objects.",
        "The service call response (type Amazon.TimestreamQuery.Model.DescribeEndpointsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetTSQEndpointListCmdlet : AmazonTimestreamQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Endpoints'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamQuery.Model.DescribeEndpointsResponse).
        /// Specifying the name of a property of type Amazon.TimestreamQuery.Model.DescribeEndpointsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Endpoints";
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
                context.Select = CreateSelectDelegate<Amazon.TimestreamQuery.Model.DescribeEndpointsResponse, GetTSQEndpointListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.TimestreamQuery.Model.DescribeEndpointsRequest();
            
            
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
        
        private Amazon.TimestreamQuery.Model.DescribeEndpointsResponse CallAWSServiceOperation(IAmazonTimestreamQuery client, Amazon.TimestreamQuery.Model.DescribeEndpointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream Query", "DescribeEndpoints");
            try
            {
                return client.DescribeEndpointsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.TimestreamQuery.Model.DescribeEndpointsResponse, GetTSQEndpointListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Endpoints;
        }
        
    }
}

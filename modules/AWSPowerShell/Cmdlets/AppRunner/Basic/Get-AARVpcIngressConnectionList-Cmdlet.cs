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
using Amazon.AppRunner;
using Amazon.AppRunner.Model;

namespace Amazon.PowerShell.Cmdlets.AAR
{
    /// <summary>
    /// Return a list of App Runner VPC Ingress Connections in your Amazon Web Services account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "AARVpcIngressConnectionList")]
    [OutputType("Amazon.AppRunner.Model.VpcIngressConnectionSummary")]
    [AWSCmdlet("Calls the AWS App Runner ListVpcIngressConnections API operation.", Operation = new[] {"ListVpcIngressConnections"}, SelectReturnType = typeof(Amazon.AppRunner.Model.ListVpcIngressConnectionsResponse))]
    [AWSCmdletOutput("Amazon.AppRunner.Model.VpcIngressConnectionSummary or Amazon.AppRunner.Model.ListVpcIngressConnectionsResponse",
        "This cmdlet returns a collection of Amazon.AppRunner.Model.VpcIngressConnectionSummary objects.",
        "The service call response (type Amazon.AppRunner.Model.ListVpcIngressConnectionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAARVpcIngressConnectionListCmdlet : AmazonAppRunnerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_ServiceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a service to filter by. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_ServiceArn { get; set; }
        #endregion
        
        #region Parameter Filter_VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of a VPC Endpoint to filter by. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to include in each response (result page). It's used
        /// for a paginated request.</para><para>If you don't specify <c>MaxResults</c>, the request retrieves all available results
        /// in a single response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token from a previous result page. It's used for a paginated request. The request
        /// retrieves the next result page. All other parameter values must be identical to the
        /// ones that are specified in the initial request.</para><para>If you don't specify <c>NextToken</c>, the request retrieves the first result page.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcIngressConnectionSummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRunner.Model.ListVpcIngressConnectionsResponse).
        /// Specifying the name of a property of type Amazon.AppRunner.Model.ListVpcIngressConnectionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcIngressConnectionSummaryList";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
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
                context.Select = CreateSelectDelegate<Amazon.AppRunner.Model.ListVpcIngressConnectionsResponse, GetAARVpcIngressConnectionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter_ServiceArn = this.Filter_ServiceArn;
            context.Filter_VpcEndpointId = this.Filter_VpcEndpointId;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.AppRunner.Model.ListVpcIngressConnectionsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.AppRunner.Model.ListVpcIngressConnectionsFilter();
            System.String requestFilter_filter_ServiceArn = null;
            if (cmdletContext.Filter_ServiceArn != null)
            {
                requestFilter_filter_ServiceArn = cmdletContext.Filter_ServiceArn;
            }
            if (requestFilter_filter_ServiceArn != null)
            {
                request.Filter.ServiceArn = requestFilter_filter_ServiceArn;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_VpcEndpointId = null;
            if (cmdletContext.Filter_VpcEndpointId != null)
            {
                requestFilter_filter_VpcEndpointId = cmdletContext.Filter_VpcEndpointId;
            }
            if (requestFilter_filter_VpcEndpointId != null)
            {
                request.Filter.VpcEndpointId = requestFilter_filter_VpcEndpointId;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.AppRunner.Model.ListVpcIngressConnectionsResponse CallAWSServiceOperation(IAmazonAppRunner client, Amazon.AppRunner.Model.ListVpcIngressConnectionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Runner", "ListVpcIngressConnections");
            try
            {
                #if DESKTOP
                return client.ListVpcIngressConnections(request);
                #elif CORECLR
                return client.ListVpcIngressConnectionsAsync(request).GetAwaiter().GetResult();
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
            public System.String Filter_ServiceArn { get; set; }
            public System.String Filter_VpcEndpointId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.AppRunner.Model.ListVpcIngressConnectionsResponse, GetAARVpcIngressConnectionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcIngressConnectionSummaryList;
        }
        
    }
}

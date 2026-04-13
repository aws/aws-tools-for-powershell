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
using Amazon.Interconnect;
using Amazon.Interconnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INTC
{
    /// <summary>
    /// Lists all connection objects to which the caller has access.
    /// 
    ///  
    /// <para>
    /// Allows for optional filtering by the following properties:
    /// </para><ul><li><para><c>state</c></para></li><li><para><c>environmentId</c></para></li><li><para><c>provider</c></para></li><li><para><c>attach point</c></para></li></ul><para>
    /// Only <a>Connection</a> objects matching all filters will be returned.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "INTCConnectionList")]
    [OutputType("Amazon.Interconnect.Model.ConnectionSummary")]
    [AWSCmdlet("Calls the Interconnect ListConnections API operation.", Operation = new[] {"ListConnections"}, SelectReturnType = typeof(Amazon.Interconnect.Model.ListConnectionsResponse))]
    [AWSCmdletOutput("Amazon.Interconnect.Model.ConnectionSummary or Amazon.Interconnect.Model.ListConnectionsResponse",
        "This cmdlet returns a collection of Amazon.Interconnect.Model.ConnectionSummary objects.",
        "The service call response (type Amazon.Interconnect.Model.ListConnectionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINTCConnectionListCmdlet : AmazonInterconnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttachPoint_Arn
        /// <summary>
        /// <para>
        /// <para>Identifies an attach point by full ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AttachPoint_Arn { get; set; }
        #endregion
        
        #region Parameter Provider_CloudServiceProvider
        /// <summary>
        /// <para>
        /// <para>The provider's name. Specifically, connections to/from this Cloud Service Provider
        /// will be considered Multicloud connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Provider_CloudServiceProvider { get; set; }
        #endregion
        
        #region Parameter AttachPoint_DirectConnectGateway
        /// <summary>
        /// <para>
        /// <para>Identifies an DirectConnect Gateway attach point by DirectConnectGatewayID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AttachPoint_DirectConnectGateway { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>Filter the results to only include <a>Connection</a> objects on the given <a>Environment</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter Provider_LastMileProvider
        /// <summary>
        /// <para>
        /// <para>The provider's name. Specifically, connections to/from this Last Mile Provider will
        /// be considered LastMile connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Provider_LastMileProvider { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>Filter the results to only include <a>Connection</a> objects in the given <a>Connection$state</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Interconnect.ConnectionState")]
        public Amazon.Interconnect.ConnectionState State { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The max number of list results in a single paginated response.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A pagination token from a previous paginated response indicating you wish to get the
        /// next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Connections'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Interconnect.Model.ListConnectionsResponse).
        /// Specifying the name of a property of type Amazon.Interconnect.Model.ListConnectionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Connections";
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
                context.Select = CreateSelectDelegate<Amazon.Interconnect.Model.ListConnectionsResponse, GetINTCConnectionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttachPoint_Arn = this.AttachPoint_Arn;
            context.AttachPoint_DirectConnectGateway = this.AttachPoint_DirectConnectGateway;
            context.EnvironmentId = this.EnvironmentId;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.Provider_CloudServiceProvider = this.Provider_CloudServiceProvider;
            context.Provider_LastMileProvider = this.Provider_LastMileProvider;
            context.State = this.State;
            
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
            var request = new Amazon.Interconnect.Model.ListConnectionsRequest();
            
            
             // populate AttachPoint
            var requestAttachPointIsNull = true;
            request.AttachPoint = new Amazon.Interconnect.Model.AttachPoint();
            System.String requestAttachPoint_attachPoint_Arn = null;
            if (cmdletContext.AttachPoint_Arn != null)
            {
                requestAttachPoint_attachPoint_Arn = cmdletContext.AttachPoint_Arn;
            }
            if (requestAttachPoint_attachPoint_Arn != null)
            {
                request.AttachPoint.Arn = requestAttachPoint_attachPoint_Arn;
                requestAttachPointIsNull = false;
            }
            System.String requestAttachPoint_attachPoint_DirectConnectGateway = null;
            if (cmdletContext.AttachPoint_DirectConnectGateway != null)
            {
                requestAttachPoint_attachPoint_DirectConnectGateway = cmdletContext.AttachPoint_DirectConnectGateway;
            }
            if (requestAttachPoint_attachPoint_DirectConnectGateway != null)
            {
                request.AttachPoint.DirectConnectGateway = requestAttachPoint_attachPoint_DirectConnectGateway;
                requestAttachPointIsNull = false;
            }
             // determine if request.AttachPoint should be set to null
            if (requestAttachPointIsNull)
            {
                request.AttachPoint = null;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate Provider
            var requestProviderIsNull = true;
            request.Provider = new Amazon.Interconnect.Model.Provider();
            System.String requestProvider_provider_CloudServiceProvider = null;
            if (cmdletContext.Provider_CloudServiceProvider != null)
            {
                requestProvider_provider_CloudServiceProvider = cmdletContext.Provider_CloudServiceProvider;
            }
            if (requestProvider_provider_CloudServiceProvider != null)
            {
                request.Provider.CloudServiceProvider = requestProvider_provider_CloudServiceProvider;
                requestProviderIsNull = false;
            }
            System.String requestProvider_provider_LastMileProvider = null;
            if (cmdletContext.Provider_LastMileProvider != null)
            {
                requestProvider_provider_LastMileProvider = cmdletContext.Provider_LastMileProvider;
            }
            if (requestProvider_provider_LastMileProvider != null)
            {
                request.Provider.LastMileProvider = requestProvider_provider_LastMileProvider;
                requestProviderIsNull = false;
            }
             // determine if request.Provider should be set to null
            if (requestProviderIsNull)
            {
                request.Provider = null;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
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
        
        private Amazon.Interconnect.Model.ListConnectionsResponse CallAWSServiceOperation(IAmazonInterconnect client, Amazon.Interconnect.Model.ListConnectionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Interconnect", "ListConnections");
            try
            {
                return client.ListConnectionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AttachPoint_Arn { get; set; }
            public System.String AttachPoint_DirectConnectGateway { get; set; }
            public System.String EnvironmentId { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Provider_CloudServiceProvider { get; set; }
            public System.String Provider_LastMileProvider { get; set; }
            public Amazon.Interconnect.ConnectionState State { get; set; }
            public System.Func<Amazon.Interconnect.Model.ListConnectionsResponse, GetINTCConnectionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Connections;
        }
        
    }
}

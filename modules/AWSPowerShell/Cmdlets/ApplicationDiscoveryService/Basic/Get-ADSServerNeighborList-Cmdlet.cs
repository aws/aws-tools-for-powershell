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
using Amazon.ApplicationDiscoveryService;
using Amazon.ApplicationDiscoveryService.Model;

namespace Amazon.PowerShell.Cmdlets.ADS
{
    /// <summary>
    /// Retrieves a list of servers that are one network hop away from a specified server.<br/><br/>In the AWS.Tools.ApplicationDiscoveryService module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ADSServerNeighborList")]
    [OutputType("Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse")]
    [AWSCmdlet("Calls the AWS Application Discovery Service ListServerNeighbors API operation.", Operation = new[] {"ListServerNeighbors"}, SelectReturnType = typeof(Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse))]
    [AWSCmdletOutput("Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse",
        "This cmdlet returns an Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse object containing multiple properties."
    )]
    public partial class GetADSServerNeighborListCmdlet : AmazonApplicationDiscoveryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationId
        /// <summary>
        /// <para>
        /// <para>Configuration ID of the server for which neighbors are being listed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ConfigurationId { get; set; }
        #endregion
        
        #region Parameter NeighborConfigurationId
        /// <summary>
        /// <para>
        /// <para>List of configuration IDs to test for one-hop-away.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NeighborConfigurationIds")]
        public System.String[] NeighborConfigurationId { get; set; }
        #endregion
        
        #region Parameter PortInformationNeeded
        /// <summary>
        /// <para>
        /// <para>Flag to indicate if port and protocol information is needed as part of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PortInformationNeeded { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of results to return in a single page of output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Token to retrieve the next set of results. For example, if you previously specified
        /// 100 IDs for <c>ListServerNeighborsRequest$neighborConfigurationIds</c> but set <c>ListServerNeighborsRequest$maxResults</c>
        /// to 10, you received a set of 10 results along with a token. Use that token in this
        /// query to get the next set of 10.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.ApplicationDiscoveryService module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse).
        /// Specifying the name of a property of type Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse, GetADSServerNeighborListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationId = this.ConfigurationId;
            #if MODULAR
            if (this.ConfigurationId == null && ParameterWasBound(nameof(this.ConfigurationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            if (this.NeighborConfigurationId != null)
            {
                context.NeighborConfigurationId = new List<System.String>(this.NeighborConfigurationId);
            }
            context.NextToken = this.NextToken;
            context.PortInformationNeeded = this.PortInformationNeeded;
            
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
            var request = new Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsRequest();
            
            if (cmdletContext.ConfigurationId != null)
            {
                request.ConfigurationId = cmdletContext.ConfigurationId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NeighborConfigurationId != null)
            {
                request.NeighborConfigurationIds = cmdletContext.NeighborConfigurationId;
            }
            if (cmdletContext.PortInformationNeeded != null)
            {
                request.PortInformationNeeded = cmdletContext.PortInformationNeeded.Value;
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
            var request = new Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsRequest();
            
            if (cmdletContext.ConfigurationId != null)
            {
                request.ConfigurationId = cmdletContext.ConfigurationId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NeighborConfigurationId != null)
            {
                request.NeighborConfigurationIds = cmdletContext.NeighborConfigurationId;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PortInformationNeeded != null)
            {
                request.PortInformationNeeded = cmdletContext.PortInformationNeeded.Value;
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
        
        private Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse CallAWSServiceOperation(IAmazonApplicationDiscoveryService client, Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Application Discovery Service", "ListServerNeighbors");
            try
            {
                return client.ListServerNeighborsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigurationId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public List<System.String> NeighborConfigurationId { get; set; }
            public System.String NextToken { get; set; }
            public System.Boolean? PortInformationNeeded { get; set; }
            public System.Func<Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse, GetADSServerNeighborListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

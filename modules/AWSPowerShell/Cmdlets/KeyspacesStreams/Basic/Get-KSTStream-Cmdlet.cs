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
using Amazon.KeyspacesStreams;
using Amazon.KeyspacesStreams.Model;

namespace Amazon.PowerShell.Cmdlets.KST
{
    /// <summary>
    /// Returns detailed information about a specific data capture stream for an Amazon Keyspaces
    /// table. The information includes the stream's Amazon Resource Name (ARN), creation
    /// time, current status, retention period, shard composition, and associated table details.
    /// This operation helps you monitor and manage the configuration of your Amazon Keyspaces
    /// data streams.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "KSTStream")]
    [OutputType("Amazon.KeyspacesStreams.Model.GetStreamResponse")]
    [AWSCmdlet("Calls the Amazon Keyspaces Streams GetStream API operation.", Operation = new[] {"GetStream"}, SelectReturnType = typeof(Amazon.KeyspacesStreams.Model.GetStreamResponse))]
    [AWSCmdletOutput("Amazon.KeyspacesStreams.Model.GetStreamResponse",
        "This cmdlet returns an Amazon.KeyspacesStreams.Model.GetStreamResponse object containing multiple properties."
    )]
    public partial class GetKSTStreamCmdlet : AmazonKeyspacesStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ShardFilter_ShardId
        /// <summary>
        /// <para>
        /// <para>The identifier of a specific shard used to filter results based on the specified filter
        /// type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShardFilter_ShardId { get; set; }
        #endregion
        
        #region Parameter StreamArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the stream for which detailed information is requested.
        /// This uniquely identifies the specific stream you want to get information about. </para>
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
        public System.String StreamArn { get; set; }
        #endregion
        
        #region Parameter ShardFilter_Type
        /// <summary>
        /// <para>
        /// <para>The type of shard filter to use, which determines how the shardId parameter is interpreted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyspacesStreams.ShardFilterType")]
        public Amazon.KeyspacesStreams.ShardFilterType ShardFilter_Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of shard objects to return in a single <c>GetStream</c> request.
        /// Default value is 100. The minimum value is 1 and the maximum value is 1000. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> An optional pagination token provided by a previous <c>GetStream</c> operation. If
        /// this parameter is specified, the response includes only records beyond the token,
        /// up to the value specified by <c>maxResults</c>. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyspacesStreams.Model.GetStreamResponse).
        /// Specifying the name of a property of type Amazon.KeyspacesStreams.Model.GetStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StreamArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StreamArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StreamArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyspacesStreams.Model.GetStreamResponse, GetKSTStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StreamArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ShardFilter_ShardId = this.ShardFilter_ShardId;
            context.ShardFilter_Type = this.ShardFilter_Type;
            context.StreamArn = this.StreamArn;
            #if MODULAR
            if (this.StreamArn == null && ParameterWasBound(nameof(this.StreamArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.KeyspacesStreams.Model.GetStreamRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate ShardFilter
            var requestShardFilterIsNull = true;
            request.ShardFilter = new Amazon.KeyspacesStreams.Model.ShardFilter();
            System.String requestShardFilter_shardFilter_ShardId = null;
            if (cmdletContext.ShardFilter_ShardId != null)
            {
                requestShardFilter_shardFilter_ShardId = cmdletContext.ShardFilter_ShardId;
            }
            if (requestShardFilter_shardFilter_ShardId != null)
            {
                request.ShardFilter.ShardId = requestShardFilter_shardFilter_ShardId;
                requestShardFilterIsNull = false;
            }
            Amazon.KeyspacesStreams.ShardFilterType requestShardFilter_shardFilter_Type = null;
            if (cmdletContext.ShardFilter_Type != null)
            {
                requestShardFilter_shardFilter_Type = cmdletContext.ShardFilter_Type;
            }
            if (requestShardFilter_shardFilter_Type != null)
            {
                request.ShardFilter.Type = requestShardFilter_shardFilter_Type;
                requestShardFilterIsNull = false;
            }
             // determine if request.ShardFilter should be set to null
            if (requestShardFilterIsNull)
            {
                request.ShardFilter = null;
            }
            if (cmdletContext.StreamArn != null)
            {
                request.StreamArn = cmdletContext.StreamArn;
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
        
        private Amazon.KeyspacesStreams.Model.GetStreamResponse CallAWSServiceOperation(IAmazonKeyspacesStreams client, Amazon.KeyspacesStreams.Model.GetStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Keyspaces Streams", "GetStream");
            try
            {
                #if DESKTOP
                return client.GetStream(request);
                #elif CORECLR
                return client.GetStreamAsync(request).GetAwaiter().GetResult();
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
            public System.String ShardFilter_ShardId { get; set; }
            public Amazon.KeyspacesStreams.ShardFilterType ShardFilter_Type { get; set; }
            public System.String StreamArn { get; set; }
            public System.Func<Amazon.KeyspacesStreams.Model.GetStreamResponse, GetKSTStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

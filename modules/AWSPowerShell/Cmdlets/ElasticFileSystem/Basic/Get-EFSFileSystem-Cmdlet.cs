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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Returns the description of a specific Amazon EFS file system if either the file system
    /// <c>CreationToken</c> or the <c>FileSystemId</c> is provided. Otherwise, it returns
    /// descriptions of all file systems owned by the caller's Amazon Web Services account
    /// in the Amazon Web Services Region of the endpoint that you're calling.
    /// 
    ///  
    /// <para>
    /// When retrieving all file system descriptions, you can optionally specify the <c>MaxItems</c>
    /// parameter to limit the number of descriptions in a response. This number is automatically
    /// set to 100. If more file system descriptions remain, Amazon EFS returns a <c>NextMarker</c>,
    /// an opaque token, in the response. In this case, you should send a subsequent request
    /// with the <c>Marker</c> request parameter set to the value of <c>NextMarker</c>. 
    /// </para><para>
    /// To retrieve a list of your file system descriptions, this operation is used in an
    /// iterative process, where <c>DescribeFileSystems</c> is called first without the <c>Marker</c>
    /// and then the operation continues to call it with the <c>Marker</c> parameter set to
    /// the value of the <c>NextMarker</c> from the previous response until the response has
    /// no <c>NextMarker</c>. 
    /// </para><para>
    ///  The order of file systems returned in the response of one <c>DescribeFileSystems</c>
    /// call and the order of file systems returned across the responses of a multi-call iteration
    /// is unspecified. 
    /// </para><para>
    ///  This operation requires permissions for the <c>elasticfilesystem:DescribeFileSystems</c>
    /// action. 
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EFSFileSystem")]
    [OutputType("Amazon.ElasticFileSystem.Model.FileSystemDescription")]
    [AWSCmdlet("Calls the Amazon Elastic File System DescribeFileSystems API operation.", Operation = new[] {"DescribeFileSystems"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.DescribeFileSystemsResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.FileSystemDescription or Amazon.ElasticFileSystem.Model.DescribeFileSystemsResponse",
        "This cmdlet returns a collection of Amazon.ElasticFileSystem.Model.FileSystemDescription objects.",
        "The service call response (type Amazon.ElasticFileSystem.Model.DescribeFileSystemsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEFSFileSystemCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreationToken
        /// <summary>
        /// <para>
        /// <para>(Optional) Restricts the list to the file system with this creation token (String).
        /// You specify a creation token when you create an Amazon EFS file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreationToken { get; set; }
        #endregion
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>(Optional) ID of the file system whose description you want to retrieve (String).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>(Optional) Opaque pagination token returned from a previous <c>DescribeFileSystems</c>
        /// operation (String). If present, specifies to continue the list from where the returning
        /// call had left off. </para>
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
        /// <para>(Optional) Specifies the maximum number of file systems to return in the response
        /// (integer). This number is automatically set to 100. The response is paginated at 100
        /// per page if you have more than 100 file systems. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FileSystems'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.DescribeFileSystemsResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.DescribeFileSystemsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FileSystems";
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
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.DescribeFileSystemsResponse, GetEFSFileSystemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreationToken = this.CreationToken;
            context.FileSystemId = this.FileSystemId;
            context.Marker = this.Marker;
            context.MaxItem = this.MaxItem;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxItem)) && this.MaxItem.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxItem parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxItem" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            
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
            var request = new Amazon.ElasticFileSystem.Model.DescribeFileSystemsRequest();
            
            if (cmdletContext.CreationToken != null)
            {
                request.CreationToken = cmdletContext.CreationToken;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxItem.Value);
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ElasticFileSystem.Model.DescribeFileSystemsRequest();
            if (cmdletContext.CreationToken != null)
            {
                request.CreationToken = cmdletContext.CreationToken;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextToken = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItem.HasValue)
            {
                _emitLimit = cmdletContext.MaxItem;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                }
                
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
                    int _receivedThisCall = response.FileSystems?.Count ?? 0;
                    
                    _nextToken = response.NextMarker;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ElasticFileSystem.Model.DescribeFileSystemsResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.DescribeFileSystemsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "DescribeFileSystems");
            try
            {
                return client.DescribeFileSystemsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CreationToken { get; set; }
            public System.String FileSystemId { get; set; }
            public System.String Marker { get; set; }
            public int? MaxItem { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.DescribeFileSystemsResponse, GetEFSFileSystemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileSystems;
        }
        
    }
}

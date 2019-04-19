/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Returns the description of a specific Amazon EFS file system if either the file system
    /// <code>CreationToken</code> or the <code>FileSystemId</code> is provided. Otherwise,
    /// it returns descriptions of all file systems owned by the caller's AWS account in the
    /// AWS Region of the endpoint that you're calling.
    /// 
    ///  
    /// <para>
    /// When retrieving all file system descriptions, you can optionally specify the <code>MaxItems</code>
    /// parameter to limit the number of descriptions in a response. Currently, this number
    /// is automatically set to 10. If more file system descriptions remain, Amazon EFS returns
    /// a <code>NextMarker</code>, an opaque token, in the response. In this case, you should
    /// send a subsequent request with the <code>Marker</code> request parameter set to the
    /// value of <code>NextMarker</code>. 
    /// </para><para>
    /// To retrieve a list of your file system descriptions, this operation is used in an
    /// iterative process, where <code>DescribeFileSystems</code> is called first without
    /// the <code>Marker</code> and then the operation continues to call it with the <code>Marker</code>
    /// parameter set to the value of the <code>NextMarker</code> from the previous response
    /// until the response has no <code>NextMarker</code>. 
    /// </para><para>
    ///  The order of file systems returned in the response of one <code>DescribeFileSystems</code>
    /// call and the order of file systems returned across the responses of a multi-call iteration
    /// is unspecified. 
    /// </para><para>
    ///  This operation requires permissions for the <code>elasticfilesystem:DescribeFileSystems</code>
    /// action. 
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "EFSFileSystem")]
    [OutputType("Amazon.ElasticFileSystem.Model.FileSystemDescription")]
    [AWSCmdlet("Calls the Amazon Elastic File System DescribeFileSystems API operation.", Operation = new[] {"DescribeFileSystems"})]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.FileSystemDescription",
        "This cmdlet returns a collection of FileSystemDescription objects.",
        "The service call response (type Amazon.ElasticFileSystem.Model.DescribeFileSystemsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type System.String), NextMarker (type System.String)"
    )]
    public partial class GetEFSFileSystemCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        #region Parameter CreationToken
        /// <summary>
        /// <para>
        /// <para>(Optional) Restricts the list to the file system with this creation token (String).
        /// You specify a creation token when you create an Amazon EFS file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CreationToken { get; set; }
        #endregion
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>(Optional) ID of the file system whose description you want to retrieve (String).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>(Optional) Opaque pagination token returned from a previous <code>DescribeFileSystems</code>
        /// operation (String). If present, specifies to continue the list from where the returning
        /// call had left off. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextMarker, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies the maximum number of file systems to return in the response
        /// (integer). Currently, this number is automatically set to 10. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CreationToken = this.CreationToken;
            context.FileSystemId = this.FileSystemId;
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
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
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxItems))
            {
                _emitLimit = cmdletContext.MaxItems;
            }
            bool _userControllingPaging = ParameterWasBound("Marker");
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    if (_emitLimit.HasValue)
                    {
                        request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.FileSystems;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        notes["NextMarker"] = response.NextMarker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.FileSystems.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.NextMarker;
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
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
                
            }
            finally
            {
            }
            
            return null;
        }
        
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
                #if DESKTOP
                return client.DescribeFileSystems(request);
                #elif CORECLR
                return client.DescribeFileSystemsAsync(request).GetAwaiter().GetResult();
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
            public System.String CreationToken { get; set; }
            public System.String FileSystemId { get; set; }
            public System.String Marker { get; set; }
            public int? MaxItems { get; set; }
        }
        
    }
}

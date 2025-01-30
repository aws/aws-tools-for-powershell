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
using Amazon.Glacier;
using Amazon.Glacier.Model;

namespace Amazon.PowerShell.Cmdlets.GLC
{
    /// <summary>
    /// This operation lists in-progress multipart uploads for the specified vault. An in-progress
    /// multipart upload is a multipart upload that has been initiated by an <a>InitiateMultipartUpload</a>
    /// request, but has not yet been completed or aborted. The list returned in the List
    /// Multipart Upload response has no guaranteed order. 
    /// 
    ///  
    /// <para>
    /// The List Multipart Uploads operation supports pagination. By default, this operation
    /// returns up to 50 multipart uploads in the response. You should always check the response
    /// for a <c>marker</c> at which to continue the list; if there are no more items the
    /// <c>marker</c> is <c>null</c>. To return a list of multipart uploads that begins at
    /// a specific upload, set the <c>marker</c> request parameter to the value you obtained
    /// from a previous List Multipart Upload request. You can also limit the number of uploads
    /// returned in the response by specifying the <c>limit</c> parameter in the request.
    /// </para><para>
    /// Note the difference between this operation and listing parts (<a>ListParts</a>). The
    /// List Multipart Uploads operation lists all multipart uploads for a vault and does
    /// not require a multipart upload ID. The List Parts operation requires a multipart upload
    /// ID since parts are associated with a single upload.
    /// </para><para>
    /// An AWS account has full permission to perform all operations (actions). However, AWS
    /// Identity and Access Management (IAM) users don't have any permissions by default.
    /// You must grant them explicit permission to perform specific actions. For more information,
    /// see <a href="https://docs.aws.amazon.com/amazonglacier/latest/dev/using-iam-with-amazon-glacier.html">Access
    /// Control Using AWS Identity and Access Management (IAM)</a>.
    /// </para><para>
    /// For conceptual information and the underlying REST API, see <a href="https://docs.aws.amazon.com/amazonglacier/latest/dev/working-with-archives.html">Working
    /// with Archives in Amazon S3 Glacier</a> and <a href="https://docs.aws.amazon.com/amazonglacier/latest/dev/api-multipart-list-uploads.html">List
    /// Multipart Uploads </a> in the <i>Amazon Glacier Developer Guide</i>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLCMultipartUploadList")]
    [OutputType("Amazon.Glacier.Model.UploadListElement")]
    [AWSCmdlet("Calls the Amazon Glacier ListMultipartUploads API operation.", Operation = new[] {"ListMultipartUploads"}, SelectReturnType = typeof(Amazon.Glacier.Model.ListMultipartUploadsResponse))]
    [AWSCmdletOutput("Amazon.Glacier.Model.UploadListElement or Amazon.Glacier.Model.ListMultipartUploadsResponse",
        "This cmdlet returns a collection of Amazon.Glacier.Model.UploadListElement objects.",
        "The service call response (type Amazon.Glacier.Model.ListMultipartUploadsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGLCMultipartUploadListCmdlet : AmazonGlacierClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The <c>AccountId</c> value is the AWS account ID of the account that owns the vault.
        /// You can either specify an AWS account ID or optionally a single '<c>-</c>' (hyphen),
        /// in which case Amazon S3 Glacier uses the AWS account ID associated with the credentials
        /// used to sign the request. If you use an account ID, do not include any hyphens ('-')
        /// in the ID. </para>
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>-</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter VaultName
        /// <summary>
        /// <para>
        /// <para>The name of the vault.</para>
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
        public System.String VaultName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of uploads returned in the response body. If this value
        /// is not specified, the List Uploads operation returns up to 50 uploads.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>50</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? Limit { get; set; }
        #endregion
        
        #region Parameter UploadIdMarker
        /// <summary>
        /// <para>
        /// <para>An opaque string used for pagination. This value specifies the upload at which the
        /// listing of uploads should begin. Get the marker value from a previous List Uploads
        /// response. You need only include the marker if you are continuing the pagination of
        /// results started in a previous List Uploads request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'UploadIdMarker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-UploadIdMarker' to null for the first call then set the 'UploadIdMarker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String UploadIdMarker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UploadsList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glacier.Model.ListMultipartUploadsResponse).
        /// Specifying the name of a property of type Amazon.Glacier.Model.ListMultipartUploadsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UploadsList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VaultName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VaultName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VaultName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of UploadIdMarker
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
                context.Select = CreateSelectDelegate<Amazon.Glacier.Model.ListMultipartUploadsResponse, GetGLCMultipartUploadListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VaultName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            if (!ParameterWasBound(nameof(this.AccountId)))
            {
                WriteVerbose("AccountId parameter unset, using default value of '-'");
                context.AccountId = "-";
            }
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Limit = this.Limit;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.Limit)))
            {
                WriteVerbose("Limit parameter unset, using default value of '50'");
                context.Limit = 50;
            }
            #endif
            #if !MODULAR
            if (ParameterWasBound(nameof(this.Limit)) && this.Limit.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the Limit parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing Limit" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.UploadIdMarker = this.UploadIdMarker;
            context.VaultName = this.VaultName;
            #if MODULAR
            if (this.VaultName == null && ParameterWasBound(nameof(this.VaultName)))
            {
                WriteWarning("You are passing $null as a value for parameter VaultName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Glacier.Model.ListMultipartUploadsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.VaultName != null)
            {
                request.VaultName = cmdletContext.VaultName;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.UploadIdMarker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.UploadIdMarker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.UploadIdMarker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.Glacier.Model.ListMultipartUploadsRequest();
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.VaultName != null)
            {
                request.VaultName = cmdletContext.VaultName;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.UploadIdMarker))
            {
                _nextToken = cmdletContext.UploadIdMarker;
            }
            if (cmdletContext.Limit.HasValue)
            {
                // The service has a maximum page size of 50. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 50 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.Limit;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.UploadIdMarker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.UploadIdMarker = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(50, _emitLimit.Value);
                    request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.Limit)))
                {
                    request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(50);
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
                    int _receivedThisCall = response.UploadsList.Count;
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.Glacier.Model.ListMultipartUploadsResponse CallAWSServiceOperation(IAmazonGlacier client, Amazon.Glacier.Model.ListMultipartUploadsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Glacier", "ListMultipartUploads");
            try
            {
                #if DESKTOP
                return client.ListMultipartUploads(request);
                #elif CORECLR
                return client.ListMultipartUploadsAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public int? Limit { get; set; }
            public System.String UploadIdMarker { get; set; }
            public System.String VaultName { get; set; }
            public System.Func<Amazon.Glacier.Model.ListMultipartUploadsResponse, GetGLCMultipartUploadListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UploadsList;
        }
        
    }
}

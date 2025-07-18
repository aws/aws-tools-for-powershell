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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Retrieve information about one or more parameters under a specified level in a hierarchy.
    /// 
    /// 
    ///  
    /// <para>
    /// Request results are returned on a best-effort basis. If you specify <c>MaxResults</c>
    /// in the request, the response includes information up to the limit specified. The number
    /// of items returned, however, can be between zero and the value of <c>MaxResults</c>.
    /// If the service reaches an internal limit while processing the results, it stops the
    /// operation and returns the matching values up to that point and a <c>NextToken</c>.
    /// You can specify the <c>NextToken</c> in a subsequent call to get the next set of results.
    /// </para><para>
    /// Parameter names can't contain spaces. The service removes any spaces specified for
    /// the beginning or end of a parameter name. If the specified name for a parameter contains
    /// spaces between characters, the request fails with a <c>ValidationException</c> error.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SSMParametersByPath")]
    [OutputType("Amazon.SimpleSystemsManagement.Model.Parameter")]
    [AWSCmdlet("Calls the AWS Systems Manager GetParametersByPath API operation.", Operation = new[] {"GetParametersByPath"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.GetParametersByPathResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.Parameter or Amazon.SimpleSystemsManagement.Model.GetParametersByPathResponse",
        "This cmdlet returns a collection of Amazon.SimpleSystemsManagement.Model.Parameter objects.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.GetParametersByPathResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSMParametersByPathCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ParameterFilter
        /// <summary>
        /// <para>
        /// <para>Filters to limit the request results.</para><note><para>The following <c>Key</c> values are supported for <c>GetParametersByPath</c>: <c>Type</c>,
        /// <c>KeyId</c>, and <c>Label</c>.</para><para>The following <c>Key</c> values aren't supported for <c>GetParametersByPath</c>: <c>tag</c>,
        /// <c>DataType</c>, <c>Name</c>, <c>Path</c>, and <c>Tier</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParameterFilters")]
        public Amazon.SimpleSystemsManagement.Model.ParameterStringFilter[] ParameterFilter { get; set; }
        #endregion
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>The hierarchy for the parameter. Hierarchies start with a forward slash (/). The hierarchy
        /// is the parameter name except the last part of the parameter. For the API call to succeed,
        /// the last part of the parameter name can't be in the path. A parameter name hierarchy
        /// can have a maximum of 15 levels. Here is an example of a hierarchy: <c>/Finance/Prod/IAD/WinServ2016/license33
        /// </c></para>
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
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter Recursive
        /// <summary>
        /// <para>
        /// <para>Retrieve all parameters within a hierarchy.</para><important><para>If a user has access to a path, then the user can access all levels of that path.
        /// For example, if a user has permission to access path <c>/a</c>, then the user can
        /// also access <c>/a/b</c>. Even if a user has explicitly been denied access in IAM for
        /// parameter <c>/a/b</c>, they can still call the GetParametersByPath API operation recursively
        /// for <c>/a</c> and view <c>/a/b</c>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Recursive { get; set; }
        #endregion
        
        #region Parameter WithDecryption
        /// <summary>
        /// <para>
        /// <para>Retrieve all parameters in a hierarchy with their value decrypted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? WithDecryption { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this call. The call also returns a token
        /// that you can specify in a subsequent call to get the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>10</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to start the list. Use this token to get the next set of results. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Parameters'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.GetParametersByPathResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.GetParametersByPathResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Parameters";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Path parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Path' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Path' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.GetParametersByPathResponse, GetSSMParametersByPathCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Path;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxResult)))
            {
                WriteVerbose("MaxResult parameter unset, using default value of '10'");
                context.MaxResult = 10;
            }
            #endif
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
            if (this.ParameterFilter != null)
            {
                context.ParameterFilter = new List<Amazon.SimpleSystemsManagement.Model.ParameterStringFilter>(this.ParameterFilter);
            }
            context.Path = this.Path;
            #if MODULAR
            if (this.Path == null && ParameterWasBound(nameof(this.Path)))
            {
                WriteWarning("You are passing $null as a value for parameter Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Recursive = this.Recursive;
            context.WithDecryption = this.WithDecryption;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.GetParametersByPathRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.ParameterFilter != null)
            {
                request.ParameterFilters = cmdletContext.ParameterFilter;
            }
            if (cmdletContext.Path != null)
            {
                request.Path = cmdletContext.Path;
            }
            if (cmdletContext.Recursive != null)
            {
                request.Recursive = cmdletContext.Recursive.Value;
            }
            if (cmdletContext.WithDecryption != null)
            {
                request.WithDecryption = cmdletContext.WithDecryption.Value;
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
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.SimpleSystemsManagement.Model.GetParametersByPathRequest();
            if (cmdletContext.ParameterFilter != null)
            {
                request.ParameterFilters = cmdletContext.ParameterFilter;
            }
            if (cmdletContext.Path != null)
            {
                request.Path = cmdletContext.Path;
            }
            if (cmdletContext.Recursive != null)
            {
                request.Recursive = cmdletContext.Recursive.Value;
            }
            if (cmdletContext.WithDecryption != null)
            {
                request.WithDecryption = cmdletContext.WithDecryption.Value;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 10. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 10 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(10, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.MaxResult)))
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(10);
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
                    int _receivedThisCall = response.Parameters.Count;
                    
                    _nextToken = response.NextToken;
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
        
        private Amazon.SimpleSystemsManagement.Model.GetParametersByPathResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.GetParametersByPathRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "GetParametersByPath");
            try
            {
                #if DESKTOP
                return client.GetParametersByPath(request);
                #elif CORECLR
                return client.GetParametersByPathAsync(request).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.ParameterStringFilter> ParameterFilter { get; set; }
            public System.String Path { get; set; }
            public System.Boolean? Recursive { get; set; }
            public System.Boolean? WithDecryption { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.GetParametersByPathResponse, GetSSMParametersByPathCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Parameters;
        }
        
    }
}

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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Returns the list of domains registered in the account. The results may be split into
    /// multiple pages. To retrieve subsequent pages, make the call again using the nextPageToken
    /// returned by the initial call.
    /// 
    ///  <note><para>
    /// This operation is eventually consistent. The results are best effort and may not exactly
    /// reflect recent updates and changes.
    /// </para></note><para><b>Access Control</b></para><para>
    /// You can use IAM policies to control this action's access to Amazon SWF resources as
    /// follows:
    /// </para><ul><li><para>
    /// Use a <c>Resource</c> element with the domain name to limit the action to only specified
    /// domains. The element must be set to <c>arn:aws:swf::AccountID:domain/*</c>, where
    /// <i>AccountID</i> is the account ID, with no dashes.
    /// </para></li><li><para>
    /// Use an <c>Action</c> element to allow or deny permission to call this action.
    /// </para></li><li><para>
    /// You cannot use an IAM policy to constrain this action's parameters.
    /// </para></li></ul><para>
    /// If the caller doesn't have sufficient permissions to invoke the action, or the parameter
    /// values fall outside the specified constraints, the action fails. The associated event
    /// attribute's <c>cause</c> parameter is set to <c>OPERATION_NOT_PERMITTED</c>. For details
    /// and example IAM policies, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/swf-dev-iam.html">Using
    /// IAM to Manage Access to Amazon SWF Workflows</a> in the <i>Amazon SWF Developer Guide</i>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SWFDomainList")]
    [OutputType("Amazon.SimpleWorkflow.Model.DomainInfo")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service (SWF) ListDomains API operation.", Operation = new[] {"ListDomains"}, SelectReturnType = typeof(Amazon.SimpleWorkflow.Model.ListDomainsResponse))]
    [AWSCmdletOutput("Amazon.SimpleWorkflow.Model.DomainInfo or Amazon.SimpleWorkflow.Model.ListDomainsResponse",
        "This cmdlet returns a collection of Amazon.SimpleWorkflow.Model.DomainInfo objects.",
        "The service call response (type Amazon.SimpleWorkflow.Model.ListDomainsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSWFDomainListCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RegistrationStatus
        /// <summary>
        /// <para>
        /// <para>Specifies the registration status of the domains to list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleWorkflow.RegistrationStatus")]
        public Amazon.SimpleWorkflow.RegistrationStatus RegistrationStatus { get; set; }
        #endregion
        
        #region Parameter ReverseOrder
        /// <summary>
        /// <para>
        /// <para>When set to <c>true</c>, returns the results in reverse order. By default, the results
        /// are returned in ascending alphabetical order by <c>name</c> of the domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReverseOrder { get; set; }
        #endregion
        
        #region Parameter MaximumPageSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of results that are returned per call. Use <c>nextPageToken</c>
        /// to obtain further pages of results. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? MaximumPageSize { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>If <c>NextPageToken</c> is returned there are more results available. The value of
        /// <c>NextPageToken</c> is a unique pagination token for each page. Make the call again
        /// using the returned token to retrieve the next page. Keep all other arguments unchanged.
        /// Each pagination token expires after 24 hours. Using an expired pagination token will
        /// return a <c>400</c> error: "<c>Specified token has exceeded its maximum lifetime</c>".
        /// </para><para>The configured <c>maximumPageSize</c> determines how many results can be returned
        /// in a single call. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextPageToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextPageToken' to null for the first call then set the 'NextPageToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String NextPageToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DomainInfos.Infos'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleWorkflow.Model.ListDomainsResponse).
        /// Specifying the name of a property of type Amazon.SimpleWorkflow.Model.ListDomainsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DomainInfos.Infos";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextPageToken
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
                context.Select = CreateSelectDelegate<Amazon.SimpleWorkflow.Model.ListDomainsResponse, GetSWFDomainListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaximumPageSize = this.MaximumPageSize;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaximumPageSize)) && this.MaximumPageSize.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaximumPageSize parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaximumPageSize" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextPageToken = this.NextPageToken;
            context.RegistrationStatus = this.RegistrationStatus;
            #if MODULAR
            if (this.RegistrationStatus == null && ParameterWasBound(nameof(this.RegistrationStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter RegistrationStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReverseOrder = this.ReverseOrder;
            
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
            var request = new Amazon.SimpleWorkflow.Model.ListDomainsRequest();
            
            if (cmdletContext.MaximumPageSize != null)
            {
                request.MaximumPageSize = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaximumPageSize.Value);
            }
            if (cmdletContext.RegistrationStatus != null)
            {
                request.RegistrationStatus = cmdletContext.RegistrationStatus;
            }
            if (cmdletContext.ReverseOrder != null)
            {
                request.ReverseOrder = cmdletContext.ReverseOrder.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextPageToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextPageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextPageToken = _nextToken;
                
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
                    
                    _nextToken = response.DomainInfos.NextPageToken;
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
            var request = new Amazon.SimpleWorkflow.Model.ListDomainsRequest();
            if (cmdletContext.RegistrationStatus != null)
            {
                request.RegistrationStatus = cmdletContext.RegistrationStatus;
            }
            if (cmdletContext.ReverseOrder != null)
            {
                request.ReverseOrder = cmdletContext.ReverseOrder.Value;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextPageToken))
            {
                _nextToken = cmdletContext.NextPageToken;
            }
            if (cmdletContext.MaximumPageSize.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaximumPageSize;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextPageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextPageToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaximumPageSize = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
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
                    int _receivedThisCall = response.DomainInfos.Infos.Count;
                    
                    _nextToken = response.DomainInfos.NextPageToken;
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
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 0));
            
            
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
        
        private Amazon.SimpleWorkflow.Model.ListDomainsResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.ListDomainsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service (SWF)", "ListDomains");
            try
            {
                #if DESKTOP
                return client.ListDomains(request);
                #elif CORECLR
                return client.ListDomainsAsync(request).GetAwaiter().GetResult();
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
            public int? MaximumPageSize { get; set; }
            public System.String NextPageToken { get; set; }
            public Amazon.SimpleWorkflow.RegistrationStatus RegistrationStatus { get; set; }
            public System.Boolean? ReverseOrder { get; set; }
            public System.Func<Amazon.SimpleWorkflow.Model.ListDomainsResponse, GetSWFDomainListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DomainInfos.Infos;
        }
        
    }
}

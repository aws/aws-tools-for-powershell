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
using Amazon.Mgn;
using Amazon.Mgn.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Lists the invocations of a source action job, one for each source server and source
    /// action, with optional filtering.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "MGNRemoteSourceActionInvocationList")]
    [OutputType("Amazon.Mgn.Model.RemoteSourceActionInvocation")]
    [AWSCmdlet("Calls the Application Migration Service ListRemoteSourceActionInvocations API operation.", Operation = new[] {"ListRemoteSourceActionInvocations"}, SelectReturnType = typeof(Amazon.Mgn.Model.ListRemoteSourceActionInvocationsResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.RemoteSourceActionInvocation or Amazon.Mgn.Model.ListRemoteSourceActionInvocationsResponse",
        "This cmdlet returns a collection of Amazon.Mgn.Model.RemoteSourceActionInvocation objects.",
        "The service call response (type Amazon.Mgn.Model.ListRemoteSourceActionInvocationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMGNRemoteSourceActionInvocationListCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountID
        /// <summary>
        /// <para>
        /// <para>Account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountID { get; set; }
        #endregion
        
        #region Parameter Filters_RemoteSourceActionArn
        /// <summary>
        /// <para>
        /// <para>A list of source action ARNs to filter by.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_RemoteSourceActionArns")]
        public System.String[] Filters_RemoteSourceActionArn { get; set; }
        #endregion
        
        #region Parameter RemoteSourceActionJobID
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the job to list invocations for.</para>
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
        public System.String RemoteSourceActionJobID { get; set; }
        #endregion
        
        #region Parameter Filters_SourceServerArn
        /// <summary>
        /// <para>
        /// <para>A list of source server ARNs to filter by.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_SourceServerArns")]
        public System.String[] Filters_SourceServerArn { get; set; }
        #endregion
        
        #region Parameter Filters_Status
        /// <summary>
        /// <para>
        /// <para>A list of invocation statuses to filter by.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Statuses")]
        public System.String[] Filters_Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call.</para>
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
        /// <para>The token for the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.ListRemoteSourceActionInvocationsResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.ListRemoteSourceActionInvocationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.ListRemoteSourceActionInvocationsResponse, GetMGNRemoteSourceActionInvocationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountID = this.AccountID;
            if (this.Filters_RemoteSourceActionArn != null)
            {
                context.Filters_RemoteSourceActionArn = new List<System.String>(this.Filters_RemoteSourceActionArn);
            }
            if (this.Filters_SourceServerArn != null)
            {
                context.Filters_SourceServerArn = new List<System.String>(this.Filters_SourceServerArn);
            }
            if (this.Filters_Status != null)
            {
                context.Filters_Status = new List<System.String>(this.Filters_Status);
            }
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
            context.RemoteSourceActionJobID = this.RemoteSourceActionJobID;
            #if MODULAR
            if (this.RemoteSourceActionJobID == null && ParameterWasBound(nameof(this.RemoteSourceActionJobID)))
            {
                WriteWarning("You are passing $null as a value for parameter RemoteSourceActionJobID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Mgn.Model.ListRemoteSourceActionInvocationsRequest();
            
            if (cmdletContext.AccountID != null)
            {
                request.AccountID = cmdletContext.AccountID;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Mgn.Model.ListRemoteSourceActionInvocationsRequestFilters();
            List<System.String> requestFilters_filters_RemoteSourceActionArn = null;
            if (cmdletContext.Filters_RemoteSourceActionArn != null)
            {
                requestFilters_filters_RemoteSourceActionArn = cmdletContext.Filters_RemoteSourceActionArn;
            }
            if (requestFilters_filters_RemoteSourceActionArn != null)
            {
                request.Filters.RemoteSourceActionArns = requestFilters_filters_RemoteSourceActionArn;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_SourceServerArn = null;
            if (cmdletContext.Filters_SourceServerArn != null)
            {
                requestFilters_filters_SourceServerArn = cmdletContext.Filters_SourceServerArn;
            }
            if (requestFilters_filters_SourceServerArn != null)
            {
                request.Filters.SourceServerArns = requestFilters_filters_SourceServerArn;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Status = null;
            if (cmdletContext.Filters_Status != null)
            {
                requestFilters_filters_Status = cmdletContext.Filters_Status;
            }
            if (requestFilters_filters_Status != null)
            {
                request.Filters.Statuses = requestFilters_filters_Status;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.RemoteSourceActionJobID != null)
            {
                request.RemoteSourceActionJobID = cmdletContext.RemoteSourceActionJobID;
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
        
        private Amazon.Mgn.Model.ListRemoteSourceActionInvocationsResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.ListRemoteSourceActionInvocationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "ListRemoteSourceActionInvocations");
            try
            {
                return client.ListRemoteSourceActionInvocationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountID { get; set; }
            public List<System.String> Filters_RemoteSourceActionArn { get; set; }
            public List<System.String> Filters_SourceServerArn { get; set; }
            public List<System.String> Filters_Status { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String RemoteSourceActionJobID { get; set; }
            public System.Func<Amazon.Mgn.Model.ListRemoteSourceActionInvocationsResponse, GetMGNRemoteSourceActionInvocationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}

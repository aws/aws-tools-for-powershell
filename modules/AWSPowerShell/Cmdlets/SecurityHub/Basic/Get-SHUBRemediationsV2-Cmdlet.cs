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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Retrieves remediation targets for the account, or for all member accounts if the caller
    /// is the delegated administrator. Results are sorted by priority, highest first, and
    /// are paginated. Use <c>TargetUid</c> or <c>MetadataUid</c> to scope the request to
    /// a single target or finding.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SHUBRemediationsV2")]
    [OutputType("Amazon.SecurityHub.Model.RemediationV2Item")]
    [AWSCmdlet("Calls the AWS Security Hub GetRemediationsV2 API operation.", Operation = new[] {"GetRemediationsV2"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.GetRemediationsV2Response))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.RemediationV2Item or Amazon.SecurityHub.Model.GetRemediationsV2Response",
        "This cmdlet returns a collection of Amazon.SecurityHub.Model.RemediationV2Item objects.",
        "The service call response (type Amazon.SecurityHub.Model.GetRemediationsV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class GetSHUBRemediationsV2Cmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_CompositeFilter
        /// <summary>
        /// <para>
        /// <para>A collection of complex filtering conditions that can be applied to remediation target
        /// data.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_CompositeFilters")]
        public Amazon.SecurityHub.Model.RemediationCompositeFilter[] Filters_CompositeFilter { get; set; }
        #endregion
        
        #region Parameter GuidanceFormat
        /// <summary>
        /// <para>
        /// <para>The format of the remediation guidance examples to return. Valid values are <c>All</c>,
        /// <c>AwsCli</c>, <c>Cli</c>, <c>Python</c>, <c>Terraform</c>, <c>Cdk</c>, <c>CloudFormation</c>,
        /// <c>IaC</c>, and <c>Template</c>. If you don't specify a value, all formats are returned.
        /// Applies only when <c>ShowGuidance</c> is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.GuidanceFormat")]
        public Amazon.SecurityHub.GuidanceFormat GuidanceFormat { get; set; }
        #endregion
        
        #region Parameter MetadataUid
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of the Security Hub exposure finding, found under the <c>metadata.uid</c>
        /// field of the finding. Returns the remediation targets associated with that finding.
        /// You can't use <c>MetadataUid</c> together with <c>TargetUid</c> or <c>Filters</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataUid { get; set; }
        #endregion
        
        #region Parameter ShowGuidance
        /// <summary>
        /// <para>
        /// <para>Specifies whether to show remediation target guidance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ShowGuidance { get; set; }
        #endregion
        
        #region Parameter TargetUid
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of an existing remediation target to return. Returns the
        /// single matching target. You can't use <c>TargetUid</c> together with <c>MetadataUid</c>
        /// or <c>Filters</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetUid { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. Valid range is 1-100. If you don't specify
        /// a value, the operation returns up to 25 results.</para>
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
        /// <para>The token used to paginate the remediations target list returned. On your first call
        /// to <c>GetRemediationsV2</c>, omit this parameter or set it to <c>NULL</c>. For subsequent
        /// calls, use the <c>NextToken</c> value returned in the previous response to retrieve
        /// the next page of results.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.GetRemediationsV2Response).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.GetRemediationsV2Response will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.GetRemediationsV2Response, GetSHUBRemediationsV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filters_CompositeFilter != null)
            {
                context.Filters_CompositeFilter = new List<Amazon.SecurityHub.Model.RemediationCompositeFilter>(this.Filters_CompositeFilter);
            }
            context.GuidanceFormat = this.GuidanceFormat;
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
            context.MetadataUid = this.MetadataUid;
            context.NextToken = this.NextToken;
            context.ShowGuidance = this.ShowGuidance;
            context.TargetUid = this.TargetUid;
            
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
            var request = new Amazon.SecurityHub.Model.GetRemediationsV2Request();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.SecurityHub.Model.RemediationFilters();
            List<Amazon.SecurityHub.Model.RemediationCompositeFilter> requestFilters_filters_CompositeFilter = null;
            if (cmdletContext.Filters_CompositeFilter != null)
            {
                requestFilters_filters_CompositeFilter = cmdletContext.Filters_CompositeFilter;
            }
            if (requestFilters_filters_CompositeFilter != null)
            {
                request.Filters.CompositeFilters = requestFilters_filters_CompositeFilter;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.GuidanceFormat != null)
            {
                request.GuidanceFormat = cmdletContext.GuidanceFormat;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.MetadataUid != null)
            {
                request.MetadataUid = cmdletContext.MetadataUid;
            }
            if (cmdletContext.ShowGuidance != null)
            {
                request.ShowGuidance = cmdletContext.ShowGuidance.Value;
            }
            if (cmdletContext.TargetUid != null)
            {
                request.TargetUid = cmdletContext.TargetUid;
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
        
        private Amazon.SecurityHub.Model.GetRemediationsV2Response CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.GetRemediationsV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "GetRemediationsV2");
            try
            {
                return client.GetRemediationsV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityHub.Model.RemediationCompositeFilter> Filters_CompositeFilter { get; set; }
            public Amazon.SecurityHub.GuidanceFormat GuidanceFormat { get; set; }
            public int? MaxResult { get; set; }
            public System.String MetadataUid { get; set; }
            public System.String NextToken { get; set; }
            public System.Boolean? ShowGuidance { get; set; }
            public System.String TargetUid { get; set; }
            public System.Func<Amazon.SecurityHub.Model.GetRemediationsV2Response, GetSHUBRemediationsV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}

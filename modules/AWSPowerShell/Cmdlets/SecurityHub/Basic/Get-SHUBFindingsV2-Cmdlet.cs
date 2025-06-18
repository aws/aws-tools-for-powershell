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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Return a list of findings that match the specified criteria. <c>GetFindings</c> and
    /// <c>GetFindingsV2</c> both use <c>securityhub:GetFindings</c> in the <c>Action</c>
    /// element of an IAM policy statement. You must have permission to perform the <c>securityhub:GetFindings</c>
    /// action. This API is in private preview and subject to change.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SHUBFindingsV2")]
    [OutputType("Amazon.Runtime.Documents.Document")]
    [AWSCmdlet("Calls the AWS Security Hub GetFindingsV2 API operation.", Operation = new[] {"GetFindingsV2"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.GetFindingsV2Response))]
    [AWSCmdletOutput("Amazon.Runtime.Documents.Document or Amazon.SecurityHub.Model.GetFindingsV2Response",
        "This cmdlet returns a collection of Amazon.Runtime.Documents.Document objects.",
        "The service call response (type Amazon.SecurityHub.Model.GetFindingsV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class GetSHUBFindingsV2Cmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_CompositeFilter
        /// <summary>
        /// <para>
        /// <para>Enables the creation of complex filtering conditions by combining filter criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_CompositeFilters")]
        public Amazon.SecurityHub.Model.CompositeFilter[] Filters_CompositeFilter { get; set; }
        #endregion
        
        #region Parameter Filters_CompositeOperator
        /// <summary>
        /// <para>
        /// <para>The logical operators used to combine the filtering on multiple <c>CompositeFilters</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.AllowedOperators")]
        public Amazon.SecurityHub.AllowedOperators Filters_CompositeOperator { get; set; }
        #endregion
        
        #region Parameter SortCriterion
        /// <summary>
        /// <para>
        /// <para>The finding attributes used to sort the list of returned findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SortCriteria")]
        public Amazon.SecurityHub.Model.SortCriterion[] SortCriterion { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The token required for pagination. On your first call, set the value of this parameter
        /// to <c>NULL</c>. For subsequent calls, to continue listing data, set the value of this
        /// parameter to the value returned in the previous response.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Findings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.GetFindingsV2Response).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.GetFindingsV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Findings";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Filters_CompositeOperator parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Filters_CompositeOperator' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Filters_CompositeOperator' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.GetFindingsV2Response, GetSHUBFindingsV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Filters_CompositeOperator;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filters_CompositeFilter != null)
            {
                context.Filters_CompositeFilter = new List<Amazon.SecurityHub.Model.CompositeFilter>(this.Filters_CompositeFilter);
            }
            context.Filters_CompositeOperator = this.Filters_CompositeOperator;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.SortCriterion != null)
            {
                context.SortCriterion = new List<Amazon.SecurityHub.Model.SortCriterion>(this.SortCriterion);
            }
            
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
            var request = new Amazon.SecurityHub.Model.GetFindingsV2Request();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.SecurityHub.Model.OcsfFindingFilters();
            List<Amazon.SecurityHub.Model.CompositeFilter> requestFilters_filters_CompositeFilter = null;
            if (cmdletContext.Filters_CompositeFilter != null)
            {
                requestFilters_filters_CompositeFilter = cmdletContext.Filters_CompositeFilter;
            }
            if (requestFilters_filters_CompositeFilter != null)
            {
                request.Filters.CompositeFilters = requestFilters_filters_CompositeFilter;
                requestFiltersIsNull = false;
            }
            Amazon.SecurityHub.AllowedOperators requestFilters_filters_CompositeOperator = null;
            if (cmdletContext.Filters_CompositeOperator != null)
            {
                requestFilters_filters_CompositeOperator = cmdletContext.Filters_CompositeOperator;
            }
            if (requestFilters_filters_CompositeOperator != null)
            {
                request.Filters.CompositeOperator = requestFilters_filters_CompositeOperator;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SortCriterion != null)
            {
                request.SortCriteria = cmdletContext.SortCriterion;
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
        
        private Amazon.SecurityHub.Model.GetFindingsV2Response CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.GetFindingsV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "GetFindingsV2");
            try
            {
                #if DESKTOP
                return client.GetFindingsV2(request);
                #elif CORECLR
                return client.GetFindingsV2Async(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityHub.Model.CompositeFilter> Filters_CompositeFilter { get; set; }
            public Amazon.SecurityHub.AllowedOperators Filters_CompositeOperator { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.SecurityHub.Model.SortCriterion> SortCriterion { get; set; }
            public System.Func<Amazon.SecurityHub.Model.GetFindingsV2Response, GetSHUBFindingsV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Findings;
        }
        
    }
}

/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ControlCatalog;
using Amazon.ControlCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.CLCAT
{
    /// <summary>
    /// Returns a paginated list of common controls from the Amazon Web Services Control Catalog.
    /// 
    ///  
    /// <para>
    /// You can apply an optional filter to see common controls that have a specific objective.
    /// If you don’t provide a filter, the operation returns all common controls. 
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CLCATCommonControlList")]
    [OutputType("Amazon.ControlCatalog.Model.CommonControlSummary")]
    [AWSCmdlet("Calls the AWS Control Catalog ListCommonControls API operation.", Operation = new[] {"ListCommonControls"}, SelectReturnType = typeof(Amazon.ControlCatalog.Model.ListCommonControlsResponse))]
    [AWSCmdletOutput("Amazon.ControlCatalog.Model.CommonControlSummary or Amazon.ControlCatalog.Model.ListCommonControlsResponse",
        "This cmdlet returns a collection of Amazon.ControlCatalog.Model.CommonControlSummary objects.",
        "The service call response (type Amazon.ControlCatalog.Model.ListCommonControlsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCLCATCommonControlListCmdlet : AmazonControlCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CommonControlFilter_Objective
        /// <summary>
        /// <para>
        /// <para>The objective that's used as filter criteria.</para><para>You can use this parameter to specify one objective ARN at a time. Passing multiple
        /// ARNs in the <c>CommonControlFilter</c> isn’t currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommonControlFilter_Objectives")]
        public Amazon.ControlCatalog.Model.ObjectiveResourceFilter[] CommonControlFilter_Objective { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results on a page or for an API request call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that's used to fetch the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CommonControls'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlCatalog.Model.ListCommonControlsResponse).
        /// Specifying the name of a property of type Amazon.ControlCatalog.Model.ListCommonControlsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CommonControls";
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ControlCatalog.Model.ListCommonControlsResponse, GetCLCATCommonControlListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CommonControlFilter_Objective != null)
            {
                context.CommonControlFilter_Objective = new List<Amazon.ControlCatalog.Model.ObjectiveResourceFilter>(this.CommonControlFilter_Objective);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.ControlCatalog.Model.ListCommonControlsRequest();
            
            
             // populate CommonControlFilter
            var requestCommonControlFilterIsNull = true;
            request.CommonControlFilter = new Amazon.ControlCatalog.Model.CommonControlFilter();
            List<Amazon.ControlCatalog.Model.ObjectiveResourceFilter> requestCommonControlFilter_commonControlFilter_Objective = null;
            if (cmdletContext.CommonControlFilter_Objective != null)
            {
                requestCommonControlFilter_commonControlFilter_Objective = cmdletContext.CommonControlFilter_Objective;
            }
            if (requestCommonControlFilter_commonControlFilter_Objective != null)
            {
                request.CommonControlFilter.Objectives = requestCommonControlFilter_commonControlFilter_Objective;
                requestCommonControlFilterIsNull = false;
            }
             // determine if request.CommonControlFilter should be set to null
            if (requestCommonControlFilterIsNull)
            {
                request.CommonControlFilter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.ControlCatalog.Model.ListCommonControlsResponse CallAWSServiceOperation(IAmazonControlCatalog client, Amazon.ControlCatalog.Model.ListCommonControlsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Catalog", "ListCommonControls");
            try
            {
                #if DESKTOP
                return client.ListCommonControls(request);
                #elif CORECLR
                return client.ListCommonControlsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ControlCatalog.Model.ObjectiveResourceFilter> CommonControlFilter_Objective { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ControlCatalog.Model.ListCommonControlsResponse, GetCLCATCommonControlListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CommonControls;
        }
        
    }
}

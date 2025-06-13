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
using Amazon.ControlCatalog;
using Amazon.ControlCatalog.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CLCAT
{
    /// <summary>
    /// Returns a paginated list of all available controls in the Control Catalog library.
    /// Allows you to discover available controls. The list of controls is given as structures
    /// of type <i>controlSummary</i>. The ARN is returned in the global <i>controlcatalog</i>
    /// format, as shown in the examples.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CLCATControlList")]
    [OutputType("Amazon.ControlCatalog.Model.ControlSummary")]
    [AWSCmdlet("Calls the AWS Control Catalog ListControls API operation.", Operation = new[] {"ListControls"}, SelectReturnType = typeof(Amazon.ControlCatalog.Model.ListControlsResponse))]
    [AWSCmdletOutput("Amazon.ControlCatalog.Model.ControlSummary or Amazon.ControlCatalog.Model.ListControlsResponse",
        "This cmdlet returns a collection of Amazon.ControlCatalog.Model.ControlSummary objects.",
        "The service call response (type Amazon.ControlCatalog.Model.ListControlsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCLCATControlListCmdlet : AmazonControlCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Implementations_Identifier
        /// <summary>
        /// <para>
        /// <para>A list of service-specific identifiers that can serve as filters. For example, you
        /// can filter for controls with specific Amazon Web Services Config Rule IDs or Security
        /// Hub Control IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Implementations_Identifiers")]
        public System.String[] Implementations_Identifier { get; set; }
        #endregion
        
        #region Parameter Implementations_Type
        /// <summary>
        /// <para>
        /// <para>A list of implementation types that can serve as filters. For example, you can filter
        /// for controls implemented as Amazon Web Services Config Rules by specifying AWS::Config::ConfigRule
        /// as a type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Implementations_Types")]
        public System.String[] Implementations_Type { get; set; }
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
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Controls'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlCatalog.Model.ListControlsResponse).
        /// Specifying the name of a property of type Amazon.ControlCatalog.Model.ListControlsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Controls";
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
                context.Select = CreateSelectDelegate<Amazon.ControlCatalog.Model.ListControlsResponse, GetCLCATControlListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Implementations_Identifier != null)
            {
                context.Implementations_Identifier = new List<System.String>(this.Implementations_Identifier);
            }
            if (this.Implementations_Type != null)
            {
                context.Implementations_Type = new List<System.String>(this.Implementations_Type);
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
            var request = new Amazon.ControlCatalog.Model.ListControlsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.ControlCatalog.Model.ControlFilter();
            Amazon.ControlCatalog.Model.ImplementationFilter requestFilter_filter_Implementations = null;
            
             // populate Implementations
            var requestFilter_filter_ImplementationsIsNull = true;
            requestFilter_filter_Implementations = new Amazon.ControlCatalog.Model.ImplementationFilter();
            List<System.String> requestFilter_filter_Implementations_implementations_Identifier = null;
            if (cmdletContext.Implementations_Identifier != null)
            {
                requestFilter_filter_Implementations_implementations_Identifier = cmdletContext.Implementations_Identifier;
            }
            if (requestFilter_filter_Implementations_implementations_Identifier != null)
            {
                requestFilter_filter_Implementations.Identifiers = requestFilter_filter_Implementations_implementations_Identifier;
                requestFilter_filter_ImplementationsIsNull = false;
            }
            List<System.String> requestFilter_filter_Implementations_implementations_Type = null;
            if (cmdletContext.Implementations_Type != null)
            {
                requestFilter_filter_Implementations_implementations_Type = cmdletContext.Implementations_Type;
            }
            if (requestFilter_filter_Implementations_implementations_Type != null)
            {
                requestFilter_filter_Implementations.Types = requestFilter_filter_Implementations_implementations_Type;
                requestFilter_filter_ImplementationsIsNull = false;
            }
             // determine if requestFilter_filter_Implementations should be set to null
            if (requestFilter_filter_ImplementationsIsNull)
            {
                requestFilter_filter_Implementations = null;
            }
            if (requestFilter_filter_Implementations != null)
            {
                request.Filter.Implementations = requestFilter_filter_Implementations;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
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
        
        private Amazon.ControlCatalog.Model.ListControlsResponse CallAWSServiceOperation(IAmazonControlCatalog client, Amazon.ControlCatalog.Model.ListControlsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Catalog", "ListControls");
            try
            {
                return client.ListControlsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Implementations_Identifier { get; set; }
            public List<System.String> Implementations_Type { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ControlCatalog.Model.ListControlsResponse, GetCLCATControlListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Controls;
        }
        
    }
}

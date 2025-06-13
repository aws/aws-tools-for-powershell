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
using Amazon.ControlCatalog;
using Amazon.ControlCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.CLCAT
{
    /// <summary>
    /// Returns a paginated list of control mappings from the Control Catalog. Control mappings
    /// show relationships between controls and other entities, such as common controls or
    /// compliance frameworks.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CLCATControlMappingList")]
    [OutputType("Amazon.ControlCatalog.Model.ControlMapping")]
    [AWSCmdlet("Calls the AWS Control Catalog ListControlMappings API operation.", Operation = new[] {"ListControlMappings"}, SelectReturnType = typeof(Amazon.ControlCatalog.Model.ListControlMappingsResponse))]
    [AWSCmdletOutput("Amazon.ControlCatalog.Model.ControlMapping or Amazon.ControlCatalog.Model.ListControlMappingsResponse",
        "This cmdlet returns a collection of Amazon.ControlCatalog.Model.ControlMapping objects.",
        "The service call response (type Amazon.ControlCatalog.Model.ListControlMappingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCLCATControlMappingListCmdlet : AmazonControlCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_CommonControlArn
        /// <summary>
        /// <para>
        /// <para>A list of common control ARNs to filter the mappings. When specified, only mappings
        /// associated with these common controls are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_CommonControlArns")]
        public System.String[] Filter_CommonControlArn { get; set; }
        #endregion
        
        #region Parameter Filter_ControlArn
        /// <summary>
        /// <para>
        /// <para>A list of control ARNs to filter the mappings. When specified, only mappings associated
        /// with these controls are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ControlArns")]
        public System.String[] Filter_ControlArn { get; set; }
        #endregion
        
        #region Parameter Filter_MappingType
        /// <summary>
        /// <para>
        /// <para>A list of mapping types to filter the mappings. When specified, only mappings of these
        /// types are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_MappingTypes")]
        public System.String[] Filter_MappingType { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ControlMappings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlCatalog.Model.ListControlMappingsResponse).
        /// Specifying the name of a property of type Amazon.ControlCatalog.Model.ListControlMappingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ControlMappings";
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
                context.Select = CreateSelectDelegate<Amazon.ControlCatalog.Model.ListControlMappingsResponse, GetCLCATControlMappingListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter_CommonControlArn != null)
            {
                context.Filter_CommonControlArn = new List<System.String>(this.Filter_CommonControlArn);
            }
            if (this.Filter_ControlArn != null)
            {
                context.Filter_ControlArn = new List<System.String>(this.Filter_ControlArn);
            }
            if (this.Filter_MappingType != null)
            {
                context.Filter_MappingType = new List<System.String>(this.Filter_MappingType);
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
            var request = new Amazon.ControlCatalog.Model.ListControlMappingsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.ControlCatalog.Model.ControlMappingFilter();
            List<System.String> requestFilter_filter_CommonControlArn = null;
            if (cmdletContext.Filter_CommonControlArn != null)
            {
                requestFilter_filter_CommonControlArn = cmdletContext.Filter_CommonControlArn;
            }
            if (requestFilter_filter_CommonControlArn != null)
            {
                request.Filter.CommonControlArns = requestFilter_filter_CommonControlArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_ControlArn = null;
            if (cmdletContext.Filter_ControlArn != null)
            {
                requestFilter_filter_ControlArn = cmdletContext.Filter_ControlArn;
            }
            if (requestFilter_filter_ControlArn != null)
            {
                request.Filter.ControlArns = requestFilter_filter_ControlArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_MappingType = null;
            if (cmdletContext.Filter_MappingType != null)
            {
                requestFilter_filter_MappingType = cmdletContext.Filter_MappingType;
            }
            if (requestFilter_filter_MappingType != null)
            {
                request.Filter.MappingTypes = requestFilter_filter_MappingType;
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
        
        private Amazon.ControlCatalog.Model.ListControlMappingsResponse CallAWSServiceOperation(IAmazonControlCatalog client, Amazon.ControlCatalog.Model.ListControlMappingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Catalog", "ListControlMappings");
            try
            {
                #if DESKTOP
                return client.ListControlMappings(request);
                #elif CORECLR
                return client.ListControlMappingsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Filter_CommonControlArn { get; set; }
            public List<System.String> Filter_ControlArn { get; set; }
            public List<System.String> Filter_MappingType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ControlCatalog.Model.ListControlMappingsResponse, GetCLCATControlMappingListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ControlMappings;
        }
        
    }
}

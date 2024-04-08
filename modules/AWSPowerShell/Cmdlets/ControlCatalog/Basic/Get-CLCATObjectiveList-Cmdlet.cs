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
    /// Returns a paginated list of objectives from the Amazon Web Services Control Catalog.
    /// 
    ///  
    /// <para>
    /// You can apply an optional filter to see the objectives that belong to a specific domain.
    /// If you don’t provide a filter, the operation returns all objectives. 
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CLCATObjectiveList")]
    [OutputType("Amazon.ControlCatalog.Model.ObjectiveSummary")]
    [AWSCmdlet("Calls the AWS Control Catalog ListObjectives API operation.", Operation = new[] {"ListObjectives"}, SelectReturnType = typeof(Amazon.ControlCatalog.Model.ListObjectivesResponse))]
    [AWSCmdletOutput("Amazon.ControlCatalog.Model.ObjectiveSummary or Amazon.ControlCatalog.Model.ListObjectivesResponse",
        "This cmdlet returns a collection of Amazon.ControlCatalog.Model.ObjectiveSummary objects.",
        "The service call response (type Amazon.ControlCatalog.Model.ListObjectivesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCLCATObjectiveListCmdlet : AmazonControlCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ObjectiveFilter_Domain
        /// <summary>
        /// <para>
        /// <para>The domain that's used as filter criteria.</para><para>You can use this parameter to specify one domain ARN at a time. Passing multiple ARNs
        /// in the <c>ObjectiveFilter</c> isn’t currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ObjectiveFilter_Domains")]
        public Amazon.ControlCatalog.Model.DomainResourceFilter[] ObjectiveFilter_Domain { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Objectives'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlCatalog.Model.ListObjectivesResponse).
        /// Specifying the name of a property of type Amazon.ControlCatalog.Model.ListObjectivesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Objectives";
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
                context.Select = CreateSelectDelegate<Amazon.ControlCatalog.Model.ListObjectivesResponse, GetCLCATObjectiveListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.ObjectiveFilter_Domain != null)
            {
                context.ObjectiveFilter_Domain = new List<Amazon.ControlCatalog.Model.DomainResourceFilter>(this.ObjectiveFilter_Domain);
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ControlCatalog.Model.ListObjectivesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate ObjectiveFilter
            var requestObjectiveFilterIsNull = true;
            request.ObjectiveFilter = new Amazon.ControlCatalog.Model.ObjectiveFilter();
            List<Amazon.ControlCatalog.Model.DomainResourceFilter> requestObjectiveFilter_objectiveFilter_Domain = null;
            if (cmdletContext.ObjectiveFilter_Domain != null)
            {
                requestObjectiveFilter_objectiveFilter_Domain = cmdletContext.ObjectiveFilter_Domain;
            }
            if (requestObjectiveFilter_objectiveFilter_Domain != null)
            {
                request.ObjectiveFilter.Domains = requestObjectiveFilter_objectiveFilter_Domain;
                requestObjectiveFilterIsNull = false;
            }
             // determine if request.ObjectiveFilter should be set to null
            if (requestObjectiveFilterIsNull)
            {
                request.ObjectiveFilter = null;
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
        
        private Amazon.ControlCatalog.Model.ListObjectivesResponse CallAWSServiceOperation(IAmazonControlCatalog client, Amazon.ControlCatalog.Model.ListObjectivesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Catalog", "ListObjectives");
            try
            {
                #if DESKTOP
                return client.ListObjectives(request);
                #elif CORECLR
                return client.ListObjectivesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.ControlCatalog.Model.DomainResourceFilter> ObjectiveFilter_Domain { get; set; }
            public System.Func<Amazon.ControlCatalog.Model.ListObjectivesResponse, GetCLCATObjectiveListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Objectives;
        }
        
    }
}

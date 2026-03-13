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
using Amazon.Mgn;
using Amazon.Mgn.Model;

namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Lists code generation segments, which represent individual infrastructure components
    /// generated as code templates.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "MGNNetworkMigrationCodeGenerationSegmentList")]
    [OutputType("Amazon.Mgn.Model.NetworkMigrationCodeGenerationSegment")]
    [AWSCmdlet("Calls the Application Migration Service ListNetworkMigrationCodeGenerationSegments API operation.", Operation = new[] {"ListNetworkMigrationCodeGenerationSegments"}, SelectReturnType = typeof(Amazon.Mgn.Model.ListNetworkMigrationCodeGenerationSegmentsResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.NetworkMigrationCodeGenerationSegment or Amazon.Mgn.Model.ListNetworkMigrationCodeGenerationSegmentsResponse",
        "This cmdlet returns a collection of Amazon.Mgn.Model.NetworkMigrationCodeGenerationSegment objects.",
        "The service call response (type Amazon.Mgn.Model.ListNetworkMigrationCodeGenerationSegmentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMGNNetworkMigrationCodeGenerationSegmentListCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NetworkMigrationDefinitionID
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the network migration definition.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String NetworkMigrationDefinitionID { get; set; }
        #endregion
        
        #region Parameter NetworkMigrationExecutionID
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the network migration execution.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String NetworkMigrationExecutionID { get; set; }
        #endregion
        
        #region Parameter Filters_SegmentIDs
        /// <summary>
        /// <para>
        /// <para>A list of segment IDs to filter by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filters_SegmentIDs { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.ListNetworkMigrationCodeGenerationSegmentsResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.ListNetworkMigrationCodeGenerationSegmentsResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.ListNetworkMigrationCodeGenerationSegmentsResponse, GetMGNNetworkMigrationCodeGenerationSegmentListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filters_SegmentIDs != null)
            {
                context.Filters_SegmentIDs = new List<System.String>(this.Filters_SegmentIDs);
            }
            context.MaxResult = this.MaxResult;
            context.NetworkMigrationDefinitionID = this.NetworkMigrationDefinitionID;
            #if MODULAR
            if (this.NetworkMigrationDefinitionID == null && ParameterWasBound(nameof(this.NetworkMigrationDefinitionID)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkMigrationDefinitionID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkMigrationExecutionID = this.NetworkMigrationExecutionID;
            #if MODULAR
            if (this.NetworkMigrationExecutionID == null && ParameterWasBound(nameof(this.NetworkMigrationExecutionID)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkMigrationExecutionID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Mgn.Model.ListNetworkMigrationCodeGenerationSegmentsRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Mgn.Model.ListNetworkMigrationCodeGenerationSegmentsFilters();
            List<System.String> requestFilters_filters_SegmentIDs = null;
            if (cmdletContext.Filters_SegmentIDs != null)
            {
                requestFilters_filters_SegmentIDs = cmdletContext.Filters_SegmentIDs;
            }
            if (requestFilters_filters_SegmentIDs != null)
            {
                request.Filters.SegmentIDs = requestFilters_filters_SegmentIDs;
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
            if (cmdletContext.NetworkMigrationDefinitionID != null)
            {
                request.NetworkMigrationDefinitionID = cmdletContext.NetworkMigrationDefinitionID;
            }
            if (cmdletContext.NetworkMigrationExecutionID != null)
            {
                request.NetworkMigrationExecutionID = cmdletContext.NetworkMigrationExecutionID;
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
        
        private Amazon.Mgn.Model.ListNetworkMigrationCodeGenerationSegmentsResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.ListNetworkMigrationCodeGenerationSegmentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "ListNetworkMigrationCodeGenerationSegments");
            try
            {
                #if DESKTOP
                return client.ListNetworkMigrationCodeGenerationSegments(request);
                #elif CORECLR
                return client.ListNetworkMigrationCodeGenerationSegmentsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Filters_SegmentIDs { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NetworkMigrationDefinitionID { get; set; }
            public System.String NetworkMigrationExecutionID { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Mgn.Model.ListNetworkMigrationCodeGenerationSegmentsResponse, GetMGNNetworkMigrationCodeGenerationSegmentListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}

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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Retrieves the reservation utilization for your account. Master accounts in an organization
    /// have access to member accounts. You can filter data by dimensions in a time period.
    /// You can use <code>GetDimensionValues</code> to determine the possible dimension values.
    /// Currently, you can group only by <code>SUBSCRIPTION_ID</code>.<br/><br/>In the AWS.Tools.CostExplorer module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CEReservationUtilization")]
    [OutputType("Amazon.CostExplorer.Model.GetReservationUtilizationResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetReservationUtilization API operation.", Operation = new[] {"GetReservationUtilization"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.GetReservationUtilizationResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetReservationUtilizationResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.GetReservationUtilizationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCEReservationUtilizationCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Filters utilization data by dimensions. You can filter by the following dimensions:</para><ul><li><para>AZ</para></li><li><para>CACHE_ENGINE</para></li><li><para>DEPLOYMENT_OPTION</para></li><li><para>INSTANCE_TYPE</para></li><li><para>LINKED_ACCOUNT</para></li><li><para>OPERATING_SYSTEM</para></li><li><para>PLATFORM</para></li><li><para>REGION</para></li><li><para>SERVICE</para></li><li><para>SCOPE</para></li><li><para>TENANCY</para></li></ul><para><code>GetReservationUtilization</code> uses the same <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_Expression.html">Expression</a>
        /// object as the other operations, but only <code>AND</code> is supported among each
        /// dimension, and nesting is supported up to only one level deep. If there are multiple
        /// values for a dimension, they are OR'd together.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>If <code>GroupBy</code> is set, <code>Granularity</code> can't be set. If <code>Granularity</code>
        /// isn't set, the response object doesn't include <code>Granularity</code>, either <code>MONTHLY</code>
        /// or <code>DAILY</code>. If both <code>GroupBy</code> and <code>Granularity</code> aren't
        /// set, <code>GetReservationUtilization</code> defaults to <code>DAILY</code>.</para><para>The <code>GetReservationUtilization</code> operation supports only <code>DAILY</code>
        /// and <code>MONTHLY</code> granularities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.Granularity")]
        public Amazon.CostExplorer.Granularity Granularity { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>Groups only by <code>SUBSCRIPTION_ID</code>. Metadata is included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.GroupDefinition[] GroupBy { get; set; }
        #endregion
        
        #region Parameter TimePeriod
        /// <summary>
        /// <para>
        /// <para>Sets the start and end dates for retrieving RI utilization. The start date is inclusive,
        /// but the end date is exclusive. For example, if <code>start</code> is <code>2017-01-01</code>
        /// and <code>end</code> is <code>2017-05-01</code>, then the cost and usage data is retrieved
        /// from <code>2017-01-01</code> up to and including <code>2017-04-30</code> but not including
        /// <code>2017-05-01</code>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results. AWS provides the token when the response
        /// from a previous call has more results than the maximum page size.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.CostExplorer module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextPageToken $null' for the first call and '-NextPageToken $AWSHistory.LastServiceResponse.NextPageToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String NextPageToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.GetReservationUtilizationResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.GetReservationUtilizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TimePeriod parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TimePeriod' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TimePeriod' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextPageToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetReservationUtilizationResponse, GetCEReservationUtilizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TimePeriod;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Filter = this.Filter;
            context.Granularity = this.Granularity;
            if (this.GroupBy != null)
            {
                context.GroupBy = new List<Amazon.CostExplorer.Model.GroupDefinition>(this.GroupBy);
            }
            context.NextPageToken = this.NextPageToken;
            context.TimePeriod = this.TimePeriod;
            #if MODULAR
            if (this.TimePeriod == null && ParameterWasBound(nameof(this.TimePeriod)))
            {
                WriteWarning("You are passing $null as a value for parameter TimePeriod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CostExplorer.Model.GetReservationUtilizationRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.Granularity != null)
            {
                request.Granularity = cmdletContext.Granularity;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.TimePeriod != null)
            {
                request.TimePeriod = cmdletContext.TimePeriod;
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
                    
                    _nextToken = response.NextPageToken;
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
            // create request
            var request = new Amazon.CostExplorer.Model.GetReservationUtilizationRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.Granularity != null)
            {
                request.Granularity = cmdletContext.Granularity;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.NextPageToken != null)
            {
                request.NextPageToken = cmdletContext.NextPageToken;
            }
            if (cmdletContext.TimePeriod != null)
            {
                request.TimePeriod = cmdletContext.TimePeriod;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CostExplorer.Model.GetReservationUtilizationResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetReservationUtilizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetReservationUtilization");
            try
            {
                #if DESKTOP
                return client.GetReservationUtilization(request);
                #elif CORECLR
                return client.GetReservationUtilizationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CostExplorer.Model.Expression Filter { get; set; }
            public Amazon.CostExplorer.Granularity Granularity { get; set; }
            public List<Amazon.CostExplorer.Model.GroupDefinition> GroupBy { get; set; }
            public System.String NextPageToken { get; set; }
            public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
            public System.Func<Amazon.CostExplorer.Model.GetReservationUtilizationResponse, GetCEReservationUtilizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

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
    /// Creates recommendations that helps you save cost by identifying idle and underutilized
    /// Amazon EC2 instances.
    /// 
    ///  
    /// <para>
    /// Recommendations are generated to either downsize or terminate instances, along with
    /// providing savings detail and metrics. For details on calculation and function, see
    /// <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/ce-what-is.html">Optimizing
    /// Your Cost with Rightsizing Recommendations</a>.
    /// </para><br/><br/>In the AWS.Tools.CostExplorer module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CERightsizingRecommendation")]
    [OutputType("Amazon.CostExplorer.Model.GetRightsizingRecommendationResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetRightsizingRecommendation API operation.", Operation = new[] {"GetRightsizingRecommendation"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.GetRightsizingRecommendationResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetRightsizingRecommendationResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.GetRightsizingRecommendationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCERightsizingRecommendationCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter Configuration_BenefitsConsidered
        /// <summary>
        /// <para>
        /// <para> The option to consider RI or Savings Plans discount benefits in your savings calculation.
        /// The default value is <code>TRUE</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Configuration_BenefitsConsidered { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter Configuration_RecommendationTarget
        /// <summary>
        /// <para>
        /// <para> The option to see recommendations within the same instance family, or recommendations
        /// for instances across other families. The default value is <code>SAME_INSTANCE_FAMILY</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.RecommendationTarget")]
        public Amazon.CostExplorer.RecommendationTarget Configuration_RecommendationTarget { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>The specific service that you want recommendations for. The only valid value for <code>GetRightsizingRecommendation</code>
        /// is "<code>AmazonEC2</code>".</para>
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
        public System.String Service { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that indicates the next set of results that you want to retrieve.</para>
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
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>The number of recommendations that you want returned in a single response object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PageSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.GetRightsizingRecommendationResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.GetRightsizingRecommendationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Service parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Service' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Service' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetRightsizingRecommendationResponse, GetCERightsizingRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Service;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Configuration_BenefitsConsidered = this.Configuration_BenefitsConsidered;
            context.Configuration_RecommendationTarget = this.Configuration_RecommendationTarget;
            context.Filter = this.Filter;
            context.NextPageToken = this.NextPageToken;
            context.PageSize = this.PageSize;
            context.Service = this.Service;
            #if MODULAR
            if (this.Service == null && ParameterWasBound(nameof(this.Service)))
            {
                WriteWarning("You are passing $null as a value for parameter Service which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CostExplorer.Model.GetRightsizingRecommendationRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.CostExplorer.Model.RightsizingRecommendationConfiguration();
            System.Boolean? requestConfiguration_configuration_BenefitsConsidered = null;
            if (cmdletContext.Configuration_BenefitsConsidered != null)
            {
                requestConfiguration_configuration_BenefitsConsidered = cmdletContext.Configuration_BenefitsConsidered.Value;
            }
            if (requestConfiguration_configuration_BenefitsConsidered != null)
            {
                request.Configuration.BenefitsConsidered = requestConfiguration_configuration_BenefitsConsidered.Value;
                requestConfigurationIsNull = false;
            }
            Amazon.CostExplorer.RecommendationTarget requestConfiguration_configuration_RecommendationTarget = null;
            if (cmdletContext.Configuration_RecommendationTarget != null)
            {
                requestConfiguration_configuration_RecommendationTarget = cmdletContext.Configuration_RecommendationTarget;
            }
            if (requestConfiguration_configuration_RecommendationTarget != null)
            {
                request.Configuration.RecommendationTarget = requestConfiguration_configuration_RecommendationTarget;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
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
            var request = new Amazon.CostExplorer.Model.GetRightsizingRecommendationRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.CostExplorer.Model.RightsizingRecommendationConfiguration();
            System.Boolean? requestConfiguration_configuration_BenefitsConsidered = null;
            if (cmdletContext.Configuration_BenefitsConsidered != null)
            {
                requestConfiguration_configuration_BenefitsConsidered = cmdletContext.Configuration_BenefitsConsidered.Value;
            }
            if (requestConfiguration_configuration_BenefitsConsidered != null)
            {
                request.Configuration.BenefitsConsidered = requestConfiguration_configuration_BenefitsConsidered.Value;
                requestConfigurationIsNull = false;
            }
            Amazon.CostExplorer.RecommendationTarget requestConfiguration_configuration_RecommendationTarget = null;
            if (cmdletContext.Configuration_RecommendationTarget != null)
            {
                requestConfiguration_configuration_RecommendationTarget = cmdletContext.Configuration_RecommendationTarget;
            }
            if (requestConfiguration_configuration_RecommendationTarget != null)
            {
                request.Configuration.RecommendationTarget = requestConfiguration_configuration_RecommendationTarget;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.NextPageToken != null)
            {
                request.NextPageToken = cmdletContext.NextPageToken;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
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
        
        private Amazon.CostExplorer.Model.GetRightsizingRecommendationResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetRightsizingRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetRightsizingRecommendation");
            try
            {
                #if DESKTOP
                return client.GetRightsizingRecommendation(request);
                #elif CORECLR
                return client.GetRightsizingRecommendationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Configuration_BenefitsConsidered { get; set; }
            public Amazon.CostExplorer.RecommendationTarget Configuration_RecommendationTarget { get; set; }
            public Amazon.CostExplorer.Model.Expression Filter { get; set; }
            public System.String NextPageToken { get; set; }
            public System.Int32? PageSize { get; set; }
            public System.String Service { get; set; }
            public System.Func<Amazon.CostExplorer.Model.GetRightsizingRecommendationResponse, GetCERightsizingRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

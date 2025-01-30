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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Retrieves the Savings Plans recommendations for your account. First use <c>StartSavingsPlansPurchaseRecommendationGeneration</c>
    /// to generate a new set of recommendations, and then use <c>GetSavingsPlansPurchaseRecommendation</c>
    /// to retrieve them.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CESavingsPlansPurchaseRecommendation")]
    [OutputType("Amazon.CostExplorer.Model.GetSavingsPlansPurchaseRecommendationResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetSavingsPlansPurchaseRecommendation API operation.", Operation = new[] {"GetSavingsPlansPurchaseRecommendation"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.GetSavingsPlansPurchaseRecommendationResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetSavingsPlansPurchaseRecommendationResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.GetSavingsPlansPurchaseRecommendationResponse object containing multiple properties."
    )]
    public partial class GetCESavingsPlansPurchaseRecommendationCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountScope
        /// <summary>
        /// <para>
        /// <para>The account scope that you want your recommendations for. Amazon Web Services calculates
        /// recommendations including the management account and member accounts if the value
        /// is set to <c>PAYER</c>. If the value is <c>LINKED</c>, recommendations are calculated
        /// for individual member accounts only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.AccountScope")]
        public Amazon.CostExplorer.AccountScope AccountScope { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>You can filter your recommendations by Account ID with the <c>LINKED_ACCOUNT</c> dimension.
        /// To filter your recommendations by Account ID, specify <c>Key</c> as <c>LINKED_ACCOUNT</c>
        /// and <c>Value</c> as the comma-separated Acount ID(s) that you want to see Savings
        /// Plans purchase recommendations for.</para><para>For GetSavingsPlansPurchaseRecommendation, the <c>Filter</c> doesn't include <c>CostCategories</c>
        /// or <c>Tags</c>. It only includes <c>Dimensions</c>. With <c>Dimensions</c>, <c>Key</c>
        /// must be <c>LINKED_ACCOUNT</c> and <c>Value</c> can be a single Account ID or multiple
        /// comma-separated Account IDs that you want to see Savings Plans Purchase Recommendations
        /// for. <c>AND</c> and <c>OR</c> operators are not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter LookbackPeriodInDay
        /// <summary>
        /// <para>
        /// <para>The lookback period that's used to generate the recommendation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("LookbackPeriodInDays")]
        [AWSConstantClassSource("Amazon.CostExplorer.LookbackPeriodInDays")]
        public Amazon.CostExplorer.LookbackPeriodInDays LookbackPeriodInDay { get; set; }
        #endregion
        
        #region Parameter PaymentOption
        /// <summary>
        /// <para>
        /// <para>The payment option that's used to generate these recommendations.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostExplorer.PaymentOption")]
        public Amazon.CostExplorer.PaymentOption PaymentOption { get; set; }
        #endregion
        
        #region Parameter SavingsPlansType
        /// <summary>
        /// <para>
        /// <para>The Savings Plans recommendation type that's requested.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostExplorer.SupportedSavingsPlansType")]
        public Amazon.CostExplorer.SupportedSavingsPlansType SavingsPlansType { get; set; }
        #endregion
        
        #region Parameter TermInYear
        /// <summary>
        /// <para>
        /// <para>The savings plan recommendation term that's used to generate these recommendations.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TermInYears")]
        [AWSConstantClassSource("Amazon.CostExplorer.TermInYears")]
        public Amazon.CostExplorer.TermInYears TermInYear { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results. Amazon Web Services provides the token
        /// when the response from a previous call has more results than the maximum page size.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextPageToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextPageToken' to null for the first call then set the 'NextPageToken' using the same property output from the previous call for subsequent calls.
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.GetSavingsPlansPurchaseRecommendationResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.GetSavingsPlansPurchaseRecommendationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PaymentOption parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PaymentOption' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PaymentOption' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextPageToken
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
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetSavingsPlansPurchaseRecommendationResponse, GetCESavingsPlansPurchaseRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PaymentOption;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountScope = this.AccountScope;
            context.Filter = this.Filter;
            context.LookbackPeriodInDay = this.LookbackPeriodInDay;
            #if MODULAR
            if (this.LookbackPeriodInDay == null && ParameterWasBound(nameof(this.LookbackPeriodInDay)))
            {
                WriteWarning("You are passing $null as a value for parameter LookbackPeriodInDay which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextPageToken = this.NextPageToken;
            context.PageSize = this.PageSize;
            context.PaymentOption = this.PaymentOption;
            #if MODULAR
            if (this.PaymentOption == null && ParameterWasBound(nameof(this.PaymentOption)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentOption which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SavingsPlansType = this.SavingsPlansType;
            #if MODULAR
            if (this.SavingsPlansType == null && ParameterWasBound(nameof(this.SavingsPlansType)))
            {
                WriteWarning("You are passing $null as a value for parameter SavingsPlansType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TermInYear = this.TermInYear;
            #if MODULAR
            if (this.TermInYear == null && ParameterWasBound(nameof(this.TermInYear)))
            {
                WriteWarning("You are passing $null as a value for parameter TermInYear which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.CostExplorer.Model.GetSavingsPlansPurchaseRecommendationRequest();
            
            if (cmdletContext.AccountScope != null)
            {
                request.AccountScope = cmdletContext.AccountScope;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.LookbackPeriodInDay != null)
            {
                request.LookbackPeriodInDays = cmdletContext.LookbackPeriodInDay;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
            }
            if (cmdletContext.PaymentOption != null)
            {
                request.PaymentOption = cmdletContext.PaymentOption;
            }
            if (cmdletContext.SavingsPlansType != null)
            {
                request.SavingsPlansType = cmdletContext.SavingsPlansType;
            }
            if (cmdletContext.TermInYear != null)
            {
                request.TermInYears = cmdletContext.TermInYear;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CostExplorer.Model.GetSavingsPlansPurchaseRecommendationResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetSavingsPlansPurchaseRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetSavingsPlansPurchaseRecommendation");
            try
            {
                #if DESKTOP
                return client.GetSavingsPlansPurchaseRecommendation(request);
                #elif CORECLR
                return client.GetSavingsPlansPurchaseRecommendationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CostExplorer.AccountScope AccountScope { get; set; }
            public Amazon.CostExplorer.Model.Expression Filter { get; set; }
            public Amazon.CostExplorer.LookbackPeriodInDays LookbackPeriodInDay { get; set; }
            public System.String NextPageToken { get; set; }
            public System.Int32? PageSize { get; set; }
            public Amazon.CostExplorer.PaymentOption PaymentOption { get; set; }
            public Amazon.CostExplorer.SupportedSavingsPlansType SavingsPlansType { get; set; }
            public Amazon.CostExplorer.TermInYears TermInYear { get; set; }
            public System.Func<Amazon.CostExplorer.Model.GetSavingsPlansPurchaseRecommendationResponse, GetCESavingsPlansPurchaseRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

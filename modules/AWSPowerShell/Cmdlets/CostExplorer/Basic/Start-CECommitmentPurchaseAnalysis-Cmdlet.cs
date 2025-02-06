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
    /// Specifies the parameters of a planned commitment purchase and starts the generation
    /// of the analysis. This enables you to estimate the cost, coverage, and utilization
    /// impact of your planned commitment purchases.
    /// </summary>
    [Cmdlet("Start", "CECommitmentPurchaseAnalysis", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CostExplorer.Model.StartCommitmentPurchaseAnalysisResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer StartCommitmentPurchaseAnalysis API operation.", Operation = new[] {"StartCommitmentPurchaseAnalysis"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.StartCommitmentPurchaseAnalysisResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.StartCommitmentPurchaseAnalysisResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.StartCommitmentPurchaseAnalysisResponse object containing multiple properties."
    )]
    public partial class StartCECommitmentPurchaseAnalysisCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SavingsPlansPurchaseAnalysisConfiguration_AccountId
        /// <summary>
        /// <para>
        /// <para>The account that the analysis is for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_AccountId")]
        public System.String SavingsPlansPurchaseAnalysisConfiguration_AccountId { get; set; }
        #endregion
        
        #region Parameter SavingsPlansPurchaseAnalysisConfiguration_AccountScope
        /// <summary>
        /// <para>
        /// <para>The account scope that you want your analysis for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_AccountScope")]
        [AWSConstantClassSource("Amazon.CostExplorer.AccountScope")]
        public Amazon.CostExplorer.AccountScope SavingsPlansPurchaseAnalysisConfiguration_AccountScope { get; set; }
        #endregion
        
        #region Parameter SavingsPlansPurchaseAnalysisConfiguration_AnalysisType
        /// <summary>
        /// <para>
        /// <para>The type of analysis.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_AnalysisType")]
        [AWSConstantClassSource("Amazon.CostExplorer.AnalysisType")]
        public Amazon.CostExplorer.AnalysisType SavingsPlansPurchaseAnalysisConfiguration_AnalysisType { get; set; }
        #endregion
        
        #region Parameter SavingsPlansPurchaseAnalysisConfiguration_LookBackTimePeriod
        /// <summary>
        /// <para>
        /// <para>The time period associated with the analysis.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_LookBackTimePeriod")]
        public Amazon.CostExplorer.Model.DateInterval SavingsPlansPurchaseAnalysisConfiguration_LookBackTimePeriod { get; set; }
        #endregion
        
        #region Parameter SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd
        /// <summary>
        /// <para>
        /// <para>Savings Plans to include in the analysis.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd")]
        public Amazon.CostExplorer.Model.SavingsPlans[] SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd { get; set; }
        #endregion
        
        #region Parameter SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude
        /// <summary>
        /// <para>
        /// <para>Savings Plans to exclude from the analysis.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude")]
        public System.String[] SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.StartCommitmentPurchaseAnalysisResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.StartCommitmentPurchaseAnalysisResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SavingsPlansPurchaseAnalysisConfiguration_AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CECommitmentPurchaseAnalysis (StartCommitmentPurchaseAnalysis)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.StartCommitmentPurchaseAnalysisResponse, StartCECommitmentPurchaseAnalysisCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SavingsPlansPurchaseAnalysisConfiguration_AccountId = this.SavingsPlansPurchaseAnalysisConfiguration_AccountId;
            context.SavingsPlansPurchaseAnalysisConfiguration_AccountScope = this.SavingsPlansPurchaseAnalysisConfiguration_AccountScope;
            context.SavingsPlansPurchaseAnalysisConfiguration_AnalysisType = this.SavingsPlansPurchaseAnalysisConfiguration_AnalysisType;
            context.SavingsPlansPurchaseAnalysisConfiguration_LookBackTimePeriod = this.SavingsPlansPurchaseAnalysisConfiguration_LookBackTimePeriod;
            if (this.SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd != null)
            {
                context.SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd = new List<Amazon.CostExplorer.Model.SavingsPlans>(this.SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd);
            }
            if (this.SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude != null)
            {
                context.SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude = new List<System.String>(this.SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude);
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
            // create request
            var request = new Amazon.CostExplorer.Model.StartCommitmentPurchaseAnalysisRequest();
            
            
             // populate CommitmentPurchaseAnalysisConfiguration
            var requestCommitmentPurchaseAnalysisConfigurationIsNull = true;
            request.CommitmentPurchaseAnalysisConfiguration = new Amazon.CostExplorer.Model.CommitmentPurchaseAnalysisConfiguration();
            Amazon.CostExplorer.Model.SavingsPlansPurchaseAnalysisConfiguration requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration = null;
            
             // populate SavingsPlansPurchaseAnalysisConfiguration
            var requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfigurationIsNull = true;
            requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration = new Amazon.CostExplorer.Model.SavingsPlansPurchaseAnalysisConfiguration();
            System.String requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_AccountId = null;
            if (cmdletContext.SavingsPlansPurchaseAnalysisConfiguration_AccountId != null)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_AccountId = cmdletContext.SavingsPlansPurchaseAnalysisConfiguration_AccountId;
            }
            if (requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_AccountId != null)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration.AccountId = requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_AccountId;
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfigurationIsNull = false;
            }
            Amazon.CostExplorer.AccountScope requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_AccountScope = null;
            if (cmdletContext.SavingsPlansPurchaseAnalysisConfiguration_AccountScope != null)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_AccountScope = cmdletContext.SavingsPlansPurchaseAnalysisConfiguration_AccountScope;
            }
            if (requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_AccountScope != null)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration.AccountScope = requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_AccountScope;
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfigurationIsNull = false;
            }
            Amazon.CostExplorer.AnalysisType requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_AnalysisType = null;
            if (cmdletContext.SavingsPlansPurchaseAnalysisConfiguration_AnalysisType != null)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_AnalysisType = cmdletContext.SavingsPlansPurchaseAnalysisConfiguration_AnalysisType;
            }
            if (requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_AnalysisType != null)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration.AnalysisType = requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_AnalysisType;
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfigurationIsNull = false;
            }
            Amazon.CostExplorer.Model.DateInterval requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_LookBackTimePeriod = null;
            if (cmdletContext.SavingsPlansPurchaseAnalysisConfiguration_LookBackTimePeriod != null)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_LookBackTimePeriod = cmdletContext.SavingsPlansPurchaseAnalysisConfiguration_LookBackTimePeriod;
            }
            if (requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_LookBackTimePeriod != null)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration.LookBackTimePeriod = requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_LookBackTimePeriod;
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfigurationIsNull = false;
            }
            List<Amazon.CostExplorer.Model.SavingsPlans> requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd = null;
            if (cmdletContext.SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd != null)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd = cmdletContext.SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd;
            }
            if (requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd != null)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration.SavingsPlansToAdd = requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd;
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfigurationIsNull = false;
            }
            List<System.String> requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude = null;
            if (cmdletContext.SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude != null)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude = cmdletContext.SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude;
            }
            if (requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude != null)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration.SavingsPlansToExclude = requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration_savingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude;
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfigurationIsNull = false;
            }
             // determine if requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration should be set to null
            if (requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfigurationIsNull)
            {
                requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration = null;
            }
            if (requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration != null)
            {
                request.CommitmentPurchaseAnalysisConfiguration.SavingsPlansPurchaseAnalysisConfiguration = requestCommitmentPurchaseAnalysisConfiguration_commitmentPurchaseAnalysisConfiguration_SavingsPlansPurchaseAnalysisConfiguration;
                requestCommitmentPurchaseAnalysisConfigurationIsNull = false;
            }
             // determine if request.CommitmentPurchaseAnalysisConfiguration should be set to null
            if (requestCommitmentPurchaseAnalysisConfigurationIsNull)
            {
                request.CommitmentPurchaseAnalysisConfiguration = null;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CostExplorer.Model.StartCommitmentPurchaseAnalysisResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.StartCommitmentPurchaseAnalysisRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "StartCommitmentPurchaseAnalysis");
            try
            {
                #if DESKTOP
                return client.StartCommitmentPurchaseAnalysis(request);
                #elif CORECLR
                return client.StartCommitmentPurchaseAnalysisAsync(request).GetAwaiter().GetResult();
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
            public System.String SavingsPlansPurchaseAnalysisConfiguration_AccountId { get; set; }
            public Amazon.CostExplorer.AccountScope SavingsPlansPurchaseAnalysisConfiguration_AccountScope { get; set; }
            public Amazon.CostExplorer.AnalysisType SavingsPlansPurchaseAnalysisConfiguration_AnalysisType { get; set; }
            public Amazon.CostExplorer.Model.DateInterval SavingsPlansPurchaseAnalysisConfiguration_LookBackTimePeriod { get; set; }
            public List<Amazon.CostExplorer.Model.SavingsPlans> SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToAdd { get; set; }
            public List<System.String> SavingsPlansPurchaseAnalysisConfiguration_SavingsPlansToExclude { get; set; }
            public System.Func<Amazon.CostExplorer.Model.StartCommitmentPurchaseAnalysisResponse, StartCECommitmentPurchaseAnalysisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

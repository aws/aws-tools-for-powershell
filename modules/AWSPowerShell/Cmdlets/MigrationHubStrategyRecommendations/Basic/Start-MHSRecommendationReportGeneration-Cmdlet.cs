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
using Amazon.MigrationHubStrategyRecommendations;
using Amazon.MigrationHubStrategyRecommendations.Model;

namespace Amazon.PowerShell.Cmdlets.MHS
{
    /// <summary>
    /// Starts generating a recommendation report.
    /// </summary>
    [Cmdlet("Start", "MHSRecommendationReportGeneration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Migration Hub Strategy Recommendations StartRecommendationReportGeneration API operation.", Operation = new[] {"StartRecommendationReportGeneration"}, SelectReturnType = typeof(Amazon.MigrationHubStrategyRecommendations.Model.StartRecommendationReportGenerationResponse))]
    [AWSCmdletOutput("System.String or Amazon.MigrationHubStrategyRecommendations.Model.StartRecommendationReportGenerationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MigrationHubStrategyRecommendations.Model.StartRecommendationReportGenerationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartMHSRecommendationReportGenerationCmdlet : AmazonMigrationHubStrategyRecommendationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GroupIdFilter
        /// <summary>
        /// <para>
        /// <para> Groups the resources in the recommendation report with a unique name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MigrationHubStrategyRecommendations.Model.Group[] GroupIdFilter { get; set; }
        #endregion
        
        #region Parameter OutputFormat
        /// <summary>
        /// <para>
        /// <para> The output format for the recommendation report file. The default format is Microsoft
        /// Excel. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.OutputFormat")]
        public Amazon.MigrationHubStrategyRecommendations.OutputFormat OutputFormat { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Id'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubStrategyRecommendations.Model.StartRecommendationReportGenerationResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubStrategyRecommendations.Model.StartRecommendationReportGenerationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Id";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OutputFormat parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OutputFormat' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OutputFormat' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutputFormat), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-MHSRecommendationReportGeneration (StartRecommendationReportGeneration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHubStrategyRecommendations.Model.StartRecommendationReportGenerationResponse, StartMHSRecommendationReportGenerationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OutputFormat;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.GroupIdFilter != null)
            {
                context.GroupIdFilter = new List<Amazon.MigrationHubStrategyRecommendations.Model.Group>(this.GroupIdFilter);
            }
            context.OutputFormat = this.OutputFormat;
            
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
            var request = new Amazon.MigrationHubStrategyRecommendations.Model.StartRecommendationReportGenerationRequest();
            
            if (cmdletContext.GroupIdFilter != null)
            {
                request.GroupIdFilter = cmdletContext.GroupIdFilter;
            }
            if (cmdletContext.OutputFormat != null)
            {
                request.OutputFormat = cmdletContext.OutputFormat;
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
        
        private Amazon.MigrationHubStrategyRecommendations.Model.StartRecommendationReportGenerationResponse CallAWSServiceOperation(IAmazonMigrationHubStrategyRecommendations client, Amazon.MigrationHubStrategyRecommendations.Model.StartRecommendationReportGenerationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Migration Hub Strategy Recommendations", "StartRecommendationReportGeneration");
            try
            {
                #if DESKTOP
                return client.StartRecommendationReportGeneration(request);
                #elif CORECLR
                return client.StartRecommendationReportGenerationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.MigrationHubStrategyRecommendations.Model.Group> GroupIdFilter { get; set; }
            public Amazon.MigrationHubStrategyRecommendations.OutputFormat OutputFormat { get; set; }
            public System.Func<Amazon.MigrationHubStrategyRecommendations.Model.StartRecommendationReportGenerationResponse, StartMHSRecommendationReportGenerationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Id;
        }
        
    }
}

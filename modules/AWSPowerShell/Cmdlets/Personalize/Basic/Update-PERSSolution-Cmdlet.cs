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
using Amazon.Personalize;
using Amazon.Personalize.Model;

namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// Updates an Amazon Personalize solution to use a different automatic training configuration.
    /// When you update a solution, you can change whether the solution uses automatic training,
    /// and you can change the training frequency. For more information about updating a solution,
    /// see <a href="https://docs.aws.amazon.com/personalize/latest/dg/updating-solution.html">Updating
    /// a solution</a>.
    /// 
    ///  
    /// <para>
    /// A solution update can be in one of the following states:
    /// </para><para>
    /// CREATE PENDING &gt; CREATE IN_PROGRESS &gt; ACTIVE -or- CREATE FAILED
    /// </para><para>
    /// To get the status of a solution update, call the <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeSolution.html">DescribeSolution</a>
    /// API operation and find the status in the <c>latestSolutionUpdate</c>. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "PERSSolution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Personalize UpdateSolution API operation.", Operation = new[] {"UpdateSolution"}, SelectReturnType = typeof(Amazon.Personalize.Model.UpdateSolutionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Personalize.Model.UpdateSolutionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Personalize.Model.UpdateSolutionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePERSSolutionCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PerformAutoTraining
        /// <summary>
        /// <para>
        /// <para>Whether the solution uses automatic training to create new solution versions (trained
        /// models). You can change the training frequency by specifying a <c>schedulingExpression</c>
        /// in the <c>AutoTrainingConfig</c> as part of solution configuration. </para><para> If you turn on automatic training, the first automatic training starts within one
        /// hour after the solution update completes. If you manually create a solution version
        /// within the hour, the solution skips the first automatic training. For more information
        /// about automatic training, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/solution-config-auto-training.html">Configuring
        /// automatic training</a>. </para><para> After training starts, you can get the solution version's Amazon Resource Name (ARN)
        /// with the <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_ListSolutionVersions.html">ListSolutionVersions</a>
        /// API operation. To get its status, use the <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeSolutionVersion.html">DescribeSolutionVersion</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PerformAutoTraining { get; set; }
        #endregion
        
        #region Parameter AutoTrainingConfig_SchedulingExpression
        /// <summary>
        /// <para>
        /// <para>Specifies how often to automatically train new solution versions. Specify a rate expression
        /// in rate(<i>value</i><i>unit</i>) format. For value, specify a number between 1 and
        /// 30. For unit, specify <c>day</c> or <c>days</c>. For example, to automatically create
        /// a new solution version every 5 days, specify <c>rate(5 days)</c>. The default is every
        /// 7 days.</para><para>For more information about auto training, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/customizing-solution-config.html">Creating
        /// and configuring a solution</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SolutionUpdateConfig_AutoTrainingConfig_SchedulingExpression")]
        public System.String AutoTrainingConfig_SchedulingExpression { get; set; }
        #endregion
        
        #region Parameter SolutionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the solution to update.</para>
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
        public System.String SolutionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SolutionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.UpdateSolutionResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.UpdateSolutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SolutionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SolutionArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SolutionArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SolutionArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SolutionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PERSSolution (UpdateSolution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.UpdateSolutionResponse, UpdatePERSSolutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SolutionArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PerformAutoTraining = this.PerformAutoTraining;
            context.SolutionArn = this.SolutionArn;
            #if MODULAR
            if (this.SolutionArn == null && ParameterWasBound(nameof(this.SolutionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SolutionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoTrainingConfig_SchedulingExpression = this.AutoTrainingConfig_SchedulingExpression;
            
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
            var request = new Amazon.Personalize.Model.UpdateSolutionRequest();
            
            if (cmdletContext.PerformAutoTraining != null)
            {
                request.PerformAutoTraining = cmdletContext.PerformAutoTraining.Value;
            }
            if (cmdletContext.SolutionArn != null)
            {
                request.SolutionArn = cmdletContext.SolutionArn;
            }
            
             // populate SolutionUpdateConfig
            var requestSolutionUpdateConfigIsNull = true;
            request.SolutionUpdateConfig = new Amazon.Personalize.Model.SolutionUpdateConfig();
            Amazon.Personalize.Model.AutoTrainingConfig requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfig = null;
            
             // populate AutoTrainingConfig
            var requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfigIsNull = true;
            requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfig = new Amazon.Personalize.Model.AutoTrainingConfig();
            System.String requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfig_autoTrainingConfig_SchedulingExpression = null;
            if (cmdletContext.AutoTrainingConfig_SchedulingExpression != null)
            {
                requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfig_autoTrainingConfig_SchedulingExpression = cmdletContext.AutoTrainingConfig_SchedulingExpression;
            }
            if (requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfig_autoTrainingConfig_SchedulingExpression != null)
            {
                requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfig.SchedulingExpression = requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfig_autoTrainingConfig_SchedulingExpression;
                requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfigIsNull = false;
            }
             // determine if requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfig should be set to null
            if (requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfigIsNull)
            {
                requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfig = null;
            }
            if (requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfig != null)
            {
                request.SolutionUpdateConfig.AutoTrainingConfig = requestSolutionUpdateConfig_solutionUpdateConfig_AutoTrainingConfig;
                requestSolutionUpdateConfigIsNull = false;
            }
             // determine if request.SolutionUpdateConfig should be set to null
            if (requestSolutionUpdateConfigIsNull)
            {
                request.SolutionUpdateConfig = null;
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
        
        private Amazon.Personalize.Model.UpdateSolutionResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.UpdateSolutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "UpdateSolution");
            try
            {
                #if DESKTOP
                return client.UpdateSolution(request);
                #elif CORECLR
                return client.UpdateSolutionAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? PerformAutoTraining { get; set; }
            public System.String SolutionArn { get; set; }
            public System.String AutoTrainingConfig_SchedulingExpression { get; set; }
            public System.Func<Amazon.Personalize.Model.UpdateSolutionResponse, UpdatePERSSolutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SolutionArn;
        }
        
    }
}

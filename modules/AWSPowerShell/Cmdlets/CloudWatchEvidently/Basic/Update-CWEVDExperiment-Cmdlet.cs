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
using Amazon.CloudWatchEvidently;
using Amazon.CloudWatchEvidently.Model;

namespace Amazon.PowerShell.Cmdlets.CWEVD
{
    /// <summary>
    /// Updates an Evidently experiment. 
    /// 
    ///  
    /// <para>
    /// Don't use this operation to update an experiment's tag. Instead, use <a href="https://docs.aws.amazon.com/cloudwatchevidently/latest/APIReference/API_TagResource.html">TagResource</a>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CWEVDExperiment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvidently.Model.Experiment")]
    [AWSCmdlet("Calls the Amazon CloudWatch Evidently UpdateExperiment API operation.", Operation = new[] {"UpdateExperiment"}, SelectReturnType = typeof(Amazon.CloudWatchEvidently.Model.UpdateExperimentResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvidently.Model.Experiment or Amazon.CloudWatchEvidently.Model.UpdateExperimentResponse",
        "This cmdlet returns an Amazon.CloudWatchEvidently.Model.Experiment object.",
        "The service call response (type Amazon.CloudWatchEvidently.Model.UpdateExperimentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCWEVDExperimentCmdlet : AmazonCloudWatchEvidentlyClientCmdlet, IExecutor
    {
        
        #region Parameter OnlineAbConfig_ControlTreatmentName
        /// <summary>
        /// <para>
        /// <para>The name of the variation that is to be the default variation that the other variations
        /// are compared to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OnlineAbConfig_ControlTreatmentName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the experiment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Experiment
        /// <summary>
        /// <para>
        /// <para>The name of the experiment to update.</para>
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
        public System.String Experiment { get; set; }
        #endregion
        
        #region Parameter MetricGoal
        /// <summary>
        /// <para>
        /// <para>An array of structures that defines the metrics used for the experiment, and whether
        /// a higher or lower value for each metric is the goal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricGoals")]
        public Amazon.CloudWatchEvidently.Model.MetricGoalConfig[] MetricGoal { get; set; }
        #endregion
        
        #region Parameter Project
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the project that contains the experiment that you want to update.</para>
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
        public System.String Project { get; set; }
        #endregion
        
        #region Parameter RandomizationSalt
        /// <summary>
        /// <para>
        /// <para>When Evidently assigns a particular user session to an experiment, it must use a randomization
        /// ID to determine which variation the user session is served. This randomization ID
        /// is a combination of the entity ID and <code>randomizationSalt</code>. If you omit
        /// <code>randomizationSalt</code>, Evidently uses the experiment name as the <code>randomizationSalt</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RandomizationSalt { get; set; }
        #endregion
        
        #region Parameter SamplingRate
        /// <summary>
        /// <para>
        /// <para>The portion of the available audience that you want to allocate to this experiment,
        /// in thousandths of a percent. The available audience is the total audience minus the
        /// audience that you have allocated to overrides or current launches of this feature.</para><para>This is represented in thousandths of a percent. For example, specify 20,000 to allocate
        /// 20% of the available audience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? SamplingRate { get; set; }
        #endregion
        
        #region Parameter Treatment
        /// <summary>
        /// <para>
        /// <para>An array of structures that define the variations being tested in the experiment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Treatments")]
        public Amazon.CloudWatchEvidently.Model.TreatmentConfig[] Treatment { get; set; }
        #endregion
        
        #region Parameter OnlineAbConfig_TreatmentWeight
        /// <summary>
        /// <para>
        /// <para>A set of key-value pairs. The keys are variation names, and the values are the portion
        /// of experiment traffic to be assigned to that variation. Specify the traffic portion
        /// in thousandths of a percent, so 20,000 for a variation would allocate 20% of the experiment
        /// traffic to that variation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnlineAbConfig_TreatmentWeights")]
        public System.Collections.Hashtable OnlineAbConfig_TreatmentWeight { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Experiment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvidently.Model.UpdateExperimentResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvidently.Model.UpdateExperimentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Experiment";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Experiment), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWEVDExperiment (UpdateExperiment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvidently.Model.UpdateExperimentResponse, UpdateCWEVDExperimentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Experiment = this.Experiment;
            #if MODULAR
            if (this.Experiment == null && ParameterWasBound(nameof(this.Experiment)))
            {
                WriteWarning("You are passing $null as a value for parameter Experiment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MetricGoal != null)
            {
                context.MetricGoal = new List<Amazon.CloudWatchEvidently.Model.MetricGoalConfig>(this.MetricGoal);
            }
            context.OnlineAbConfig_ControlTreatmentName = this.OnlineAbConfig_ControlTreatmentName;
            if (this.OnlineAbConfig_TreatmentWeight != null)
            {
                context.OnlineAbConfig_TreatmentWeight = new Dictionary<System.String, System.Int64>(StringComparer.Ordinal);
                foreach (var hashKey in this.OnlineAbConfig_TreatmentWeight.Keys)
                {
                    context.OnlineAbConfig_TreatmentWeight.Add((String)hashKey, (Int64)(this.OnlineAbConfig_TreatmentWeight[hashKey]));
                }
            }
            context.Project = this.Project;
            #if MODULAR
            if (this.Project == null && ParameterWasBound(nameof(this.Project)))
            {
                WriteWarning("You are passing $null as a value for parameter Project which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RandomizationSalt = this.RandomizationSalt;
            context.SamplingRate = this.SamplingRate;
            if (this.Treatment != null)
            {
                context.Treatment = new List<Amazon.CloudWatchEvidently.Model.TreatmentConfig>(this.Treatment);
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
            var request = new Amazon.CloudWatchEvidently.Model.UpdateExperimentRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Experiment != null)
            {
                request.Experiment = cmdletContext.Experiment;
            }
            if (cmdletContext.MetricGoal != null)
            {
                request.MetricGoals = cmdletContext.MetricGoal;
            }
            
             // populate OnlineAbConfig
            var requestOnlineAbConfigIsNull = true;
            request.OnlineAbConfig = new Amazon.CloudWatchEvidently.Model.OnlineAbConfig();
            System.String requestOnlineAbConfig_onlineAbConfig_ControlTreatmentName = null;
            if (cmdletContext.OnlineAbConfig_ControlTreatmentName != null)
            {
                requestOnlineAbConfig_onlineAbConfig_ControlTreatmentName = cmdletContext.OnlineAbConfig_ControlTreatmentName;
            }
            if (requestOnlineAbConfig_onlineAbConfig_ControlTreatmentName != null)
            {
                request.OnlineAbConfig.ControlTreatmentName = requestOnlineAbConfig_onlineAbConfig_ControlTreatmentName;
                requestOnlineAbConfigIsNull = false;
            }
            Dictionary<System.String, System.Int64> requestOnlineAbConfig_onlineAbConfig_TreatmentWeight = null;
            if (cmdletContext.OnlineAbConfig_TreatmentWeight != null)
            {
                requestOnlineAbConfig_onlineAbConfig_TreatmentWeight = cmdletContext.OnlineAbConfig_TreatmentWeight;
            }
            if (requestOnlineAbConfig_onlineAbConfig_TreatmentWeight != null)
            {
                request.OnlineAbConfig.TreatmentWeights = requestOnlineAbConfig_onlineAbConfig_TreatmentWeight;
                requestOnlineAbConfigIsNull = false;
            }
             // determine if request.OnlineAbConfig should be set to null
            if (requestOnlineAbConfigIsNull)
            {
                request.OnlineAbConfig = null;
            }
            if (cmdletContext.Project != null)
            {
                request.Project = cmdletContext.Project;
            }
            if (cmdletContext.RandomizationSalt != null)
            {
                request.RandomizationSalt = cmdletContext.RandomizationSalt;
            }
            if (cmdletContext.SamplingRate != null)
            {
                request.SamplingRate = cmdletContext.SamplingRate.Value;
            }
            if (cmdletContext.Treatment != null)
            {
                request.Treatments = cmdletContext.Treatment;
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
        
        private Amazon.CloudWatchEvidently.Model.UpdateExperimentResponse CallAWSServiceOperation(IAmazonCloudWatchEvidently client, Amazon.CloudWatchEvidently.Model.UpdateExperimentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Evidently", "UpdateExperiment");
            try
            {
                #if DESKTOP
                return client.UpdateExperiment(request);
                #elif CORECLR
                return client.UpdateExperimentAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Experiment { get; set; }
            public List<Amazon.CloudWatchEvidently.Model.MetricGoalConfig> MetricGoal { get; set; }
            public System.String OnlineAbConfig_ControlTreatmentName { get; set; }
            public Dictionary<System.String, System.Int64> OnlineAbConfig_TreatmentWeight { get; set; }
            public System.String Project { get; set; }
            public System.String RandomizationSalt { get; set; }
            public System.Int64? SamplingRate { get; set; }
            public List<Amazon.CloudWatchEvidently.Model.TreatmentConfig> Treatment { get; set; }
            public System.Func<Amazon.CloudWatchEvidently.Model.UpdateExperimentResponse, UpdateCWEVDExperimentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Experiment;
        }
        
    }
}

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
using Amazon.CloudWatchEvidently;
using Amazon.CloudWatchEvidently.Model;

namespace Amazon.PowerShell.Cmdlets.CWEVD
{
    /// <summary>
    /// Creates an Evidently <i>experiment</i>. Before you create an experiment, you must
    /// create the feature to use for the experiment.
    /// 
    ///  
    /// <para>
    /// An experiment helps you make feature design decisions based on evidence and data.
    /// An experiment can test as many as five variations at once. Evidently collects experiment
    /// data and analyzes it by statistical methods, and provides clear recommendations about
    /// which variations perform better.
    /// </para><para>
    /// You can optionally specify a <c>segment</c> to have the experiment consider only certain
    /// audience types in the experiment, such as using only user sessions from a certain
    /// location or who use a certain internet browser.
    /// </para><para>
    /// Don't use this operation to update an existing experiment. Instead, use <a href="https://docs.aws.amazon.com/cloudwatchevidently/latest/APIReference/API_UpdateExperiment.html">UpdateExperiment</a>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("New", "CWEVDExperiment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvidently.Model.Experiment")]
    [AWSCmdlet("Calls the Amazon CloudWatch Evidently CreateExperiment API operation.", Operation = new[] {"CreateExperiment"}, SelectReturnType = typeof(Amazon.CloudWatchEvidently.Model.CreateExperimentResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvidently.Model.Experiment or Amazon.CloudWatchEvidently.Model.CreateExperimentResponse",
        "This cmdlet returns an Amazon.CloudWatchEvidently.Model.Experiment object.",
        "The service call response (type Amazon.CloudWatchEvidently.Model.CreateExperimentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCWEVDExperimentCmdlet : AmazonCloudWatchEvidentlyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter MetricGoal
        /// <summary>
        /// <para>
        /// <para>An array of structures that defines the metrics used for the experiment, and whether
        /// a higher or lower value for each metric is the goal.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MetricGoals")]
        public Amazon.CloudWatchEvidently.Model.MetricGoalConfig[] MetricGoal { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the new experiment.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Project
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the project that you want to create the new experiment in.</para>
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
        public System.String Project { get; set; }
        #endregion
        
        #region Parameter RandomizationSalt
        /// <summary>
        /// <para>
        /// <para>When Evidently assigns a particular user session to an experiment, it must use a randomization
        /// ID to determine which variation the user session is served. This randomization ID
        /// is a combination of the entity ID and <c>randomizationSalt</c>. If you omit <c>randomizationSalt</c>,
        /// Evidently uses the experiment name as the <c>randomizationSalt</c>.</para>
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
        /// audience that you have allocated to overrides or current launches of this feature.</para><para>This is represented in thousandths of a percent. For example, specify 10,000 to allocate
        /// 10% of the available audience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? SamplingRate { get; set; }
        #endregion
        
        #region Parameter Segment
        /// <summary>
        /// <para>
        /// <para>Specifies an audience <i>segment</i> to use in the experiment. When a segment is used
        /// in an experiment, only user sessions that match the segment pattern are used in the
        /// experiment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Segment { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Assigns one or more tags (key-value pairs) to the experiment.</para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions by granting a user permission to access or change only resources
        /// with certain tag values.</para><para>Tags don't have any semantic meaning to Amazon Web Services and are interpreted strictly
        /// as strings of characters.</para><para>You can associate as many as 50 tags with an experiment.</para><para>For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Treatment
        /// <summary>
        /// <para>
        /// <para>An array of structures that describe the configuration of each feature variation used
        /// in the experiment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvidently.Model.CreateExperimentResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvidently.Model.CreateExperimentResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWEVDExperiment (CreateExperiment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvidently.Model.CreateExperimentResponse, NewCWEVDExperimentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            if (this.MetricGoal != null)
            {
                context.MetricGoal = new List<Amazon.CloudWatchEvidently.Model.MetricGoalConfig>(this.MetricGoal);
            }
            #if MODULAR
            if (this.MetricGoal == null && ParameterWasBound(nameof(this.MetricGoal)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricGoal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OnlineAbConfig_ControlTreatmentName = this.OnlineAbConfig_ControlTreatmentName;
            if (this.OnlineAbConfig_TreatmentWeight != null)
            {
                context.OnlineAbConfig_TreatmentWeight = new Dictionary<System.String, System.Int64>(StringComparer.Ordinal);
                foreach (var hashKey in this.OnlineAbConfig_TreatmentWeight.Keys)
                {
                    context.OnlineAbConfig_TreatmentWeight.Add((String)hashKey, (System.Int64)(this.OnlineAbConfig_TreatmentWeight[hashKey]));
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
            context.Segment = this.Segment;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.Treatment != null)
            {
                context.Treatment = new List<Amazon.CloudWatchEvidently.Model.TreatmentConfig>(this.Treatment);
            }
            #if MODULAR
            if (this.Treatment == null && ParameterWasBound(nameof(this.Treatment)))
            {
                WriteWarning("You are passing $null as a value for parameter Treatment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            // create request
            var request = new Amazon.CloudWatchEvidently.Model.CreateExperimentRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MetricGoal != null)
            {
                request.MetricGoals = cmdletContext.MetricGoal;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
            if (cmdletContext.Segment != null)
            {
                request.Segment = cmdletContext.Segment;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CloudWatchEvidently.Model.CreateExperimentResponse CallAWSServiceOperation(IAmazonCloudWatchEvidently client, Amazon.CloudWatchEvidently.Model.CreateExperimentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Evidently", "CreateExperiment");
            try
            {
                #if DESKTOP
                return client.CreateExperiment(request);
                #elif CORECLR
                return client.CreateExperimentAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudWatchEvidently.Model.MetricGoalConfig> MetricGoal { get; set; }
            public System.String Name { get; set; }
            public System.String OnlineAbConfig_ControlTreatmentName { get; set; }
            public Dictionary<System.String, System.Int64> OnlineAbConfig_TreatmentWeight { get; set; }
            public System.String Project { get; set; }
            public System.String RandomizationSalt { get; set; }
            public System.Int64? SamplingRate { get; set; }
            public System.String Segment { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<Amazon.CloudWatchEvidently.Model.TreatmentConfig> Treatment { get; set; }
            public System.Func<Amazon.CloudWatchEvidently.Model.CreateExperimentResponse, NewCWEVDExperimentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Experiment;
        }
        
    }
}

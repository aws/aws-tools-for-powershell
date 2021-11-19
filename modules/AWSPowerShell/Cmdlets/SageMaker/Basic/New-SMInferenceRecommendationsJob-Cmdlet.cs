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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Starts a recommendation job. You can create either an instance recommendation or load
    /// test job.
    /// </summary>
    [Cmdlet("New", "SMInferenceRecommendationsJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateInferenceRecommendationsJob API operation.", Operation = new[] {"CreateInferenceRecommendationsJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMInferenceRecommendationsJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter InputConfig_EndpointConfiguration
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint configuration to use for a job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_EndpointConfigurations")]
        public Amazon.SageMaker.Model.EndpointInputConfiguration[] InputConfig_EndpointConfiguration { get; set; }
        #endregion
        
        #region Parameter JobDescription
        /// <summary>
        /// <para>
        /// <para>Description of the recommendation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobDescription { get; set; }
        #endregion
        
        #region Parameter InputConfig_JobDurationInSecond
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum duration of the job, in seconds.&gt;</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_JobDurationInSeconds")]
        public System.Int32? InputConfig_JobDurationInSecond { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>A name for the recommendation job. The name must be unique within the Amazon Web Services
        /// Region and within your Amazon Web Services account.</para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter JobType
        /// <summary>
        /// <para>
        /// <para>Defines the type of recommendation job. Specify <code>Default</code> to initiate an
        /// instance recommendation and <code>Advanced</code> to initiate a load test. If left
        /// unspecified, Amazon SageMaker Inference Recommender will run an instance recommendation
        /// (<code>DEFAULT</code>) job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.RecommendationJobType")]
        public Amazon.SageMaker.RecommendationJobType JobType { get; set; }
        #endregion
        
        #region Parameter StoppingConditions_MaxInvocation
        /// <summary>
        /// <para>
        /// <para>The maximum number of requests per minute expected for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingConditions_MaxInvocations")]
        public System.Int32? StoppingConditions_MaxInvocation { get; set; }
        #endregion
        
        #region Parameter ResourceLimit_MaxNumberOfTest
        /// <summary>
        /// <para>
        /// <para>Defines the maximum number of load tests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ResourceLimit_MaxNumberOfTests")]
        public System.Int32? ResourceLimit_MaxNumberOfTest { get; set; }
        #endregion
        
        #region Parameter ResourceLimit_MaxParallelOfTest
        /// <summary>
        /// <para>
        /// <para>Defines the maximum number of parallel load tests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_ResourceLimit_MaxParallelOfTests")]
        public System.Int32? ResourceLimit_MaxParallelOfTest { get; set; }
        #endregion
        
        #region Parameter StoppingConditions_ModelLatencyThreshold
        /// <summary>
        /// <para>
        /// <para>The interval of time taken by a model to respond as viewed from SageMaker. The interval
        /// includes the local communication time taken to send the request and to fetch the response
        /// from the container of a model and the time taken to complete the inference in the
        /// container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingConditions_ModelLatencyThresholds")]
        public Amazon.SageMaker.Model.ModelLatencyThreshold[] StoppingConditions_ModelLatencyThreshold { get; set; }
        #endregion
        
        #region Parameter InputConfig_ModelPackageVersionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a versioned model package.</para>
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
        public System.String InputConfig_ModelPackageVersionArn { get; set; }
        #endregion
        
        #region Parameter TrafficPattern_Phase
        /// <summary>
        /// <para>
        /// <para>Defines the phases traffic specification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_TrafficPattern_Phases")]
        public Amazon.SageMaker.Model.Phase[] TrafficPattern_Phase { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that enables Amazon SageMaker to perform
        /// tasks on your behalf.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to Amazon Web Services resources to help you categorize
        /// and organize them. Each tag consists of a key and a value, both of which you define.
        /// For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a> in the Amazon Web Services General Reference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrafficPattern_TrafficType
        /// <summary>
        /// <para>
        /// <para>Defines the traffic patterns.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_TrafficPattern_TrafficType")]
        [AWSConstantClassSource("Amazon.SageMaker.TrafficType")]
        public Amazon.SageMaker.TrafficType TrafficPattern_TrafficType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMInferenceRecommendationsJob (CreateInferenceRecommendationsJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse, NewSMInferenceRecommendationsJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.InputConfig_EndpointConfiguration != null)
            {
                context.InputConfig_EndpointConfiguration = new List<Amazon.SageMaker.Model.EndpointInputConfiguration>(this.InputConfig_EndpointConfiguration);
            }
            context.InputConfig_JobDurationInSecond = this.InputConfig_JobDurationInSecond;
            context.InputConfig_ModelPackageVersionArn = this.InputConfig_ModelPackageVersionArn;
            #if MODULAR
            if (this.InputConfig_ModelPackageVersionArn == null && ParameterWasBound(nameof(this.InputConfig_ModelPackageVersionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InputConfig_ModelPackageVersionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceLimit_MaxNumberOfTest = this.ResourceLimit_MaxNumberOfTest;
            context.ResourceLimit_MaxParallelOfTest = this.ResourceLimit_MaxParallelOfTest;
            if (this.TrafficPattern_Phase != null)
            {
                context.TrafficPattern_Phase = new List<Amazon.SageMaker.Model.Phase>(this.TrafficPattern_Phase);
            }
            context.TrafficPattern_TrafficType = this.TrafficPattern_TrafficType;
            context.JobDescription = this.JobDescription;
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobType = this.JobType;
            #if MODULAR
            if (this.JobType == null && ParameterWasBound(nameof(this.JobType)))
            {
                WriteWarning("You are passing $null as a value for parameter JobType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StoppingConditions_MaxInvocation = this.StoppingConditions_MaxInvocation;
            if (this.StoppingConditions_ModelLatencyThreshold != null)
            {
                context.StoppingConditions_ModelLatencyThreshold = new List<Amazon.SageMaker.Model.ModelLatencyThreshold>(this.StoppingConditions_ModelLatencyThreshold);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateInferenceRecommendationsJobRequest();
            
            
             // populate InputConfig
            var requestInputConfigIsNull = true;
            request.InputConfig = new Amazon.SageMaker.Model.RecommendationJobInputConfig();
            List<Amazon.SageMaker.Model.EndpointInputConfiguration> requestInputConfig_inputConfig_EndpointConfiguration = null;
            if (cmdletContext.InputConfig_EndpointConfiguration != null)
            {
                requestInputConfig_inputConfig_EndpointConfiguration = cmdletContext.InputConfig_EndpointConfiguration;
            }
            if (requestInputConfig_inputConfig_EndpointConfiguration != null)
            {
                request.InputConfig.EndpointConfigurations = requestInputConfig_inputConfig_EndpointConfiguration;
                requestInputConfigIsNull = false;
            }
            System.Int32? requestInputConfig_inputConfig_JobDurationInSecond = null;
            if (cmdletContext.InputConfig_JobDurationInSecond != null)
            {
                requestInputConfig_inputConfig_JobDurationInSecond = cmdletContext.InputConfig_JobDurationInSecond.Value;
            }
            if (requestInputConfig_inputConfig_JobDurationInSecond != null)
            {
                request.InputConfig.JobDurationInSeconds = requestInputConfig_inputConfig_JobDurationInSecond.Value;
                requestInputConfigIsNull = false;
            }
            System.String requestInputConfig_inputConfig_ModelPackageVersionArn = null;
            if (cmdletContext.InputConfig_ModelPackageVersionArn != null)
            {
                requestInputConfig_inputConfig_ModelPackageVersionArn = cmdletContext.InputConfig_ModelPackageVersionArn;
            }
            if (requestInputConfig_inputConfig_ModelPackageVersionArn != null)
            {
                request.InputConfig.ModelPackageVersionArn = requestInputConfig_inputConfig_ModelPackageVersionArn;
                requestInputConfigIsNull = false;
            }
            Amazon.SageMaker.Model.RecommendationJobResourceLimit requestInputConfig_inputConfig_ResourceLimit = null;
            
             // populate ResourceLimit
            var requestInputConfig_inputConfig_ResourceLimitIsNull = true;
            requestInputConfig_inputConfig_ResourceLimit = new Amazon.SageMaker.Model.RecommendationJobResourceLimit();
            System.Int32? requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxNumberOfTest = null;
            if (cmdletContext.ResourceLimit_MaxNumberOfTest != null)
            {
                requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxNumberOfTest = cmdletContext.ResourceLimit_MaxNumberOfTest.Value;
            }
            if (requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxNumberOfTest != null)
            {
                requestInputConfig_inputConfig_ResourceLimit.MaxNumberOfTests = requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxNumberOfTest.Value;
                requestInputConfig_inputConfig_ResourceLimitIsNull = false;
            }
            System.Int32? requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxParallelOfTest = null;
            if (cmdletContext.ResourceLimit_MaxParallelOfTest != null)
            {
                requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxParallelOfTest = cmdletContext.ResourceLimit_MaxParallelOfTest.Value;
            }
            if (requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxParallelOfTest != null)
            {
                requestInputConfig_inputConfig_ResourceLimit.MaxParallelOfTests = requestInputConfig_inputConfig_ResourceLimit_resourceLimit_MaxParallelOfTest.Value;
                requestInputConfig_inputConfig_ResourceLimitIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_ResourceLimit should be set to null
            if (requestInputConfig_inputConfig_ResourceLimitIsNull)
            {
                requestInputConfig_inputConfig_ResourceLimit = null;
            }
            if (requestInputConfig_inputConfig_ResourceLimit != null)
            {
                request.InputConfig.ResourceLimit = requestInputConfig_inputConfig_ResourceLimit;
                requestInputConfigIsNull = false;
            }
            Amazon.SageMaker.Model.TrafficPattern requestInputConfig_inputConfig_TrafficPattern = null;
            
             // populate TrafficPattern
            var requestInputConfig_inputConfig_TrafficPatternIsNull = true;
            requestInputConfig_inputConfig_TrafficPattern = new Amazon.SageMaker.Model.TrafficPattern();
            List<Amazon.SageMaker.Model.Phase> requestInputConfig_inputConfig_TrafficPattern_trafficPattern_Phase = null;
            if (cmdletContext.TrafficPattern_Phase != null)
            {
                requestInputConfig_inputConfig_TrafficPattern_trafficPattern_Phase = cmdletContext.TrafficPattern_Phase;
            }
            if (requestInputConfig_inputConfig_TrafficPattern_trafficPattern_Phase != null)
            {
                requestInputConfig_inputConfig_TrafficPattern.Phases = requestInputConfig_inputConfig_TrafficPattern_trafficPattern_Phase;
                requestInputConfig_inputConfig_TrafficPatternIsNull = false;
            }
            Amazon.SageMaker.TrafficType requestInputConfig_inputConfig_TrafficPattern_trafficPattern_TrafficType = null;
            if (cmdletContext.TrafficPattern_TrafficType != null)
            {
                requestInputConfig_inputConfig_TrafficPattern_trafficPattern_TrafficType = cmdletContext.TrafficPattern_TrafficType;
            }
            if (requestInputConfig_inputConfig_TrafficPattern_trafficPattern_TrafficType != null)
            {
                requestInputConfig_inputConfig_TrafficPattern.TrafficType = requestInputConfig_inputConfig_TrafficPattern_trafficPattern_TrafficType;
                requestInputConfig_inputConfig_TrafficPatternIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_TrafficPattern should be set to null
            if (requestInputConfig_inputConfig_TrafficPatternIsNull)
            {
                requestInputConfig_inputConfig_TrafficPattern = null;
            }
            if (requestInputConfig_inputConfig_TrafficPattern != null)
            {
                request.InputConfig.TrafficPattern = requestInputConfig_inputConfig_TrafficPattern;
                requestInputConfigIsNull = false;
            }
             // determine if request.InputConfig should be set to null
            if (requestInputConfigIsNull)
            {
                request.InputConfig = null;
            }
            if (cmdletContext.JobDescription != null)
            {
                request.JobDescription = cmdletContext.JobDescription;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.JobType != null)
            {
                request.JobType = cmdletContext.JobType;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate StoppingConditions
            var requestStoppingConditionsIsNull = true;
            request.StoppingConditions = new Amazon.SageMaker.Model.RecommendationJobStoppingConditions();
            System.Int32? requestStoppingConditions_stoppingConditions_MaxInvocation = null;
            if (cmdletContext.StoppingConditions_MaxInvocation != null)
            {
                requestStoppingConditions_stoppingConditions_MaxInvocation = cmdletContext.StoppingConditions_MaxInvocation.Value;
            }
            if (requestStoppingConditions_stoppingConditions_MaxInvocation != null)
            {
                request.StoppingConditions.MaxInvocations = requestStoppingConditions_stoppingConditions_MaxInvocation.Value;
                requestStoppingConditionsIsNull = false;
            }
            List<Amazon.SageMaker.Model.ModelLatencyThreshold> requestStoppingConditions_stoppingConditions_ModelLatencyThreshold = null;
            if (cmdletContext.StoppingConditions_ModelLatencyThreshold != null)
            {
                requestStoppingConditions_stoppingConditions_ModelLatencyThreshold = cmdletContext.StoppingConditions_ModelLatencyThreshold;
            }
            if (requestStoppingConditions_stoppingConditions_ModelLatencyThreshold != null)
            {
                request.StoppingConditions.ModelLatencyThresholds = requestStoppingConditions_stoppingConditions_ModelLatencyThreshold;
                requestStoppingConditionsIsNull = false;
            }
             // determine if request.StoppingConditions should be set to null
            if (requestStoppingConditionsIsNull)
            {
                request.StoppingConditions = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateInferenceRecommendationsJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateInferenceRecommendationsJob");
            try
            {
                #if DESKTOP
                return client.CreateInferenceRecommendationsJob(request);
                #elif CORECLR
                return client.CreateInferenceRecommendationsJobAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.EndpointInputConfiguration> InputConfig_EndpointConfiguration { get; set; }
            public System.Int32? InputConfig_JobDurationInSecond { get; set; }
            public System.String InputConfig_ModelPackageVersionArn { get; set; }
            public System.Int32? ResourceLimit_MaxNumberOfTest { get; set; }
            public System.Int32? ResourceLimit_MaxParallelOfTest { get; set; }
            public List<Amazon.SageMaker.Model.Phase> TrafficPattern_Phase { get; set; }
            public Amazon.SageMaker.TrafficType TrafficPattern_TrafficType { get; set; }
            public System.String JobDescription { get; set; }
            public System.String JobName { get; set; }
            public Amazon.SageMaker.RecommendationJobType JobType { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? StoppingConditions_MaxInvocation { get; set; }
            public List<Amazon.SageMaker.Model.ModelLatencyThreshold> StoppingConditions_ModelLatencyThreshold { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateInferenceRecommendationsJobResponse, NewSMInferenceRecommendationsJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobArn;
        }
        
    }
}

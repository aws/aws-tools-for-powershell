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
    /// Update a model training job to request a new Debugger profiling configuration or to
    /// change warm pool retention length.
    /// </summary>
    [Cmdlet("Update", "SMTrainingJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateTrainingJob API operation.", Operation = new[] {"UpdateTrainingJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateTrainingJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateTrainingJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateTrainingJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMTrainingJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter ProfilerConfig_DisableProfiler
        /// <summary>
        /// <para>
        /// <para>To disable Debugger monitoring and profiling, set to <code>True</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ProfilerConfig_DisableProfiler { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_KeepAlivePeriodInSecond
        /// <summary>
        /// <para>
        /// <para>The <code>KeepAlivePeriodInSeconds</code> value specified in the <code>ResourceConfig</code>
        /// to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_KeepAlivePeriodInSeconds")]
        public System.Int32? ResourceConfig_KeepAlivePeriodInSecond { get; set; }
        #endregion
        
        #region Parameter ProfilerRuleConfiguration
        /// <summary>
        /// <para>
        /// <para>Configuration information for Debugger rules for profiling system and framework metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProfilerRuleConfigurations")]
        public Amazon.SageMaker.Model.ProfilerRuleConfiguration[] ProfilerRuleConfiguration { get; set; }
        #endregion
        
        #region Parameter ProfilerConfig_ProfilingIntervalInMillisecond
        /// <summary>
        /// <para>
        /// <para>A time interval for capturing system metrics in milliseconds. Available values are
        /// 100, 200, 500, 1000 (1 second), 5000 (5 seconds), and 60000 (1 minute) milliseconds.
        /// The default value is 500 milliseconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProfilerConfig_ProfilingIntervalInMilliseconds")]
        public System.Int64? ProfilerConfig_ProfilingIntervalInMillisecond { get; set; }
        #endregion
        
        #region Parameter ProfilerConfig_ProfilingParameter
        /// <summary>
        /// <para>
        /// <para>Configuration information for capturing framework metrics. Available key strings for
        /// different profiling options are <code>DetailedProfilingConfig</code>, <code>PythonProfilingConfig</code>,
        /// and <code>DataLoaderProfilingConfig</code>. The following codes are configuration
        /// structures for the <code>ProfilingParameters</code> parameter. To learn more about
        /// how to configure the <code>ProfilingParameters</code> parameter, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/debugger-createtrainingjob-api.html">Use
        /// the SageMaker and Debugger Configuration API Operations to Create, Update, and Debug
        /// Your Training Job</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProfilerConfig_ProfilingParameters")]
        public System.Collections.Hashtable ProfilerConfig_ProfilingParameter { get; set; }
        #endregion
        
        #region Parameter ProfilerConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>Path to Amazon S3 storage location for system and framework metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProfilerConfig_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter TrainingJobName
        /// <summary>
        /// <para>
        /// <para>The name of a training job to update the Debugger profiling configuration.</para>
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
        public System.String TrainingJobName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrainingJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateTrainingJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateTrainingJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrainingJobArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrainingJobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrainingJobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrainingJobName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrainingJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMTrainingJob (UpdateTrainingJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateTrainingJobResponse, UpdateSMTrainingJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrainingJobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ProfilerConfig_DisableProfiler = this.ProfilerConfig_DisableProfiler;
            context.ProfilerConfig_ProfilingIntervalInMillisecond = this.ProfilerConfig_ProfilingIntervalInMillisecond;
            if (this.ProfilerConfig_ProfilingParameter != null)
            {
                context.ProfilerConfig_ProfilingParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ProfilerConfig_ProfilingParameter.Keys)
                {
                    context.ProfilerConfig_ProfilingParameter.Add((String)hashKey, (String)(this.ProfilerConfig_ProfilingParameter[hashKey]));
                }
            }
            context.ProfilerConfig_S3OutputPath = this.ProfilerConfig_S3OutputPath;
            if (this.ProfilerRuleConfiguration != null)
            {
                context.ProfilerRuleConfiguration = new List<Amazon.SageMaker.Model.ProfilerRuleConfiguration>(this.ProfilerRuleConfiguration);
            }
            context.ResourceConfig_KeepAlivePeriodInSecond = this.ResourceConfig_KeepAlivePeriodInSecond;
            context.TrainingJobName = this.TrainingJobName;
            #if MODULAR
            if (this.TrainingJobName == null && ParameterWasBound(nameof(this.TrainingJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.UpdateTrainingJobRequest();
            
            
             // populate ProfilerConfig
            var requestProfilerConfigIsNull = true;
            request.ProfilerConfig = new Amazon.SageMaker.Model.ProfilerConfigForUpdate();
            System.Boolean? requestProfilerConfig_profilerConfig_DisableProfiler = null;
            if (cmdletContext.ProfilerConfig_DisableProfiler != null)
            {
                requestProfilerConfig_profilerConfig_DisableProfiler = cmdletContext.ProfilerConfig_DisableProfiler.Value;
            }
            if (requestProfilerConfig_profilerConfig_DisableProfiler != null)
            {
                request.ProfilerConfig.DisableProfiler = requestProfilerConfig_profilerConfig_DisableProfiler.Value;
                requestProfilerConfigIsNull = false;
            }
            System.Int64? requestProfilerConfig_profilerConfig_ProfilingIntervalInMillisecond = null;
            if (cmdletContext.ProfilerConfig_ProfilingIntervalInMillisecond != null)
            {
                requestProfilerConfig_profilerConfig_ProfilingIntervalInMillisecond = cmdletContext.ProfilerConfig_ProfilingIntervalInMillisecond.Value;
            }
            if (requestProfilerConfig_profilerConfig_ProfilingIntervalInMillisecond != null)
            {
                request.ProfilerConfig.ProfilingIntervalInMilliseconds = requestProfilerConfig_profilerConfig_ProfilingIntervalInMillisecond.Value;
                requestProfilerConfigIsNull = false;
            }
            Dictionary<System.String, System.String> requestProfilerConfig_profilerConfig_ProfilingParameter = null;
            if (cmdletContext.ProfilerConfig_ProfilingParameter != null)
            {
                requestProfilerConfig_profilerConfig_ProfilingParameter = cmdletContext.ProfilerConfig_ProfilingParameter;
            }
            if (requestProfilerConfig_profilerConfig_ProfilingParameter != null)
            {
                request.ProfilerConfig.ProfilingParameters = requestProfilerConfig_profilerConfig_ProfilingParameter;
                requestProfilerConfigIsNull = false;
            }
            System.String requestProfilerConfig_profilerConfig_S3OutputPath = null;
            if (cmdletContext.ProfilerConfig_S3OutputPath != null)
            {
                requestProfilerConfig_profilerConfig_S3OutputPath = cmdletContext.ProfilerConfig_S3OutputPath;
            }
            if (requestProfilerConfig_profilerConfig_S3OutputPath != null)
            {
                request.ProfilerConfig.S3OutputPath = requestProfilerConfig_profilerConfig_S3OutputPath;
                requestProfilerConfigIsNull = false;
            }
             // determine if request.ProfilerConfig should be set to null
            if (requestProfilerConfigIsNull)
            {
                request.ProfilerConfig = null;
            }
            if (cmdletContext.ProfilerRuleConfiguration != null)
            {
                request.ProfilerRuleConfigurations = cmdletContext.ProfilerRuleConfiguration;
            }
            
             // populate ResourceConfig
            var requestResourceConfigIsNull = true;
            request.ResourceConfig = new Amazon.SageMaker.Model.ResourceConfigForUpdate();
            System.Int32? requestResourceConfig_resourceConfig_KeepAlivePeriodInSecond = null;
            if (cmdletContext.ResourceConfig_KeepAlivePeriodInSecond != null)
            {
                requestResourceConfig_resourceConfig_KeepAlivePeriodInSecond = cmdletContext.ResourceConfig_KeepAlivePeriodInSecond.Value;
            }
            if (requestResourceConfig_resourceConfig_KeepAlivePeriodInSecond != null)
            {
                request.ResourceConfig.KeepAlivePeriodInSeconds = requestResourceConfig_resourceConfig_KeepAlivePeriodInSecond.Value;
                requestResourceConfigIsNull = false;
            }
             // determine if request.ResourceConfig should be set to null
            if (requestResourceConfigIsNull)
            {
                request.ResourceConfig = null;
            }
            if (cmdletContext.TrainingJobName != null)
            {
                request.TrainingJobName = cmdletContext.TrainingJobName;
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
        
        private Amazon.SageMaker.Model.UpdateTrainingJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateTrainingJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateTrainingJob");
            try
            {
                #if DESKTOP
                return client.UpdateTrainingJob(request);
                #elif CORECLR
                return client.UpdateTrainingJobAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ProfilerConfig_DisableProfiler { get; set; }
            public System.Int64? ProfilerConfig_ProfilingIntervalInMillisecond { get; set; }
            public Dictionary<System.String, System.String> ProfilerConfig_ProfilingParameter { get; set; }
            public System.String ProfilerConfig_S3OutputPath { get; set; }
            public List<Amazon.SageMaker.Model.ProfilerRuleConfiguration> ProfilerRuleConfiguration { get; set; }
            public System.Int32? ResourceConfig_KeepAlivePeriodInSecond { get; set; }
            public System.String TrainingJobName { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateTrainingJobResponse, UpdateSMTrainingJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrainingJobArn;
        }
        
    }
}

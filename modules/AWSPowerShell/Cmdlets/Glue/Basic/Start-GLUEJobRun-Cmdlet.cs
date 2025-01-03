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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Starts a job run using a job definition.
    /// </summary>
    [Cmdlet("Start", "GLUEJobRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue StartJobRun API operation.", Operation = new[] {"StartJobRun"}, SelectReturnType = typeof(Amazon.Glue.Model.StartJobRunResponse))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.StartJobRunResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Glue.Model.StartJobRunResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartGLUEJobRunCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Argument
        /// <summary>
        /// <para>
        /// <para>The job arguments associated with this run. For this job run, they replace the default
        /// arguments set in the job definition itself.</para><para>You can specify arguments here that your own job-execution script consumes, as well
        /// as arguments that Glue itself consumes.</para><para>Job arguments may be logged. Do not pass plaintext secrets as arguments. Retrieve
        /// secrets from a Glue Connection, Secrets Manager or other secret management mechanism
        /// if you intend to keep them within the Job. </para><para>For information about how to specify and consume your own Job arguments, see the <a href="https://docs.aws.amazon.com/glue/latest/dg/aws-glue-programming-python-calling.html">Calling
        /// Glue APIs in Python</a> topic in the developer guide.</para><para>For information about the arguments you can provide to this field when configuring
        /// Spark jobs, see the <a href="https://docs.aws.amazon.com/glue/latest/dg/aws-glue-programming-etl-glue-arguments.html">Special
        /// Parameters Used by Glue</a> topic in the developer guide.</para><para>For information about the arguments you can provide to this field when configuring
        /// Ray jobs, see <a href="https://docs.aws.amazon.com/glue/latest/dg/author-job-ray-job-parameters.html">Using
        /// job parameters in Ray jobs</a> in the developer guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Arguments")]
        public System.Collections.Hashtable Argument { get; set; }
        #endregion
        
        #region Parameter ExecutionClass
        /// <summary>
        /// <para>
        /// <para>Indicates whether the job is run with a standard or flexible execution class. The
        /// standard execution-class is ideal for time-sensitive workloads that require fast job
        /// startup and dedicated resources.</para><para>The flexible execution class is appropriate for time-insensitive jobs whose start
        /// and completion times may vary. </para><para>Only jobs with Glue version 3.0 and above and command type <c>glueetl</c> will be
        /// allowed to set <c>ExecutionClass</c> to <c>FLEX</c>. The flexible execution class
        /// is available for Spark jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ExecutionClass")]
        public Amazon.Glue.ExecutionClass ExecutionClass { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The name of the job definition to use.</para>
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
        
        #region Parameter JobRunId
        /// <summary>
        /// <para>
        /// <para>The ID of a previous <c>JobRun</c> to retry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobRunId { get; set; }
        #endregion
        
        #region Parameter JobRunQueuingEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether job run queuing is enabled for the job run.</para><para>A value of true means job run queuing is enabled for the job run. If false or not
        /// populated, the job run will not be considered for queueing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? JobRunQueuingEnabled { get; set; }
        #endregion
        
        #region Parameter MaxCapacity
        /// <summary>
        /// <para>
        /// <para>For Glue version 1.0 or earlier jobs, using the standard worker type, the number of
        /// Glue data processing units (DPUs) that can be allocated when this job runs. A DPU
        /// is a relative measure of processing power that consists of 4 vCPUs of compute capacity
        /// and 16 GB of memory. For more information, see the <a href="https://aws.amazon.com/glue/pricing/">
        /// Glue pricing page</a>.</para><para>For Glue version 2.0+ jobs, you cannot specify a <c>Maximum capacity</c>. Instead,
        /// you should specify a <c>Worker type</c> and the <c>Number of workers</c>.</para><para>Do not set <c>MaxCapacity</c> if using <c>WorkerType</c> and <c>NumberOfWorkers</c>.</para><para>The value that can be allocated for <c>MaxCapacity</c> depends on whether you are
        /// running a Python shell job, an Apache Spark ETL job, or an Apache Spark streaming
        /// ETL job:</para><ul><li><para>When you specify a Python shell job (<c>JobCommand.Name</c>="pythonshell"), you can
        /// allocate either 0.0625 or 1 DPU. The default is 0.0625 DPU.</para></li><li><para>When you specify an Apache Spark ETL job (<c>JobCommand.Name</c>="glueetl") or Apache
        /// Spark streaming ETL job (<c>JobCommand.Name</c>="gluestreaming"), you can allocate
        /// from 2 to 100 DPUs. The default is 10 DPUs. This job type cannot have a fractional
        /// DPU allocation.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? MaxCapacity { get; set; }
        #endregion
        
        #region Parameter NotificationProperty_NotifyDelayAfter
        /// <summary>
        /// <para>
        /// <para>After a job run starts, the number of minutes to wait before sending a job run delay
        /// notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NotificationProperty_NotifyDelayAfter { get; set; }
        #endregion
        
        #region Parameter NumberOfWorker
        /// <summary>
        /// <para>
        /// <para>The number of workers of a defined <c>workerType</c> that are allocated when a job
        /// runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumberOfWorkers")]
        public System.Int32? NumberOfWorker { get; set; }
        #endregion
        
        #region Parameter SecurityConfiguration
        /// <summary>
        /// <para>
        /// <para>The name of the <c>SecurityConfiguration</c> structure to be used with this job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityConfiguration { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The <c>JobRun</c> timeout in minutes. This is the maximum time that a job run can
        /// consume resources before it is terminated and enters <c>TIMEOUT</c> status. This value
        /// overrides the timeout value set in the parent job. </para><para>Jobs must have timeout values less than 7 days or 10080 minutes. Otherwise, the jobs
        /// will throw an exception.</para><para>When the value is left blank, the timeout is defaulted to 2880 minutes.</para><para>Any existing Glue jobs that had a timeout value greater than 7 days will be defaulted
        /// to 7 days. For instance if you have specified a timeout of 20 days for a batch job,
        /// it will be stopped on the 7th day.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Timeout { get; set; }
        #endregion
        
        #region Parameter WorkerType
        /// <summary>
        /// <para>
        /// <para>The type of predefined worker that is allocated when a job runs. Accepts a value of
        /// G.1X, G.2X, G.4X, G.8X or G.025X for Spark jobs. Accepts the value Z.2X for Ray jobs.</para><ul><li><para>For the <c>G.1X</c> worker type, each worker maps to 1 DPU (4 vCPUs, 16 GB of memory)
        /// with 94GB disk, and provides 1 executor per worker. We recommend this worker type
        /// for workloads such as data transforms, joins, and queries, to offers a scalable and
        /// cost effective way to run most jobs.</para></li><li><para>For the <c>G.2X</c> worker type, each worker maps to 2 DPU (8 vCPUs, 32 GB of memory)
        /// with 138GB disk, and provides 1 executor per worker. We recommend this worker type
        /// for workloads such as data transforms, joins, and queries, to offers a scalable and
        /// cost effective way to run most jobs.</para></li><li><para>For the <c>G.4X</c> worker type, each worker maps to 4 DPU (16 vCPUs, 64 GB of memory)
        /// with 256GB disk, and provides 1 executor per worker. We recommend this worker type
        /// for jobs whose workloads contain your most demanding transforms, aggregations, joins,
        /// and queries. This worker type is available only for Glue version 3.0 or later Spark
        /// ETL jobs in the following Amazon Web Services Regions: US East (Ohio), US East (N.
        /// Virginia), US West (Oregon), Asia Pacific (Singapore), Asia Pacific (Sydney), Asia
        /// Pacific (Tokyo), Canada (Central), Europe (Frankfurt), Europe (Ireland), and Europe
        /// (Stockholm).</para></li><li><para>For the <c>G.8X</c> worker type, each worker maps to 8 DPU (32 vCPUs, 128 GB of memory)
        /// with 512GB disk, and provides 1 executor per worker. We recommend this worker type
        /// for jobs whose workloads contain your most demanding transforms, aggregations, joins,
        /// and queries. This worker type is available only for Glue version 3.0 or later Spark
        /// ETL jobs, in the same Amazon Web Services Regions as supported for the <c>G.4X</c>
        /// worker type.</para></li><li><para>For the <c>G.025X</c> worker type, each worker maps to 0.25 DPU (2 vCPUs, 4 GB of
        /// memory) with 84GB disk, and provides 1 executor per worker. We recommend this worker
        /// type for low volume streaming jobs. This worker type is only available for Glue version
        /// 3.0 or later streaming jobs.</para></li><li><para>For the <c>Z.2X</c> worker type, each worker maps to 2 M-DPU (8vCPUs, 64 GB of memory)
        /// with 128 GB disk, and provides up to 8 Ray workers based on the autoscaler.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.WorkerType")]
        public Amazon.Glue.WorkerType WorkerType { get; set; }
        #endregion
        
        #region Parameter AllocatedCapacity
        /// <summary>
        /// <para>
        /// <para>This field is deprecated. Use <c>MaxCapacity</c> instead.</para><para>The number of Glue data processing units (DPUs) to allocate to this JobRun. You can
        /// allocate a minimum of 2 DPUs; the default is 10. A DPU is a relative measure of processing
        /// power that consists of 4 vCPUs of compute capacity and 16 GB of memory. For more information,
        /// see the <a href="https://aws.amazon.com/glue/pricing/">Glue pricing page</a>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This property is deprecated, use MaxCapacity instead.")]
        public System.Int32? AllocatedCapacity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobRunId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.StartJobRunResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.StartJobRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobRunId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GLUEJobRun (StartJobRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.StartJobRunResponse, StartGLUEJobRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllocatedCapacity = this.AllocatedCapacity;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Argument != null)
            {
                context.Argument = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Argument.Keys)
                {
                    context.Argument.Add((String)hashKey, (System.String)(this.Argument[hashKey]));
                }
            }
            context.ExecutionClass = this.ExecutionClass;
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobRunId = this.JobRunId;
            context.JobRunQueuingEnabled = this.JobRunQueuingEnabled;
            context.MaxCapacity = this.MaxCapacity;
            context.NotificationProperty_NotifyDelayAfter = this.NotificationProperty_NotifyDelayAfter;
            context.NumberOfWorker = this.NumberOfWorker;
            context.SecurityConfiguration = this.SecurityConfiguration;
            context.Timeout = this.Timeout;
            context.WorkerType = this.WorkerType;
            
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
            var request = new Amazon.Glue.Model.StartJobRunRequest();
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.AllocatedCapacity != null)
            {
                request.AllocatedCapacity = cmdletContext.AllocatedCapacity.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Argument != null)
            {
                request.Arguments = cmdletContext.Argument;
            }
            if (cmdletContext.ExecutionClass != null)
            {
                request.ExecutionClass = cmdletContext.ExecutionClass;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.JobRunId != null)
            {
                request.JobRunId = cmdletContext.JobRunId;
            }
            if (cmdletContext.JobRunQueuingEnabled != null)
            {
                request.JobRunQueuingEnabled = cmdletContext.JobRunQueuingEnabled.Value;
            }
            if (cmdletContext.MaxCapacity != null)
            {
                request.MaxCapacity = cmdletContext.MaxCapacity.Value;
            }
            
             // populate NotificationProperty
            var requestNotificationPropertyIsNull = true;
            request.NotificationProperty = new Amazon.Glue.Model.NotificationProperty();
            System.Int32? requestNotificationProperty_notificationProperty_NotifyDelayAfter = null;
            if (cmdletContext.NotificationProperty_NotifyDelayAfter != null)
            {
                requestNotificationProperty_notificationProperty_NotifyDelayAfter = cmdletContext.NotificationProperty_NotifyDelayAfter.Value;
            }
            if (requestNotificationProperty_notificationProperty_NotifyDelayAfter != null)
            {
                request.NotificationProperty.NotifyDelayAfter = requestNotificationProperty_notificationProperty_NotifyDelayAfter.Value;
                requestNotificationPropertyIsNull = false;
            }
             // determine if request.NotificationProperty should be set to null
            if (requestNotificationPropertyIsNull)
            {
                request.NotificationProperty = null;
            }
            if (cmdletContext.NumberOfWorker != null)
            {
                request.NumberOfWorkers = cmdletContext.NumberOfWorker.Value;
            }
            if (cmdletContext.SecurityConfiguration != null)
            {
                request.SecurityConfiguration = cmdletContext.SecurityConfiguration;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
            }
            if (cmdletContext.WorkerType != null)
            {
                request.WorkerType = cmdletContext.WorkerType;
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
        
        private Amazon.Glue.Model.StartJobRunResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.StartJobRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "StartJobRun");
            try
            {
                #if DESKTOP
                return client.StartJobRun(request);
                #elif CORECLR
                return client.StartJobRunAsync(request).GetAwaiter().GetResult();
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
            [System.ObsoleteAttribute]
            public System.Int32? AllocatedCapacity { get; set; }
            public Dictionary<System.String, System.String> Argument { get; set; }
            public Amazon.Glue.ExecutionClass ExecutionClass { get; set; }
            public System.String JobName { get; set; }
            public System.String JobRunId { get; set; }
            public System.Boolean? JobRunQueuingEnabled { get; set; }
            public System.Double? MaxCapacity { get; set; }
            public System.Int32? NotificationProperty_NotifyDelayAfter { get; set; }
            public System.Int32? NumberOfWorker { get; set; }
            public System.String SecurityConfiguration { get; set; }
            public System.Int32? Timeout { get; set; }
            public Amazon.Glue.WorkerType WorkerType { get; set; }
            public System.Func<Amazon.Glue.Model.StartJobRunResponse, StartGLUEJobRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobRunId;
        }
        
    }
}

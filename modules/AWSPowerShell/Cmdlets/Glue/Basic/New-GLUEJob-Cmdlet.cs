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
    /// Creates a new job definition.
    /// </summary>
    [Cmdlet("New", "GLUEJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue CreateJob API operation.", Operation = new[] {"CreateJob"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.CreateJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Glue.Model.CreateJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGLUEJobCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SourceControlDetails_AuthStrategy
        /// <summary>
        /// <para>
        /// <para>The type of authentication, which can be an authentication token stored in Amazon
        /// Web Services Secrets Manager, or a personal access token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.SourceControlAuthStrategy")]
        public Amazon.Glue.SourceControlAuthStrategy SourceControlDetails_AuthStrategy { get; set; }
        #endregion
        
        #region Parameter SourceControlDetails_AuthToken
        /// <summary>
        /// <para>
        /// <para>The value of an authorization token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceControlDetails_AuthToken { get; set; }
        #endregion
        
        #region Parameter SourceControlDetails_Branch
        /// <summary>
        /// <para>
        /// <para>An optional branch in the remote repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceControlDetails_Branch { get; set; }
        #endregion
        
        #region Parameter CodeGenConfigurationNode
        /// <summary>
        /// <para>
        /// <para>The representation of a directed acyclic graph on which both the Glue Studio visual
        /// component and Glue Studio code generation is based.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodeGenConfigurationNodes")]
        public System.Collections.Hashtable CodeGenConfigurationNode { get; set; }
        #endregion
        
        #region Parameter Command
        /// <summary>
        /// <para>
        /// <para>The <c>JobCommand</c> that runs this job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Glue.Model.JobCommand Command { get; set; }
        #endregion
        
        #region Parameter Connections_Connection
        /// <summary>
        /// <para>
        /// <para>A list of connections used by the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Connections_Connections")]
        public System.String[] Connections_Connection { get; set; }
        #endregion
        
        #region Parameter DefaultArgument
        /// <summary>
        /// <para>
        /// <para>The default arguments for every run of this job, specified as name-value pairs.</para><para>You can specify arguments here that your own job-execution script consumes, as well
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
        [Alias("DefaultArguments")]
        public System.Collections.Hashtable DefaultArgument { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Description of the job being defined.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
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
        
        #region Parameter SourceControlDetails_Folder
        /// <summary>
        /// <para>
        /// <para>An optional folder in the remote repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceControlDetails_Folder { get; set; }
        #endregion
        
        #region Parameter GlueVersion
        /// <summary>
        /// <para>
        /// <para>In Spark jobs, <c>GlueVersion</c> determines the versions of Apache Spark and Python
        /// that Glue available in a job. The Python version indicates the version supported for
        /// jobs of type Spark. </para><para>Ray jobs should set <c>GlueVersion</c> to <c>4.0</c> or greater. However, the versions
        /// of Ray, Python and additional libraries available in your Ray job are determined by
        /// the <c>Runtime</c> parameter of the Job command.</para><para>For more information about the available Glue versions and corresponding Spark and
        /// Python versions, see <a href="https://docs.aws.amazon.com/glue/latest/dg/add-job.html">Glue
        /// version</a> in the developer guide.</para><para>Jobs that are created without specifying a Glue version default to Glue 0.9.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GlueVersion { get; set; }
        #endregion
        
        #region Parameter SourceControlDetails_LastCommitId
        /// <summary>
        /// <para>
        /// <para>The last commit ID for a commit in the remote repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceControlDetails_LastCommitId { get; set; }
        #endregion
        
        #region Parameter LogUri
        /// <summary>
        /// <para>
        /// <para>This field is reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogUri { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>This field specifies a day of the week and hour for a maintenance window for streaming
        /// jobs. Glue periodically performs maintenance activities. During these maintenance
        /// windows, Glue will need to restart your streaming jobs.</para><para>Glue will restart the job within 3 hours of the specified maintenance window. For
        /// instance, if you set up the maintenance window for Monday at 10:00AM GMT, your jobs
        /// will be restarted between 10:00AM GMT to 1:00PM GMT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaintenanceWindow { get; set; }
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
        
        #region Parameter ExecutionProperty_MaxConcurrentRun
        /// <summary>
        /// <para>
        /// <para>The maximum number of concurrent runs allowed for the job. The default is 1. An error
        /// is returned when this threshold is reached. The maximum value you can specify is controlled
        /// by a service limit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionProperty_MaxConcurrentRuns")]
        public System.Int32? ExecutionProperty_MaxConcurrentRun { get; set; }
        #endregion
        
        #region Parameter MaxRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of times to retry this job if it fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRetries")]
        public System.Int32? MaxRetry { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name you assign to this job definition. It must be unique in your account.</para>
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
        
        #region Parameter NonOverridableArgument
        /// <summary>
        /// <para>
        /// <para>Arguments for this job that are not overridden when providing job arguments in a job
        /// run, specified as name-value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NonOverridableArguments")]
        public System.Collections.Hashtable NonOverridableArgument { get; set; }
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
        
        #region Parameter SourceControlDetails_Owner
        /// <summary>
        /// <para>
        /// <para>The owner of the remote repository that contains the job artifacts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceControlDetails_Owner { get; set; }
        #endregion
        
        #region Parameter SourceControlDetails_Provider
        /// <summary>
        /// <para>
        /// <para>The provider for the remote repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.SourceControlProvider")]
        public Amazon.Glue.SourceControlProvider SourceControlDetails_Provider { get; set; }
        #endregion
        
        #region Parameter SourceControlDetails_Repository
        /// <summary>
        /// <para>
        /// <para>The name of the remote repository that contains the job artifacts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceControlDetails_Repository { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the IAM role associated with this job.</para>
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
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter SecurityConfiguration
        /// <summary>
        /// <para>
        /// <para>The name of the <c>SecurityConfiguration</c> structure to be used with this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityConfiguration { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to use with this job. You may use tags to limit access to the job. For more
        /// information about tags in Glue, see <a href="https://docs.aws.amazon.com/glue/latest/dg/monitor-tags.html">Amazon
        /// Web Services Tags in Glue</a> in the developer guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The job timeout in minutes. This is the maximum time that a job run can consume resources
        /// before it is terminated and enters <c>TIMEOUT</c> status. The default is 2,880 minutes
        /// (48 hours).</para>
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
        /// with 84GB disk (approximately 34GB free), and provides 1 executor per worker. We recommend
        /// this worker type for workloads such as data transforms, joins, and queries, to offers
        /// a scalable and cost effective way to run most jobs.</para></li><li><para>For the <c>G.2X</c> worker type, each worker maps to 2 DPU (8 vCPUs, 32 GB of memory)
        /// with 128GB disk (approximately 77GB free), and provides 1 executor per worker. We
        /// recommend this worker type for workloads such as data transforms, joins, and queries,
        /// to offers a scalable and cost effective way to run most jobs.</para></li><li><para>For the <c>G.4X</c> worker type, each worker maps to 4 DPU (16 vCPUs, 64 GB of memory)
        /// with 256GB disk (approximately 235GB free), and provides 1 executor per worker. We
        /// recommend this worker type for jobs whose workloads contain your most demanding transforms,
        /// aggregations, joins, and queries. This worker type is available only for Glue version
        /// 3.0 or later Spark ETL jobs in the following Amazon Web Services Regions: US East
        /// (Ohio), US East (N. Virginia), US West (Oregon), Asia Pacific (Singapore), Asia Pacific
        /// (Sydney), Asia Pacific (Tokyo), Canada (Central), Europe (Frankfurt), Europe (Ireland),
        /// and Europe (Stockholm).</para></li><li><para>For the <c>G.8X</c> worker type, each worker maps to 8 DPU (32 vCPUs, 128 GB of memory)
        /// with 512GB disk (approximately 487GB free), and provides 1 executor per worker. We
        /// recommend this worker type for jobs whose workloads contain your most demanding transforms,
        /// aggregations, joins, and queries. This worker type is available only for Glue version
        /// 3.0 or later Spark ETL jobs, in the same Amazon Web Services Regions as supported
        /// for the <c>G.4X</c> worker type.</para></li><li><para>For the <c>G.025X</c> worker type, each worker maps to 0.25 DPU (2 vCPUs, 4 GB of
        /// memory) with 84GB disk (approximately 34GB free), and provides 1 executor per worker.
        /// We recommend this worker type for low volume streaming jobs. This worker type is only
        /// available for Glue version 3.0 streaming jobs.</para></li><li><para>For the <c>Z.2X</c> worker type, each worker maps to 2 M-DPU (8vCPUs, 64 GB of memory)
        /// with 128 GB disk (approximately 120GB free), and provides up to 8 Ray workers based
        /// on the autoscaler.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.WorkerType")]
        public Amazon.Glue.WorkerType WorkerType { get; set; }
        #endregion
        
        #region Parameter AllocatedCapacity
        /// <summary>
        /// <para>
        /// <para>This parameter is deprecated. Use <c>MaxCapacity</c> instead.</para><para>The number of Glue data processing units (DPUs) to allocate to this Job. You can allocate
        /// a minimum of 2 DPUs; the default is 10. A DPU is a relative measure of processing
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Name'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateJobResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.CreateJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Name";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Command parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Command' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Command' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUEJob (CreateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateJobResponse, NewGLUEJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Command;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllocatedCapacity = this.AllocatedCapacity;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CodeGenConfigurationNode != null)
            {
                context.CodeGenConfigurationNode = new Dictionary<System.String, Amazon.Glue.Model.CodeGenConfigurationNode>(StringComparer.Ordinal);
                foreach (var hashKey in this.CodeGenConfigurationNode.Keys)
                {
                    context.CodeGenConfigurationNode.Add((String)hashKey, (Amazon.Glue.Model.CodeGenConfigurationNode)(this.CodeGenConfigurationNode[hashKey]));
                }
            }
            context.Command = this.Command;
            #if MODULAR
            if (this.Command == null && ParameterWasBound(nameof(this.Command)))
            {
                WriteWarning("You are passing $null as a value for parameter Command which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Connections_Connection != null)
            {
                context.Connections_Connection = new List<System.String>(this.Connections_Connection);
            }
            if (this.DefaultArgument != null)
            {
                context.DefaultArgument = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultArgument.Keys)
                {
                    context.DefaultArgument.Add((String)hashKey, (System.String)(this.DefaultArgument[hashKey]));
                }
            }
            context.Description = this.Description;
            context.ExecutionClass = this.ExecutionClass;
            context.ExecutionProperty_MaxConcurrentRun = this.ExecutionProperty_MaxConcurrentRun;
            context.GlueVersion = this.GlueVersion;
            context.LogUri = this.LogUri;
            context.MaintenanceWindow = this.MaintenanceWindow;
            context.MaxCapacity = this.MaxCapacity;
            context.MaxRetry = this.MaxRetry;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NonOverridableArgument != null)
            {
                context.NonOverridableArgument = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.NonOverridableArgument.Keys)
                {
                    context.NonOverridableArgument.Add((String)hashKey, (System.String)(this.NonOverridableArgument[hashKey]));
                }
            }
            context.NotificationProperty_NotifyDelayAfter = this.NotificationProperty_NotifyDelayAfter;
            context.NumberOfWorker = this.NumberOfWorker;
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecurityConfiguration = this.SecurityConfiguration;
            context.SourceControlDetails_AuthStrategy = this.SourceControlDetails_AuthStrategy;
            context.SourceControlDetails_AuthToken = this.SourceControlDetails_AuthToken;
            context.SourceControlDetails_Branch = this.SourceControlDetails_Branch;
            context.SourceControlDetails_Folder = this.SourceControlDetails_Folder;
            context.SourceControlDetails_LastCommitId = this.SourceControlDetails_LastCommitId;
            context.SourceControlDetails_Owner = this.SourceControlDetails_Owner;
            context.SourceControlDetails_Provider = this.SourceControlDetails_Provider;
            context.SourceControlDetails_Repository = this.SourceControlDetails_Repository;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
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
            var request = new Amazon.Glue.Model.CreateJobRequest();
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.AllocatedCapacity != null)
            {
                request.AllocatedCapacity = cmdletContext.AllocatedCapacity.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.CodeGenConfigurationNode != null)
            {
                request.CodeGenConfigurationNodes = cmdletContext.CodeGenConfigurationNode;
            }
            if (cmdletContext.Command != null)
            {
                request.Command = cmdletContext.Command;
            }
            
             // populate Connections
            var requestConnectionsIsNull = true;
            request.Connections = new Amazon.Glue.Model.ConnectionsList();
            List<System.String> requestConnections_connections_Connection = null;
            if (cmdletContext.Connections_Connection != null)
            {
                requestConnections_connections_Connection = cmdletContext.Connections_Connection;
            }
            if (requestConnections_connections_Connection != null)
            {
                request.Connections.Connections = requestConnections_connections_Connection;
                requestConnectionsIsNull = false;
            }
             // determine if request.Connections should be set to null
            if (requestConnectionsIsNull)
            {
                request.Connections = null;
            }
            if (cmdletContext.DefaultArgument != null)
            {
                request.DefaultArguments = cmdletContext.DefaultArgument;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExecutionClass != null)
            {
                request.ExecutionClass = cmdletContext.ExecutionClass;
            }
            
             // populate ExecutionProperty
            var requestExecutionPropertyIsNull = true;
            request.ExecutionProperty = new Amazon.Glue.Model.ExecutionProperty();
            System.Int32? requestExecutionProperty_executionProperty_MaxConcurrentRun = null;
            if (cmdletContext.ExecutionProperty_MaxConcurrentRun != null)
            {
                requestExecutionProperty_executionProperty_MaxConcurrentRun = cmdletContext.ExecutionProperty_MaxConcurrentRun.Value;
            }
            if (requestExecutionProperty_executionProperty_MaxConcurrentRun != null)
            {
                request.ExecutionProperty.MaxConcurrentRuns = requestExecutionProperty_executionProperty_MaxConcurrentRun.Value;
                requestExecutionPropertyIsNull = false;
            }
             // determine if request.ExecutionProperty should be set to null
            if (requestExecutionPropertyIsNull)
            {
                request.ExecutionProperty = null;
            }
            if (cmdletContext.GlueVersion != null)
            {
                request.GlueVersion = cmdletContext.GlueVersion;
            }
            if (cmdletContext.LogUri != null)
            {
                request.LogUri = cmdletContext.LogUri;
            }
            if (cmdletContext.MaintenanceWindow != null)
            {
                request.MaintenanceWindow = cmdletContext.MaintenanceWindow;
            }
            if (cmdletContext.MaxCapacity != null)
            {
                request.MaxCapacity = cmdletContext.MaxCapacity.Value;
            }
            if (cmdletContext.MaxRetry != null)
            {
                request.MaxRetries = cmdletContext.MaxRetry.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NonOverridableArgument != null)
            {
                request.NonOverridableArguments = cmdletContext.NonOverridableArgument;
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
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.SecurityConfiguration != null)
            {
                request.SecurityConfiguration = cmdletContext.SecurityConfiguration;
            }
            
             // populate SourceControlDetails
            var requestSourceControlDetailsIsNull = true;
            request.SourceControlDetails = new Amazon.Glue.Model.SourceControlDetails();
            Amazon.Glue.SourceControlAuthStrategy requestSourceControlDetails_sourceControlDetails_AuthStrategy = null;
            if (cmdletContext.SourceControlDetails_AuthStrategy != null)
            {
                requestSourceControlDetails_sourceControlDetails_AuthStrategy = cmdletContext.SourceControlDetails_AuthStrategy;
            }
            if (requestSourceControlDetails_sourceControlDetails_AuthStrategy != null)
            {
                request.SourceControlDetails.AuthStrategy = requestSourceControlDetails_sourceControlDetails_AuthStrategy;
                requestSourceControlDetailsIsNull = false;
            }
            System.String requestSourceControlDetails_sourceControlDetails_AuthToken = null;
            if (cmdletContext.SourceControlDetails_AuthToken != null)
            {
                requestSourceControlDetails_sourceControlDetails_AuthToken = cmdletContext.SourceControlDetails_AuthToken;
            }
            if (requestSourceControlDetails_sourceControlDetails_AuthToken != null)
            {
                request.SourceControlDetails.AuthToken = requestSourceControlDetails_sourceControlDetails_AuthToken;
                requestSourceControlDetailsIsNull = false;
            }
            System.String requestSourceControlDetails_sourceControlDetails_Branch = null;
            if (cmdletContext.SourceControlDetails_Branch != null)
            {
                requestSourceControlDetails_sourceControlDetails_Branch = cmdletContext.SourceControlDetails_Branch;
            }
            if (requestSourceControlDetails_sourceControlDetails_Branch != null)
            {
                request.SourceControlDetails.Branch = requestSourceControlDetails_sourceControlDetails_Branch;
                requestSourceControlDetailsIsNull = false;
            }
            System.String requestSourceControlDetails_sourceControlDetails_Folder = null;
            if (cmdletContext.SourceControlDetails_Folder != null)
            {
                requestSourceControlDetails_sourceControlDetails_Folder = cmdletContext.SourceControlDetails_Folder;
            }
            if (requestSourceControlDetails_sourceControlDetails_Folder != null)
            {
                request.SourceControlDetails.Folder = requestSourceControlDetails_sourceControlDetails_Folder;
                requestSourceControlDetailsIsNull = false;
            }
            System.String requestSourceControlDetails_sourceControlDetails_LastCommitId = null;
            if (cmdletContext.SourceControlDetails_LastCommitId != null)
            {
                requestSourceControlDetails_sourceControlDetails_LastCommitId = cmdletContext.SourceControlDetails_LastCommitId;
            }
            if (requestSourceControlDetails_sourceControlDetails_LastCommitId != null)
            {
                request.SourceControlDetails.LastCommitId = requestSourceControlDetails_sourceControlDetails_LastCommitId;
                requestSourceControlDetailsIsNull = false;
            }
            System.String requestSourceControlDetails_sourceControlDetails_Owner = null;
            if (cmdletContext.SourceControlDetails_Owner != null)
            {
                requestSourceControlDetails_sourceControlDetails_Owner = cmdletContext.SourceControlDetails_Owner;
            }
            if (requestSourceControlDetails_sourceControlDetails_Owner != null)
            {
                request.SourceControlDetails.Owner = requestSourceControlDetails_sourceControlDetails_Owner;
                requestSourceControlDetailsIsNull = false;
            }
            Amazon.Glue.SourceControlProvider requestSourceControlDetails_sourceControlDetails_Provider = null;
            if (cmdletContext.SourceControlDetails_Provider != null)
            {
                requestSourceControlDetails_sourceControlDetails_Provider = cmdletContext.SourceControlDetails_Provider;
            }
            if (requestSourceControlDetails_sourceControlDetails_Provider != null)
            {
                request.SourceControlDetails.Provider = requestSourceControlDetails_sourceControlDetails_Provider;
                requestSourceControlDetailsIsNull = false;
            }
            System.String requestSourceControlDetails_sourceControlDetails_Repository = null;
            if (cmdletContext.SourceControlDetails_Repository != null)
            {
                requestSourceControlDetails_sourceControlDetails_Repository = cmdletContext.SourceControlDetails_Repository;
            }
            if (requestSourceControlDetails_sourceControlDetails_Repository != null)
            {
                request.SourceControlDetails.Repository = requestSourceControlDetails_sourceControlDetails_Repository;
                requestSourceControlDetailsIsNull = false;
            }
             // determine if request.SourceControlDetails should be set to null
            if (requestSourceControlDetailsIsNull)
            {
                request.SourceControlDetails = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Glue.Model.CreateJobResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateJob");
            try
            {
                #if DESKTOP
                return client.CreateJob(request);
                #elif CORECLR
                return client.CreateJobAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.Glue.Model.CodeGenConfigurationNode> CodeGenConfigurationNode { get; set; }
            public Amazon.Glue.Model.JobCommand Command { get; set; }
            public List<System.String> Connections_Connection { get; set; }
            public Dictionary<System.String, System.String> DefaultArgument { get; set; }
            public System.String Description { get; set; }
            public Amazon.Glue.ExecutionClass ExecutionClass { get; set; }
            public System.Int32? ExecutionProperty_MaxConcurrentRun { get; set; }
            public System.String GlueVersion { get; set; }
            public System.String LogUri { get; set; }
            public System.String MaintenanceWindow { get; set; }
            public System.Double? MaxCapacity { get; set; }
            public System.Int32? MaxRetry { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> NonOverridableArgument { get; set; }
            public System.Int32? NotificationProperty_NotifyDelayAfter { get; set; }
            public System.Int32? NumberOfWorker { get; set; }
            public System.String Role { get; set; }
            public System.String SecurityConfiguration { get; set; }
            public Amazon.Glue.SourceControlAuthStrategy SourceControlDetails_AuthStrategy { get; set; }
            public System.String SourceControlDetails_AuthToken { get; set; }
            public System.String SourceControlDetails_Branch { get; set; }
            public System.String SourceControlDetails_Folder { get; set; }
            public System.String SourceControlDetails_LastCommitId { get; set; }
            public System.String SourceControlDetails_Owner { get; set; }
            public Amazon.Glue.SourceControlProvider SourceControlDetails_Provider { get; set; }
            public System.String SourceControlDetails_Repository { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? Timeout { get; set; }
            public Amazon.Glue.WorkerType WorkerType { get; set; }
            public System.Func<Amazon.Glue.Model.CreateJobResponse, NewGLUEJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Name;
        }
        
    }
}

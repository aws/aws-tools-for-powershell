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
using Amazon.RoboMaker;
using Amazon.RoboMaker.Model;

namespace Amazon.PowerShell.Cmdlets.ROBO
{
    /// <summary>
    /// <important><para>
    /// End of support notice: On September 10, 2025, Amazon Web Services will discontinue
    /// support for Amazon Web Services RoboMaker. After September 10, 2025, you will no longer
    /// be able to access the Amazon Web Services RoboMaker console or Amazon Web Services
    /// RoboMaker resources. For more information on transitioning to Batch to help run containerized
    /// simulations, visit <a href="https://aws.amazon.com/blogs/hpc/run-simulations-using-multiple-containers-in-a-single-aws-batch-job/">https://aws.amazon.com/blogs/hpc/run-simulations-using-multiple-containers-in-a-single-aws-batch-job/</a>.
    /// 
    /// </para></important><para>
    /// Creates a simulation job.
    /// </para><note><para>
    /// After 90 days, simulation jobs expire and will be deleted. They will no longer be
    /// accessible. 
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "ROBOSimulationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RoboMaker.Model.CreateSimulationJobResponse")]
    [AWSCmdlet("Calls the AWS RoboMaker CreateSimulationJob API operation.", Operation = new[] {"CreateSimulationJob"}, SelectReturnType = typeof(Amazon.RoboMaker.Model.CreateSimulationJobResponse))]
    [AWSCmdletOutput("Amazon.RoboMaker.Model.CreateSimulationJobResponse",
        "This cmdlet returns an Amazon.RoboMaker.Model.CreateSimulationJobResponse object containing multiple properties."
    )]
    public partial class NewROBOSimulationJobCmdlet : AmazonRoboMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Compute_ComputeType
        /// <summary>
        /// <para>
        /// <para>Compute type information for the simulation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RoboMaker.ComputeType")]
        public Amazon.RoboMaker.ComputeType Compute_ComputeType { get; set; }
        #endregion
        
        #region Parameter DataSource
        /// <summary>
        /// <para>
        /// <para>Specify data sources to mount read-only files from S3 into your simulation. These
        /// files are available under <c>/opt/robomaker/datasources/data_source_name</c>. </para><note><para>There is a limit of 100 files and a combined size of 25GB for all <c>DataSourceConfig</c>
        /// objects. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources")]
        public Amazon.RoboMaker.Model.DataSourceConfig[] DataSource { get; set; }
        #endregion
        
        #region Parameter FailureBehavior
        /// <summary>
        /// <para>
        /// <para>The failure behavior the simulation job.</para><dl><dt>Continue</dt><dd><para>Leaves the instance running for its maximum timeout duration after a <c>4XX</c> error
        /// code.</para></dd><dt>Fail</dt><dd><para>Stop the simulation job and terminate the instance.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RoboMaker.FailureBehavior")]
        public Amazon.RoboMaker.FailureBehavior FailureBehavior { get; set; }
        #endregion
        
        #region Parameter Compute_GpuUnitLimit
        /// <summary>
        /// <para>
        /// <para>Compute GPU unit limit for the simulation job. It is the same as the number of GPUs
        /// allocated to the SimulationJob.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Compute_GpuUnitLimit { get; set; }
        #endregion
        
        #region Parameter IamRole
        /// <summary>
        /// <para>
        /// <para>The IAM role name that allows the simulation instance to call the AWS APIs that are
        /// specified in its associated policies on your behalf. This is how credentials are passed
        /// in to your simulation job. </para>
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
        public System.String IamRole { get; set; }
        #endregion
        
        #region Parameter MaxJobDurationInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum simulation job duration in seconds (up to 14 days or 1,209,600 seconds.
        /// When <c>maxJobDurationInSeconds</c> is reached, the simulation job will status will
        /// transition to <c>Completed</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MaxJobDurationInSeconds")]
        public System.Int64? MaxJobDurationInSecond { get; set; }
        #endregion
        
        #region Parameter OutputLocation
        /// <summary>
        /// <para>
        /// <para>Location for output files generated by the simulation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.RoboMaker.Model.OutputLocation OutputLocation { get; set; }
        #endregion
        
        #region Parameter RobotApplication
        /// <summary>
        /// <para>
        /// <para>The robot application to use in the simulation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RobotApplications")]
        public Amazon.RoboMaker.Model.RobotApplicationConfig[] RobotApplication { get; set; }
        #endregion
        
        #region Parameter SimulationApplication
        /// <summary>
        /// <para>
        /// <para>The simulation application to use in the simulation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SimulationApplications")]
        public Amazon.RoboMaker.Model.SimulationApplicationConfig[] SimulationApplication { get; set; }
        #endregion
        
        #region Parameter Compute_SimulationUnitLimit
        /// <summary>
        /// <para>
        /// <para>The simulation unit limit. Your simulation is allocated CPU and memory proportional
        /// to the supplied simulation unit limit. A simulation unit is 1 vcpu and 2GB of memory.
        /// You are only billed for the SU utilization you consume up to the maximum value provided.
        /// The default is 15. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Compute_SimulationUnitLimit { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map that contains tag keys and tag values that are attached to the simulation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter VpcConfig
        /// <summary>
        /// <para>
        /// <para>If your simulation job accesses resources in a VPC, you provide this parameter identifying
        /// the list of security group IDs and subnet IDs. These must belong to the same VPC.
        /// You must provide at least one security group and one subnet ID. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.RoboMaker.Model.VPCConfig VpcConfig { get; set; }
        #endregion
        
        #region Parameter LoggingConfig_RecordAllRosTopic
        /// <summary>
        /// <para>
        /// <para>A boolean indicating whether to record all ROS topics.</para><important><para>This API is no longer supported and will throw an error if used.</para></important>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("AWS RoboMaker is ending support for ROS software suite. For additional information, see https://docs.aws.amazon.com/robomaker/latest/dg/software-support-policy.html.")]
        [Alias("LoggingConfig_RecordAllRosTopics")]
        public System.Boolean? LoggingConfig_RecordAllRosTopic { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RoboMaker.Model.CreateSimulationJobResponse).
        /// Specifying the name of a property of type Amazon.RoboMaker.Model.CreateSimulationJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IamRole parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IamRole' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IamRole' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IamRole), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ROBOSimulationJob (CreateSimulationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RoboMaker.Model.CreateSimulationJobResponse, NewROBOSimulationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IamRole;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.Compute_ComputeType = this.Compute_ComputeType;
            context.Compute_GpuUnitLimit = this.Compute_GpuUnitLimit;
            context.Compute_SimulationUnitLimit = this.Compute_SimulationUnitLimit;
            if (this.DataSource != null)
            {
                context.DataSource = new List<Amazon.RoboMaker.Model.DataSourceConfig>(this.DataSource);
            }
            context.FailureBehavior = this.FailureBehavior;
            context.IamRole = this.IamRole;
            #if MODULAR
            if (this.IamRole == null && ParameterWasBound(nameof(this.IamRole)))
            {
                WriteWarning("You are passing $null as a value for parameter IamRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LoggingConfig_RecordAllRosTopic = this.LoggingConfig_RecordAllRosTopic;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxJobDurationInSecond = this.MaxJobDurationInSecond;
            #if MODULAR
            if (this.MaxJobDurationInSecond == null && ParameterWasBound(nameof(this.MaxJobDurationInSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter MaxJobDurationInSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputLocation = this.OutputLocation;
            if (this.RobotApplication != null)
            {
                context.RobotApplication = new List<Amazon.RoboMaker.Model.RobotApplicationConfig>(this.RobotApplication);
            }
            if (this.SimulationApplication != null)
            {
                context.SimulationApplication = new List<Amazon.RoboMaker.Model.SimulationApplicationConfig>(this.SimulationApplication);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.VpcConfig = this.VpcConfig;
            
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
            var request = new Amazon.RoboMaker.Model.CreateSimulationJobRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate Compute
            var requestComputeIsNull = true;
            request.Compute = new Amazon.RoboMaker.Model.Compute();
            Amazon.RoboMaker.ComputeType requestCompute_compute_ComputeType = null;
            if (cmdletContext.Compute_ComputeType != null)
            {
                requestCompute_compute_ComputeType = cmdletContext.Compute_ComputeType;
            }
            if (requestCompute_compute_ComputeType != null)
            {
                request.Compute.ComputeType = requestCompute_compute_ComputeType;
                requestComputeIsNull = false;
            }
            System.Int32? requestCompute_compute_GpuUnitLimit = null;
            if (cmdletContext.Compute_GpuUnitLimit != null)
            {
                requestCompute_compute_GpuUnitLimit = cmdletContext.Compute_GpuUnitLimit.Value;
            }
            if (requestCompute_compute_GpuUnitLimit != null)
            {
                request.Compute.GpuUnitLimit = requestCompute_compute_GpuUnitLimit.Value;
                requestComputeIsNull = false;
            }
            System.Int32? requestCompute_compute_SimulationUnitLimit = null;
            if (cmdletContext.Compute_SimulationUnitLimit != null)
            {
                requestCompute_compute_SimulationUnitLimit = cmdletContext.Compute_SimulationUnitLimit.Value;
            }
            if (requestCompute_compute_SimulationUnitLimit != null)
            {
                request.Compute.SimulationUnitLimit = requestCompute_compute_SimulationUnitLimit.Value;
                requestComputeIsNull = false;
            }
             // determine if request.Compute should be set to null
            if (requestComputeIsNull)
            {
                request.Compute = null;
            }
            if (cmdletContext.DataSource != null)
            {
                request.DataSources = cmdletContext.DataSource;
            }
            if (cmdletContext.FailureBehavior != null)
            {
                request.FailureBehavior = cmdletContext.FailureBehavior;
            }
            if (cmdletContext.IamRole != null)
            {
                request.IamRole = cmdletContext.IamRole;
            }
            
             // populate LoggingConfig
            var requestLoggingConfigIsNull = true;
            request.LoggingConfig = new Amazon.RoboMaker.Model.LoggingConfig();
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Boolean? requestLoggingConfig_loggingConfig_RecordAllRosTopic = null;
            if (cmdletContext.LoggingConfig_RecordAllRosTopic != null)
            {
                requestLoggingConfig_loggingConfig_RecordAllRosTopic = cmdletContext.LoggingConfig_RecordAllRosTopic.Value;
            }
            if (requestLoggingConfig_loggingConfig_RecordAllRosTopic != null)
            {
                request.LoggingConfig.RecordAllRosTopics = requestLoggingConfig_loggingConfig_RecordAllRosTopic.Value;
                requestLoggingConfigIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
             // determine if request.LoggingConfig should be set to null
            if (requestLoggingConfigIsNull)
            {
                request.LoggingConfig = null;
            }
            if (cmdletContext.MaxJobDurationInSecond != null)
            {
                request.MaxJobDurationInSeconds = cmdletContext.MaxJobDurationInSecond.Value;
            }
            if (cmdletContext.OutputLocation != null)
            {
                request.OutputLocation = cmdletContext.OutputLocation;
            }
            if (cmdletContext.RobotApplication != null)
            {
                request.RobotApplications = cmdletContext.RobotApplication;
            }
            if (cmdletContext.SimulationApplication != null)
            {
                request.SimulationApplications = cmdletContext.SimulationApplication;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VpcConfig != null)
            {
                request.VpcConfig = cmdletContext.VpcConfig;
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
        
        private Amazon.RoboMaker.Model.CreateSimulationJobResponse CallAWSServiceOperation(IAmazonRoboMaker client, Amazon.RoboMaker.Model.CreateSimulationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS RoboMaker", "CreateSimulationJob");
            try
            {
                #if DESKTOP
                return client.CreateSimulationJob(request);
                #elif CORECLR
                return client.CreateSimulationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public Amazon.RoboMaker.ComputeType Compute_ComputeType { get; set; }
            public System.Int32? Compute_GpuUnitLimit { get; set; }
            public System.Int32? Compute_SimulationUnitLimit { get; set; }
            public List<Amazon.RoboMaker.Model.DataSourceConfig> DataSource { get; set; }
            public Amazon.RoboMaker.FailureBehavior FailureBehavior { get; set; }
            public System.String IamRole { get; set; }
            [System.ObsoleteAttribute]
            public System.Boolean? LoggingConfig_RecordAllRosTopic { get; set; }
            public System.Int64? MaxJobDurationInSecond { get; set; }
            public Amazon.RoboMaker.Model.OutputLocation OutputLocation { get; set; }
            public List<Amazon.RoboMaker.Model.RobotApplicationConfig> RobotApplication { get; set; }
            public List<Amazon.RoboMaker.Model.SimulationApplicationConfig> SimulationApplication { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.RoboMaker.Model.VPCConfig VpcConfig { get; set; }
            public System.Func<Amazon.RoboMaker.Model.CreateSimulationJobResponse, NewROBOSimulationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

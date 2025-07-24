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
using System.Threading;
using Amazon.Omics;
using Amazon.Omics.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// Starts a new run and returns details about the run, or duplicates an existing run.
    /// A run is a single invocation of a workflow. If you provide request IDs, Amazon Web
    /// Services HealthOmics identifies duplicate requests and starts the run only once. Monitor
    /// the progress of the run by calling the <c>GetRun</c> API operation.
    /// 
    ///  
    /// <para>
    /// To start a new run, the following inputs are required:
    /// </para><ul><li><para>
    /// A service role ARN (<c>roleArn</c>).
    /// </para></li><li><para>
    /// The run's workflow ID (<c>workflowId</c>, not the <c>uuid</c> or <c>runId</c>).
    /// </para></li><li><para>
    /// An Amazon S3 location (<c>outputUri</c>) where the run outputs will be saved.
    /// </para></li><li><para>
    /// All required workflow parameters (<c>parameter</c>), which can include optional parameters
    /// from the parameter template. The run cannot include any parameters that are not defined
    /// in the parameter template. To see all possible parameters, use the <c>GetRun</c> API
    /// operation. 
    /// </para></li><li><para>
    /// For runs with a <c>STATIC</c> (default) storage type, specify the required storage
    /// capacity (in gibibytes). A storage capacity value is not required for runs that use
    /// <c>DYNAMIC</c> storage.
    /// </para></li></ul><para><c>StartRun</c> can also duplicate an existing run using the run's default values.
    /// You can modify these default values and/or add other optional inputs. To duplicate
    /// a run, the following inputs are required:
    /// </para><ul><li><para>
    /// A service role ARN (<c>roleArn</c>).
    /// </para></li><li><para>
    /// The ID of the run to duplicate (<c>runId</c>).
    /// </para></li><li><para>
    /// An Amazon S3 location where the run outputs will be saved (<c>outputUri</c>).
    /// </para></li></ul><para>
    /// To learn more about the optional parameters for <c>StartRun</c>, see <a href="https://docs.aws.amazon.com/omics/latest/dev/starting-a-run.html">Starting
    /// a run</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.
    /// </para><para>
    /// Use the <c>retentionMode</c> input to control how long the metadata for each run is
    /// stored in CloudWatch. There are two retention modes:
    /// </para><ul><li><para>
    /// Specify <c>REMOVE</c> to automatically remove the oldest runs when you reach the maximum
    /// service retention limit for runs. It is recommended that you use the <c>REMOVE</c>
    /// mode to initiate major run requests so that your runs do not fail when you reach the
    /// limit.
    /// </para></li><li><para>
    /// The <c>retentionMode</c> is set to the <c>RETAIN</c> mode by default, which allows
    /// you to manually remove runs after reaching the maximum service retention limit. Under
    /// this setting, you cannot create additional runs until you remove the excess runs.
    /// </para></li></ul><para>
    /// To learn more about the retention modes, see <a href="https://docs.aws.amazon.com/omics/latest/dev/run-retention.html">Run
    /// retention mode</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "OMICSRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Omics.Model.StartRunResponse")]
    [AWSCmdlet("Calls the Amazon Omics StartRun API operation.", Operation = new[] {"StartRun"}, SelectReturnType = typeof(Amazon.Omics.Model.StartRunResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.StartRunResponse",
        "This cmdlet returns an Amazon.Omics.Model.StartRunResponse object containing multiple properties."
    )]
    public partial class StartOMICSRunCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CacheBehavior
        /// <summary>
        /// <para>
        /// <para>The cache behavior for the run. You specify this value if you want to override the
        /// default behavior for the cache. You had set the default value when you created the
        /// cache. For more information, see <a href="https://docs.aws.amazon.com/omics/latest/dev/how-run-cache.html#run-cache-behavior">Run
        /// cache behavior</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.CacheBehavior")]
        public Amazon.Omics.CacheBehavior CacheBehavior { get; set; }
        #endregion
        
        #region Parameter CacheId
        /// <summary>
        /// <para>
        /// <para>Identifier of the cache associated with this run. If you don't specify a cache ID,
        /// no task outputs are cached for this run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheId { get; set; }
        #endregion
        
        #region Parameter LogLevel
        /// <summary>
        /// <para>
        /// <para>A log level for the run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.RunLogLevel")]
        public Amazon.Omics.RunLogLevel LogLevel { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the run. This is recommended to view and organize runs in the Amazon Web
        /// Services HealthOmics console and CloudWatch logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OutputUri
        /// <summary>
        /// <para>
        /// <para>An output S3 URI for the run. The S3 bucket must be in the same region as the workflow.
        /// The role ARN must have permission to write to this S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputUri { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>Parameters for the run. The run needs all required parameters and can include optional
        /// parameters. The run cannot include any parameters that are not defined in the parameter
        /// template. To retrieve parameters from the run, use the GetRun API operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Management.Automation.PSObject Parameter { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>Use the run priority (highest: 1) to establish the order of runs in a run group when
        /// you start a run. If multiple runs share the same priority, the run that was initiated
        /// first will have the higher priority. Runs that do not belong to a run group can be
        /// assigned a priority. The priorities of these runs are ranked among other runs that
        /// are not in a run group. For more information, see <a href="https://docs.aws.amazon.com/omics/latest/dev/creating-run-groups.html#run-priority">Run
        /// priority</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// <para>An idempotency token used to dedupe retry requests so that duplicate runs are not
        /// created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter RetentionMode
        /// <summary>
        /// <para>
        /// <para>The retention mode for the run. The default value is <c>RETAIN</c>. </para><para>Amazon Web Services HealthOmics stores a fixed number of runs that are available to
        /// the console and API. In the default mode (<c>RETAIN</c>), you need to remove runs
        /// manually when the number of run exceeds the maximum. If you set the retention mode
        /// to <c>REMOVE</c>, Amazon Web Services HealthOmics automatically removes runs (that
        /// have mode set to <c>REMOVE</c>) when the number of run exceeds the maximum. All run
        /// logs are available in CloudWatch logs, if you need information about a run that is
        /// no longer available to the API.</para><para>For more information about retention mode, see <a href="https://docs.aws.amazon.com/omics/latest/dev/starting-a-run.html">Specifying
        /// run retention mode</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.RunRetentionMode")]
        public Amazon.Omics.RunRetentionMode RetentionMode { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>A service role for the run. The <c>roleArn</c> requires access to Amazon Web Services
        /// HealthOmics, S3, Cloudwatch logs, and EC2. An example <c>roleArn</c> is <c>arn:aws:iam::123456789012:role/omics-service-role-serviceRole-W8O1XMPL7QZ</c>.
        /// In this example, the AWS account ID is <c>123456789012</c> and the role name is <c>omics-service-role-serviceRole-W8O1XMPL7QZ</c>.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter RunGroupId
        /// <summary>
        /// <para>
        /// <para>The run's group ID. Use a run group to cap the compute resources (and number of concurrent
        /// runs) for the runs that you add to the run group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RunGroupId { get; set; }
        #endregion
        
        #region Parameter RunId
        /// <summary>
        /// <para>
        /// <para>The ID of a run to duplicate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RunId { get; set; }
        #endregion
        
        #region Parameter StorageCapacity
        /// <summary>
        /// <para>
        /// <para>The <c>STATIC</c> storage capacity (in gibibytes, GiB) for this run. The default run
        /// storage capacity is 1200 GiB. If your requested storage capacity is unavailable, the
        /// system rounds up the value to the nearest 1200 GiB multiple. If the requested storage
        /// capacity is still unavailable, the system rounds up the value to the nearest 2400
        /// GiB multiple. This field is not required if the storage type is <c>DYNAMIC</c> (the
        /// system ignores any value that you enter).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageCapacity { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>The storage type for the run. If you set the storage type to <c>DYNAMIC</c>, Amazon
        /// Web Services HealthOmics dynamically scales the storage up or down, based on file
        /// system utilization. By default, the run uses <c>STATIC</c> storage type, which allocates
        /// a fixed amount of storage. For more information about <c>DYNAMIC</c> and <c>STATIC</c>
        /// storage, see <a href="https://docs.aws.amazon.com/omics/latest/dev/workflows-run-types.html">Run
        /// storage types</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.StorageType")]
        public Amazon.Omics.StorageType StorageType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags for the run. You can add up to 50 tags per run. For more information, see <a href="https://docs.aws.amazon.com/omics/latest/dev/add-a-tag.html">Adding a tag</a>
        /// in the <i>Amazon Web Services HealthOmics User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter WorkflowId
        /// <summary>
        /// <para>
        /// <para>The run's workflow ID. The <c>workflowId</c> is not the UUID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkflowId { get; set; }
        #endregion
        
        #region Parameter WorkflowOwnerId
        /// <summary>
        /// <para>
        /// <para>The 12-digit account ID of the workflow owner that is used for running a shared workflow.
        /// The workflow owner ID can be retrieved using the <c>GetShare</c> API operation. If
        /// you are the workflow owner, you do not need to include this ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkflowOwnerId { get; set; }
        #endregion
        
        #region Parameter WorkflowType
        /// <summary>
        /// <para>
        /// <para>The run's workflow type. The <c>workflowType</c> must be specified if you are running
        /// a <c>READY2RUN</c> workflow. If you are running a <c>PRIVATE</c> workflow (default),
        /// you do not need to include the workflow type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.WorkflowType")]
        public Amazon.Omics.WorkflowType WorkflowType { get; set; }
        #endregion
        
        #region Parameter WorkflowVersionName
        /// <summary>
        /// <para>
        /// <para>The name of the workflow version. Use workflow versions to track and organize changes
        /// to the workflow. If your workflow has multiple versions, the run uses the default
        /// version unless you specify a version name. To learn more, see <a href="https://docs.aws.amazon.com/omics/latest/dev/workflow-versions.html">Workflow
        /// versioning</a> in the <i>Amazon Web Services HealthOmics User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkflowVersionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.StartRunResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.StartRunResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-OMICSRun (StartRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.StartRunResponse, StartOMICSRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CacheBehavior = this.CacheBehavior;
            context.CacheId = this.CacheId;
            context.LogLevel = this.LogLevel;
            context.Name = this.Name;
            context.OutputUri = this.OutputUri;
            context.Parameter = this.Parameter;
            context.Priority = this.Priority;
            context.RequestId = this.RequestId;
            context.RetentionMode = this.RetentionMode;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RunGroupId = this.RunGroupId;
            context.RunId = this.RunId;
            context.StorageCapacity = this.StorageCapacity;
            context.StorageType = this.StorageType;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.WorkflowId = this.WorkflowId;
            context.WorkflowOwnerId = this.WorkflowOwnerId;
            context.WorkflowType = this.WorkflowType;
            context.WorkflowVersionName = this.WorkflowVersionName;
            
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
            var request = new Amazon.Omics.Model.StartRunRequest();
            
            if (cmdletContext.CacheBehavior != null)
            {
                request.CacheBehavior = cmdletContext.CacheBehavior;
            }
            if (cmdletContext.CacheId != null)
            {
                request.CacheId = cmdletContext.CacheId;
            }
            if (cmdletContext.LogLevel != null)
            {
                request.LogLevel = cmdletContext.LogLevel;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OutputUri != null)
            {
                request.OutputUri = cmdletContext.OutputUri;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Parameter);
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
            }
            if (cmdletContext.RetentionMode != null)
            {
                request.RetentionMode = cmdletContext.RetentionMode;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.RunGroupId != null)
            {
                request.RunGroupId = cmdletContext.RunGroupId;
            }
            if (cmdletContext.RunId != null)
            {
                request.RunId = cmdletContext.RunId;
            }
            if (cmdletContext.StorageCapacity != null)
            {
                request.StorageCapacity = cmdletContext.StorageCapacity.Value;
            }
            if (cmdletContext.StorageType != null)
            {
                request.StorageType = cmdletContext.StorageType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.WorkflowId != null)
            {
                request.WorkflowId = cmdletContext.WorkflowId;
            }
            if (cmdletContext.WorkflowOwnerId != null)
            {
                request.WorkflowOwnerId = cmdletContext.WorkflowOwnerId;
            }
            if (cmdletContext.WorkflowType != null)
            {
                request.WorkflowType = cmdletContext.WorkflowType;
            }
            if (cmdletContext.WorkflowVersionName != null)
            {
                request.WorkflowVersionName = cmdletContext.WorkflowVersionName;
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
        
        private Amazon.Omics.Model.StartRunResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.StartRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "StartRun");
            try
            {
                return client.StartRunAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Omics.CacheBehavior CacheBehavior { get; set; }
            public System.String CacheId { get; set; }
            public Amazon.Omics.RunLogLevel LogLevel { get; set; }
            public System.String Name { get; set; }
            public System.String OutputUri { get; set; }
            public System.Management.Automation.PSObject Parameter { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String RequestId { get; set; }
            public Amazon.Omics.RunRetentionMode RetentionMode { get; set; }
            public System.String RoleArn { get; set; }
            public System.String RunGroupId { get; set; }
            public System.String RunId { get; set; }
            public System.Int32? StorageCapacity { get; set; }
            public Amazon.Omics.StorageType StorageType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String WorkflowId { get; set; }
            public System.String WorkflowOwnerId { get; set; }
            public Amazon.Omics.WorkflowType WorkflowType { get; set; }
            public System.String WorkflowVersionName { get; set; }
            public System.Func<Amazon.Omics.Model.StartRunResponse, StartOMICSRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

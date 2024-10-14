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
using Amazon.MediaConvert;
using Amazon.MediaConvert.Model;

namespace Amazon.PowerShell.Cmdlets.EMC
{
    /// <summary>
    /// Create a new transcoding job. For information about jobs and job settings, see the
    /// User Guide at http://docs.aws.amazon.com/mediaconvert/latest/ug/what-is.html
    /// </summary>
    [Cmdlet("New", "EMCJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConvert.Model.Job")]
    [AWSCmdlet("Calls the AWS Elemental MediaConvert CreateJob API operation.", Operation = new[] {"CreateJob"}, SelectReturnType = typeof(Amazon.MediaConvert.Model.CreateJobResponse))]
    [AWSCmdletOutput("Amazon.MediaConvert.Model.Job or Amazon.MediaConvert.Model.CreateJobResponse",
        "This cmdlet returns an Amazon.MediaConvert.Model.Job object.",
        "The service call response (type Amazon.MediaConvert.Model.CreateJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMCJobCmdlet : AmazonMediaConvertClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BillingTagsSource
        /// <summary>
        /// <para>
        /// Optional. Choose a tag type that AWS
        /// Billing and Cost Management will use to sort your AWS Elemental MediaConvert costs
        /// on any billing report that you set up. Any transcoding outputs that don't have an
        /// associated tag will appear in your billing report unsorted. If you don't choose a
        /// valid value for this field, your job outputs will appear on the billing report unsorted.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConvert.BillingTagsSource")]
        public Amazon.MediaConvert.BillingTagsSource BillingTagsSource { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// Prevent duplicate jobs from being created
        /// and ensure idempotency for your requests. A client request token can be any string
        /// that includes up to 64 ASCII characters. If you reuse a client request token within
        /// one minute of a successful request, the API returns the job details of the original
        /// request instead. For more information see https://docs.aws.amazon.com/mediaconvert/latest/apireference/idempotency.html.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter HopDestination
        /// <summary>
        /// <para>
        /// Optional. Use queue hopping to avoid overly
        /// long waits in the backlog of the queue that you submit your job to. Specify an alternate
        /// queue and the maximum time that your job will wait in the initial queue before hopping.
        /// For more information about this feature, see the AWS Elemental MediaConvert User Guide.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HopDestinations")]
        public Amazon.MediaConvert.Model.HopDestination[] HopDestination { get; set; }
        #endregion
        
        #region Parameter JobEngineVersion
        /// <summary>
        /// <para>
        /// Use Job engine versions to run jobs for
        /// your production workflow on one version, while you test and validate the latest version.
        /// To specify a Job engine version: Enter a date in a YYYY-MM-DD format. For a list of
        /// valid Job engine versions, submit a ListVersions request. To not specify a Job engine
        /// version: Leave blank.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobEngineVersion { get; set; }
        #endregion
        
        #region Parameter JobTemplate
        /// <summary>
        /// <para>
        /// Optional. When you create a job, you can either
        /// specify a job template or specify the transcoding settings individually.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String JobTemplate { get; set; }
        #endregion
        
        #region Parameter AccelerationSettings_Mode
        /// <summary>
        /// <para>
        /// Specify the conditions when the service will run
        /// your job with accelerated transcoding.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConvert.AccelerationMode")]
        public Amazon.MediaConvert.AccelerationMode AccelerationSettings_Mode { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// Optional. Specify the relative priority for this
        /// job. In any given queue, the service begins processing the job with the highest value
        /// first. When more than one job has the same priority, the service begins processing
        /// the job that you submitted first. If you don't specify a priority, the service uses
        /// the default value 0.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter Queue
        /// <summary>
        /// <para>
        /// Optional. When you create a job, you can specify
        /// a queue to send it to. If you don't specify, the job will go to the default queue.
        /// For more about queues, see the User Guide topic at https://docs.aws.amazon.com/mediaconvert/latest/ug/what-is.html.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Queue { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// Required. The IAM role you use for creating this
        /// job. For details about permissions, see the User Guide topic at the User Guide at
        /// https://docs.aws.amazon.com/mediaconvert/latest/ug/iam-role.html.
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
        
        #region Parameter Setting
        /// <summary>
        /// <para>
        /// JobSettings contains all the transcode settings
        /// for a job.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Settings")]
        public Amazon.MediaConvert.Model.JobSettings Setting { get; set; }
        #endregion
        
        #region Parameter SimulateReservedQueue
        /// <summary>
        /// <para>
        /// Optional. Enable this setting when
        /// you run a test job to estimate how many reserved transcoding slots (RTS) you need.
        /// When this is enabled, MediaConvert runs your job from an on-demand queue with similar
        /// performance to what you will see with one RTS in a reserved queue. This setting is
        /// disabled by default.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConvert.SimulateReservedQueue")]
        public Amazon.MediaConvert.SimulateReservedQueue SimulateReservedQueue { get; set; }
        #endregion
        
        #region Parameter StatusUpdateInterval
        /// <summary>
        /// <para>
        /// Optional. Specify how often MediaConvert
        /// sends STATUS_UPDATE events to Amazon CloudWatch Events. Set the interval, in seconds,
        /// between status updates. MediaConvert sends an update at this interval from the time
        /// the service begins processing your job to the time it completes the transcode or encounters
        /// an error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConvert.StatusUpdateInterval")]
        public Amazon.MediaConvert.StatusUpdateInterval StatusUpdateInterval { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// Optional. The tags that you want to add to the resource.
        /// You can tag resources with a key-value pair or with only a key.  Use standard AWS
        /// tags on your job for automatic integration with AWS services and for custom integrations
        /// and workflows.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter UserMetadata
        /// <summary>
        /// <para>
        /// Optional. User-defined metadata that you
        /// want to associate with an MediaConvert job. You specify metadata in key/value pairs.
        ///  Use only for existing integrations or workflows that rely on job metadata tags. Otherwise,
        /// we recommend that you use standard AWS tags.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable UserMetadata { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Job'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConvert.Model.CreateJobResponse).
        /// Specifying the name of a property of type Amazon.MediaConvert.Model.CreateJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Job";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobTemplate parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobTemplate' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobTemplate' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobTemplate), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMCJob (CreateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConvert.Model.CreateJobResponse, NewEMCJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobTemplate;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccelerationSettings_Mode = this.AccelerationSettings_Mode;
            context.BillingTagsSource = this.BillingTagsSource;
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.HopDestination != null)
            {
                context.HopDestination = new List<Amazon.MediaConvert.Model.HopDestination>(this.HopDestination);
            }
            context.JobEngineVersion = this.JobEngineVersion;
            context.JobTemplate = this.JobTemplate;
            context.Priority = this.Priority;
            context.Queue = this.Queue;
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Setting = this.Setting;
            #if MODULAR
            if (this.Setting == null && ParameterWasBound(nameof(this.Setting)))
            {
                WriteWarning("You are passing $null as a value for parameter Setting which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SimulateReservedQueue = this.SimulateReservedQueue;
            context.StatusUpdateInterval = this.StatusUpdateInterval;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.UserMetadata != null)
            {
                context.UserMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.UserMetadata.Keys)
                {
                    context.UserMetadata.Add((String)hashKey, (System.String)(this.UserMetadata[hashKey]));
                }
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
            var request = new Amazon.MediaConvert.Model.CreateJobRequest();
            
            
             // populate AccelerationSettings
            var requestAccelerationSettingsIsNull = true;
            request.AccelerationSettings = new Amazon.MediaConvert.Model.AccelerationSettings();
            Amazon.MediaConvert.AccelerationMode requestAccelerationSettings_accelerationSettings_Mode = null;
            if (cmdletContext.AccelerationSettings_Mode != null)
            {
                requestAccelerationSettings_accelerationSettings_Mode = cmdletContext.AccelerationSettings_Mode;
            }
            if (requestAccelerationSettings_accelerationSettings_Mode != null)
            {
                request.AccelerationSettings.Mode = requestAccelerationSettings_accelerationSettings_Mode;
                requestAccelerationSettingsIsNull = false;
            }
             // determine if request.AccelerationSettings should be set to null
            if (requestAccelerationSettingsIsNull)
            {
                request.AccelerationSettings = null;
            }
            if (cmdletContext.BillingTagsSource != null)
            {
                request.BillingTagsSource = cmdletContext.BillingTagsSource;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.HopDestination != null)
            {
                request.HopDestinations = cmdletContext.HopDestination;
            }
            if (cmdletContext.JobEngineVersion != null)
            {
                request.JobEngineVersion = cmdletContext.JobEngineVersion;
            }
            if (cmdletContext.JobTemplate != null)
            {
                request.JobTemplate = cmdletContext.JobTemplate;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.Queue != null)
            {
                request.Queue = cmdletContext.Queue;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.Setting != null)
            {
                request.Settings = cmdletContext.Setting;
            }
            if (cmdletContext.SimulateReservedQueue != null)
            {
                request.SimulateReservedQueue = cmdletContext.SimulateReservedQueue;
            }
            if (cmdletContext.StatusUpdateInterval != null)
            {
                request.StatusUpdateInterval = cmdletContext.StatusUpdateInterval;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UserMetadata != null)
            {
                request.UserMetadata = cmdletContext.UserMetadata;
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
        
        private Amazon.MediaConvert.Model.CreateJobResponse CallAWSServiceOperation(IAmazonMediaConvert client, Amazon.MediaConvert.Model.CreateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConvert", "CreateJob");
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
            public Amazon.MediaConvert.AccelerationMode AccelerationSettings_Mode { get; set; }
            public Amazon.MediaConvert.BillingTagsSource BillingTagsSource { get; set; }
            public System.String ClientRequestToken { get; set; }
            public List<Amazon.MediaConvert.Model.HopDestination> HopDestination { get; set; }
            public System.String JobEngineVersion { get; set; }
            public System.String JobTemplate { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String Queue { get; set; }
            public System.String Role { get; set; }
            public Amazon.MediaConvert.Model.JobSettings Setting { get; set; }
            public Amazon.MediaConvert.SimulateReservedQueue SimulateReservedQueue { get; set; }
            public Amazon.MediaConvert.StatusUpdateInterval StatusUpdateInterval { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Dictionary<System.String, System.String> UserMetadata { get; set; }
            public System.Func<Amazon.MediaConvert.Model.CreateJobResponse, NewEMCJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Job;
        }
        
    }
}

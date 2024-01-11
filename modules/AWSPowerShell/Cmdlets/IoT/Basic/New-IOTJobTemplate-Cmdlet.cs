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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates a job template.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreateJobTemplate</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTJobTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateJobTemplateResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateJobTemplate API operation.", Operation = new[] {"CreateJobTemplate"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateJobTemplateResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateJobTemplateResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreateJobTemplateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTJobTemplateCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AbortConfig_CriteriaList
        /// <summary>
        /// <para>
        /// <para>The list of criteria that determine when and how to abort the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoT.Model.AbortCriteria[] AbortConfig_CriteriaList { get; set; }
        #endregion
        
        #region Parameter JobExecutionsRetryConfig_CriteriaList
        /// <summary>
        /// <para>
        /// <para>The list of criteria that determines how many retries are allowed for each failure
        /// type for a job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoT.Model.RetryCriteria[] JobExecutionsRetryConfig_CriteriaList { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the job document.</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DestinationPackageVersion
        /// <summary>
        /// <para>
        /// <para>The package version Amazon Resource Names (ARNs) that are installed on the device
        /// when the job successfully completes. The package version must be in either the Published
        /// or Deprecated state when the job deploys. For more information, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/preparing-to-use-software-package-catalog.html#package-version-lifecycle">Package
        /// version lifecycle</a>.</para><para><b>Note:</b>The following Length Constraints relates to a single ARN. Up to 25 package
        /// version ARNs are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationPackageVersions")]
        public System.String[] DestinationPackageVersion { get; set; }
        #endregion
        
        #region Parameter Document
        /// <summary>
        /// <para>
        /// <para>The job document. Required if you don't specify a value for <c>documentSource</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Document { get; set; }
        #endregion
        
        #region Parameter DocumentSource
        /// <summary>
        /// <para>
        /// <para>An S3 link, or S3 object URL, to the job document. The link is an Amazon S3 object
        /// URL and is required if you don't specify a value for <c>document</c>.</para><para>For example, <c>--document-source https://s3.<i>region-code</i>.amazonaws.com/example-firmware/device-firmware.1.0</c></para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-bucket-intro.html">Methods
        /// for accessing a bucket</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentSource { get; set; }
        #endregion
        
        #region Parameter PresignedUrlConfig_ExpiresInSec
        /// <summary>
        /// <para>
        /// <para>How long (in seconds) pre-signed URLs are valid. Valid values are 60 - 3600, the default
        /// value is 3600 seconds. Pre-signed URLs are generated when Jobs receives an MQTT request
        /// for the job document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? PresignedUrlConfig_ExpiresInSec { get; set; }
        #endregion
        
        #region Parameter JobExecutionsRolloutConfig_ExponentialRate
        /// <summary>
        /// <para>
        /// <para>The rate of increase for a job rollout. This parameter allows you to define an exponential
        /// rate for a job rollout.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoT.Model.ExponentialRolloutRate JobExecutionsRolloutConfig_ExponentialRate { get; set; }
        #endregion
        
        #region Parameter TimeoutConfig_InProgressTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>Specifies the amount of time, in minutes, this device has to finish execution of this
        /// job. The timeout interval can be anywhere between 1 minute and 7 days (1 to 10080
        /// minutes). The in progress timer can't be updated and will apply to all job executions
        /// for the job. Whenever a job execution remains in the IN_PROGRESS status for longer
        /// than this interval, the job execution will fail and switch to the terminal <c>TIMED_OUT</c>
        /// status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutConfig_InProgressTimeoutInMinutes")]
        public System.Int64? TimeoutConfig_InProgressTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter JobArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the job to use as the basis for the job template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobArn { get; set; }
        #endregion
        
        #region Parameter JobTemplateId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the job template. We recommend using a UUID. Alpha-numeric
        /// characters, "-", and "_" are valid for use here.</para>
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
        public System.String JobTemplateId { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>Allows you to configure an optional maintenance window for the rollout of a job document
        /// to all devices in the target group for a job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaintenanceWindows")]
        public Amazon.IoT.Model.MaintenanceWindow[] MaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter JobExecutionsRolloutConfig_MaximumPerMinute
        /// <summary>
        /// <para>
        /// <para>The maximum number of things that will be notified of a pending job, per minute. This
        /// parameter allows you to create a staged rollout.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? JobExecutionsRolloutConfig_MaximumPerMinute { get; set; }
        #endregion
        
        #region Parameter PresignedUrlConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that grants permission to download files from the S3 bucket
        /// where the job data/updates are stored. The role must also grant permission for IoT
        /// to download the files.</para><important><para>For information about addressing the confused deputy problem, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/cross-service-confused-deputy-prevention.html">cross-service
        /// confused deputy prevention</a> in the <i>Amazon Web Services IoT Core developer guide</i>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PresignedUrlConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that can be used to manage the job template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoT.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateJobTemplateResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateJobTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobTemplateId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobTemplateId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobTemplateId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobTemplateId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTJobTemplate (CreateJobTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateJobTemplateResponse, NewIOTJobTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobTemplateId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AbortConfig_CriteriaList != null)
            {
                context.AbortConfig_CriteriaList = new List<Amazon.IoT.Model.AbortCriteria>(this.AbortConfig_CriteriaList);
            }
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DestinationPackageVersion != null)
            {
                context.DestinationPackageVersion = new List<System.String>(this.DestinationPackageVersion);
            }
            context.Document = this.Document;
            context.DocumentSource = this.DocumentSource;
            context.JobArn = this.JobArn;
            if (this.JobExecutionsRetryConfig_CriteriaList != null)
            {
                context.JobExecutionsRetryConfig_CriteriaList = new List<Amazon.IoT.Model.RetryCriteria>(this.JobExecutionsRetryConfig_CriteriaList);
            }
            context.JobExecutionsRolloutConfig_ExponentialRate = this.JobExecutionsRolloutConfig_ExponentialRate;
            context.JobExecutionsRolloutConfig_MaximumPerMinute = this.JobExecutionsRolloutConfig_MaximumPerMinute;
            context.JobTemplateId = this.JobTemplateId;
            #if MODULAR
            if (this.JobTemplateId == null && ParameterWasBound(nameof(this.JobTemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobTemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MaintenanceWindow != null)
            {
                context.MaintenanceWindow = new List<Amazon.IoT.Model.MaintenanceWindow>(this.MaintenanceWindow);
            }
            context.PresignedUrlConfig_ExpiresInSec = this.PresignedUrlConfig_ExpiresInSec;
            context.PresignedUrlConfig_RoleArn = this.PresignedUrlConfig_RoleArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoT.Model.Tag>(this.Tag);
            }
            context.TimeoutConfig_InProgressTimeoutInMinute = this.TimeoutConfig_InProgressTimeoutInMinute;
            
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
            var request = new Amazon.IoT.Model.CreateJobTemplateRequest();
            
            
             // populate AbortConfig
            var requestAbortConfigIsNull = true;
            request.AbortConfig = new Amazon.IoT.Model.AbortConfig();
            List<Amazon.IoT.Model.AbortCriteria> requestAbortConfig_abortConfig_CriteriaList = null;
            if (cmdletContext.AbortConfig_CriteriaList != null)
            {
                requestAbortConfig_abortConfig_CriteriaList = cmdletContext.AbortConfig_CriteriaList;
            }
            if (requestAbortConfig_abortConfig_CriteriaList != null)
            {
                request.AbortConfig.CriteriaList = requestAbortConfig_abortConfig_CriteriaList;
                requestAbortConfigIsNull = false;
            }
             // determine if request.AbortConfig should be set to null
            if (requestAbortConfigIsNull)
            {
                request.AbortConfig = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DestinationPackageVersion != null)
            {
                request.DestinationPackageVersions = cmdletContext.DestinationPackageVersion;
            }
            if (cmdletContext.Document != null)
            {
                request.Document = cmdletContext.Document;
            }
            if (cmdletContext.DocumentSource != null)
            {
                request.DocumentSource = cmdletContext.DocumentSource;
            }
            if (cmdletContext.JobArn != null)
            {
                request.JobArn = cmdletContext.JobArn;
            }
            
             // populate JobExecutionsRetryConfig
            var requestJobExecutionsRetryConfigIsNull = true;
            request.JobExecutionsRetryConfig = new Amazon.IoT.Model.JobExecutionsRetryConfig();
            List<Amazon.IoT.Model.RetryCriteria> requestJobExecutionsRetryConfig_jobExecutionsRetryConfig_CriteriaList = null;
            if (cmdletContext.JobExecutionsRetryConfig_CriteriaList != null)
            {
                requestJobExecutionsRetryConfig_jobExecutionsRetryConfig_CriteriaList = cmdletContext.JobExecutionsRetryConfig_CriteriaList;
            }
            if (requestJobExecutionsRetryConfig_jobExecutionsRetryConfig_CriteriaList != null)
            {
                request.JobExecutionsRetryConfig.CriteriaList = requestJobExecutionsRetryConfig_jobExecutionsRetryConfig_CriteriaList;
                requestJobExecutionsRetryConfigIsNull = false;
            }
             // determine if request.JobExecutionsRetryConfig should be set to null
            if (requestJobExecutionsRetryConfigIsNull)
            {
                request.JobExecutionsRetryConfig = null;
            }
            
             // populate JobExecutionsRolloutConfig
            var requestJobExecutionsRolloutConfigIsNull = true;
            request.JobExecutionsRolloutConfig = new Amazon.IoT.Model.JobExecutionsRolloutConfig();
            Amazon.IoT.Model.ExponentialRolloutRate requestJobExecutionsRolloutConfig_jobExecutionsRolloutConfig_ExponentialRate = null;
            if (cmdletContext.JobExecutionsRolloutConfig_ExponentialRate != null)
            {
                requestJobExecutionsRolloutConfig_jobExecutionsRolloutConfig_ExponentialRate = cmdletContext.JobExecutionsRolloutConfig_ExponentialRate;
            }
            if (requestJobExecutionsRolloutConfig_jobExecutionsRolloutConfig_ExponentialRate != null)
            {
                request.JobExecutionsRolloutConfig.ExponentialRate = requestJobExecutionsRolloutConfig_jobExecutionsRolloutConfig_ExponentialRate;
                requestJobExecutionsRolloutConfigIsNull = false;
            }
            System.Int32? requestJobExecutionsRolloutConfig_jobExecutionsRolloutConfig_MaximumPerMinute = null;
            if (cmdletContext.JobExecutionsRolloutConfig_MaximumPerMinute != null)
            {
                requestJobExecutionsRolloutConfig_jobExecutionsRolloutConfig_MaximumPerMinute = cmdletContext.JobExecutionsRolloutConfig_MaximumPerMinute.Value;
            }
            if (requestJobExecutionsRolloutConfig_jobExecutionsRolloutConfig_MaximumPerMinute != null)
            {
                request.JobExecutionsRolloutConfig.MaximumPerMinute = requestJobExecutionsRolloutConfig_jobExecutionsRolloutConfig_MaximumPerMinute.Value;
                requestJobExecutionsRolloutConfigIsNull = false;
            }
             // determine if request.JobExecutionsRolloutConfig should be set to null
            if (requestJobExecutionsRolloutConfigIsNull)
            {
                request.JobExecutionsRolloutConfig = null;
            }
            if (cmdletContext.JobTemplateId != null)
            {
                request.JobTemplateId = cmdletContext.JobTemplateId;
            }
            if (cmdletContext.MaintenanceWindow != null)
            {
                request.MaintenanceWindows = cmdletContext.MaintenanceWindow;
            }
            
             // populate PresignedUrlConfig
            var requestPresignedUrlConfigIsNull = true;
            request.PresignedUrlConfig = new Amazon.IoT.Model.PresignedUrlConfig();
            System.Int64? requestPresignedUrlConfig_presignedUrlConfig_ExpiresInSec = null;
            if (cmdletContext.PresignedUrlConfig_ExpiresInSec != null)
            {
                requestPresignedUrlConfig_presignedUrlConfig_ExpiresInSec = cmdletContext.PresignedUrlConfig_ExpiresInSec.Value;
            }
            if (requestPresignedUrlConfig_presignedUrlConfig_ExpiresInSec != null)
            {
                request.PresignedUrlConfig.ExpiresInSec = requestPresignedUrlConfig_presignedUrlConfig_ExpiresInSec.Value;
                requestPresignedUrlConfigIsNull = false;
            }
            System.String requestPresignedUrlConfig_presignedUrlConfig_RoleArn = null;
            if (cmdletContext.PresignedUrlConfig_RoleArn != null)
            {
                requestPresignedUrlConfig_presignedUrlConfig_RoleArn = cmdletContext.PresignedUrlConfig_RoleArn;
            }
            if (requestPresignedUrlConfig_presignedUrlConfig_RoleArn != null)
            {
                request.PresignedUrlConfig.RoleArn = requestPresignedUrlConfig_presignedUrlConfig_RoleArn;
                requestPresignedUrlConfigIsNull = false;
            }
             // determine if request.PresignedUrlConfig should be set to null
            if (requestPresignedUrlConfigIsNull)
            {
                request.PresignedUrlConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TimeoutConfig
            var requestTimeoutConfigIsNull = true;
            request.TimeoutConfig = new Amazon.IoT.Model.TimeoutConfig();
            System.Int64? requestTimeoutConfig_timeoutConfig_InProgressTimeoutInMinute = null;
            if (cmdletContext.TimeoutConfig_InProgressTimeoutInMinute != null)
            {
                requestTimeoutConfig_timeoutConfig_InProgressTimeoutInMinute = cmdletContext.TimeoutConfig_InProgressTimeoutInMinute.Value;
            }
            if (requestTimeoutConfig_timeoutConfig_InProgressTimeoutInMinute != null)
            {
                request.TimeoutConfig.InProgressTimeoutInMinutes = requestTimeoutConfig_timeoutConfig_InProgressTimeoutInMinute.Value;
                requestTimeoutConfigIsNull = false;
            }
             // determine if request.TimeoutConfig should be set to null
            if (requestTimeoutConfigIsNull)
            {
                request.TimeoutConfig = null;
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
        
        private Amazon.IoT.Model.CreateJobTemplateResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateJobTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateJobTemplate");
            try
            {
                #if DESKTOP
                return client.CreateJobTemplate(request);
                #elif CORECLR
                return client.CreateJobTemplateAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.IoT.Model.AbortCriteria> AbortConfig_CriteriaList { get; set; }
            public System.String Description { get; set; }
            public List<System.String> DestinationPackageVersion { get; set; }
            public System.String Document { get; set; }
            public System.String DocumentSource { get; set; }
            public System.String JobArn { get; set; }
            public List<Amazon.IoT.Model.RetryCriteria> JobExecutionsRetryConfig_CriteriaList { get; set; }
            public Amazon.IoT.Model.ExponentialRolloutRate JobExecutionsRolloutConfig_ExponentialRate { get; set; }
            public System.Int32? JobExecutionsRolloutConfig_MaximumPerMinute { get; set; }
            public System.String JobTemplateId { get; set; }
            public List<Amazon.IoT.Model.MaintenanceWindow> MaintenanceWindow { get; set; }
            public System.Int64? PresignedUrlConfig_ExpiresInSec { get; set; }
            public System.String PresignedUrlConfig_RoleArn { get; set; }
            public List<Amazon.IoT.Model.Tag> Tag { get; set; }
            public System.Int64? TimeoutConfig_InProgressTimeoutInMinute { get; set; }
            public System.Func<Amazon.IoT.Model.CreateJobTemplateResponse, NewIOTJobTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

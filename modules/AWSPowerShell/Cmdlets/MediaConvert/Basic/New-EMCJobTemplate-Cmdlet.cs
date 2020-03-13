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
    /// Create a new job template. For information about job templates see the User Guide
    /// at http://docs.aws.amazon.com/mediaconvert/latest/ug/what-is.html
    /// </summary>
    [Cmdlet("New", "EMCJobTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConvert.Model.JobTemplate")]
    [AWSCmdlet("Calls the AWS Elemental MediaConvert CreateJobTemplate API operation.", Operation = new[] {"CreateJobTemplate"}, SelectReturnType = typeof(Amazon.MediaConvert.Model.CreateJobTemplateResponse))]
    [AWSCmdletOutput("Amazon.MediaConvert.Model.JobTemplate or Amazon.MediaConvert.Model.CreateJobTemplateResponse",
        "This cmdlet returns an Amazon.MediaConvert.Model.JobTemplate object.",
        "The service call response (type Amazon.MediaConvert.Model.CreateJobTemplateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMCJobTemplateCmdlet : AmazonMediaConvertClientCmdlet, IExecutor
    {
        
        #region Parameter Category
        /// <summary>
        /// <para>
        /// Optional. A category for the job template you
        /// are creating
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Category { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// Optional. A description of the job template
        /// you are creating.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the job template you are creating.
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
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// Specify the relative priority for this job. In
        /// any given queue, the service begins processing the job with the highest value first.
        /// When more than one job has the same priority, the service begins processing the job
        /// that you submitted first. If you don't specify a priority, the service uses the default
        /// value 0.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter Queue
        /// <summary>
        /// <para>
        /// Optional. The queue that jobs created from this
        /// template are assigned to. If you don't specify this, jobs will go to the default queue.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Queue { get; set; }
        #endregion
        
        #region Parameter Setting
        /// <summary>
        /// <para>
        /// JobTemplateSettings contains all the transcode
        /// settings saved in the template that will be applied to jobs created from it.
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
        public Amazon.MediaConvert.Model.JobTemplateSettings Setting { get; set; }
        #endregion
        
        #region Parameter StatusUpdateInterval
        /// <summary>
        /// <para>
        /// Specify how often MediaConvert sends
        /// STATUS_UPDATE events to Amazon CloudWatch Events. Set the interval, in seconds, between
        /// status updates. MediaConvert sends an update at this interval from the time the service
        /// begins processing your job to the time it completes the transcode or encounters an
        /// error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConvert.StatusUpdateInterval")]
        public Amazon.MediaConvert.StatusUpdateInterval StatusUpdateInterval { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The tags that you want to add to the resource. You
        /// can tag resources with a key-value pair or with only a key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConvert.Model.CreateJobTemplateResponse).
        /// Specifying the name of a property of type Amazon.MediaConvert.Model.CreateJobTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobTemplate";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Queue parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Queue' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Queue' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMCJobTemplate (CreateJobTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConvert.Model.CreateJobTemplateResponse, NewEMCJobTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Queue;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccelerationSettings_Mode = this.AccelerationSettings_Mode;
            context.Category = this.Category;
            context.Description = this.Description;
            if (this.HopDestination != null)
            {
                context.HopDestination = new List<Amazon.MediaConvert.Model.HopDestination>(this.HopDestination);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Priority = this.Priority;
            context.Queue = this.Queue;
            context.Setting = this.Setting;
            #if MODULAR
            if (this.Setting == null && ParameterWasBound(nameof(this.Setting)))
            {
                WriteWarning("You are passing $null as a value for parameter Setting which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StatusUpdateInterval = this.StatusUpdateInterval;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.MediaConvert.Model.CreateJobTemplateRequest();
            
            
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
            if (cmdletContext.Category != null)
            {
                request.Category = cmdletContext.Category;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.HopDestination != null)
            {
                request.HopDestinations = cmdletContext.HopDestination;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.Queue != null)
            {
                request.Queue = cmdletContext.Queue;
            }
            if (cmdletContext.Setting != null)
            {
                request.Settings = cmdletContext.Setting;
            }
            if (cmdletContext.StatusUpdateInterval != null)
            {
                request.StatusUpdateInterval = cmdletContext.StatusUpdateInterval;
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
        
        private Amazon.MediaConvert.Model.CreateJobTemplateResponse CallAWSServiceOperation(IAmazonMediaConvert client, Amazon.MediaConvert.Model.CreateJobTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConvert", "CreateJobTemplate");
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
            public Amazon.MediaConvert.AccelerationMode AccelerationSettings_Mode { get; set; }
            public System.String Category { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.MediaConvert.Model.HopDestination> HopDestination { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String Queue { get; set; }
            public Amazon.MediaConvert.Model.JobTemplateSettings Setting { get; set; }
            public Amazon.MediaConvert.StatusUpdateInterval StatusUpdateInterval { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaConvert.Model.CreateJobTemplateResponse, NewEMCJobTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobTemplate;
        }
        
    }
}

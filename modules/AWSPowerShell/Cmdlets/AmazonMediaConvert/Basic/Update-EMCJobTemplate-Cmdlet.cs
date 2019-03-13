/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Modify one of your existing job templates.
    /// </summary>
    [Cmdlet("Update", "EMCJobTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConvert.Model.JobTemplate")]
    [AWSCmdlet("Calls the AWS Elemental MediaConvert UpdateJobTemplate API operation.", Operation = new[] {"UpdateJobTemplate"})]
    [AWSCmdletOutput("Amazon.MediaConvert.Model.JobTemplate",
        "This cmdlet returns a JobTemplate object.",
        "The service call response (type Amazon.MediaConvert.Model.UpdateJobTemplateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEMCJobTemplateCmdlet : AmazonMediaConvertClientCmdlet, IExecutor
    {
        
        #region Parameter Category
        /// <summary>
        /// <para>
        /// The new category for the job template, if you
        /// are changing it.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Category { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The new description for the job template,
        /// if you are changing it.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AccelerationSettings_Mode
        /// <summary>
        /// <para>
        /// Acceleration configuration for the job.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MediaConvert.AccelerationMode")]
        public Amazon.MediaConvert.AccelerationMode AccelerationSettings_Mode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the job template you are modifying
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Queue
        /// <summary>
        /// <para>
        /// The new queue for the job template, if you are changing
        /// it.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Queue { get; set; }
        #endregion
        
        #region Parameter Setting
        /// <summary>
        /// <para>
        /// JobTemplateSettings contains all the transcode
        /// settings saved in the template that will be applied to jobs created from it.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MediaConvert.StatusUpdateInterval")]
        public Amazon.MediaConvert.StatusUpdateInterval StatusUpdateInterval { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCJobTemplate (UpdateJobTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AccelerationSettings_Mode = this.AccelerationSettings_Mode;
            context.Category = this.Category;
            context.Description = this.Description;
            context.Name = this.Name;
            context.Queue = this.Queue;
            context.Settings = this.Setting;
            context.StatusUpdateInterval = this.StatusUpdateInterval;
            
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
            var request = new Amazon.MediaConvert.Model.UpdateJobTemplateRequest();
            
            
             // populate AccelerationSettings
            bool requestAccelerationSettingsIsNull = true;
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Queue != null)
            {
                request.Queue = cmdletContext.Queue;
            }
            if (cmdletContext.Settings != null)
            {
                request.Settings = cmdletContext.Settings;
            }
            if (cmdletContext.StatusUpdateInterval != null)
            {
                request.StatusUpdateInterval = cmdletContext.StatusUpdateInterval;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.JobTemplate;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.MediaConvert.Model.UpdateJobTemplateResponse CallAWSServiceOperation(IAmazonMediaConvert client, Amazon.MediaConvert.Model.UpdateJobTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConvert", "UpdateJobTemplate");
            try
            {
                #if DESKTOP
                return client.UpdateJobTemplate(request);
                #elif CORECLR
                return client.UpdateJobTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String Queue { get; set; }
            public Amazon.MediaConvert.Model.JobTemplateSettings Settings { get; set; }
            public Amazon.MediaConvert.StatusUpdateInterval StatusUpdateInterval { get; set; }
        }
        
    }
}

/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a job.
    /// </summary>
    [Cmdlet("New", "IOTJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateJobResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateJob API operation.", Operation = new[] {"CreateJob"})]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateJobResponse",
        "This cmdlet returns a Amazon.IoT.Model.CreateJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTJobCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A short text description of the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Document
        /// <summary>
        /// <para>
        /// <para>The job document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Document { get; set; }
        #endregion
        
        #region Parameter DocumentParameter
        /// <summary>
        /// <para>
        /// <para>Parameters for the job document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DocumentParameters")]
        public System.Collections.Hashtable DocumentParameter { get; set; }
        #endregion
        
        #region Parameter DocumentSource
        /// <summary>
        /// <para>
        /// <para>An S3 link to the job document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.Int64 PresignedUrlConfig_ExpiresInSec { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>A job identifier which must be unique for your AWS account. We recommend using a UUID.
        /// Alpha-numeric characters, "-" and "_" are valid for use here.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter JobExecutionsRolloutConfig_MaximumPerMinute
        /// <summary>
        /// <para>
        /// <para>The maximum number of things that will be notified of a pending job, per minute. This
        /// parameter allows you to create a staged rollout.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 JobExecutionsRolloutConfig_MaximumPerMinute { get; set; }
        #endregion
        
        #region Parameter PresignedUrlConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that grants grants permission to download files from the S3
        /// bucket where the job data/updates are stored. The role must also grant permission
        /// for IoT to download the files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PresignedUrlConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>A list of things and thing groups to which the job should be sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Targets")]
        public System.String[] Target { get; set; }
        #endregion
        
        #region Parameter TargetSelection
        /// <summary>
        /// <para>
        /// <para>Specifies whether the job will continue to run (CONTINUOUS), or will be complete after
        /// all those things specified as targets have completed the job (SNAPSHOT). If continuous,
        /// the job may also be run on a thing when a change is detected in a target. For example,
        /// a job will run on a thing when the thing is added to a target group, even after the
        /// job was completed by all things originally in the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoT.TargetSelection")]
        public Amazon.IoT.TargetSelection TargetSelection { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("JobId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTJob (CreateJob)"))
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
            
            context.Description = this.Description;
            context.Document = this.Document;
            if (this.DocumentParameter != null)
            {
                context.DocumentParameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DocumentParameter.Keys)
                {
                    context.DocumentParameters.Add((String)hashKey, (String)(this.DocumentParameter[hashKey]));
                }
            }
            context.DocumentSource = this.DocumentSource;
            if (ParameterWasBound("JobExecutionsRolloutConfig_MaximumPerMinute"))
                context.JobExecutionsRolloutConfig_MaximumPerMinute = this.JobExecutionsRolloutConfig_MaximumPerMinute;
            context.JobId = this.JobId;
            if (ParameterWasBound("PresignedUrlConfig_ExpiresInSec"))
                context.PresignedUrlConfig_ExpiresInSec = this.PresignedUrlConfig_ExpiresInSec;
            context.PresignedUrlConfig_RoleArn = this.PresignedUrlConfig_RoleArn;
            if (this.Target != null)
            {
                context.Targets = new List<System.String>(this.Target);
            }
            context.TargetSelection = this.TargetSelection;
            
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
            var request = new Amazon.IoT.Model.CreateJobRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Document != null)
            {
                request.Document = cmdletContext.Document;
            }
            if (cmdletContext.DocumentParameters != null)
            {
                request.DocumentParameters = cmdletContext.DocumentParameters;
            }
            if (cmdletContext.DocumentSource != null)
            {
                request.DocumentSource = cmdletContext.DocumentSource;
            }
            
             // populate JobExecutionsRolloutConfig
            bool requestJobExecutionsRolloutConfigIsNull = true;
            request.JobExecutionsRolloutConfig = new Amazon.IoT.Model.JobExecutionsRolloutConfig();
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
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            
             // populate PresignedUrlConfig
            bool requestPresignedUrlConfigIsNull = true;
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
            if (cmdletContext.Targets != null)
            {
                request.Targets = cmdletContext.Targets;
            }
            if (cmdletContext.TargetSelection != null)
            {
                request.TargetSelection = cmdletContext.TargetSelection;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.IoT.Model.CreateJobResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateJob");
            try
            {
                #if DESKTOP
                return client.CreateJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateJobAsync(request);
                return task.Result;
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
            public System.String Description { get; set; }
            public System.String Document { get; set; }
            public Dictionary<System.String, System.String> DocumentParameters { get; set; }
            public System.String DocumentSource { get; set; }
            public System.Int32? JobExecutionsRolloutConfig_MaximumPerMinute { get; set; }
            public System.String JobId { get; set; }
            public System.Int64? PresignedUrlConfig_ExpiresInSec { get; set; }
            public System.String PresignedUrlConfig_RoleArn { get; set; }
            public List<System.String> Targets { get; set; }
            public Amazon.IoT.TargetSelection TargetSelection { get; set; }
        }
        
    }
}

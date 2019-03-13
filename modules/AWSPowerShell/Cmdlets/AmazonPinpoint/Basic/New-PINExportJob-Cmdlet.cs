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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Creates an export job.
    /// </summary>
    [Cmdlet("New", "PINExportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.ExportJobResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint CreateExportJob API operation.", Operation = new[] {"CreateExportJob"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.ExportJobResponse",
        "This cmdlet returns a ExportJobResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateExportJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINExportJobCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// The unique ID of your Amazon Pinpoint application.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter ExportJobRequest_RoleArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of an IAM role
        /// that grants Amazon Pinpoint access to the Amazon S3 location that endpoints will be
        /// exported to.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExportJobRequest_RoleArn { get; set; }
        #endregion
        
        #region Parameter ExportJobRequest_S3UrlPrefix
        /// <summary>
        /// <para>
        /// A URL that points to the location within an
        /// Amazon S3 bucket that will receive the export. The location is typically a folder
        /// with multiple files.The URL should follow this format: s3://bucket-name/folder-name/Amazon
        /// Pinpoint will export endpoints to this location.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExportJobRequest_S3UrlPrefix { get; set; }
        #endregion
        
        #region Parameter ExportJobRequest_SegmentId
        /// <summary>
        /// <para>
        /// The ID of the segment to export endpoints from.
        /// If not present, Amazon Pinpoint exports all of the endpoints that belong to the application.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExportJobRequest_SegmentId { get; set; }
        #endregion
        
        #region Parameter ExportJobRequest_SegmentVersion
        /// <summary>
        /// <para>
        /// The version of the segment to export if
        /// specified.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ExportJobRequest_SegmentVersion { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINExportJob (CreateExportJob)"))
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
            
            context.ApplicationId = this.ApplicationId;
            context.ExportJobRequest_RoleArn = this.ExportJobRequest_RoleArn;
            context.ExportJobRequest_S3UrlPrefix = this.ExportJobRequest_S3UrlPrefix;
            context.ExportJobRequest_SegmentId = this.ExportJobRequest_SegmentId;
            if (ParameterWasBound("ExportJobRequest_SegmentVersion"))
                context.ExportJobRequest_SegmentVersion = this.ExportJobRequest_SegmentVersion;
            
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
            var request = new Amazon.Pinpoint.Model.CreateExportJobRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate ExportJobRequest
            bool requestExportJobRequestIsNull = true;
            request.ExportJobRequest = new Amazon.Pinpoint.Model.ExportJobRequest();
            System.String requestExportJobRequest_exportJobRequest_RoleArn = null;
            if (cmdletContext.ExportJobRequest_RoleArn != null)
            {
                requestExportJobRequest_exportJobRequest_RoleArn = cmdletContext.ExportJobRequest_RoleArn;
            }
            if (requestExportJobRequest_exportJobRequest_RoleArn != null)
            {
                request.ExportJobRequest.RoleArn = requestExportJobRequest_exportJobRequest_RoleArn;
                requestExportJobRequestIsNull = false;
            }
            System.String requestExportJobRequest_exportJobRequest_S3UrlPrefix = null;
            if (cmdletContext.ExportJobRequest_S3UrlPrefix != null)
            {
                requestExportJobRequest_exportJobRequest_S3UrlPrefix = cmdletContext.ExportJobRequest_S3UrlPrefix;
            }
            if (requestExportJobRequest_exportJobRequest_S3UrlPrefix != null)
            {
                request.ExportJobRequest.S3UrlPrefix = requestExportJobRequest_exportJobRequest_S3UrlPrefix;
                requestExportJobRequestIsNull = false;
            }
            System.String requestExportJobRequest_exportJobRequest_SegmentId = null;
            if (cmdletContext.ExportJobRequest_SegmentId != null)
            {
                requestExportJobRequest_exportJobRequest_SegmentId = cmdletContext.ExportJobRequest_SegmentId;
            }
            if (requestExportJobRequest_exportJobRequest_SegmentId != null)
            {
                request.ExportJobRequest.SegmentId = requestExportJobRequest_exportJobRequest_SegmentId;
                requestExportJobRequestIsNull = false;
            }
            System.Int32? requestExportJobRequest_exportJobRequest_SegmentVersion = null;
            if (cmdletContext.ExportJobRequest_SegmentVersion != null)
            {
                requestExportJobRequest_exportJobRequest_SegmentVersion = cmdletContext.ExportJobRequest_SegmentVersion.Value;
            }
            if (requestExportJobRequest_exportJobRequest_SegmentVersion != null)
            {
                request.ExportJobRequest.SegmentVersion = requestExportJobRequest_exportJobRequest_SegmentVersion.Value;
                requestExportJobRequestIsNull = false;
            }
             // determine if request.ExportJobRequest should be set to null
            if (requestExportJobRequestIsNull)
            {
                request.ExportJobRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ExportJobResponse;
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
        
        private Amazon.Pinpoint.Model.CreateExportJobResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.CreateExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "CreateExportJob");
            try
            {
                #if DESKTOP
                return client.CreateExportJob(request);
                #elif CORECLR
                return client.CreateExportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String ExportJobRequest_RoleArn { get; set; }
            public System.String ExportJobRequest_S3UrlPrefix { get; set; }
            public System.String ExportJobRequest_SegmentId { get; set; }
            public System.Int32? ExportJobRequest_SegmentVersion { get; set; }
        }
        
    }
}

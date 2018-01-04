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
    /// Creates or updates an import job.
    /// </summary>
    [Cmdlet("New", "PINImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.ImportJobResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint CreateImportJob API operation.", Operation = new[] {"CreateImportJob"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.ImportJobResponse",
        "This cmdlet returns a ImportJobResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateImportJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINImportJobCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_DefineSegment
        /// <summary>
        /// <para>
        /// Sets whether the endpoints create a segment
        /// when they are imported.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ImportJobRequest_DefineSegment { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_ExternalId
        /// <summary>
        /// <para>
        /// A unique, custom ID assigned to the IAM role
        /// that restricts who can assume the role.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImportJobRequest_ExternalId { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_Format
        /// <summary>
        /// <para>
        /// The format of the files that contain the endpoint
        /// definitions.Valid values: CSV, JSON
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Pinpoint.Format")]
        public Amazon.Pinpoint.Format ImportJobRequest_Format { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_RegisterEndpoint
        /// <summary>
        /// <para>
        /// Sets whether the endpoints are registered
        /// with Amazon Pinpoint when they are imported.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ImportJobRequest_RegisterEndpoints")]
        public System.Boolean ImportJobRequest_RegisterEndpoint { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_RoleArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of an IAM role
        /// that grants Amazon Pinpoint access to the Amazon S3 location that contains the endpoints
        /// to import.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImportJobRequest_RoleArn { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_S3Url
        /// <summary>
        /// <para>
        /// A URL that points to the location within an Amazon
        /// S3 bucket that contains the endpoints to import. The location can be a folder or a
        /// single file.The URL should follow this format: s3://bucket-name/folder-name/file-nameAmazon
        /// Pinpoint will import endpoints from this location and any subfolders it contains.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImportJobRequest_S3Url { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_SegmentId
        /// <summary>
        /// <para>
        /// The ID of the segment to update if the import
        /// job is meant to update an existing segment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImportJobRequest_SegmentId { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_SegmentName
        /// <summary>
        /// <para>
        /// A custom name for the segment created by the
        /// import job. Use if DefineSegment is true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImportJobRequest_SegmentName { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINImportJob (CreateImportJob)"))
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
            if (ParameterWasBound("ImportJobRequest_DefineSegment"))
                context.ImportJobRequest_DefineSegment = this.ImportJobRequest_DefineSegment;
            context.ImportJobRequest_ExternalId = this.ImportJobRequest_ExternalId;
            context.ImportJobRequest_Format = this.ImportJobRequest_Format;
            if (ParameterWasBound("ImportJobRequest_RegisterEndpoint"))
                context.ImportJobRequest_RegisterEndpoints = this.ImportJobRequest_RegisterEndpoint;
            context.ImportJobRequest_RoleArn = this.ImportJobRequest_RoleArn;
            context.ImportJobRequest_S3Url = this.ImportJobRequest_S3Url;
            context.ImportJobRequest_SegmentId = this.ImportJobRequest_SegmentId;
            context.ImportJobRequest_SegmentName = this.ImportJobRequest_SegmentName;
            
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
            var request = new Amazon.Pinpoint.Model.CreateImportJobRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate ImportJobRequest
            bool requestImportJobRequestIsNull = true;
            request.ImportJobRequest = new Amazon.Pinpoint.Model.ImportJobRequest();
            System.Boolean? requestImportJobRequest_importJobRequest_DefineSegment = null;
            if (cmdletContext.ImportJobRequest_DefineSegment != null)
            {
                requestImportJobRequest_importJobRequest_DefineSegment = cmdletContext.ImportJobRequest_DefineSegment.Value;
            }
            if (requestImportJobRequest_importJobRequest_DefineSegment != null)
            {
                request.ImportJobRequest.DefineSegment = requestImportJobRequest_importJobRequest_DefineSegment.Value;
                requestImportJobRequestIsNull = false;
            }
            System.String requestImportJobRequest_importJobRequest_ExternalId = null;
            if (cmdletContext.ImportJobRequest_ExternalId != null)
            {
                requestImportJobRequest_importJobRequest_ExternalId = cmdletContext.ImportJobRequest_ExternalId;
            }
            if (requestImportJobRequest_importJobRequest_ExternalId != null)
            {
                request.ImportJobRequest.ExternalId = requestImportJobRequest_importJobRequest_ExternalId;
                requestImportJobRequestIsNull = false;
            }
            Amazon.Pinpoint.Format requestImportJobRequest_importJobRequest_Format = null;
            if (cmdletContext.ImportJobRequest_Format != null)
            {
                requestImportJobRequest_importJobRequest_Format = cmdletContext.ImportJobRequest_Format;
            }
            if (requestImportJobRequest_importJobRequest_Format != null)
            {
                request.ImportJobRequest.Format = requestImportJobRequest_importJobRequest_Format;
                requestImportJobRequestIsNull = false;
            }
            System.Boolean? requestImportJobRequest_importJobRequest_RegisterEndpoint = null;
            if (cmdletContext.ImportJobRequest_RegisterEndpoints != null)
            {
                requestImportJobRequest_importJobRequest_RegisterEndpoint = cmdletContext.ImportJobRequest_RegisterEndpoints.Value;
            }
            if (requestImportJobRequest_importJobRequest_RegisterEndpoint != null)
            {
                request.ImportJobRequest.RegisterEndpoints = requestImportJobRequest_importJobRequest_RegisterEndpoint.Value;
                requestImportJobRequestIsNull = false;
            }
            System.String requestImportJobRequest_importJobRequest_RoleArn = null;
            if (cmdletContext.ImportJobRequest_RoleArn != null)
            {
                requestImportJobRequest_importJobRequest_RoleArn = cmdletContext.ImportJobRequest_RoleArn;
            }
            if (requestImportJobRequest_importJobRequest_RoleArn != null)
            {
                request.ImportJobRequest.RoleArn = requestImportJobRequest_importJobRequest_RoleArn;
                requestImportJobRequestIsNull = false;
            }
            System.String requestImportJobRequest_importJobRequest_S3Url = null;
            if (cmdletContext.ImportJobRequest_S3Url != null)
            {
                requestImportJobRequest_importJobRequest_S3Url = cmdletContext.ImportJobRequest_S3Url;
            }
            if (requestImportJobRequest_importJobRequest_S3Url != null)
            {
                request.ImportJobRequest.S3Url = requestImportJobRequest_importJobRequest_S3Url;
                requestImportJobRequestIsNull = false;
            }
            System.String requestImportJobRequest_importJobRequest_SegmentId = null;
            if (cmdletContext.ImportJobRequest_SegmentId != null)
            {
                requestImportJobRequest_importJobRequest_SegmentId = cmdletContext.ImportJobRequest_SegmentId;
            }
            if (requestImportJobRequest_importJobRequest_SegmentId != null)
            {
                request.ImportJobRequest.SegmentId = requestImportJobRequest_importJobRequest_SegmentId;
                requestImportJobRequestIsNull = false;
            }
            System.String requestImportJobRequest_importJobRequest_SegmentName = null;
            if (cmdletContext.ImportJobRequest_SegmentName != null)
            {
                requestImportJobRequest_importJobRequest_SegmentName = cmdletContext.ImportJobRequest_SegmentName;
            }
            if (requestImportJobRequest_importJobRequest_SegmentName != null)
            {
                request.ImportJobRequest.SegmentName = requestImportJobRequest_importJobRequest_SegmentName;
                requestImportJobRequestIsNull = false;
            }
             // determine if request.ImportJobRequest should be set to null
            if (requestImportJobRequestIsNull)
            {
                request.ImportJobRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ImportJobResponse;
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
        
        private Amazon.Pinpoint.Model.CreateImportJobResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.CreateImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "CreateImportJob");
            try
            {
                #if DESKTOP
                return client.CreateImportJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateImportJobAsync(request);
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
            public System.String ApplicationId { get; set; }
            public System.Boolean? ImportJobRequest_DefineSegment { get; set; }
            public System.String ImportJobRequest_ExternalId { get; set; }
            public Amazon.Pinpoint.Format ImportJobRequest_Format { get; set; }
            public System.Boolean? ImportJobRequest_RegisterEndpoints { get; set; }
            public System.String ImportJobRequest_RoleArn { get; set; }
            public System.String ImportJobRequest_S3Url { get; set; }
            public System.String ImportJobRequest_SegmentId { get; set; }
            public System.String ImportJobRequest_SegmentName { get; set; }
        }
        
    }
}

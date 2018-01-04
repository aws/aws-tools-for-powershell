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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Exports a running or stopped instance to an S3 bucket.
    /// 
    ///  
    /// <para>
    /// For information about the supported operating systems, image formats, and known limitations
    /// for the types of instances you can export, see <a href="http://docs.aws.amazon.com/vm-import/latest/userguide/vmexport.html">Exporting
    /// an Instance as a VM Using VM Import/Export</a> in the <i>VM Import/Export User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2InstanceExportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ExportTask")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateInstanceExportTask API operation.", Operation = new[] {"CreateInstanceExportTask"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ExportTask",
        "This cmdlet returns a ExportTask object.",
        "The service call response (type Amazon.EC2.Model.CreateInstanceExportTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2InstanceExportTaskCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter ExportToS3Task_ContainerFormat
        /// <summary>
        /// <para>
        /// <para>The container format used to combine disk images with metadata (such as OVF). If absent,
        /// only the disk image is exported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.ContainerFormat")]
        public Amazon.EC2.ContainerFormat ExportToS3Task_ContainerFormat { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the conversion task or the resource being exported. The maximum
        /// length is 255 bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExportToS3Task_DiskImageFormat
        /// <summary>
        /// <para>
        /// <para>The format for the exported image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.DiskImageFormat")]
        public Amazon.EC2.DiskImageFormat ExportToS3Task_DiskImageFormat { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter ExportToS3Task_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket for the destination image. The destination bucket must exist and grant
        /// WRITE and READ_ACP permissions to the AWS account <code>vm-import-export@amazon.com</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExportToS3Task_S3Bucket { get; set; }
        #endregion
        
        #region Parameter ExportToS3Task_S3Prefix
        /// <summary>
        /// <para>
        /// <para>The image is written to a single object in the S3 bucket at the S3 key s3prefix +
        /// exportTaskId + '.' + diskImageFormat.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExportToS3Task_S3Prefix { get; set; }
        #endregion
        
        #region Parameter TargetEnvironment
        /// <summary>
        /// <para>
        /// <para>The target virtualization environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [AWSConstantClassSource("Amazon.EC2.ExportEnvironment")]
        public Amazon.EC2.ExportEnvironment TargetEnvironment { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2InstanceExportTask (CreateInstanceExportTask)"))
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
            context.ExportToS3Task_ContainerFormat = this.ExportToS3Task_ContainerFormat;
            context.ExportToS3Task_DiskImageFormat = this.ExportToS3Task_DiskImageFormat;
            context.ExportToS3Task_S3Bucket = this.ExportToS3Task_S3Bucket;
            context.ExportToS3Task_S3Prefix = this.ExportToS3Task_S3Prefix;
            context.InstanceId = this.InstanceId;
            context.TargetEnvironment = this.TargetEnvironment;
            
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
            var request = new Amazon.EC2.Model.CreateInstanceExportTaskRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate ExportToS3Task
            bool requestExportToS3TaskIsNull = true;
            request.ExportToS3Task = new Amazon.EC2.Model.ExportToS3TaskSpecification();
            Amazon.EC2.ContainerFormat requestExportToS3Task_exportToS3Task_ContainerFormat = null;
            if (cmdletContext.ExportToS3Task_ContainerFormat != null)
            {
                requestExportToS3Task_exportToS3Task_ContainerFormat = cmdletContext.ExportToS3Task_ContainerFormat;
            }
            if (requestExportToS3Task_exportToS3Task_ContainerFormat != null)
            {
                request.ExportToS3Task.ContainerFormat = requestExportToS3Task_exportToS3Task_ContainerFormat;
                requestExportToS3TaskIsNull = false;
            }
            Amazon.EC2.DiskImageFormat requestExportToS3Task_exportToS3Task_DiskImageFormat = null;
            if (cmdletContext.ExportToS3Task_DiskImageFormat != null)
            {
                requestExportToS3Task_exportToS3Task_DiskImageFormat = cmdletContext.ExportToS3Task_DiskImageFormat;
            }
            if (requestExportToS3Task_exportToS3Task_DiskImageFormat != null)
            {
                request.ExportToS3Task.DiskImageFormat = requestExportToS3Task_exportToS3Task_DiskImageFormat;
                requestExportToS3TaskIsNull = false;
            }
            System.String requestExportToS3Task_exportToS3Task_S3Bucket = null;
            if (cmdletContext.ExportToS3Task_S3Bucket != null)
            {
                requestExportToS3Task_exportToS3Task_S3Bucket = cmdletContext.ExportToS3Task_S3Bucket;
            }
            if (requestExportToS3Task_exportToS3Task_S3Bucket != null)
            {
                request.ExportToS3Task.S3Bucket = requestExportToS3Task_exportToS3Task_S3Bucket;
                requestExportToS3TaskIsNull = false;
            }
            System.String requestExportToS3Task_exportToS3Task_S3Prefix = null;
            if (cmdletContext.ExportToS3Task_S3Prefix != null)
            {
                requestExportToS3Task_exportToS3Task_S3Prefix = cmdletContext.ExportToS3Task_S3Prefix;
            }
            if (requestExportToS3Task_exportToS3Task_S3Prefix != null)
            {
                request.ExportToS3Task.S3Prefix = requestExportToS3Task_exportToS3Task_S3Prefix;
                requestExportToS3TaskIsNull = false;
            }
             // determine if request.ExportToS3Task should be set to null
            if (requestExportToS3TaskIsNull)
            {
                request.ExportToS3Task = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.TargetEnvironment != null)
            {
                request.TargetEnvironment = cmdletContext.TargetEnvironment;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ExportTask;
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
        
        private Amazon.EC2.Model.CreateInstanceExportTaskResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateInstanceExportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateInstanceExportTask");
            try
            {
                #if DESKTOP
                return client.CreateInstanceExportTask(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateInstanceExportTaskAsync(request);
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
            public Amazon.EC2.ContainerFormat ExportToS3Task_ContainerFormat { get; set; }
            public Amazon.EC2.DiskImageFormat ExportToS3Task_DiskImageFormat { get; set; }
            public System.String ExportToS3Task_S3Bucket { get; set; }
            public System.String ExportToS3Task_S3Prefix { get; set; }
            public System.String InstanceId { get; set; }
            public Amazon.EC2.ExportEnvironment TargetEnvironment { get; set; }
        }
        
    }
}

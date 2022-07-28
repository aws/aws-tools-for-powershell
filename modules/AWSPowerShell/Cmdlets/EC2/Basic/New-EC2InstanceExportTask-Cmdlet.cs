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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Exports a running or stopped instance to an Amazon S3 bucket.
    /// 
    ///  
    /// <para>
    /// For information about the supported operating systems, image formats, and known limitations
    /// for the types of instances you can export, see <a href="https://docs.aws.amazon.com/vm-import/latest/userguide/vmexport.html">Exporting
    /// an instance as a VM Using VM Import/Export</a> in the <i>VM Import/Export User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2InstanceExportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ExportTask")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateInstanceExportTask API operation.", Operation = new[] {"CreateInstanceExportTask"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateInstanceExportTaskResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ExportTask or Amazon.EC2.Model.CreateInstanceExportTaskResponse",
        "This cmdlet returns an Amazon.EC2.Model.ExportTask object.",
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.ContainerFormat")]
        public Amazon.EC2.ContainerFormat ExportToS3Task_ContainerFormat { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the conversion task or the resource being exported. The maximum
        /// length is 255 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExportToS3Task_DiskImageFormat
        /// <summary>
        /// <para>
        /// <para>The format for the exported image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DiskImageFormat")]
        public Amazon.EC2.DiskImageFormat ExportToS3Task_DiskImageFormat { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter ExportToS3Task_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket for the destination image. The destination bucket must exist
        /// and have an access control list (ACL) attached that specifies the Region-specific
        /// canonical account ID for the <code>Grantee</code>. For more information about the
        /// ACL to your S3 bucket, see <a href="https://docs.aws.amazon.com/vm-import/latest/userguide/vmexport.html#vmexport-prerequisites">Prerequisites</a>
        /// in the VM Import/Export User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExportToS3Task_S3Bucket { get; set; }
        #endregion
        
        #region Parameter ExportToS3Task_S3Prefix
        /// <summary>
        /// <para>
        /// <para>The image is written to a single object in the Amazon S3 bucket at the S3 key s3prefix
        /// + exportTaskId + '.' + diskImageFormat.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExportToS3Task_S3Prefix { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the export instance task during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TargetEnvironment
        /// <summary>
        /// <para>
        /// <para>The target virtualization environment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.ExportEnvironment")]
        public Amazon.EC2.ExportEnvironment TargetEnvironment { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExportTask'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateInstanceExportTaskResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateInstanceExportTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExportTask";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2InstanceExportTask (CreateInstanceExportTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateInstanceExportTaskResponse, NewEC2InstanceExportTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.ExportToS3Task_ContainerFormat = this.ExportToS3Task_ContainerFormat;
            context.ExportToS3Task_DiskImageFormat = this.ExportToS3Task_DiskImageFormat;
            context.ExportToS3Task_S3Bucket = this.ExportToS3Task_S3Bucket;
            context.ExportToS3Task_S3Prefix = this.ExportToS3Task_S3Prefix;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TargetEnvironment = this.TargetEnvironment;
            #if MODULAR
            if (this.TargetEnvironment == null && ParameterWasBound(nameof(this.TargetEnvironment)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetEnvironment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var requestExportToS3TaskIsNull = true;
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
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.TargetEnvironment != null)
            {
                request.TargetEnvironment = cmdletContext.TargetEnvironment;
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
        
        private Amazon.EC2.Model.CreateInstanceExportTaskResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateInstanceExportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateInstanceExportTask");
            try
            {
                #if DESKTOP
                return client.CreateInstanceExportTask(request);
                #elif CORECLR
                return client.CreateInstanceExportTaskAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public Amazon.EC2.ExportEnvironment TargetEnvironment { get; set; }
            public System.Func<Amazon.EC2.Model.CreateInstanceExportTaskResponse, NewEC2InstanceExportTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExportTask;
        }
        
    }
}

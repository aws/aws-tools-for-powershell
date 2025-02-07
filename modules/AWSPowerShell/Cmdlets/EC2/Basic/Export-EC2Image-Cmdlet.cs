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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Exports an Amazon Machine Image (AMI) to a VM file. For more information, see <a href="https://docs.aws.amazon.com/vm-import/latest/userguide/vmexport_image.html">Exporting
    /// a VM directly from an Amazon Machine Image (AMI)</a> in the <i>VM Import/Export User
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Export", "EC2Image", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ExportImageResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ExportImage API operation.", Operation = new[] {"ExportImage"}, SelectReturnType = typeof(Amazon.EC2.Model.ExportImageResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ExportImageResponse",
        "This cmdlet returns an Amazon.EC2.Model.ExportImageResponse object containing multiple properties."
    )]
    public partial class ExportEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the image being exported. The maximum length is 255 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DiskImageFormat
        /// <summary>
        /// <para>
        /// <para>The disk image format.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.DiskImageFormat")]
        public Amazon.EC2.DiskImageFormat DiskImageFormat { get; set; }
        #endregion
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the image.</para>
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
        public System.String ImageId { get; set; }
        #endregion
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>The name of the role that grants VM Import/Export permission to export images to your
        /// Amazon S3 bucket. If this parameter is not specified, the default role is named 'vmimport'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter S3ExportLocation_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The destination Amazon S3 bucket.</para>
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
        public System.String S3ExportLocation_S3Bucket { get; set; }
        #endregion
        
        #region Parameter S3ExportLocation_S3Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix (logical hierarchy) in the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3ExportLocation_S3Prefix { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the export image task during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Token to enable idempotency for export image requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ExportImageResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ExportImageResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-EC2Image (ExportImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ExportImageResponse, ExportEC2ImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DiskImageFormat = this.DiskImageFormat;
            #if MODULAR
            if (this.DiskImageFormat == null && ParameterWasBound(nameof(this.DiskImageFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter DiskImageFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageId = this.ImageId;
            #if MODULAR
            if (this.ImageId == null && ParameterWasBound(nameof(this.ImageId)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleName = this.RoleName;
            context.S3ExportLocation_S3Bucket = this.S3ExportLocation_S3Bucket;
            #if MODULAR
            if (this.S3ExportLocation_S3Bucket == null && ParameterWasBound(nameof(this.S3ExportLocation_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter S3ExportLocation_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3ExportLocation_S3Prefix = this.S3ExportLocation_S3Prefix;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            var request = new Amazon.EC2.Model.ExportImageRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DiskImageFormat != null)
            {
                request.DiskImageFormat = cmdletContext.DiskImageFormat;
            }
            if (cmdletContext.ImageId != null)
            {
                request.ImageId = cmdletContext.ImageId;
            }
            if (cmdletContext.RoleName != null)
            {
                request.RoleName = cmdletContext.RoleName;
            }
            
             // populate S3ExportLocation
            var requestS3ExportLocationIsNull = true;
            request.S3ExportLocation = new Amazon.EC2.Model.ExportTaskS3LocationRequest();
            System.String requestS3ExportLocation_s3ExportLocation_S3Bucket = null;
            if (cmdletContext.S3ExportLocation_S3Bucket != null)
            {
                requestS3ExportLocation_s3ExportLocation_S3Bucket = cmdletContext.S3ExportLocation_S3Bucket;
            }
            if (requestS3ExportLocation_s3ExportLocation_S3Bucket != null)
            {
                request.S3ExportLocation.S3Bucket = requestS3ExportLocation_s3ExportLocation_S3Bucket;
                requestS3ExportLocationIsNull = false;
            }
            System.String requestS3ExportLocation_s3ExportLocation_S3Prefix = null;
            if (cmdletContext.S3ExportLocation_S3Prefix != null)
            {
                requestS3ExportLocation_s3ExportLocation_S3Prefix = cmdletContext.S3ExportLocation_S3Prefix;
            }
            if (requestS3ExportLocation_s3ExportLocation_S3Prefix != null)
            {
                request.S3ExportLocation.S3Prefix = requestS3ExportLocation_s3ExportLocation_S3Prefix;
                requestS3ExportLocationIsNull = false;
            }
             // determine if request.S3ExportLocation should be set to null
            if (requestS3ExportLocationIsNull)
            {
                request.S3ExportLocation = null;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.ExportImageResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ExportImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ExportImage");
            try
            {
                #if DESKTOP
                return client.ExportImage(request);
                #elif CORECLR
                return client.ExportImageAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public Amazon.EC2.DiskImageFormat DiskImageFormat { get; set; }
            public System.String ImageId { get; set; }
            public System.String RoleName { get; set; }
            public System.String S3ExportLocation_S3Bucket { get; set; }
            public System.String S3ExportLocation_S3Prefix { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.ExportImageResponse, ExportEC2ImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

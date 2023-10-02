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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Creates an import job for an application.
    /// </summary>
    [Cmdlet("New", "PINImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.ImportJobResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint CreateImportJob API operation.", Operation = new[] {"CreateImportJob"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.CreateImportJobResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.ImportJobResponse or Amazon.Pinpoint.Model.CreateImportJobResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.ImportJobResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateImportJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINImportJobCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the application. This identifier is displayed as the <b>Project
        /// ID</b> on the Amazon Pinpoint console.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_DefineSegment
        /// <summary>
        /// <para>
        /// <para>Specifies whether to create a segment that contains the endpoints, when the endpoint
        /// definitions are imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ImportJobRequest_DefineSegment { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_ExternalId
        /// <summary>
        /// <para>
        /// <para>(Deprecated) Your AWS account ID, which you assigned to an external ID key in an IAM
        /// trust policy. Amazon Pinpoint previously used this value to assume an IAM role when
        /// importing endpoint definitions, but we removed this requirement. We don't recommend
        /// use of external IDs for IAM roles that are assumed by Amazon Pinpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImportJobRequest_ExternalId { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_Format
        /// <summary>
        /// <para>
        /// <para>The format of the files that contain the endpoint definitions to import. Valid values
        /// are: CSV, for comma-separated values format; and, JSON, for newline-delimited JSON
        /// format. If the Amazon S3 location stores multiple files that use different formats,
        /// Amazon Pinpoint imports data only from the files that use the specified format.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Pinpoint.Format")]
        public Amazon.Pinpoint.Format ImportJobRequest_Format { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_RegisterEndpoint
        /// <summary>
        /// <para>
        /// <para>Specifies whether to register the endpoints with Amazon Pinpoint, when the endpoint
        /// definitions are imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportJobRequest_RegisterEndpoints")]
        public System.Boolean? ImportJobRequest_RegisterEndpoint { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Identity and Access Management (IAM) role
        /// that authorizes Amazon Pinpoint to access the Amazon S3 location to import endpoint
        /// definitions from.</para>
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
        public System.String ImportJobRequest_RoleArn { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_S3Url
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon Simple Storage Service (Amazon S3) bucket that contains the
        /// endpoint definitions to import. This location can be a folder or a single file. If
        /// the location is a folder, Amazon Pinpoint imports endpoint definitions from the files
        /// in this location, including any subfolders that the folder contains.</para><para>The URL should be in the following format: s3://<replaceable>bucket-name</replaceable>/<replaceable>folder-name</replaceable>/<replaceable>file-name</replaceable>.
        /// The location can end with the key for an individual object or a prefix that qualifies
        /// multiple objects.</para>
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
        public System.String ImportJobRequest_S3Url { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_SegmentId
        /// <summary>
        /// <para>
        /// <para>The identifier for the segment to update or add the imported endpoint definitions
        /// to, if the import job is meant to update an existing segment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImportJobRequest_SegmentId { get; set; }
        #endregion
        
        #region Parameter ImportJobRequest_SegmentName
        /// <summary>
        /// <para>
        /// <para>A custom name for the segment that's created by the import job, if the value of the
        /// DefineSegment property is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImportJobRequest_SegmentName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImportJobResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.CreateImportJobResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.CreateImportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImportJobResponse";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINImportJob (CreateImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.CreateImportJobResponse, NewPINImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImportJobRequest_DefineSegment = this.ImportJobRequest_DefineSegment;
            context.ImportJobRequest_ExternalId = this.ImportJobRequest_ExternalId;
            context.ImportJobRequest_Format = this.ImportJobRequest_Format;
            #if MODULAR
            if (this.ImportJobRequest_Format == null && ParameterWasBound(nameof(this.ImportJobRequest_Format)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportJobRequest_Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImportJobRequest_RegisterEndpoint = this.ImportJobRequest_RegisterEndpoint;
            context.ImportJobRequest_RoleArn = this.ImportJobRequest_RoleArn;
            #if MODULAR
            if (this.ImportJobRequest_RoleArn == null && ParameterWasBound(nameof(this.ImportJobRequest_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportJobRequest_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImportJobRequest_S3Url = this.ImportJobRequest_S3Url;
            #if MODULAR
            if (this.ImportJobRequest_S3Url == null && ParameterWasBound(nameof(this.ImportJobRequest_S3Url)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportJobRequest_S3Url which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var requestImportJobRequestIsNull = true;
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
            if (cmdletContext.ImportJobRequest_RegisterEndpoint != null)
            {
                requestImportJobRequest_importJobRequest_RegisterEndpoint = cmdletContext.ImportJobRequest_RegisterEndpoint.Value;
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
        
        private Amazon.Pinpoint.Model.CreateImportJobResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.CreateImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "CreateImportJob");
            try
            {
                #if DESKTOP
                return client.CreateImportJob(request);
                #elif CORECLR
                return client.CreateImportJobAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ImportJobRequest_RegisterEndpoint { get; set; }
            public System.String ImportJobRequest_RoleArn { get; set; }
            public System.String ImportJobRequest_S3Url { get; set; }
            public System.String ImportJobRequest_SegmentId { get; set; }
            public System.String ImportJobRequest_SegmentName { get; set; }
            public System.Func<Amazon.Pinpoint.Model.CreateImportJobResponse, NewPINImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImportJobResponse;
        }
        
    }
}

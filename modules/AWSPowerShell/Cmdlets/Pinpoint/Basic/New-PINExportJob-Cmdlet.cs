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
    /// Creates an export job for an application.
    /// </summary>
    [Cmdlet("New", "PINExportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.ExportJobResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint CreateExportJob API operation.", Operation = new[] {"CreateExportJob"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.CreateExportJobResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.ExportJobResponse or Amazon.Pinpoint.Model.CreateExportJobResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.ExportJobResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateExportJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINExportJobCmdlet : AmazonPinpointClientCmdlet, IExecutor
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
        
        #region Parameter ExportJobRequest_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Identity and Access Management (IAM) role
        /// that authorizes Amazon Pinpoint to access the Amazon S3 location where you want to
        /// export endpoint definitions to.</para>
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
        public System.String ExportJobRequest_RoleArn { get; set; }
        #endregion
        
        #region Parameter ExportJobRequest_S3UrlPrefix
        /// <summary>
        /// <para>
        /// <para>The URL of the location in an Amazon Simple Storage Service (Amazon S3) bucket where
        /// you want to export endpoint definitions to. This location is typically a folder that
        /// contains multiple files. The URL should be in the following format: s3://<replaceable>bucket-name</replaceable>/<replaceable>folder-name</replaceable>/.</para>
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
        public System.String ExportJobRequest_S3UrlPrefix { get; set; }
        #endregion
        
        #region Parameter ExportJobRequest_SegmentId
        /// <summary>
        /// <para>
        /// <para>The identifier for the segment to export endpoint definitions from. If you don't specify
        /// this value, Amazon Pinpoint exports definitions for all the endpoints that are associated
        /// with the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExportJobRequest_SegmentId { get; set; }
        #endregion
        
        #region Parameter ExportJobRequest_SegmentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the segment to export endpoint definitions from, if specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ExportJobRequest_SegmentVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExportJobResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.CreateExportJobResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.CreateExportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExportJobResponse";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINExportJob (CreateExportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.CreateExportJobResponse, NewPINExportJobCmdlet>(Select) ??
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
            context.ExportJobRequest_RoleArn = this.ExportJobRequest_RoleArn;
            #if MODULAR
            if (this.ExportJobRequest_RoleArn == null && ParameterWasBound(nameof(this.ExportJobRequest_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportJobRequest_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExportJobRequest_S3UrlPrefix = this.ExportJobRequest_S3UrlPrefix;
            #if MODULAR
            if (this.ExportJobRequest_S3UrlPrefix == null && ParameterWasBound(nameof(this.ExportJobRequest_S3UrlPrefix)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportJobRequest_S3UrlPrefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExportJobRequest_SegmentId = this.ExportJobRequest_SegmentId;
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
            var requestExportJobRequestIsNull = true;
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
            public System.Func<Amazon.Pinpoint.Model.CreateExportJobResponse, NewPINExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExportJobResponse;
        }
        
    }
}

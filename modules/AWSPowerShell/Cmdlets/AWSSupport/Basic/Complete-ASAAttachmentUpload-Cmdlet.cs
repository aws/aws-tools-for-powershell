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
using System.Threading;
using Amazon.AWSSupport;
using Amazon.AWSSupport.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ASA
{
    /// <summary>
    /// Completes an attachment upload that was started with <a>GetAttachmentUploadLinks</a>.
    /// After you upload a part of the file to its presigned Amazon S3 URL, call <c>CompleteAttachmentUpload</c>
    /// with the <c>partIndex</c> and <c>eTag</c> of that part. You can include one part per
    /// call, or multiple parts in a single call. After <c>CompleteAttachmentUpload</c> has
    /// been called for every part of the file, the service processes the upload asynchronously.
    /// The <c>attachment-ready</c> status might not be reflected immediately. Use <a>DescribeAttachmentUploadStatus</a>
    /// to poll for the <c>uploadStatus</c> to become <c>attachment-ready</c> before passing
    /// the <c>uploadId</c> to <a>CreateCase</a> or <a>AddCommunicationToCase</a>.
    /// </summary>
    [Cmdlet("Complete", "ASAAttachmentUpload", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AWSSupport.UploadStatus")]
    [AWSCmdlet("Calls the AWS Support CompleteAttachmentUpload API operation.", Operation = new[] {"CompleteAttachmentUpload"}, SelectReturnType = typeof(Amazon.AWSSupport.Model.CompleteAttachmentUploadResponse))]
    [AWSCmdletOutput("Amazon.AWSSupport.UploadStatus or Amazon.AWSSupport.Model.CompleteAttachmentUploadResponse",
        "This cmdlet returns an Amazon.AWSSupport.UploadStatus object.",
        "The service call response (type Amazon.AWSSupport.Model.CompleteAttachmentUploadResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CompleteASAAttachmentUploadCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CompletedUpload
        /// <summary>
        /// <para>
        /// <para>The list of parts being reported as completed in this call. Each entry must contain
        /// the <c>partIndex</c> of an uploaded part and the <c>ETag</c> returned by Amazon S3
        /// when that part was uploaded.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("CompletedUploads")]
        public Amazon.AWSSupport.Model.CompletedUpload[] CompletedUpload { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Specifies whether to validate the request without actually completing the upload.
        /// When set to <c>true</c>, the request is validated but the upload isn't finalized,
        /// and the operation returns a <c>DryRunOperationException</c>. When omitted or set to
        /// <c>false</c>, the request runs normally.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter UploadId
        /// <summary>
        /// <para>
        /// <para>The identifier associated with the upload to complete.</para>
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
        public System.String UploadId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UploadStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSSupport.Model.CompleteAttachmentUploadResponse).
        /// Specifying the name of a property of type Amazon.AWSSupport.Model.CompleteAttachmentUploadResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UploadStatus";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UploadId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Complete-ASAAttachmentUpload (CompleteAttachmentUpload)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AWSSupport.Model.CompleteAttachmentUploadResponse, CompleteASAAttachmentUploadCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CompletedUpload != null)
            {
                context.CompletedUpload = new List<Amazon.AWSSupport.Model.CompletedUpload>(this.CompletedUpload);
            }
            #if MODULAR
            if (this.CompletedUpload == null && ParameterWasBound(nameof(this.CompletedUpload)))
            {
                WriteWarning("You are passing $null as a value for parameter CompletedUpload which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            context.UploadId = this.UploadId;
            #if MODULAR
            if (this.UploadId == null && ParameterWasBound(nameof(this.UploadId)))
            {
                WriteWarning("You are passing $null as a value for parameter UploadId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AWSSupport.Model.CompleteAttachmentUploadRequest();
            
            if (cmdletContext.CompletedUpload != null)
            {
                request.CompletedUploads = cmdletContext.CompletedUpload;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.UploadId != null)
            {
                request.UploadId = cmdletContext.UploadId;
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
        
        private Amazon.AWSSupport.Model.CompleteAttachmentUploadResponse CallAWSServiceOperation(IAmazonAWSSupport client, Amazon.AWSSupport.Model.CompleteAttachmentUploadRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support", "CompleteAttachmentUpload");
            try
            {
                return client.CompleteAttachmentUploadAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.AWSSupport.Model.CompletedUpload> CompletedUpload { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String UploadId { get; set; }
            public System.Func<Amazon.AWSSupport.Model.CompleteAttachmentUploadResponse, CompleteASAAttachmentUploadCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UploadStatus;
        }
        
    }
}

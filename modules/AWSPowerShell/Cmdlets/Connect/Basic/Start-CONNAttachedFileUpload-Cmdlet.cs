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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Provides a pre-signed Amazon S3 URL in response for uploading your content.
    /// 
    ///  <important><para>
    /// You may only use this API to upload attachments to an <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_connect-cases_CreateCase.html">Amazon
    /// Connect Case</a> or <a href="https://docs.aws.amazon.com/connect/latest/adminguide/setup-email-channel.html">Amazon
    /// Connect Email</a>. 
    /// </para></important>
    /// </summary>
    [Cmdlet("Start", "CONNAttachedFileUpload", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.StartAttachedFileUploadResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service StartAttachedFileUpload API operation.", Operation = new[] {"StartAttachedFileUpload"}, SelectReturnType = typeof(Amazon.Connect.Model.StartAttachedFileUploadResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.StartAttachedFileUploadResponse",
        "This cmdlet returns an Amazon.Connect.Model.StartAttachedFileUploadResponse object containing multiple properties."
    )]
    public partial class StartCONNAttachedFileUploadCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssociatedResourceArn
        /// <summary>
        /// <para>
        /// <para>The resource to which the attached file is (being) uploaded to. The supported resources
        /// are <a href="https://docs.aws.amazon.com/connect/latest/adminguide/cases.html">Cases</a>
        /// and <a href="https://docs.aws.amazon.com/connect/latest/adminguide/setup-email-channel.html">Email</a>.</para><note><para>This value must be a valid ARN.</para></note>
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
        public System.String AssociatedResourceArn { get; set; }
        #endregion
        
        #region Parameter CreatedBy_AWSIdentityArn
        /// <summary>
        /// <para>
        /// <para>STS or IAM ARN representing the identity of API Caller. SDK users cannot populate
        /// this and this value is calculated automatically if <c>ConnectUserArn</c> is not provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatedBy_AWSIdentityArn { get; set; }
        #endregion
        
        #region Parameter CreatedBy_ConnectUserArn
        /// <summary>
        /// <para>
        /// <para>An agent ARN representing a <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_amazonconnect.html#amazonconnect-resources-for-iam-policies">connect
        /// user</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatedBy_ConnectUserArn { get; set; }
        #endregion
        
        #region Parameter FileName
        /// <summary>
        /// <para>
        /// <para>A case-sensitive name of the attached file being uploaded.</para>
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
        public System.String FileName { get; set; }
        #endregion
        
        #region Parameter FileSizeInByte
        /// <summary>
        /// <para>
        /// <para>The size of the attached file in bytes.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FileSizeInBytes")]
        public System.Int64? FileSizeInByte { get; set; }
        #endregion
        
        #region Parameter FileUseCaseType
        /// <summary>
        /// <para>
        /// <para>The use case for the file.</para><important><para> Only <c>ATTACHMENTS</c> are supported.</para></important>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.FileUseCaseType")]
        public Amazon.Connect.FileUseCaseType FileUseCaseType { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Amazon Connect instance.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource. For example,
        /// <c>{ "Tags": {"key1":"value1", "key2":"value2"} }</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter UrlExpiryInSecond
        /// <summary>
        /// <para>
        /// <para>Optional override for the expiry of the pre-signed S3 URL in seconds. The default
        /// value is 300.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UrlExpiryInSeconds")]
        public System.Int32? UrlExpiryInSecond { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.StartAttachedFileUploadResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.StartAttachedFileUploadResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssociatedResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CONNAttachedFileUpload (StartAttachedFileUpload)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.StartAttachedFileUploadResponse, StartCONNAttachedFileUploadCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociatedResourceArn = this.AssociatedResourceArn;
            #if MODULAR
            if (this.AssociatedResourceArn == null && ParameterWasBound(nameof(this.AssociatedResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociatedResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.CreatedBy_AWSIdentityArn = this.CreatedBy_AWSIdentityArn;
            context.CreatedBy_ConnectUserArn = this.CreatedBy_ConnectUserArn;
            context.FileName = this.FileName;
            #if MODULAR
            if (this.FileName == null && ParameterWasBound(nameof(this.FileName)))
            {
                WriteWarning("You are passing $null as a value for parameter FileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileSizeInByte = this.FileSizeInByte;
            #if MODULAR
            if (this.FileSizeInByte == null && ParameterWasBound(nameof(this.FileSizeInByte)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSizeInByte which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileUseCaseType = this.FileUseCaseType;
            #if MODULAR
            if (this.FileUseCaseType == null && ParameterWasBound(nameof(this.FileUseCaseType)))
            {
                WriteWarning("You are passing $null as a value for parameter FileUseCaseType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.UrlExpiryInSecond = this.UrlExpiryInSecond;
            
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
            var request = new Amazon.Connect.Model.StartAttachedFileUploadRequest();
            
            if (cmdletContext.AssociatedResourceArn != null)
            {
                request.AssociatedResourceArn = cmdletContext.AssociatedResourceArn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate CreatedBy
            var requestCreatedByIsNull = true;
            request.CreatedBy = new Amazon.Connect.Model.CreatedByInfo();
            System.String requestCreatedBy_createdBy_AWSIdentityArn = null;
            if (cmdletContext.CreatedBy_AWSIdentityArn != null)
            {
                requestCreatedBy_createdBy_AWSIdentityArn = cmdletContext.CreatedBy_AWSIdentityArn;
            }
            if (requestCreatedBy_createdBy_AWSIdentityArn != null)
            {
                request.CreatedBy.AWSIdentityArn = requestCreatedBy_createdBy_AWSIdentityArn;
                requestCreatedByIsNull = false;
            }
            System.String requestCreatedBy_createdBy_ConnectUserArn = null;
            if (cmdletContext.CreatedBy_ConnectUserArn != null)
            {
                requestCreatedBy_createdBy_ConnectUserArn = cmdletContext.CreatedBy_ConnectUserArn;
            }
            if (requestCreatedBy_createdBy_ConnectUserArn != null)
            {
                request.CreatedBy.ConnectUserArn = requestCreatedBy_createdBy_ConnectUserArn;
                requestCreatedByIsNull = false;
            }
             // determine if request.CreatedBy should be set to null
            if (requestCreatedByIsNull)
            {
                request.CreatedBy = null;
            }
            if (cmdletContext.FileName != null)
            {
                request.FileName = cmdletContext.FileName;
            }
            if (cmdletContext.FileSizeInByte != null)
            {
                request.FileSizeInBytes = cmdletContext.FileSizeInByte.Value;
            }
            if (cmdletContext.FileUseCaseType != null)
            {
                request.FileUseCaseType = cmdletContext.FileUseCaseType;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UrlExpiryInSecond != null)
            {
                request.UrlExpiryInSeconds = cmdletContext.UrlExpiryInSecond.Value;
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
        
        private Amazon.Connect.Model.StartAttachedFileUploadResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.StartAttachedFileUploadRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "StartAttachedFileUpload");
            try
            {
                return client.StartAttachedFileUploadAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssociatedResourceArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String CreatedBy_AWSIdentityArn { get; set; }
            public System.String CreatedBy_ConnectUserArn { get; set; }
            public System.String FileName { get; set; }
            public System.Int64? FileSizeInByte { get; set; }
            public Amazon.Connect.FileUseCaseType FileUseCaseType { get; set; }
            public System.String InstanceId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? UrlExpiryInSecond { get; set; }
            public System.Func<Amazon.Connect.Model.StartAttachedFileUploadResponse, StartCONNAttachedFileUploadCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

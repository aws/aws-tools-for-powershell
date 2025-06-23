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
using Amazon.SocialMessaging;
using Amazon.SocialMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SOCIAL
{
    /// <summary>
    /// Upload a media file to the WhatsApp service. Only the specified <c>originationPhoneNumberId</c>
    /// has the permissions to send the media file when using <a href="https://docs.aws.amazon.com/social-messaging/latest/APIReference/API_SendWhatsAppMessage.html">SendWhatsAppMessage</a>.
    /// You must use either <c>sourceS3File</c> or <c>sourceS3PresignedUrl</c> for the source.
    /// If both or neither are specified then an <c>InvalidParameterException</c> is returned.
    /// </summary>
    [Cmdlet("Send", "SOCIALWhatsAppMessageMedia", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS End User Messaging Social PostWhatsAppMessageMedia API operation.", Operation = new[] {"PostWhatsAppMessageMedia"}, SelectReturnType = typeof(Amazon.SocialMessaging.Model.PostWhatsAppMessageMediaResponse))]
    [AWSCmdletOutput("System.String or Amazon.SocialMessaging.Model.PostWhatsAppMessageMediaResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SocialMessaging.Model.PostWhatsAppMessageMediaResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendSOCIALWhatsAppMessageMediaCmdlet : AmazonSocialMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SourceS3File_BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceS3File_BucketName { get; set; }
        #endregion
        
        #region Parameter SourceS3PresignedUrl_Header
        /// <summary>
        /// <para>
        /// <para>A map of headers and their values. You must specify the <c>Content-Type</c> header
        /// when using <c>PostWhatsAppMessageMedia</c>. For a list of common headers, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/RESTCommonRequestHeaders.html">Common
        /// Request Headers</a> in the <i>Amazon S3 API Reference</i></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceS3PresignedUrl_Headers")]
        public System.Collections.Hashtable SourceS3PresignedUrl_Header { get; set; }
        #endregion
        
        #region Parameter SourceS3File_Key
        /// <summary>
        /// <para>
        /// <para>The object key of the media file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceS3File_Key { get; set; }
        #endregion
        
        #region Parameter OriginationPhoneNumberId
        /// <summary>
        /// <para>
        /// <para>The ID of the phone number to associate with the WhatsApp media file. The phone number
        /// identifiers are formatted as <c>phone-number-id-01234567890123456789012345678901</c>.
        /// Use <a href="https://docs.aws.amazon.com/social-messaging/latest/APIReference/API_GetLinkedWhatsAppBusinessAccountPhoneNumber.html">GetLinkedWhatsAppBusinessAccount</a>
        /// to find a phone number's id.</para>
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
        public System.String OriginationPhoneNumberId { get; set; }
        #endregion
        
        #region Parameter SourceS3PresignedUrl_Url
        /// <summary>
        /// <para>
        /// <para>The presign url to the object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceS3PresignedUrl_Url { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MediaId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SocialMessaging.Model.PostWhatsAppMessageMediaResponse).
        /// Specifying the name of a property of type Amazon.SocialMessaging.Model.PostWhatsAppMessageMediaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MediaId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OriginationPhoneNumberId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SOCIALWhatsAppMessageMedia (PostWhatsAppMessageMedia)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SocialMessaging.Model.PostWhatsAppMessageMediaResponse, SendSOCIALWhatsAppMessageMediaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OriginationPhoneNumberId = this.OriginationPhoneNumberId;
            #if MODULAR
            if (this.OriginationPhoneNumberId == null && ParameterWasBound(nameof(this.OriginationPhoneNumberId)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginationPhoneNumberId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceS3File_BucketName = this.SourceS3File_BucketName;
            context.SourceS3File_Key = this.SourceS3File_Key;
            if (this.SourceS3PresignedUrl_Header != null)
            {
                context.SourceS3PresignedUrl_Header = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SourceS3PresignedUrl_Header.Keys)
                {
                    context.SourceS3PresignedUrl_Header.Add((String)hashKey, (System.String)(this.SourceS3PresignedUrl_Header[hashKey]));
                }
            }
            context.SourceS3PresignedUrl_Url = this.SourceS3PresignedUrl_Url;
            
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
            var request = new Amazon.SocialMessaging.Model.PostWhatsAppMessageMediaRequest();
            
            if (cmdletContext.OriginationPhoneNumberId != null)
            {
                request.OriginationPhoneNumberId = cmdletContext.OriginationPhoneNumberId;
            }
            
             // populate SourceS3File
            var requestSourceS3FileIsNull = true;
            request.SourceS3File = new Amazon.SocialMessaging.Model.S3File();
            System.String requestSourceS3File_sourceS3File_BucketName = null;
            if (cmdletContext.SourceS3File_BucketName != null)
            {
                requestSourceS3File_sourceS3File_BucketName = cmdletContext.SourceS3File_BucketName;
            }
            if (requestSourceS3File_sourceS3File_BucketName != null)
            {
                request.SourceS3File.BucketName = requestSourceS3File_sourceS3File_BucketName;
                requestSourceS3FileIsNull = false;
            }
            System.String requestSourceS3File_sourceS3File_Key = null;
            if (cmdletContext.SourceS3File_Key != null)
            {
                requestSourceS3File_sourceS3File_Key = cmdletContext.SourceS3File_Key;
            }
            if (requestSourceS3File_sourceS3File_Key != null)
            {
                request.SourceS3File.Key = requestSourceS3File_sourceS3File_Key;
                requestSourceS3FileIsNull = false;
            }
             // determine if request.SourceS3File should be set to null
            if (requestSourceS3FileIsNull)
            {
                request.SourceS3File = null;
            }
            
             // populate SourceS3PresignedUrl
            var requestSourceS3PresignedUrlIsNull = true;
            request.SourceS3PresignedUrl = new Amazon.SocialMessaging.Model.S3PresignedUrl();
            Dictionary<System.String, System.String> requestSourceS3PresignedUrl_sourceS3PresignedUrl_Header = null;
            if (cmdletContext.SourceS3PresignedUrl_Header != null)
            {
                requestSourceS3PresignedUrl_sourceS3PresignedUrl_Header = cmdletContext.SourceS3PresignedUrl_Header;
            }
            if (requestSourceS3PresignedUrl_sourceS3PresignedUrl_Header != null)
            {
                request.SourceS3PresignedUrl.Headers = requestSourceS3PresignedUrl_sourceS3PresignedUrl_Header;
                requestSourceS3PresignedUrlIsNull = false;
            }
            System.String requestSourceS3PresignedUrl_sourceS3PresignedUrl_Url = null;
            if (cmdletContext.SourceS3PresignedUrl_Url != null)
            {
                requestSourceS3PresignedUrl_sourceS3PresignedUrl_Url = cmdletContext.SourceS3PresignedUrl_Url;
            }
            if (requestSourceS3PresignedUrl_sourceS3PresignedUrl_Url != null)
            {
                request.SourceS3PresignedUrl.Url = requestSourceS3PresignedUrl_sourceS3PresignedUrl_Url;
                requestSourceS3PresignedUrlIsNull = false;
            }
             // determine if request.SourceS3PresignedUrl should be set to null
            if (requestSourceS3PresignedUrlIsNull)
            {
                request.SourceS3PresignedUrl = null;
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
        
        private Amazon.SocialMessaging.Model.PostWhatsAppMessageMediaResponse CallAWSServiceOperation(IAmazonSocialMessaging client, Amazon.SocialMessaging.Model.PostWhatsAppMessageMediaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging Social", "PostWhatsAppMessageMedia");
            try
            {
                return client.PostWhatsAppMessageMediaAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String OriginationPhoneNumberId { get; set; }
            public System.String SourceS3File_BucketName { get; set; }
            public System.String SourceS3File_Key { get; set; }
            public Dictionary<System.String, System.String> SourceS3PresignedUrl_Header { get; set; }
            public System.String SourceS3PresignedUrl_Url { get; set; }
            public System.Func<Amazon.SocialMessaging.Model.PostWhatsAppMessageMediaResponse, SendSOCIALWhatsAppMessageMediaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MediaId;
        }
        
    }
}

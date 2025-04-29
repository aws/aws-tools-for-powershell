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
    /// Get a media file from the WhatsApp service. On successful completion the media file
    /// is retrieved from Meta and stored in the specified Amazon S3 bucket. Use either <c>destinationS3File</c>
    /// or <c>destinationS3PresignedUrl</c> for the destination. If both are used then an
    /// <c>InvalidParameterException</c> is returned.
    /// </summary>
    [Cmdlet("Get", "SOCIALWhatsAppMessageMedia")]
    [OutputType("Amazon.SocialMessaging.Model.GetWhatsAppMessageMediaResponse")]
    [AWSCmdlet("Calls the AWS End User Messaging Social GetWhatsAppMessageMedia API operation.", Operation = new[] {"GetWhatsAppMessageMedia"}, SelectReturnType = typeof(Amazon.SocialMessaging.Model.GetWhatsAppMessageMediaResponse))]
    [AWSCmdletOutput("Amazon.SocialMessaging.Model.GetWhatsAppMessageMediaResponse",
        "This cmdlet returns an Amazon.SocialMessaging.Model.GetWhatsAppMessageMediaResponse object containing multiple properties."
    )]
    public partial class GetSOCIALWhatsAppMessageMediaCmdlet : AmazonSocialMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DestinationS3File_BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationS3File_BucketName { get; set; }
        #endregion
        
        #region Parameter DestinationS3PresignedUrl_Header
        /// <summary>
        /// <para>
        /// <para>A map of headers and their values. You must specify the <c>Content-Type</c> header
        /// when using <c>PostWhatsAppMessageMedia</c>. For a list of common headers, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/RESTCommonRequestHeaders.html">Common
        /// Request Headers</a> in the <i>Amazon S3 API Reference</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationS3PresignedUrl_Headers")]
        public System.Collections.Hashtable DestinationS3PresignedUrl_Header { get; set; }
        #endregion
        
        #region Parameter DestinationS3File_Key
        /// <summary>
        /// <para>
        /// <para>The object key of the media file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationS3File_Key { get; set; }
        #endregion
        
        #region Parameter MediaId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the media file.</para>
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
        public System.String MediaId { get; set; }
        #endregion
        
        #region Parameter MetadataOnly
        /// <summary>
        /// <para>
        /// <para>Set to <c>True</c> to get only the metadata for the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MetadataOnly { get; set; }
        #endregion
        
        #region Parameter OriginationPhoneNumberId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the originating phone number for the WhatsApp message media.
        /// The phone number identifiers are formatted as <c>phone-number-id-01234567890123456789012345678901</c>.
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
        
        #region Parameter DestinationS3PresignedUrl_Url
        /// <summary>
        /// <para>
        /// <para>The presign url to the object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationS3PresignedUrl_Url { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SocialMessaging.Model.GetWhatsAppMessageMediaResponse).
        /// Specifying the name of a property of type Amazon.SocialMessaging.Model.GetWhatsAppMessageMediaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SocialMessaging.Model.GetWhatsAppMessageMediaResponse, GetSOCIALWhatsAppMessageMediaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationS3File_BucketName = this.DestinationS3File_BucketName;
            context.DestinationS3File_Key = this.DestinationS3File_Key;
            if (this.DestinationS3PresignedUrl_Header != null)
            {
                context.DestinationS3PresignedUrl_Header = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DestinationS3PresignedUrl_Header.Keys)
                {
                    context.DestinationS3PresignedUrl_Header.Add((String)hashKey, (System.String)(this.DestinationS3PresignedUrl_Header[hashKey]));
                }
            }
            context.DestinationS3PresignedUrl_Url = this.DestinationS3PresignedUrl_Url;
            context.MediaId = this.MediaId;
            #if MODULAR
            if (this.MediaId == null && ParameterWasBound(nameof(this.MediaId)))
            {
                WriteWarning("You are passing $null as a value for parameter MediaId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetadataOnly = this.MetadataOnly;
            context.OriginationPhoneNumberId = this.OriginationPhoneNumberId;
            #if MODULAR
            if (this.OriginationPhoneNumberId == null && ParameterWasBound(nameof(this.OriginationPhoneNumberId)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginationPhoneNumberId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SocialMessaging.Model.GetWhatsAppMessageMediaRequest();
            
            
             // populate DestinationS3File
            var requestDestinationS3FileIsNull = true;
            request.DestinationS3File = new Amazon.SocialMessaging.Model.S3File();
            System.String requestDestinationS3File_destinationS3File_BucketName = null;
            if (cmdletContext.DestinationS3File_BucketName != null)
            {
                requestDestinationS3File_destinationS3File_BucketName = cmdletContext.DestinationS3File_BucketName;
            }
            if (requestDestinationS3File_destinationS3File_BucketName != null)
            {
                request.DestinationS3File.BucketName = requestDestinationS3File_destinationS3File_BucketName;
                requestDestinationS3FileIsNull = false;
            }
            System.String requestDestinationS3File_destinationS3File_Key = null;
            if (cmdletContext.DestinationS3File_Key != null)
            {
                requestDestinationS3File_destinationS3File_Key = cmdletContext.DestinationS3File_Key;
            }
            if (requestDestinationS3File_destinationS3File_Key != null)
            {
                request.DestinationS3File.Key = requestDestinationS3File_destinationS3File_Key;
                requestDestinationS3FileIsNull = false;
            }
             // determine if request.DestinationS3File should be set to null
            if (requestDestinationS3FileIsNull)
            {
                request.DestinationS3File = null;
            }
            
             // populate DestinationS3PresignedUrl
            var requestDestinationS3PresignedUrlIsNull = true;
            request.DestinationS3PresignedUrl = new Amazon.SocialMessaging.Model.S3PresignedUrl();
            Dictionary<System.String, System.String> requestDestinationS3PresignedUrl_destinationS3PresignedUrl_Header = null;
            if (cmdletContext.DestinationS3PresignedUrl_Header != null)
            {
                requestDestinationS3PresignedUrl_destinationS3PresignedUrl_Header = cmdletContext.DestinationS3PresignedUrl_Header;
            }
            if (requestDestinationS3PresignedUrl_destinationS3PresignedUrl_Header != null)
            {
                request.DestinationS3PresignedUrl.Headers = requestDestinationS3PresignedUrl_destinationS3PresignedUrl_Header;
                requestDestinationS3PresignedUrlIsNull = false;
            }
            System.String requestDestinationS3PresignedUrl_destinationS3PresignedUrl_Url = null;
            if (cmdletContext.DestinationS3PresignedUrl_Url != null)
            {
                requestDestinationS3PresignedUrl_destinationS3PresignedUrl_Url = cmdletContext.DestinationS3PresignedUrl_Url;
            }
            if (requestDestinationS3PresignedUrl_destinationS3PresignedUrl_Url != null)
            {
                request.DestinationS3PresignedUrl.Url = requestDestinationS3PresignedUrl_destinationS3PresignedUrl_Url;
                requestDestinationS3PresignedUrlIsNull = false;
            }
             // determine if request.DestinationS3PresignedUrl should be set to null
            if (requestDestinationS3PresignedUrlIsNull)
            {
                request.DestinationS3PresignedUrl = null;
            }
            if (cmdletContext.MediaId != null)
            {
                request.MediaId = cmdletContext.MediaId;
            }
            if (cmdletContext.MetadataOnly != null)
            {
                request.MetadataOnly = cmdletContext.MetadataOnly.Value;
            }
            if (cmdletContext.OriginationPhoneNumberId != null)
            {
                request.OriginationPhoneNumberId = cmdletContext.OriginationPhoneNumberId;
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
        
        private Amazon.SocialMessaging.Model.GetWhatsAppMessageMediaResponse CallAWSServiceOperation(IAmazonSocialMessaging client, Amazon.SocialMessaging.Model.GetWhatsAppMessageMediaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging Social", "GetWhatsAppMessageMedia");
            try
            {
                return client.GetWhatsAppMessageMediaAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DestinationS3File_BucketName { get; set; }
            public System.String DestinationS3File_Key { get; set; }
            public Dictionary<System.String, System.String> DestinationS3PresignedUrl_Header { get; set; }
            public System.String DestinationS3PresignedUrl_Url { get; set; }
            public System.String MediaId { get; set; }
            public System.Boolean? MetadataOnly { get; set; }
            public System.String OriginationPhoneNumberId { get; set; }
            public System.Func<Amazon.SocialMessaging.Model.GetWhatsAppMessageMediaResponse, GetSOCIALWhatsAppMessageMediaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

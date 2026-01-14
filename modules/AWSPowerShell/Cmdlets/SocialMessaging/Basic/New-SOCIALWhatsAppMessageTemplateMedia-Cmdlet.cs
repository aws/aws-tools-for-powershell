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
    /// Uploads media for use in a WhatsApp message template.
    /// </summary>
    [Cmdlet("New", "SOCIALWhatsAppMessageTemplateMedia", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS End User Messaging Social CreateWhatsAppMessageTemplateMedia API operation.", Operation = new[] {"CreateWhatsAppMessageTemplateMedia"}, SelectReturnType = typeof(Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateMediaResponse))]
    [AWSCmdletOutput("System.String or Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateMediaResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateMediaResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSOCIALWhatsAppMessageTemplateMediaCmdlet : AmazonSocialMessagingClientCmdlet, IExecutor
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
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the WhatsApp Business Account associated with this media upload.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter SourceS3File_Key
        /// <summary>
        /// <para>
        /// <para>The S3 key prefix that defines the storage location of your media files. The prefix
        /// works like a folder path in S3, and is combined with the WhatsApp mediaId to create
        /// the final file path.</para><para>For example, if a media file's WhatsApp mediaId is <c>123.ogg</c>, and the key is
        /// <c>audio/example.ogg</c>, the final file path is <c>audio/example.ogg123.ogg</c>.</para><para>For the same mediaId, a key of <c>audio/</c> results in the file path <c>audio/123.ogg</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceS3File_Key { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MetaHeaderHandle'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateMediaResponse).
        /// Specifying the name of a property of type Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateMediaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MetaHeaderHandle";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SOCIALWhatsAppMessageTemplateMedia (CreateWhatsAppMessageTemplateMedia)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateMediaResponse, NewSOCIALWhatsAppMessageTemplateMediaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceS3File_BucketName = this.SourceS3File_BucketName;
            context.SourceS3File_Key = this.SourceS3File_Key;
            
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
            var request = new Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateMediaRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateMediaResponse CallAWSServiceOperation(IAmazonSocialMessaging client, Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateMediaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging Social", "CreateWhatsAppMessageTemplateMedia");
            try
            {
                return client.CreateWhatsAppMessageTemplateMediaAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String SourceS3File_BucketName { get; set; }
            public System.String SourceS3File_Key { get; set; }
            public System.Func<Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateMediaResponse, NewSOCIALWhatsAppMessageTemplateMediaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MetaHeaderHandle;
        }
        
    }
}

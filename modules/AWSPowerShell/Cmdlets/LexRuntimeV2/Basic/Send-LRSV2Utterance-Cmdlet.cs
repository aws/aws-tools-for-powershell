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
using Amazon.LexRuntimeV2;
using Amazon.LexRuntimeV2.Model;

namespace Amazon.PowerShell.Cmdlets.LRSV2
{
    /// <summary>
    /// Sends user input to Amazon Lex V2. You can send text or speech. Clients use this API
    /// to send text and audio requests to Amazon Lex V2 at runtime. Amazon Lex V2 interprets
    /// the user input using the machine learning model built for the bot.
    /// 
    ///  
    /// <para>
    /// The following request fields must be compressed with gzip and then base64 encoded
    /// before you send them to Amazon Lex V2. 
    /// </para><ul><li><para>
    /// requestAttributes
    /// </para></li><li><para>
    /// sessionState
    /// </para></li></ul><para>
    /// The following response fields are compressed using gzip and then base64 encoded by
    /// Amazon Lex V2. Before you can use these fields, you must decode and decompress them.
    /// 
    /// </para><ul><li><para>
    /// inputTranscript
    /// </para></li><li><para>
    /// interpretations
    /// </para></li><li><para>
    /// messages
    /// </para></li><li><para>
    /// requestAttributes
    /// </para></li><li><para>
    /// sessionState
    /// </para></li></ul><para>
    /// The example contains a Java application that compresses and encodes a Java object
    /// to send to Amazon Lex V2, and a second that decodes and decompresses a response from
    /// Amazon Lex V2.
    /// </para><para>
    /// If the optional post-fulfillment response is specified, the messages are returned
    /// as follows. For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/API_PostFulfillmentStatusSpecification.html">PostFulfillmentStatusSpecification</a>.
    /// </para><ul><li><para><b>Success message</b> - Returned if the Lambda function completes successfully and
    /// the intent state is fulfilled or ready fulfillment if the message is present.
    /// </para></li><li><para><b>Failed message</b> - The failed message is returned if the Lambda function throws
    /// an exception or if the Lambda function returns a failed intent state without a message.
    /// </para></li><li><para><b>Timeout message</b> - If you don't configure a timeout message and a timeout,
    /// and the Lambda function doesn't return within 30 seconds, the timeout message is returned.
    /// If you configure a timeout, the timeout message is returned when the period times
    /// out. 
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/streaming-progress.html#progress-complete.html">Completion
    /// message</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Send", "LRSV2Utterance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexRuntimeV2.Model.RecognizeUtteranceResponse")]
    [AWSCmdlet("Calls the Amazon Lex Runtime V2 RecognizeUtterance API operation.", Operation = new[] {"RecognizeUtterance"}, SelectReturnType = typeof(Amazon.LexRuntimeV2.Model.RecognizeUtteranceResponse))]
    [AWSCmdletOutput("Amazon.LexRuntimeV2.Model.RecognizeUtteranceResponse",
        "This cmdlet returns an Amazon.LexRuntimeV2.Model.RecognizeUtteranceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendLRSV2UtteranceCmdlet : AmazonLexRuntimeV2ClientCmdlet, IExecutor
    {
        
        #region Parameter BotAliasId
        /// <summary>
        /// <para>
        /// <para>The alias identifier in use for the bot that should receive the request.</para>
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
        public System.String BotAliasId { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot that should receive the request.</para>
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
        public System.String BotId { get; set; }
        #endregion
        
        #region Parameter InputStream
        /// <summary>
        /// <para>
        /// <para>User input in PCM or Opus audio format or text format as described in the <code>requestContentType</code>
        /// parameter.</para>
        /// </para>
        /// <para>The cmdlet accepts a parameter of type string, string[], System.IO.FileInfo or System.IO.Stream.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public object InputStream { get; set; }
        #endregion
        
        #region Parameter LocaleId
        /// <summary>
        /// <para>
        /// <para>The locale where the session is in use.</para>
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
        public System.String LocaleId { get; set; }
        #endregion
        
        #region Parameter RequestAttribute
        /// <summary>
        /// <para>
        /// <para>Request-specific information passed between the client application and Amazon Lex
        /// V2 </para><para>The namespace <code>x-amz-lex:</code> is reserved for special attributes. Don't create
        /// any request attributes for prefix <code>x-amz-lex:</code>.</para><para>The <code>requestAttributes</code> field must be compressed using gzip and then base64
        /// encoded before sending to Amazon Lex V2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestAttributes")]
        public System.String RequestAttribute { get; set; }
        #endregion
        
        #region Parameter RequestContentType
        /// <summary>
        /// <para>
        /// <para>Indicates the format for audio input or that the content is text. The header must
        /// start with one of the following prefixes:</para><ul><li><para>PCM format, audio data must be in little-endian byte order.</para><ul><li><para>audio/l16; rate=16000; channels=1</para></li><li><para>audio/x-l16; sample-rate=16000; channel-count=1</para></li><li><para>audio/lpcm; sample-rate=8000; sample-size-bits=16; channel-count=1; is-big-endian=false</para></li></ul></li><li><para>Opus format</para><ul><li><para>audio/x-cbr-opus-with-preamble;preamble-size=0;bit-rate=256000;frame-size-milliseconds=4</para></li></ul></li><li><para>Text format</para><ul><li><para>text/plain; charset=utf-8</para></li></ul></li></ul>
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
        public System.String RequestContentType { get; set; }
        #endregion
        
        #region Parameter ResponseContentType
        /// <summary>
        /// <para>
        /// <para>The message that Amazon Lex V2 returns in the response can be either text or speech
        /// based on the <code>responseContentType</code> value.</para><ul><li><para>If the value is <code>text/plain;charset=utf-8</code>, Amazon Lex V2 returns text
        /// in the response.</para></li><li><para>If the value begins with <code>audio/</code>, Amazon Lex V2 returns speech in the
        /// response. Amazon Lex V2 uses Amazon Polly to generate the speech using the configuration
        /// that you specified in the <code>responseContentType</code> parameter. For example,
        /// if you specify <code>audio/mpeg</code> as the value, Amazon Lex V2 returns speech
        /// in the MPEG format.</para></li><li><para>If the value is <code>audio/pcm</code>, the speech returned is <code>audio/pcm</code>
        /// at 16 KHz in 16-bit, little-endian format.</para></li><li><para>The following are the accepted values:</para><ul><li><para>audio/mpeg</para></li><li><para>audio/ogg</para></li><li><para>audio/pcm (16 KHz)</para></li><li><para>audio/* (defaults to mpeg)</para></li><li><para>text/plain; charset=utf-8</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResponseContentType { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the session in use.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter SessionStateValue
        /// <summary>
        /// <para>
        /// <para>Sets the state of the session with the user. You can use this to set the current intent,
        /// attributes, context, and dialog action. Use the dialog action to determine the next
        /// step that Amazon Lex V2 should use in the conversation with the user.</para><para>The <code>sessionState</code> field must be compressed using gzip and then base64
        /// encoded before sending to Amazon Lex V2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionStateValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexRuntimeV2.Model.RecognizeUtteranceResponse).
        /// Specifying the name of a property of type Amazon.LexRuntimeV2.Model.RecognizeUtteranceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-LRSV2Utterance (RecognizeUtterance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexRuntimeV2.Model.RecognizeUtteranceResponse, SendLRSV2UtteranceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BotAliasId = this.BotAliasId;
            #if MODULAR
            if (this.BotAliasId == null && ParameterWasBound(nameof(this.BotAliasId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotAliasId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputStream = this.InputStream;
            context.LocaleId = this.LocaleId;
            #if MODULAR
            if (this.LocaleId == null && ParameterWasBound(nameof(this.LocaleId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocaleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RequestAttribute = this.RequestAttribute;
            context.RequestContentType = this.RequestContentType;
            #if MODULAR
            if (this.RequestContentType == null && ParameterWasBound(nameof(this.RequestContentType)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestContentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResponseContentType = this.ResponseContentType;
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionStateValue = this.SessionStateValue;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.Stream _InputStreamStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.LexRuntimeV2.Model.RecognizeUtteranceRequest();
                
                if (cmdletContext.BotAliasId != null)
                {
                    request.BotAliasId = cmdletContext.BotAliasId;
                }
                if (cmdletContext.BotId != null)
                {
                    request.BotId = cmdletContext.BotId;
                }
                if (cmdletContext.InputStream != null)
                {
                    _InputStreamStream = Amazon.PowerShell.Common.StreamParameterConverter.TransformToStream(cmdletContext.InputStream);
                    request.InputStream = _InputStreamStream;
                }
                if (cmdletContext.LocaleId != null)
                {
                    request.LocaleId = cmdletContext.LocaleId;
                }
                if (cmdletContext.RequestAttribute != null)
                {
                    request.RequestAttributes = cmdletContext.RequestAttribute;
                }
                if (cmdletContext.RequestContentType != null)
                {
                    request.RequestContentType = cmdletContext.RequestContentType;
                }
                if (cmdletContext.ResponseContentType != null)
                {
                    request.ResponseContentType = cmdletContext.ResponseContentType;
                }
                if (cmdletContext.SessionId != null)
                {
                    request.SessionId = cmdletContext.SessionId;
                }
                if (cmdletContext.SessionStateValue != null)
                {
                    request.SessionStateValue = cmdletContext.SessionStateValue;
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
            finally
            {
                if( _InputStreamStream != null)
                {
                    _InputStreamStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.LexRuntimeV2.Model.RecognizeUtteranceResponse CallAWSServiceOperation(IAmazonLexRuntimeV2 client, Amazon.LexRuntimeV2.Model.RecognizeUtteranceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Runtime V2", "RecognizeUtterance");
            try
            {
                #if DESKTOP
                return client.RecognizeUtterance(request);
                #elif CORECLR
                return client.RecognizeUtteranceAsync(request).GetAwaiter().GetResult();
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
            public System.String BotAliasId { get; set; }
            public System.String BotId { get; set; }
            public object InputStream { get; set; }
            public System.String LocaleId { get; set; }
            public System.String RequestAttribute { get; set; }
            public System.String RequestContentType { get; set; }
            public System.String ResponseContentType { get; set; }
            public System.String SessionId { get; set; }
            public System.String SessionStateValue { get; set; }
            public System.Func<Amazon.LexRuntimeV2.Model.RecognizeUtteranceResponse, SendLRSV2UtteranceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

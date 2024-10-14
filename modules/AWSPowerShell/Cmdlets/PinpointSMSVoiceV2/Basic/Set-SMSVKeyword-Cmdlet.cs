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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Creates or updates a keyword configuration on an origination phone number or pool.
    /// 
    ///  
    /// <para>
    ///  A keyword is a word that you can search for on a particular phone number or pool.
    /// It is also a specific word or phrase that an end user can send to your number to elicit
    /// a response, such as an informational message or a special offer. When your number
    /// receives a message that begins with a keyword, AWS End User Messaging SMS and Voice
    /// responds with a customizable message.
    /// </para><para>
    /// If you specify a keyword that isn't valid, an error is returned.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "SMSVKeyword", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.PutKeywordResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 PutKeyword API operation.", Operation = new[] {"PutKeyword"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.PutKeywordResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.PutKeywordResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.PutKeywordResponse object containing multiple properties."
    )]
    public partial class SetSMSVKeywordCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Keyword
        /// <summary>
        /// <para>
        /// <para>The new keyword to add.</para>
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
        public System.String Keyword { get; set; }
        #endregion
        
        #region Parameter KeywordAction
        /// <summary>
        /// <para>
        /// <para>The action to perform for the new keyword when it is received.</para><ul><li><para>AUTOMATIC_RESPONSE: A message is sent to the recipient.</para></li><li><para>OPT_OUT: Keeps the recipient from receiving future messages.</para></li><li><para>OPT_IN: The recipient wants to receive future messages.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.KeywordAction")]
        public Amazon.PinpointSMSVoiceV2.KeywordAction KeywordAction { get; set; }
        #endregion
        
        #region Parameter KeywordMessage
        /// <summary>
        /// <para>
        /// <para>The message associated with the keyword.</para>
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
        public System.String KeywordMessage { get; set; }
        #endregion
        
        #region Parameter OriginationIdentity
        /// <summary>
        /// <para>
        /// <para>The origination identity to use such as a PhoneNumberId, PhoneNumberArn, SenderId
        /// or SenderIdArn. You can use <a>DescribePhoneNumbers</a> get the values for PhoneNumberId
        /// and PhoneNumberArn while <a>DescribeSenderIds</a> can be used to get the values for
        /// SenderId and SenderIdArn.</para><important><para>If you are using a shared AWS End User Messaging SMS and Voice resource then you must
        /// use the full Amazon Resource Name(ARN).</para></important>
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
        public System.String OriginationIdentity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.PutKeywordResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.PutKeywordResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OriginationIdentity parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OriginationIdentity' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OriginationIdentity' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OriginationIdentity), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SMSVKeyword (PutKeyword)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.PutKeywordResponse, SetSMSVKeywordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OriginationIdentity;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Keyword = this.Keyword;
            #if MODULAR
            if (this.Keyword == null && ParameterWasBound(nameof(this.Keyword)))
            {
                WriteWarning("You are passing $null as a value for parameter Keyword which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeywordAction = this.KeywordAction;
            context.KeywordMessage = this.KeywordMessage;
            #if MODULAR
            if (this.KeywordMessage == null && ParameterWasBound(nameof(this.KeywordMessage)))
            {
                WriteWarning("You are passing $null as a value for parameter KeywordMessage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OriginationIdentity = this.OriginationIdentity;
            #if MODULAR
            if (this.OriginationIdentity == null && ParameterWasBound(nameof(this.OriginationIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginationIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.PutKeywordRequest();
            
            if (cmdletContext.Keyword != null)
            {
                request.Keyword = cmdletContext.Keyword;
            }
            if (cmdletContext.KeywordAction != null)
            {
                request.KeywordAction = cmdletContext.KeywordAction;
            }
            if (cmdletContext.KeywordMessage != null)
            {
                request.KeywordMessage = cmdletContext.KeywordMessage;
            }
            if (cmdletContext.OriginationIdentity != null)
            {
                request.OriginationIdentity = cmdletContext.OriginationIdentity;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.PutKeywordResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.PutKeywordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "PutKeyword");
            try
            {
                #if DESKTOP
                return client.PutKeyword(request);
                #elif CORECLR
                return client.PutKeywordAsync(request).GetAwaiter().GetResult();
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
            public System.String Keyword { get; set; }
            public Amazon.PinpointSMSVoiceV2.KeywordAction KeywordAction { get; set; }
            public System.String KeywordMessage { get; set; }
            public System.String OriginationIdentity { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.PutKeywordResponse, SetSMSVKeywordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Creates a new pool and associates the specified origination identity to the pool.
    /// A pool can include one or more phone numbers and SenderIds that are associated with
    /// your Amazon Web Services account.
    /// 
    ///  
    /// <para>
    /// The new pool inherits its configuration from the specified origination identity. This
    /// includes keywords, message type, opt-out list, two-way configuration, and self-managed
    /// opt-out configuration. Deletion protection isn't inherited from the origination identity
    /// and defaults to false.
    /// </para><para>
    /// If the origination identity is a phone number and is already associated with another
    /// pool, an error is returned. A sender ID can be associated with multiple pools.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMSVPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.CreatePoolResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 CreatePool API operation.", Operation = new[] {"CreatePool"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.CreatePoolResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.CreatePoolResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.CreatePoolResponse object containing multiple properties."
    )]
    public partial class NewSMSVPoolCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeletionProtectionEnabled
        /// <summary>
        /// <para>
        /// <para>By default this is set to false. When set to true the pool can't be deleted. You can
        /// change this value using the <a>UpdatePool</a> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtectionEnabled { get; set; }
        #endregion
        
        #region Parameter IsoCountryCode
        /// <summary>
        /// <para>
        /// <para>The new two-character code, in ISO 3166-1 alpha-2 format, for the country or region
        /// of the new pool.</para>
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
        public System.String IsoCountryCode { get; set; }
        #endregion
        
        #region Parameter MessageType
        /// <summary>
        /// <para>
        /// <para>The type of message. Valid values are TRANSACTIONAL for messages that are critical
        /// or time-sensitive and PROMOTIONAL for messages that aren't critical or time-sensitive.
        /// After the pool is created the MessageType can't be changed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.MessageType")]
        public Amazon.PinpointSMSVoiceV2.MessageType MessageType { get; set; }
        #endregion
        
        #region Parameter OriginationIdentity
        /// <summary>
        /// <para>
        /// <para>The origination identity to use such as a PhoneNumberId, PhoneNumberArn, SenderId
        /// or SenderIdArn. You can use <a>DescribePhoneNumbers</a> to find the values for PhoneNumberId
        /// and PhoneNumberArn while <a>DescribeSenderIds</a> can be used to get the values for
        /// SenderId and SenderIdArn.</para><para>After the pool is created you can add more origination identities to the pool by using
        /// <a href="https://docs.aws.amazon.com/pinpoint/latest/apireference_smsvoicev2/API_AssociateOriginationIdentity.html">AssociateOriginationIdentity</a>.</para><important><para>If you are using a shared AWS End User Messaging SMS and Voice resource then you must
        /// use the full Amazon Resource Name(ARN).</para></important>
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
        public System.String OriginationIdentity { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of tags (key and value pairs) associated with the pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PinpointSMSVoiceV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. If you don't specify a client token, a randomly generated token is used for
        /// the request to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.CreatePoolResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.CreatePoolResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMSVPool (CreatePool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.CreatePoolResponse, NewSMSVPoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DeletionProtectionEnabled = this.DeletionProtectionEnabled;
            context.IsoCountryCode = this.IsoCountryCode;
            #if MODULAR
            if (this.IsoCountryCode == null && ParameterWasBound(nameof(this.IsoCountryCode)))
            {
                WriteWarning("You are passing $null as a value for parameter IsoCountryCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessageType = this.MessageType;
            #if MODULAR
            if (this.MessageType == null && ParameterWasBound(nameof(this.MessageType)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OriginationIdentity = this.OriginationIdentity;
            #if MODULAR
            if (this.OriginationIdentity == null && ParameterWasBound(nameof(this.OriginationIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginationIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.PinpointSMSVoiceV2.Model.Tag>(this.Tag);
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.CreatePoolRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeletionProtectionEnabled != null)
            {
                request.DeletionProtectionEnabled = cmdletContext.DeletionProtectionEnabled.Value;
            }
            if (cmdletContext.IsoCountryCode != null)
            {
                request.IsoCountryCode = cmdletContext.IsoCountryCode;
            }
            if (cmdletContext.MessageType != null)
            {
                request.MessageType = cmdletContext.MessageType;
            }
            if (cmdletContext.OriginationIdentity != null)
            {
                request.OriginationIdentity = cmdletContext.OriginationIdentity;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.CreatePoolResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.CreatePoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "CreatePool");
            try
            {
                #if DESKTOP
                return client.CreatePool(request);
                #elif CORECLR
                return client.CreatePoolAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeletionProtectionEnabled { get; set; }
            public System.String IsoCountryCode { get; set; }
            public Amazon.PinpointSMSVoiceV2.MessageType MessageType { get; set; }
            public System.String OriginationIdentity { get; set; }
            public List<Amazon.PinpointSMSVoiceV2.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.CreatePoolResponse, NewSMSVPoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

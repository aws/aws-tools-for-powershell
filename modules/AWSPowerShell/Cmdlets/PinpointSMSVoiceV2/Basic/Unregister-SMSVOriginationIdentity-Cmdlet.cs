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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Removes the specified origination identity from an existing pool.
    /// 
    ///  
    /// <para>
    /// If the origination identity isn't associated with the specified pool, an error is
    /// returned.
    /// </para>
    /// </summary>
    [Cmdlet("Unregister", "SMSVOriginationIdentity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.DisassociateOriginationIdentityResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 DisassociateOriginationIdentity API operation.", Operation = new[] {"DisassociateOriginationIdentity"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.DisassociateOriginationIdentityResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.DisassociateOriginationIdentityResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.DisassociateOriginationIdentityResponse object containing multiple properties."
    )]
    public partial class UnregisterSMSVOriginationIdentityCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IsoCountryCode
        /// <summary>
        /// <para>
        /// <para>The two-character code, in ISO 3166-1 alpha-2 format, for the country or region. </para>
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
        
        #region Parameter OriginationIdentity
        /// <summary>
        /// <para>
        /// <para>The origination identity to use such as a PhoneNumberId, PhoneNumberArn, SenderId
        /// or SenderIdArn. You can use <a>DescribePhoneNumbers</a> find the values for PhoneNumberId
        /// and PhoneNumberArn, or use <a>DescribeSenderIds</a> to get the values for SenderId
        /// and SenderIdArn.</para><important><para>If you are using a shared AWS End User Messaging SMS and Voice resource then you must
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
        
        #region Parameter PoolId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the pool to disassociate with the origination identity.
        /// This value can be either the PoolId or PoolArn.</para><important><para>If you are using a shared AWS End User Messaging SMS and Voice resource then you must
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
        public System.String PoolId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// If you don't specify a client token, a randomly generated token is used for the request
        /// to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.DisassociateOriginationIdentityResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.DisassociateOriginationIdentityResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-SMSVOriginationIdentity (DisassociateOriginationIdentity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.DisassociateOriginationIdentityResponse, UnregisterSMSVOriginationIdentityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.IsoCountryCode = this.IsoCountryCode;
            #if MODULAR
            if (this.IsoCountryCode == null && ParameterWasBound(nameof(this.IsoCountryCode)))
            {
                WriteWarning("You are passing $null as a value for parameter IsoCountryCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OriginationIdentity = this.OriginationIdentity;
            #if MODULAR
            if (this.OriginationIdentity == null && ParameterWasBound(nameof(this.OriginationIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginationIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PoolId = this.PoolId;
            #if MODULAR
            if (this.PoolId == null && ParameterWasBound(nameof(this.PoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter PoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.DisassociateOriginationIdentityRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.IsoCountryCode != null)
            {
                request.IsoCountryCode = cmdletContext.IsoCountryCode;
            }
            if (cmdletContext.OriginationIdentity != null)
            {
                request.OriginationIdentity = cmdletContext.OriginationIdentity;
            }
            if (cmdletContext.PoolId != null)
            {
                request.PoolId = cmdletContext.PoolId;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.DisassociateOriginationIdentityResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.DisassociateOriginationIdentityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "DisassociateOriginationIdentity");
            try
            {
                return client.DisassociateOriginationIdentityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IsoCountryCode { get; set; }
            public System.String OriginationIdentity { get; set; }
            public System.String PoolId { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.DisassociateOriginationIdentityResponse, UnregisterSMSVOriginationIdentityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

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
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

namespace Amazon.PowerShell.Cmdlets.STS
{
    /// <summary>
    /// Decodes additional information about the authorization status of a request from an
    /// encoded message returned in response to an AWS request.
    /// 
    ///  
    /// <para>
    /// For example, if a user is not authorized to perform an operation that he or she has
    /// requested, the request returns a <code>Client.UnauthorizedOperation</code> response
    /// (an HTTP 403 response). Some AWS operations additionally return an encoded message
    /// that can provide details about this authorization failure. 
    /// </para><note><para>
    /// Only certain AWS operations return an encoded authorization message. The documentation
    /// for an individual operation indicates whether that operation returns an encoded message
    /// in addition to returning an HTTP code.
    /// </para></note><para>
    /// The message is encoded because the details of the authorization status can constitute
    /// privileged information that the user who requested the operation should not see. To
    /// decode an authorization status message, a user must be granted permissions via an
    /// IAM policy to request the <code>DecodeAuthorizationMessage</code> (<code>sts:DecodeAuthorizationMessage</code>)
    /// action. 
    /// </para><para>
    /// The decoded message includes the following type of information:
    /// </para><ul><li><para>
    /// Whether the request was denied due to an explicit deny or due to the absence of an
    /// explicit allow. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_evaluation-logic.html#policy-eval-denyallow">Determining
    /// Whether a Request is Allowed or Denied</a> in the <i>IAM User Guide</i>. 
    /// </para></li><li><para>
    /// The principal who made the request.
    /// </para></li><li><para>
    /// The requested action.
    /// </para></li><li><para>
    /// The requested resource.
    /// </para></li><li><para>
    /// The values of condition keys in the context of the user's request.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Convert", "STSAuthorizationMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Security Token Service (STS) DecodeAuthorizationMessage API operation.", Operation = new[] {"DecodeAuthorizationMessage"}, SelectReturnType = typeof(Amazon.SecurityToken.Model.DecodeAuthorizationMessageResponse))]
    [AWSCmdletOutput("System.String or Amazon.SecurityToken.Model.DecodeAuthorizationMessageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SecurityToken.Model.DecodeAuthorizationMessageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConvertSTSAuthorizationMessageCmdlet : AmazonSecurityTokenServiceClientCmdlet, IExecutor
    {
        
        #region Parameter EncodedMessage
        /// <summary>
        /// <para>
        /// <para>The encoded message that was returned with the response.</para>
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
        public System.String EncodedMessage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DecodedMessage'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityToken.Model.DecodeAuthorizationMessageResponse).
        /// Specifying the name of a property of type Amazon.SecurityToken.Model.DecodeAuthorizationMessageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DecodedMessage";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EncodedMessage parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EncodedMessage' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EncodedMessage' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EncodedMessage), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Convert-STSAuthorizationMessage (DecodeAuthorizationMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityToken.Model.DecodeAuthorizationMessageResponse, ConvertSTSAuthorizationMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EncodedMessage;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EncodedMessage = this.EncodedMessage;
            #if MODULAR
            if (this.EncodedMessage == null && ParameterWasBound(nameof(this.EncodedMessage)))
            {
                WriteWarning("You are passing $null as a value for parameter EncodedMessage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityToken.Model.DecodeAuthorizationMessageRequest();
            
            if (cmdletContext.EncodedMessage != null)
            {
                request.EncodedMessage = cmdletContext.EncodedMessage;
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
        
        private Amazon.SecurityToken.Model.DecodeAuthorizationMessageResponse CallAWSServiceOperation(IAmazonSecurityTokenService client, Amazon.SecurityToken.Model.DecodeAuthorizationMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Token Service (STS)", "DecodeAuthorizationMessage");
            try
            {
                #if DESKTOP
                return client.DecodeAuthorizationMessage(request);
                #elif CORECLR
                return client.DecodeAuthorizationMessageAsync(request).GetAwaiter().GetResult();
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
            public System.String EncodedMessage { get; set; }
            public System.Func<Amazon.SecurityToken.Model.DecodeAuthorizationMessageResponse, ConvertSTSAuthorizationMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DecodedMessage;
        }
        
    }
}

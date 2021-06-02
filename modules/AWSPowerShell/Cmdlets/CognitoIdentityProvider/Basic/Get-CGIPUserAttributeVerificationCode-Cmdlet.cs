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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Gets the user attribute verification code for the specified attribute name.
    /// 
    ///  <note><para>
    /// This action might generate an SMS text message. Starting June 1, 2021, U.S. telecom
    /// carriers require that you register an origination phone number before you can send
    /// SMS messages to U.S. phone numbers. If you use SMS text messages in Amazon Cognito,
    /// you must register a phone number with <a href="https://console.aws.amazon.com/pinpoint/home/">Amazon
    /// Pinpoint</a>. Cognito will use the the registered number automatically. Otherwise,
    /// Cognito users that must receive SMS messages might be unable to sign up, activate
    /// their accounts, or sign in.
    /// </para><para>
    /// If you have never used SMS text messages with Amazon Cognito or any other AWS service,
    /// Amazon SNS might place your account in SMS sandbox. In <i><a href="https://docs.aws.amazon.com/sns/latest/dg/sns-sms-sandbox.html">sandbox
    /// mode</a></i>, you’ll have limitations, such as sending messages to only verified
    /// phone numbers. After testing in the sandbox environment, you can move out of the SMS
    /// sandbox and into production. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools-sms-userpool-settings.html">
    /// SMS message settings for Cognito User Pools</a> in the <i>Amazon Cognito Developer
    /// Guide</i>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CGIPUserAttributeVerificationCode")]
    [OutputType("Amazon.CognitoIdentityProvider.Model.CodeDeliveryDetailsType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider GetUserAttributeVerificationCode API operation. This operation uses anonymous authentication and does not require credential parameters to be supplied.", Operation = new[] {"GetUserAttributeVerificationCode"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.GetUserAttributeVerificationCodeResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.CodeDeliveryDetailsType or Amazon.CognitoIdentityProvider.Model.GetUserAttributeVerificationCodeResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.CodeDeliveryDetailsType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.GetUserAttributeVerificationCodeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCGIPUserAttributeVerificationCodeCmdlet : AnonymousAmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter AccessToken
        /// <summary>
        /// <para>
        /// <para>The access token returned by the server response to get the user attribute verification
        /// code.</para>
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
        public System.String AccessToken { get; set; }
        #endregion
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>The attribute name returned by the server response to get the user attribute verification
        /// code.</para>
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
        public System.String AttributeName { get; set; }
        #endregion
        
        #region Parameter ClientMetadata
        /// <summary>
        /// <para>
        /// <para>A map of custom key-value pairs that you can provide as input for any custom workflows
        /// that this action triggers. </para><para>You create custom workflows by assigning AWS Lambda functions to user pool triggers.
        /// When you use the GetUserAttributeVerificationCode API action, Amazon Cognito invokes
        /// the function that is assigned to the <i>custom message</i> trigger. When Amazon Cognito
        /// invokes this function, it passes a JSON payload, which the function receives as input.
        /// This payload contains a <code>clientMetadata</code> attribute, which provides the
        /// data that you assigned to the ClientMetadata parameter in your GetUserAttributeVerificationCode
        /// request. In your function code in AWS Lambda, you can process the <code>clientMetadata</code>
        /// value to enhance your workflow for your specific needs.</para><para>For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools-working-with-aws-lambda-triggers.html">Customizing
        /// User Pool Workflows with Lambda Triggers</a> in the <i>Amazon Cognito Developer Guide</i>.</para><note><para>Take the following limitations into consideration when you use the ClientMetadata
        /// parameter:</para><ul><li><para>Amazon Cognito does not store the ClientMetadata value. This data is available only
        /// to AWS Lambda triggers that are assigned to a user pool to support custom workflows.
        /// If your user pool configuration does not include triggers, the ClientMetadata parameter
        /// serves no purpose.</para></li><li><para>Amazon Cognito does not validate the ClientMetadata value.</para></li><li><para>Amazon Cognito does not encrypt the the ClientMetadata value, so don't use it to provide
        /// sensitive information.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ClientMetadata { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CodeDeliveryDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.GetUserAttributeVerificationCodeResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.GetUserAttributeVerificationCodeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CodeDeliveryDetails";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.GetUserAttributeVerificationCodeResponse, GetCGIPUserAttributeVerificationCodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessToken = this.AccessToken;
            #if MODULAR
            if (this.AccessToken == null && ParameterWasBound(nameof(this.AccessToken)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AttributeName = this.AttributeName;
            #if MODULAR
            if (this.AttributeName == null && ParameterWasBound(nameof(this.AttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ClientMetadata != null)
            {
                context.ClientMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ClientMetadata.Keys)
                {
                    context.ClientMetadata.Add((String)hashKey, (String)(this.ClientMetadata[hashKey]));
                }
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
            var request = new Amazon.CognitoIdentityProvider.Model.GetUserAttributeVerificationCodeRequest();
            
            if (cmdletContext.AccessToken != null)
            {
                request.AccessToken = cmdletContext.AccessToken;
            }
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeName = cmdletContext.AttributeName;
            }
            if (cmdletContext.ClientMetadata != null)
            {
                request.ClientMetadata = cmdletContext.ClientMetadata;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_RegionEndpoint);
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
        
        private Amazon.CognitoIdentityProvider.Model.GetUserAttributeVerificationCodeResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.GetUserAttributeVerificationCodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "GetUserAttributeVerificationCode");
            try
            {
                #if DESKTOP
                return client.GetUserAttributeVerificationCode(request);
                #elif CORECLR
                return client.GetUserAttributeVerificationCodeAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessToken { get; set; }
            public System.String AttributeName { get; set; }
            public Dictionary<System.String, System.String> ClientMetadata { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.GetUserAttributeVerificationCodeResponse, GetCGIPUserAttributeVerificationCodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CodeDeliveryDetails;
        }
        
    }
}

/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Updates the Secure Sockets Layer (SSL) certificate for the custom domain for your
    /// user pool.
    /// 
    ///  
    /// <para>
    /// You can use this operation to provide the Amazon Resource Name (ARN) of a new certificate
    /// to Amazon Cognito. You cannot use it to change the domain for a user pool.
    /// </para><para>
    /// A custom domain is used to host the Amazon Cognito hosted UI, which provides sign-up
    /// and sign-in pages for your application. When you set up a custom domain, you provide
    /// a certificate that you manage with AWS Certificate Manager (ACM). When necessary,
    /// you can use this operation to change the certificate that you applied to your custom
    /// domain.
    /// </para><para>
    /// Usually, this is unnecessary following routine certificate renewal with ACM. When
    /// you renew your existing certificate in ACM, the ARN for your certificate remains the
    /// same, and your custom domain uses the new certificate automatically.
    /// </para><para>
    /// However, if you replace your existing certificate with a new one, ACM gives the new
    /// certificate a new ARN. To apply the new certificate to your custom domain, you must
    /// provide this ARN to Amazon Cognito.
    /// </para><para>
    /// When you add your new certificate in ACM, you must choose US East (N. Virginia) as
    /// the AWS Region.
    /// </para><para>
    /// After you submit your request, Amazon Cognito requires up to 1 hour to distribute
    /// your new certificate to your custom domain.
    /// </para><para>
    /// For more information about adding a custom domain to your user pool, see <a href="http://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-add-custom-domain.html">Using
    /// Your Own Domain for the Hosted UI</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CGIPUserPoolDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider UpdateUserPoolDomain API operation.", Operation = new[] {"UpdateUserPoolDomain"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCGIPUserPoolDomainCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter CustomDomainConfig_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an AWS Certificate Manager SSL certificate. You
        /// use this certificate for the subdomain of your custom domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomDomainConfig_CertificateArn { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The domain name for the custom domain that hosts the sign-up and sign-in pages for
        /// your application. For example: <code>auth.example.com</code>. </para><para>This string can include only lowercase letters, numbers, and hyphens. Do not use a
        /// hyphen for the first or last character. Use periods to separate subdomain names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool that is associated with the custom domain that you are updating
        /// the certificate for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UserPoolId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CGIPUserPoolDomain (UpdateUserPoolDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CustomDomainConfig_CertificateArn = this.CustomDomainConfig_CertificateArn;
            context.Domain = this.Domain;
            context.UserPoolId = this.UserPoolId;
            
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
            var request = new Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainRequest();
            
            
             // populate CustomDomainConfig
            bool requestCustomDomainConfigIsNull = true;
            request.CustomDomainConfig = new Amazon.CognitoIdentityProvider.Model.CustomDomainConfigType();
            System.String requestCustomDomainConfig_customDomainConfig_CertificateArn = null;
            if (cmdletContext.CustomDomainConfig_CertificateArn != null)
            {
                requestCustomDomainConfig_customDomainConfig_CertificateArn = cmdletContext.CustomDomainConfig_CertificateArn;
            }
            if (requestCustomDomainConfig_customDomainConfig_CertificateArn != null)
            {
                request.CustomDomainConfig.CertificateArn = requestCustomDomainConfig_customDomainConfig_CertificateArn;
                requestCustomDomainConfigIsNull = false;
            }
             // determine if request.CustomDomainConfig should be set to null
            if (requestCustomDomainConfigIsNull)
            {
                request.CustomDomainConfig = null;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CloudFrontDomain;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.UpdateUserPoolDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "UpdateUserPoolDomain");
            try
            {
                #if DESKTOP
                return client.UpdateUserPoolDomain(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateUserPoolDomainAsync(request);
                return task.Result;
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
            public System.String CustomDomainConfig_CertificateArn { get; set; }
            public System.String Domain { get; set; }
            public System.String UserPoolId { get; set; }
        }
        
    }
}

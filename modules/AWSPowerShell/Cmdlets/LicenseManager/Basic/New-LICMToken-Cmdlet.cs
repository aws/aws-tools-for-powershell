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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Creates a long-lived token.
    /// 
    ///  
    /// <para>
    /// A refresh token is a JWT token used to get an access token. With an access token,
    /// you can call AssumeRoleWithWebIdentity to get role credentials that you can use to
    /// call License Manager to manage the specified license.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LICMToken", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LicenseManager.Model.CreateTokenResponse")]
    [AWSCmdlet("Calls the AWS License Manager CreateToken API operation.", Operation = new[] {"CreateToken"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.CreateTokenResponse))]
    [AWSCmdletOutput("Amazon.LicenseManager.Model.CreateTokenResponse",
        "This cmdlet returns an Amazon.LicenseManager.Model.CreateTokenResponse object containing multiple properties."
    )]
    public partial class NewLICMTokenCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExpirationInDay
        /// <summary>
        /// <para>
        /// <para>Token expiration, in days, counted from token creation. The default is 365 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpirationInDays")]
        public System.Int32? ExpirationInDay { get; set; }
        #endregion
        
        #region Parameter LicenseArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the license. The ARN is mapped to the aud claim of the
        /// JWT token.</para>
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
        public System.String LicenseArn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the IAM roles to embed in the token. License Manager
        /// does not check whether the roles are in use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RoleArns")]
        public System.String[] RoleArn { get; set; }
        #endregion
        
        #region Parameter TokenProperty
        /// <summary>
        /// <para>
        /// <para>Data specified by the caller to be included in the JWT token. The data is mapped to
        /// the amr claim of the JWT token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TokenProperties")]
        public System.String[] TokenProperty { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token, valid for 10 minutes.</para>
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
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.CreateTokenResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.CreateTokenResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LicenseArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LICMToken (CreateToken)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.CreateTokenResponse, NewLICMTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpirationInDay = this.ExpirationInDay;
            context.LicenseArn = this.LicenseArn;
            #if MODULAR
            if (this.LicenseArn == null && ParameterWasBound(nameof(this.LicenseArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RoleArn != null)
            {
                context.RoleArn = new List<System.String>(this.RoleArn);
            }
            if (this.TokenProperty != null)
            {
                context.TokenProperty = new List<System.String>(this.TokenProperty);
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
            var request = new Amazon.LicenseManager.Model.CreateTokenRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ExpirationInDay != null)
            {
                request.ExpirationInDays = cmdletContext.ExpirationInDay.Value;
            }
            if (cmdletContext.LicenseArn != null)
            {
                request.LicenseArn = cmdletContext.LicenseArn;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArns = cmdletContext.RoleArn;
            }
            if (cmdletContext.TokenProperty != null)
            {
                request.TokenProperties = cmdletContext.TokenProperty;
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
        
        private Amazon.LicenseManager.Model.CreateTokenResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.CreateTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "CreateToken");
            try
            {
                #if DESKTOP
                return client.CreateToken(request);
                #elif CORECLR
                return client.CreateTokenAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ExpirationInDay { get; set; }
            public System.String LicenseArn { get; set; }
            public List<System.String> RoleArn { get; set; }
            public List<System.String> TokenProperty { get; set; }
            public System.Func<Amazon.LicenseManager.Model.CreateTokenResponse, NewLICMTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Adds or updates an authentication method for an application.
    /// </summary>
    [Cmdlet("Write", "SSOADMNApplicationAuthenticationMethod", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin PutApplicationAuthenticationMethod API operation.", Operation = new[] {"PutApplicationAuthenticationMethod"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.PutApplicationAuthenticationMethodResponse))]
    [AWSCmdletOutput("None or Amazon.SSOAdmin.Model.PutApplicationAuthenticationMethodResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSOAdmin.Model.PutApplicationAuthenticationMethodResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteSSOADMNApplicationAuthenticationMethodCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Iam_ActorPolicy
        /// <summary>
        /// <para>
        /// <para>An IAM policy document in JSON.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationMethod_Iam_ActorPolicy")]
        public System.Management.Automation.PSObject Iam_ActorPolicy { get; set; }
        #endregion
        
        #region Parameter ApplicationArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the application with the authentication method to add or update.</para>
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
        public System.String ApplicationArn { get; set; }
        #endregion
        
        #region Parameter AuthenticationMethodType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of the authentication method that you want to add or update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SSOAdmin.AuthenticationMethodType")]
        public Amazon.SSOAdmin.AuthenticationMethodType AuthenticationMethodType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.PutApplicationAuthenticationMethodResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SSOADMNApplicationAuthenticationMethod (PutApplicationAuthenticationMethod)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.PutApplicationAuthenticationMethodResponse, WriteSSOADMNApplicationAuthenticationMethodCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationArn = this.ApplicationArn;
            #if MODULAR
            if (this.ApplicationArn == null && ParameterWasBound(nameof(this.ApplicationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Iam_ActorPolicy = this.Iam_ActorPolicy;
            context.AuthenticationMethodType = this.AuthenticationMethodType;
            #if MODULAR
            if (this.AuthenticationMethodType == null && ParameterWasBound(nameof(this.AuthenticationMethodType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationMethodType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSOAdmin.Model.PutApplicationAuthenticationMethodRequest();
            
            if (cmdletContext.ApplicationArn != null)
            {
                request.ApplicationArn = cmdletContext.ApplicationArn;
            }
            
             // populate AuthenticationMethod
            var requestAuthenticationMethodIsNull = true;
            request.AuthenticationMethod = new Amazon.SSOAdmin.Model.AuthenticationMethod();
            Amazon.SSOAdmin.Model.IamAuthenticationMethod requestAuthenticationMethod_authenticationMethod_Iam = null;
            
             // populate Iam
            var requestAuthenticationMethod_authenticationMethod_IamIsNull = true;
            requestAuthenticationMethod_authenticationMethod_Iam = new Amazon.SSOAdmin.Model.IamAuthenticationMethod();
            Amazon.Runtime.Documents.Document? requestAuthenticationMethod_authenticationMethod_Iam_iam_ActorPolicy = null;
            if (cmdletContext.Iam_ActorPolicy != null)
            {
                requestAuthenticationMethod_authenticationMethod_Iam_iam_ActorPolicy = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Iam_ActorPolicy);
            }
            if (requestAuthenticationMethod_authenticationMethod_Iam_iam_ActorPolicy != null)
            {
                requestAuthenticationMethod_authenticationMethod_Iam.ActorPolicy = requestAuthenticationMethod_authenticationMethod_Iam_iam_ActorPolicy.Value;
                requestAuthenticationMethod_authenticationMethod_IamIsNull = false;
            }
             // determine if requestAuthenticationMethod_authenticationMethod_Iam should be set to null
            if (requestAuthenticationMethod_authenticationMethod_IamIsNull)
            {
                requestAuthenticationMethod_authenticationMethod_Iam = null;
            }
            if (requestAuthenticationMethod_authenticationMethod_Iam != null)
            {
                request.AuthenticationMethod.Iam = requestAuthenticationMethod_authenticationMethod_Iam;
                requestAuthenticationMethodIsNull = false;
            }
             // determine if request.AuthenticationMethod should be set to null
            if (requestAuthenticationMethodIsNull)
            {
                request.AuthenticationMethod = null;
            }
            if (cmdletContext.AuthenticationMethodType != null)
            {
                request.AuthenticationMethodType = cmdletContext.AuthenticationMethodType;
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
        
        private Amazon.SSOAdmin.Model.PutApplicationAuthenticationMethodResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.PutApplicationAuthenticationMethodRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "PutApplicationAuthenticationMethod");
            try
            {
                #if DESKTOP
                return client.PutApplicationAuthenticationMethod(request);
                #elif CORECLR
                return client.PutApplicationAuthenticationMethodAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationArn { get; set; }
            public System.Management.Automation.PSObject Iam_ActorPolicy { get; set; }
            public Amazon.SSOAdmin.AuthenticationMethodType AuthenticationMethodType { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.PutApplicationAuthenticationMethodResponse, WriteSSOADMNApplicationAuthenticationMethodCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

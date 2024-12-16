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
using Amazon.WorkMail;
using Amazon.WorkMail.Model;

namespace Amazon.PowerShell.Cmdlets.WM
{
    /// <summary>
    /// Creates an <c>AvailabilityConfiguration</c> for the given WorkMail organization and
    /// domain.
    /// </summary>
    [Cmdlet("New", "WMAvailabilityConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkMail CreateAvailabilityConfiguration API operation.", Operation = new[] {"CreateAvailabilityConfiguration"}, SelectReturnType = typeof(Amazon.WorkMail.Model.CreateAvailabilityConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.WorkMail.Model.CreateAvailabilityConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkMail.Model.CreateAvailabilityConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewWMAvailabilityConfigurationCmdlet : AmazonWorkMailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The domain to which the provider applies.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter EwsProvider_EwsEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint of the remote EWS server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EwsProvider_EwsEndpoint { get; set; }
        #endregion
        
        #region Parameter EwsProvider_EwsPassword
        /// <summary>
        /// <para>
        /// <para>The password used to authenticate the remote EWS server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EwsProvider_EwsPassword { get; set; }
        #endregion
        
        #region Parameter EwsProvider_EwsUsername
        /// <summary>
        /// <para>
        /// <para>The username used to authenticate the remote EWS server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EwsProvider_EwsUsername { get; set; }
        #endregion
        
        #region Parameter LambdaProvider_LambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Lambda that acts as the availability provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaProvider_LambdaArn { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>The WorkMail organization for which the <c>AvailabilityConfiguration</c> will be created.</para>
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
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An idempotent token that ensures that an API request is executed only once.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkMail.Model.CreateAvailabilityConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WMAvailabilityConfiguration (CreateAvailabilityConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkMail.Model.CreateAvailabilityConfigurationResponse, NewWMAvailabilityConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EwsProvider_EwsEndpoint = this.EwsProvider_EwsEndpoint;
            context.EwsProvider_EwsPassword = this.EwsProvider_EwsPassword;
            context.EwsProvider_EwsUsername = this.EwsProvider_EwsUsername;
            context.LambdaProvider_LambdaArn = this.LambdaProvider_LambdaArn;
            context.OrganizationId = this.OrganizationId;
            #if MODULAR
            if (this.OrganizationId == null && ParameterWasBound(nameof(this.OrganizationId)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkMail.Model.CreateAvailabilityConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate EwsProvider
            var requestEwsProviderIsNull = true;
            request.EwsProvider = new Amazon.WorkMail.Model.EwsAvailabilityProvider();
            System.String requestEwsProvider_ewsProvider_EwsEndpoint = null;
            if (cmdletContext.EwsProvider_EwsEndpoint != null)
            {
                requestEwsProvider_ewsProvider_EwsEndpoint = cmdletContext.EwsProvider_EwsEndpoint;
            }
            if (requestEwsProvider_ewsProvider_EwsEndpoint != null)
            {
                request.EwsProvider.EwsEndpoint = requestEwsProvider_ewsProvider_EwsEndpoint;
                requestEwsProviderIsNull = false;
            }
            System.String requestEwsProvider_ewsProvider_EwsPassword = null;
            if (cmdletContext.EwsProvider_EwsPassword != null)
            {
                requestEwsProvider_ewsProvider_EwsPassword = cmdletContext.EwsProvider_EwsPassword;
            }
            if (requestEwsProvider_ewsProvider_EwsPassword != null)
            {
                request.EwsProvider.EwsPassword = requestEwsProvider_ewsProvider_EwsPassword;
                requestEwsProviderIsNull = false;
            }
            System.String requestEwsProvider_ewsProvider_EwsUsername = null;
            if (cmdletContext.EwsProvider_EwsUsername != null)
            {
                requestEwsProvider_ewsProvider_EwsUsername = cmdletContext.EwsProvider_EwsUsername;
            }
            if (requestEwsProvider_ewsProvider_EwsUsername != null)
            {
                request.EwsProvider.EwsUsername = requestEwsProvider_ewsProvider_EwsUsername;
                requestEwsProviderIsNull = false;
            }
             // determine if request.EwsProvider should be set to null
            if (requestEwsProviderIsNull)
            {
                request.EwsProvider = null;
            }
            
             // populate LambdaProvider
            var requestLambdaProviderIsNull = true;
            request.LambdaProvider = new Amazon.WorkMail.Model.LambdaAvailabilityProvider();
            System.String requestLambdaProvider_lambdaProvider_LambdaArn = null;
            if (cmdletContext.LambdaProvider_LambdaArn != null)
            {
                requestLambdaProvider_lambdaProvider_LambdaArn = cmdletContext.LambdaProvider_LambdaArn;
            }
            if (requestLambdaProvider_lambdaProvider_LambdaArn != null)
            {
                request.LambdaProvider.LambdaArn = requestLambdaProvider_lambdaProvider_LambdaArn;
                requestLambdaProviderIsNull = false;
            }
             // determine if request.LambdaProvider should be set to null
            if (requestLambdaProviderIsNull)
            {
                request.LambdaProvider = null;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
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
        
        private Amazon.WorkMail.Model.CreateAvailabilityConfigurationResponse CallAWSServiceOperation(IAmazonWorkMail client, Amazon.WorkMail.Model.CreateAvailabilityConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkMail", "CreateAvailabilityConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateAvailabilityConfiguration(request);
                #elif CORECLR
                return client.CreateAvailabilityConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public System.String EwsProvider_EwsEndpoint { get; set; }
            public System.String EwsProvider_EwsPassword { get; set; }
            public System.String EwsProvider_EwsUsername { get; set; }
            public System.String LambdaProvider_LambdaArn { get; set; }
            public System.String OrganizationId { get; set; }
            public System.Func<Amazon.WorkMail.Model.CreateAvailabilityConfigurationResponse, NewWMAvailabilityConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

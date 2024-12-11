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
    /// Performs a test on an availability provider to ensure that access is allowed. For
    /// EWS, it verifies the provided credentials can be used to successfully log in. For
    /// Lambda, it verifies that the Lambda function can be invoked and that the resource
    /// access policy was configured to deny anonymous access. An anonymous invocation is
    /// one done without providing either a <c>SourceArn</c> or <c>SourceAccount</c> header.
    /// 
    ///  <note><para>
    /// The request must contain either one provider definition (<c>EwsProvider</c> or <c>LambdaProvider</c>)
    /// or the <c>DomainName</c> parameter. If the <c>DomainName</c> parameter is provided,
    /// the configuration stored under the <c>DomainName</c> will be tested.
    /// </para></note>
    /// </summary>
    [Cmdlet("Test", "WMAvailabilityConfiguration")]
    [OutputType("Amazon.WorkMail.Model.TestAvailabilityConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon WorkMail TestAvailabilityConfiguration API operation.", Operation = new[] {"TestAvailabilityConfiguration"}, SelectReturnType = typeof(Amazon.WorkMail.Model.TestAvailabilityConfigurationResponse))]
    [AWSCmdletOutput("Amazon.WorkMail.Model.TestAvailabilityConfigurationResponse",
        "This cmdlet returns an Amazon.WorkMail.Model.TestAvailabilityConfigurationResponse object containing multiple properties."
    )]
    public partial class TestWMAvailabilityConfigurationCmdlet : AmazonWorkMailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The domain to which the provider applies. If this field is provided, a stored availability
        /// provider associated to this domain name will be tested.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// <para>The WorkMail organization where the availability provider will be tested.</para>
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
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkMail.Model.TestAvailabilityConfigurationResponse).
        /// Specifying the name of a property of type Amazon.WorkMail.Model.TestAvailabilityConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkMail.Model.TestAvailabilityConfigurationResponse, TestWMAvailabilityConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainName = this.DomainName;
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
            var request = new Amazon.WorkMail.Model.TestAvailabilityConfigurationRequest();
            
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
        
        private Amazon.WorkMail.Model.TestAvailabilityConfigurationResponse CallAWSServiceOperation(IAmazonWorkMail client, Amazon.WorkMail.Model.TestAvailabilityConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkMail", "TestAvailabilityConfiguration");
            try
            {
                #if DESKTOP
                return client.TestAvailabilityConfiguration(request);
                #elif CORECLR
                return client.TestAvailabilityConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public System.String EwsProvider_EwsEndpoint { get; set; }
            public System.String EwsProvider_EwsPassword { get; set; }
            public System.String EwsProvider_EwsUsername { get; set; }
            public System.String LambdaProvider_LambdaArn { get; set; }
            public System.String OrganizationId { get; set; }
            public System.Func<Amazon.WorkMail.Model.TestAvailabilityConfigurationResponse, TestWMAvailabilityConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

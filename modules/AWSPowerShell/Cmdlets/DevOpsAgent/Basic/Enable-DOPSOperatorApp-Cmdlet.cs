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
using Amazon.DevOpsAgent;
using Amazon.DevOpsAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOPS
{
    /// <summary>
    /// Enable the Operator App to access the given AgentSpace
    /// </summary>
    [Cmdlet("Enable", "DOPSOperatorApp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DevOpsAgent.Model.EnableOperatorAppResponse")]
    [AWSCmdlet("Calls the AWS DevOps Agent Service EnableOperatorApp API operation.", Operation = new[] {"EnableOperatorApp"}, SelectReturnType = typeof(Amazon.DevOpsAgent.Model.EnableOperatorAppResponse))]
    [AWSCmdletOutput("Amazon.DevOpsAgent.Model.EnableOperatorAppResponse",
        "This cmdlet returns an Amazon.DevOpsAgent.Model.EnableOperatorAppResponse object containing multiple properties."
    )]
    public partial class EnableDOPSOperatorAppCmdlet : AmazonDevOpsAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the AgentSpace</para>
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
        public System.String AgentSpaceId { get; set; }
        #endregion
        
        #region Parameter AuthFlow
        /// <summary>
        /// <para>
        /// <para>The authentication flow configured for the operator App. e.g. iam or idc</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DevOpsAgent.AuthFlow")]
        public Amazon.DevOpsAgent.AuthFlow AuthFlow { get; set; }
        #endregion
        
        #region Parameter IdcInstanceArn
        /// <summary>
        /// <para>
        /// <para>The IdC instance Arn used to create an IdC auth application</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdcInstanceArn { get; set; }
        #endregion
        
        #region Parameter IdpClientId
        /// <summary>
        /// <para>
        /// <para>The OIDC client ID for the IdP application</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdpClientId { get; set; }
        #endregion
        
        #region Parameter IdpClientSecret
        /// <summary>
        /// <para>
        /// <para>The OIDC client secret for the IdP application</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdpClientSecret { get; set; }
        #endregion
        
        #region Parameter IssuerUrl
        /// <summary>
        /// <para>
        /// <para>The OIDC issuer URL of the external Identity Provider</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IssuerUrl { get; set; }
        #endregion
        
        #region Parameter OperatorAppRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role end users assume to access AIDevOps APIs</para>
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
        public System.String OperatorAppRoleArn { get; set; }
        #endregion
        
        #region Parameter Provider
        /// <summary>
        /// <para>
        /// <para>The Identity Provider name (e.g., Entra, Okta, Google)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Provider { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsAgent.Model.EnableOperatorAppResponse).
        /// Specifying the name of a property of type Amazon.DevOpsAgent.Model.EnableOperatorAppResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OperatorAppRoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-DOPSOperatorApp (EnableOperatorApp)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsAgent.Model.EnableOperatorAppResponse, EnableDOPSOperatorAppCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthFlow = this.AuthFlow;
            #if MODULAR
            if (this.AuthFlow == null && ParameterWasBound(nameof(this.AuthFlow)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthFlow which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdcInstanceArn = this.IdcInstanceArn;
            context.IdpClientId = this.IdpClientId;
            context.IdpClientSecret = this.IdpClientSecret;
            context.IssuerUrl = this.IssuerUrl;
            context.OperatorAppRoleArn = this.OperatorAppRoleArn;
            #if MODULAR
            if (this.OperatorAppRoleArn == null && ParameterWasBound(nameof(this.OperatorAppRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter OperatorAppRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Provider = this.Provider;
            
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
            var request = new Amazon.DevOpsAgent.Model.EnableOperatorAppRequest();
            
            if (cmdletContext.AgentSpaceId != null)
            {
                request.AgentSpaceId = cmdletContext.AgentSpaceId;
            }
            if (cmdletContext.AuthFlow != null)
            {
                request.AuthFlow = cmdletContext.AuthFlow;
            }
            if (cmdletContext.IdcInstanceArn != null)
            {
                request.IdcInstanceArn = cmdletContext.IdcInstanceArn;
            }
            if (cmdletContext.IdpClientId != null)
            {
                request.IdpClientId = cmdletContext.IdpClientId;
            }
            if (cmdletContext.IdpClientSecret != null)
            {
                request.IdpClientSecret = cmdletContext.IdpClientSecret;
            }
            if (cmdletContext.IssuerUrl != null)
            {
                request.IssuerUrl = cmdletContext.IssuerUrl;
            }
            if (cmdletContext.OperatorAppRoleArn != null)
            {
                request.OperatorAppRoleArn = cmdletContext.OperatorAppRoleArn;
            }
            if (cmdletContext.Provider != null)
            {
                request.Provider = cmdletContext.Provider;
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
        
        private Amazon.DevOpsAgent.Model.EnableOperatorAppResponse CallAWSServiceOperation(IAmazonDevOpsAgent client, Amazon.DevOpsAgent.Model.EnableOperatorAppRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DevOps Agent Service", "EnableOperatorApp");
            try
            {
                return client.EnableOperatorAppAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentSpaceId { get; set; }
            public Amazon.DevOpsAgent.AuthFlow AuthFlow { get; set; }
            public System.String IdcInstanceArn { get; set; }
            public System.String IdpClientId { get; set; }
            public System.String IdpClientSecret { get; set; }
            public System.String IssuerUrl { get; set; }
            public System.String OperatorAppRoleArn { get; set; }
            public System.String Provider { get; set; }
            public System.Func<Amazon.DevOpsAgent.Model.EnableOperatorAppResponse, EnableDOPSOperatorAppCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

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
using Amazon.SecurityAgent;
using Amazon.SecurityAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SECAG
{
    /// <summary>
    /// Creates the Integration of the Security Agent App with an external Provider
    /// </summary>
    [Cmdlet("New", "SECAGIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Security Agent CreateIntegration API operation.", Operation = new[] {"CreateIntegration"}, SelectReturnType = typeof(Amazon.SecurityAgent.Model.CreateIntegrationResponse))]
    [AWSCmdletOutput("System.String or Amazon.SecurityAgent.Model.CreateIntegrationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SecurityAgent.Model.CreateIntegrationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSECAGIntegrationCmdlet : AmazonSecurityAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Input_Github_Code
        /// <summary>
        /// <para>
        /// <para>Authorization code from OAuth flow</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Github_Code { get; set; }
        #endregion
        
        #region Parameter IntegrationDisplayName
        /// <summary>
        /// <para>
        /// <para>Display name for the integration</para>
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
        public System.String IntegrationDisplayName { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>KMS key ID for encrypting integration details</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Input_Github_OrganizationName
        /// <summary>
        /// <para>
        /// <para>Name of the GitHub organization</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Github_OrganizationName { get; set; }
        #endregion
        
        #region Parameter Provider
        /// <summary>
        /// <para>
        /// <para>Provider to integrate with</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SecurityAgent.Provider")]
        public Amazon.SecurityAgent.Provider Provider { get; set; }
        #endregion
        
        #region Parameter Input_Github_State
        /// <summary>
        /// <para>
        /// <para>CSRF state token for OAuth security</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Github_State { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to associate with the integration</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IntegrationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityAgent.Model.CreateIntegrationResponse).
        /// Specifying the name of a property of type Amazon.SecurityAgent.Model.CreateIntegrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IntegrationId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IntegrationDisplayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SECAGIntegration (CreateIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityAgent.Model.CreateIntegrationResponse, NewSECAGIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Input_Github_Code = this.Input_Github_Code;
            context.Input_Github_OrganizationName = this.Input_Github_OrganizationName;
            context.Input_Github_State = this.Input_Github_State;
            context.IntegrationDisplayName = this.IntegrationDisplayName;
            #if MODULAR
            if (this.IntegrationDisplayName == null && ParameterWasBound(nameof(this.IntegrationDisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationDisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            context.Provider = this.Provider;
            #if MODULAR
            if (this.Provider == null && ParameterWasBound(nameof(this.Provider)))
            {
                WriteWarning("You are passing $null as a value for parameter Provider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.SecurityAgent.Model.CreateIntegrationRequest();
            
            
             // populate Input
            var requestInputIsNull = true;
            request.Input = new Amazon.SecurityAgent.Model.ProviderInput();
            Amazon.SecurityAgent.Model.GitHubIntegrationInput requestInput_input_Github = null;
            
             // populate Github
            var requestInput_input_GithubIsNull = true;
            requestInput_input_Github = new Amazon.SecurityAgent.Model.GitHubIntegrationInput();
            System.String requestInput_input_Github_input_Github_Code = null;
            if (cmdletContext.Input_Github_Code != null)
            {
                requestInput_input_Github_input_Github_Code = cmdletContext.Input_Github_Code;
            }
            if (requestInput_input_Github_input_Github_Code != null)
            {
                requestInput_input_Github.Code = requestInput_input_Github_input_Github_Code;
                requestInput_input_GithubIsNull = false;
            }
            System.String requestInput_input_Github_input_Github_OrganizationName = null;
            if (cmdletContext.Input_Github_OrganizationName != null)
            {
                requestInput_input_Github_input_Github_OrganizationName = cmdletContext.Input_Github_OrganizationName;
            }
            if (requestInput_input_Github_input_Github_OrganizationName != null)
            {
                requestInput_input_Github.OrganizationName = requestInput_input_Github_input_Github_OrganizationName;
                requestInput_input_GithubIsNull = false;
            }
            System.String requestInput_input_Github_input_Github_State = null;
            if (cmdletContext.Input_Github_State != null)
            {
                requestInput_input_Github_input_Github_State = cmdletContext.Input_Github_State;
            }
            if (requestInput_input_Github_input_Github_State != null)
            {
                requestInput_input_Github.State = requestInput_input_Github_input_Github_State;
                requestInput_input_GithubIsNull = false;
            }
             // determine if requestInput_input_Github should be set to null
            if (requestInput_input_GithubIsNull)
            {
                requestInput_input_Github = null;
            }
            if (requestInput_input_Github != null)
            {
                request.Input.Github = requestInput_input_Github;
                requestInputIsNull = false;
            }
             // determine if request.Input should be set to null
            if (requestInputIsNull)
            {
                request.Input = null;
            }
            if (cmdletContext.IntegrationDisplayName != null)
            {
                request.IntegrationDisplayName = cmdletContext.IntegrationDisplayName;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Provider != null)
            {
                request.Provider = cmdletContext.Provider;
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
        
        private Amazon.SecurityAgent.Model.CreateIntegrationResponse CallAWSServiceOperation(IAmazonSecurityAgent client, Amazon.SecurityAgent.Model.CreateIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Agent", "CreateIntegration");
            try
            {
                return client.CreateIntegrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Input_Github_Code { get; set; }
            public System.String Input_Github_OrganizationName { get; set; }
            public System.String Input_Github_State { get; set; }
            public System.String IntegrationDisplayName { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.SecurityAgent.Provider Provider { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SecurityAgent.Model.CreateIntegrationResponse, NewSECAGIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IntegrationId;
        }
        
    }
}

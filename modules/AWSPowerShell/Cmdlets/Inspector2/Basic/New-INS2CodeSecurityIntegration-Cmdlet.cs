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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Creates a code security integration with a source code repository provider.
    /// 
    ///  
    /// <para>
    /// After calling the <c>CreateCodeSecurityIntegration</c> operation, you complete authentication
    /// and authorization with your provider. Next you call the <c>UpdateCodeSecurityIntegration</c>
    /// operation to provide the <c>details</c> to complete the integration setup
    /// </para>
    /// </summary>
    [Cmdlet("New", "INS2CodeSecurityIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Inspector2.Model.CreateCodeSecurityIntegrationResponse")]
    [AWSCmdlet("Calls the Inspector2 CreateCodeSecurityIntegration API operation.", Operation = new[] {"CreateCodeSecurityIntegration"}, SelectReturnType = typeof(Amazon.Inspector2.Model.CreateCodeSecurityIntegrationResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.CreateCodeSecurityIntegrationResponse",
        "This cmdlet returns an Amazon.Inspector2.Model.CreateCodeSecurityIntegrationResponse object containing multiple properties."
    )]
    public partial class NewINS2CodeSecurityIntegrationCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GitlabSelfManaged_AccessToken
        /// <summary>
        /// <para>
        /// <para>The personal access token used to authenticate with the self-managed GitLab instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_GitlabSelfManaged_AccessToken")]
        public System.String GitlabSelfManaged_AccessToken { get; set; }
        #endregion
        
        #region Parameter GitlabSelfManaged_InstanceUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the self-managed GitLab instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_GitlabSelfManaged_InstanceUrl")]
        public System.String GitlabSelfManaged_InstanceUrl { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the code security integration.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the code security integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of repository provider for the integration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Inspector2.IntegrationType")]
        public Amazon.Inspector2.IntegrationType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.CreateCodeSecurityIntegrationResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.CreateCodeSecurityIntegrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-INS2CodeSecurityIntegration (CreateCodeSecurityIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.CreateCodeSecurityIntegrationResponse, NewINS2CodeSecurityIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GitlabSelfManaged_AccessToken = this.GitlabSelfManaged_AccessToken;
            context.GitlabSelfManaged_InstanceUrl = this.GitlabSelfManaged_InstanceUrl;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector2.Model.CreateCodeSecurityIntegrationRequest();
            
            
             // populate Details
            var requestDetailsIsNull = true;
            request.Details = new Amazon.Inspector2.Model.CreateIntegrationDetail();
            Amazon.Inspector2.Model.CreateGitLabSelfManagedIntegrationDetail requestDetails_details_GitlabSelfManaged = null;
            
             // populate GitlabSelfManaged
            var requestDetails_details_GitlabSelfManagedIsNull = true;
            requestDetails_details_GitlabSelfManaged = new Amazon.Inspector2.Model.CreateGitLabSelfManagedIntegrationDetail();
            System.String requestDetails_details_GitlabSelfManaged_gitlabSelfManaged_AccessToken = null;
            if (cmdletContext.GitlabSelfManaged_AccessToken != null)
            {
                requestDetails_details_GitlabSelfManaged_gitlabSelfManaged_AccessToken = cmdletContext.GitlabSelfManaged_AccessToken;
            }
            if (requestDetails_details_GitlabSelfManaged_gitlabSelfManaged_AccessToken != null)
            {
                requestDetails_details_GitlabSelfManaged.AccessToken = requestDetails_details_GitlabSelfManaged_gitlabSelfManaged_AccessToken;
                requestDetails_details_GitlabSelfManagedIsNull = false;
            }
            System.String requestDetails_details_GitlabSelfManaged_gitlabSelfManaged_InstanceUrl = null;
            if (cmdletContext.GitlabSelfManaged_InstanceUrl != null)
            {
                requestDetails_details_GitlabSelfManaged_gitlabSelfManaged_InstanceUrl = cmdletContext.GitlabSelfManaged_InstanceUrl;
            }
            if (requestDetails_details_GitlabSelfManaged_gitlabSelfManaged_InstanceUrl != null)
            {
                requestDetails_details_GitlabSelfManaged.InstanceUrl = requestDetails_details_GitlabSelfManaged_gitlabSelfManaged_InstanceUrl;
                requestDetails_details_GitlabSelfManagedIsNull = false;
            }
             // determine if requestDetails_details_GitlabSelfManaged should be set to null
            if (requestDetails_details_GitlabSelfManagedIsNull)
            {
                requestDetails_details_GitlabSelfManaged = null;
            }
            if (requestDetails_details_GitlabSelfManaged != null)
            {
                request.Details.GitlabSelfManaged = requestDetails_details_GitlabSelfManaged;
                requestDetailsIsNull = false;
            }
             // determine if request.Details should be set to null
            if (requestDetailsIsNull)
            {
                request.Details = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.Inspector2.Model.CreateCodeSecurityIntegrationResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.CreateCodeSecurityIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "CreateCodeSecurityIntegration");
            try
            {
                #if DESKTOP
                return client.CreateCodeSecurityIntegration(request);
                #elif CORECLR
                return client.CreateCodeSecurityIntegrationAsync(request).GetAwaiter().GetResult();
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
            public System.String GitlabSelfManaged_AccessToken { get; set; }
            public System.String GitlabSelfManaged_InstanceUrl { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.Inspector2.IntegrationType Type { get; set; }
            public System.Func<Amazon.Inspector2.Model.CreateCodeSecurityIntegrationResponse, NewINS2CodeSecurityIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

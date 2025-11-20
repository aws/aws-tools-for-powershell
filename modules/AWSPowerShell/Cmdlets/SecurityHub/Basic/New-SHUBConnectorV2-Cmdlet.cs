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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Grants permission to create a connectorV2 based on input parameters. This API is in
    /// public preview and subject to change.
    /// </summary>
    [Cmdlet("New", "SHUBConnectorV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.CreateConnectorV2Response")]
    [AWSCmdlet("Calls the AWS Security Hub CreateConnectorV2 API operation.", Operation = new[] {"CreateConnectorV2"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.CreateConnectorV2Response))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.CreateConnectorV2Response",
        "This cmdlet returns an Amazon.SecurityHub.Model.CreateConnectorV2Response object containing multiple properties."
    )]
    public partial class NewSHUBConnectorV2Cmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ServiceNow_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID of ServiceNow ITSM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provider_ServiceNow_ClientId")]
        public System.String ServiceNow_ClientId { get; set; }
        #endregion
        
        #region Parameter ServiceNow_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret of ServiceNow ITSM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provider_ServiceNow_ClientSecret")]
        public System.String ServiceNow_ClientSecret { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the connectorV2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ServiceNow_InstanceName
        /// <summary>
        /// <para>
        /// <para>The instance name of ServiceNow ITSM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provider_ServiceNow_InstanceName")]
        public System.String ServiceNow_InstanceName { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of KMS key used to encrypt secrets for the connectorV2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The unique name of the connectorV2.</para>
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
        
        #region Parameter JiraCloud_ProjectKey
        /// <summary>
        /// <para>
        /// <para>The project key for a JiraCloud instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provider_JiraCloud_ProjectKey")]
        public System.String JiraCloud_ProjectKey { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the connectorV2 when you create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier used to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.CreateConnectorV2Response).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.CreateConnectorV2Response will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SHUBConnectorV2 (CreateConnectorV2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.CreateConnectorV2Response, NewSHUBConnectorV2Cmdlet>(Select) ??
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
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.KmsKeyArn = this.KmsKeyArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JiraCloud_ProjectKey = this.JiraCloud_ProjectKey;
            context.ServiceNow_ClientId = this.ServiceNow_ClientId;
            context.ServiceNow_ClientSecret = this.ServiceNow_ClientSecret;
            context.ServiceNow_InstanceName = this.ServiceNow_InstanceName;
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
            var request = new Amazon.SecurityHub.Model.CreateConnectorV2Request();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Provider
            var requestProviderIsNull = true;
            request.Provider = new Amazon.SecurityHub.Model.ProviderConfiguration();
            Amazon.SecurityHub.Model.JiraCloudProviderConfiguration requestProvider_provider_JiraCloud = null;
            
             // populate JiraCloud
            var requestProvider_provider_JiraCloudIsNull = true;
            requestProvider_provider_JiraCloud = new Amazon.SecurityHub.Model.JiraCloudProviderConfiguration();
            System.String requestProvider_provider_JiraCloud_jiraCloud_ProjectKey = null;
            if (cmdletContext.JiraCloud_ProjectKey != null)
            {
                requestProvider_provider_JiraCloud_jiraCloud_ProjectKey = cmdletContext.JiraCloud_ProjectKey;
            }
            if (requestProvider_provider_JiraCloud_jiraCloud_ProjectKey != null)
            {
                requestProvider_provider_JiraCloud.ProjectKey = requestProvider_provider_JiraCloud_jiraCloud_ProjectKey;
                requestProvider_provider_JiraCloudIsNull = false;
            }
             // determine if requestProvider_provider_JiraCloud should be set to null
            if (requestProvider_provider_JiraCloudIsNull)
            {
                requestProvider_provider_JiraCloud = null;
            }
            if (requestProvider_provider_JiraCloud != null)
            {
                request.Provider.JiraCloud = requestProvider_provider_JiraCloud;
                requestProviderIsNull = false;
            }
            Amazon.SecurityHub.Model.ServiceNowProviderConfiguration requestProvider_provider_ServiceNow = null;
            
             // populate ServiceNow
            var requestProvider_provider_ServiceNowIsNull = true;
            requestProvider_provider_ServiceNow = new Amazon.SecurityHub.Model.ServiceNowProviderConfiguration();
            System.String requestProvider_provider_ServiceNow_serviceNow_ClientId = null;
            if (cmdletContext.ServiceNow_ClientId != null)
            {
                requestProvider_provider_ServiceNow_serviceNow_ClientId = cmdletContext.ServiceNow_ClientId;
            }
            if (requestProvider_provider_ServiceNow_serviceNow_ClientId != null)
            {
                requestProvider_provider_ServiceNow.ClientId = requestProvider_provider_ServiceNow_serviceNow_ClientId;
                requestProvider_provider_ServiceNowIsNull = false;
            }
            System.String requestProvider_provider_ServiceNow_serviceNow_ClientSecret = null;
            if (cmdletContext.ServiceNow_ClientSecret != null)
            {
                requestProvider_provider_ServiceNow_serviceNow_ClientSecret = cmdletContext.ServiceNow_ClientSecret;
            }
            if (requestProvider_provider_ServiceNow_serviceNow_ClientSecret != null)
            {
                requestProvider_provider_ServiceNow.ClientSecret = requestProvider_provider_ServiceNow_serviceNow_ClientSecret;
                requestProvider_provider_ServiceNowIsNull = false;
            }
            System.String requestProvider_provider_ServiceNow_serviceNow_InstanceName = null;
            if (cmdletContext.ServiceNow_InstanceName != null)
            {
                requestProvider_provider_ServiceNow_serviceNow_InstanceName = cmdletContext.ServiceNow_InstanceName;
            }
            if (requestProvider_provider_ServiceNow_serviceNow_InstanceName != null)
            {
                requestProvider_provider_ServiceNow.InstanceName = requestProvider_provider_ServiceNow_serviceNow_InstanceName;
                requestProvider_provider_ServiceNowIsNull = false;
            }
             // determine if requestProvider_provider_ServiceNow should be set to null
            if (requestProvider_provider_ServiceNowIsNull)
            {
                requestProvider_provider_ServiceNow = null;
            }
            if (requestProvider_provider_ServiceNow != null)
            {
                request.Provider.ServiceNow = requestProvider_provider_ServiceNow;
                requestProviderIsNull = false;
            }
             // determine if request.Provider should be set to null
            if (requestProviderIsNull)
            {
                request.Provider = null;
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
        
        private Amazon.SecurityHub.Model.CreateConnectorV2Response CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.CreateConnectorV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "CreateConnectorV2");
            try
            {
                #if DESKTOP
                return client.CreateConnectorV2(request);
                #elif CORECLR
                return client.CreateConnectorV2Async(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String Name { get; set; }
            public System.String JiraCloud_ProjectKey { get; set; }
            public System.String ServiceNow_ClientId { get; set; }
            public System.String ServiceNow_ClientSecret { get; set; }
            public System.String ServiceNow_InstanceName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SecurityHub.Model.CreateConnectorV2Response, NewSHUBConnectorV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

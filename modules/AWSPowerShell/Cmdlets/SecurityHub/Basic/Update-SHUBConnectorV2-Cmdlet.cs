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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Grants permission to update a connectorV2 based on its id and input parameters. This
    /// API is in public preview and subject to change.
    /// </summary>
    [Cmdlet("Update", "SHUBConnectorV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Security Hub UpdateConnectorV2 API operation.", Operation = new[] {"UpdateConnectorV2"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.UpdateConnectorV2Response))]
    [AWSCmdletOutput("None or Amazon.SecurityHub.Model.UpdateConnectorV2Response",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityHub.Model.UpdateConnectorV2Response) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSHUBConnectorV2Cmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientSecret
        /// <summary>
        /// <para>
        /// <para>The clientSecret of ServiceNow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientSecret { get; set; }
        #endregion
        
        #region Parameter ConnectorId
        /// <summary>
        /// <para>
        /// <para>The UUID of the connectorV2 to identify connectorV2 resource.</para>
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
        public System.String ConnectorId { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.UpdateConnectorV2Response).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SHUBConnectorV2 (UpdateConnectorV2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.UpdateConnectorV2Response, UpdateSHUBConnectorV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientSecret = this.ClientSecret;
            context.ConnectorId = this.ConnectorId;
            #if MODULAR
            if (this.ConnectorId == null && ParameterWasBound(nameof(this.ConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.JiraCloud_ProjectKey = this.JiraCloud_ProjectKey;
            
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
            var request = new Amazon.SecurityHub.Model.UpdateConnectorV2Request();
            
            if (cmdletContext.ClientSecret != null)
            {
                request.ClientSecret = cmdletContext.ClientSecret;
            }
            if (cmdletContext.ConnectorId != null)
            {
                request.ConnectorId = cmdletContext.ConnectorId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Provider
            var requestProviderIsNull = true;
            request.Provider = new Amazon.SecurityHub.Model.ProviderUpdateConfiguration();
            Amazon.SecurityHub.Model.JiraCloudUpdateConfiguration requestProvider_provider_JiraCloud = null;
            
             // populate JiraCloud
            var requestProvider_provider_JiraCloudIsNull = true;
            requestProvider_provider_JiraCloud = new Amazon.SecurityHub.Model.JiraCloudUpdateConfiguration();
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
             // determine if request.Provider should be set to null
            if (requestProviderIsNull)
            {
                request.Provider = null;
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
        
        private Amazon.SecurityHub.Model.UpdateConnectorV2Response CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.UpdateConnectorV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "UpdateConnectorV2");
            try
            {
                return client.UpdateConnectorV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientSecret { get; set; }
            public System.String ConnectorId { get; set; }
            public System.String Description { get; set; }
            public System.String JiraCloud_ProjectKey { get; set; }
            public System.Func<Amazon.SecurityHub.Model.UpdateConnectorV2Response, UpdateSHUBConnectorV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

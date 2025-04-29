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
using Amazon.ConnectCampaignsV2;
using Amazon.ConnectCampaignsV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCS2
{
    /// <summary>
    /// Delete the integration for the specified Amazon Connect instance.
    /// </summary>
    [Cmdlet("Remove", "CCS2ConnectInstanceIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AmazonConnectCampaignServiceV2 DeleteConnectInstanceIntegration API operation.", Operation = new[] {"DeleteConnectInstanceIntegration"}, SelectReturnType = typeof(Amazon.ConnectCampaignsV2.Model.DeleteConnectInstanceIntegrationResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectCampaignsV2.Model.DeleteConnectInstanceIntegrationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectCampaignsV2.Model.DeleteConnectInstanceIntegrationResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCCS2ConnectInstanceIntegrationCmdlet : AmazonConnectCampaignsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectInstanceId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String ConnectInstanceId { get; set; }
        #endregion
        
        #region Parameter CustomerProfiles_DomainArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationIdentifier_CustomerProfiles_DomainArn")]
        public System.String CustomerProfiles_DomainArn { get; set; }
        #endregion
        
        #region Parameter QConnect_KnowledgeBaseArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationIdentifier_QConnect_KnowledgeBaseArn")]
        public System.String QConnect_KnowledgeBaseArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCampaignsV2.Model.DeleteConnectInstanceIntegrationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectInstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CCS2ConnectInstanceIntegration (DeleteConnectInstanceIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCampaignsV2.Model.DeleteConnectInstanceIntegrationResponse, RemoveCCS2ConnectInstanceIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectInstanceId = this.ConnectInstanceId;
            #if MODULAR
            if (this.ConnectInstanceId == null && ParameterWasBound(nameof(this.ConnectInstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectInstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomerProfiles_DomainArn = this.CustomerProfiles_DomainArn;
            context.QConnect_KnowledgeBaseArn = this.QConnect_KnowledgeBaseArn;
            
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
            var request = new Amazon.ConnectCampaignsV2.Model.DeleteConnectInstanceIntegrationRequest();
            
            if (cmdletContext.ConnectInstanceId != null)
            {
                request.ConnectInstanceId = cmdletContext.ConnectInstanceId;
            }
            
             // populate IntegrationIdentifier
            var requestIntegrationIdentifierIsNull = true;
            request.IntegrationIdentifier = new Amazon.ConnectCampaignsV2.Model.IntegrationIdentifier();
            Amazon.ConnectCampaignsV2.Model.CustomerProfilesIntegrationIdentifier requestIntegrationIdentifier_integrationIdentifier_CustomerProfiles = null;
            
             // populate CustomerProfiles
            var requestIntegrationIdentifier_integrationIdentifier_CustomerProfilesIsNull = true;
            requestIntegrationIdentifier_integrationIdentifier_CustomerProfiles = new Amazon.ConnectCampaignsV2.Model.CustomerProfilesIntegrationIdentifier();
            System.String requestIntegrationIdentifier_integrationIdentifier_CustomerProfiles_customerProfiles_DomainArn = null;
            if (cmdletContext.CustomerProfiles_DomainArn != null)
            {
                requestIntegrationIdentifier_integrationIdentifier_CustomerProfiles_customerProfiles_DomainArn = cmdletContext.CustomerProfiles_DomainArn;
            }
            if (requestIntegrationIdentifier_integrationIdentifier_CustomerProfiles_customerProfiles_DomainArn != null)
            {
                requestIntegrationIdentifier_integrationIdentifier_CustomerProfiles.DomainArn = requestIntegrationIdentifier_integrationIdentifier_CustomerProfiles_customerProfiles_DomainArn;
                requestIntegrationIdentifier_integrationIdentifier_CustomerProfilesIsNull = false;
            }
             // determine if requestIntegrationIdentifier_integrationIdentifier_CustomerProfiles should be set to null
            if (requestIntegrationIdentifier_integrationIdentifier_CustomerProfilesIsNull)
            {
                requestIntegrationIdentifier_integrationIdentifier_CustomerProfiles = null;
            }
            if (requestIntegrationIdentifier_integrationIdentifier_CustomerProfiles != null)
            {
                request.IntegrationIdentifier.CustomerProfiles = requestIntegrationIdentifier_integrationIdentifier_CustomerProfiles;
                requestIntegrationIdentifierIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.QConnectIntegrationIdentifier requestIntegrationIdentifier_integrationIdentifier_QConnect = null;
            
             // populate QConnect
            var requestIntegrationIdentifier_integrationIdentifier_QConnectIsNull = true;
            requestIntegrationIdentifier_integrationIdentifier_QConnect = new Amazon.ConnectCampaignsV2.Model.QConnectIntegrationIdentifier();
            System.String requestIntegrationIdentifier_integrationIdentifier_QConnect_qConnect_KnowledgeBaseArn = null;
            if (cmdletContext.QConnect_KnowledgeBaseArn != null)
            {
                requestIntegrationIdentifier_integrationIdentifier_QConnect_qConnect_KnowledgeBaseArn = cmdletContext.QConnect_KnowledgeBaseArn;
            }
            if (requestIntegrationIdentifier_integrationIdentifier_QConnect_qConnect_KnowledgeBaseArn != null)
            {
                requestIntegrationIdentifier_integrationIdentifier_QConnect.KnowledgeBaseArn = requestIntegrationIdentifier_integrationIdentifier_QConnect_qConnect_KnowledgeBaseArn;
                requestIntegrationIdentifier_integrationIdentifier_QConnectIsNull = false;
            }
             // determine if requestIntegrationIdentifier_integrationIdentifier_QConnect should be set to null
            if (requestIntegrationIdentifier_integrationIdentifier_QConnectIsNull)
            {
                requestIntegrationIdentifier_integrationIdentifier_QConnect = null;
            }
            if (requestIntegrationIdentifier_integrationIdentifier_QConnect != null)
            {
                request.IntegrationIdentifier.QConnect = requestIntegrationIdentifier_integrationIdentifier_QConnect;
                requestIntegrationIdentifierIsNull = false;
            }
             // determine if request.IntegrationIdentifier should be set to null
            if (requestIntegrationIdentifierIsNull)
            {
                request.IntegrationIdentifier = null;
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
        
        private Amazon.ConnectCampaignsV2.Model.DeleteConnectInstanceIntegrationResponse CallAWSServiceOperation(IAmazonConnectCampaignsV2 client, Amazon.ConnectCampaignsV2.Model.DeleteConnectInstanceIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonConnectCampaignServiceV2", "DeleteConnectInstanceIntegration");
            try
            {
                return client.DeleteConnectInstanceIntegrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectInstanceId { get; set; }
            public System.String CustomerProfiles_DomainArn { get; set; }
            public System.String QConnect_KnowledgeBaseArn { get; set; }
            public System.Func<Amazon.ConnectCampaignsV2.Model.DeleteConnectInstanceIntegrationResponse, RemoveCCS2ConnectInstanceIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

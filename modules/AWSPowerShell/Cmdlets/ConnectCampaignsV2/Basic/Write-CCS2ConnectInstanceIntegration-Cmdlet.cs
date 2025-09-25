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
using Amazon.ConnectCampaignsV2;
using Amazon.ConnectCampaignsV2.Model;

namespace Amazon.PowerShell.Cmdlets.CCS2
{
    /// <summary>
    /// Put or update the integration for the specified Amazon Connect instance.
    /// </summary>
    [Cmdlet("Write", "CCS2ConnectInstanceIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AmazonConnectCampaignServiceV2 PutConnectInstanceIntegration API operation.", Operation = new[] {"PutConnectInstanceIntegration"}, SelectReturnType = typeof(Amazon.ConnectCampaignsV2.Model.PutConnectInstanceIntegrationResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectCampaignsV2.Model.PutConnectInstanceIntegrationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectCampaignsV2.Model.PutConnectInstanceIntegrationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCCS2ConnectInstanceIntegrationCmdlet : AmazonConnectCampaignsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        [Alias("IntegrationConfig_CustomerProfiles_DomainArn")]
        public System.String CustomerProfiles_DomainArn { get; set; }
        #endregion
        
        #region Parameter QConnect_KnowledgeBaseArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_QConnect_KnowledgeBaseArn")]
        public System.String QConnect_KnowledgeBaseArn { get; set; }
        #endregion
        
        #region Parameter CustomerProfiles_ObjectTypeName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_CustomerProfiles_ObjectTypeNames")]
        public System.Collections.Hashtable CustomerProfiles_ObjectTypeName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCampaignsV2.Model.PutConnectInstanceIntegrationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectInstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectInstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectInstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectInstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CCS2ConnectInstanceIntegration (PutConnectInstanceIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCampaignsV2.Model.PutConnectInstanceIntegrationResponse, WriteCCS2ConnectInstanceIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectInstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConnectInstanceId = this.ConnectInstanceId;
            #if MODULAR
            if (this.ConnectInstanceId == null && ParameterWasBound(nameof(this.ConnectInstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectInstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomerProfiles_DomainArn = this.CustomerProfiles_DomainArn;
            if (this.CustomerProfiles_ObjectTypeName != null)
            {
                context.CustomerProfiles_ObjectTypeName = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomerProfiles_ObjectTypeName.Keys)
                {
                    context.CustomerProfiles_ObjectTypeName.Add((String)hashKey, (System.String)(this.CustomerProfiles_ObjectTypeName[hashKey]));
                }
            }
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
            var request = new Amazon.ConnectCampaignsV2.Model.PutConnectInstanceIntegrationRequest();
            
            if (cmdletContext.ConnectInstanceId != null)
            {
                request.ConnectInstanceId = cmdletContext.ConnectInstanceId;
            }
            
             // populate IntegrationConfig
            var requestIntegrationConfigIsNull = true;
            request.IntegrationConfig = new Amazon.ConnectCampaignsV2.Model.IntegrationConfig();
            Amazon.ConnectCampaignsV2.Model.QConnectIntegrationConfig requestIntegrationConfig_integrationConfig_QConnect = null;
            
             // populate QConnect
            var requestIntegrationConfig_integrationConfig_QConnectIsNull = true;
            requestIntegrationConfig_integrationConfig_QConnect = new Amazon.ConnectCampaignsV2.Model.QConnectIntegrationConfig();
            System.String requestIntegrationConfig_integrationConfig_QConnect_qConnect_KnowledgeBaseArn = null;
            if (cmdletContext.QConnect_KnowledgeBaseArn != null)
            {
                requestIntegrationConfig_integrationConfig_QConnect_qConnect_KnowledgeBaseArn = cmdletContext.QConnect_KnowledgeBaseArn;
            }
            if (requestIntegrationConfig_integrationConfig_QConnect_qConnect_KnowledgeBaseArn != null)
            {
                requestIntegrationConfig_integrationConfig_QConnect.KnowledgeBaseArn = requestIntegrationConfig_integrationConfig_QConnect_qConnect_KnowledgeBaseArn;
                requestIntegrationConfig_integrationConfig_QConnectIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_QConnect should be set to null
            if (requestIntegrationConfig_integrationConfig_QConnectIsNull)
            {
                requestIntegrationConfig_integrationConfig_QConnect = null;
            }
            if (requestIntegrationConfig_integrationConfig_QConnect != null)
            {
                request.IntegrationConfig.QConnect = requestIntegrationConfig_integrationConfig_QConnect;
                requestIntegrationConfigIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.CustomerProfilesIntegrationConfig requestIntegrationConfig_integrationConfig_CustomerProfiles = null;
            
             // populate CustomerProfiles
            var requestIntegrationConfig_integrationConfig_CustomerProfilesIsNull = true;
            requestIntegrationConfig_integrationConfig_CustomerProfiles = new Amazon.ConnectCampaignsV2.Model.CustomerProfilesIntegrationConfig();
            System.String requestIntegrationConfig_integrationConfig_CustomerProfiles_customerProfiles_DomainArn = null;
            if (cmdletContext.CustomerProfiles_DomainArn != null)
            {
                requestIntegrationConfig_integrationConfig_CustomerProfiles_customerProfiles_DomainArn = cmdletContext.CustomerProfiles_DomainArn;
            }
            if (requestIntegrationConfig_integrationConfig_CustomerProfiles_customerProfiles_DomainArn != null)
            {
                requestIntegrationConfig_integrationConfig_CustomerProfiles.DomainArn = requestIntegrationConfig_integrationConfig_CustomerProfiles_customerProfiles_DomainArn;
                requestIntegrationConfig_integrationConfig_CustomerProfilesIsNull = false;
            }
            Dictionary<System.String, System.String> requestIntegrationConfig_integrationConfig_CustomerProfiles_customerProfiles_ObjectTypeName = null;
            if (cmdletContext.CustomerProfiles_ObjectTypeName != null)
            {
                requestIntegrationConfig_integrationConfig_CustomerProfiles_customerProfiles_ObjectTypeName = cmdletContext.CustomerProfiles_ObjectTypeName;
            }
            if (requestIntegrationConfig_integrationConfig_CustomerProfiles_customerProfiles_ObjectTypeName != null)
            {
                requestIntegrationConfig_integrationConfig_CustomerProfiles.ObjectTypeNames = requestIntegrationConfig_integrationConfig_CustomerProfiles_customerProfiles_ObjectTypeName;
                requestIntegrationConfig_integrationConfig_CustomerProfilesIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_CustomerProfiles should be set to null
            if (requestIntegrationConfig_integrationConfig_CustomerProfilesIsNull)
            {
                requestIntegrationConfig_integrationConfig_CustomerProfiles = null;
            }
            if (requestIntegrationConfig_integrationConfig_CustomerProfiles != null)
            {
                request.IntegrationConfig.CustomerProfiles = requestIntegrationConfig_integrationConfig_CustomerProfiles;
                requestIntegrationConfigIsNull = false;
            }
             // determine if request.IntegrationConfig should be set to null
            if (requestIntegrationConfigIsNull)
            {
                request.IntegrationConfig = null;
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
        
        private Amazon.ConnectCampaignsV2.Model.PutConnectInstanceIntegrationResponse CallAWSServiceOperation(IAmazonConnectCampaignsV2 client, Amazon.ConnectCampaignsV2.Model.PutConnectInstanceIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonConnectCampaignServiceV2", "PutConnectInstanceIntegration");
            try
            {
                #if DESKTOP
                return client.PutConnectInstanceIntegration(request);
                #elif CORECLR
                return client.PutConnectInstanceIntegrationAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectInstanceId { get; set; }
            public System.String CustomerProfiles_DomainArn { get; set; }
            public Dictionary<System.String, System.String> CustomerProfiles_ObjectTypeName { get; set; }
            public System.String QConnect_KnowledgeBaseArn { get; set; }
            public System.Func<Amazon.ConnectCampaignsV2.Model.PutConnectInstanceIntegrationResponse, WriteCCS2ConnectInstanceIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

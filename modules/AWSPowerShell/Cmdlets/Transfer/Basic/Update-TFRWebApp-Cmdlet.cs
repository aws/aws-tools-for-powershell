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
using Amazon.Transfer;
using Amazon.Transfer.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Assigns new properties to a web app. You can modify the access point, identity provider
    /// details, and the web app units.
    /// </summary>
    [Cmdlet("Update", "TFRWebApp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP UpdateWebApp API operation.", Operation = new[] {"UpdateWebApp"}, SelectReturnType = typeof(Amazon.Transfer.Model.UpdateWebAppResponse))]
    [AWSCmdletOutput("System.String or Amazon.Transfer.Model.UpdateWebAppResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Transfer.Model.UpdateWebAppResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateTFRWebAppCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessEndpoint
        /// <summary>
        /// <para>
        /// <para>The <c>AccessEndpoint</c> is the URL that you provide to your users for them to interact
        /// with the Transfer Family web app. You can specify a custom URL or use the default
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessEndpoint { get; set; }
        #endregion
        
        #region Parameter WebAppUnits_Provisioned
        /// <summary>
        /// <para>
        /// <para>An integer that represents the number of units for your desired number of concurrent
        /// connections, or the number of user sessions on your web app at the same time.</para><para>Each increment allows an additional 250 concurrent sessions: a value of <c>1</c> sets
        /// the number of concurrent sessions to 250; <c>2</c> sets a value of 500, and so on.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? WebAppUnits_Provisioned { get; set; }
        #endregion
        
        #region Parameter IdentityCenterConfig_Role
        /// <summary>
        /// <para>
        /// <para>The IAM role used to access IAM Identity Center.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProviderDetails_IdentityCenterConfig_Role")]
        public System.String IdentityCenterConfig_Role { get; set; }
        #endregion
        
        #region Parameter WebAppId
        /// <summary>
        /// <para>
        /// <para>Provide the identifier of the web app that you are updating.</para>
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
        public System.String WebAppId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WebAppId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.UpdateWebAppResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.UpdateWebAppResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WebAppId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WebAppId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TFRWebApp (UpdateWebApp)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.UpdateWebAppResponse, UpdateTFRWebAppCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessEndpoint = this.AccessEndpoint;
            context.IdentityCenterConfig_Role = this.IdentityCenterConfig_Role;
            context.WebAppId = this.WebAppId;
            #if MODULAR
            if (this.WebAppId == null && ParameterWasBound(nameof(this.WebAppId)))
            {
                WriteWarning("You are passing $null as a value for parameter WebAppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WebAppUnits_Provisioned = this.WebAppUnits_Provisioned;
            
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
            var request = new Amazon.Transfer.Model.UpdateWebAppRequest();
            
            if (cmdletContext.AccessEndpoint != null)
            {
                request.AccessEndpoint = cmdletContext.AccessEndpoint;
            }
            
             // populate IdentityProviderDetails
            var requestIdentityProviderDetailsIsNull = true;
            request.IdentityProviderDetails = new Amazon.Transfer.Model.UpdateWebAppIdentityProviderDetails();
            Amazon.Transfer.Model.UpdateWebAppIdentityCenterConfig requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfig = null;
            
             // populate IdentityCenterConfig
            var requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfigIsNull = true;
            requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfig = new Amazon.Transfer.Model.UpdateWebAppIdentityCenterConfig();
            System.String requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfig_identityCenterConfig_Role = null;
            if (cmdletContext.IdentityCenterConfig_Role != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfig_identityCenterConfig_Role = cmdletContext.IdentityCenterConfig_Role;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfig_identityCenterConfig_Role != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfig.Role = requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfig_identityCenterConfig_Role;
                requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfigIsNull = false;
            }
             // determine if requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfig should be set to null
            if (requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfigIsNull)
            {
                requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfig = null;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfig != null)
            {
                request.IdentityProviderDetails.IdentityCenterConfig = requestIdentityProviderDetails_identityProviderDetails_IdentityCenterConfig;
                requestIdentityProviderDetailsIsNull = false;
            }
             // determine if request.IdentityProviderDetails should be set to null
            if (requestIdentityProviderDetailsIsNull)
            {
                request.IdentityProviderDetails = null;
            }
            if (cmdletContext.WebAppId != null)
            {
                request.WebAppId = cmdletContext.WebAppId;
            }
            
             // populate WebAppUnits
            var requestWebAppUnitsIsNull = true;
            request.WebAppUnits = new Amazon.Transfer.Model.WebAppUnits();
            System.Int32? requestWebAppUnits_webAppUnits_Provisioned = null;
            if (cmdletContext.WebAppUnits_Provisioned != null)
            {
                requestWebAppUnits_webAppUnits_Provisioned = cmdletContext.WebAppUnits_Provisioned.Value;
            }
            if (requestWebAppUnits_webAppUnits_Provisioned != null)
            {
                request.WebAppUnits.Provisioned = requestWebAppUnits_webAppUnits_Provisioned.Value;
                requestWebAppUnitsIsNull = false;
            }
             // determine if request.WebAppUnits should be set to null
            if (requestWebAppUnitsIsNull)
            {
                request.WebAppUnits = null;
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
        
        private Amazon.Transfer.Model.UpdateWebAppResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.UpdateWebAppRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "UpdateWebApp");
            try
            {
                return client.UpdateWebAppAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccessEndpoint { get; set; }
            public System.String IdentityCenterConfig_Role { get; set; }
            public System.String WebAppId { get; set; }
            public System.Int32? WebAppUnits_Provisioned { get; set; }
            public System.Func<Amazon.Transfer.Model.UpdateWebAppResponse, UpdateTFRWebAppCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WebAppId;
        }
        
    }
}

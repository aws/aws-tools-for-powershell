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
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APPC
{
    /// <summary>
    /// Updates the value of the <c>DeletionProtection</c> parameter.
    /// </summary>
    [Cmdlet("Update", "APPCAccountSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppConfig.Model.DeletionProtectionSettings")]
    [AWSCmdlet("Calls the AWS AppConfig UpdateAccountSettings API operation.", Operation = new[] {"UpdateAccountSettings"}, SelectReturnType = typeof(Amazon.AppConfig.Model.UpdateAccountSettingsResponse))]
    [AWSCmdletOutput("Amazon.AppConfig.Model.DeletionProtectionSettings or Amazon.AppConfig.Model.UpdateAccountSettingsResponse",
        "This cmdlet returns an Amazon.AppConfig.Model.DeletionProtectionSettings object.",
        "The service call response (type Amazon.AppConfig.Model.UpdateAccountSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAPPCAccountSettingCmdlet : AmazonAppConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeletionProtection_Enabled
        /// <summary>
        /// <para>
        /// <para>A parameter that indicates if deletion protection is enabled or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection_Enabled { get; set; }
        #endregion
        
        #region Parameter DeletionProtection_ProtectionPeriodInMinute
        /// <summary>
        /// <para>
        /// <para>The time interval during which AppConfig monitors for calls to <a href="https://docs.aws.amazon.com/appconfig/2019-10-09/APIReference/API_appconfigdata_GetLatestConfiguration.html">GetLatestConfiguration</a>
        /// or for a configuration profile or from an environment. AppConfig returns an error
        /// if a user calls or for the designated configuration profile or environment. To bypass
        /// the error and delete a configuration profile or an environment, specify <c>BYPASS</c>
        /// for the <c>DeletionProtectionCheck</c> parameter for either or .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeletionProtection_ProtectionPeriodInMinutes")]
        public System.Int32? DeletionProtection_ProtectionPeriodInMinute { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeletionProtection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.UpdateAccountSettingsResponse).
        /// Specifying the name of a property of type Amazon.AppConfig.Model.UpdateAccountSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeletionProtection";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APPCAccountSetting (UpdateAccountSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.UpdateAccountSettingsResponse, UpdateAPPCAccountSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeletionProtection_Enabled = this.DeletionProtection_Enabled;
            context.DeletionProtection_ProtectionPeriodInMinute = this.DeletionProtection_ProtectionPeriodInMinute;
            
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
            var request = new Amazon.AppConfig.Model.UpdateAccountSettingsRequest();
            
            
             // populate DeletionProtection
            var requestDeletionProtectionIsNull = true;
            request.DeletionProtection = new Amazon.AppConfig.Model.DeletionProtectionSettings();
            System.Boolean? requestDeletionProtection_deletionProtection_Enabled = null;
            if (cmdletContext.DeletionProtection_Enabled != null)
            {
                requestDeletionProtection_deletionProtection_Enabled = cmdletContext.DeletionProtection_Enabled.Value;
            }
            if (requestDeletionProtection_deletionProtection_Enabled != null)
            {
                request.DeletionProtection.Enabled = requestDeletionProtection_deletionProtection_Enabled.Value;
                requestDeletionProtectionIsNull = false;
            }
            System.Int32? requestDeletionProtection_deletionProtection_ProtectionPeriodInMinute = null;
            if (cmdletContext.DeletionProtection_ProtectionPeriodInMinute != null)
            {
                requestDeletionProtection_deletionProtection_ProtectionPeriodInMinute = cmdletContext.DeletionProtection_ProtectionPeriodInMinute.Value;
            }
            if (requestDeletionProtection_deletionProtection_ProtectionPeriodInMinute != null)
            {
                request.DeletionProtection.ProtectionPeriodInMinutes = requestDeletionProtection_deletionProtection_ProtectionPeriodInMinute.Value;
                requestDeletionProtectionIsNull = false;
            }
             // determine if request.DeletionProtection should be set to null
            if (requestDeletionProtectionIsNull)
            {
                request.DeletionProtection = null;
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
        
        private Amazon.AppConfig.Model.UpdateAccountSettingsResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.UpdateAccountSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "UpdateAccountSettings");
            try
            {
                return client.UpdateAccountSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DeletionProtection_Enabled { get; set; }
            public System.Int32? DeletionProtection_ProtectionPeriodInMinute { get; set; }
            public System.Func<Amazon.AppConfig.Model.UpdateAccountSettingsResponse, UpdateAPPCAccountSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeletionProtection;
        }
        
    }
}

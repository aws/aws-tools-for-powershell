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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Updates License Manager settings for the current Region.
    /// </summary>
    [Cmdlet("Update", "LICMServiceSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS License Manager UpdateServiceSettings API operation.", Operation = new[] {"UpdateServiceSettings"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.UpdateServiceSettingsResponse))]
    [AWSCmdletOutput("None or Amazon.LicenseManager.Model.UpdateServiceSettingsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.LicenseManager.Model.UpdateServiceSettingsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLICMServiceSettingCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        #region Parameter EnableCrossAccountsDiscovery
        /// <summary>
        /// <para>
        /// <para>Activates cross-account discovery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableCrossAccountsDiscovery { get; set; }
        #endregion
        
        #region Parameter OrganizationConfiguration_EnableIntegration
        /// <summary>
        /// <para>
        /// <para>Enables Organizations integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OrganizationConfiguration_EnableIntegration { get; set; }
        #endregion
        
        #region Parameter S3BucketArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the Amazon S3 bucket where the License Manager information
        /// is stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3BucketArn { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the Amazon SNS topic used for License Manager alerts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.UpdateServiceSettingsResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LICMServiceSetting (UpdateServiceSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.UpdateServiceSettingsResponse, UpdateLICMServiceSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EnableCrossAccountsDiscovery = this.EnableCrossAccountsDiscovery;
            context.OrganizationConfiguration_EnableIntegration = this.OrganizationConfiguration_EnableIntegration;
            context.S3BucketArn = this.S3BucketArn;
            context.SnsTopicArn = this.SnsTopicArn;
            
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
            var request = new Amazon.LicenseManager.Model.UpdateServiceSettingsRequest();
            
            if (cmdletContext.EnableCrossAccountsDiscovery != null)
            {
                request.EnableCrossAccountsDiscovery = cmdletContext.EnableCrossAccountsDiscovery.Value;
            }
            
             // populate OrganizationConfiguration
            var requestOrganizationConfigurationIsNull = true;
            request.OrganizationConfiguration = new Amazon.LicenseManager.Model.OrganizationConfiguration();
            System.Boolean? requestOrganizationConfiguration_organizationConfiguration_EnableIntegration = null;
            if (cmdletContext.OrganizationConfiguration_EnableIntegration != null)
            {
                requestOrganizationConfiguration_organizationConfiguration_EnableIntegration = cmdletContext.OrganizationConfiguration_EnableIntegration.Value;
            }
            if (requestOrganizationConfiguration_organizationConfiguration_EnableIntegration != null)
            {
                request.OrganizationConfiguration.EnableIntegration = requestOrganizationConfiguration_organizationConfiguration_EnableIntegration.Value;
                requestOrganizationConfigurationIsNull = false;
            }
             // determine if request.OrganizationConfiguration should be set to null
            if (requestOrganizationConfigurationIsNull)
            {
                request.OrganizationConfiguration = null;
            }
            if (cmdletContext.S3BucketArn != null)
            {
                request.S3BucketArn = cmdletContext.S3BucketArn;
            }
            if (cmdletContext.SnsTopicArn != null)
            {
                request.SnsTopicArn = cmdletContext.SnsTopicArn;
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
        
        private Amazon.LicenseManager.Model.UpdateServiceSettingsResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.UpdateServiceSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "UpdateServiceSettings");
            try
            {
                #if DESKTOP
                return client.UpdateServiceSettings(request);
                #elif CORECLR
                return client.UpdateServiceSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? EnableCrossAccountsDiscovery { get; set; }
            public System.Boolean? OrganizationConfiguration_EnableIntegration { get; set; }
            public System.String S3BucketArn { get; set; }
            public System.String SnsTopicArn { get; set; }
            public System.Func<Amazon.LicenseManager.Model.UpdateServiceSettingsResponse, UpdateLICMServiceSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

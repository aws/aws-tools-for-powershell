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
using Amazon.LicenseManagerLinuxSubscriptions;
using Amazon.LicenseManagerLinuxSubscriptions.Model;

namespace Amazon.PowerShell.Cmdlets.LLMS
{
    /// <summary>
    /// Lists the Linux subscriptions service settings for your account.
    /// </summary>
    [Cmdlet("Get", "LLMSServiceSetting")]
    [OutputType("Amazon.LicenseManagerLinuxSubscriptions.Model.GetServiceSettingsResponse")]
    [AWSCmdlet("Calls the AWS License Manager - Linux Subscriptions GetServiceSettings API operation.", Operation = new[] {"GetServiceSettings"}, SelectReturnType = typeof(Amazon.LicenseManagerLinuxSubscriptions.Model.GetServiceSettingsResponse))]
    [AWSCmdletOutput("Amazon.LicenseManagerLinuxSubscriptions.Model.GetServiceSettingsResponse",
        "This cmdlet returns an Amazon.LicenseManagerLinuxSubscriptions.Model.GetServiceSettingsResponse object containing multiple properties."
    )]
    public partial class GetLLMSServiceSettingCmdlet : AmazonLicenseManagerLinuxSubscriptionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManagerLinuxSubscriptions.Model.GetServiceSettingsResponse).
        /// Specifying the name of a property of type Amazon.LicenseManagerLinuxSubscriptions.Model.GetServiceSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManagerLinuxSubscriptions.Model.GetServiceSettingsResponse, GetLLMSServiceSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.LicenseManagerLinuxSubscriptions.Model.GetServiceSettingsRequest();
            
            
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
        
        private Amazon.LicenseManagerLinuxSubscriptions.Model.GetServiceSettingsResponse CallAWSServiceOperation(IAmazonLicenseManagerLinuxSubscriptions client, Amazon.LicenseManagerLinuxSubscriptions.Model.GetServiceSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager - Linux Subscriptions", "GetServiceSettings");
            try
            {
                #if DESKTOP
                return client.GetServiceSettings(request);
                #elif CORECLR
                return client.GetServiceSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.LicenseManagerLinuxSubscriptions.Model.GetServiceSettingsResponse, GetLLMSServiceSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

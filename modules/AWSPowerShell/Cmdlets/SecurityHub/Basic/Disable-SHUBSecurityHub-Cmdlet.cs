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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Disables Security Hub in your account only in the current Amazon Web Services Region.
    /// To disable Security Hub in all Regions, you must submit one request per Region where
    /// you have enabled Security Hub.
    /// 
    ///  
    /// <para>
    /// You can't disable Security Hub in an account that is currently the Security Hub administrator.
    /// </para><para>
    /// When you disable Security Hub, your existing findings and insights and any Security
    /// Hub configuration settings are deleted after 90 days and cannot be recovered. Any
    /// standards that were enabled are disabled, and your administrator and member account
    /// associations are removed.
    /// </para><para>
    /// If you want to save your existing findings, you must export them before you disable
    /// Security Hub.
    /// </para>
    /// </summary>
    [Cmdlet("Disable", "SHUBSecurityHub", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Security Hub DisableSecurityHub API operation.", Operation = new[] {"DisableSecurityHub"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.DisableSecurityHubResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityHub.Model.DisableSecurityHubResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityHub.Model.DisableSecurityHubResponse) be returned by specifying '-Select *'."
    )]
    public partial class DisableSHUBSecurityHubCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.DisableSecurityHubResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-SHUBSecurityHub (DisableSecurityHub)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.DisableSecurityHubResponse, DisableSHUBSecurityHubCmdlet>(Select) ??
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
            var request = new Amazon.SecurityHub.Model.DisableSecurityHubRequest();
            
            
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
        
        private Amazon.SecurityHub.Model.DisableSecurityHubResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.DisableSecurityHubRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "DisableSecurityHub");
            try
            {
                #if DESKTOP
                return client.DisableSecurityHub(request);
                #elif CORECLR
                return client.DisableSecurityHubAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SecurityHub.Model.DisableSecurityHubResponse, DisableSHUBSecurityHubCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

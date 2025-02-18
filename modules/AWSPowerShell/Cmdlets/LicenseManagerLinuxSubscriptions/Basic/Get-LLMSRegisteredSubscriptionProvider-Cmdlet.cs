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
using Amazon.LicenseManagerLinuxSubscriptions;
using Amazon.LicenseManagerLinuxSubscriptions.Model;

namespace Amazon.PowerShell.Cmdlets.LLMS
{
    /// <summary>
    /// Get details for a Bring Your Own License (BYOL) subscription that's registered to
    /// your account.
    /// </summary>
    [Cmdlet("Get", "LLMSRegisteredSubscriptionProvider")]
    [OutputType("Amazon.LicenseManagerLinuxSubscriptions.Model.GetRegisteredSubscriptionProviderResponse")]
    [AWSCmdlet("Calls the AWS License Manager - Linux Subscriptions GetRegisteredSubscriptionProvider API operation.", Operation = new[] {"GetRegisteredSubscriptionProvider"}, SelectReturnType = typeof(Amazon.LicenseManagerLinuxSubscriptions.Model.GetRegisteredSubscriptionProviderResponse))]
    [AWSCmdletOutput("Amazon.LicenseManagerLinuxSubscriptions.Model.GetRegisteredSubscriptionProviderResponse",
        "This cmdlet returns an Amazon.LicenseManagerLinuxSubscriptions.Model.GetRegisteredSubscriptionProviderResponse object containing multiple properties."
    )]
    public partial class GetLLMSRegisteredSubscriptionProviderCmdlet : AmazonLicenseManagerLinuxSubscriptionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SubscriptionProviderArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the BYOL registration resource to get details for.</para>
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
        public System.String SubscriptionProviderArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManagerLinuxSubscriptions.Model.GetRegisteredSubscriptionProviderResponse).
        /// Specifying the name of a property of type Amazon.LicenseManagerLinuxSubscriptions.Model.GetRegisteredSubscriptionProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManagerLinuxSubscriptions.Model.GetRegisteredSubscriptionProviderResponse, GetLLMSRegisteredSubscriptionProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SubscriptionProviderArn = this.SubscriptionProviderArn;
            #if MODULAR
            if (this.SubscriptionProviderArn == null && ParameterWasBound(nameof(this.SubscriptionProviderArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionProviderArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LicenseManagerLinuxSubscriptions.Model.GetRegisteredSubscriptionProviderRequest();
            
            if (cmdletContext.SubscriptionProviderArn != null)
            {
                request.SubscriptionProviderArn = cmdletContext.SubscriptionProviderArn;
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
        
        private Amazon.LicenseManagerLinuxSubscriptions.Model.GetRegisteredSubscriptionProviderResponse CallAWSServiceOperation(IAmazonLicenseManagerLinuxSubscriptions client, Amazon.LicenseManagerLinuxSubscriptions.Model.GetRegisteredSubscriptionProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager - Linux Subscriptions", "GetRegisteredSubscriptionProvider");
            try
            {
                return client.GetRegisteredSubscriptionProviderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SubscriptionProviderArn { get; set; }
            public System.Func<Amazon.LicenseManagerLinuxSubscriptions.Model.GetRegisteredSubscriptionProviderResponse, GetLLMSRegisteredSubscriptionProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

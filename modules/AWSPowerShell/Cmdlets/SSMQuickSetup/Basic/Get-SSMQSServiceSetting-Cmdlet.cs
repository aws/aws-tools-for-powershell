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
using Amazon.SSMQuickSetup;
using Amazon.SSMQuickSetup.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSMQS
{
    /// <summary>
    /// Returns settings configured for Quick Setup in the requesting Amazon Web Services
    /// account and Amazon Web Services Region.
    /// </summary>
    [Cmdlet("Get", "SSMQSServiceSetting")]
    [OutputType("Amazon.SSMQuickSetup.Model.ServiceSettings")]
    [AWSCmdlet("Calls the AWS Systems Manager QuickSetup GetServiceSettings API operation.", Operation = new[] {"GetServiceSettings"}, SelectReturnType = typeof(Amazon.SSMQuickSetup.Model.GetServiceSettingsResponse))]
    [AWSCmdletOutput("Amazon.SSMQuickSetup.Model.ServiceSettings or Amazon.SSMQuickSetup.Model.GetServiceSettingsResponse",
        "This cmdlet returns an Amazon.SSMQuickSetup.Model.ServiceSettings object.",
        "The service call response (type Amazon.SSMQuickSetup.Model.GetServiceSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSMQSServiceSettingCmdlet : AmazonSSMQuickSetupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceSettings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMQuickSetup.Model.GetServiceSettingsResponse).
        /// Specifying the name of a property of type Amazon.SSMQuickSetup.Model.GetServiceSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceSettings";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMQuickSetup.Model.GetServiceSettingsResponse, GetSSMQSServiceSettingCmdlet>(Select) ??
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
            var request = new Amazon.SSMQuickSetup.Model.GetServiceSettingsRequest();
            
            
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
        
        private Amazon.SSMQuickSetup.Model.GetServiceSettingsResponse CallAWSServiceOperation(IAmazonSSMQuickSetup client, Amazon.SSMQuickSetup.Model.GetServiceSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager QuickSetup", "GetServiceSettings");
            try
            {
                return client.GetServiceSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SSMQuickSetup.Model.GetServiceSettingsResponse, GetSSMQSServiceSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceSettings;
        }
        
    }
}

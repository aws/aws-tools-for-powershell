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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Gets the settings for a specified Amazon Web Services account.
    /// </summary>
    [Cmdlet("Get", "AUDMSetting")]
    [OutputType("Amazon.AuditManager.Model.Settings")]
    [AWSCmdlet("Calls the AWS Audit Manager GetSettings API operation.", Operation = new[] {"GetSettings"}, SelectReturnType = typeof(Amazon.AuditManager.Model.GetSettingsResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.Settings or Amazon.AuditManager.Model.GetSettingsResponse",
        "This cmdlet returns an Amazon.AuditManager.Model.Settings object.",
        "The service call response (type Amazon.AuditManager.Model.GetSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAUDMSettingCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para> The list of setting attribute enum values. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AuditManager.SettingAttribute")]
        public Amazon.AuditManager.SettingAttribute Attribute { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Settings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.GetSettingsResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.GetSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Settings";
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
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.GetSettingsResponse, GetAUDMSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Attribute = this.Attribute;
            #if MODULAR
            if (this.Attribute == null && ParameterWasBound(nameof(this.Attribute)))
            {
                WriteWarning("You are passing $null as a value for parameter Attribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AuditManager.Model.GetSettingsRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attribute = cmdletContext.Attribute;
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
        
        private Amazon.AuditManager.Model.GetSettingsResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.GetSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "GetSettings");
            try
            {
                return client.GetSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.AuditManager.SettingAttribute Attribute { get; set; }
            public System.Func<Amazon.AuditManager.Model.GetSettingsResponse, GetAUDMSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Settings;
        }
        
    }
}

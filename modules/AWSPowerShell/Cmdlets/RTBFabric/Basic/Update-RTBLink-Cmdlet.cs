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
using Amazon.RTBFabric;
using Amazon.RTBFabric.Model;

namespace Amazon.PowerShell.Cmdlets.RTB
{
    /// <summary>
    /// Updates the configuration of a link between gateways.
    /// 
    ///  
    /// <para>
    /// Allows you to modify settings and parameters for an existing link.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "RTBLink", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RTBFabric.Model.UpdateLinkResponse")]
    [AWSCmdlet("Calls the Amazon RTBFabric UpdateLink API operation.", Operation = new[] {"UpdateLink"}, SelectReturnType = typeof(Amazon.RTBFabric.Model.UpdateLinkResponse))]
    [AWSCmdletOutput("Amazon.RTBFabric.Model.UpdateLinkResponse",
        "This cmdlet returns an Amazon.RTBFabric.Model.UpdateLinkResponse object containing multiple properties."
    )]
    public partial class UpdateRTBLinkCmdlet : AmazonRTBFabricClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Sampling_ErrorLog
        /// <summary>
        /// <para>
        /// <para>An error log entry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogSettings_ApplicationLogs_Sampling_ErrorLog")]
        public System.Double? Sampling_ErrorLog { get; set; }
        #endregion
        
        #region Parameter Sampling_FilterLog
        /// <summary>
        /// <para>
        /// <para>A filter log entry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogSettings_ApplicationLogs_Sampling_FilterLog")]
        public System.Double? Sampling_FilterLog { get; set; }
        #endregion
        
        #region Parameter GatewayId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the gateway.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String GatewayId { get; set; }
        #endregion
        
        #region Parameter LinkId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the link.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LinkId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RTBFabric.Model.UpdateLinkResponse).
        /// Specifying the name of a property of type Amazon.RTBFabric.Model.UpdateLinkResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LinkId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RTBLink (UpdateLink)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RTBFabric.Model.UpdateLinkResponse, UpdateRTBLinkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GatewayId = this.GatewayId;
            #if MODULAR
            if (this.GatewayId == null && ParameterWasBound(nameof(this.GatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LinkId = this.LinkId;
            #if MODULAR
            if (this.LinkId == null && ParameterWasBound(nameof(this.LinkId)))
            {
                WriteWarning("You are passing $null as a value for parameter LinkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Sampling_ErrorLog = this.Sampling_ErrorLog;
            context.Sampling_FilterLog = this.Sampling_FilterLog;
            
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
            var request = new Amazon.RTBFabric.Model.UpdateLinkRequest();
            
            if (cmdletContext.GatewayId != null)
            {
                request.GatewayId = cmdletContext.GatewayId;
            }
            if (cmdletContext.LinkId != null)
            {
                request.LinkId = cmdletContext.LinkId;
            }
            
             // populate LogSettings
            var requestLogSettingsIsNull = true;
            request.LogSettings = new Amazon.RTBFabric.Model.LinkLogSettings();
            Amazon.RTBFabric.Model.LinkApplicationLogConfiguration requestLogSettings_logSettings_ApplicationLogs = null;
            
             // populate ApplicationLogs
            var requestLogSettings_logSettings_ApplicationLogsIsNull = true;
            requestLogSettings_logSettings_ApplicationLogs = new Amazon.RTBFabric.Model.LinkApplicationLogConfiguration();
            Amazon.RTBFabric.Model.LinkApplicationLogSampling requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling = null;
            
             // populate Sampling
            var requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_SamplingIsNull = true;
            requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling = new Amazon.RTBFabric.Model.LinkApplicationLogSampling();
            System.Double? requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_ErrorLog = null;
            if (cmdletContext.Sampling_ErrorLog != null)
            {
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_ErrorLog = cmdletContext.Sampling_ErrorLog.Value;
            }
            if (requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_ErrorLog != null)
            {
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling.ErrorLog = requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_ErrorLog.Value;
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_SamplingIsNull = false;
            }
            System.Double? requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_FilterLog = null;
            if (cmdletContext.Sampling_FilterLog != null)
            {
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_FilterLog = cmdletContext.Sampling_FilterLog.Value;
            }
            if (requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_FilterLog != null)
            {
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling.FilterLog = requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling_sampling_FilterLog.Value;
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_SamplingIsNull = false;
            }
             // determine if requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling should be set to null
            if (requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_SamplingIsNull)
            {
                requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling = null;
            }
            if (requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling != null)
            {
                requestLogSettings_logSettings_ApplicationLogs.Sampling = requestLogSettings_logSettings_ApplicationLogs_logSettings_ApplicationLogs_Sampling;
                requestLogSettings_logSettings_ApplicationLogsIsNull = false;
            }
             // determine if requestLogSettings_logSettings_ApplicationLogs should be set to null
            if (requestLogSettings_logSettings_ApplicationLogsIsNull)
            {
                requestLogSettings_logSettings_ApplicationLogs = null;
            }
            if (requestLogSettings_logSettings_ApplicationLogs != null)
            {
                request.LogSettings.ApplicationLogs = requestLogSettings_logSettings_ApplicationLogs;
                requestLogSettingsIsNull = false;
            }
             // determine if request.LogSettings should be set to null
            if (requestLogSettingsIsNull)
            {
                request.LogSettings = null;
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
        
        private Amazon.RTBFabric.Model.UpdateLinkResponse CallAWSServiceOperation(IAmazonRTBFabric client, Amazon.RTBFabric.Model.UpdateLinkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon RTBFabric", "UpdateLink");
            try
            {
                #if DESKTOP
                return client.UpdateLink(request);
                #elif CORECLR
                return client.UpdateLinkAsync(request).GetAwaiter().GetResult();
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
            public System.String GatewayId { get; set; }
            public System.String LinkId { get; set; }
            public System.Double? Sampling_ErrorLog { get; set; }
            public System.Double? Sampling_FilterLog { get; set; }
            public System.Func<Amazon.RTBFabric.Model.UpdateLinkResponse, UpdateRTBLinkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

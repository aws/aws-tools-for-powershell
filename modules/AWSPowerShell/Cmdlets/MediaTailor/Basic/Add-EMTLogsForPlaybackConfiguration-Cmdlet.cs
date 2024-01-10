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
using Amazon.MediaTailor;
using Amazon.MediaTailor.Model;

namespace Amazon.PowerShell.Cmdlets.EMT
{
    /// <summary>
    /// Amazon CloudWatch log settings for a playback configuration.
    /// </summary>
    [Cmdlet("Add", "EMTLogsForPlaybackConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaTailor ConfigureLogsForPlaybackConfiguration API operation.", Operation = new[] {"ConfigureLogsForPlaybackConfiguration"}, SelectReturnType = typeof(Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse))]
    [AWSCmdletOutput("Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse",
        "This cmdlet returns an Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddEMTLogsForPlaybackConfigurationCmdlet : AmazonMediaTailorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PercentEnabled
        /// <summary>
        /// <para>
        /// <para>The percentage of session logs that MediaTailor sends to your Cloudwatch Logs account.
        /// For example, if your playback configuration has 1000 sessions and percentEnabled is
        /// set to <c>60</c>, MediaTailor sends logs for 600 of the sessions to CloudWatch Logs.
        /// MediaTailor decides at random which of the playback configuration sessions to send
        /// logs for. If you want to view logs for a specific session, you can use the <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/debug-log-mode.html">debug
        /// log mode</a>.</para><para>Valid values: <c>0</c> - <c>100</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? PercentEnabled { get; set; }
        #endregion
        
        #region Parameter PlaybackConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the playback configuration.</para>
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
        public System.String PlaybackConfigurationName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse).
        /// Specifying the name of a property of type Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PlaybackConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-EMTLogsForPlaybackConfiguration (ConfigureLogsForPlaybackConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse, AddEMTLogsForPlaybackConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PercentEnabled = this.PercentEnabled;
            #if MODULAR
            if (this.PercentEnabled == null && ParameterWasBound(nameof(this.PercentEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter PercentEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlaybackConfigurationName = this.PlaybackConfigurationName;
            #if MODULAR
            if (this.PlaybackConfigurationName == null && ParameterWasBound(nameof(this.PlaybackConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter PlaybackConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationRequest();
            
            if (cmdletContext.PercentEnabled != null)
            {
                request.PercentEnabled = cmdletContext.PercentEnabled.Value;
            }
            if (cmdletContext.PlaybackConfigurationName != null)
            {
                request.PlaybackConfigurationName = cmdletContext.PlaybackConfigurationName;
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
        
        private Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse CallAWSServiceOperation(IAmazonMediaTailor client, Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaTailor", "ConfigureLogsForPlaybackConfiguration");
            try
            {
                #if DESKTOP
                return client.ConfigureLogsForPlaybackConfiguration(request);
                #elif CORECLR
                return client.ConfigureLogsForPlaybackConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? PercentEnabled { get; set; }
            public System.String PlaybackConfigurationName { get; set; }
            public System.Func<Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse, AddEMTLogsForPlaybackConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

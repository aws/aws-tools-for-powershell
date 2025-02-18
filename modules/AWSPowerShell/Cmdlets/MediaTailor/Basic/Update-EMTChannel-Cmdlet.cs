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
using Amazon.MediaTailor;
using Amazon.MediaTailor.Model;

namespace Amazon.PowerShell.Cmdlets.EMT
{
    /// <summary>
    /// Updates a channel. For information about MediaTailor channels, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/channel-assembly-channels.html">Working
    /// with channels</a> in the <i>MediaTailor User Guide</i>.
    /// </summary>
    [Cmdlet("Update", "EMTChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaTailor.Model.UpdateChannelResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaTailor UpdateChannel API operation.", Operation = new[] {"UpdateChannel"}, SelectReturnType = typeof(Amazon.MediaTailor.Model.UpdateChannelResponse))]
    [AWSCmdletOutput("Amazon.MediaTailor.Model.UpdateChannelResponse",
        "This cmdlet returns an Amazon.MediaTailor.Model.UpdateChannelResponse object containing multiple properties."
    )]
    public partial class UpdateEMTChannelCmdlet : AmazonMediaTailorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Audience
        /// <summary>
        /// <para>
        /// <para>The list of audiences defined in channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Audiences")]
        public System.String[] Audience { get; set; }
        #endregion
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the channel.</para>
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
        public System.String ChannelName { get; set; }
        #endregion
        
        #region Parameter TimeShiftConfiguration_MaxTimeDelaySecond
        /// <summary>
        /// <para>
        /// <para> The maximum time delay for time-shifted viewing. The minimum allowed maximum time
        /// delay is 0 seconds, and the maximum allowed maximum time delay is 21600 seconds (6
        /// hours). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeShiftConfiguration_MaxTimeDelaySeconds")]
        public System.Int32? TimeShiftConfiguration_MaxTimeDelaySecond { get; set; }
        #endregion
        
        #region Parameter Output
        /// <summary>
        /// <para>
        /// <para>The channel's output properties.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Outputs")]
        public Amazon.MediaTailor.Model.RequestOutputItem[] Output { get; set; }
        #endregion
        
        #region Parameter FillerSlate_SourceLocationName
        /// <summary>
        /// <para>
        /// <para>The name of the source location where the slate VOD source is stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FillerSlate_SourceLocationName { get; set; }
        #endregion
        
        #region Parameter FillerSlate_VodSourceName
        /// <summary>
        /// <para>
        /// <para>The slate VOD source name. The VOD source must already exist in a source location
        /// before it can be used for slate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FillerSlate_VodSourceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaTailor.Model.UpdateChannelResponse).
        /// Specifying the name of a property of type Amazon.MediaTailor.Model.UpdateChannelResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMTChannel (UpdateChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaTailor.Model.UpdateChannelResponse, UpdateEMTChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Audience != null)
            {
                context.Audience = new List<System.String>(this.Audience);
            }
            context.ChannelName = this.ChannelName;
            #if MODULAR
            if (this.ChannelName == null && ParameterWasBound(nameof(this.ChannelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FillerSlate_SourceLocationName = this.FillerSlate_SourceLocationName;
            context.FillerSlate_VodSourceName = this.FillerSlate_VodSourceName;
            if (this.Output != null)
            {
                context.Output = new List<Amazon.MediaTailor.Model.RequestOutputItem>(this.Output);
            }
            #if MODULAR
            if (this.Output == null && ParameterWasBound(nameof(this.Output)))
            {
                WriteWarning("You are passing $null as a value for parameter Output which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeShiftConfiguration_MaxTimeDelaySecond = this.TimeShiftConfiguration_MaxTimeDelaySecond;
            
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
            var request = new Amazon.MediaTailor.Model.UpdateChannelRequest();
            
            if (cmdletContext.Audience != null)
            {
                request.Audiences = cmdletContext.Audience;
            }
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            
             // populate FillerSlate
            var requestFillerSlateIsNull = true;
            request.FillerSlate = new Amazon.MediaTailor.Model.SlateSource();
            System.String requestFillerSlate_fillerSlate_SourceLocationName = null;
            if (cmdletContext.FillerSlate_SourceLocationName != null)
            {
                requestFillerSlate_fillerSlate_SourceLocationName = cmdletContext.FillerSlate_SourceLocationName;
            }
            if (requestFillerSlate_fillerSlate_SourceLocationName != null)
            {
                request.FillerSlate.SourceLocationName = requestFillerSlate_fillerSlate_SourceLocationName;
                requestFillerSlateIsNull = false;
            }
            System.String requestFillerSlate_fillerSlate_VodSourceName = null;
            if (cmdletContext.FillerSlate_VodSourceName != null)
            {
                requestFillerSlate_fillerSlate_VodSourceName = cmdletContext.FillerSlate_VodSourceName;
            }
            if (requestFillerSlate_fillerSlate_VodSourceName != null)
            {
                request.FillerSlate.VodSourceName = requestFillerSlate_fillerSlate_VodSourceName;
                requestFillerSlateIsNull = false;
            }
             // determine if request.FillerSlate should be set to null
            if (requestFillerSlateIsNull)
            {
                request.FillerSlate = null;
            }
            if (cmdletContext.Output != null)
            {
                request.Outputs = cmdletContext.Output;
            }
            
             // populate TimeShiftConfiguration
            var requestTimeShiftConfigurationIsNull = true;
            request.TimeShiftConfiguration = new Amazon.MediaTailor.Model.TimeShiftConfiguration();
            System.Int32? requestTimeShiftConfiguration_timeShiftConfiguration_MaxTimeDelaySecond = null;
            if (cmdletContext.TimeShiftConfiguration_MaxTimeDelaySecond != null)
            {
                requestTimeShiftConfiguration_timeShiftConfiguration_MaxTimeDelaySecond = cmdletContext.TimeShiftConfiguration_MaxTimeDelaySecond.Value;
            }
            if (requestTimeShiftConfiguration_timeShiftConfiguration_MaxTimeDelaySecond != null)
            {
                request.TimeShiftConfiguration.MaxTimeDelaySeconds = requestTimeShiftConfiguration_timeShiftConfiguration_MaxTimeDelaySecond.Value;
                requestTimeShiftConfigurationIsNull = false;
            }
             // determine if request.TimeShiftConfiguration should be set to null
            if (requestTimeShiftConfigurationIsNull)
            {
                request.TimeShiftConfiguration = null;
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
        
        private Amazon.MediaTailor.Model.UpdateChannelResponse CallAWSServiceOperation(IAmazonMediaTailor client, Amazon.MediaTailor.Model.UpdateChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaTailor", "UpdateChannel");
            try
            {
                return client.UpdateChannelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Audience { get; set; }
            public System.String ChannelName { get; set; }
            public System.String FillerSlate_SourceLocationName { get; set; }
            public System.String FillerSlate_VodSourceName { get; set; }
            public List<Amazon.MediaTailor.Model.RequestOutputItem> Output { get; set; }
            public System.Int32? TimeShiftConfiguration_MaxTimeDelaySecond { get; set; }
            public System.Func<Amazon.MediaTailor.Model.UpdateChannelResponse, UpdateEMTChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

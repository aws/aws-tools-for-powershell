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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Changes the class of the channel.
    /// </summary>
    [Cmdlet("Update", "EMLChannelClass", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.Channel")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive UpdateChannelClass API operation.", Operation = new[] {"UpdateChannelClass"}, SelectReturnType = typeof(Amazon.MediaLive.Model.UpdateChannelClassResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.Channel or Amazon.MediaLive.Model.UpdateChannelClassResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.Channel object.",
        "The service call response (type Amazon.MediaLive.Model.UpdateChannelClassResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEMLChannelClassCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChannelClass
        /// <summary>
        /// <para>
        /// The channel class that you wish to update
        /// this channel to use.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MediaLive.ChannelClass")]
        public Amazon.MediaLive.ChannelClass ChannelClass { get; set; }
        #endregion
        
        #region Parameter ChannelId
        /// <summary>
        /// <para>
        /// Channel Id of the channel whose class should
        /// be updated.
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
        public System.String ChannelId { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// A list of output destinations for this channel.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destinations")]
        public Amazon.MediaLive.Model.OutputDestination[] Destination { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Channel'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.UpdateChannelClassResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.UpdateChannelClassResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Channel";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMLChannelClass (UpdateChannelClass)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.UpdateChannelClassResponse, UpdateEMLChannelClassCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelClass = this.ChannelClass;
            #if MODULAR
            if (this.ChannelClass == null && ParameterWasBound(nameof(this.ChannelClass)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelClass which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelId = this.ChannelId;
            #if MODULAR
            if (this.ChannelId == null && ParameterWasBound(nameof(this.ChannelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Destination != null)
            {
                context.Destination = new List<Amazon.MediaLive.Model.OutputDestination>(this.Destination);
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
            var request = new Amazon.MediaLive.Model.UpdateChannelClassRequest();
            
            if (cmdletContext.ChannelClass != null)
            {
                request.ChannelClass = cmdletContext.ChannelClass;
            }
            if (cmdletContext.ChannelId != null)
            {
                request.ChannelId = cmdletContext.ChannelId;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destinations = cmdletContext.Destination;
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
        
        private Amazon.MediaLive.Model.UpdateChannelClassResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.UpdateChannelClassRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "UpdateChannelClass");
            try
            {
                return client.UpdateChannelClassAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.MediaLive.ChannelClass ChannelClass { get; set; }
            public System.String ChannelId { get; set; }
            public List<Amazon.MediaLive.Model.OutputDestination> Destination { get; set; }
            public System.Func<Amazon.MediaLive.Model.UpdateChannelClassResponse, UpdateEMLChannelClassCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Channel;
        }
        
    }
}

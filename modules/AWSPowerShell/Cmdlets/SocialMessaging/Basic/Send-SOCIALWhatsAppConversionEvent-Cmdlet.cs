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
using Amazon.SocialMessaging;
using Amazon.SocialMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SOCIAL
{
    /// <summary>
    /// Sends a conversion event to Meta's Conversions API for the specified WhatsApp Business
    /// Account dataset.
    /// </summary>
    [Cmdlet("Send", "SOCIALWhatsAppConversionEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SocialMessaging.Model.SendWhatsAppConversionEventResponse")]
    [AWSCmdlet("Calls the AWS End User Messaging Social SendWhatsAppConversionEvent API operation.", Operation = new[] {"SendWhatsAppConversionEvent"}, SelectReturnType = typeof(Amazon.SocialMessaging.Model.SendWhatsAppConversionEventResponse))]
    [AWSCmdletOutput("Amazon.SocialMessaging.Model.SendWhatsAppConversionEventResponse",
        "This cmdlet returns an Amazon.SocialMessaging.Model.SendWhatsAppConversionEventResponse object containing multiple properties."
    )]
    public partial class SendSOCIALWhatsAppConversionEventCmdlet : AmazonSocialMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatasetId
        /// <summary>
        /// <para>
        /// <para>The Meta-generated dataset ID to send the event to.</para>
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
        public System.String DatasetId { get; set; }
        #endregion
        
        #region Parameter EventData
        /// <summary>
        /// <para>
        /// <para>The raw Meta Conversions API event payload as a JSON blob. See <a href="https://developers.facebook.com/docs/marketing-api/conversions-api/parameters/server-event">Meta's
        /// server event parameters</a> for the supported format.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] EventData { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the WhatsApp Business Account associated with the dataset, formatted as
        /// <c>waba-01234567890123456789012345678901</c>.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SocialMessaging.Model.SendWhatsAppConversionEventResponse).
        /// Specifying the name of a property of type Amazon.SocialMessaging.Model.SendWhatsAppConversionEventResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.DatasetId),
                nameof(this.Id)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SOCIALWhatsAppConversionEvent (SendWhatsAppConversionEvent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SocialMessaging.Model.SendWhatsAppConversionEventResponse, SendSOCIALWhatsAppConversionEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatasetId = this.DatasetId;
            #if MODULAR
            if (this.DatasetId == null && ParameterWasBound(nameof(this.DatasetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventData = this.EventData;
            #if MODULAR
            if (this.EventData == null && ParameterWasBound(nameof(this.EventData)))
            {
                WriteWarning("You are passing $null as a value for parameter EventData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _EventDataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.SocialMessaging.Model.SendWhatsAppConversionEventRequest();
                
                if (cmdletContext.DatasetId != null)
                {
                    request.DatasetId = cmdletContext.DatasetId;
                }
                if (cmdletContext.EventData != null)
                {
                    _EventDataStream = new System.IO.MemoryStream(cmdletContext.EventData);
                    request.EventData = _EventDataStream;
                }
                if (cmdletContext.Id != null)
                {
                    request.Id = cmdletContext.Id;
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
            finally
            {
                if( _EventDataStream != null)
                {
                    _EventDataStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SocialMessaging.Model.SendWhatsAppConversionEventResponse CallAWSServiceOperation(IAmazonSocialMessaging client, Amazon.SocialMessaging.Model.SendWhatsAppConversionEventRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging Social", "SendWhatsAppConversionEvent");
            try
            {
                return client.SendWhatsAppConversionEventAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatasetId { get; set; }
            public byte[] EventData { get; set; }
            public System.String Id { get; set; }
            public System.Func<Amazon.SocialMessaging.Model.SendWhatsAppConversionEventResponse, SendSOCIALWhatsAppConversionEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

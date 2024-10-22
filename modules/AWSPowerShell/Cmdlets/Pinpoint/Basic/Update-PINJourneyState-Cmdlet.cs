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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Cancels (stops) an active journey.
    /// </summary>
    [Cmdlet("Update", "PINJourneyState", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.JourneyResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateJourneyState API operation.", Operation = new[] {"UpdateJourneyState"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateJourneyStateResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.JourneyResponse or Amazon.Pinpoint.Model.UpdateJourneyStateResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.JourneyResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateJourneyStateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINJourneyStateCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the application. This identifier is displayed as the <b>Project
        /// ID</b> on the Amazon Pinpoint console.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter JourneyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the journey.</para>
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
        public System.String JourneyId { get; set; }
        #endregion
        
        #region Parameter JourneyStateRequest_State
        /// <summary>
        /// <para>
        /// <para>The status of the journey. Currently, Supported values are ACTIVE, PAUSED, and CANCELLED</para><para>If you cancel a journey, Amazon Pinpoint continues to perform activities that are
        /// currently in progress, until those activities are complete. Amazon Pinpoint also continues
        /// to collect and aggregate analytics data for those activities, until they are complete,
        /// and any activities that were complete when you cancelled the journey.</para><para>After you cancel a journey, you can't add, change, or remove any activities from the
        /// journey. In addition, Amazon Pinpoint stops evaluating the journey and doesn't perform
        /// any activities that haven't started.</para><para>When the journey is paused, Amazon Pinpoint continues to perform activities that are
        /// currently in progress, until those activities are complete. Endpoints will stop entering
        /// journeys when the journey is paused and will resume entering the journey after the
        /// journey is resumed. For wait activities, wait time is paused when the journey is paused.
        /// Currently, PAUSED only supports journeys with a segment refresh interval.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Pinpoint.State")]
        public Amazon.Pinpoint.State JourneyStateRequest_State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JourneyResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateJourneyStateResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateJourneyStateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JourneyResponse";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINJourneyState (UpdateJourneyState)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateJourneyStateResponse, UpdatePINJourneyStateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JourneyId = this.JourneyId;
            #if MODULAR
            if (this.JourneyId == null && ParameterWasBound(nameof(this.JourneyId)))
            {
                WriteWarning("You are passing $null as a value for parameter JourneyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JourneyStateRequest_State = this.JourneyStateRequest_State;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateJourneyStateRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.JourneyId != null)
            {
                request.JourneyId = cmdletContext.JourneyId;
            }
            
             // populate JourneyStateRequest
            var requestJourneyStateRequestIsNull = true;
            request.JourneyStateRequest = new Amazon.Pinpoint.Model.JourneyStateRequest();
            Amazon.Pinpoint.State requestJourneyStateRequest_journeyStateRequest_State = null;
            if (cmdletContext.JourneyStateRequest_State != null)
            {
                requestJourneyStateRequest_journeyStateRequest_State = cmdletContext.JourneyStateRequest_State;
            }
            if (requestJourneyStateRequest_journeyStateRequest_State != null)
            {
                request.JourneyStateRequest.State = requestJourneyStateRequest_journeyStateRequest_State;
                requestJourneyStateRequestIsNull = false;
            }
             // determine if request.JourneyStateRequest should be set to null
            if (requestJourneyStateRequestIsNull)
            {
                request.JourneyStateRequest = null;
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
        
        private Amazon.Pinpoint.Model.UpdateJourneyStateResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateJourneyStateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateJourneyState");
            try
            {
                #if DESKTOP
                return client.UpdateJourneyState(request);
                #elif CORECLR
                return client.UpdateJourneyStateAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String JourneyId { get; set; }
            public Amazon.Pinpoint.State JourneyStateRequest_State { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateJourneyStateResponse, UpdatePINJourneyStateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JourneyResponse;
        }
        
    }
}

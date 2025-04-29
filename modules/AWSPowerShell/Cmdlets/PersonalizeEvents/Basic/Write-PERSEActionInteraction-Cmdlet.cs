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
using Amazon.PersonalizeEvents;
using Amazon.PersonalizeEvents.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PERSE
{
    /// <summary>
    /// Records action interaction event data. An <i>action interaction</i> event is an interaction
    /// between a user and an <i>action</i>. For example, a user taking an action, such a
    /// enrolling in a membership program or downloading your app.
    /// 
    ///  
    /// <para>
    ///  For more information about recording action interactions, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/recording-action-interaction-events.html">Recording
    /// action interaction events</a>. For more information about actions in an Actions dataset,
    /// see <a href="https://docs.aws.amazon.com/personalize/latest/dg/actions-datasets.html">Actions
    /// dataset</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "PERSEActionInteraction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Personalize Events PutActionInteractions API operation.", Operation = new[] {"PutActionInteractions"}, SelectReturnType = typeof(Amazon.PersonalizeEvents.Model.PutActionInteractionsResponse))]
    [AWSCmdletOutput("None or Amazon.PersonalizeEvents.Model.PutActionInteractionsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.PersonalizeEvents.Model.PutActionInteractionsResponse) be returned by specifying '-Select *'."
    )]
    public partial class WritePERSEActionInteractionCmdlet : AmazonPersonalizeEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActionInteraction
        /// <summary>
        /// <para>
        /// <para>A list of action interaction events from the session.</para>
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
        [Alias("ActionInteractions")]
        public Amazon.PersonalizeEvents.Model.ActionInteraction[] ActionInteraction { get; set; }
        #endregion
        
        #region Parameter TrackingId
        /// <summary>
        /// <para>
        /// <para>The ID of your action interaction event tracker. When you create an Action interactions
        /// dataset, Amazon Personalize creates an action interaction event tracker for you. For
        /// more information, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/action-interaction-tracker-id.html">Action
        /// interaction event tracker ID</a>.</para>
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
        public System.String TrackingId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PersonalizeEvents.Model.PutActionInteractionsResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrackingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-PERSEActionInteraction (PutActionInteractions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PersonalizeEvents.Model.PutActionInteractionsResponse, WritePERSEActionInteractionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ActionInteraction != null)
            {
                context.ActionInteraction = new List<Amazon.PersonalizeEvents.Model.ActionInteraction>(this.ActionInteraction);
            }
            #if MODULAR
            if (this.ActionInteraction == null && ParameterWasBound(nameof(this.ActionInteraction)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionInteraction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrackingId = this.TrackingId;
            #if MODULAR
            if (this.TrackingId == null && ParameterWasBound(nameof(this.TrackingId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrackingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PersonalizeEvents.Model.PutActionInteractionsRequest();
            
            if (cmdletContext.ActionInteraction != null)
            {
                request.ActionInteractions = cmdletContext.ActionInteraction;
            }
            if (cmdletContext.TrackingId != null)
            {
                request.TrackingId = cmdletContext.TrackingId;
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
        
        private Amazon.PersonalizeEvents.Model.PutActionInteractionsResponse CallAWSServiceOperation(IAmazonPersonalizeEvents client, Amazon.PersonalizeEvents.Model.PutActionInteractionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Personalize Events", "PutActionInteractions");
            try
            {
                return client.PutActionInteractionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.PersonalizeEvents.Model.ActionInteraction> ActionInteraction { get; set; }
            public System.String TrackingId { get; set; }
            public System.Func<Amazon.PersonalizeEvents.Model.PutActionInteractionsResponse, WritePERSEActionInteractionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

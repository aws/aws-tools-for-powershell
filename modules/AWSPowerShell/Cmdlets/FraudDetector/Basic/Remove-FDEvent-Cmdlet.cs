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
using Amazon.FraudDetector;
using Amazon.FraudDetector.Model;

namespace Amazon.PowerShell.Cmdlets.FD
{
    /// <summary>
    /// Deletes the specified event.
    /// 
    ///  
    /// <para>
    /// When you delete an event, Amazon Fraud Detector permanently deletes that event and
    /// the event data is no longer stored in Amazon Fraud Detector. If <c>deleteAuditHistory</c>
    /// is <c>True</c>, event data is available through search for up to 30 seconds after
    /// the delete operation is completed.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "FDEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Fraud Detector DeleteEvent API operation.", Operation = new[] {"DeleteEvent"}, SelectReturnType = typeof(Amazon.FraudDetector.Model.DeleteEventResponse))]
    [AWSCmdletOutput("None or Amazon.FraudDetector.Model.DeleteEventResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.FraudDetector.Model.DeleteEventResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveFDEventCmdlet : AmazonFraudDetectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeleteAuditHistory
        /// <summary>
        /// <para>
        /// <para>Specifies whether or not to delete any predictions associated with the event. If set
        /// to <c>True</c>, </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeleteAuditHistory { get; set; }
        #endregion
        
        #region Parameter EventId
        /// <summary>
        /// <para>
        /// <para>The ID of the event to delete.</para>
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
        public System.String EventId { get; set; }
        #endregion
        
        #region Parameter EventTypeName
        /// <summary>
        /// <para>
        /// <para>The name of the event type.</para>
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
        public System.String EventTypeName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FraudDetector.Model.DeleteEventResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EventId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-FDEvent (DeleteEvent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FraudDetector.Model.DeleteEventResponse, RemoveFDEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeleteAuditHistory = this.DeleteAuditHistory;
            context.EventId = this.EventId;
            #if MODULAR
            if (this.EventId == null && ParameterWasBound(nameof(this.EventId)))
            {
                WriteWarning("You are passing $null as a value for parameter EventId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventTypeName = this.EventTypeName;
            #if MODULAR
            if (this.EventTypeName == null && ParameterWasBound(nameof(this.EventTypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter EventTypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FraudDetector.Model.DeleteEventRequest();
            
            if (cmdletContext.DeleteAuditHistory != null)
            {
                request.DeleteAuditHistory = cmdletContext.DeleteAuditHistory.Value;
            }
            if (cmdletContext.EventId != null)
            {
                request.EventId = cmdletContext.EventId;
            }
            if (cmdletContext.EventTypeName != null)
            {
                request.EventTypeName = cmdletContext.EventTypeName;
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
        
        private Amazon.FraudDetector.Model.DeleteEventResponse CallAWSServiceOperation(IAmazonFraudDetector client, Amazon.FraudDetector.Model.DeleteEventRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Fraud Detector", "DeleteEvent");
            try
            {
                #if DESKTOP
                return client.DeleteEvent(request);
                #elif CORECLR
                return client.DeleteEventAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeleteAuditHistory { get; set; }
            public System.String EventId { get; set; }
            public System.String EventTypeName { get; set; }
            public System.Func<Amazon.FraudDetector.Model.DeleteEventResponse, RemoveFDEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

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
using Amazon.FraudDetector;
using Amazon.FraudDetector.Model;

namespace Amazon.PowerShell.Cmdlets.FD
{
    /// <summary>
    /// Creates or updates an event type. An event is a business activity that is evaluated
    /// for fraud risk. With Amazon Fraud Detector, you generate fraud predictions for events.
    /// An event type defines the structure for an event sent to Amazon Fraud Detector. This
    /// includes the variables sent as part of the event, the entity performing the event
    /// (such as a customer), and the labels that classify the event. Example event types
    /// include online payment transactions, account registrations, and authentications.
    /// </summary>
    [Cmdlet("Write", "FDEventType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Fraud Detector PutEventType API operation.", Operation = new[] {"PutEventType"}, SelectReturnType = typeof(Amazon.FraudDetector.Model.PutEventTypeResponse))]
    [AWSCmdletOutput("None or Amazon.FraudDetector.Model.PutEventTypeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.FraudDetector.Model.PutEventTypeResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteFDEventTypeCmdlet : AmazonFraudDetectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the event type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EntityType
        /// <summary>
        /// <para>
        /// <para>The entity type for the event type. Example entity types: customer, merchant, account.</para>
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
        [Alias("EntityTypes")]
        public System.String[] EntityType { get; set; }
        #endregion
        
        #region Parameter EventOrchestration_EventBridgeEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies if event orchestration is enabled through Amazon EventBridge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EventOrchestration_EventBridgeEnabled { get; set; }
        #endregion
        
        #region Parameter EventIngestion
        /// <summary>
        /// <para>
        /// <para>Specifies if ingestion is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FraudDetector.EventIngestion")]
        public Amazon.FraudDetector.EventIngestion EventIngestion { get; set; }
        #endregion
        
        #region Parameter EventVariable
        /// <summary>
        /// <para>
        /// <para>The event type variables.</para>
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
        [Alias("EventVariables")]
        public System.String[] EventVariable { get; set; }
        #endregion
        
        #region Parameter Label
        /// <summary>
        /// <para>
        /// <para>The event type labels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Labels")]
        public System.String[] Label { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A collection of key and value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FraudDetector.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FraudDetector.Model.PutEventTypeResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-FDEventType (PutEventType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FraudDetector.Model.PutEventTypeResponse, WriteFDEventTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            if (this.EntityType != null)
            {
                context.EntityType = new List<System.String>(this.EntityType);
            }
            #if MODULAR
            if (this.EntityType == null && ParameterWasBound(nameof(this.EntityType)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventIngestion = this.EventIngestion;
            context.EventOrchestration_EventBridgeEnabled = this.EventOrchestration_EventBridgeEnabled;
            if (this.EventVariable != null)
            {
                context.EventVariable = new List<System.String>(this.EventVariable);
            }
            #if MODULAR
            if (this.EventVariable == null && ParameterWasBound(nameof(this.EventVariable)))
            {
                WriteWarning("You are passing $null as a value for parameter EventVariable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Label != null)
            {
                context.Label = new List<System.String>(this.Label);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FraudDetector.Model.Tag>(this.Tag);
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
            var request = new Amazon.FraudDetector.Model.PutEventTypeRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EntityType != null)
            {
                request.EntityTypes = cmdletContext.EntityType;
            }
            if (cmdletContext.EventIngestion != null)
            {
                request.EventIngestion = cmdletContext.EventIngestion;
            }
            
             // populate EventOrchestration
            var requestEventOrchestrationIsNull = true;
            request.EventOrchestration = new Amazon.FraudDetector.Model.EventOrchestration();
            System.Boolean? requestEventOrchestration_eventOrchestration_EventBridgeEnabled = null;
            if (cmdletContext.EventOrchestration_EventBridgeEnabled != null)
            {
                requestEventOrchestration_eventOrchestration_EventBridgeEnabled = cmdletContext.EventOrchestration_EventBridgeEnabled.Value;
            }
            if (requestEventOrchestration_eventOrchestration_EventBridgeEnabled != null)
            {
                request.EventOrchestration.EventBridgeEnabled = requestEventOrchestration_eventOrchestration_EventBridgeEnabled.Value;
                requestEventOrchestrationIsNull = false;
            }
             // determine if request.EventOrchestration should be set to null
            if (requestEventOrchestrationIsNull)
            {
                request.EventOrchestration = null;
            }
            if (cmdletContext.EventVariable != null)
            {
                request.EventVariables = cmdletContext.EventVariable;
            }
            if (cmdletContext.Label != null)
            {
                request.Labels = cmdletContext.Label;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.FraudDetector.Model.PutEventTypeResponse CallAWSServiceOperation(IAmazonFraudDetector client, Amazon.FraudDetector.Model.PutEventTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Fraud Detector", "PutEventType");
            try
            {
                #if DESKTOP
                return client.PutEventType(request);
                #elif CORECLR
                return client.PutEventTypeAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public List<System.String> EntityType { get; set; }
            public Amazon.FraudDetector.EventIngestion EventIngestion { get; set; }
            public System.Boolean? EventOrchestration_EventBridgeEnabled { get; set; }
            public List<System.String> EventVariable { get; set; }
            public List<System.String> Label { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.FraudDetector.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.FraudDetector.Model.PutEventTypeResponse, WriteFDEventTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

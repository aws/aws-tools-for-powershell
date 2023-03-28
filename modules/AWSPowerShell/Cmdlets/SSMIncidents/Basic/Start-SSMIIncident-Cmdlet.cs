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
using Amazon.SSMIncidents;
using Amazon.SSMIncidents.Model;

namespace Amazon.PowerShell.Cmdlets.SSMI
{
    /// <summary>
    /// Used to start an incident from CloudWatch alarms, EventBridge events, or manually.
    /// </summary>
    [Cmdlet("Start", "SSMIIncident", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager StartIncident API operation.", Operation = new[] {"StartIncident"}, SelectReturnType = typeof(Amazon.SSMIncidents.Model.StartIncidentResponse))]
    [AWSCmdletOutput("System.String or Amazon.SSMIncidents.Model.StartIncidentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SSMIncidents.Model.StartIncidentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartSSMIIncidentCmdlet : AmazonSSMIncidentsClientCmdlet, IExecutor
    {
        
        #region Parameter Impact
        /// <summary>
        /// <para>
        /// Amazon.SSMIncidents.Model.StartIncidentRequest.Impact
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Impact { get; set; }
        #endregion
        
        #region Parameter TriggerDetails_RawData
        /// <summary>
        /// <para>
        /// <para>Raw data passed from either Amazon EventBridge, Amazon CloudWatch, or Incident Manager
        /// when an incident is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TriggerDetails_RawData { get; set; }
        #endregion
        
        #region Parameter RelatedItem
        /// <summary>
        /// <para>
        /// <para>Add related items to the incident for other responders to use. Related items are Amazon
        /// Web Services resources, external links, or files uploaded to an Amazon S3 bucket.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RelatedItems")]
        public Amazon.SSMIncidents.Model.RelatedItem[] RelatedItem { get; set; }
        #endregion
        
        #region Parameter ResponsePlanArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the response plan that pre-defines summary, chat
        /// channels, Amazon SNS topics, runbooks, title, and impact of the incident. </para>
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
        public System.String ResponsePlanArn { get; set; }
        #endregion
        
        #region Parameter TriggerDetails_Source
        /// <summary>
        /// <para>
        /// <para>Identifies the service that sourced the event. All events sourced from within Amazon
        /// Web Services begin with "<code>aws.</code>" Customer-generated events can have any
        /// value here, as long as it doesn't begin with "<code>aws.</code>" We recommend the
        /// use of Java package-name style reverse domain-name strings. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TriggerDetails_Source { get; set; }
        #endregion
        
        #region Parameter TriggerDetails_Timestamp
        /// <summary>
        /// <para>
        /// <para>The time that the incident was detected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TriggerDetails_Timestamp { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>Provide a title for the incident. Providing a title overwrites the title provided
        /// by the response plan. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter TriggerDetails_TriggerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source that detected the incident.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TriggerDetails_TriggerArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token ensuring that the operation is called only once with the specified details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IncidentRecordArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMIncidents.Model.StartIncidentResponse).
        /// Specifying the name of a property of type Amazon.SSMIncidents.Model.StartIncidentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IncidentRecordArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResponsePlanArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResponsePlanArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResponsePlanArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResponsePlanArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SSMIIncident (StartIncident)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMIncidents.Model.StartIncidentResponse, StartSSMIIncidentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResponsePlanArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Impact = this.Impact;
            if (this.RelatedItem != null)
            {
                context.RelatedItem = new List<Amazon.SSMIncidents.Model.RelatedItem>(this.RelatedItem);
            }
            context.ResponsePlanArn = this.ResponsePlanArn;
            #if MODULAR
            if (this.ResponsePlanArn == null && ParameterWasBound(nameof(this.ResponsePlanArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResponsePlanArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Title = this.Title;
            context.TriggerDetails_RawData = this.TriggerDetails_RawData;
            context.TriggerDetails_Source = this.TriggerDetails_Source;
            context.TriggerDetails_Timestamp = this.TriggerDetails_Timestamp;
            context.TriggerDetails_TriggerArn = this.TriggerDetails_TriggerArn;
            
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
            var request = new Amazon.SSMIncidents.Model.StartIncidentRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Impact != null)
            {
                request.Impact = cmdletContext.Impact.Value;
            }
            if (cmdletContext.RelatedItem != null)
            {
                request.RelatedItems = cmdletContext.RelatedItem;
            }
            if (cmdletContext.ResponsePlanArn != null)
            {
                request.ResponsePlanArn = cmdletContext.ResponsePlanArn;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
            }
            
             // populate TriggerDetails
            var requestTriggerDetailsIsNull = true;
            request.TriggerDetails = new Amazon.SSMIncidents.Model.TriggerDetails();
            System.String requestTriggerDetails_triggerDetails_RawData = null;
            if (cmdletContext.TriggerDetails_RawData != null)
            {
                requestTriggerDetails_triggerDetails_RawData = cmdletContext.TriggerDetails_RawData;
            }
            if (requestTriggerDetails_triggerDetails_RawData != null)
            {
                request.TriggerDetails.RawData = requestTriggerDetails_triggerDetails_RawData;
                requestTriggerDetailsIsNull = false;
            }
            System.String requestTriggerDetails_triggerDetails_Source = null;
            if (cmdletContext.TriggerDetails_Source != null)
            {
                requestTriggerDetails_triggerDetails_Source = cmdletContext.TriggerDetails_Source;
            }
            if (requestTriggerDetails_triggerDetails_Source != null)
            {
                request.TriggerDetails.Source = requestTriggerDetails_triggerDetails_Source;
                requestTriggerDetailsIsNull = false;
            }
            System.DateTime? requestTriggerDetails_triggerDetails_Timestamp = null;
            if (cmdletContext.TriggerDetails_Timestamp != null)
            {
                requestTriggerDetails_triggerDetails_Timestamp = cmdletContext.TriggerDetails_Timestamp.Value;
            }
            if (requestTriggerDetails_triggerDetails_Timestamp != null)
            {
                request.TriggerDetails.Timestamp = requestTriggerDetails_triggerDetails_Timestamp.Value;
                requestTriggerDetailsIsNull = false;
            }
            System.String requestTriggerDetails_triggerDetails_TriggerArn = null;
            if (cmdletContext.TriggerDetails_TriggerArn != null)
            {
                requestTriggerDetails_triggerDetails_TriggerArn = cmdletContext.TriggerDetails_TriggerArn;
            }
            if (requestTriggerDetails_triggerDetails_TriggerArn != null)
            {
                request.TriggerDetails.TriggerArn = requestTriggerDetails_triggerDetails_TriggerArn;
                requestTriggerDetailsIsNull = false;
            }
             // determine if request.TriggerDetails should be set to null
            if (requestTriggerDetailsIsNull)
            {
                request.TriggerDetails = null;
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
        
        private Amazon.SSMIncidents.Model.StartIncidentResponse CallAWSServiceOperation(IAmazonSSMIncidents client, Amazon.SSMIncidents.Model.StartIncidentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager", "StartIncident");
            try
            {
                #if DESKTOP
                return client.StartIncident(request);
                #elif CORECLR
                return client.StartIncidentAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Int32? Impact { get; set; }
            public List<Amazon.SSMIncidents.Model.RelatedItem> RelatedItem { get; set; }
            public System.String ResponsePlanArn { get; set; }
            public System.String Title { get; set; }
            public System.String TriggerDetails_RawData { get; set; }
            public System.String TriggerDetails_Source { get; set; }
            public System.DateTime? TriggerDetails_Timestamp { get; set; }
            public System.String TriggerDetails_TriggerArn { get; set; }
            public System.Func<Amazon.SSMIncidents.Model.StartIncidentResponse, StartSSMIIncidentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IncidentRecordArn;
        }
        
    }
}

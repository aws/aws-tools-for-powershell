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
using Amazon.CloudWatchEvents;
using Amazon.CloudWatchEvents.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWE
{
    /// <summary>
    /// Called by an SaaS partner to create a partner event source. This operation is not
    /// used by Amazon Web Services customers.
    /// 
    ///  
    /// <para>
    /// Each partner event source can be used by one Amazon Web Services account to create
    /// a matching partner event bus in that Amazon Web Services account. A SaaS partner must
    /// create one partner event source for each Amazon Web Services account that wants to
    /// receive those event types. 
    /// </para><para>
    /// A partner event source creates events based on resources within the SaaS partner's
    /// service or application.
    /// </para><para>
    /// An Amazon Web Services account that creates a partner event bus that matches the partner
    /// event source can use that event bus to receive events from the partner, and then process
    /// them using Amazon Web Services Events rules and targets.
    /// </para><para>
    /// Partner event source names follow this format:
    /// </para><para><c><i>partner_name</i>/<i>event_namespace</i>/<i>event_name</i></c></para><para><i>partner_name</i> is determined during partner registration and identifies the
    /// partner to Amazon Web Services customers. <i>event_namespace</i> is determined by
    /// the partner and is a way for the partner to categorize their events. <i>event_name</i>
    /// is determined by the partner, and should uniquely identify an event-generating resource
    /// within the partner system. The combination of <i>event_namespace</i> and <i>event_name</i>
    /// should help Amazon Web Services customers decide whether to create an event bus to
    /// receive these events.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CWEPartnerEventSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch Events CreatePartnerEventSource API operation.", Operation = new[] {"CreatePartnerEventSource"}, SelectReturnType = typeof(Amazon.CloudWatchEvents.Model.CreatePartnerEventSourceResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudWatchEvents.Model.CreatePartnerEventSourceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudWatchEvents.Model.CreatePartnerEventSourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCWEPartnerEventSourceCmdlet : AmazonCloudWatchEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Account
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID that is permitted to create a matching partner
        /// event bus for this partner event source.</para>
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
        public System.String Account { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the partner event source. This name must be unique and must be in the
        /// format <c><i>partner_name</i>/<i>event_namespace</i>/<i>event_name</i></c>. The
        /// Amazon Web Services account that wants to use this partner event source must create
        /// a partner event bus with a name that matches the name of the partner event source.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventSourceArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvents.Model.CreatePartnerEventSourceResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvents.Model.CreatePartnerEventSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventSourceArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWEPartnerEventSource (CreatePartnerEventSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvents.Model.CreatePartnerEventSourceResponse, NewCWEPartnerEventSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Account = this.Account;
            #if MODULAR
            if (this.Account == null && ParameterWasBound(nameof(this.Account)))
            {
                WriteWarning("You are passing $null as a value for parameter Account which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchEvents.Model.CreatePartnerEventSourceRequest();
            
            if (cmdletContext.Account != null)
            {
                request.Account = cmdletContext.Account;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.CloudWatchEvents.Model.CreatePartnerEventSourceResponse CallAWSServiceOperation(IAmazonCloudWatchEvents client, Amazon.CloudWatchEvents.Model.CreatePartnerEventSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Events", "CreatePartnerEventSource");
            try
            {
                return client.CreatePartnerEventSourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Account { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.CloudWatchEvents.Model.CreatePartnerEventSourceResponse, NewCWEPartnerEventSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventSourceArn;
        }
        
    }
}

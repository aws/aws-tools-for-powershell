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
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Modifies an existing RDS event notification subscription. You can't modify the source
    /// identifiers using this call. To change source identifiers for a subscription, use
    /// the <c>AddSourceIdentifierToSubscription</c> and <c>RemoveSourceIdentifierFromSubscription</c>
    /// calls.
    /// 
    ///  
    /// <para>
    /// You can see a list of the event categories for a given source type (<c>SourceType</c>)
    /// in <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Events.html">Events</a>
    /// in the <i>Amazon RDS User Guide</i> or by using the <c>DescribeEventCategories</c>
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "RDSEventSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.EventSubscription")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyEventSubscription API operation.", Operation = new[] {"ModifyEventSubscription"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyEventSubscriptionResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.EventSubscription or Amazon.RDS.Model.ModifyEventSubscriptionResponse",
        "This cmdlet returns an Amazon.RDS.Model.EventSubscription object.",
        "The service call response (type Amazon.RDS.Model.ModifyEventSubscriptionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditRDSEventSubscriptionCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to activate the subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter EventCategory
        /// <summary>
        /// <para>
        /// <para>A list of event categories for a source type (<c>SourceType</c>) that you want to
        /// subscribe to. You can see a list of the categories for a given source type in <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Events.html">Events</a>
        /// in the <i>Amazon RDS User Guide</i> or by using the <c>DescribeEventCategories</c>
        /// operation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventCategories")]
        public System.String[] EventCategory { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the SNS topic created for event notification. The
        /// ARN is created by Amazon SNS when you create a topic and subscribe to it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter SourceType
        /// <summary>
        /// <para>
        /// <para>The type of source that is generating the events. For example, if you want to be notified
        /// of events generated by a DB instance, you would set this parameter to db-instance.
        /// For RDS Proxy events, specify <c>db-proxy</c>. If this value isn't specified, all
        /// events are returned.</para><para>Valid Values:<c> db-instance | db-cluster | db-parameter-group | db-security-group
        /// | db-snapshot | db-cluster-snapshot | db-proxy | zero-etl | custom-engine-version
        /// | blue-green-deployment </c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceType { get; set; }
        #endregion
        
        #region Parameter SubscriptionName
        /// <summary>
        /// <para>
        /// <para>The name of the RDS event notification subscription.</para>
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
        public System.String SubscriptionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventSubscription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyEventSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyEventSubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventSubscription";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubscriptionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSEventSubscription (ModifyEventSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyEventSubscriptionResponse, EditRDSEventSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Enabled = this.Enabled;
            if (this.EventCategory != null)
            {
                context.EventCategory = new List<System.String>(this.EventCategory);
            }
            context.SnsTopicArn = this.SnsTopicArn;
            context.SourceType = this.SourceType;
            context.SubscriptionName = this.SubscriptionName;
            #if MODULAR
            if (this.SubscriptionName == null && ParameterWasBound(nameof(this.SubscriptionName)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.ModifyEventSubscriptionRequest();
            
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.EventCategory != null)
            {
                request.EventCategories = cmdletContext.EventCategory;
            }
            if (cmdletContext.SnsTopicArn != null)
            {
                request.SnsTopicArn = cmdletContext.SnsTopicArn;
            }
            if (cmdletContext.SourceType != null)
            {
                request.SourceType = cmdletContext.SourceType;
            }
            if (cmdletContext.SubscriptionName != null)
            {
                request.SubscriptionName = cmdletContext.SubscriptionName;
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
        
        private Amazon.RDS.Model.ModifyEventSubscriptionResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyEventSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyEventSubscription");
            try
            {
                return client.ModifyEventSubscriptionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Enabled { get; set; }
            public List<System.String> EventCategory { get; set; }
            public System.String SnsTopicArn { get; set; }
            public System.String SourceType { get; set; }
            public System.String SubscriptionName { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyEventSubscriptionResponse, EditRDSEventSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventSubscription;
        }
        
    }
}

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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates an event window in which scheduled events for the associated Amazon EC2 instances
    /// can run.
    /// 
    ///  
    /// <para>
    /// You can define either a set of time ranges or a cron expression when creating the
    /// event window, but not both. All event window times are in UTC.
    /// </para><para>
    /// You can create up to 200 event windows per Amazon Web Services Region.
    /// </para><para>
    /// When you create the event window, targets (instance IDs, Dedicated Host IDs, or tags)
    /// are not yet associated with it. To ensure that the event window can be used, you must
    /// associate one or more targets with it by using the <a>AssociateInstanceEventWindow</a>
    /// API.
    /// </para><important><para>
    /// Event windows are applicable only for scheduled events that stop, reboot, or terminate
    /// instances.
    /// </para><para>
    /// Event windows are <i>not</i> applicable for:
    /// </para><ul><li><para>
    /// Expedited scheduled events and network maintenance events. 
    /// </para></li><li><para>
    /// Unscheduled maintenance such as AutoRecovery and unplanned reboots.
    /// </para></li></ul></important><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/event-windows.html">Define
    /// event windows for scheduled events</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2InstanceEventWindow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.InstanceEventWindow")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateInstanceEventWindow API operation.", Operation = new[] {"CreateInstanceEventWindow"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateInstanceEventWindowResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceEventWindow or Amazon.EC2.Model.CreateInstanceEventWindowResponse",
        "This cmdlet returns an Amazon.EC2.Model.InstanceEventWindow object.",
        "The service call response (type Amazon.EC2.Model.CreateInstanceEventWindowResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2InstanceEventWindowCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter CronExpression
        /// <summary>
        /// <para>
        /// <para>The cron expression for the event window, for example, <code>* 0-4,20-23 * * 1,5</code>.
        /// If you specify a cron expression, you can't specify a time range.</para><para>Constraints:</para><ul><li><para>Only hour and day of the week values are supported.</para></li><li><para>For day of the week values, you can specify either integers <code>0</code> through
        /// <code>6</code>, or alternative single values <code>SUN</code> through <code>SAT</code>.</para></li><li><para>The minute, month, and year must be specified by <code>*</code>.</para></li><li><para>The hour value must be one or a multiple range, for example, <code>0-4</code> or <code>0-4,20-23</code>.</para></li><li><para>Each hour range must be &gt;= 2 hours, for example, <code>0-2</code> or <code>20-23</code>.</para></li><li><para>The event window must be &gt;= 4 hours. The combined total time ranges in the event
        /// window must be &gt;= 4 hours.</para></li></ul><para>For more information about cron expressions, see <a href="https://en.wikipedia.org/wiki/Cron">cron</a>
        /// on the <i>Wikipedia website</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CronExpression { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the event window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the event window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TimeRange
        /// <summary>
        /// <para>
        /// <para>The time range for the event window. If you specify a time range, you can't specify
        /// a cron expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeRanges")]
        public Amazon.EC2.Model.InstanceEventWindowTimeRangeRequest[] TimeRange { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceEventWindow'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateInstanceEventWindowResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateInstanceEventWindowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceEventWindow";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2InstanceEventWindow (CreateInstanceEventWindow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateInstanceEventWindowResponse, NewEC2InstanceEventWindowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CronExpression = this.CronExpression;
            context.Name = this.Name;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            if (this.TimeRange != null)
            {
                context.TimeRange = new List<Amazon.EC2.Model.InstanceEventWindowTimeRangeRequest>(this.TimeRange);
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
            var request = new Amazon.EC2.Model.CreateInstanceEventWindowRequest();
            
            if (cmdletContext.CronExpression != null)
            {
                request.CronExpression = cmdletContext.CronExpression;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.TimeRange != null)
            {
                request.TimeRanges = cmdletContext.TimeRange;
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
        
        private Amazon.EC2.Model.CreateInstanceEventWindowResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateInstanceEventWindowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateInstanceEventWindow");
            try
            {
                #if DESKTOP
                return client.CreateInstanceEventWindow(request);
                #elif CORECLR
                return client.CreateInstanceEventWindowAsync(request).GetAwaiter().GetResult();
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
            public System.String CronExpression { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public List<Amazon.EC2.Model.InstanceEventWindowTimeRangeRequest> TimeRange { get; set; }
            public System.Func<Amazon.EC2.Model.CreateInstanceEventWindowResponse, NewEC2InstanceEventWindowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceEventWindow;
        }
        
    }
}

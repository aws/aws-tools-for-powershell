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
    /// Modifies the specified event window.
    /// 
    ///  
    /// <para>
    /// You can define either a set of time ranges or a cron expression when modifying the
    /// event window, but not both.
    /// </para><para>
    /// To modify the targets associated with the event window, use the <a>AssociateInstanceEventWindow</a>
    /// and <a>DisassociateInstanceEventWindow</a> API.
    /// </para><para>
    /// If Amazon Web Services has already scheduled an event, modifying an event window won't
    /// change the time of the scheduled event.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/event-windows.html">Define
    /// event windows for scheduled events</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2InstanceEventWindow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.InstanceEventWindow")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyInstanceEventWindow API operation.", Operation = new[] {"ModifyInstanceEventWindow"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyInstanceEventWindowResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceEventWindow or Amazon.EC2.Model.ModifyInstanceEventWindowResponse",
        "This cmdlet returns an Amazon.EC2.Model.InstanceEventWindow object.",
        "The service call response (type Amazon.EC2.Model.ModifyInstanceEventWindowResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2InstanceEventWindowCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CronExpression
        /// <summary>
        /// <para>
        /// <para>The cron expression of the event window, for example, <c>* 0-4,20-23 * * 1,5</c>.</para><para>Constraints:</para><ul><li><para>Only hour and day of the week values are supported.</para></li><li><para>For day of the week values, you can specify either integers <c>0</c> through <c>6</c>,
        /// or alternative single values <c>SUN</c> through <c>SAT</c>.</para></li><li><para>The minute, month, and year must be specified by <c>*</c>.</para></li><li><para>The hour value must be one or a multiple range, for example, <c>0-4</c> or <c>0-4,20-23</c>.</para></li><li><para>Each hour range must be &gt;= 2 hours, for example, <c>0-2</c> or <c>20-23</c>.</para></li><li><para>The event window must be &gt;= 4 hours. The combined total time ranges in the event
        /// window must be &gt;= 4 hours.</para></li></ul><para>For more information about cron expressions, see <a href="https://en.wikipedia.org/wiki/Cron">cron</a>
        /// on the <i>Wikipedia website</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CronExpression { get; set; }
        #endregion
        
        #region Parameter InstanceEventWindowId
        /// <summary>
        /// <para>
        /// <para>The ID of the event window.</para>
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
        public System.String InstanceEventWindowId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the event window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TimeRange
        /// <summary>
        /// <para>
        /// <para>The time ranges of the event window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeRanges")]
        public Amazon.EC2.Model.InstanceEventWindowTimeRangeRequest[] TimeRange { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceEventWindow'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyInstanceEventWindowResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyInstanceEventWindowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceEventWindow";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceEventWindowId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2InstanceEventWindow (ModifyInstanceEventWindow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyInstanceEventWindowResponse, EditEC2InstanceEventWindowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CronExpression = this.CronExpression;
            context.InstanceEventWindowId = this.InstanceEventWindowId;
            #if MODULAR
            if (this.InstanceEventWindowId == null && ParameterWasBound(nameof(this.InstanceEventWindowId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceEventWindowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
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
            var request = new Amazon.EC2.Model.ModifyInstanceEventWindowRequest();
            
            if (cmdletContext.CronExpression != null)
            {
                request.CronExpression = cmdletContext.CronExpression;
            }
            if (cmdletContext.InstanceEventWindowId != null)
            {
                request.InstanceEventWindowId = cmdletContext.InstanceEventWindowId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.EC2.Model.ModifyInstanceEventWindowResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyInstanceEventWindowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyInstanceEventWindow");
            try
            {
                #if DESKTOP
                return client.ModifyInstanceEventWindow(request);
                #elif CORECLR
                return client.ModifyInstanceEventWindowAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceEventWindowId { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.EC2.Model.InstanceEventWindowTimeRangeRequest> TimeRange { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyInstanceEventWindowResponse, EditEC2InstanceEventWindowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceEventWindow;
        }
        
    }
}

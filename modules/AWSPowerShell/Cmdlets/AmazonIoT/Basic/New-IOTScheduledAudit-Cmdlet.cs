/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates a scheduled audit that is run at a specified time interval.
    /// </summary>
    [Cmdlet("New", "IOTScheduledAudit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT CreateScheduledAudit API operation.", Operation = new[] {"CreateScheduledAudit"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.IoT.Model.CreateScheduledAuditResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTScheduledAuditCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter DayOfMonth
        /// <summary>
        /// <para>
        /// <para>The day of the month on which the scheduled audit takes place. Can be "1" through
        /// "31" or "LAST". This field is required if the "frequency" parameter is set to "MONTHLY".
        /// If days 29-31 are specified, and the month does not have that many days, the audit
        /// takes place on the "LAST" day of the month.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DayOfMonth { get; set; }
        #endregion
        
        #region Parameter DayOfWeek
        /// <summary>
        /// <para>
        /// <para>The day of the week on which the scheduled audit takes place. Can be one of "SUN",
        /// "MON", "TUE", "WED", "THU", "FRI" or "SAT". This field is required if the "frequency"
        /// parameter is set to "WEEKLY" or "BIWEEKLY".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoT.DayOfWeek")]
        public Amazon.IoT.DayOfWeek DayOfWeek { get; set; }
        #endregion
        
        #region Parameter Frequency
        /// <summary>
        /// <para>
        /// <para>How often the scheduled audit takes place. Can be one of "DAILY", "WEEKLY", "BIWEEKLY"
        /// or "MONTHLY". The actual start time of each audit is determined by the system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoT.AuditFrequency")]
        public Amazon.IoT.AuditFrequency Frequency { get; set; }
        #endregion
        
        #region Parameter ScheduledAuditName
        /// <summary>
        /// <para>
        /// <para>The name you want to give to the scheduled audit. (Max. 128 chars)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ScheduledAuditName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata which can be used to manage the scheduled audit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.IoT.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetCheckName
        /// <summary>
        /// <para>
        /// <para>Which checks are performed during the scheduled audit. Checks must be enabled for
        /// your account. (Use <code>DescribeAccountAuditConfiguration</code> to see the list
        /// of all checks including those that are enabled or <code>UpdateAccountAuditConfiguration</code>
        /// to select which checks are enabled.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetCheckNames")]
        public System.String[] TargetCheckName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ScheduledAuditName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTScheduledAudit (CreateScheduledAudit)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DayOfMonth = this.DayOfMonth;
            context.DayOfWeek = this.DayOfWeek;
            context.Frequency = this.Frequency;
            context.ScheduledAuditName = this.ScheduledAuditName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.IoT.Model.Tag>(this.Tag);
            }
            if (this.TargetCheckName != null)
            {
                context.TargetCheckNames = new List<System.String>(this.TargetCheckName);
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
            var request = new Amazon.IoT.Model.CreateScheduledAuditRequest();
            
            if (cmdletContext.DayOfMonth != null)
            {
                request.DayOfMonth = cmdletContext.DayOfMonth;
            }
            if (cmdletContext.DayOfWeek != null)
            {
                request.DayOfWeek = cmdletContext.DayOfWeek;
            }
            if (cmdletContext.Frequency != null)
            {
                request.Frequency = cmdletContext.Frequency;
            }
            if (cmdletContext.ScheduledAuditName != null)
            {
                request.ScheduledAuditName = cmdletContext.ScheduledAuditName;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TargetCheckNames != null)
            {
                request.TargetCheckNames = cmdletContext.TargetCheckNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ScheduledAuditArn;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.IoT.Model.CreateScheduledAuditResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateScheduledAuditRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateScheduledAudit");
            try
            {
                #if DESKTOP
                return client.CreateScheduledAudit(request);
                #elif CORECLR
                return client.CreateScheduledAuditAsync(request).GetAwaiter().GetResult();
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
            public System.String DayOfMonth { get; set; }
            public Amazon.IoT.DayOfWeek DayOfWeek { get; set; }
            public Amazon.IoT.AuditFrequency Frequency { get; set; }
            public System.String ScheduledAuditName { get; set; }
            public List<Amazon.IoT.Model.Tag> Tags { get; set; }
            public List<System.String> TargetCheckNames { get; set; }
        }
        
    }
}

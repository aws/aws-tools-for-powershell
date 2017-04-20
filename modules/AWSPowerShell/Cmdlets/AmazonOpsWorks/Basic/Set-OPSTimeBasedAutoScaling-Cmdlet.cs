/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Specify the time-based auto scaling configuration for a specified instance. For more
    /// information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-autoscaling.html">Managing
    /// Load with Time-based and Load-based Instances</a>.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack, or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "OPSTimeBasedAutoScaling", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SetTimeBasedAutoScaling operation against AWS OpsWorks.", Operation = new[] {"SetTimeBasedAutoScaling"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the InstanceId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.OpsWorks.Model.SetTimeBasedAutoScalingResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetOPSTimeBasedAutoScalingCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        #region Parameter AutoScalingSchedule_Friday
        /// <summary>
        /// <para>
        /// <para>The schedule for Friday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable AutoScalingSchedule_Friday { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The instance ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter AutoScalingSchedule_Monday
        /// <summary>
        /// <para>
        /// <para>The schedule for Monday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable AutoScalingSchedule_Monday { get; set; }
        #endregion
        
        #region Parameter AutoScalingSchedule_Saturday
        /// <summary>
        /// <para>
        /// <para>The schedule for Saturday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable AutoScalingSchedule_Saturday { get; set; }
        #endregion
        
        #region Parameter AutoScalingSchedule_Sunday
        /// <summary>
        /// <para>
        /// <para>The schedule for Sunday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable AutoScalingSchedule_Sunday { get; set; }
        #endregion
        
        #region Parameter AutoScalingSchedule_Thursday
        /// <summary>
        /// <para>
        /// <para>The schedule for Thursday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable AutoScalingSchedule_Thursday { get; set; }
        #endregion
        
        #region Parameter AutoScalingSchedule_Tuesday
        /// <summary>
        /// <para>
        /// <para>The schedule for Tuesday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable AutoScalingSchedule_Tuesday { get; set; }
        #endregion
        
        #region Parameter AutoScalingSchedule_Wednesday
        /// <summary>
        /// <para>
        /// <para>The schedule for Wednesday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable AutoScalingSchedule_Wednesday { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the InstanceId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-OPSTimeBasedAutoScaling (SetTimeBasedAutoScaling)"))
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
            
            if (this.AutoScalingSchedule_Friday != null)
            {
                context.AutoScalingSchedule_Friday = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AutoScalingSchedule_Friday.Keys)
                {
                    context.AutoScalingSchedule_Friday.Add((String)hashKey, (String)(this.AutoScalingSchedule_Friday[hashKey]));
                }
            }
            if (this.AutoScalingSchedule_Monday != null)
            {
                context.AutoScalingSchedule_Monday = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AutoScalingSchedule_Monday.Keys)
                {
                    context.AutoScalingSchedule_Monday.Add((String)hashKey, (String)(this.AutoScalingSchedule_Monday[hashKey]));
                }
            }
            if (this.AutoScalingSchedule_Saturday != null)
            {
                context.AutoScalingSchedule_Saturday = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AutoScalingSchedule_Saturday.Keys)
                {
                    context.AutoScalingSchedule_Saturday.Add((String)hashKey, (String)(this.AutoScalingSchedule_Saturday[hashKey]));
                }
            }
            if (this.AutoScalingSchedule_Sunday != null)
            {
                context.AutoScalingSchedule_Sunday = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AutoScalingSchedule_Sunday.Keys)
                {
                    context.AutoScalingSchedule_Sunday.Add((String)hashKey, (String)(this.AutoScalingSchedule_Sunday[hashKey]));
                }
            }
            if (this.AutoScalingSchedule_Thursday != null)
            {
                context.AutoScalingSchedule_Thursday = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AutoScalingSchedule_Thursday.Keys)
                {
                    context.AutoScalingSchedule_Thursday.Add((String)hashKey, (String)(this.AutoScalingSchedule_Thursday[hashKey]));
                }
            }
            if (this.AutoScalingSchedule_Tuesday != null)
            {
                context.AutoScalingSchedule_Tuesday = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AutoScalingSchedule_Tuesday.Keys)
                {
                    context.AutoScalingSchedule_Tuesday.Add((String)hashKey, (String)(this.AutoScalingSchedule_Tuesday[hashKey]));
                }
            }
            if (this.AutoScalingSchedule_Wednesday != null)
            {
                context.AutoScalingSchedule_Wednesday = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AutoScalingSchedule_Wednesday.Keys)
                {
                    context.AutoScalingSchedule_Wednesday.Add((String)hashKey, (String)(this.AutoScalingSchedule_Wednesday[hashKey]));
                }
            }
            context.InstanceId = this.InstanceId;
            
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
            var request = new Amazon.OpsWorks.Model.SetTimeBasedAutoScalingRequest();
            
            
             // populate AutoScalingSchedule
            bool requestAutoScalingScheduleIsNull = true;
            request.AutoScalingSchedule = new Amazon.OpsWorks.Model.WeeklyAutoScalingSchedule();
            Dictionary<System.String, System.String> requestAutoScalingSchedule_autoScalingSchedule_Friday = null;
            if (cmdletContext.AutoScalingSchedule_Friday != null)
            {
                requestAutoScalingSchedule_autoScalingSchedule_Friday = cmdletContext.AutoScalingSchedule_Friday;
            }
            if (requestAutoScalingSchedule_autoScalingSchedule_Friday != null)
            {
                request.AutoScalingSchedule.Friday = requestAutoScalingSchedule_autoScalingSchedule_Friday;
                requestAutoScalingScheduleIsNull = false;
            }
            Dictionary<System.String, System.String> requestAutoScalingSchedule_autoScalingSchedule_Monday = null;
            if (cmdletContext.AutoScalingSchedule_Monday != null)
            {
                requestAutoScalingSchedule_autoScalingSchedule_Monday = cmdletContext.AutoScalingSchedule_Monday;
            }
            if (requestAutoScalingSchedule_autoScalingSchedule_Monday != null)
            {
                request.AutoScalingSchedule.Monday = requestAutoScalingSchedule_autoScalingSchedule_Monday;
                requestAutoScalingScheduleIsNull = false;
            }
            Dictionary<System.String, System.String> requestAutoScalingSchedule_autoScalingSchedule_Saturday = null;
            if (cmdletContext.AutoScalingSchedule_Saturday != null)
            {
                requestAutoScalingSchedule_autoScalingSchedule_Saturday = cmdletContext.AutoScalingSchedule_Saturday;
            }
            if (requestAutoScalingSchedule_autoScalingSchedule_Saturday != null)
            {
                request.AutoScalingSchedule.Saturday = requestAutoScalingSchedule_autoScalingSchedule_Saturday;
                requestAutoScalingScheduleIsNull = false;
            }
            Dictionary<System.String, System.String> requestAutoScalingSchedule_autoScalingSchedule_Sunday = null;
            if (cmdletContext.AutoScalingSchedule_Sunday != null)
            {
                requestAutoScalingSchedule_autoScalingSchedule_Sunday = cmdletContext.AutoScalingSchedule_Sunday;
            }
            if (requestAutoScalingSchedule_autoScalingSchedule_Sunday != null)
            {
                request.AutoScalingSchedule.Sunday = requestAutoScalingSchedule_autoScalingSchedule_Sunday;
                requestAutoScalingScheduleIsNull = false;
            }
            Dictionary<System.String, System.String> requestAutoScalingSchedule_autoScalingSchedule_Thursday = null;
            if (cmdletContext.AutoScalingSchedule_Thursday != null)
            {
                requestAutoScalingSchedule_autoScalingSchedule_Thursday = cmdletContext.AutoScalingSchedule_Thursday;
            }
            if (requestAutoScalingSchedule_autoScalingSchedule_Thursday != null)
            {
                request.AutoScalingSchedule.Thursday = requestAutoScalingSchedule_autoScalingSchedule_Thursday;
                requestAutoScalingScheduleIsNull = false;
            }
            Dictionary<System.String, System.String> requestAutoScalingSchedule_autoScalingSchedule_Tuesday = null;
            if (cmdletContext.AutoScalingSchedule_Tuesday != null)
            {
                requestAutoScalingSchedule_autoScalingSchedule_Tuesday = cmdletContext.AutoScalingSchedule_Tuesday;
            }
            if (requestAutoScalingSchedule_autoScalingSchedule_Tuesday != null)
            {
                request.AutoScalingSchedule.Tuesday = requestAutoScalingSchedule_autoScalingSchedule_Tuesday;
                requestAutoScalingScheduleIsNull = false;
            }
            Dictionary<System.String, System.String> requestAutoScalingSchedule_autoScalingSchedule_Wednesday = null;
            if (cmdletContext.AutoScalingSchedule_Wednesday != null)
            {
                requestAutoScalingSchedule_autoScalingSchedule_Wednesday = cmdletContext.AutoScalingSchedule_Wednesday;
            }
            if (requestAutoScalingSchedule_autoScalingSchedule_Wednesday != null)
            {
                request.AutoScalingSchedule.Wednesday = requestAutoScalingSchedule_autoScalingSchedule_Wednesday;
                requestAutoScalingScheduleIsNull = false;
            }
             // determine if request.AutoScalingSchedule should be set to null
            if (requestAutoScalingScheduleIsNull)
            {
                request.AutoScalingSchedule = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.InstanceId;
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
        
        private Amazon.OpsWorks.Model.SetTimeBasedAutoScalingResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.SetTimeBasedAutoScalingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "SetTimeBasedAutoScaling");
            #if DESKTOP
            return client.SetTimeBasedAutoScaling(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.SetTimeBasedAutoScalingAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Dictionary<System.String, System.String> AutoScalingSchedule_Friday { get; set; }
            public Dictionary<System.String, System.String> AutoScalingSchedule_Monday { get; set; }
            public Dictionary<System.String, System.String> AutoScalingSchedule_Saturday { get; set; }
            public Dictionary<System.String, System.String> AutoScalingSchedule_Sunday { get; set; }
            public Dictionary<System.String, System.String> AutoScalingSchedule_Thursday { get; set; }
            public Dictionary<System.String, System.String> AutoScalingSchedule_Tuesday { get; set; }
            public Dictionary<System.String, System.String> AutoScalingSchedule_Wednesday { get; set; }
            public System.String InstanceId { get; set; }
        }
        
    }
}

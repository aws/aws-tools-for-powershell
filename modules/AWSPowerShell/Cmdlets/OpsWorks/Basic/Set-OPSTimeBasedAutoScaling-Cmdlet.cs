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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Specify the time-based auto scaling configuration for a specified instance. For more
    /// information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-autoscaling.html">Managing
    /// Load with Time-based and Load-based Instances</a>.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack, or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "OPSTimeBasedAutoScaling", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS OpsWorks SetTimeBasedAutoScaling API operation.", Operation = new[] {"SetTimeBasedAutoScaling"}, SelectReturnType = typeof(Amazon.OpsWorks.Model.SetTimeBasedAutoScalingResponse))]
    [AWSCmdletOutput("None or Amazon.OpsWorks.Model.SetTimeBasedAutoScalingResponse",
        "This cmdlet does not generate any output." +
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AutoScalingSchedule_Friday { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The instance ID.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter AutoScalingSchedule_Monday
        /// <summary>
        /// <para>
        /// <para>The schedule for Monday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AutoScalingSchedule_Monday { get; set; }
        #endregion
        
        #region Parameter AutoScalingSchedule_Saturday
        /// <summary>
        /// <para>
        /// <para>The schedule for Saturday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AutoScalingSchedule_Saturday { get; set; }
        #endregion
        
        #region Parameter AutoScalingSchedule_Sunday
        /// <summary>
        /// <para>
        /// <para>The schedule for Sunday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AutoScalingSchedule_Sunday { get; set; }
        #endregion
        
        #region Parameter AutoScalingSchedule_Thursday
        /// <summary>
        /// <para>
        /// <para>The schedule for Thursday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AutoScalingSchedule_Thursday { get; set; }
        #endregion
        
        #region Parameter AutoScalingSchedule_Tuesday
        /// <summary>
        /// <para>
        /// <para>The schedule for Tuesday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AutoScalingSchedule_Tuesday { get; set; }
        #endregion
        
        #region Parameter AutoScalingSchedule_Wednesday
        /// <summary>
        /// <para>
        /// <para>The schedule for Wednesday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AutoScalingSchedule_Wednesday { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorks.Model.SetTimeBasedAutoScalingResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-OPSTimeBasedAutoScaling (SetTimeBasedAutoScaling)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorks.Model.SetTimeBasedAutoScalingResponse, SetOPSTimeBasedAutoScalingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpsWorks.Model.SetTimeBasedAutoScalingRequest();
            
            
             // populate AutoScalingSchedule
            var requestAutoScalingScheduleIsNull = true;
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
        
        private Amazon.OpsWorks.Model.SetTimeBasedAutoScalingResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.SetTimeBasedAutoScalingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "SetTimeBasedAutoScaling");
            try
            {
                #if DESKTOP
                return client.SetTimeBasedAutoScaling(request);
                #elif CORECLR
                return client.SetTimeBasedAutoScalingAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> AutoScalingSchedule_Friday { get; set; }
            public Dictionary<System.String, System.String> AutoScalingSchedule_Monday { get; set; }
            public Dictionary<System.String, System.String> AutoScalingSchedule_Saturday { get; set; }
            public Dictionary<System.String, System.String> AutoScalingSchedule_Sunday { get; set; }
            public Dictionary<System.String, System.String> AutoScalingSchedule_Thursday { get; set; }
            public Dictionary<System.String, System.String> AutoScalingSchedule_Tuesday { get; set; }
            public Dictionary<System.String, System.String> AutoScalingSchedule_Wednesday { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.OpsWorks.Model.SetTimeBasedAutoScalingResponse, SetOPSTimeBasedAutoScalingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

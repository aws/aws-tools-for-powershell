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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Modifies an account setting for all users on an account for whom no individual account
    /// setting has been specified. Account settings are set on a per-Region basis.
    /// </summary>
    [Cmdlet("Write", "ECSAccountSettingDefault", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Setting")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service PutAccountSettingDefault API operation.", Operation = new[] {"PutAccountSettingDefault"}, SelectReturnType = typeof(Amazon.ECS.Model.PutAccountSettingDefaultResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.Setting or Amazon.ECS.Model.PutAccountSettingDefaultResponse",
        "This cmdlet returns an Amazon.ECS.Model.Setting object.",
        "The service call response (type Amazon.ECS.Model.PutAccountSettingDefaultResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteECSAccountSettingDefaultCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The resource name for which to modify the account setting. If you specify <code>serviceLongArnFormat</code>,
        /// the ARN for your Amazon ECS services is affected. If you specify <code>taskLongArnFormat</code>,
        /// the ARN and resource ID for your Amazon ECS tasks is affected. If you specify <code>containerInstanceLongArnFormat</code>,
        /// the ARN and resource ID for your Amazon ECS container instances is affected. If you
        /// specify <code>awsvpcTrunking</code>, the ENI limit for your Amazon ECS container instances
        /// is affected. If you specify <code>containerInsights</code>, the default setting for
        /// Amazon Web Services CloudWatch Container Insights for your clusters is affected. If
        /// you specify <code>tagResourceAuthorization</code>, the opt-in option for tagging resources
        /// on creation is affected. For information about the opt-in timeline, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-account-settings.html#tag-resources">Tagging
        /// authorization timeline</a> in the <i>Amazon ECS Developer Guide</i>. If you specify
        /// <code>fargateTaskRetirementWaitPeriod</code>, the default wait time to retire a Fargate
        /// task due to required maintenance is affected.</para><para>When you specify <code>fargateFIPSMode</code> for the <code>name</code> and <code>enabled</code>
        /// for the <code>value</code>, Fargate uses FIPS-140 compliant cryptographic algorithms
        /// on your tasks. For more information about FIPS-140 compliance with Fargate, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-fips-compliance.html">
        /// Amazon Web Services Fargate Federal Information Processing Standard (FIPS) 140-2 compliance</a>
        /// in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><para>When Amazon Web Services determines that a security or infrastructure update is needed
        /// for an Amazon ECS task hosted on Fargate, the tasks need to be stopped and new tasks
        /// launched to replace them. Use <code>fargateTaskRetirementWaitPeriod</code> to set
        /// the wait time to retire a Fargate task to the default. For information about the Fargate
        /// tasks maintenance, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-maintenance.html">Amazon
        /// Web Services Fargate task maintenance</a> in the <i>Amazon ECS Developer Guide</i>.</para><para>The <code>guardDutyActivate</code> parameter is read-only in Amazon ECS and indicates
        /// whether Amazon ECS Runtime Monitoring is enabled or disabled by your security administrator
        /// in your Amazon ECS account. Amazon GuardDuty controls this account setting on your
        /// behalf. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-guard-duty-integration.html">Protecting
        /// Amazon ECS workloads with Amazon ECS Runtime Monitoring</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ECS.SettingName")]
        public Amazon.ECS.SettingName Name { get; set; }
        #endregion
        
        #region Parameter Value
        /// <summary>
        /// <para>
        /// <para>The account setting value for the specified principal ARN. Accepted values are <code>enabled</code>,
        /// <code>disabled</code>, <code>on</code>, and <code>off</code>.</para><para>When you specify <code>fargateTaskRetirementWaitPeriod</code> for the <code>name</code>,
        /// the following are the valid values:</para><ul><li><para><code>0</code> - Amazon Web Services sends the notification, and immediately retires
        /// the affected tasks.</para></li><li><para><code>7</code> - Amazon Web Services sends the notification, and waits 7 calendar
        /// days to retire the tasks.</para></li><li><para><code>14</code> - Amazon Web Services sends the notification, and waits 14 calendar
        /// days to retire the tasks.</para></li></ul>
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
        public System.String Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Setting'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.PutAccountSettingDefaultResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.PutAccountSettingDefaultResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Setting";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ECSAccountSettingDefault (PutAccountSettingDefault)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.PutAccountSettingDefaultResponse, WriteECSAccountSettingDefaultCmdlet>(Select) ??
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
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Value = this.Value;
            #if MODULAR
            if (this.Value == null && ParameterWasBound(nameof(this.Value)))
            {
                WriteWarning("You are passing $null as a value for parameter Value which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.PutAccountSettingDefaultRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Value != null)
            {
                request.Value = cmdletContext.Value;
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
        
        private Amazon.ECS.Model.PutAccountSettingDefaultResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.PutAccountSettingDefaultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "PutAccountSettingDefault");
            try
            {
                #if DESKTOP
                return client.PutAccountSettingDefault(request);
                #elif CORECLR
                return client.PutAccountSettingDefaultAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ECS.SettingName Name { get; set; }
            public System.String Value { get; set; }
            public System.Func<Amazon.ECS.Model.PutAccountSettingDefaultResponse, WriteECSAccountSettingDefaultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Setting;
        }
        
    }
}

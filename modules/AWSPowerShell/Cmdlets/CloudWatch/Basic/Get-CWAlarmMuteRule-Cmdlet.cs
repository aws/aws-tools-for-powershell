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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Retrieves details for a specific alarm mute rule.
    /// 
    ///  
    /// <para>
    /// This operation returns complete information about the mute rule, including its configuration,
    /// status, targeted alarms, and metadata.
    /// </para><para>
    /// The returned status indicates the current state of the mute rule:
    /// </para><ul><li><para><b>SCHEDULED</b>: The mute rule is configured and will become active in the future
    /// </para></li><li><para><b>ACTIVE</b>: The mute rule is currently muting alarm actions
    /// </para></li><li><para><b>EXPIRED</b>: The mute rule has passed its expiration date and will no longer become
    /// active
    /// </para></li></ul><para><b>Permissions</b></para><para>
    /// To retrieve details for a mute rule, you need the <c>cloudwatch:GetAlarmMuteRule</c>
    /// permission on the alarm mute rule resource.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWAlarmMuteRule")]
    [OutputType("Amazon.CloudWatch.Model.GetAlarmMuteRuleResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch GetAlarmMuteRule API operation.", Operation = new[] {"GetAlarmMuteRule"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.GetAlarmMuteRuleResponse))]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.GetAlarmMuteRuleResponse",
        "This cmdlet returns an Amazon.CloudWatch.Model.GetAlarmMuteRuleResponse object containing multiple properties."
    )]
    public partial class GetCWAlarmMuteRuleCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AlarmMuteRuleName
        /// <summary>
        /// <para>
        /// <para>The name of the alarm mute rule to retrieve.</para>
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
        public System.String AlarmMuteRuleName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.GetAlarmMuteRuleResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.GetAlarmMuteRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AlarmMuteRuleName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AlarmMuteRuleName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AlarmMuteRuleName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.GetAlarmMuteRuleResponse, GetCWAlarmMuteRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AlarmMuteRuleName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AlarmMuteRuleName = this.AlarmMuteRuleName;
            #if MODULAR
            if (this.AlarmMuteRuleName == null && ParameterWasBound(nameof(this.AlarmMuteRuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter AlarmMuteRuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatch.Model.GetAlarmMuteRuleRequest();
            
            if (cmdletContext.AlarmMuteRuleName != null)
            {
                request.AlarmMuteRuleName = cmdletContext.AlarmMuteRuleName;
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
        
        private Amazon.CloudWatch.Model.GetAlarmMuteRuleResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.GetAlarmMuteRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "GetAlarmMuteRule");
            try
            {
                #if DESKTOP
                return client.GetAlarmMuteRule(request);
                #elif CORECLR
                return client.GetAlarmMuteRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String AlarmMuteRuleName { get; set; }
            public System.Func<Amazon.CloudWatch.Model.GetAlarmMuteRuleResponse, GetCWAlarmMuteRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

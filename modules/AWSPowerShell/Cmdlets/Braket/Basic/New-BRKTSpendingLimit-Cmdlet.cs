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
using Amazon.Braket;
using Amazon.Braket.Model;

namespace Amazon.PowerShell.Cmdlets.BRKT
{
    /// <summary>
    /// Creates a spending limit for a specified quantum device. Spending limits help you
    /// control costs by setting maximum amounts that can be spent on quantum computing tasks
    /// within a specified time period. Simulators do not support spending limits.
    /// </summary>
    [Cmdlet("New", "BRKTSpendingLimit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Braket CreateSpendingLimit API operation.", Operation = new[] {"CreateSpendingLimit"}, SelectReturnType = typeof(Amazon.Braket.Model.CreateSpendingLimitResponse))]
    [AWSCmdletOutput("System.String or Amazon.Braket.Model.CreateSpendingLimitResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Braket.Model.CreateSpendingLimitResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBRKTSpendingLimitCmdlet : AmazonBraketClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeviceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the quantum device to apply the spending limit to.</para>
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
        public System.String DeviceArn { get; set; }
        #endregion
        
        #region Parameter TimePeriod_EndAt
        /// <summary>
        /// <para>
        /// <para>The end date and time for the spending limit period, in epoch seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimePeriod_EndAt { get; set; }
        #endregion
        
        #region Parameter SpendingLimit
        /// <summary>
        /// <para>
        /// <para>The maximum amount that can be spent on the specified device, in USD.</para>
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
        public System.String SpendingLimit { get; set; }
        #endregion
        
        #region Parameter TimePeriod_StartAt
        /// <summary>
        /// <para>
        /// <para>The start date and time for the spending limit period, in epoch seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimePeriod_StartAt { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the spending limit. Each tag consists of a key and an optional
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, Amazon Braket ignores the
        /// request, but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SpendingLimitArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Braket.Model.CreateSpendingLimitResponse).
        /// Specifying the name of a property of type Amazon.Braket.Model.CreateSpendingLimitResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SpendingLimitArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SpendingLimit), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BRKTSpendingLimit (CreateSpendingLimit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Braket.Model.CreateSpendingLimitResponse, NewBRKTSpendingLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DeviceArn = this.DeviceArn;
            #if MODULAR
            if (this.DeviceArn == null && ParameterWasBound(nameof(this.DeviceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SpendingLimit = this.SpendingLimit;
            #if MODULAR
            if (this.SpendingLimit == null && ParameterWasBound(nameof(this.SpendingLimit)))
            {
                WriteWarning("You are passing $null as a value for parameter SpendingLimit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TimePeriod_EndAt = this.TimePeriod_EndAt;
            context.TimePeriod_StartAt = this.TimePeriod_StartAt;
            
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
            var request = new Amazon.Braket.Model.CreateSpendingLimitRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeviceArn != null)
            {
                request.DeviceArn = cmdletContext.DeviceArn;
            }
            if (cmdletContext.SpendingLimit != null)
            {
                request.SpendingLimit = cmdletContext.SpendingLimit;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TimePeriod
            var requestTimePeriodIsNull = true;
            request.TimePeriod = new Amazon.Braket.Model.TimePeriod();
            System.DateTime? requestTimePeriod_timePeriod_EndAt = null;
            if (cmdletContext.TimePeriod_EndAt != null)
            {
                requestTimePeriod_timePeriod_EndAt = cmdletContext.TimePeriod_EndAt.Value;
            }
            if (requestTimePeriod_timePeriod_EndAt != null)
            {
                request.TimePeriod.EndAt = requestTimePeriod_timePeriod_EndAt.Value;
                requestTimePeriodIsNull = false;
            }
            System.DateTime? requestTimePeriod_timePeriod_StartAt = null;
            if (cmdletContext.TimePeriod_StartAt != null)
            {
                requestTimePeriod_timePeriod_StartAt = cmdletContext.TimePeriod_StartAt.Value;
            }
            if (requestTimePeriod_timePeriod_StartAt != null)
            {
                request.TimePeriod.StartAt = requestTimePeriod_timePeriod_StartAt.Value;
                requestTimePeriodIsNull = false;
            }
             // determine if request.TimePeriod should be set to null
            if (requestTimePeriodIsNull)
            {
                request.TimePeriod = null;
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
        
        private Amazon.Braket.Model.CreateSpendingLimitResponse CallAWSServiceOperation(IAmazonBraket client, Amazon.Braket.Model.CreateSpendingLimitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Braket", "CreateSpendingLimit");
            try
            {
                #if DESKTOP
                return client.CreateSpendingLimit(request);
                #elif CORECLR
                return client.CreateSpendingLimitAsync(request).GetAwaiter().GetResult();
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
            public System.String DeviceArn { get; set; }
            public System.String SpendingLimit { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.DateTime? TimePeriod_EndAt { get; set; }
            public System.DateTime? TimePeriod_StartAt { get; set; }
            public System.Func<Amazon.Braket.Model.CreateSpendingLimitResponse, NewBRKTSpendingLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SpendingLimitArn;
        }
        
    }
}

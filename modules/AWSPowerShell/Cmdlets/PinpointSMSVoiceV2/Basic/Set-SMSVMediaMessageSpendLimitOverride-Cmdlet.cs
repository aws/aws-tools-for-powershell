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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Sets an account level monthly spend limit override for sending MMS messages. The requested
    /// spend limit must be less than or equal to the <c>MaxLimit</c>, which is set by Amazon
    /// Web Services.
    /// </summary>
    [Cmdlet("Set", "SMSVMediaMessageSpendLimitOverride", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 SetMediaMessageSpendLimitOverride API operation.", Operation = new[] {"SetMediaMessageSpendLimitOverride"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.SetMediaMessageSpendLimitOverrideResponse))]
    [AWSCmdletOutput("System.Int64 or Amazon.PinpointSMSVoiceV2.Model.SetMediaMessageSpendLimitOverrideResponse",
        "This cmdlet returns a collection of System.Int64 objects.",
        "The service call response (type Amazon.PinpointSMSVoiceV2.Model.SetMediaMessageSpendLimitOverrideResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetSMSVMediaMessageSpendLimitOverrideCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MonthlyLimit
        /// <summary>
        /// <para>
        /// <para>The new monthly limit to enforce on text messages.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? MonthlyLimit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MonthlyLimit'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.SetMediaMessageSpendLimitOverrideResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.SetMediaMessageSpendLimitOverrideResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MonthlyLimit";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MonthlyLimit), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SMSVMediaMessageSpendLimitOverride (SetMediaMessageSpendLimitOverride)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.SetMediaMessageSpendLimitOverrideResponse, SetSMSVMediaMessageSpendLimitOverrideCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MonthlyLimit = this.MonthlyLimit;
            #if MODULAR
            if (this.MonthlyLimit == null && ParameterWasBound(nameof(this.MonthlyLimit)))
            {
                WriteWarning("You are passing $null as a value for parameter MonthlyLimit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.SetMediaMessageSpendLimitOverrideRequest();
            
            if (cmdletContext.MonthlyLimit != null)
            {
                request.MonthlyLimit = cmdletContext.MonthlyLimit.Value;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.SetMediaMessageSpendLimitOverrideResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.SetMediaMessageSpendLimitOverrideRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "SetMediaMessageSpendLimitOverride");
            try
            {
                #if DESKTOP
                return client.SetMediaMessageSpendLimitOverride(request);
                #elif CORECLR
                return client.SetMediaMessageSpendLimitOverrideAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? MonthlyLimit { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.SetMediaMessageSpendLimitOverrideResponse, SetSMSVMediaMessageSpendLimitOverrideCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MonthlyLimit;
        }
        
    }
}

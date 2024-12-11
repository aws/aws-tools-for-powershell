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
using Amazon.Snowball;
using Amazon.Snowball.Model;

namespace Amazon.PowerShell.Cmdlets.SNOW
{
    /// <summary>
    /// Updates the long-term pricing type.
    /// </summary>
    [Cmdlet("Update", "SNOWLongTermPricing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Import/Export Snowball UpdateLongTermPricing API operation.", Operation = new[] {"UpdateLongTermPricing"}, SelectReturnType = typeof(Amazon.Snowball.Model.UpdateLongTermPricingResponse))]
    [AWSCmdletOutput("None or Amazon.Snowball.Model.UpdateLongTermPricingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Snowball.Model.UpdateLongTermPricingResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSNOWLongTermPricingCmdlet : AmazonSnowballClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IsLongTermPricingAutoRenew
        /// <summary>
        /// <para>
        /// <para>If set to <c>true</c>, specifies that the current long-term pricing type for the device
        /// should be automatically renewed before the long-term pricing contract expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsLongTermPricingAutoRenew { get; set; }
        #endregion
        
        #region Parameter LongTermPricingId
        /// <summary>
        /// <para>
        /// <para>The ID of the long-term pricing type for the device.</para>
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
        public System.String LongTermPricingId { get; set; }
        #endregion
        
        #region Parameter ReplacementJob
        /// <summary>
        /// <para>
        /// <para>Specifies that a device that is ordered with long-term pricing should be replaced
        /// with a new device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplacementJob { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Snowball.Model.UpdateLongTermPricingResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LongTermPricingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SNOWLongTermPricing (UpdateLongTermPricing)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Snowball.Model.UpdateLongTermPricingResponse, UpdateSNOWLongTermPricingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IsLongTermPricingAutoRenew = this.IsLongTermPricingAutoRenew;
            context.LongTermPricingId = this.LongTermPricingId;
            #if MODULAR
            if (this.LongTermPricingId == null && ParameterWasBound(nameof(this.LongTermPricingId)))
            {
                WriteWarning("You are passing $null as a value for parameter LongTermPricingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplacementJob = this.ReplacementJob;
            
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
            var request = new Amazon.Snowball.Model.UpdateLongTermPricingRequest();
            
            if (cmdletContext.IsLongTermPricingAutoRenew != null)
            {
                request.IsLongTermPricingAutoRenew = cmdletContext.IsLongTermPricingAutoRenew.Value;
            }
            if (cmdletContext.LongTermPricingId != null)
            {
                request.LongTermPricingId = cmdletContext.LongTermPricingId;
            }
            if (cmdletContext.ReplacementJob != null)
            {
                request.ReplacementJob = cmdletContext.ReplacementJob;
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
        
        private Amazon.Snowball.Model.UpdateLongTermPricingResponse CallAWSServiceOperation(IAmazonSnowball client, Amazon.Snowball.Model.UpdateLongTermPricingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Import/Export Snowball", "UpdateLongTermPricing");
            try
            {
                #if DESKTOP
                return client.UpdateLongTermPricing(request);
                #elif CORECLR
                return client.UpdateLongTermPricingAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? IsLongTermPricingAutoRenew { get; set; }
            public System.String LongTermPricingId { get; set; }
            public System.String ReplacementJob { get; set; }
            public System.Func<Amazon.Snowball.Model.UpdateLongTermPricingResponse, UpdateSNOWLongTermPricingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

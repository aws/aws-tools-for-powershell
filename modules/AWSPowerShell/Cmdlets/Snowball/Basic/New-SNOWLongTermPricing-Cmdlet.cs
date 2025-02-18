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
using System.Threading;
using Amazon.Snowball;
using Amazon.Snowball.Model;

namespace Amazon.PowerShell.Cmdlets.SNOW
{
    /// <summary>
    /// Creates a job with the long-term usage option for a device. The long-term usage is
    /// a 1-year or 3-year long-term pricing type for the device. You are billed upfront,
    /// and Amazon Web Services provides discounts for long-term pricing.
    /// </summary>
    [Cmdlet("New", "SNOWLongTermPricing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Import/Export Snowball CreateLongTermPricing API operation.", Operation = new[] {"CreateLongTermPricing"}, SelectReturnType = typeof(Amazon.Snowball.Model.CreateLongTermPricingResponse))]
    [AWSCmdletOutput("System.String or Amazon.Snowball.Model.CreateLongTermPricingResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Snowball.Model.CreateLongTermPricingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSNOWLongTermPricingCmdlet : AmazonSnowballClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IsLongTermPricingAutoRenew
        /// <summary>
        /// <para>
        /// <para>Specifies whether the current long-term pricing type for the device should be renewed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsLongTermPricingAutoRenew { get; set; }
        #endregion
        
        #region Parameter LongTermPricingType
        /// <summary>
        /// <para>
        /// <para>The type of long-term pricing option you want for the device, either 1-year or 3-year
        /// long-term pricing.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Snowball.LongTermPricingType")]
        public Amazon.Snowball.LongTermPricingType LongTermPricingType { get; set; }
        #endregion
        
        #region Parameter SnowballType
        /// <summary>
        /// <para>
        /// <para>The type of Snow Family devices to use for the long-term pricing job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Snowball.SnowballType")]
        public Amazon.Snowball.SnowballType SnowballType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LongTermPricingId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Snowball.Model.CreateLongTermPricingResponse).
        /// Specifying the name of a property of type Amazon.Snowball.Model.CreateLongTermPricingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LongTermPricingId";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LongTermPricingType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SNOWLongTermPricing (CreateLongTermPricing)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Snowball.Model.CreateLongTermPricingResponse, NewSNOWLongTermPricingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IsLongTermPricingAutoRenew = this.IsLongTermPricingAutoRenew;
            context.LongTermPricingType = this.LongTermPricingType;
            #if MODULAR
            if (this.LongTermPricingType == null && ParameterWasBound(nameof(this.LongTermPricingType)))
            {
                WriteWarning("You are passing $null as a value for parameter LongTermPricingType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnowballType = this.SnowballType;
            #if MODULAR
            if (this.SnowballType == null && ParameterWasBound(nameof(this.SnowballType)))
            {
                WriteWarning("You are passing $null as a value for parameter SnowballType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Snowball.Model.CreateLongTermPricingRequest();
            
            if (cmdletContext.IsLongTermPricingAutoRenew != null)
            {
                request.IsLongTermPricingAutoRenew = cmdletContext.IsLongTermPricingAutoRenew.Value;
            }
            if (cmdletContext.LongTermPricingType != null)
            {
                request.LongTermPricingType = cmdletContext.LongTermPricingType;
            }
            if (cmdletContext.SnowballType != null)
            {
                request.SnowballType = cmdletContext.SnowballType;
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
        
        private Amazon.Snowball.Model.CreateLongTermPricingResponse CallAWSServiceOperation(IAmazonSnowball client, Amazon.Snowball.Model.CreateLongTermPricingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Import/Export Snowball", "CreateLongTermPricing");
            try
            {
                return client.CreateLongTermPricingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Snowball.LongTermPricingType LongTermPricingType { get; set; }
            public Amazon.Snowball.SnowballType SnowballType { get; set; }
            public System.Func<Amazon.Snowball.Model.CreateLongTermPricingResponse, NewSNOWLongTermPricingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LongTermPricingId;
        }
        
    }
}

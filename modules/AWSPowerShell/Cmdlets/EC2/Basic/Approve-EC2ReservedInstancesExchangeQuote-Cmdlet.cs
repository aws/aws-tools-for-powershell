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
    /// Accepts the Convertible Reserved Instance exchange quote described in the <a>GetReservedInstancesExchangeQuote</a>
    /// call.
    /// </summary>
    [Cmdlet("Approve", "EC2ReservedInstancesExchangeQuote", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AcceptReservedInstancesExchangeQuote API operation.", Operation = new[] {"AcceptReservedInstancesExchangeQuote"}, SelectReturnType = typeof(Amazon.EC2.Model.AcceptReservedInstancesExchangeQuoteResponse), LegacyAlias="Confirm-EC2ReservedInstancesExchangeQuote")]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.AcceptReservedInstancesExchangeQuoteResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.AcceptReservedInstancesExchangeQuoteResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ApproveEC2ReservedInstancesExchangeQuoteCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ReservedInstanceId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Convertible Reserved Instances to exchange for another Convertible
        /// Reserved Instance of the same or higher value.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ReservedInstanceIds")]
        public System.String[] ReservedInstanceId { get; set; }
        #endregion
        
        #region Parameter TargetConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration of the target Convertible Reserved Instance to exchange for your
        /// current Convertible Reserved Instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfigurations")]
        public Amazon.EC2.Model.TargetConfigurationRequest[] TargetConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExchangeId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AcceptReservedInstancesExchangeQuoteResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AcceptReservedInstancesExchangeQuoteResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExchangeId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReservedInstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-EC2ReservedInstancesExchangeQuote (AcceptReservedInstancesExchangeQuote)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AcceptReservedInstancesExchangeQuoteResponse, ApproveEC2ReservedInstancesExchangeQuoteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ReservedInstanceId != null)
            {
                context.ReservedInstanceId = new List<System.String>(this.ReservedInstanceId);
            }
            #if MODULAR
            if (this.ReservedInstanceId == null && ParameterWasBound(nameof(this.ReservedInstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReservedInstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TargetConfiguration != null)
            {
                context.TargetConfiguration = new List<Amazon.EC2.Model.TargetConfigurationRequest>(this.TargetConfiguration);
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
            var request = new Amazon.EC2.Model.AcceptReservedInstancesExchangeQuoteRequest();
            
            if (cmdletContext.ReservedInstanceId != null)
            {
                request.ReservedInstanceIds = cmdletContext.ReservedInstanceId;
            }
            if (cmdletContext.TargetConfiguration != null)
            {
                request.TargetConfigurations = cmdletContext.TargetConfiguration;
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
        
        private Amazon.EC2.Model.AcceptReservedInstancesExchangeQuoteResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AcceptReservedInstancesExchangeQuoteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AcceptReservedInstancesExchangeQuote");
            try
            {
                #if DESKTOP
                return client.AcceptReservedInstancesExchangeQuote(request);
                #elif CORECLR
                return client.AcceptReservedInstancesExchangeQuoteAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ReservedInstanceId { get; set; }
            public List<Amazon.EC2.Model.TargetConfigurationRequest> TargetConfiguration { get; set; }
            public System.Func<Amazon.EC2.Model.AcceptReservedInstancesExchangeQuoteResponse, ApproveEC2ReservedInstancesExchangeQuoteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExchangeId;
        }
        
    }
}

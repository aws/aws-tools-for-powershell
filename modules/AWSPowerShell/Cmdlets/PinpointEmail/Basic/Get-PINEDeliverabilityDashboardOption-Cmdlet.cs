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
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;

namespace Amazon.PowerShell.Cmdlets.PINE
{
    /// <summary>
    /// Retrieve information about the status of the Deliverability dashboard for your Amazon
    /// Pinpoint account. When the Deliverability dashboard is enabled, you gain access to
    /// reputation, deliverability, and other metrics for the domains that you use to send
    /// email using Amazon Pinpoint. You also gain the ability to perform predictive inbox
    /// placement tests.
    /// 
    ///  
    /// <para>
    /// When you use the Deliverability dashboard, you pay a monthly subscription charge,
    /// in addition to any other fees that you accrue by using Amazon Pinpoint. For more information
    /// about the features and cost of a Deliverability dashboard subscription, see <a href="http://aws.amazon.com/pinpoint/pricing/">Amazon
    /// Pinpoint Pricing</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "PINEDeliverabilityDashboardOption")]
    [OutputType("Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email GetDeliverabilityDashboardOptions API operation.", Operation = new[] {"GetDeliverabilityDashboardOptions"}, SelectReturnType = typeof(Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsResponse))]
    [AWSCmdletOutput("Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsResponse",
        "This cmdlet returns an Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsResponse object containing multiple properties."
    )]
    public partial class GetPINEDeliverabilityDashboardOptionCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsResponse).
        /// Specifying the name of a property of type Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsResponse, GetPINEDeliverabilityDashboardOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsRequest();
            
            
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
        
        private Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsResponse CallAWSServiceOperation(IAmazonPinpointEmail client, Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint Email", "GetDeliverabilityDashboardOptions");
            try
            {
                #if DESKTOP
                return client.GetDeliverabilityDashboardOptions(request);
                #elif CORECLR
                return client.GetDeliverabilityDashboardOptionsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsResponse, GetPINEDeliverabilityDashboardOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

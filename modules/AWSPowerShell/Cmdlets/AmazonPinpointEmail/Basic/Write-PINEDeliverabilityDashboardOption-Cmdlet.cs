/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Enable or disable the Deliverability dashboard. When you enable the Deliverability
    /// dashboard, you gain access to reputation metrics for the domains that you use to send
    /// email using Amazon Pinpoint. You also gain the ability to perform predictive inbox
    /// placement tests.
    /// 
    ///  
    /// <para>
    /// When you use the Deliverability dashboard, you pay a monthly charge of USD$1,250.00,
    /// in addition to any other fees that you accrue by using Amazon Pinpoint. If you enable
    /// the Deliverability dashboard after the first day of a calendar month, we prorate the
    /// monthly charge based on how many days have elapsed in the current calendar month.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "PINEDeliverabilityDashboardOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.Boolean")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email PutDeliverabilityDashboardOption API operation.", Operation = new[] {"PutDeliverabilityDashboardOption"})]
    [AWSCmdletOutput("None or System.Boolean",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the DashboardEnabled parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.PinpointEmail.Model.PutDeliverabilityDashboardOptionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WritePINEDeliverabilityDashboardOptionCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        #region Parameter DashboardEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the Deliverability dashboard is enabled. If the value is <code>true</code>,
        /// then the dashboard is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.Boolean DashboardEnabled { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the DashboardEnabled parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DashboardEnabled", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-PINEDeliverabilityDashboardOption (PutDeliverabilityDashboardOption)"))
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
            
            if (ParameterWasBound("DashboardEnabled"))
                context.DashboardEnabled = this.DashboardEnabled;
            
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
            var request = new Amazon.PinpointEmail.Model.PutDeliverabilityDashboardOptionRequest();
            
            if (cmdletContext.DashboardEnabled != null)
            {
                request.DashboardEnabled = cmdletContext.DashboardEnabled.Value;
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
                    pipelineOutput = this.DashboardEnabled;
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
        
        private Amazon.PinpointEmail.Model.PutDeliverabilityDashboardOptionResponse CallAWSServiceOperation(IAmazonPinpointEmail client, Amazon.PinpointEmail.Model.PutDeliverabilityDashboardOptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint Email", "PutDeliverabilityDashboardOption");
            try
            {
                #if DESKTOP
                return client.PutDeliverabilityDashboardOption(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutDeliverabilityDashboardOptionAsync(request);
                return task.Result;
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
            public System.Boolean? DashboardEnabled { get; set; }
        }
        
    }
}

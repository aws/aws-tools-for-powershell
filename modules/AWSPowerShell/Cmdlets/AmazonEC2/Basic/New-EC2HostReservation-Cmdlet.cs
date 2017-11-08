/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Purchase a reservation with configurations that match those of your Dedicated Host.
    /// You must have active Dedicated Hosts in your account before you purchase a reservation.
    /// This action results in the specified reservation being purchased and charged to your
    /// account.
    /// </summary>
    [Cmdlet("New", "EC2HostReservation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.PurchaseHostReservationResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud PurchaseHostReservation API operation.", Operation = new[] {"PurchaseHostReservation"})]
    [AWSCmdletOutput("Amazon.EC2.Model.PurchaseHostReservationResponse",
        "This cmdlet returns a Amazon.EC2.Model.PurchaseHostReservationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2HostReservationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of the request.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Run_Instance_Idempotency.html">How
        /// to Ensure Idempotency</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter CurrencyCode
        /// <summary>
        /// <para>
        /// <para>The currency in which the <code>totalUpfrontPrice</code>, <code>LimitPrice</code>,
        /// and <code>totalHourlyPrice</code> amounts are specified. At this time, the only supported
        /// currency is <code>USD</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.CurrencyCodeValues")]
        public Amazon.EC2.CurrencyCodeValues CurrencyCode { get; set; }
        #endregion
        
        #region Parameter HostIdSet
        /// <summary>
        /// <para>
        /// <para>The ID/s of the Dedicated Host/s that the reservation will be associated with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] HostIdSet { get; set; }
        #endregion
        
        #region Parameter LimitPrice
        /// <summary>
        /// <para>
        /// <para>The specified limit is checked against the total upfront cost of the reservation (calculated
        /// as the offering's upfront cost multiplied by the host count). If the total upfront
        /// cost is greater than the specified price limit, the request will fail. This is used
        /// to ensure that the purchase does not exceed the expected upfront cost of the purchase.
        /// At this time, the only supported currency is <code>USD</code>. For example, to indicate
        /// a limit price of USD 100, specify 100.00.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LimitPrice { get; set; }
        #endregion
        
        #region Parameter OfferingId
        /// <summary>
        /// <para>
        /// <para>The ID of the offering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String OfferingId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("OfferingId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2HostReservation (PurchaseHostReservation)"))
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
            
            context.ClientToken = this.ClientToken;
            context.CurrencyCode = this.CurrencyCode;
            if (this.HostIdSet != null)
            {
                context.HostIdSet = new List<System.String>(this.HostIdSet);
            }
            context.LimitPrice = this.LimitPrice;
            context.OfferingId = this.OfferingId;
            
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
            var request = new Amazon.EC2.Model.PurchaseHostReservationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CurrencyCode != null)
            {
                request.CurrencyCode = cmdletContext.CurrencyCode;
            }
            if (cmdletContext.HostIdSet != null)
            {
                request.HostIdSet = cmdletContext.HostIdSet;
            }
            if (cmdletContext.LimitPrice != null)
            {
                request.LimitPrice = cmdletContext.LimitPrice;
            }
            if (cmdletContext.OfferingId != null)
            {
                request.OfferingId = cmdletContext.OfferingId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.EC2.Model.PurchaseHostReservationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.PurchaseHostReservationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "PurchaseHostReservation");
            try
            {
                #if DESKTOP
                return client.PurchaseHostReservation(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PurchaseHostReservationAsync(request);
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
            public System.String ClientToken { get; set; }
            public Amazon.EC2.CurrencyCodeValues CurrencyCode { get; set; }
            public List<System.String> HostIdSet { get; set; }
            public System.String LimitPrice { get; set; }
            public System.String OfferingId { get; set; }
        }
        
    }
}

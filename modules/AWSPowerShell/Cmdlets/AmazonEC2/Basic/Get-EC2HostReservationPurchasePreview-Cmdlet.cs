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
    /// Preview a reservation purchase with configurations that match those of your Dedicated
    /// Host. You must have active Dedicated Hosts in your account before you purchase a reservation.
    /// 
    ///  
    /// <para>
    /// This is a preview of the <a>PurchaseHostReservation</a> action and does not result
    /// in the offering being purchased.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2HostReservationPurchasePreview")]
    [OutputType("Amazon.EC2.Model.GetHostReservationPurchasePreviewResponse")]
    [AWSCmdlet("Invokes the GetHostReservationPurchasePreview operation against Amazon Elastic Compute Cloud.", Operation = new[] {"GetHostReservationPurchasePreview"})]
    [AWSCmdletOutput("Amazon.EC2.Model.GetHostReservationPurchasePreviewResponse",
        "This cmdlet returns a Amazon.EC2.Model.GetHostReservationPurchasePreviewResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2HostReservationPurchasePreviewCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter HostIdSet
        /// <summary>
        /// <para>
        /// <para>The ID/s of the Dedicated Host/s that the reservation will be associated with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] HostIdSet { get; set; }
        #endregion
        
        #region Parameter OfferingId
        /// <summary>
        /// <para>
        /// <para>The offering ID of the reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String OfferingId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.HostIdSet != null)
            {
                context.HostIdSet = new List<System.String>(this.HostIdSet);
            }
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
            var request = new Amazon.EC2.Model.GetHostReservationPurchasePreviewRequest();
            
            if (cmdletContext.HostIdSet != null)
            {
                request.HostIdSet = cmdletContext.HostIdSet;
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
        
        private Amazon.EC2.Model.GetHostReservationPurchasePreviewResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetHostReservationPurchasePreviewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "GetHostReservationPurchasePreview");
            try
            {
                #if DESKTOP
                return client.GetHostReservationPurchasePreview(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetHostReservationPurchasePreviewAsync(request);
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
            public List<System.String> HostIdSet { get; set; }
            public System.String OfferingId { get; set; }
        }
        
    }
}

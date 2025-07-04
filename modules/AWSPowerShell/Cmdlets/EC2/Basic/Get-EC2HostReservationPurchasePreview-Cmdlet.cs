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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
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
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetHostReservationPurchasePreview API operation.", Operation = new[] {"GetHostReservationPurchasePreview"}, SelectReturnType = typeof(Amazon.EC2.Model.GetHostReservationPurchasePreviewResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.GetHostReservationPurchasePreviewResponse",
        "This cmdlet returns an Amazon.EC2.Model.GetHostReservationPurchasePreviewResponse object containing multiple properties."
    )]
    public partial class GetEC2HostReservationPurchasePreviewCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HostIdSet
        /// <summary>
        /// <para>
        /// <para>The IDs of the Dedicated Hosts with which the reservation is associated.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] HostIdSet { get; set; }
        #endregion
        
        #region Parameter OfferingId
        /// <summary>
        /// <para>
        /// <para>The offering ID of the reservation.</para>
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
        public System.String OfferingId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetHostReservationPurchasePreviewResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetHostReservationPurchasePreviewResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetHostReservationPurchasePreviewResponse, GetEC2HostReservationPurchasePreviewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.HostIdSet != null)
            {
                context.HostIdSet = new List<System.String>(this.HostIdSet);
            }
            #if MODULAR
            if (this.HostIdSet == null && ParameterWasBound(nameof(this.HostIdSet)))
            {
                WriteWarning("You are passing $null as a value for parameter HostIdSet which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OfferingId = this.OfferingId;
            #if MODULAR
            if (this.OfferingId == null && ParameterWasBound(nameof(this.OfferingId)))
            {
                WriteWarning("You are passing $null as a value for parameter OfferingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
        
        private Amazon.EC2.Model.GetHostReservationPurchasePreviewResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetHostReservationPurchasePreviewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetHostReservationPurchasePreview");
            try
            {
                return client.GetHostReservationPurchasePreviewAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.EC2.Model.GetHostReservationPurchasePreviewResponse, GetEC2HostReservationPurchasePreviewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

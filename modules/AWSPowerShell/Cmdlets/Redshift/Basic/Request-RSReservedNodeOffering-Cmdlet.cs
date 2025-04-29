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
using Amazon.Redshift;
using Amazon.Redshift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Allows you to purchase reserved nodes. Amazon Redshift offers a predefined set of
    /// reserved node offerings. You can purchase one or more of the offerings. You can call
    /// the <a>DescribeReservedNodeOfferings</a> API to obtain the available reserved node
    /// offerings. You can call this API by providing a specific reserved node offering and
    /// the number of nodes you want to reserve. 
    /// 
    ///  
    /// <para>
    ///  For more information about reserved node offerings, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/purchase-reserved-node-instance.html">Purchasing
    /// Reserved Nodes</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Request", "RSReservedNodeOffering", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.ReservedNode")]
    [AWSCmdlet("Calls the Amazon Redshift PurchaseReservedNodeOffering API operation.", Operation = new[] {"PurchaseReservedNodeOffering"}, SelectReturnType = typeof(Amazon.Redshift.Model.PurchaseReservedNodeOfferingResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.ReservedNode or Amazon.Redshift.Model.PurchaseReservedNodeOfferingResponse",
        "This cmdlet returns an Amazon.Redshift.Model.ReservedNode object.",
        "The service call response (type Amazon.Redshift.Model.PurchaseReservedNodeOfferingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RequestRSReservedNodeOfferingCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NodeCount
        /// <summary>
        /// <para>
        /// <para>The number of reserved nodes that you want to purchase.</para><para>Default: <c>1</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.Int32? NodeCount { get; set; }
        #endregion
        
        #region Parameter ReservedNodeOfferingId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the reserved node offering you want to purchase.</para>
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
        public System.String ReservedNodeOfferingId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReservedNode'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.PurchaseReservedNodeOfferingResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.PurchaseReservedNodeOfferingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReservedNode";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReservedNodeOfferingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-RSReservedNodeOffering (PurchaseReservedNodeOffering)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.PurchaseReservedNodeOfferingResponse, RequestRSReservedNodeOfferingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NodeCount = this.NodeCount;
            context.ReservedNodeOfferingId = this.ReservedNodeOfferingId;
            #if MODULAR
            if (this.ReservedNodeOfferingId == null && ParameterWasBound(nameof(this.ReservedNodeOfferingId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReservedNodeOfferingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Redshift.Model.PurchaseReservedNodeOfferingRequest();
            
            if (cmdletContext.NodeCount != null)
            {
                request.NodeCount = cmdletContext.NodeCount.Value;
            }
            if (cmdletContext.ReservedNodeOfferingId != null)
            {
                request.ReservedNodeOfferingId = cmdletContext.ReservedNodeOfferingId;
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
        
        private Amazon.Redshift.Model.PurchaseReservedNodeOfferingResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.PurchaseReservedNodeOfferingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "PurchaseReservedNodeOffering");
            try
            {
                return client.PurchaseReservedNodeOfferingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? NodeCount { get; set; }
            public System.String ReservedNodeOfferingId { get; set; }
            public System.Func<Amazon.Redshift.Model.PurchaseReservedNodeOfferingResponse, RequestRSReservedNodeOfferingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReservedNode;
        }
        
    }
}

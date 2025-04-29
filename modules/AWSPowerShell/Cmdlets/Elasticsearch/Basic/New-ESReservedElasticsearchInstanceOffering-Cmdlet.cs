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
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Allows you to purchase reserved Elasticsearch instances.
    /// </summary>
    [Cmdlet("New", "ESReservedElasticsearchInstanceOffering", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse")]
    [AWSCmdlet("Calls the Amazon Elasticsearch PurchaseReservedElasticsearchInstanceOffering API operation.", Operation = new[] {"PurchaseReservedElasticsearchInstanceOffering"}, SelectReturnType = typeof(Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse))]
    [AWSCmdletOutput("Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse",
        "This cmdlet returns an Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse object containing multiple properties."
    )]
    public partial class NewESReservedElasticsearchInstanceOfferingCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of Elasticsearch instances to reserve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceCount { get; set; }
        #endregion
        
        #region Parameter ReservationName
        /// <summary>
        /// <para>
        /// <para>A customer-specified identifier to track this reservation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ReservationName { get; set; }
        #endregion
        
        #region Parameter ReservedElasticsearchInstanceOfferingId
        /// <summary>
        /// <para>
        /// <para>The ID of the reserved Elasticsearch instance offering to purchase.</para>
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
        public System.String ReservedElasticsearchInstanceOfferingId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse).
        /// Specifying the name of a property of type Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReservedElasticsearchInstanceOfferingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ESReservedElasticsearchInstanceOffering (PurchaseReservedElasticsearchInstanceOffering)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse, NewESReservedElasticsearchInstanceOfferingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceCount = this.InstanceCount;
            context.ReservationName = this.ReservationName;
            #if MODULAR
            if (this.ReservationName == null && ParameterWasBound(nameof(this.ReservationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ReservationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReservedElasticsearchInstanceOfferingId = this.ReservedElasticsearchInstanceOfferingId;
            #if MODULAR
            if (this.ReservedElasticsearchInstanceOfferingId == null && ParameterWasBound(nameof(this.ReservedElasticsearchInstanceOfferingId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReservedElasticsearchInstanceOfferingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingRequest();
            
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            if (cmdletContext.ReservationName != null)
            {
                request.ReservationName = cmdletContext.ReservationName;
            }
            if (cmdletContext.ReservedElasticsearchInstanceOfferingId != null)
            {
                request.ReservedElasticsearchInstanceOfferingId = cmdletContext.ReservedElasticsearchInstanceOfferingId;
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
        
        private Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "PurchaseReservedElasticsearchInstanceOffering");
            try
            {
                return client.PurchaseReservedElasticsearchInstanceOfferingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? InstanceCount { get; set; }
            public System.String ReservationName { get; set; }
            public System.String ReservedElasticsearchInstanceOfferingId { get; set; }
            public System.Func<Amazon.Elasticsearch.Model.PurchaseReservedElasticsearchInstanceOfferingResponse, NewESReservedElasticsearchInstanceOfferingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

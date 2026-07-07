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
using Amazon.PartnerCentralRevenueMeasurement;
using Amazon.PartnerCentralRevenueMeasurement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCRM
{
    /// <summary>
    /// Submits a batch of up to 250 allocation changes (CREATE and/or UPDATE) for asynchronous
    /// processing. Returns a TaskId for tracking.
    /// </summary>
    [Cmdlet("Start", "PCRMRevenueAttributionAllocationsTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralRevenueMeasurement.Model.StartRevenueAttributionAllocationsTaskResponse")]
    [AWSCmdlet("Calls the Partner Central Revenue Measurement API StartRevenueAttributionAllocationsTask API operation.", Operation = new[] {"StartRevenueAttributionAllocationsTask"}, SelectReturnType = typeof(Amazon.PartnerCentralRevenueMeasurement.Model.StartRevenueAttributionAllocationsTaskResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralRevenueMeasurement.Model.StartRevenueAttributionAllocationsTaskResponse",
        "This cmdlet returns an Amazon.PartnerCentralRevenueMeasurement.Model.StartRevenueAttributionAllocationsTaskResponse object containing multiple properties."
    )]
    public partial class StartPCRMRevenueAttributionAllocationsTaskCmdlet : AmazonPartnerCentralRevenueMeasurementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog context for this operation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralRevenueMeasurement.CatalogName")]
        public Amazon.PartnerCentralRevenueMeasurement.CatalogName Catalog { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Human-readable description of the batch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RevenueAttributionIdentifier
        /// <summary>
        /// <para>
        /// <para>The revenue attribution identifier.</para>
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
        public System.String RevenueAttributionIdentifier { get; set; }
        #endregion
        
        #region Parameter RevenueAttributionRevision
        /// <summary>
        /// <para>
        /// <para>Current revision of the revenue attribution for optimistic locking.</para>
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
        public System.String RevenueAttributionRevision { get; set; }
        #endregion
        
        #region Parameter RevenueShareAllocation
        /// <summary>
        /// <para>
        /// <para>The list of allocation changes to process in this batch.</para><para />
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
        [Alias("RevenueShareAllocations")]
        public Amazon.PartnerCentralRevenueMeasurement.Model.RevenueShareAllocation[] RevenueShareAllocation { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token for deduplication and retry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralRevenueMeasurement.Model.StartRevenueAttributionAllocationsTaskResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralRevenueMeasurement.Model.StartRevenueAttributionAllocationsTaskResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RevenueAttributionIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-PCRMRevenueAttributionAllocationsTask (StartRevenueAttributionAllocationsTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralRevenueMeasurement.Model.StartRevenueAttributionAllocationsTaskResponse, StartPCRMRevenueAttributionAllocationsTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.RevenueAttributionIdentifier = this.RevenueAttributionIdentifier;
            #if MODULAR
            if (this.RevenueAttributionIdentifier == null && ParameterWasBound(nameof(this.RevenueAttributionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter RevenueAttributionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevenueAttributionRevision = this.RevenueAttributionRevision;
            #if MODULAR
            if (this.RevenueAttributionRevision == null && ParameterWasBound(nameof(this.RevenueAttributionRevision)))
            {
                WriteWarning("You are passing $null as a value for parameter RevenueAttributionRevision which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RevenueShareAllocation != null)
            {
                context.RevenueShareAllocation = new List<Amazon.PartnerCentralRevenueMeasurement.Model.RevenueShareAllocation>(this.RevenueShareAllocation);
            }
            #if MODULAR
            if (this.RevenueShareAllocation == null && ParameterWasBound(nameof(this.RevenueShareAllocation)))
            {
                WriteWarning("You are passing $null as a value for parameter RevenueShareAllocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PartnerCentralRevenueMeasurement.Model.StartRevenueAttributionAllocationsTaskRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.RevenueAttributionIdentifier != null)
            {
                request.RevenueAttributionIdentifier = cmdletContext.RevenueAttributionIdentifier;
            }
            if (cmdletContext.RevenueAttributionRevision != null)
            {
                request.RevenueAttributionRevision = cmdletContext.RevenueAttributionRevision;
            }
            if (cmdletContext.RevenueShareAllocation != null)
            {
                request.RevenueShareAllocations = cmdletContext.RevenueShareAllocation;
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
        
        private Amazon.PartnerCentralRevenueMeasurement.Model.StartRevenueAttributionAllocationsTaskResponse CallAWSServiceOperation(IAmazonPartnerCentralRevenueMeasurement client, Amazon.PartnerCentralRevenueMeasurement.Model.StartRevenueAttributionAllocationsTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Revenue Measurement API", "StartRevenueAttributionAllocationsTask");
            try
            {
                return client.StartRevenueAttributionAllocationsTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.PartnerCentralRevenueMeasurement.CatalogName Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String RevenueAttributionIdentifier { get; set; }
            public System.String RevenueAttributionRevision { get; set; }
            public List<Amazon.PartnerCentralRevenueMeasurement.Model.RevenueShareAllocation> RevenueShareAllocation { get; set; }
            public System.Func<Amazon.PartnerCentralRevenueMeasurement.Model.StartRevenueAttributionAllocationsTaskResponse, StartPCRMRevenueAttributionAllocationsTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

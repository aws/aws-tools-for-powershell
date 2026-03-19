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
using Amazon.Batch;
using Amazon.Batch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Updates a quota share.
    /// </summary>
    [Cmdlet("Update", "BATQuotaShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.UpdateQuotaShareResponse")]
    [AWSCmdlet("Calls the AWS Batch UpdateQuotaShare API operation.", Operation = new[] {"UpdateQuotaShare"}, SelectReturnType = typeof(Amazon.Batch.Model.UpdateQuotaShareResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.UpdateQuotaShareResponse",
        "This cmdlet returns an Amazon.Batch.Model.UpdateQuotaShareResponse object containing multiple properties."
    )]
    public partial class UpdateBATQuotaShareCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResourceSharingConfiguration_BorrowLimit
        /// <summary>
        /// <para>
        /// <para>The maximum percentage of additional capacity that the quota share can borrow from
        /// other shares. <c>borrowLimit</c> can only be applied to quota shares with a strategy
        /// of <c>LEND_AND_BORROW</c>. This value is expressed as a percentage of the quota share's
        /// configured <a href="https://docs.aws.amazon.com/batch/latest/APIReference/API_QuotaShareCapacityLimit.html">CapacityLimits</a>.</para><para>The <c>borrowLimit</c> is applied uniformly across all capacity units. For example,
        /// if the <c>borrowLimit</c> is 200, the quota share can borrow up to 200% of its configured
        /// <c>maxCapacity</c> for each capacity unit. The default <c>borrowLimit</c> is -1, which
        /// indicates unlimited borrowing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourceSharingConfiguration_BorrowLimit { get; set; }
        #endregion
        
        #region Parameter CapacityLimit
        /// <summary>
        /// <para>
        /// <para>A list that specifies the quantity and type of compute capacity allocated to the quota
        /// share.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityLimits")]
        public Amazon.Batch.Model.QuotaShareCapacityLimit[] CapacityLimit { get; set; }
        #endregion
        
        #region Parameter PreemptionConfiguration_InSharePreemption
        /// <summary>
        /// <para>
        /// <para>Specifies whether jobs within a quota share can be preempted by another, higher priority
        /// job in the same quota share.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.QuotaShareInSharePreemptionState")]
        public Amazon.Batch.QuotaShareInSharePreemptionState PreemptionConfiguration_InSharePreemption { get; set; }
        #endregion
        
        #region Parameter QuotaShareArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the quota share to update.</para>
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
        public System.String QuotaShareArn { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The state of the quota share. If the quota share is <c>ENABLED</c>, it is able to
        /// accept jobs. If the quota share is <c>DISABLED</c>, new jobs won't be accepted but
        /// jobs already submitted can finish.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.QuotaShareState")]
        public Amazon.Batch.QuotaShareState State { get; set; }
        #endregion
        
        #region Parameter ResourceSharingConfiguration_Strategy
        /// <summary>
        /// <para>
        /// <para>The resource sharing strategy for the quota share. The <c>RESERVE</c> strategy allows
        /// a quota share to reserve idle capacity for itself. <c>LEND</c> configures the share
        /// to lend its idle capacity to another share in need of capacity. The <c>LEND_AND_BORROW</c>
        /// strategy configures the share to borrow idle capacity from an underutilized share,
        /// as well as lend to another share.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.QuotaShareResourceSharingStrategy")]
        public Amazon.Batch.QuotaShareResourceSharingStrategy ResourceSharingConfiguration_Strategy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.UpdateQuotaShareResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.UpdateQuotaShareResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QuotaShareArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BATQuotaShare (UpdateQuotaShare)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.UpdateQuotaShareResponse, UpdateBATQuotaShareCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CapacityLimit != null)
            {
                context.CapacityLimit = new List<Amazon.Batch.Model.QuotaShareCapacityLimit>(this.CapacityLimit);
            }
            context.PreemptionConfiguration_InSharePreemption = this.PreemptionConfiguration_InSharePreemption;
            context.QuotaShareArn = this.QuotaShareArn;
            #if MODULAR
            if (this.QuotaShareArn == null && ParameterWasBound(nameof(this.QuotaShareArn)))
            {
                WriteWarning("You are passing $null as a value for parameter QuotaShareArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceSharingConfiguration_BorrowLimit = this.ResourceSharingConfiguration_BorrowLimit;
            context.ResourceSharingConfiguration_Strategy = this.ResourceSharingConfiguration_Strategy;
            context.State = this.State;
            
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
            var request = new Amazon.Batch.Model.UpdateQuotaShareRequest();
            
            if (cmdletContext.CapacityLimit != null)
            {
                request.CapacityLimits = cmdletContext.CapacityLimit;
            }
            
             // populate PreemptionConfiguration
            var requestPreemptionConfigurationIsNull = true;
            request.PreemptionConfiguration = new Amazon.Batch.Model.QuotaSharePreemptionConfiguration();
            Amazon.Batch.QuotaShareInSharePreemptionState requestPreemptionConfiguration_preemptionConfiguration_InSharePreemption = null;
            if (cmdletContext.PreemptionConfiguration_InSharePreemption != null)
            {
                requestPreemptionConfiguration_preemptionConfiguration_InSharePreemption = cmdletContext.PreemptionConfiguration_InSharePreemption;
            }
            if (requestPreemptionConfiguration_preemptionConfiguration_InSharePreemption != null)
            {
                request.PreemptionConfiguration.InSharePreemption = requestPreemptionConfiguration_preemptionConfiguration_InSharePreemption;
                requestPreemptionConfigurationIsNull = false;
            }
             // determine if request.PreemptionConfiguration should be set to null
            if (requestPreemptionConfigurationIsNull)
            {
                request.PreemptionConfiguration = null;
            }
            if (cmdletContext.QuotaShareArn != null)
            {
                request.QuotaShareArn = cmdletContext.QuotaShareArn;
            }
            
             // populate ResourceSharingConfiguration
            var requestResourceSharingConfigurationIsNull = true;
            request.ResourceSharingConfiguration = new Amazon.Batch.Model.QuotaShareResourceSharingConfiguration();
            System.Int32? requestResourceSharingConfiguration_resourceSharingConfiguration_BorrowLimit = null;
            if (cmdletContext.ResourceSharingConfiguration_BorrowLimit != null)
            {
                requestResourceSharingConfiguration_resourceSharingConfiguration_BorrowLimit = cmdletContext.ResourceSharingConfiguration_BorrowLimit.Value;
            }
            if (requestResourceSharingConfiguration_resourceSharingConfiguration_BorrowLimit != null)
            {
                request.ResourceSharingConfiguration.BorrowLimit = requestResourceSharingConfiguration_resourceSharingConfiguration_BorrowLimit.Value;
                requestResourceSharingConfigurationIsNull = false;
            }
            Amazon.Batch.QuotaShareResourceSharingStrategy requestResourceSharingConfiguration_resourceSharingConfiguration_Strategy = null;
            if (cmdletContext.ResourceSharingConfiguration_Strategy != null)
            {
                requestResourceSharingConfiguration_resourceSharingConfiguration_Strategy = cmdletContext.ResourceSharingConfiguration_Strategy;
            }
            if (requestResourceSharingConfiguration_resourceSharingConfiguration_Strategy != null)
            {
                request.ResourceSharingConfiguration.Strategy = requestResourceSharingConfiguration_resourceSharingConfiguration_Strategy;
                requestResourceSharingConfigurationIsNull = false;
            }
             // determine if request.ResourceSharingConfiguration should be set to null
            if (requestResourceSharingConfigurationIsNull)
            {
                request.ResourceSharingConfiguration = null;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
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
        
        private Amazon.Batch.Model.UpdateQuotaShareResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.UpdateQuotaShareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "UpdateQuotaShare");
            try
            {
                return client.UpdateQuotaShareAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Batch.Model.QuotaShareCapacityLimit> CapacityLimit { get; set; }
            public Amazon.Batch.QuotaShareInSharePreemptionState PreemptionConfiguration_InSharePreemption { get; set; }
            public System.String QuotaShareArn { get; set; }
            public System.Int32? ResourceSharingConfiguration_BorrowLimit { get; set; }
            public Amazon.Batch.QuotaShareResourceSharingStrategy ResourceSharingConfiguration_Strategy { get; set; }
            public Amazon.Batch.QuotaShareState State { get; set; }
            public System.Func<Amazon.Batch.Model.UpdateQuotaShareResponse, UpdateBATQuotaShareCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

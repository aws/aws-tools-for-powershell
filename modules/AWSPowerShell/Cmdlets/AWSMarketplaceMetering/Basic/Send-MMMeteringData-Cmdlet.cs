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
using Amazon.AWSMarketplaceMetering;
using Amazon.AWSMarketplaceMetering.Model;

namespace Amazon.PowerShell.Cmdlets.MM
{
    /// <summary>
    /// API to emit metering records. For identical requests, the API is idempotent and returns
    /// the metering record ID. This is used for metering flexible consumption pricing (FCP)
    /// Amazon Machine Images (AMI) and container products.
    /// 
    ///  
    /// <para><c>MeterUsage</c> is authenticated on the buyer's Amazon Web Services account using
    /// credentials from the Amazon EC2 instance, Amazon ECS task, or Amazon EKS pod.
    /// </para><para><c>MeterUsage</c> can optionally include multiple usage allocations, to provide customers
    /// with usage data split into buckets by tags that you define (or allow the customer
    /// to define).
    /// </para><para>
    /// Submit usage records to report events from the previous hour. If you submit records
    /// that are greater than six hours after events occur, the records won’t be accepted.
    /// The timestamp in your request determines when an event is recorded. You can only report
    /// usage once per hour for each dimension. For AMI-based products, this is per dimension
    /// and per EC2 instance. For container products, this is per dimension and per ECS task
    /// or EKS pod. You can’t modify values after they’re recorded. If you report usage before
    /// the current hour ends, you will be unable to report additional usage until the next
    /// hour begins.
    /// </para><para>
    /// For Amazon Web Services Regions that support <c>MeterUsage</c>, see <a href="https://docs.aws.amazon.com/marketplace/latest/APIReference/metering-regions.html#meterusage-region-support-ec2">MeterUsage
    /// Region support for Amazon EC2</a> and <a href="https://docs.aws.amazon.com/marketplace/latest/APIReference/metering-regions.html#meterusage-region-support-ecs-eks">MeterUsage
    /// Region support for Amazon ECS and Amazon EKS</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Send", "MMMeteringData", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Marketplace Metering MeterUsage API operation.", Operation = new[] {"MeterUsage"}, SelectReturnType = typeof(Amazon.AWSMarketplaceMetering.Model.MeterUsageResponse))]
    [AWSCmdletOutput("System.String or Amazon.AWSMarketplaceMetering.Model.MeterUsageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AWSMarketplaceMetering.Model.MeterUsageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendMMMeteringDataCmdlet : AmazonAWSMarketplaceMeteringClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the permissions required for the action, but does not make
        /// the request. If you have the permissions, the request returns <c>DryRunOperation</c>;
        /// otherwise, it returns <c>UnauthorizedException</c>. Defaults to <c>false</c> if not
        /// specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter ProductCode
        /// <summary>
        /// <para>
        /// <para>Product code is used to uniquely identify a product in Amazon Web Services Marketplace.
        /// The product code should be the same as the one used during the publishing of a new
        /// product.</para>
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
        public System.String ProductCode { get; set; }
        #endregion
        
        #region Parameter Timestamp
        /// <summary>
        /// <para>
        /// <para>Timestamp, in UTC, for which the usage is being reported. Your application can meter
        /// usage for up to six hours in the past. Make sure the <c>timestamp</c> value is not
        /// before the start of the software usage.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? Timestamp { get; set; }
        #endregion
        
        #region Parameter UsageAllocation
        /// <summary>
        /// <para>
        /// <para>The set of <c>UsageAllocations</c> to submit.</para><para>The sum of all <c>UsageAllocation</c> quantities must equal the <c>UsageQuantity</c>
        /// of the <c>MeterUsage</c> request, and each <c>UsageAllocation</c> must have a unique
        /// set of tags (include no tags).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UsageAllocations")]
        public Amazon.AWSMarketplaceMetering.Model.UsageAllocation[] UsageAllocation { get; set; }
        #endregion
        
        #region Parameter UsageDimension
        /// <summary>
        /// <para>
        /// <para>It will be one of the fcp dimension name provided during the publishing of the product.</para>
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
        public System.String UsageDimension { get; set; }
        #endregion
        
        #region Parameter UsageQuantity
        /// <summary>
        /// <para>
        /// <para>Consumption value for the hour. Defaults to <c>0</c> if not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UsageQuantity { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a unique, case-sensitive identifier that you provide to ensure the idempotency
        /// of the request. This lets you safely retry the request without accidentally performing
        /// the same operation a second time. Passing the same value to a later call to an operation
        /// requires that you also pass the same value for all other parameters. We recommend
        /// that you use a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID
        /// type of value</a>.</para><para>If you don't provide this value, then Amazon Web Services generates a random one for
        /// you.</para><para>If you retry the operation with the same <c>ClientToken</c>, but with different parameters,
        /// the retry fails with an <c>IdempotencyConflictException</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MeteringRecordId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSMarketplaceMetering.Model.MeterUsageResponse).
        /// Specifying the name of a property of type Amazon.AWSMarketplaceMetering.Model.MeterUsageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MeteringRecordId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProductCode parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProductCode' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProductCode' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProductCode), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-MMMeteringData (MeterUsage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AWSMarketplaceMetering.Model.MeterUsageResponse, SendMMMeteringDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProductCode;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.DryRun = this.DryRun;
            context.ProductCode = this.ProductCode;
            #if MODULAR
            if (this.ProductCode == null && ParameterWasBound(nameof(this.ProductCode)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Timestamp = this.Timestamp;
            #if MODULAR
            if (this.Timestamp == null && ParameterWasBound(nameof(this.Timestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter Timestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UsageAllocation != null)
            {
                context.UsageAllocation = new List<Amazon.AWSMarketplaceMetering.Model.UsageAllocation>(this.UsageAllocation);
            }
            context.UsageDimension = this.UsageDimension;
            #if MODULAR
            if (this.UsageDimension == null && ParameterWasBound(nameof(this.UsageDimension)))
            {
                WriteWarning("You are passing $null as a value for parameter UsageDimension which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UsageQuantity = this.UsageQuantity;
            
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
            var request = new Amazon.AWSMarketplaceMetering.Model.MeterUsageRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.ProductCode != null)
            {
                request.ProductCode = cmdletContext.ProductCode;
            }
            if (cmdletContext.Timestamp != null)
            {
                request.Timestamp = cmdletContext.Timestamp.Value;
            }
            if (cmdletContext.UsageAllocation != null)
            {
                request.UsageAllocations = cmdletContext.UsageAllocation;
            }
            if (cmdletContext.UsageDimension != null)
            {
                request.UsageDimension = cmdletContext.UsageDimension;
            }
            if (cmdletContext.UsageQuantity != null)
            {
                request.UsageQuantity = cmdletContext.UsageQuantity.Value;
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
        
        private Amazon.AWSMarketplaceMetering.Model.MeterUsageResponse CallAWSServiceOperation(IAmazonAWSMarketplaceMetering client, Amazon.AWSMarketplaceMetering.Model.MeterUsageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Metering", "MeterUsage");
            try
            {
                #if DESKTOP
                return client.MeterUsage(request);
                #elif CORECLR
                return client.MeterUsageAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String ProductCode { get; set; }
            public System.DateTime? Timestamp { get; set; }
            public List<Amazon.AWSMarketplaceMetering.Model.UsageAllocation> UsageAllocation { get; set; }
            public System.String UsageDimension { get; set; }
            public System.Int32? UsageQuantity { get; set; }
            public System.Func<Amazon.AWSMarketplaceMetering.Model.MeterUsageResponse, SendMMMeteringDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MeteringRecordId;
        }
        
    }
}

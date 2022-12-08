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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a listing for Amazon EC2 Standard Reserved Instances to be sold in the Reserved
    /// Instance Marketplace. You can submit one Standard Reserved Instance listing at a time.
    /// To get a list of your Standard Reserved Instances, you can use the <a>DescribeReservedInstances</a>
    /// operation.
    /// 
    ///  <note><para>
    /// Only Standard Reserved Instances can be sold in the Reserved Instance Marketplace.
    /// Convertible Reserved Instances cannot be sold.
    /// </para></note><para>
    /// The Reserved Instance Marketplace matches sellers who want to resell Standard Reserved
    /// Instance capacity that they no longer need with buyers who want to purchase additional
    /// capacity. Reserved Instances bought and sold through the Reserved Instance Marketplace
    /// work like any other Reserved Instances.
    /// </para><para>
    /// To sell your Standard Reserved Instances, you must first register as a seller in the
    /// Reserved Instance Marketplace. After completing the registration process, you can
    /// create a Reserved Instance Marketplace listing of some or all of your Standard Reserved
    /// Instances, and specify the upfront price to receive for them. Your Standard Reserved
    /// Instance listings then become available for purchase. To view the details of your
    /// Standard Reserved Instance listing, you can use the <a>DescribeReservedInstancesListings</a>
    /// operation.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ri-market-general.html">Reserved
    /// Instance Marketplace</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2ReservedInstancesListing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ReservedInstancesListing")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateReservedInstancesListing API operation.", Operation = new[] {"CreateReservedInstancesListing"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateReservedInstancesListingResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ReservedInstancesListing or Amazon.EC2.Model.CreateReservedInstancesListingResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.ReservedInstancesListing objects.",
        "The service call response (type Amazon.EC2.Model.CreateReservedInstancesListingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2ReservedInstancesListingCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances that are a part of a Reserved Instance account to be listed
        /// in the Reserved Instance Marketplace. This number should be less than or equal to
        /// the instance count associated with the Reserved Instance ID specified in this call.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? InstanceCount { get; set; }
        #endregion
        
        #region Parameter PriceSchedule
        /// <summary>
        /// <para>
        /// <para>A list specifying the price of the Standard Reserved Instance for each month remaining
        /// in the Reserved Instance term.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("PriceSchedules","PricingSchedules")]
        public Amazon.EC2.Model.PriceScheduleSpecification[] PriceSchedule { get; set; }
        #endregion
        
        #region Parameter ReservedInstancesId
        /// <summary>
        /// <para>
        /// <para>The ID of the active Standard Reserved Instance.</para>
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
        public System.String ReservedInstancesId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of your listings.
        /// This helps avoid duplicate listings. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReservedInstancesListings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateReservedInstancesListingResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateReservedInstancesListingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReservedInstancesListings";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReservedInstancesId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReservedInstancesId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReservedInstancesId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReservedInstancesId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2ReservedInstancesListing (CreateReservedInstancesListing)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateReservedInstancesListingResponse, NewEC2ReservedInstancesListingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReservedInstancesId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceCount = this.InstanceCount;
            #if MODULAR
            if (this.InstanceCount == null && ParameterWasBound(nameof(this.InstanceCount)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PriceSchedule != null)
            {
                context.PriceSchedule = new List<Amazon.EC2.Model.PriceScheduleSpecification>(this.PriceSchedule);
            }
            #if MODULAR
            if (this.PriceSchedule == null && ParameterWasBound(nameof(this.PriceSchedule)))
            {
                WriteWarning("You are passing $null as a value for parameter PriceSchedule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReservedInstancesId = this.ReservedInstancesId;
            #if MODULAR
            if (this.ReservedInstancesId == null && ParameterWasBound(nameof(this.ReservedInstancesId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReservedInstancesId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateReservedInstancesListingRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            if (cmdletContext.PriceSchedule != null)
            {
                request.PriceSchedules = cmdletContext.PriceSchedule;
            }
            if (cmdletContext.ReservedInstancesId != null)
            {
                request.ReservedInstancesId = cmdletContext.ReservedInstancesId;
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
        
        private Amazon.EC2.Model.CreateReservedInstancesListingResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateReservedInstancesListingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateReservedInstancesListing");
            try
            {
                #if DESKTOP
                return client.CreateReservedInstancesListing(request);
                #elif CORECLR
                return client.CreateReservedInstancesListingAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? InstanceCount { get; set; }
            public List<Amazon.EC2.Model.PriceScheduleSpecification> PriceSchedule { get; set; }
            public System.String ReservedInstancesId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateReservedInstancesListingResponse, NewEC2ReservedInstancesListingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReservedInstancesListings;
        }
        
    }
}

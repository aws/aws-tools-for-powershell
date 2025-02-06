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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Purchase the Capacity Block for use with your account. With Capacity Blocks you ensure
    /// GPU capacity is available for machine learning (ML) workloads. You must specify the
    /// ID of the Capacity Block offering you are purchasing.
    /// </summary>
    [Cmdlet("New", "EC2EC2CapacityBlock", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CapacityReservation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) PurchaseCapacityBlock API operation.", Operation = new[] {"PurchaseCapacityBlock"}, SelectReturnType = typeof(Amazon.EC2.Model.PurchaseCapacityBlockResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CapacityReservation or Amazon.EC2.Model.PurchaseCapacityBlockResponse",
        "This cmdlet returns an Amazon.EC2.Model.CapacityReservation object.",
        "The service call response (type Amazon.EC2.Model.PurchaseCapacityBlockResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2EC2CapacityBlockCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CapacityBlockOfferingId
        /// <summary>
        /// <para>
        /// <para>The ID of the Capacity Block offering.</para>
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
        public System.String CapacityBlockOfferingId { get; set; }
        #endregion
        
        #region Parameter InstancePlatform
        /// <summary>
        /// <para>
        /// <para>The type of operating system for which to reserve capacity.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.CapacityReservationInstancePlatform")]
        public Amazon.EC2.CapacityReservationInstancePlatform InstancePlatform { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the Capacity Block during launch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CapacityReservation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.PurchaseCapacityBlockResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.PurchaseCapacityBlockResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CapacityReservation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CapacityBlockOfferingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2EC2CapacityBlock (PurchaseCapacityBlock)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.PurchaseCapacityBlockResponse, NewEC2EC2CapacityBlockCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityBlockOfferingId = this.CapacityBlockOfferingId;
            #if MODULAR
            if (this.CapacityBlockOfferingId == null && ParameterWasBound(nameof(this.CapacityBlockOfferingId)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityBlockOfferingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstancePlatform = this.InstancePlatform;
            #if MODULAR
            if (this.InstancePlatform == null && ParameterWasBound(nameof(this.InstancePlatform)))
            {
                WriteWarning("You are passing $null as a value for parameter InstancePlatform which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            
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
            var request = new Amazon.EC2.Model.PurchaseCapacityBlockRequest();
            
            if (cmdletContext.CapacityBlockOfferingId != null)
            {
                request.CapacityBlockOfferingId = cmdletContext.CapacityBlockOfferingId;
            }
            if (cmdletContext.InstancePlatform != null)
            {
                request.InstancePlatform = cmdletContext.InstancePlatform;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.PurchaseCapacityBlockResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.PurchaseCapacityBlockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "PurchaseCapacityBlock");
            try
            {
                #if DESKTOP
                return client.PurchaseCapacityBlock(request);
                #elif CORECLR
                return client.PurchaseCapacityBlockAsync(request).GetAwaiter().GetResult();
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
            public System.String CapacityBlockOfferingId { get; set; }
            public Amazon.EC2.CapacityReservationInstancePlatform InstancePlatform { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.PurchaseCapacityBlockResponse, NewEC2EC2CapacityBlockCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CapacityReservation;
        }
        
    }
}

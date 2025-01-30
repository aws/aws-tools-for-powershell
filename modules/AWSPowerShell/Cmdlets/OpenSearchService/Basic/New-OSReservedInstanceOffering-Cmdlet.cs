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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Allows you to purchase Amazon OpenSearch Service Reserved Instances.
    /// </summary>
    [Cmdlet("New", "OSReservedInstanceOffering", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.PurchaseReservedInstanceOfferingResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service PurchaseReservedInstanceOffering API operation.", Operation = new[] {"PurchaseReservedInstanceOffering"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.PurchaseReservedInstanceOfferingResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.PurchaseReservedInstanceOfferingResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.PurchaseReservedInstanceOfferingResponse object containing multiple properties."
    )]
    public partial class NewOSReservedInstanceOfferingCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of OpenSearch instances to reserve.</para>
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
        
        #region Parameter ReservedInstanceOfferingId
        /// <summary>
        /// <para>
        /// <para>The ID of the Reserved Instance offering to purchase.</para>
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
        public System.String ReservedInstanceOfferingId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.PurchaseReservedInstanceOfferingResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.PurchaseReservedInstanceOfferingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReservedInstanceOfferingId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReservedInstanceOfferingId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReservedInstanceOfferingId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReservedInstanceOfferingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSReservedInstanceOffering (PurchaseReservedInstanceOffering)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.PurchaseReservedInstanceOfferingResponse, NewOSReservedInstanceOfferingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReservedInstanceOfferingId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceCount = this.InstanceCount;
            context.ReservationName = this.ReservationName;
            #if MODULAR
            if (this.ReservationName == null && ParameterWasBound(nameof(this.ReservationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ReservationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReservedInstanceOfferingId = this.ReservedInstanceOfferingId;
            #if MODULAR
            if (this.ReservedInstanceOfferingId == null && ParameterWasBound(nameof(this.ReservedInstanceOfferingId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReservedInstanceOfferingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpenSearchService.Model.PurchaseReservedInstanceOfferingRequest();
            
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            if (cmdletContext.ReservationName != null)
            {
                request.ReservationName = cmdletContext.ReservationName;
            }
            if (cmdletContext.ReservedInstanceOfferingId != null)
            {
                request.ReservedInstanceOfferingId = cmdletContext.ReservedInstanceOfferingId;
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
        
        private Amazon.OpenSearchService.Model.PurchaseReservedInstanceOfferingResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.PurchaseReservedInstanceOfferingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "PurchaseReservedInstanceOffering");
            try
            {
                #if DESKTOP
                return client.PurchaseReservedInstanceOffering(request);
                #elif CORECLR
                return client.PurchaseReservedInstanceOfferingAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? InstanceCount { get; set; }
            public System.String ReservationName { get; set; }
            public System.String ReservedInstanceOfferingId { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.PurchaseReservedInstanceOfferingResponse, NewOSReservedInstanceOfferingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

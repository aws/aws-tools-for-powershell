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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Request a cost allocation tag backfill. This will backfill the activation status
    /// (either <c>active</c> or <c>inactive</c>) for all tag keys from <c>para:BackfillFrom</c>
    /// up to the time this request is made.
    /// 
    ///  
    /// <para>
    /// You can request a backfill once every 24 hours. 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CECostAllocationTagBackfill", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CostExplorer.Model.CostAllocationTagBackfillRequest")]
    [AWSCmdlet("Calls the AWS Cost Explorer StartCostAllocationTagBackfill API operation.", Operation = new[] {"StartCostAllocationTagBackfill"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.StartCostAllocationTagBackfillResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.CostAllocationTagBackfillRequest or Amazon.CostExplorer.Model.StartCostAllocationTagBackfillResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.CostAllocationTagBackfillRequest object.",
        "The service call response (type Amazon.CostExplorer.Model.StartCostAllocationTagBackfillResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCECostAllocationTagBackfillCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BackfillFrom
        /// <summary>
        /// <para>
        /// <para> The date you want the backfill to start from. The date can only be a first day of
        /// the month (a billing start date). Dates can't precede the previous twelve months,
        /// or in the future.</para>
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
        public System.String BackfillFrom { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BackfillRequest'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.StartCostAllocationTagBackfillResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.StartCostAllocationTagBackfillResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BackfillRequest";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BackfillFrom parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BackfillFrom' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BackfillFrom' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BackfillFrom), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CECostAllocationTagBackfill (StartCostAllocationTagBackfill)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.StartCostAllocationTagBackfillResponse, StartCECostAllocationTagBackfillCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BackfillFrom;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackfillFrom = this.BackfillFrom;
            #if MODULAR
            if (this.BackfillFrom == null && ParameterWasBound(nameof(this.BackfillFrom)))
            {
                WriteWarning("You are passing $null as a value for parameter BackfillFrom which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CostExplorer.Model.StartCostAllocationTagBackfillRequest();
            
            if (cmdletContext.BackfillFrom != null)
            {
                request.BackfillFrom = cmdletContext.BackfillFrom;
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
        
        private Amazon.CostExplorer.Model.StartCostAllocationTagBackfillResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.StartCostAllocationTagBackfillRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "StartCostAllocationTagBackfill");
            try
            {
                #if DESKTOP
                return client.StartCostAllocationTagBackfill(request);
                #elif CORECLR
                return client.StartCostAllocationTagBackfillAsync(request).GetAwaiter().GetResult();
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
            public System.String BackfillFrom { get; set; }
            public System.Func<Amazon.CostExplorer.Model.StartCostAllocationTagBackfillResponse, StartCECostAllocationTagBackfillCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BackfillRequest;
        }
        
    }
}

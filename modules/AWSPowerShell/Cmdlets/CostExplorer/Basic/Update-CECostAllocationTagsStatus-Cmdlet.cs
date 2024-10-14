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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Updates status for cost allocation tags in bulk, with maximum batch size of 20. If
    /// the tag status that's updated is the same as the existing tag status, the request
    /// doesn't fail. Instead, it doesn't have any effect on the tag status (for example,
    /// activating the active tag).
    /// </summary>
    [Cmdlet("Update", "CECostAllocationTagsStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusError")]
    [AWSCmdlet("Calls the AWS Cost Explorer UpdateCostAllocationTagsStatus API operation.", Operation = new[] {"UpdateCostAllocationTagsStatus"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusError or Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusResponse",
        "This cmdlet returns a collection of Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusError objects.",
        "The service call response (type Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCECostAllocationTagsStatusCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CostAllocationTagsStatus
        /// <summary>
        /// <para>
        /// <para>The list of <c>CostAllocationTagStatusEntry</c> objects that are used to update cost
        /// allocation tags status for this request. </para>
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
        public Amazon.CostExplorer.Model.CostAllocationTagStatusEntry[] CostAllocationTagsStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Errors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Errors";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CostAllocationTagsStatus), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CECostAllocationTagsStatus (UpdateCostAllocationTagsStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusResponse, UpdateCECostAllocationTagsStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CostAllocationTagsStatus != null)
            {
                context.CostAllocationTagsStatus = new List<Amazon.CostExplorer.Model.CostAllocationTagStatusEntry>(this.CostAllocationTagsStatus);
            }
            #if MODULAR
            if (this.CostAllocationTagsStatus == null && ParameterWasBound(nameof(this.CostAllocationTagsStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter CostAllocationTagsStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusRequest();
            
            if (cmdletContext.CostAllocationTagsStatus != null)
            {
                request.CostAllocationTagsStatus = cmdletContext.CostAllocationTagsStatus;
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
        
        private Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "UpdateCostAllocationTagsStatus");
            try
            {
                #if DESKTOP
                return client.UpdateCostAllocationTagsStatus(request);
                #elif CORECLR
                return client.UpdateCostAllocationTagsStatusAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CostExplorer.Model.CostAllocationTagStatusEntry> CostAllocationTagsStatus { get; set; }
            public System.Func<Amazon.CostExplorer.Model.UpdateCostAllocationTagsStatusResponse, UpdateCECostAllocationTagsStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Errors;
        }
        
    }
}

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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Deletes the specified resiliency group. Deletion is asynchronous: the resiliency group
    /// transitions through the <c>deleting</c> state before it reaches the <c>deleted</c>
    /// state. The response returns the resiliency group so you can observe its current state
    /// without a subsequent <a>GetResiliencyGroup</a> call.
    /// </summary>
    [Cmdlet("Remove", "DCResiliencyGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.DirectConnect.Model.ResiliencyGroup")]
    [AWSCmdlet("Calls the AWS Direct Connect DeleteResiliencyGroup API operation.", Operation = new[] {"DeleteResiliencyGroup"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.DeleteResiliencyGroupResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.ResiliencyGroup or Amazon.DirectConnect.Model.DeleteResiliencyGroupResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.ResiliencyGroup object.",
        "The service call response (type Amazon.DirectConnect.Model.DeleteResiliencyGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveDCResiliencyGroupCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResiliencyGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the resiliency group.</para>
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
        public System.String ResiliencyGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResiliencyGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.DeleteResiliencyGroupResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.DeleteResiliencyGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResiliencyGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResiliencyGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-DCResiliencyGroup (DeleteResiliencyGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.DeleteResiliencyGroupResponse, RemoveDCResiliencyGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResiliencyGroupId = this.ResiliencyGroupId;
            #if MODULAR
            if (this.ResiliencyGroupId == null && ParameterWasBound(nameof(this.ResiliencyGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResiliencyGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectConnect.Model.DeleteResiliencyGroupRequest();
            
            if (cmdletContext.ResiliencyGroupId != null)
            {
                request.ResiliencyGroupId = cmdletContext.ResiliencyGroupId;
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
        
        private Amazon.DirectConnect.Model.DeleteResiliencyGroupResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.DeleteResiliencyGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "DeleteResiliencyGroup");
            try
            {
                return client.DeleteResiliencyGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ResiliencyGroupId { get; set; }
            public System.Func<Amazon.DirectConnect.Model.DeleteResiliencyGroupResponse, RemoveDCResiliencyGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResiliencyGroup;
        }
        
    }
}

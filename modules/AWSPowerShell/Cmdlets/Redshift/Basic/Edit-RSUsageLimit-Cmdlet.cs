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
using Amazon.Redshift;
using Amazon.Redshift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Modifies a usage limit in a cluster. You can't modify the feature type or period of
    /// a usage limit.
    /// </summary>
    [Cmdlet("Edit", "RSUsageLimit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.ModifyUsageLimitResponse")]
    [AWSCmdlet("Calls the Amazon Redshift ModifyUsageLimit API operation.", Operation = new[] {"ModifyUsageLimit"}, SelectReturnType = typeof(Amazon.Redshift.Model.ModifyUsageLimitResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.ModifyUsageLimitResponse",
        "This cmdlet returns an Amazon.Redshift.Model.ModifyUsageLimitResponse object containing multiple properties."
    )]
    public partial class EditRSUsageLimitCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Amount
        /// <summary>
        /// <para>
        /// <para>The new limit amount. For more information about this parameter, see <a>UsageLimit</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Amount { get; set; }
        #endregion
        
        #region Parameter BreachAction
        /// <summary>
        /// <para>
        /// <para>The new action that Amazon Redshift takes when the limit is reached. For more information
        /// about this parameter, see <a>UsageLimit</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Redshift.UsageLimitBreachAction")]
        public Amazon.Redshift.UsageLimitBreachAction BreachAction { get; set; }
        #endregion
        
        #region Parameter UsageLimitId
        /// <summary>
        /// <para>
        /// <para>The identifier of the usage limit to modify.</para>
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
        public System.String UsageLimitId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.ModifyUsageLimitResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.ModifyUsageLimitResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UsageLimitId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RSUsageLimit (ModifyUsageLimit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.ModifyUsageLimitResponse, EditRSUsageLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Amount = this.Amount;
            context.BreachAction = this.BreachAction;
            context.UsageLimitId = this.UsageLimitId;
            #if MODULAR
            if (this.UsageLimitId == null && ParameterWasBound(nameof(this.UsageLimitId)))
            {
                WriteWarning("You are passing $null as a value for parameter UsageLimitId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Redshift.Model.ModifyUsageLimitRequest();
            
            if (cmdletContext.Amount != null)
            {
                request.Amount = cmdletContext.Amount.Value;
            }
            if (cmdletContext.BreachAction != null)
            {
                request.BreachAction = cmdletContext.BreachAction;
            }
            if (cmdletContext.UsageLimitId != null)
            {
                request.UsageLimitId = cmdletContext.UsageLimitId;
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
        
        private Amazon.Redshift.Model.ModifyUsageLimitResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.ModifyUsageLimitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "ModifyUsageLimit");
            try
            {
                return client.ModifyUsageLimitAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? Amount { get; set; }
            public Amazon.Redshift.UsageLimitBreachAction BreachAction { get; set; }
            public System.String UsageLimitId { get; set; }
            public System.Func<Amazon.Redshift.Model.ModifyUsageLimitResponse, EditRSUsageLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

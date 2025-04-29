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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Updates the name or associated model for a Provisioned Throughput. For more information,
    /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prov-throughput.html">Provisioned
    /// Throughput</a> in the <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/what-is-service.html">Amazon
    /// Bedrock User Guide</a>.
    /// </summary>
    [Cmdlet("Update", "BDRProvisionedModelThroughput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Bedrock UpdateProvisionedModelThroughput API operation.", Operation = new[] {"UpdateProvisionedModelThroughput"}, SelectReturnType = typeof(Amazon.Bedrock.Model.UpdateProvisionedModelThroughputResponse))]
    [AWSCmdletOutput("None or Amazon.Bedrock.Model.UpdateProvisionedModelThroughputResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Bedrock.Model.UpdateProvisionedModelThroughputResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateBDRProvisionedModelThroughputCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DesiredModelId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the new model to associate with this Provisioned
        /// Throughput. You can't specify this field if this Provisioned Throughput is associated
        /// with a base model.</para><para>If this Provisioned Throughput is associated with a custom model, you can specify
        /// one of the following options:</para><ul><li><para>The base model from which the custom model was customized.</para></li><li><para>Another custom model that was customized from the same base model as the custom model.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DesiredModelId { get; set; }
        #endregion
        
        #region Parameter DesiredProvisionedModelName
        /// <summary>
        /// <para>
        /// <para>The new name for this Provisioned Throughput.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DesiredProvisionedModelName { get; set; }
        #endregion
        
        #region Parameter ProvisionedModelId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or name of the Provisioned Throughput to update.</para>
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
        public System.String ProvisionedModelId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.UpdateProvisionedModelThroughputResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProvisionedModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BDRProvisionedModelThroughput (UpdateProvisionedModelThroughput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.UpdateProvisionedModelThroughputResponse, UpdateBDRProvisionedModelThroughputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DesiredModelId = this.DesiredModelId;
            context.DesiredProvisionedModelName = this.DesiredProvisionedModelName;
            context.ProvisionedModelId = this.ProvisionedModelId;
            #if MODULAR
            if (this.ProvisionedModelId == null && ParameterWasBound(nameof(this.ProvisionedModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProvisionedModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.UpdateProvisionedModelThroughputRequest();
            
            if (cmdletContext.DesiredModelId != null)
            {
                request.DesiredModelId = cmdletContext.DesiredModelId;
            }
            if (cmdletContext.DesiredProvisionedModelName != null)
            {
                request.DesiredProvisionedModelName = cmdletContext.DesiredProvisionedModelName;
            }
            if (cmdletContext.ProvisionedModelId != null)
            {
                request.ProvisionedModelId = cmdletContext.ProvisionedModelId;
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
        
        private Amazon.Bedrock.Model.UpdateProvisionedModelThroughputResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.UpdateProvisionedModelThroughputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "UpdateProvisionedModelThroughput");
            try
            {
                return client.UpdateProvisionedModelThroughputAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DesiredModelId { get; set; }
            public System.String DesiredProvisionedModelName { get; set; }
            public System.String ProvisionedModelId { get; set; }
            public System.Func<Amazon.Bedrock.Model.UpdateProvisionedModelThroughputResponse, UpdateBDRProvisionedModelThroughputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

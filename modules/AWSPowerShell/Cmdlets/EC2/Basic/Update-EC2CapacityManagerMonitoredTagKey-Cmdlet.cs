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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Activates or deactivates tag keys for monitoring by EC2 Capacity Manager. Activated
    /// tag keys are included as dimensions in capacity metric data, enabling you to group
    /// and filter metrics by tag values.
    /// </summary>
    [Cmdlet("Update", "EC2CapacityManagerMonitoredTagKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CapacityManagerMonitoredTagKey")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) UpdateCapacityManagerMonitoredTagKeys API operation.", Operation = new[] {"UpdateCapacityManagerMonitoredTagKeys"}, SelectReturnType = typeof(Amazon.EC2.Model.UpdateCapacityManagerMonitoredTagKeysResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CapacityManagerMonitoredTagKey or Amazon.EC2.Model.UpdateCapacityManagerMonitoredTagKeysResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.CapacityManagerMonitoredTagKey objects.",
        "The service call response (type Amazon.EC2.Model.UpdateCapacityManagerMonitoredTagKeysResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEC2CapacityManagerMonitoredTagKeyCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActivateTagKey
        /// <summary>
        /// <para>
        /// <para> The tag keys to activate for monitoring. Once activated, these tag keys will be included
        /// as dimensions in capacity metric data. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActivateTagKeys")]
        public System.String[] ActivateTagKey { get; set; }
        #endregion
        
        #region Parameter DeactivateTagKey
        /// <summary>
        /// <para>
        /// <para> The tag keys to deactivate. Deactivated tag keys will no longer be included as dimensions
        /// in capacity metric data. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeactivateTagKeys")]
        public System.String[] DeactivateTagKey { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para> Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CapacityManagerTagKeys'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.UpdateCapacityManagerMonitoredTagKeysResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.UpdateCapacityManagerMonitoredTagKeysResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CapacityManagerTagKeys";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EC2CapacityManagerMonitoredTagKey (UpdateCapacityManagerMonitoredTagKeys)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.UpdateCapacityManagerMonitoredTagKeysResponse, UpdateEC2CapacityManagerMonitoredTagKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ActivateTagKey != null)
            {
                context.ActivateTagKey = new List<System.String>(this.ActivateTagKey);
            }
            context.ClientToken = this.ClientToken;
            if (this.DeactivateTagKey != null)
            {
                context.DeactivateTagKey = new List<System.String>(this.DeactivateTagKey);
            }
            context.DryRun = this.DryRun;
            
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
            var request = new Amazon.EC2.Model.UpdateCapacityManagerMonitoredTagKeysRequest();
            
            if (cmdletContext.ActivateTagKey != null)
            {
                request.ActivateTagKeys = cmdletContext.ActivateTagKey;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeactivateTagKey != null)
            {
                request.DeactivateTagKeys = cmdletContext.DeactivateTagKey;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
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
        
        private Amazon.EC2.Model.UpdateCapacityManagerMonitoredTagKeysResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.UpdateCapacityManagerMonitoredTagKeysRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "UpdateCapacityManagerMonitoredTagKeys");
            try
            {
                return client.UpdateCapacityManagerMonitoredTagKeysAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ActivateTagKey { get; set; }
            public System.String ClientToken { get; set; }
            public List<System.String> DeactivateTagKey { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.Func<Amazon.EC2.Model.UpdateCapacityManagerMonitoredTagKeysResponse, UpdateEC2CapacityManagerMonitoredTagKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CapacityManagerTagKeys;
        }
        
    }
}

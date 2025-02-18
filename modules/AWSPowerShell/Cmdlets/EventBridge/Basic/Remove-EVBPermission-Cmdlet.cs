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
using Amazon.EventBridge;
using Amazon.EventBridge.Model;

namespace Amazon.PowerShell.Cmdlets.EVB
{
    /// <summary>
    /// Revokes the permission of another Amazon Web Services account to be able to put events
    /// to the specified event bus. Specify the account to revoke by the <c>StatementId</c>
    /// value that you associated with the account when you granted it permission with <c>PutPermission</c>.
    /// You can find the <c>StatementId</c> by using <a href="https://docs.aws.amazon.com/eventbridge/latest/APIReference/API_DescribeEventBus.html">DescribeEventBus</a>.
    /// </summary>
    [Cmdlet("Remove", "EVBPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon EventBridge RemovePermission API operation.", Operation = new[] {"RemovePermission"}, SelectReturnType = typeof(Amazon.EventBridge.Model.RemovePermissionResponse))]
    [AWSCmdletOutput("None or Amazon.EventBridge.Model.RemovePermissionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EventBridge.Model.RemovePermissionResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveEVBPermissionCmdlet : AmazonEventBridgeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EventBusName
        /// <summary>
        /// <para>
        /// <para>The name of the event bus to revoke permissions for. If you omit this, the default
        /// event bus is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventBusName { get; set; }
        #endregion
        
        #region Parameter RemoveAllPermission
        /// <summary>
        /// <para>
        /// <para>Specifies whether to remove all permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveAllPermissions")]
        public System.Boolean? RemoveAllPermission { get; set; }
        #endregion
        
        #region Parameter StatementId
        /// <summary>
        /// <para>
        /// <para>The statement ID corresponding to the account that is no longer allowed to put events
        /// to the default event bus.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StatementId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridge.Model.RemovePermissionResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StatementId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EVBPermission (RemovePermission)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridge.Model.RemovePermissionResponse, RemoveEVBPermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EventBusName = this.EventBusName;
            context.RemoveAllPermission = this.RemoveAllPermission;
            context.StatementId = this.StatementId;
            
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
            var request = new Amazon.EventBridge.Model.RemovePermissionRequest();
            
            if (cmdletContext.EventBusName != null)
            {
                request.EventBusName = cmdletContext.EventBusName;
            }
            if (cmdletContext.RemoveAllPermission != null)
            {
                request.RemoveAllPermissions = cmdletContext.RemoveAllPermission.Value;
            }
            if (cmdletContext.StatementId != null)
            {
                request.StatementId = cmdletContext.StatementId;
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
        
        private Amazon.EventBridge.Model.RemovePermissionResponse CallAWSServiceOperation(IAmazonEventBridge client, Amazon.EventBridge.Model.RemovePermissionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge", "RemovePermission");
            try
            {
                return client.RemovePermissionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EventBusName { get; set; }
            public System.Boolean? RemoveAllPermission { get; set; }
            public System.String StatementId { get; set; }
            public System.Func<Amazon.EventBridge.Model.RemovePermissionResponse, RemoveEVBPermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

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
using Amazon.DocDB;
using Amazon.DocDB.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Applies a pending maintenance action to a resource (for example, to an Amazon DocumentDB
    /// instance).
    /// </summary>
    [Cmdlet("Complete", "DOCPendingMaintenanceAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.ResourcePendingMaintenanceActions")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) ApplyPendingMaintenanceAction API operation.", Operation = new[] {"ApplyPendingMaintenanceAction"}, SelectReturnType = typeof(Amazon.DocDB.Model.ApplyPendingMaintenanceActionResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.ResourcePendingMaintenanceActions or Amazon.DocDB.Model.ApplyPendingMaintenanceActionResponse",
        "This cmdlet returns an Amazon.DocDB.Model.ResourcePendingMaintenanceActions object.",
        "The service call response (type Amazon.DocDB.Model.ApplyPendingMaintenanceActionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CompleteDOCPendingMaintenanceActionCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplyAction
        /// <summary>
        /// <para>
        /// <para>The pending maintenance action to apply to this resource.</para><para>Valid values: <c>system-update</c>, <c>db-upgrade</c></para>
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
        public System.String ApplyAction { get; set; }
        #endregion
        
        #region Parameter OptInType
        /// <summary>
        /// <para>
        /// <para>A value that specifies the type of opt-in request or undoes an opt-in request. An
        /// opt-in request of type <c>immediate</c> can't be undone.</para><para>Valid values:</para><ul><li><para><c>immediate</c> - Apply the maintenance action immediately.</para></li><li><para><c>next-maintenance</c> - Apply the maintenance action during the next maintenance
        /// window for the resource. </para></li><li><para><c>undo-opt-in</c> - Cancel any existing <c>next-maintenance</c> opt-in requests.</para></li></ul>
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
        public System.String OptInType { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource that the pending maintenance action
        /// applies to.</para>
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
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourcePendingMaintenanceActions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.ApplyPendingMaintenanceActionResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.ApplyPendingMaintenanceActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourcePendingMaintenanceActions";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Complete-DOCPendingMaintenanceAction (ApplyPendingMaintenanceAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.ApplyPendingMaintenanceActionResponse, CompleteDOCPendingMaintenanceActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplyAction = this.ApplyAction;
            #if MODULAR
            if (this.ApplyAction == null && ParameterWasBound(nameof(this.ApplyAction)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplyAction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OptInType = this.OptInType;
            #if MODULAR
            if (this.OptInType == null && ParameterWasBound(nameof(this.OptInType)))
            {
                WriteWarning("You are passing $null as a value for parameter OptInType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceIdentifier = this.ResourceIdentifier;
            #if MODULAR
            if (this.ResourceIdentifier == null && ParameterWasBound(nameof(this.ResourceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DocDB.Model.ApplyPendingMaintenanceActionRequest();
            
            if (cmdletContext.ApplyAction != null)
            {
                request.ApplyAction = cmdletContext.ApplyAction;
            }
            if (cmdletContext.OptInType != null)
            {
                request.OptInType = cmdletContext.OptInType;
            }
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
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
        
        private Amazon.DocDB.Model.ApplyPendingMaintenanceActionResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.ApplyPendingMaintenanceActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "ApplyPendingMaintenanceAction");
            try
            {
                return client.ApplyPendingMaintenanceActionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplyAction { get; set; }
            public System.String OptInType { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public System.Func<Amazon.DocDB.Model.ApplyPendingMaintenanceActionResponse, CompleteDOCPendingMaintenanceActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourcePendingMaintenanceActions;
        }
        
    }
}

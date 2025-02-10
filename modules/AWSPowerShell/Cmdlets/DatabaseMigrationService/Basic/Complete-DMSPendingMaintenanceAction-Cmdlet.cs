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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Applies a pending maintenance action to a resource (for example, to a replication
    /// instance).
    /// </summary>
    [Cmdlet("Complete", "DMSPendingMaintenanceAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.ResourcePendingMaintenanceActions")]
    [AWSCmdlet("Calls the AWS Database Migration Service ApplyPendingMaintenanceAction API operation.", Operation = new[] {"ApplyPendingMaintenanceAction"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.ApplyPendingMaintenanceActionResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.ResourcePendingMaintenanceActions or Amazon.DatabaseMigrationService.Model.ApplyPendingMaintenanceActionResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.ResourcePendingMaintenanceActions object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.ApplyPendingMaintenanceActionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CompleteDMSPendingMaintenanceActionCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplyAction
        /// <summary>
        /// <para>
        /// <para>The pending maintenance action to apply to this resource.</para><para>Valid values: <c>os-upgrade</c>, <c>system-update</c>, <c>db-upgrade</c>, <c>os-patch</c></para>
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
        /// <para>A value that specifies the type of opt-in request, or undoes an opt-in request. You
        /// can't undo an opt-in request of type <c>immediate</c>.</para><para>Valid values:</para><ul><li><para><c>immediate</c> - Apply the maintenance action immediately.</para></li><li><para><c>next-maintenance</c> - Apply the maintenance action during the next maintenance
        /// window for the resource.</para></li><li><para><c>undo-opt-in</c> - Cancel any existing <c>next-maintenance</c> opt-in requests.</para></li></ul>
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
        
        #region Parameter ReplicationInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the DMS resource that the pending maintenance action
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
        public System.String ReplicationInstanceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourcePendingMaintenanceActions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.ApplyPendingMaintenanceActionResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.ApplyPendingMaintenanceActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourcePendingMaintenanceActions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReplicationInstanceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReplicationInstanceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReplicationInstanceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationInstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Complete-DMSPendingMaintenanceAction (ApplyPendingMaintenanceAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.ApplyPendingMaintenanceActionResponse, CompleteDMSPendingMaintenanceActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReplicationInstanceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.ReplicationInstanceArn = this.ReplicationInstanceArn;
            #if MODULAR
            if (this.ReplicationInstanceArn == null && ParameterWasBound(nameof(this.ReplicationInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DatabaseMigrationService.Model.ApplyPendingMaintenanceActionRequest();
            
            if (cmdletContext.ApplyAction != null)
            {
                request.ApplyAction = cmdletContext.ApplyAction;
            }
            if (cmdletContext.OptInType != null)
            {
                request.OptInType = cmdletContext.OptInType;
            }
            if (cmdletContext.ReplicationInstanceArn != null)
            {
                request.ReplicationInstanceArn = cmdletContext.ReplicationInstanceArn;
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
        
        private Amazon.DatabaseMigrationService.Model.ApplyPendingMaintenanceActionResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.ApplyPendingMaintenanceActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "ApplyPendingMaintenanceAction");
            try
            {
                #if DESKTOP
                return client.ApplyPendingMaintenanceAction(request);
                #elif CORECLR
                return client.ApplyPendingMaintenanceActionAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplyAction { get; set; }
            public System.String OptInType { get; set; }
            public System.String ReplicationInstanceArn { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.ApplyPendingMaintenanceActionResponse, CompleteDMSPendingMaintenanceActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourcePendingMaintenanceActions;
        }
        
    }
}

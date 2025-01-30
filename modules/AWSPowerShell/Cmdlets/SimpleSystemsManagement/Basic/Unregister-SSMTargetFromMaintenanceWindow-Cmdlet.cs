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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Removes a target from a maintenance window.
    /// </summary>
    [Cmdlet("Unregister", "SSMTargetFromMaintenanceWindow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager DeregisterTargetFromMaintenanceWindow API operation.", Operation = new[] {"DeregisterTargetFromMaintenanceWindow"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse object containing multiple properties."
    )]
    public partial class UnregisterSSMTargetFromMaintenanceWindowCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Safe
        /// <summary>
        /// <para>
        /// <para>The system checks if the target is being referenced by a task. If the target is being
        /// referenced, the system returns an error and doesn't deregister the target from the
        /// maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Safe { get; set; }
        #endregion
        
        #region Parameter WindowId
        /// <summary>
        /// <para>
        /// <para>The ID of the maintenance window the target should be removed from.</para>
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
        public System.String WindowId { get; set; }
        #endregion
        
        #region Parameter WindowTargetId
        /// <summary>
        /// <para>
        /// <para>The ID of the target definition to remove.</para>
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
        public System.String WindowTargetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WindowTargetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WindowTargetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WindowTargetId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WindowTargetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-SSMTargetFromMaintenanceWindow (DeregisterTargetFromMaintenanceWindow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse, UnregisterSSMTargetFromMaintenanceWindowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WindowTargetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Safe = this.Safe;
            context.WindowId = this.WindowId;
            #if MODULAR
            if (this.WindowId == null && ParameterWasBound(nameof(this.WindowId)))
            {
                WriteWarning("You are passing $null as a value for parameter WindowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WindowTargetId = this.WindowTargetId;
            #if MODULAR
            if (this.WindowTargetId == null && ParameterWasBound(nameof(this.WindowTargetId)))
            {
                WriteWarning("You are passing $null as a value for parameter WindowTargetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowRequest();
            
            if (cmdletContext.Safe != null)
            {
                request.Safe = cmdletContext.Safe.Value;
            }
            if (cmdletContext.WindowId != null)
            {
                request.WindowId = cmdletContext.WindowId;
            }
            if (cmdletContext.WindowTargetId != null)
            {
                request.WindowTargetId = cmdletContext.WindowTargetId;
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
        
        private Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "DeregisterTargetFromMaintenanceWindow");
            try
            {
                #if DESKTOP
                return client.DeregisterTargetFromMaintenanceWindow(request);
                #elif CORECLR
                return client.DeregisterTargetFromMaintenanceWindowAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Safe { get; set; }
            public System.String WindowId { get; set; }
            public System.String WindowTargetId { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse, UnregisterSSMTargetFromMaintenanceWindowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

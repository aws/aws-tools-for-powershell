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
using Amazon.Neptune;
using Amazon.Neptune.Model;

namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Applies a pending maintenance action to a resource (for example, to a DB instance).
    /// </summary>
    [Cmdlet("Submit", "NPTPendingMaintenanceAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptune.Model.ResourcePendingMaintenanceActions")]
    [AWSCmdlet("Calls the Amazon Neptune ApplyPendingMaintenanceAction API operation.", Operation = new[] {"ApplyPendingMaintenanceAction"}, SelectReturnType = typeof(Amazon.Neptune.Model.ApplyPendingMaintenanceActionResponse))]
    [AWSCmdletOutput("Amazon.Neptune.Model.ResourcePendingMaintenanceActions or Amazon.Neptune.Model.ApplyPendingMaintenanceActionResponse",
        "This cmdlet returns an Amazon.Neptune.Model.ResourcePendingMaintenanceActions object.",
        "The service call response (type Amazon.Neptune.Model.ApplyPendingMaintenanceActionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SubmitNPTPendingMaintenanceActionCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        #region Parameter ApplyAction
        /// <summary>
        /// <para>
        /// <para>The pending maintenance action to apply to this resource.</para><para>Valid values: <code>system-update</code>, <code>db-upgrade</code></para>
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
        /// <para>A value that specifies the type of opt-in request, or undoes an opt-in request. An
        /// opt-in request of type <code>immediate</code> can't be undone.</para><para>Valid values:</para><ul><li><para><code>immediate</code> - Apply the maintenance action immediately.</para></li><li><para><code>next-maintenance</code> - Apply the maintenance action during the next maintenance
        /// window for the resource.</para></li><li><para><code>undo-opt-in</code> - Cancel any existing <code>next-maintenance</code> opt-in
        /// requests.</para></li></ul>
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
        /// applies to. For information about creating an ARN, see <a href="https://docs.aws.amazon.com/neptune/latest/UserGuide/tagging.ARN.html#tagging.ARN.Constructing">
        /// Constructing an Amazon Resource Name (ARN)</a>.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptune.Model.ApplyPendingMaintenanceActionResponse).
        /// Specifying the name of a property of type Amazon.Neptune.Model.ApplyPendingMaintenanceActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourcePendingMaintenanceActions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceIdentifier' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Submit-NPTPendingMaintenanceAction (ApplyPendingMaintenanceAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptune.Model.ApplyPendingMaintenanceActionResponse, SubmitNPTPendingMaintenanceActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceIdentifier;
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
            var request = new Amazon.Neptune.Model.ApplyPendingMaintenanceActionRequest();
            
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
        
        private Amazon.Neptune.Model.ApplyPendingMaintenanceActionResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.ApplyPendingMaintenanceActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "ApplyPendingMaintenanceAction");
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
            public System.String ResourceIdentifier { get; set; }
            public System.Func<Amazon.Neptune.Model.ApplyPendingMaintenanceActionResponse, SubmitNPTPendingMaintenanceActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourcePendingMaintenanceActions;
        }
        
    }
}

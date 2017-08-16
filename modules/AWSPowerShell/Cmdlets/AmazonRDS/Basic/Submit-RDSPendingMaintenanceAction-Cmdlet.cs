/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Applies a pending maintenance action to a resource (for example, to a DB instance).
    /// </summary>
    [Cmdlet("Submit", "RDSPendingMaintenanceAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.ResourcePendingMaintenanceActions")]
    [AWSCmdlet("Invokes the ApplyPendingMaintenanceAction operation against Amazon Relational Database Service.", Operation = new[] {"ApplyPendingMaintenanceAction"})]
    [AWSCmdletOutput("Amazon.RDS.Model.ResourcePendingMaintenanceActions",
        "This cmdlet returns a ResourcePendingMaintenanceActions object.",
        "The service call response (type Amazon.RDS.Model.ApplyPendingMaintenanceActionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SubmitRDSPendingMaintenanceActionCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter ApplyAction
        /// <summary>
        /// <para>
        /// <para>The pending maintenance action to apply to this resource.</para><para>Valid values: <code>system-update</code>, <code>db-upgrade</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ApplyAction { get; set; }
        #endregion
        
        #region Parameter OptInType
        /// <summary>
        /// <para>
        /// <para>A value that specifies the type of opt-in request, or undoes an opt-in request. An
        /// opt-in request of type <code>immediate</code> cannot be undone.</para><para>Valid values:</para><ul><li><para><code>immediate</code> - Apply the maintenance action immediately.</para></li><li><para><code>next-maintenance</code> - Apply the maintenance action during the next maintenance
        /// window for the resource.</para></li><li><para><code>undo-opt-in</code> - Cancel any existing <code>next-maintenance</code> opt-in
        /// requests.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OptInType { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The RDS Amazon Resource Name (ARN) of the resource that the pending maintenance action
        /// applies to. For information about creating an ARN, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Tagging.ARN.html#USER_Tagging.ARN.Constructing">
        /// Constructing an RDS Amazon Resource Name (ARN)</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Submit-RDSPendingMaintenanceAction (ApplyPendingMaintenanceAction)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ApplyAction = this.ApplyAction;
            context.OptInType = this.OptInType;
            context.ResourceIdentifier = this.ResourceIdentifier;
            
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
            var request = new Amazon.RDS.Model.ApplyPendingMaintenanceActionRequest();
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ResourcePendingMaintenanceActions;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.RDS.Model.ApplyPendingMaintenanceActionResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ApplyPendingMaintenanceActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ApplyPendingMaintenanceAction");
            try
            {
                #if DESKTOP
                return client.ApplyPendingMaintenanceAction(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ApplyPendingMaintenanceActionAsync(request);
                return task.Result;
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
        }
        
    }
}

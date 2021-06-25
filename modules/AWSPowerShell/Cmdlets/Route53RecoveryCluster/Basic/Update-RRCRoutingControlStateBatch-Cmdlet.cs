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
using Amazon.Route53RecoveryCluster;
using Amazon.Route53RecoveryCluster.Model;

namespace Amazon.PowerShell.Cmdlets.RRC
{
    /// <summary>
    /// Set multiple routing control states. You can set the value for each state to be On
    /// or Off. When the state is On, traffic flows to a cell. When it's off, traffic does
    /// not flow.
    /// 
    ///  
    /// <para>
    /// For more information about working with routing controls, see <a href="https://docs.aws.amazon.com/r53recovery/latest/dg/routing-control.html">Routing
    /// control</a> in the Route 53 Application Recovery Controller Developer Guide.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "RRCRoutingControlStateBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Route53 Recovery Cluster UpdateRoutingControlStates API operation.", Operation = new[] {"UpdateRoutingControlStates"}, SelectReturnType = typeof(Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse))]
    [AWSCmdletOutput("None or Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateRRCRoutingControlStateBatchCmdlet : AmazonRoute53RecoveryClusterClientCmdlet, IExecutor
    {
        
        #region Parameter UpdateRoutingControlStateEntry
        /// <summary>
        /// <para>
        /// <para>A set of routing control entries that you want to update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("UpdateRoutingControlStateEntries")]
        public Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateEntry[] UpdateRoutingControlStateEntry { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse).
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UpdateRoutingControlStateEntry), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RRCRoutingControlStateBatch (UpdateRoutingControlStates)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse, UpdateRRCRoutingControlStateBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.UpdateRoutingControlStateEntry != null)
            {
                context.UpdateRoutingControlStateEntry = new List<Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateEntry>(this.UpdateRoutingControlStateEntry);
            }
            #if MODULAR
            if (this.UpdateRoutingControlStateEntry == null && ParameterWasBound(nameof(this.UpdateRoutingControlStateEntry)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateRoutingControlStateEntry which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesRequest();
            
            if (cmdletContext.UpdateRoutingControlStateEntry != null)
            {
                request.UpdateRoutingControlStateEntries = cmdletContext.UpdateRoutingControlStateEntry;
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
        
        private Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse CallAWSServiceOperation(IAmazonRoute53RecoveryCluster client, Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Route53 Recovery Cluster", "UpdateRoutingControlStates");
            try
            {
                #if DESKTOP
                return client.UpdateRoutingControlStates(request);
                #elif CORECLR
                return client.UpdateRoutingControlStatesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateEntry> UpdateRoutingControlStateEntry { get; set; }
            public System.Func<Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse, UpdateRRCRoutingControlStateBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

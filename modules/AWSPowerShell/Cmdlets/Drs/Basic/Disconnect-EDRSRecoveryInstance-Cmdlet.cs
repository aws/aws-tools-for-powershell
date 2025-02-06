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
using Amazon.Drs;
using Amazon.Drs.Model;

namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Disconnect a Recovery Instance from Elastic Disaster Recovery. Data replication is
    /// stopped immediately. All AWS resources created by Elastic Disaster Recovery for enabling
    /// the replication of the Recovery Instance will be terminated / deleted within 90 minutes.
    /// If the agent on the Recovery Instance has not been prevented from communicating with
    /// the Elastic Disaster Recovery service, then it will receive a command to uninstall
    /// itself (within approximately 10 minutes). The following properties of the Recovery
    /// Instance will be changed immediately: dataReplicationInfo.dataReplicationState will
    /// be set to DISCONNECTED; The totalStorageBytes property for each of dataReplicationInfo.replicatedDisks
    /// will be set to zero; dataReplicationInfo.lagDuration and dataReplicationInfo.lagDuration
    /// will be nullified.
    /// </summary>
    [Cmdlet("Disconnect", "EDRSRecoveryInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service DisconnectRecoveryInstance API operation.", Operation = new[] {"DisconnectRecoveryInstance"}, SelectReturnType = typeof(Amazon.Drs.Model.DisconnectRecoveryInstanceResponse))]
    [AWSCmdletOutput("None or Amazon.Drs.Model.DisconnectRecoveryInstanceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Drs.Model.DisconnectRecoveryInstanceResponse) be returned by specifying '-Select *'."
    )]
    public partial class DisconnectEDRSRecoveryInstanceCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RecoveryInstanceID
        /// <summary>
        /// <para>
        /// <para>The ID of the Recovery Instance to disconnect.</para>
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
        public System.String RecoveryInstanceID { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.DisconnectRecoveryInstanceResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecoveryInstanceID), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disconnect-EDRSRecoveryInstance (DisconnectRecoveryInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.DisconnectRecoveryInstanceResponse, DisconnectEDRSRecoveryInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RecoveryInstanceID = this.RecoveryInstanceID;
            #if MODULAR
            if (this.RecoveryInstanceID == null && ParameterWasBound(nameof(this.RecoveryInstanceID)))
            {
                WriteWarning("You are passing $null as a value for parameter RecoveryInstanceID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Drs.Model.DisconnectRecoveryInstanceRequest();
            
            if (cmdletContext.RecoveryInstanceID != null)
            {
                request.RecoveryInstanceID = cmdletContext.RecoveryInstanceID;
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
        
        private Amazon.Drs.Model.DisconnectRecoveryInstanceResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.DisconnectRecoveryInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "DisconnectRecoveryInstance");
            try
            {
                #if DESKTOP
                return client.DisconnectRecoveryInstance(request);
                #elif CORECLR
                return client.DisconnectRecoveryInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String RecoveryInstanceID { get; set; }
            public System.Func<Amazon.Drs.Model.DisconnectRecoveryInstanceResponse, DisconnectEDRSRecoveryInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

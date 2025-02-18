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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Modifies the settings of an Aurora Limitless Database DB shard group. You can change
    /// one or more settings by specifying these parameters and the new values in the request.
    /// </summary>
    [Cmdlet("Edit", "RDSDBShardGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.ModifyDBShardGroupResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBShardGroup API operation.", Operation = new[] {"ModifyDBShardGroup"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyDBShardGroupResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.ModifyDBShardGroupResponse",
        "This cmdlet returns an Amazon.RDS.Model.ModifyDBShardGroupResponse object containing multiple properties."
    )]
    public partial class EditRDSDBShardGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComputeRedundancy
        /// <summary>
        /// <para>
        /// <para>Specifies whether to create standby DB shard groups for the DB shard group. Valid
        /// values are the following:</para><ul><li><para>0 - Creates a DB shard group without a standby DB shard group. This is the default
        /// value.</para></li><li><para>1 - Creates a DB shard group with a standby DB shard group in a different Availability
        /// Zone (AZ).</para></li><li><para>2 - Creates a DB shard group with two standby DB shard groups in two different AZs.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeRedundancy { get; set; }
        #endregion
        
        #region Parameter DBShardGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of the DB shard group to modify.</para>
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
        public System.String DBShardGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter MaxACU
        /// <summary>
        /// <para>
        /// <para>The maximum capacity of the DB shard group in Aurora capacity units (ACUs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? MaxACU { get; set; }
        #endregion
        
        #region Parameter MinACU
        /// <summary>
        /// <para>
        /// <para>The minimum capacity of the DB shard group in Aurora capacity units (ACUs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? MinACU { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyDBShardGroupResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyDBShardGroupResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBShardGroupIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBShardGroup (ModifyDBShardGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyDBShardGroupResponse, EditRDSDBShardGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComputeRedundancy = this.ComputeRedundancy;
            context.DBShardGroupIdentifier = this.DBShardGroupIdentifier;
            #if MODULAR
            if (this.DBShardGroupIdentifier == null && ParameterWasBound(nameof(this.DBShardGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBShardGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxACU = this.MaxACU;
            context.MinACU = this.MinACU;
            
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
            var request = new Amazon.RDS.Model.ModifyDBShardGroupRequest();
            
            if (cmdletContext.ComputeRedundancy != null)
            {
                request.ComputeRedundancy = cmdletContext.ComputeRedundancy.Value;
            }
            if (cmdletContext.DBShardGroupIdentifier != null)
            {
                request.DBShardGroupIdentifier = cmdletContext.DBShardGroupIdentifier;
            }
            if (cmdletContext.MaxACU != null)
            {
                request.MaxACU = cmdletContext.MaxACU.Value;
            }
            if (cmdletContext.MinACU != null)
            {
                request.MinACU = cmdletContext.MinACU.Value;
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
        
        private Amazon.RDS.Model.ModifyDBShardGroupResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBShardGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBShardGroup");
            try
            {
                return client.ModifyDBShardGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ComputeRedundancy { get; set; }
            public System.String DBShardGroupIdentifier { get; set; }
            public System.Double? MaxACU { get; set; }
            public System.Double? MinACU { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyDBShardGroupResponse, EditRDSDBShardGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

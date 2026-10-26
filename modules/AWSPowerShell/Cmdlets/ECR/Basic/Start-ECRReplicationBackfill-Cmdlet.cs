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
using Amazon.ECR;
using Amazon.ECR.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Starts a replication backfill for a registry. A replication backfill replicates a
    /// registry's existing images that match its replication configuration to the specified
    /// destination. Use the <a>DescribeReplicationBackfillResults</a> operation to monitor
    /// the progress of a replication backfill, and to retrieve its per-image results after
    /// it reaches a terminal status.
    /// 
    ///  <note><para>
    /// The destination must already be configured in the registry's replication configuration.
    /// </para></note><note><para>
    /// Only one replication backfill can be in progress for a given destination Region at
    /// a time. Starting a replication backfill for a destination Region that already has
    /// one in progress fails with a <c>ReplicationBackfillInProgressException</c>. In addition,
    /// a registry can have at most 10 replication backfills in progress at once. Starting
    /// a replication backfill that would exceed this limit fails with a <c>LimitExceededException</c>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "ECRReplicationBackfill", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECR.Model.StartReplicationBackfillResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry StartReplicationBackfill API operation.", Operation = new[] {"StartReplicationBackfill"}, SelectReturnType = typeof(Amazon.ECR.Model.StartReplicationBackfillResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.StartReplicationBackfillResponse",
        "This cmdlet returns an Amazon.ECR.Model.StartReplicationBackfillResponse object containing multiple properties."
    )]
    public partial class StartECRReplicationBackfillCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Destination_Region
        /// <summary>
        /// <para>
        /// <para>The Region to replicate to.</para>
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
        public System.String Destination_Region { get; set; }
        #endregion
        
        #region Parameter Destination_RegistryId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the Amazon ECR private registry to replicate
        /// to. When configuring cross-Region replication within your own registry, specify your
        /// own account ID.</para>
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
        public System.String Destination_RegistryId { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the registry from which to start
        /// the replication backfill. If you do not specify a registry, the default registry is
        /// assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.StartReplicationBackfillResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.StartReplicationBackfillResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Destination_RegistryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ECRReplicationBackfill (StartReplicationBackfill)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.StartReplicationBackfillResponse, StartECRReplicationBackfillCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Destination_Region = this.Destination_Region;
            #if MODULAR
            if (this.Destination_Region == null && ParameterWasBound(nameof(this.Destination_Region)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination_Region which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Destination_RegistryId = this.Destination_RegistryId;
            #if MODULAR
            if (this.Destination_RegistryId == null && ParameterWasBound(nameof(this.Destination_RegistryId)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination_RegistryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegistryId = this.RegistryId;
            
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
            var request = new Amazon.ECR.Model.StartReplicationBackfillRequest();
            
            
             // populate Destination
            var requestDestinationIsNull = true;
            request.Destination = new Amazon.ECR.Model.ReplicationDestination();
            System.String requestDestination_destination_Region = null;
            if (cmdletContext.Destination_Region != null)
            {
                requestDestination_destination_Region = cmdletContext.Destination_Region;
            }
            if (requestDestination_destination_Region != null)
            {
                request.Destination.Region = requestDestination_destination_Region;
                requestDestinationIsNull = false;
            }
            System.String requestDestination_destination_RegistryId = null;
            if (cmdletContext.Destination_RegistryId != null)
            {
                requestDestination_destination_RegistryId = cmdletContext.Destination_RegistryId;
            }
            if (requestDestination_destination_RegistryId != null)
            {
                request.Destination.RegistryId = requestDestination_destination_RegistryId;
                requestDestinationIsNull = false;
            }
             // determine if request.Destination should be set to null
            if (requestDestinationIsNull)
            {
                request.Destination = null;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
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
        
        private Amazon.ECR.Model.StartReplicationBackfillResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.StartReplicationBackfillRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "StartReplicationBackfill");
            try
            {
                return client.StartReplicationBackfillAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Destination_Region { get; set; }
            public System.String Destination_RegistryId { get; set; }
            public System.String RegistryId { get; set; }
            public System.Func<Amazon.ECR.Model.StartReplicationBackfillResponse, StartECRReplicationBackfillCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

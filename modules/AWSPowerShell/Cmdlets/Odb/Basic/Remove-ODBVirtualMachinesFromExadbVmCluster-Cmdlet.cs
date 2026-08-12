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
using Amazon.Odb;
using Amazon.Odb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Removes virtual machines from the specified Exascale VM cluster.
    /// </summary>
    [Cmdlet("Remove", "ODBVirtualMachinesFromExadbVmCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Odb.Model.DisassociateVirtualMachinesFromExadbVmClusterResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services DisassociateVirtualMachinesFromExadbVmCluster API operation.", Operation = new[] {"DisassociateVirtualMachinesFromExadbVmCluster"}, SelectReturnType = typeof(Amazon.Odb.Model.DisassociateVirtualMachinesFromExadbVmClusterResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.DisassociateVirtualMachinesFromExadbVmClusterResponse",
        "This cmdlet returns an Amazon.Odb.Model.DisassociateVirtualMachinesFromExadbVmClusterResponse object containing multiple properties."
    )]
    public partial class RemoveODBVirtualMachinesFromExadbVmClusterCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DbNodeId
        /// <summary>
        /// <para>
        /// <para>The list of DB node IDs to remove from the Exascale VM cluster.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("DbNodeIds")]
        public System.String[] DbNodeId { get; set; }
        #endregion
        
        #region Parameter ExadbVmClusterId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Exascale VM cluster to remove virtual machines from.</para>
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
        public System.String ExadbVmClusterId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.DisassociateVirtualMachinesFromExadbVmClusterResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.DisassociateVirtualMachinesFromExadbVmClusterResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ODBVirtualMachinesFromExadbVmCluster (DisassociateVirtualMachinesFromExadbVmCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.DisassociateVirtualMachinesFromExadbVmClusterResponse, RemoveODBVirtualMachinesFromExadbVmClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DbNodeId != null)
            {
                context.DbNodeId = new List<System.String>(this.DbNodeId);
            }
            #if MODULAR
            if (this.DbNodeId == null && ParameterWasBound(nameof(this.DbNodeId)))
            {
                WriteWarning("You are passing $null as a value for parameter DbNodeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExadbVmClusterId = this.ExadbVmClusterId;
            #if MODULAR
            if (this.ExadbVmClusterId == null && ParameterWasBound(nameof(this.ExadbVmClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExadbVmClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Odb.Model.DisassociateVirtualMachinesFromExadbVmClusterRequest();
            
            if (cmdletContext.DbNodeId != null)
            {
                request.DbNodeIds = cmdletContext.DbNodeId;
            }
            if (cmdletContext.ExadbVmClusterId != null)
            {
                request.ExadbVmClusterId = cmdletContext.ExadbVmClusterId;
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
        
        private Amazon.Odb.Model.DisassociateVirtualMachinesFromExadbVmClusterResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.DisassociateVirtualMachinesFromExadbVmClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "DisassociateVirtualMachinesFromExadbVmCluster");
            try
            {
                return client.DisassociateVirtualMachinesFromExadbVmClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> DbNodeId { get; set; }
            public System.String ExadbVmClusterId { get; set; }
            public System.Func<Amazon.Odb.Model.DisassociateVirtualMachinesFromExadbVmClusterResponse, RemoveODBVirtualMachinesFromExadbVmClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

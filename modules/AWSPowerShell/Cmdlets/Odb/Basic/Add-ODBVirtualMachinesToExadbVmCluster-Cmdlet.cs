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
    /// Adds virtual machines to the specified Exascale VM cluster.
    /// </summary>
    [Cmdlet("Add", "ODBVirtualMachinesToExadbVmCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.AssociateVirtualMachinesToExadbVmClusterResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services AssociateVirtualMachinesToExadbVmCluster API operation.", Operation = new[] {"AssociateVirtualMachinesToExadbVmCluster"}, SelectReturnType = typeof(Amazon.Odb.Model.AssociateVirtualMachinesToExadbVmClusterResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.AssociateVirtualMachinesToExadbVmClusterResponse",
        "This cmdlet returns an Amazon.Odb.Model.AssociateVirtualMachinesToExadbVmClusterResponse object containing multiple properties."
    )]
    public partial class AddODBVirtualMachinesToExadbVmClusterCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DesiredNodeCount
        /// <summary>
        /// <para>
        /// <para>The desired number of nodes in the Exascale VM cluster after the association.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? DesiredNodeCount { get; set; }
        #endregion
        
        #region Parameter ExadbVmClusterId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Exascale VM cluster to add virtual machines to.</para>
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
        public System.String ExadbVmClusterId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.AssociateVirtualMachinesToExadbVmClusterResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.AssociateVirtualMachinesToExadbVmClusterResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExadbVmClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-ODBVirtualMachinesToExadbVmCluster (AssociateVirtualMachinesToExadbVmCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.AssociateVirtualMachinesToExadbVmClusterResponse, AddODBVirtualMachinesToExadbVmClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DesiredNodeCount = this.DesiredNodeCount;
            #if MODULAR
            if (this.DesiredNodeCount == null && ParameterWasBound(nameof(this.DesiredNodeCount)))
            {
                WriteWarning("You are passing $null as a value for parameter DesiredNodeCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Odb.Model.AssociateVirtualMachinesToExadbVmClusterRequest();
            
            if (cmdletContext.DesiredNodeCount != null)
            {
                request.DesiredNodeCount = cmdletContext.DesiredNodeCount.Value;
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
        
        private Amazon.Odb.Model.AssociateVirtualMachinesToExadbVmClusterResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.AssociateVirtualMachinesToExadbVmClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "AssociateVirtualMachinesToExadbVmCluster");
            try
            {
                return client.AssociateVirtualMachinesToExadbVmClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? DesiredNodeCount { get; set; }
            public System.String ExadbVmClusterId { get; set; }
            public System.Func<Amazon.Odb.Model.AssociateVirtualMachinesToExadbVmClusterResponse, AddODBVirtualMachinesToExadbVmClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

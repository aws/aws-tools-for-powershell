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
using Amazon.DocDB;
using Amazon.DocDB.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Detaches an Amazon DocumentDB secondary cluster from a global cluster. The cluster
    /// becomes a standalone cluster with read-write capability instead of being read-only
    /// and receiving data from a primary in a different region. 
    /// 
    ///  <note><para>
    /// This action only applies to Amazon DocumentDB clusters.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "DOCFromGlobalCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.DocDB.Model.GlobalCluster")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) RemoveFromGlobalCluster API operation.", Operation = new[] {"RemoveFromGlobalCluster"}, SelectReturnType = typeof(Amazon.DocDB.Model.RemoveFromGlobalClusterResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.GlobalCluster or Amazon.DocDB.Model.RemoveFromGlobalClusterResponse",
        "This cmdlet returns an Amazon.DocDB.Model.GlobalCluster object.",
        "The service call response (type Amazon.DocDB.Model.RemoveFromGlobalClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveDOCFromGlobalClusterCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DbClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) identifying the cluster that was detached from the
        /// Amazon DocumentDB global cluster. </para>
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
        public System.String DbClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter GlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The cluster identifier to detach from the Amazon DocumentDB global cluster. </para>
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
        public System.String GlobalClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.RemoveFromGlobalClusterResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.RemoveFromGlobalClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GlobalCluster";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GlobalClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-DOCFromGlobalCluster (RemoveFromGlobalCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.RemoveFromGlobalClusterResponse, RemoveDOCFromGlobalClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DbClusterIdentifier = this.DbClusterIdentifier;
            #if MODULAR
            if (this.DbClusterIdentifier == null && ParameterWasBound(nameof(this.DbClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DbClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GlobalClusterIdentifier = this.GlobalClusterIdentifier;
            #if MODULAR
            if (this.GlobalClusterIdentifier == null && ParameterWasBound(nameof(this.GlobalClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DocDB.Model.RemoveFromGlobalClusterRequest();
            
            if (cmdletContext.DbClusterIdentifier != null)
            {
                request.DbClusterIdentifier = cmdletContext.DbClusterIdentifier;
            }
            if (cmdletContext.GlobalClusterIdentifier != null)
            {
                request.GlobalClusterIdentifier = cmdletContext.GlobalClusterIdentifier;
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
        
        private Amazon.DocDB.Model.RemoveFromGlobalClusterResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.RemoveFromGlobalClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "RemoveFromGlobalCluster");
            try
            {
                return client.RemoveFromGlobalClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DbClusterIdentifier { get; set; }
            public System.String GlobalClusterIdentifier { get; set; }
            public System.Func<Amazon.DocDB.Model.RemoveFromGlobalClusterResponse, RemoveDOCFromGlobalClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalCluster;
        }
        
    }
}

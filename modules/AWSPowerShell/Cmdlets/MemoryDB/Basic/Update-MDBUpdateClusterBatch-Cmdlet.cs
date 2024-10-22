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
using Amazon.MemoryDB;
using Amazon.MemoryDB.Model;

namespace Amazon.PowerShell.Cmdlets.MDB
{
    /// <summary>
    /// Apply the service update to a list of clusters supplied. For more information on service
    /// updates and applying them, see <a href="https://docs.aws.amazon.com/MemoryDB/latest/devguide/managing-updates.html#applying-updates">Applying
    /// the service updates</a>.
    /// </summary>
    [Cmdlet("Update", "MDBUpdateClusterBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MemoryDB.Model.BatchUpdateClusterResponse")]
    [AWSCmdlet("Calls the Amazon MemoryDB BatchUpdateCluster API operation.", Operation = new[] {"BatchUpdateCluster"}, SelectReturnType = typeof(Amazon.MemoryDB.Model.BatchUpdateClusterResponse))]
    [AWSCmdletOutput("Amazon.MemoryDB.Model.BatchUpdateClusterResponse",
        "This cmdlet returns an Amazon.MemoryDB.Model.BatchUpdateClusterResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMDBUpdateClusterBatchCmdlet : AmazonMemoryDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The cluster names to apply the updates.</para>
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
        [Alias("ClusterNames")]
        public System.String[] ClusterName { get; set; }
        #endregion
        
        #region Parameter ServiceUpdate_ServiceUpdateNameToApply
        /// <summary>
        /// <para>
        /// <para>The unique ID of the service update</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ServiceUpdate_ServiceUpdateNameToApply { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MemoryDB.Model.BatchUpdateClusterResponse).
        /// Specifying the name of a property of type Amazon.MemoryDB.Model.BatchUpdateClusterResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceUpdate_ServiceUpdateNameToApply), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MDBUpdateClusterBatch (BatchUpdateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MemoryDB.Model.BatchUpdateClusterResponse, UpdateMDBUpdateClusterBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ClusterName != null)
            {
                context.ClusterName = new List<System.String>(this.ClusterName);
            }
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceUpdate_ServiceUpdateNameToApply = this.ServiceUpdate_ServiceUpdateNameToApply;
            
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
            var request = new Amazon.MemoryDB.Model.BatchUpdateClusterRequest();
            
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterNames = cmdletContext.ClusterName;
            }
            
             // populate ServiceUpdate
            var requestServiceUpdateIsNull = true;
            request.ServiceUpdate = new Amazon.MemoryDB.Model.ServiceUpdateRequest();
            System.String requestServiceUpdate_serviceUpdate_ServiceUpdateNameToApply = null;
            if (cmdletContext.ServiceUpdate_ServiceUpdateNameToApply != null)
            {
                requestServiceUpdate_serviceUpdate_ServiceUpdateNameToApply = cmdletContext.ServiceUpdate_ServiceUpdateNameToApply;
            }
            if (requestServiceUpdate_serviceUpdate_ServiceUpdateNameToApply != null)
            {
                request.ServiceUpdate.ServiceUpdateNameToApply = requestServiceUpdate_serviceUpdate_ServiceUpdateNameToApply;
                requestServiceUpdateIsNull = false;
            }
             // determine if request.ServiceUpdate should be set to null
            if (requestServiceUpdateIsNull)
            {
                request.ServiceUpdate = null;
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
        
        private Amazon.MemoryDB.Model.BatchUpdateClusterResponse CallAWSServiceOperation(IAmazonMemoryDB client, Amazon.MemoryDB.Model.BatchUpdateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MemoryDB", "BatchUpdateCluster");
            try
            {
                #if DESKTOP
                return client.BatchUpdateCluster(request);
                #elif CORECLR
                return client.BatchUpdateClusterAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ClusterName { get; set; }
            public System.String ServiceUpdate_ServiceUpdateNameToApply { get; set; }
            public System.Func<Amazon.MemoryDB.Model.BatchUpdateClusterResponse, UpdateMDBUpdateClusterBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

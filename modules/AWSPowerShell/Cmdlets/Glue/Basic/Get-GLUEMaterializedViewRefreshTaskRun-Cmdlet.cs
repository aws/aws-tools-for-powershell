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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Get the associated metadata/information for a task run, given a task run ID.
    /// </summary>
    [Cmdlet("Get", "GLUEMaterializedViewRefreshTaskRun")]
    [OutputType("Amazon.Glue.Model.MaterializedViewRefreshTaskRun")]
    [AWSCmdlet("Calls the AWS Glue GetMaterializedViewRefreshTaskRun API operation.", Operation = new[] {"GetMaterializedViewRefreshTaskRun"}, SelectReturnType = typeof(Amazon.Glue.Model.GetMaterializedViewRefreshTaskRunResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.MaterializedViewRefreshTaskRun or Amazon.Glue.Model.GetMaterializedViewRefreshTaskRunResponse",
        "This cmdlet returns an Amazon.Glue.Model.MaterializedViewRefreshTaskRun object.",
        "The service call response (type Amazon.Glue.Model.GetMaterializedViewRefreshTaskRunResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGLUEMaterializedViewRefreshTaskRunCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog where the table resides. If none is supplied, the account
        /// ID is used by default.</para>
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
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter MaterializedViewRefreshTaskRunId
        /// <summary>
        /// <para>
        /// <para>The identifier for the particular materialized view refresh task run.</para>
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
        public System.String MaterializedViewRefreshTaskRunId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MaterializedViewRefreshTaskRun'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetMaterializedViewRefreshTaskRunResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetMaterializedViewRefreshTaskRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MaterializedViewRefreshTaskRun";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetMaterializedViewRefreshTaskRunResponse, GetGLUEMaterializedViewRefreshTaskRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CatalogId = this.CatalogId;
            #if MODULAR
            if (this.CatalogId == null && ParameterWasBound(nameof(this.CatalogId)))
            {
                WriteWarning("You are passing $null as a value for parameter CatalogId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaterializedViewRefreshTaskRunId = this.MaterializedViewRefreshTaskRunId;
            #if MODULAR
            if (this.MaterializedViewRefreshTaskRunId == null && ParameterWasBound(nameof(this.MaterializedViewRefreshTaskRunId)))
            {
                WriteWarning("You are passing $null as a value for parameter MaterializedViewRefreshTaskRunId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.GetMaterializedViewRefreshTaskRunRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.MaterializedViewRefreshTaskRunId != null)
            {
                request.MaterializedViewRefreshTaskRunId = cmdletContext.MaterializedViewRefreshTaskRunId;
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
        
        private Amazon.Glue.Model.GetMaterializedViewRefreshTaskRunResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetMaterializedViewRefreshTaskRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetMaterializedViewRefreshTaskRun");
            try
            {
                return client.GetMaterializedViewRefreshTaskRunAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CatalogId { get; set; }
            public System.String MaterializedViewRefreshTaskRunId { get; set; }
            public System.Func<Amazon.Glue.Model.GetMaterializedViewRefreshTaskRunResponse, GetGLUEMaterializedViewRefreshTaskRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MaterializedViewRefreshTaskRun;
        }
        
    }
}

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
using Amazon.DSQL;
using Amazon.DSQL.Model;

namespace Amazon.PowerShell.Cmdlets.DSQL
{
    /// <summary>
    /// Deletes a multi-Region cluster in Amazon Aurora DSQL.
    /// </summary>
    [Cmdlet("Remove", "DSQLMultiRegionCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Aurora DSQL DeleteMultiRegionClusters API operation.", Operation = new[] {"DeleteMultiRegionClusters"}, SelectReturnType = typeof(Amazon.DSQL.Model.DeleteMultiRegionClustersResponse))]
    [AWSCmdletOutput("None or Amazon.DSQL.Model.DeleteMultiRegionClustersResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DSQL.Model.DeleteMultiRegionClustersResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveDSQLMultiRegionClusterCmdlet : AmazonDSQLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LinkedClusterArn
        /// <summary>
        /// <para>
        /// <para>The ARNs of the clusters linked to the cluster you want to delete. also deletes these
        /// clusters as part of the operation.</para>
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
        [Alias("LinkedClusterArns")]
        public System.String[] LinkedClusterArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully. The subsequent
        /// retries with the same client token return the result from the original successful
        /// request and they have no additional effect.</para><para>If you don't specify a client token, the Amazon Web Services SDK automatically generates
        /// one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DSQL.Model.DeleteMultiRegionClustersResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LinkedClusterArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-DSQLMultiRegionCluster (DeleteMultiRegionClusters)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DSQL.Model.DeleteMultiRegionClustersResponse, RemoveDSQLMultiRegionClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.LinkedClusterArn != null)
            {
                context.LinkedClusterArn = new List<System.String>(this.LinkedClusterArn);
            }
            #if MODULAR
            if (this.LinkedClusterArn == null && ParameterWasBound(nameof(this.LinkedClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LinkedClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DSQL.Model.DeleteMultiRegionClustersRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.LinkedClusterArn != null)
            {
                request.LinkedClusterArns = cmdletContext.LinkedClusterArn;
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
        
        private Amazon.DSQL.Model.DeleteMultiRegionClustersResponse CallAWSServiceOperation(IAmazonDSQL client, Amazon.DSQL.Model.DeleteMultiRegionClustersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Aurora DSQL", "DeleteMultiRegionClusters");
            try
            {
                #if DESKTOP
                return client.DeleteMultiRegionClusters(request);
                #elif CORECLR
                return client.DeleteMultiRegionClustersAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<System.String> LinkedClusterArn { get; set; }
            public System.Func<Amazon.DSQL.Model.DeleteMultiRegionClustersResponse, RemoveDSQLMultiRegionClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

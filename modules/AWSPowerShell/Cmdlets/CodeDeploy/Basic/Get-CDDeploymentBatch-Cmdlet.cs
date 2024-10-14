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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Gets information about one or more deployments. The maximum number of deployments
    /// that can be returned is 25.
    /// </summary>
    [Cmdlet("Get", "CDDeploymentBatch")]
    [OutputType("Amazon.CodeDeploy.Model.DeploymentInfo")]
    [AWSCmdlet("Calls the AWS CodeDeploy BatchGetDeployments API operation.", Operation = new[] {"BatchGetDeployments"}, SelectReturnType = typeof(Amazon.CodeDeploy.Model.BatchGetDeploymentsResponse), LegacyAlias="Get-CDDeployments")]
    [AWSCmdletOutput("Amazon.CodeDeploy.Model.DeploymentInfo or Amazon.CodeDeploy.Model.BatchGetDeploymentsResponse",
        "This cmdlet returns a collection of Amazon.CodeDeploy.Model.DeploymentInfo objects.",
        "The service call response (type Amazon.CodeDeploy.Model.BatchGetDeploymentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCDDeploymentBatchCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeploymentId
        /// <summary>
        /// <para>
        /// <para> A list of deployment IDs, separated by spaces. The maximum number of deployment IDs
        /// you can specify is 25.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DeploymentIds")]
        public System.String[] DeploymentId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeploymentsInfo'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeDeploy.Model.BatchGetDeploymentsResponse).
        /// Specifying the name of a property of type Amazon.CodeDeploy.Model.BatchGetDeploymentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeploymentsInfo";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DeploymentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DeploymentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DeploymentId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeDeploy.Model.BatchGetDeploymentsResponse, GetCDDeploymentBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DeploymentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.DeploymentId != null)
            {
                context.DeploymentId = new List<System.String>(this.DeploymentId);
            }
            #if MODULAR
            if (this.DeploymentId == null && ParameterWasBound(nameof(this.DeploymentId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeDeploy.Model.BatchGetDeploymentsRequest();
            
            if (cmdletContext.DeploymentId != null)
            {
                request.DeploymentIds = cmdletContext.DeploymentId;
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
        
        private Amazon.CodeDeploy.Model.BatchGetDeploymentsResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.BatchGetDeploymentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "BatchGetDeployments");
            try
            {
                #if DESKTOP
                return client.BatchGetDeployments(request);
                #elif CORECLR
                return client.BatchGetDeploymentsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> DeploymentId { get; set; }
            public System.Func<Amazon.CodeDeploy.Model.BatchGetDeploymentsResponse, GetCDDeploymentBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeploymentsInfo;
        }
        
    }
}

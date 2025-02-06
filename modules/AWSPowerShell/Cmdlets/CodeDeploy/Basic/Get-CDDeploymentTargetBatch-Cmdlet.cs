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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Returns an array of one or more targets associated with a deployment. This method
    /// works with all compute types and should be used instead of the deprecated <c>BatchGetDeploymentInstances</c>.
    /// The maximum number of targets that can be returned is 25.
    /// 
    ///  
    /// <para>
    ///  The type of targets returned depends on the deployment's compute platform or deployment
    /// method: 
    /// </para><ul><li><para><b>EC2/On-premises</b>: Information about Amazon EC2 instance targets. 
    /// </para></li><li><para><b>Lambda</b>: Information about Lambda functions targets. 
    /// </para></li><li><para><b>Amazon ECS</b>: Information about Amazon ECS service targets. 
    /// </para></li><li><para><b>CloudFormation</b>: Information about targets of blue/green deployments initiated
    /// by a CloudFormation stack update.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "CDDeploymentTargetBatch")]
    [OutputType("Amazon.CodeDeploy.Model.DeploymentTarget")]
    [AWSCmdlet("Calls the AWS CodeDeploy BatchGetDeploymentTargets API operation.", Operation = new[] {"BatchGetDeploymentTargets"}, SelectReturnType = typeof(Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsResponse))]
    [AWSCmdletOutput("Amazon.CodeDeploy.Model.DeploymentTarget or Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsResponse",
        "This cmdlet returns a collection of Amazon.CodeDeploy.Model.DeploymentTarget objects.",
        "The service call response (type Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCDDeploymentTargetBatchCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeploymentId
        /// <summary>
        /// <para>
        /// <para> The unique ID of a deployment. </para>
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
        public System.String DeploymentId { get; set; }
        #endregion
        
        #region Parameter TargetId
        /// <summary>
        /// <para>
        /// <para> The unique IDs of the deployment targets. The compute platform of the deployment
        /// determines the type of the targets and their formats. The maximum number of deployment
        /// target IDs you can specify is 25.</para><ul><li><para> For deployments that use the EC2/On-premises compute platform, the target IDs are
        /// Amazon EC2 or on-premises instances IDs, and their target type is <c>instanceTarget</c>.
        /// </para></li><li><para> For deployments that use the Lambda compute platform, the target IDs are the names
        /// of Lambda functions, and their target type is <c>instanceTarget</c>. </para></li><li><para> For deployments that use the Amazon ECS compute platform, the target IDs are pairs
        /// of Amazon ECS clusters and services specified using the format <c>&lt;clustername&gt;:&lt;servicename&gt;</c>.
        /// Their target type is <c>ecsTarget</c>. </para></li><li><para> For deployments that are deployed with CloudFormation, the target IDs are CloudFormation
        /// stack IDs. Their target type is <c>cloudFormationTarget</c>. </para></li></ul>
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
        [Alias("TargetIds")]
        public System.String[] TargetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeploymentTargets'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsResponse).
        /// Specifying the name of a property of type Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeploymentTargets";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsResponse, GetCDDeploymentTargetBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeploymentId = this.DeploymentId;
            #if MODULAR
            if (this.DeploymentId == null && ParameterWasBound(nameof(this.DeploymentId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TargetId != null)
            {
                context.TargetId = new List<System.String>(this.TargetId);
            }
            #if MODULAR
            if (this.TargetId == null && ParameterWasBound(nameof(this.TargetId)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsRequest();
            
            if (cmdletContext.DeploymentId != null)
            {
                request.DeploymentId = cmdletContext.DeploymentId;
            }
            if (cmdletContext.TargetId != null)
            {
                request.TargetIds = cmdletContext.TargetId;
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
        
        private Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "BatchGetDeploymentTargets");
            try
            {
                #if DESKTOP
                return client.BatchGetDeploymentTargets(request);
                #elif CORECLR
                return client.BatchGetDeploymentTargetsAsync(request).GetAwaiter().GetResult();
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
            public System.String DeploymentId { get; set; }
            public List<System.String> TargetId { get; set; }
            public System.Func<Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsResponse, GetCDDeploymentTargetBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeploymentTargets;
        }
        
    }
}

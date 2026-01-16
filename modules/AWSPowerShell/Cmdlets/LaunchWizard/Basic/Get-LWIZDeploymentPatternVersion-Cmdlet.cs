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
using Amazon.LaunchWizard;
using Amazon.LaunchWizard.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LWIZ
{
    /// <summary>
    /// Returns information about a deployment pattern version.
    /// </summary>
    [Cmdlet("Get", "LWIZDeploymentPatternVersion")]
    [OutputType("Amazon.LaunchWizard.Model.DeploymentPatternVersionDataSummary")]
    [AWSCmdlet("Calls the AWS Launch Wizard GetDeploymentPatternVersion API operation.", Operation = new[] {"GetDeploymentPatternVersion"}, SelectReturnType = typeof(Amazon.LaunchWizard.Model.GetDeploymentPatternVersionResponse))]
    [AWSCmdletOutput("Amazon.LaunchWizard.Model.DeploymentPatternVersionDataSummary or Amazon.LaunchWizard.Model.GetDeploymentPatternVersionResponse",
        "This cmdlet returns an Amazon.LaunchWizard.Model.DeploymentPatternVersionDataSummary object.",
        "The service call response (type Amazon.LaunchWizard.Model.GetDeploymentPatternVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLWIZDeploymentPatternVersionCmdlet : AmazonLaunchWizardClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeploymentPatternName
        /// <summary>
        /// <para>
        /// <para>The name of the deployment pattern. You can use the <a href="https://docs.aws.amazon.com/launchwizard/latest/APIReference/API_ListWorkloadDeploymentPatterns.html"><c>ListWorkloadDeploymentPatterns</c></a> operation to discover supported values
        /// for this parameter.</para>
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
        public System.String DeploymentPatternName { get; set; }
        #endregion
        
        #region Parameter DeploymentPatternVersionName
        /// <summary>
        /// <para>
        /// <para>The name of the deployment pattern version.</para>
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
        public System.String DeploymentPatternVersionName { get; set; }
        #endregion
        
        #region Parameter WorkloadName
        /// <summary>
        /// <para>
        /// <para>The name of the workload. You can use the <a href="https://docs.aws.amazon.com/launchwizard/latest/APIReference/API_ListWorkloads.html"><c>ListWorkloads</c></a> operation to discover supported values for this parameter.</para>
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
        public System.String WorkloadName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeploymentPatternVersion'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LaunchWizard.Model.GetDeploymentPatternVersionResponse).
        /// Specifying the name of a property of type Amazon.LaunchWizard.Model.GetDeploymentPatternVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeploymentPatternVersion";
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
                context.Select = CreateSelectDelegate<Amazon.LaunchWizard.Model.GetDeploymentPatternVersionResponse, GetLWIZDeploymentPatternVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeploymentPatternName = this.DeploymentPatternName;
            #if MODULAR
            if (this.DeploymentPatternName == null && ParameterWasBound(nameof(this.DeploymentPatternName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentPatternName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeploymentPatternVersionName = this.DeploymentPatternVersionName;
            #if MODULAR
            if (this.DeploymentPatternVersionName == null && ParameterWasBound(nameof(this.DeploymentPatternVersionName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentPatternVersionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkloadName = this.WorkloadName;
            #if MODULAR
            if (this.WorkloadName == null && ParameterWasBound(nameof(this.WorkloadName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkloadName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LaunchWizard.Model.GetDeploymentPatternVersionRequest();
            
            if (cmdletContext.DeploymentPatternName != null)
            {
                request.DeploymentPatternName = cmdletContext.DeploymentPatternName;
            }
            if (cmdletContext.DeploymentPatternVersionName != null)
            {
                request.DeploymentPatternVersionName = cmdletContext.DeploymentPatternVersionName;
            }
            if (cmdletContext.WorkloadName != null)
            {
                request.WorkloadName = cmdletContext.WorkloadName;
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
        
        private Amazon.LaunchWizard.Model.GetDeploymentPatternVersionResponse CallAWSServiceOperation(IAmazonLaunchWizard client, Amazon.LaunchWizard.Model.GetDeploymentPatternVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Launch Wizard", "GetDeploymentPatternVersion");
            try
            {
                return client.GetDeploymentPatternVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DeploymentPatternName { get; set; }
            public System.String DeploymentPatternVersionName { get; set; }
            public System.String WorkloadName { get; set; }
            public System.Func<Amazon.LaunchWizard.Model.GetDeploymentPatternVersionResponse, GetLWIZDeploymentPatternVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeploymentPatternVersion;
        }
        
    }
}

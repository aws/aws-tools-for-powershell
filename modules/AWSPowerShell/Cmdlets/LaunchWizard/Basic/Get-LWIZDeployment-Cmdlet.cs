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
using Amazon.LaunchWizard;
using Amazon.LaunchWizard.Model;

namespace Amazon.PowerShell.Cmdlets.LWIZ
{
    /// <summary>
    /// Returns information about the deployment.
    /// </summary>
    [Cmdlet("Get", "LWIZDeployment")]
    [OutputType("Amazon.LaunchWizard.Model.DeploymentData")]
    [AWSCmdlet("Calls the AWS Launch Wizard GetDeployment API operation.", Operation = new[] {"GetDeployment"}, SelectReturnType = typeof(Amazon.LaunchWizard.Model.GetDeploymentResponse))]
    [AWSCmdletOutput("Amazon.LaunchWizard.Model.DeploymentData or Amazon.LaunchWizard.Model.GetDeploymentResponse",
        "This cmdlet returns an Amazon.LaunchWizard.Model.DeploymentData object.",
        "The service call response (type Amazon.LaunchWizard.Model.GetDeploymentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLWIZDeploymentCmdlet : AmazonLaunchWizardClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeploymentId
        /// <summary>
        /// <para>
        /// <para>The ID of the deployment.</para>
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
        public System.String DeploymentId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Deployment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LaunchWizard.Model.GetDeploymentResponse).
        /// Specifying the name of a property of type Amazon.LaunchWizard.Model.GetDeploymentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Deployment";
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
                context.Select = CreateSelectDelegate<Amazon.LaunchWizard.Model.GetDeploymentResponse, GetLWIZDeploymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeploymentId = this.DeploymentId;
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
            var request = new Amazon.LaunchWizard.Model.GetDeploymentRequest();
            
            if (cmdletContext.DeploymentId != null)
            {
                request.DeploymentId = cmdletContext.DeploymentId;
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
        
        private Amazon.LaunchWizard.Model.GetDeploymentResponse CallAWSServiceOperation(IAmazonLaunchWizard client, Amazon.LaunchWizard.Model.GetDeploymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Launch Wizard", "GetDeployment");
            try
            {
                #if DESKTOP
                return client.GetDeployment(request);
                #elif CORECLR
                return client.GetDeploymentAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.LaunchWizard.Model.GetDeploymentResponse, GetLWIZDeploymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Deployment;
        }
        
    }
}

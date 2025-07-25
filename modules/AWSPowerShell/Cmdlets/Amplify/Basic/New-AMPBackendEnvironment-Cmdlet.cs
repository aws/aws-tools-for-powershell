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
using Amazon.Amplify;
using Amazon.Amplify.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AMP
{
    /// <summary>
    /// Creates a new backend environment for an Amplify app. 
    /// 
    ///  
    /// <para>
    /// This API is available only to Amplify Gen 1 applications where the backend is created
    /// using Amplify Studio or the Amplify command line interface (CLI). This API isn’t available
    /// to Amplify Gen 2 applications. When you deploy an application with Amplify Gen 2,
    /// you provision the app's backend infrastructure using Typescript code.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AMPBackendEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Amplify.Model.BackendEnvironment")]
    [AWSCmdlet("Calls the AWS Amplify CreateBackendEnvironment API operation.", Operation = new[] {"CreateBackendEnvironment"}, SelectReturnType = typeof(Amazon.Amplify.Model.CreateBackendEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.Amplify.Model.BackendEnvironment or Amazon.Amplify.Model.CreateBackendEnvironmentResponse",
        "This cmdlet returns an Amazon.Amplify.Model.BackendEnvironment object.",
        "The service call response (type Amazon.Amplify.Model.CreateBackendEnvironmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAMPBackendEnvironmentCmdlet : AmazonAmplifyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The unique ID for an Amplify app. </para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter DeploymentArtifact
        /// <summary>
        /// <para>
        /// <para>The name of deployment artifacts. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentArtifacts")]
        public System.String DeploymentArtifact { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name for the backend environment. </para>
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
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The AWS CloudFormation stack name of a backend environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BackendEnvironment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Amplify.Model.CreateBackendEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.Amplify.Model.CreateBackendEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BackendEnvironment";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMPBackendEnvironment (CreateBackendEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Amplify.Model.CreateBackendEnvironmentResponse, NewAMPBackendEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeploymentArtifact = this.DeploymentArtifact;
            context.EnvironmentName = this.EnvironmentName;
            #if MODULAR
            if (this.EnvironmentName == null && ParameterWasBound(nameof(this.EnvironmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StackName = this.StackName;
            
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
            var request = new Amazon.Amplify.Model.CreateBackendEnvironmentRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.DeploymentArtifact != null)
            {
                request.DeploymentArtifacts = cmdletContext.DeploymentArtifact;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
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
        
        private Amazon.Amplify.Model.CreateBackendEnvironmentResponse CallAWSServiceOperation(IAmazonAmplify client, Amazon.Amplify.Model.CreateBackendEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify", "CreateBackendEnvironment");
            try
            {
                return client.CreateBackendEnvironmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.String DeploymentArtifact { get; set; }
            public System.String EnvironmentName { get; set; }
            public System.String StackName { get; set; }
            public System.Func<Amazon.Amplify.Model.CreateBackendEnvironmentResponse, NewAMPBackendEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BackendEnvironment;
        }
        
    }
}

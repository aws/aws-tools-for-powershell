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
using Amazon.Finspace;
using Amazon.Finspace.Model;

namespace Amazon.PowerShell.Cmdlets.FINSP
{
    /// <summary>
    /// Allows you to update code configuration on a running cluster. By using this API you
    /// can update the code, the initialization script path, and the command line arguments
    /// for a specific cluster. The configuration that you want to update will override any
    /// existing configurations on the cluster.
    /// </summary>
    [Cmdlet("Update", "FINSPKxClusterCodeConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the FinSpace User Environment Management Service UpdateKxClusterCodeConfiguration API operation.", Operation = new[] {"UpdateKxClusterCodeConfiguration"}, SelectReturnType = typeof(Amazon.Finspace.Model.UpdateKxClusterCodeConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.Finspace.Model.UpdateKxClusterCodeConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Finspace.Model.UpdateKxClusterCodeConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateFINSPKxClusterCodeConfigurationCmdlet : AmazonFinspaceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the cluster.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter CommandLineArgument
        /// <summary>
        /// <para>
        /// <para>Specifies the key-value pairs to make them available inside the cluster.</para><para>You cannot update this parameter for a <c>NO_RESTART</c> deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommandLineArguments")]
        public Amazon.Finspace.Model.KxCommandLineArgument[] CommandLineArgument { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_DeploymentStrategy
        /// <summary>
        /// <para>
        /// <para> The type of deployment that you want on a cluster. </para><ul><li><para>ROLLING – This options updates the cluster by stopping the exiting q process and starting
        /// a new q process with updated configuration.</para></li><li><para>NO_RESTART – This option updates the cluster without stopping the running q process.
        /// It is only available for <c>GP</c> type cluster. This option is quicker as it reduces
        /// the turn around time to update configuration on a cluster. </para><para>With this deployment mode, you cannot update the <c>initializationScript</c> and <c>commandLineArguments</c>
        /// parameters.</para></li><li><para>FORCE – This option updates the cluster by immediately stopping all the running processes
        /// before starting up new ones with the updated configuration. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Finspace.KxClusterCodeDeploymentStrategy")]
        public Amazon.Finspace.KxClusterCodeDeploymentStrategy DeploymentConfiguration_DeploymentStrategy { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para> A unique identifier of the kdb environment. </para>
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter InitializationScript
        /// <summary>
        /// <para>
        /// <para>Specifies a Q program that will be run at launch of a cluster. It is a relative path
        /// within <i>.zip</i> file that contains the custom code, which will be loaded on the
        /// cluster. It must include the file name itself. For example, <c>somedir/init.q</c>.</para><para>You cannot update this parameter for a <c>NO_RESTART</c> deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitializationScript { get; set; }
        #endregion
        
        #region Parameter Code_S3Bucket
        /// <summary>
        /// <para>
        /// <para>A unique name for the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code_S3Bucket { get; set; }
        #endregion
        
        #region Parameter Code_S3Key
        /// <summary>
        /// <para>
        /// <para>The full S3 path (excluding bucket) to the .zip file. This file contains the code
        /// that is loaded onto the cluster when it's started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code_S3Key { get; set; }
        #endregion
        
        #region Parameter Code_S3ObjectVersion
        /// <summary>
        /// <para>
        /// <para>The version of an S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code_S3ObjectVersion { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures idempotency. This token expires in 10 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Finspace.Model.UpdateKxClusterCodeConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FINSPKxClusterCodeConfiguration (UpdateKxClusterCodeConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Finspace.Model.UpdateKxClusterCodeConfigurationResponse, UpdateFINSPKxClusterCodeConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Code_S3Bucket = this.Code_S3Bucket;
            context.Code_S3Key = this.Code_S3Key;
            context.Code_S3ObjectVersion = this.Code_S3ObjectVersion;
            if (this.CommandLineArgument != null)
            {
                context.CommandLineArgument = new List<Amazon.Finspace.Model.KxCommandLineArgument>(this.CommandLineArgument);
            }
            context.DeploymentConfiguration_DeploymentStrategy = this.DeploymentConfiguration_DeploymentStrategy;
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InitializationScript = this.InitializationScript;
            
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
            var request = new Amazon.Finspace.Model.UpdateKxClusterCodeConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate Code
            request.Code = new Amazon.Finspace.Model.CodeConfiguration();
            System.String requestCode_code_S3Bucket = null;
            if (cmdletContext.Code_S3Bucket != null)
            {
                requestCode_code_S3Bucket = cmdletContext.Code_S3Bucket;
            }
            if (requestCode_code_S3Bucket != null)
            {
                request.Code.S3Bucket = requestCode_code_S3Bucket;
            }
            System.String requestCode_code_S3Key = null;
            if (cmdletContext.Code_S3Key != null)
            {
                requestCode_code_S3Key = cmdletContext.Code_S3Key;
            }
            if (requestCode_code_S3Key != null)
            {
                request.Code.S3Key = requestCode_code_S3Key;
            }
            System.String requestCode_code_S3ObjectVersion = null;
            if (cmdletContext.Code_S3ObjectVersion != null)
            {
                requestCode_code_S3ObjectVersion = cmdletContext.Code_S3ObjectVersion;
            }
            if (requestCode_code_S3ObjectVersion != null)
            {
                request.Code.S3ObjectVersion = requestCode_code_S3ObjectVersion;
            }
            if (cmdletContext.CommandLineArgument != null)
            {
                request.CommandLineArguments = cmdletContext.CommandLineArgument;
            }
            
             // populate DeploymentConfiguration
            var requestDeploymentConfigurationIsNull = true;
            request.DeploymentConfiguration = new Amazon.Finspace.Model.KxClusterCodeDeploymentConfiguration();
            Amazon.Finspace.KxClusterCodeDeploymentStrategy requestDeploymentConfiguration_deploymentConfiguration_DeploymentStrategy = null;
            if (cmdletContext.DeploymentConfiguration_DeploymentStrategy != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentStrategy = cmdletContext.DeploymentConfiguration_DeploymentStrategy;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_DeploymentStrategy != null)
            {
                request.DeploymentConfiguration.DeploymentStrategy = requestDeploymentConfiguration_deploymentConfiguration_DeploymentStrategy;
                requestDeploymentConfigurationIsNull = false;
            }
             // determine if request.DeploymentConfiguration should be set to null
            if (requestDeploymentConfigurationIsNull)
            {
                request.DeploymentConfiguration = null;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.InitializationScript != null)
            {
                request.InitializationScript = cmdletContext.InitializationScript;
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
        
        private Amazon.Finspace.Model.UpdateKxClusterCodeConfigurationResponse CallAWSServiceOperation(IAmazonFinspace client, Amazon.Finspace.Model.UpdateKxClusterCodeConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace User Environment Management Service", "UpdateKxClusterCodeConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateKxClusterCodeConfiguration(request);
                #elif CORECLR
                return client.UpdateKxClusterCodeConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterName { get; set; }
            public System.String Code_S3Bucket { get; set; }
            public System.String Code_S3Key { get; set; }
            public System.String Code_S3ObjectVersion { get; set; }
            public List<Amazon.Finspace.Model.KxCommandLineArgument> CommandLineArgument { get; set; }
            public Amazon.Finspace.KxClusterCodeDeploymentStrategy DeploymentConfiguration_DeploymentStrategy { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.String InitializationScript { get; set; }
            public System.Func<Amazon.Finspace.Model.UpdateKxClusterCodeConfigurationResponse, UpdateFINSPKxClusterCodeConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

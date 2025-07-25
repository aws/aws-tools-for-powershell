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
using Amazon.Proton;
using Amazon.Proton.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PRO
{
    /// <summary>
    /// In an environment account, update an environment account connection to use a new IAM
    /// role.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-env-account-connections.html">Environment
    /// account connections</a> in the <i>Proton User guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "PROEnvironmentAccountConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Proton.Model.EnvironmentAccountConnection")]
    [AWSCmdlet("Calls the AWS Proton UpdateEnvironmentAccountConnection API operation.", Operation = new[] {"UpdateEnvironmentAccountConnection"}, SelectReturnType = typeof(Amazon.Proton.Model.UpdateEnvironmentAccountConnectionResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.EnvironmentAccountConnection or Amazon.Proton.Model.UpdateEnvironmentAccountConnectionResponse",
        "This cmdlet returns an Amazon.Proton.Model.EnvironmentAccountConnection object.",
        "The service call response (type Amazon.Proton.Model.UpdateEnvironmentAccountConnectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePROEnvironmentAccountConnectionCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CodebuildRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM service role in the environment account.
        /// Proton uses this role to provision infrastructure resources using CodeBuild-based
        /// provisioning in the associated environment account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CodebuildRoleArn { get; set; }
        #endregion
        
        #region Parameter ComponentRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM service role that Proton uses when provisioning
        /// directly defined components in the associated environment account. It determines the
        /// scope of infrastructure that a component can provision in the account.</para><para>The environment account connection must have a <c>componentRoleArn</c> to allow directly
        /// defined components to be associated with any environments running in the account.</para><para>For more information about components, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-components.html">Proton
        /// components</a> in the <i>Proton User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComponentRoleArn { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the environment account connection to update.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM service role that's associated with the
        /// environment account connection to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnvironmentAccountConnection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.UpdateEnvironmentAccountConnectionResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.UpdateEnvironmentAccountConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnvironmentAccountConnection";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PROEnvironmentAccountConnection (UpdateEnvironmentAccountConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.UpdateEnvironmentAccountConnectionResponse, UpdatePROEnvironmentAccountConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CodebuildRoleArn = this.CodebuildRoleArn;
            context.ComponentRoleArn = this.ComponentRoleArn;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.Proton.Model.UpdateEnvironmentAccountConnectionRequest();
            
            if (cmdletContext.CodebuildRoleArn != null)
            {
                request.CodebuildRoleArn = cmdletContext.CodebuildRoleArn;
            }
            if (cmdletContext.ComponentRoleArn != null)
            {
                request.ComponentRoleArn = cmdletContext.ComponentRoleArn;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.Proton.Model.UpdateEnvironmentAccountConnectionResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.UpdateEnvironmentAccountConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "UpdateEnvironmentAccountConnection");
            try
            {
                return client.UpdateEnvironmentAccountConnectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CodebuildRoleArn { get; set; }
            public System.String ComponentRoleArn { get; set; }
            public System.String Id { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.Proton.Model.UpdateEnvironmentAccountConnectionResponse, UpdatePROEnvironmentAccountConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnvironmentAccountConnection;
        }
        
    }
}

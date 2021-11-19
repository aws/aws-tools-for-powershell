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
using Amazon.Proton;
using Amazon.Proton.Model;

namespace Amazon.PowerShell.Cmdlets.PRO
{
    /// <summary>
    /// Create an environment account connection in an environment account so that environment
    /// infrastructure resources can be provisioned in the environment account from a management
    /// account.
    /// 
    ///  
    /// <para>
    /// An environment account connection is a secure bi-directional connection between a
    /// <i>management account</i> and an <i>environment account</i> that maintains authorization
    /// and permissions. For more information, see <a href="https://docs.aws.amazon.com/proton/latest/adminguide/ag-env-account-connections.html">Environment
    /// account connections</a> in the <i>Proton Administrator guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "PROEnvironmentAccountConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Proton.Model.EnvironmentAccountConnection")]
    [AWSCmdlet("Calls the AWS Proton CreateEnvironmentAccountConnection API operation.", Operation = new[] {"CreateEnvironmentAccountConnection"}, SelectReturnType = typeof(Amazon.Proton.Model.CreateEnvironmentAccountConnectionResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.EnvironmentAccountConnection or Amazon.Proton.Model.CreateEnvironmentAccountConnectionResponse",
        "This cmdlet returns an Amazon.Proton.Model.EnvironmentAccountConnection object.",
        "The service call response (type Amazon.Proton.Model.CreateEnvironmentAccountConnectionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPROEnvironmentAccountConnectionCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the Proton environment that's created in the associated management account.</para>
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
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter ManagementAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the management account that accepts or rejects the environment account connection.
        /// You create an manage the Proton environment in this account. If the management account
        /// accepts the environment account connection, Proton can use the associated IAM role
        /// to provision environment infrastructure resources in the associated environment account.</para>
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
        public System.String ManagementAccountId { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM service role that's created in the environment
        /// account. Proton uses this role to provision infrastructure resources in the associated
        /// environment account.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags for your environment account connection. For more information, see <a href="https://docs.aws.amazon.com/proton/latest/adminguide/resources.html">Proton
        /// resources and tagging</a> in the <i>Proton Administrator Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Proton.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>When included, if two identical requests are made with the same client token, Proton
        /// returns the environment account connection that the first request created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnvironmentAccountConnection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.CreateEnvironmentAccountConnectionResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.CreateEnvironmentAccountConnectionResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PROEnvironmentAccountConnection (CreateEnvironmentAccountConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.CreateEnvironmentAccountConnectionResponse, NewPROEnvironmentAccountConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.EnvironmentName = this.EnvironmentName;
            #if MODULAR
            if (this.EnvironmentName == null && ParameterWasBound(nameof(this.EnvironmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ManagementAccountId = this.ManagementAccountId;
            #if MODULAR
            if (this.ManagementAccountId == null && ParameterWasBound(nameof(this.ManagementAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter ManagementAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Proton.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.Proton.Model.CreateEnvironmentAccountConnectionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.ManagementAccountId != null)
            {
                request.ManagementAccountId = cmdletContext.ManagementAccountId;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Proton.Model.CreateEnvironmentAccountConnectionResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.CreateEnvironmentAccountConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "CreateEnvironmentAccountConnection");
            try
            {
                #if DESKTOP
                return client.CreateEnvironmentAccountConnection(request);
                #elif CORECLR
                return client.CreateEnvironmentAccountConnectionAsync(request).GetAwaiter().GetResult();
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
            public System.String EnvironmentName { get; set; }
            public System.String ManagementAccountId { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.Proton.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Proton.Model.CreateEnvironmentAccountConnectionResponse, NewPROEnvironmentAccountConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnvironmentAccountConnection;
        }
        
    }
}

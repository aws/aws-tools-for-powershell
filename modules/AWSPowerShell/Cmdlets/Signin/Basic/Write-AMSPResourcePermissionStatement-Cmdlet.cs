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
using Amazon.Signin;
using Amazon.Signin.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AMSP
{
    /// <summary>
    /// Create a permission statement in the account's SignIn resource-based policy
    /// </summary>
    [Cmdlet("Write", "AMSPResourcePermissionStatement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Sign-In Data Plane PutResourcePermissionStatement API operation.", Operation = new[] {"PutResourcePermissionStatement"}, SelectReturnType = typeof(Amazon.Signin.Model.PutResourcePermissionStatementResponse))]
    [AWSCmdletOutput("System.String or Amazon.Signin.Model.PutResourcePermissionStatementResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Signin.Model.PutResourcePermissionStatementResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteAMSPResourcePermissionStatementCmdlet : AmazonSigninClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConsoleSourceVpce
        /// <summary>
        /// <para>
        /// <para>Console VPC endpoint identifier</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConsoleSourceVpce { get; set; }
        #endregion
        
        #region Parameter ExcludedPrincipal
        /// <summary>
        /// <para>
        /// <para>Principal to exclude from the permission statement</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExcludedPrincipal { get; set; }
        #endregion
        
        #region Parameter RequestedRegion
        /// <summary>
        /// <para>
        /// <para>AWS region where the VPC and VPC endpoint reside Required when sourceVpc or signinSourceVpce/consoleSourceVpce
        /// is provided</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestedRegion { get; set; }
        #endregion
        
        #region Parameter SigninSourceVpce
        /// <summary>
        /// <para>
        /// <para>SignIn VPC endpoint identifier</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SigninSourceVpce { get; set; }
        #endregion
        
        #region Parameter SourceIp
        /// <summary>
        /// <para>
        /// <para>Source IP address</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceIp { get; set; }
        #endregion
        
        #region Parameter SourceVpc
        /// <summary>
        /// <para>
        /// <para>VPC identifier to restrict console access</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceVpc { get; set; }
        #endregion
        
        #region Parameter VpcSourceIp
        /// <summary>
        /// <para>
        /// <para>Source IP address within VPC</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcSourceIp { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token for the request</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StatementId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Signin.Model.PutResourcePermissionStatementResponse).
        /// Specifying the name of a property of type Amazon.Signin.Model.PutResourcePermissionStatementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StatementId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-AMSPResourcePermissionStatement (PutResourcePermissionStatement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Signin.Model.PutResourcePermissionStatementResponse, WriteAMSPResourcePermissionStatementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ConsoleSourceVpce = this.ConsoleSourceVpce;
            context.ExcludedPrincipal = this.ExcludedPrincipal;
            context.RequestedRegion = this.RequestedRegion;
            context.SigninSourceVpce = this.SigninSourceVpce;
            context.SourceIp = this.SourceIp;
            context.SourceVpc = this.SourceVpc;
            context.VpcSourceIp = this.VpcSourceIp;
            
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
            var request = new Amazon.Signin.Model.PutResourcePermissionStatementRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConsoleSourceVpce != null)
            {
                request.ConsoleSourceVpce = cmdletContext.ConsoleSourceVpce;
            }
            if (cmdletContext.ExcludedPrincipal != null)
            {
                request.ExcludedPrincipal = cmdletContext.ExcludedPrincipal;
            }
            if (cmdletContext.RequestedRegion != null)
            {
                request.RequestedRegion = cmdletContext.RequestedRegion;
            }
            if (cmdletContext.SigninSourceVpce != null)
            {
                request.SigninSourceVpce = cmdletContext.SigninSourceVpce;
            }
            if (cmdletContext.SourceIp != null)
            {
                request.SourceIp = cmdletContext.SourceIp;
            }
            if (cmdletContext.SourceVpc != null)
            {
                request.SourceVpc = cmdletContext.SourceVpc;
            }
            if (cmdletContext.VpcSourceIp != null)
            {
                request.VpcSourceIp = cmdletContext.VpcSourceIp;
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
        
        private Amazon.Signin.Model.PutResourcePermissionStatementResponse CallAWSServiceOperation(IAmazonSignin client, Amazon.Signin.Model.PutResourcePermissionStatementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Sign-In Data Plane", "PutResourcePermissionStatement");
            try
            {
                return client.PutResourcePermissionStatementAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConsoleSourceVpce { get; set; }
            public System.String ExcludedPrincipal { get; set; }
            public System.String RequestedRegion { get; set; }
            public System.String SigninSourceVpce { get; set; }
            public System.String SourceIp { get; set; }
            public System.String SourceVpc { get; set; }
            public System.String VpcSourceIp { get; set; }
            public System.Func<Amazon.Signin.Model.PutResourcePermissionStatementResponse, WriteAMSPResourcePermissionStatementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StatementId;
        }
        
    }
}

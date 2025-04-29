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
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Changes the settings for an existing DB proxy.
    /// </summary>
    [Cmdlet("Edit", "RDSDBProxy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBProxy")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBProxy API operation.", Operation = new[] {"ModifyDBProxy"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyDBProxyResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBProxy or Amazon.RDS.Model.ModifyDBProxyResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBProxy object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBProxyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditRDSDBProxyCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Auth
        /// <summary>
        /// <para>
        /// <para>The new authentication settings for the <c>DBProxy</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.RDS.Model.UserAuthConfig[] Auth { get; set; }
        #endregion
        
        #region Parameter DBProxyName
        /// <summary>
        /// <para>
        /// <para>The identifier for the <c>DBProxy</c> to modify.</para>
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
        public System.String DBProxyName { get; set; }
        #endregion
        
        #region Parameter DebugLogging
        /// <summary>
        /// <para>
        /// <para>Whether the proxy includes detailed information about SQL statements in its logs.
        /// This information helps you to debug issues involving SQL behavior or the performance
        /// and scalability of the proxy connections. The debug information includes the text
        /// of SQL statements that you submit through the proxy. Thus, only enable this setting
        /// when needed for debugging, and only when you have security measures in place to safeguard
        /// any sensitive information that appears in the logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DebugLogging { get; set; }
        #endregion
        
        #region Parameter IdleClientTimeout
        /// <summary>
        /// <para>
        /// <para>The number of seconds that a connection to the proxy can be inactive before the proxy
        /// disconnects it. You can set this value higher or lower than the connection timeout
        /// limit for the associated database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? IdleClientTimeout { get; set; }
        #endregion
        
        #region Parameter NewDBProxyName
        /// <summary>
        /// <para>
        /// <para>The new identifier for the <c>DBProxy</c>. An identifier must begin with a letter
        /// and must contain only ASCII letters, digits, and hyphens; it can't end with a hyphen
        /// or contain two consecutive hyphens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewDBProxyName { get; set; }
        #endregion
        
        #region Parameter RequireTLS
        /// <summary>
        /// <para>
        /// <para>Whether Transport Layer Security (TLS) encryption is required for connections to the
        /// proxy. By enabling this setting, you can enforce encrypted TLS connections to the
        /// proxy, even if the associated database doesn't use TLS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RequireTLS { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that the proxy uses to access secrets
        /// in Amazon Web Services Secrets Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The new list of security groups for the <c>DBProxy</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBProxy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyDBProxyResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyDBProxyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBProxy";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBProxyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBProxy (ModifyDBProxy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyDBProxyResponse, EditRDSDBProxyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Auth != null)
            {
                context.Auth = new List<Amazon.RDS.Model.UserAuthConfig>(this.Auth);
            }
            context.DBProxyName = this.DBProxyName;
            #if MODULAR
            if (this.DBProxyName == null && ParameterWasBound(nameof(this.DBProxyName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBProxyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DebugLogging = this.DebugLogging;
            context.IdleClientTimeout = this.IdleClientTimeout;
            context.NewDBProxyName = this.NewDBProxyName;
            context.RequireTLS = this.RequireTLS;
            context.RoleArn = this.RoleArn;
            if (this.SecurityGroup != null)
            {
                context.SecurityGroup = new List<System.String>(this.SecurityGroup);
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
            var request = new Amazon.RDS.Model.ModifyDBProxyRequest();
            
            if (cmdletContext.Auth != null)
            {
                request.Auth = cmdletContext.Auth;
            }
            if (cmdletContext.DBProxyName != null)
            {
                request.DBProxyName = cmdletContext.DBProxyName;
            }
            if (cmdletContext.DebugLogging != null)
            {
                request.DebugLogging = cmdletContext.DebugLogging.Value;
            }
            if (cmdletContext.IdleClientTimeout != null)
            {
                request.IdleClientTimeout = cmdletContext.IdleClientTimeout.Value;
            }
            if (cmdletContext.NewDBProxyName != null)
            {
                request.NewDBProxyName = cmdletContext.NewDBProxyName;
            }
            if (cmdletContext.RequireTLS != null)
            {
                request.RequireTLS = cmdletContext.RequireTLS.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SecurityGroup != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroup;
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
        
        private Amazon.RDS.Model.ModifyDBProxyResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBProxyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBProxy");
            try
            {
                return client.ModifyDBProxyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.RDS.Model.UserAuthConfig> Auth { get; set; }
            public System.String DBProxyName { get; set; }
            public System.Boolean? DebugLogging { get; set; }
            public System.Int32? IdleClientTimeout { get; set; }
            public System.String NewDBProxyName { get; set; }
            public System.Boolean? RequireTLS { get; set; }
            public System.String RoleArn { get; set; }
            public List<System.String> SecurityGroup { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyDBProxyResponse, EditRDSDBProxyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBProxy;
        }
        
    }
}

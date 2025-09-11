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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates a new DB proxy.
    /// </summary>
    [Cmdlet("New", "RDSDBProxy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBProxy")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateDBProxy API operation.", Operation = new[] {"CreateDBProxy"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateDBProxyResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBProxy or Amazon.RDS.Model.CreateDBProxyResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBProxy object.",
        "The service call response (type Amazon.RDS.Model.CreateDBProxyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRDSDBProxyCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Auth
        /// <summary>
        /// <para>
        /// <para>The authorization mechanism that the proxy uses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.RDS.Model.UserAuthConfig[] Auth { get; set; }
        #endregion
        
        #region Parameter DBProxyName
        /// <summary>
        /// <para>
        /// <para>The identifier for the proxy. This name must be unique for all proxies owned by your
        /// Amazon Web Services account in the specified Amazon Web Services Region. An identifier
        /// must begin with a letter and must contain only ASCII letters, digits, and hyphens;
        /// it can't end with a hyphen or contain two consecutive hyphens.</para>
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
        /// <para>Specifies whether the proxy logs detailed connection and query information. When you
        /// enable <c>DebugLogging</c>, the proxy captures connection details and connection pool
        /// behavior from your queries. Debug logging increases CloudWatch costs and can impact
        /// proxy performance. Enable this option only when you need to troubleshoot connection
        /// or performance issues.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DebugLogging { get; set; }
        #endregion
        
        #region Parameter DefaultAuthScheme
        /// <summary>
        /// <para>
        /// <para>The default authentication scheme that the proxy uses for client connections to the
        /// proxy and connections from the proxy to the underlying database. Valid values are
        /// <c>NONE</c> and <c>IAM_AUTH</c>. When set to <c>IAM_AUTH</c>, the proxy uses end-to-end
        /// IAM authentication to connect to the database. If you don't specify <c>DefaultAuthScheme</c>
        /// or specify this parameter as <c>NONE</c>, you must specify the <c>Auth</c> option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDS.DefaultAuthScheme")]
        public Amazon.RDS.DefaultAuthScheme DefaultAuthScheme { get; set; }
        #endregion
        
        #region Parameter EndpointNetworkType
        /// <summary>
        /// <para>
        /// <para>The network type of the DB proxy endpoint. The network type determines the IP version
        /// that the proxy endpoint supports.</para><para>Valid values:</para><ul><li><para><c>IPV4</c> - The proxy endpoint supports IPv4 only.</para></li><li><para><c>IPV6</c> - The proxy endpoint supports IPv6 only.</para></li><li><para><c>DUAL</c> - The proxy endpoint supports both IPv4 and IPv6.</para></li></ul><para>Default: <c>IPV4</c></para><para>Constraints:</para><ul><li><para>If you specify <c>IPV6</c> or <c>DUAL</c>, the VPC and all subnets must have an IPv6
        /// CIDR block.</para></li><li><para>If you specify <c>IPV6</c> or <c>DUAL</c>, the VPC tenancy cannot be <c>dedicated</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDS.EndpointNetworkType")]
        public Amazon.RDS.EndpointNetworkType EndpointNetworkType { get; set; }
        #endregion
        
        #region Parameter EngineFamily
        /// <summary>
        /// <para>
        /// <para>The kinds of databases that the proxy can connect to. This value determines which
        /// database network protocol the proxy recognizes when it interprets network traffic
        /// to and from the database. For Aurora MySQL, RDS for MariaDB, and RDS for MySQL databases,
        /// specify <c>MYSQL</c>. For Aurora PostgreSQL and RDS for PostgreSQL databases, specify
        /// <c>POSTGRESQL</c>. For RDS for Microsoft SQL Server, specify <c>SQLSERVER</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.RDS.EngineFamily")]
        public Amazon.RDS.EngineFamily EngineFamily { get; set; }
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
        
        #region Parameter RequireTLS
        /// <summary>
        /// <para>
        /// <para>Specifies whether Transport Layer Security (TLS) encryption is required for connections
        /// to the proxy. By enabling this setting, you can enforce encrypted TLS connections
        /// to the proxy.</para>
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
        /// <para>An optional set of key-value pairs to associate arbitrary data of your choosing with
        /// the proxy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetConnectionNetworkType
        /// <summary>
        /// <para>
        /// <para>The network type that the proxy uses to connect to the target database. The network
        /// type determines the IP version that the proxy uses for connections to the database.</para><para>Valid values:</para><ul><li><para><c>IPV4</c> - The proxy connects to the database using IPv4 only.</para></li><li><para><c>IPV6</c> - The proxy connects to the database using IPv6 only.</para></li></ul><para>Default: <c>IPV4</c></para><para>Constraints:</para><ul><li><para>If you specify <c>IPV6</c>, the database must support dual-stack mode. RDS doesn't
        /// support IPv6-only databases.</para></li><li><para>All targets registered with the proxy must be compatible with the specified network
        /// type.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDS.TargetConnectionNetworkType")]
        public Amazon.RDS.TargetConnectionNetworkType TargetConnectionNetworkType { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>One or more VPC security group IDs to associate with the new proxy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcSubnetId
        /// <summary>
        /// <para>
        /// <para>One or more VPC subnet IDs to associate with the new proxy.</para>
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
        [Alias("VpcSubnetIds")]
        public System.String[] VpcSubnetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBProxy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateDBProxyResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateDBProxyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBProxy";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBProxyName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBProxyName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBProxyName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBProxyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSDBProxy (CreateDBProxy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateDBProxyResponse, NewRDSDBProxyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBProxyName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.DefaultAuthScheme = this.DefaultAuthScheme;
            context.EndpointNetworkType = this.EndpointNetworkType;
            context.EngineFamily = this.EngineFamily;
            #if MODULAR
            if (this.EngineFamily == null && ParameterWasBound(nameof(this.EngineFamily)))
            {
                WriteWarning("You are passing $null as a value for parameter EngineFamily which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdleClientTimeout = this.IdleClientTimeout;
            context.RequireTLS = this.RequireTLS;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TargetConnectionNetworkType = this.TargetConnectionNetworkType;
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupId = new List<System.String>(this.VpcSecurityGroupId);
            }
            if (this.VpcSubnetId != null)
            {
                context.VpcSubnetId = new List<System.String>(this.VpcSubnetId);
            }
            #if MODULAR
            if (this.VpcSubnetId == null && ParameterWasBound(nameof(this.VpcSubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcSubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.CreateDBProxyRequest();
            
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
            if (cmdletContext.DefaultAuthScheme != null)
            {
                request.DefaultAuthScheme = cmdletContext.DefaultAuthScheme;
            }
            if (cmdletContext.EndpointNetworkType != null)
            {
                request.EndpointNetworkType = cmdletContext.EndpointNetworkType;
            }
            if (cmdletContext.EngineFamily != null)
            {
                request.EngineFamily = cmdletContext.EngineFamily;
            }
            if (cmdletContext.IdleClientTimeout != null)
            {
                request.IdleClientTimeout = cmdletContext.IdleClientTimeout.Value;
            }
            if (cmdletContext.RequireTLS != null)
            {
                request.RequireTLS = cmdletContext.RequireTLS.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetConnectionNetworkType != null)
            {
                request.TargetConnectionNetworkType = cmdletContext.TargetConnectionNetworkType;
            }
            if (cmdletContext.VpcSecurityGroupId != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupId;
            }
            if (cmdletContext.VpcSubnetId != null)
            {
                request.VpcSubnetIds = cmdletContext.VpcSubnetId;
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
        
        private Amazon.RDS.Model.CreateDBProxyResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateDBProxyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateDBProxy");
            try
            {
                #if DESKTOP
                return client.CreateDBProxy(request);
                #elif CORECLR
                return client.CreateDBProxyAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.RDS.Model.UserAuthConfig> Auth { get; set; }
            public System.String DBProxyName { get; set; }
            public System.Boolean? DebugLogging { get; set; }
            public Amazon.RDS.DefaultAuthScheme DefaultAuthScheme { get; set; }
            public Amazon.RDS.EndpointNetworkType EndpointNetworkType { get; set; }
            public Amazon.RDS.EngineFamily EngineFamily { get; set; }
            public System.Int32? IdleClientTimeout { get; set; }
            public System.Boolean? RequireTLS { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public Amazon.RDS.TargetConnectionNetworkType TargetConnectionNetworkType { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public List<System.String> VpcSubnetId { get; set; }
            public System.Func<Amazon.RDS.Model.CreateDBProxyResponse, NewRDSDBProxyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBProxy;
        }
        
    }
}

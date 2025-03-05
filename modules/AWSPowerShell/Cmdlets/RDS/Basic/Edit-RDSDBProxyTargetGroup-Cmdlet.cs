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

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Modifies the properties of a <c>DBProxyTargetGroup</c>.
    /// </summary>
    [Cmdlet("Edit", "RDSDBProxyTargetGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBProxyTargetGroup")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBProxyTargetGroup API operation.", Operation = new[] {"ModifyDBProxyTargetGroup"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyDBProxyTargetGroupResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBProxyTargetGroup or Amazon.RDS.Model.ModifyDBProxyTargetGroupResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBProxyTargetGroup object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBProxyTargetGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditRDSDBProxyTargetGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectionPoolConfig_ConnectionBorrowTimeout
        /// <summary>
        /// <para>
        /// <para>The number of seconds for a proxy to wait for a connection to become available in
        /// the connection pool. This setting only applies when the proxy has opened its maximum
        /// number of connections and all connections are busy with client sessions.</para><para>Default: <c>120</c></para><para>Constraints:</para><ul><li><para>Must be between 0 and 3600.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ConnectionPoolConfig_ConnectionBorrowTimeout { get; set; }
        #endregion
        
        #region Parameter DBProxyName
        /// <summary>
        /// <para>
        /// <para>The name of the proxy.</para>
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
        public System.String DBProxyName { get; set; }
        #endregion
        
        #region Parameter ConnectionPoolConfig_InitQuery
        /// <summary>
        /// <para>
        /// <para>One or more SQL statements for the proxy to run when opening each new database connection.
        /// Typically used with <c>SET</c> statements to make sure that each connection has identical
        /// settings such as time zone and character set. For multiple statements, use semicolons
        /// as the separator. You can also include multiple variables in a single <c>SET</c> statement,
        /// such as <c>SET x=1, y=2</c>.</para><para>Default: no initialization query</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionPoolConfig_InitQuery { get; set; }
        #endregion
        
        #region Parameter ConnectionPoolConfig_MaxConnectionsPercent
        /// <summary>
        /// <para>
        /// <para>The maximum size of the connection pool for each target in a target group. The value
        /// is expressed as a percentage of the <c>max_connections</c> setting for the RDS DB
        /// instance or Aurora DB cluster used by the target group.</para><para>If you specify <c>MaxIdleConnectionsPercent</c>, then you must also include a value
        /// for this parameter.</para><para>Default: <c>10</c> for RDS for Microsoft SQL Server, and <c>100</c> for all other
        /// engines</para><para>Constraints:</para><ul><li><para>Must be between 1 and 100.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ConnectionPoolConfig_MaxConnectionsPercent { get; set; }
        #endregion
        
        #region Parameter ConnectionPoolConfig_MaxIdleConnectionsPercent
        /// <summary>
        /// <para>
        /// <para>A value that controls how actively the proxy closes idle database connections in the
        /// connection pool. The value is expressed as a percentage of the <c>max_connections</c>
        /// setting for the RDS DB instance or Aurora DB cluster used by the target group. With
        /// a high value, the proxy leaves a high percentage of idle database connections open.
        /// A low value causes the proxy to close more idle connections and return them to the
        /// database.</para><para>If you specify this parameter, then you must also include a value for <c>MaxConnectionsPercent</c>.</para><para>Default: The default value is half of the value of <c>MaxConnectionsPercent</c>. For
        /// example, if <c>MaxConnectionsPercent</c> is 80, then the default value of <c>MaxIdleConnectionsPercent</c>
        /// is 40. If the value of <c>MaxConnectionsPercent</c> isn't specified, then for SQL
        /// Server, <c>MaxIdleConnectionsPercent</c> is <c>5</c>, and for all other engines, the
        /// default is <c>50</c>.</para><para>Constraints:</para><ul><li><para>Must be between 0 and the value of <c>MaxConnectionsPercent</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ConnectionPoolConfig_MaxIdleConnectionsPercent { get; set; }
        #endregion
        
        #region Parameter NewName
        /// <summary>
        /// <para>
        /// <para>The new name for the modified <c>DBProxyTarget</c>. An identifier must begin with
        /// a letter and must contain only ASCII letters, digits, and hyphens; it can't end with
        /// a hyphen or contain two consecutive hyphens.</para><para>You can't rename the <c>default</c> target group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewName { get; set; }
        #endregion
        
        #region Parameter ConnectionPoolConfig_SessionPinningFilter
        /// <summary>
        /// <para>
        /// <para>Each item in the list represents a class of SQL operations that normally cause all
        /// later statements in a session using a proxy to be pinned to the same underlying database
        /// connection. Including an item in the list exempts that class of SQL operations from
        /// the pinning behavior.</para><para>Default: no session pinning filters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectionPoolConfig_SessionPinningFilters")]
        public System.String[] ConnectionPoolConfig_SessionPinningFilter { get; set; }
        #endregion
        
        #region Parameter TargetGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the target group to modify.</para>
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
        public System.String TargetGroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBProxyTargetGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyDBProxyTargetGroupResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyDBProxyTargetGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBProxyTargetGroup";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBProxyTargetGroup (ModifyDBProxyTargetGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyDBProxyTargetGroupResponse, EditRDSDBProxyTargetGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectionPoolConfig_ConnectionBorrowTimeout = this.ConnectionPoolConfig_ConnectionBorrowTimeout;
            context.ConnectionPoolConfig_InitQuery = this.ConnectionPoolConfig_InitQuery;
            context.ConnectionPoolConfig_MaxConnectionsPercent = this.ConnectionPoolConfig_MaxConnectionsPercent;
            context.ConnectionPoolConfig_MaxIdleConnectionsPercent = this.ConnectionPoolConfig_MaxIdleConnectionsPercent;
            if (this.ConnectionPoolConfig_SessionPinningFilter != null)
            {
                context.ConnectionPoolConfig_SessionPinningFilter = new List<System.String>(this.ConnectionPoolConfig_SessionPinningFilter);
            }
            context.DBProxyName = this.DBProxyName;
            #if MODULAR
            if (this.DBProxyName == null && ParameterWasBound(nameof(this.DBProxyName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBProxyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewName = this.NewName;
            context.TargetGroupName = this.TargetGroupName;
            #if MODULAR
            if (this.TargetGroupName == null && ParameterWasBound(nameof(this.TargetGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.ModifyDBProxyTargetGroupRequest();
            
            
             // populate ConnectionPoolConfig
            var requestConnectionPoolConfigIsNull = true;
            request.ConnectionPoolConfig = new Amazon.RDS.Model.ConnectionPoolConfiguration();
            System.Int32? requestConnectionPoolConfig_connectionPoolConfig_ConnectionBorrowTimeout = null;
            if (cmdletContext.ConnectionPoolConfig_ConnectionBorrowTimeout != null)
            {
                requestConnectionPoolConfig_connectionPoolConfig_ConnectionBorrowTimeout = cmdletContext.ConnectionPoolConfig_ConnectionBorrowTimeout.Value;
            }
            if (requestConnectionPoolConfig_connectionPoolConfig_ConnectionBorrowTimeout != null)
            {
                request.ConnectionPoolConfig.ConnectionBorrowTimeout = requestConnectionPoolConfig_connectionPoolConfig_ConnectionBorrowTimeout.Value;
                requestConnectionPoolConfigIsNull = false;
            }
            System.String requestConnectionPoolConfig_connectionPoolConfig_InitQuery = null;
            if (cmdletContext.ConnectionPoolConfig_InitQuery != null)
            {
                requestConnectionPoolConfig_connectionPoolConfig_InitQuery = cmdletContext.ConnectionPoolConfig_InitQuery;
            }
            if (requestConnectionPoolConfig_connectionPoolConfig_InitQuery != null)
            {
                request.ConnectionPoolConfig.InitQuery = requestConnectionPoolConfig_connectionPoolConfig_InitQuery;
                requestConnectionPoolConfigIsNull = false;
            }
            System.Int32? requestConnectionPoolConfig_connectionPoolConfig_MaxConnectionsPercent = null;
            if (cmdletContext.ConnectionPoolConfig_MaxConnectionsPercent != null)
            {
                requestConnectionPoolConfig_connectionPoolConfig_MaxConnectionsPercent = cmdletContext.ConnectionPoolConfig_MaxConnectionsPercent.Value;
            }
            if (requestConnectionPoolConfig_connectionPoolConfig_MaxConnectionsPercent != null)
            {
                request.ConnectionPoolConfig.MaxConnectionsPercent = requestConnectionPoolConfig_connectionPoolConfig_MaxConnectionsPercent.Value;
                requestConnectionPoolConfigIsNull = false;
            }
            System.Int32? requestConnectionPoolConfig_connectionPoolConfig_MaxIdleConnectionsPercent = null;
            if (cmdletContext.ConnectionPoolConfig_MaxIdleConnectionsPercent != null)
            {
                requestConnectionPoolConfig_connectionPoolConfig_MaxIdleConnectionsPercent = cmdletContext.ConnectionPoolConfig_MaxIdleConnectionsPercent.Value;
            }
            if (requestConnectionPoolConfig_connectionPoolConfig_MaxIdleConnectionsPercent != null)
            {
                request.ConnectionPoolConfig.MaxIdleConnectionsPercent = requestConnectionPoolConfig_connectionPoolConfig_MaxIdleConnectionsPercent.Value;
                requestConnectionPoolConfigIsNull = false;
            }
            List<System.String> requestConnectionPoolConfig_connectionPoolConfig_SessionPinningFilter = null;
            if (cmdletContext.ConnectionPoolConfig_SessionPinningFilter != null)
            {
                requestConnectionPoolConfig_connectionPoolConfig_SessionPinningFilter = cmdletContext.ConnectionPoolConfig_SessionPinningFilter;
            }
            if (requestConnectionPoolConfig_connectionPoolConfig_SessionPinningFilter != null)
            {
                request.ConnectionPoolConfig.SessionPinningFilters = requestConnectionPoolConfig_connectionPoolConfig_SessionPinningFilter;
                requestConnectionPoolConfigIsNull = false;
            }
             // determine if request.ConnectionPoolConfig should be set to null
            if (requestConnectionPoolConfigIsNull)
            {
                request.ConnectionPoolConfig = null;
            }
            if (cmdletContext.DBProxyName != null)
            {
                request.DBProxyName = cmdletContext.DBProxyName;
            }
            if (cmdletContext.NewName != null)
            {
                request.NewName = cmdletContext.NewName;
            }
            if (cmdletContext.TargetGroupName != null)
            {
                request.TargetGroupName = cmdletContext.TargetGroupName;
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
        
        private Amazon.RDS.Model.ModifyDBProxyTargetGroupResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBProxyTargetGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBProxyTargetGroup");
            try
            {
                return client.ModifyDBProxyTargetGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ConnectionPoolConfig_ConnectionBorrowTimeout { get; set; }
            public System.String ConnectionPoolConfig_InitQuery { get; set; }
            public System.Int32? ConnectionPoolConfig_MaxConnectionsPercent { get; set; }
            public System.Int32? ConnectionPoolConfig_MaxIdleConnectionsPercent { get; set; }
            public List<System.String> ConnectionPoolConfig_SessionPinningFilter { get; set; }
            public System.String DBProxyName { get; set; }
            public System.String NewName { get; set; }
            public System.String TargetGroupName { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyDBProxyTargetGroupResponse, EditRDSDBProxyTargetGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBProxyTargetGroup;
        }
        
    }
}

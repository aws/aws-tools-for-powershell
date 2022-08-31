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
using Amazon.RDSDataService;
using Amazon.RDSDataService.Model;

namespace Amazon.PowerShell.Cmdlets.RDSD
{
    /// <summary>
    /// Runs a SQL statement against a database.
    /// 
    ///  <note><para>
    /// If a call isn't part of a transaction because it doesn't include the <code>transactionID</code>
    /// parameter, changes that result from the call are committed automatically.
    /// </para><para>
    /// If the binary response data from the database is more than 1 MB, the call is terminated.
    /// </para></note>
    /// </summary>
    [Cmdlet("Invoke", "RDSDStatement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDSDataService.Model.ExecuteStatementResponse")]
    [AWSCmdlet("Calls the AWS RDS DataService ExecuteStatement API operation.", Operation = new[] {"ExecuteStatement"}, SelectReturnType = typeof(Amazon.RDSDataService.Model.ExecuteStatementResponse))]
    [AWSCmdletOutput("Amazon.RDSDataService.Model.ExecuteStatementResponse",
        "This cmdlet returns an Amazon.RDSDataService.Model.ExecuteStatementResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeRDSDStatementCmdlet : AmazonRDSDataServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ContinueAfterTimeout
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to continue running the statement after the call times
        /// out. By default, the statement stops running when the call times out.</para><note><para>For DDL statements, we recommend continuing to run the statement after the call times
        /// out. When a DDL statement terminates before it is finished running, it can result
        /// in errors and possibly corrupted data structures.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ContinueAfterTimeout { get; set; }
        #endregion
        
        #region Parameter Database
        /// <summary>
        /// <para>
        /// <para>The name of the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Database { get; set; }
        #endregion
        
        #region Parameter ResultSetOptions_DecimalReturnType
        /// <summary>
        /// <para>
        /// <para>A value that indicates how a field of <code>DECIMAL</code> type is represented in
        /// the response. The value of <code>STRING</code>, the default, specifies that it is
        /// converted to a String value. The value of <code>DOUBLE_OR_LONG</code> specifies that
        /// it is converted to a Long value if its scale is 0, or to a Double value otherwise.</para><note><para>Conversion to Double or Long can result in roundoff errors due to precision loss.
        /// We recommend converting to String, especially when working with currency values.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDSDataService.DecimalReturnType")]
        public Amazon.RDSDataService.DecimalReturnType ResultSetOptions_DecimalReturnType { get; set; }
        #endregion
        
        #region Parameter FormatRecordsAs
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to format the result set as a single JSON string. This
        /// parameter only applies to <code>SELECT</code> statements and is ignored for other
        /// types of statements. Allowed values are <code>NONE</code> and <code>JSON</code>. The
        /// default value is <code>NONE</code>. The result is returned in the <code>formattedRecords</code>
        /// field.</para><para>For usage information about the JSON format for result sets, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/data-api.html">Using
        /// the Data API</a> in the <i>Amazon Aurora User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDSDataService.RecordsFormatType")]
        public Amazon.RDSDataService.RecordsFormatType FormatRecordsAs { get; set; }
        #endregion
        
        #region Parameter IncludeResultMetadata
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to include metadata in the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeResultMetadata { get; set; }
        #endregion
        
        #region Parameter ResultSetOptions_LongReturnType
        /// <summary>
        /// <para>
        /// <para>A value that indicates how a field of <code>LONG</code> type is represented. Allowed
        /// values are <code>LONG</code> and <code>STRING</code>. The default is <code>LONG</code>.
        /// Specify <code>STRING</code> if the length or precision of numeric values might cause
        /// truncation or rounding errors. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDSDataService.LongReturnType")]
        public Amazon.RDSDataService.LongReturnType ResultSetOptions_LongReturnType { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The parameters for the SQL statement.</para><note><para>Array parameters are not supported.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.RDSDataService.Model.SqlParameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Aurora Serverless DB cluster.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Schema
        /// <summary>
        /// <para>
        /// <para>The name of the database schema.</para><note><para>Currently, the <code>schema</code> parameter isn't supported.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schema { get; set; }
        #endregion
        
        #region Parameter SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the secret that enables access to the DB cluster. Enter the database user
        /// name and password for the credentials in the secret.</para><para>For information about creating the secret, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/create_database_secret.html">Create
        /// a database secret</a>.</para>
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
        public System.String SecretArn { get; set; }
        #endregion
        
        #region Parameter Sql
        /// <summary>
        /// <para>
        /// <para>The SQL statement to run.</para>
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
        public System.String Sql { get; set; }
        #endregion
        
        #region Parameter TransactionId
        /// <summary>
        /// <para>
        /// <para>The identifier of a transaction that was started by using the <code>BeginTransaction</code>
        /// operation. Specify the transaction ID of the transaction that you want to include
        /// the SQL statement in.</para><para>If the SQL statement is not part of a transaction, don't set this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransactionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDSDataService.Model.ExecuteStatementResponse).
        /// Specifying the name of a property of type Amazon.RDSDataService.Model.ExecuteStatementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Sql parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Sql' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Sql' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-RDSDStatement (ExecuteStatement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDSDataService.Model.ExecuteStatementResponse, InvokeRDSDStatementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Sql;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContinueAfterTimeout = this.ContinueAfterTimeout;
            context.Database = this.Database;
            context.FormatRecordsAs = this.FormatRecordsAs;
            context.IncludeResultMetadata = this.IncludeResultMetadata;
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.RDSDataService.Model.SqlParameter>(this.Parameter);
            }
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResultSetOptions_DecimalReturnType = this.ResultSetOptions_DecimalReturnType;
            context.ResultSetOptions_LongReturnType = this.ResultSetOptions_LongReturnType;
            context.Schema = this.Schema;
            context.SecretArn = this.SecretArn;
            #if MODULAR
            if (this.SecretArn == null && ParameterWasBound(nameof(this.SecretArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SecretArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Sql = this.Sql;
            #if MODULAR
            if (this.Sql == null && ParameterWasBound(nameof(this.Sql)))
            {
                WriteWarning("You are passing $null as a value for parameter Sql which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransactionId = this.TransactionId;
            
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
            var request = new Amazon.RDSDataService.Model.ExecuteStatementRequest();
            
            if (cmdletContext.ContinueAfterTimeout != null)
            {
                request.ContinueAfterTimeout = cmdletContext.ContinueAfterTimeout.Value;
            }
            if (cmdletContext.Database != null)
            {
                request.Database = cmdletContext.Database;
            }
            if (cmdletContext.FormatRecordsAs != null)
            {
                request.FormatRecordsAs = cmdletContext.FormatRecordsAs;
            }
            if (cmdletContext.IncludeResultMetadata != null)
            {
                request.IncludeResultMetadata = cmdletContext.IncludeResultMetadata.Value;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            
             // populate ResultSetOptions
            var requestResultSetOptionsIsNull = true;
            request.ResultSetOptions = new Amazon.RDSDataService.Model.ResultSetOptions();
            Amazon.RDSDataService.DecimalReturnType requestResultSetOptions_resultSetOptions_DecimalReturnType = null;
            if (cmdletContext.ResultSetOptions_DecimalReturnType != null)
            {
                requestResultSetOptions_resultSetOptions_DecimalReturnType = cmdletContext.ResultSetOptions_DecimalReturnType;
            }
            if (requestResultSetOptions_resultSetOptions_DecimalReturnType != null)
            {
                request.ResultSetOptions.DecimalReturnType = requestResultSetOptions_resultSetOptions_DecimalReturnType;
                requestResultSetOptionsIsNull = false;
            }
            Amazon.RDSDataService.LongReturnType requestResultSetOptions_resultSetOptions_LongReturnType = null;
            if (cmdletContext.ResultSetOptions_LongReturnType != null)
            {
                requestResultSetOptions_resultSetOptions_LongReturnType = cmdletContext.ResultSetOptions_LongReturnType;
            }
            if (requestResultSetOptions_resultSetOptions_LongReturnType != null)
            {
                request.ResultSetOptions.LongReturnType = requestResultSetOptions_resultSetOptions_LongReturnType;
                requestResultSetOptionsIsNull = false;
            }
             // determine if request.ResultSetOptions should be set to null
            if (requestResultSetOptionsIsNull)
            {
                request.ResultSetOptions = null;
            }
            if (cmdletContext.Schema != null)
            {
                request.Schema = cmdletContext.Schema;
            }
            if (cmdletContext.SecretArn != null)
            {
                request.SecretArn = cmdletContext.SecretArn;
            }
            if (cmdletContext.Sql != null)
            {
                request.Sql = cmdletContext.Sql;
            }
            if (cmdletContext.TransactionId != null)
            {
                request.TransactionId = cmdletContext.TransactionId;
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
        
        private Amazon.RDSDataService.Model.ExecuteStatementResponse CallAWSServiceOperation(IAmazonRDSDataService client, Amazon.RDSDataService.Model.ExecuteStatementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS RDS DataService", "ExecuteStatement");
            try
            {
                #if DESKTOP
                return client.ExecuteStatement(request);
                #elif CORECLR
                return client.ExecuteStatementAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ContinueAfterTimeout { get; set; }
            public System.String Database { get; set; }
            public Amazon.RDSDataService.RecordsFormatType FormatRecordsAs { get; set; }
            public System.Boolean? IncludeResultMetadata { get; set; }
            public List<Amazon.RDSDataService.Model.SqlParameter> Parameter { get; set; }
            public System.String ResourceArn { get; set; }
            public Amazon.RDSDataService.DecimalReturnType ResultSetOptions_DecimalReturnType { get; set; }
            public Amazon.RDSDataService.LongReturnType ResultSetOptions_LongReturnType { get; set; }
            public System.String Schema { get; set; }
            public System.String SecretArn { get; set; }
            public System.String Sql { get; set; }
            public System.String TransactionId { get; set; }
            public System.Func<Amazon.RDSDataService.Model.ExecuteStatementResponse, InvokeRDSDStatementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

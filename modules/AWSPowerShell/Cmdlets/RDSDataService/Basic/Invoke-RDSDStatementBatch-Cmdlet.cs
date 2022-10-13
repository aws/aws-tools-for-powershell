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
    /// Runs a batch SQL statement over an array of data.
    /// 
    ///  
    /// <para>
    /// You can run bulk update and insert operations for multiple records using a DML statement
    /// with different parameter sets. Bulk operations can provide a significant performance
    /// improvement over individual insert and update operations.
    /// </para><note><para>
    /// If a call isn't part of a transaction because it doesn't include the <code>transactionID</code>
    /// parameter, changes that result from the call are committed automatically.
    /// </para><para>
    /// There isn't a fixed upper limit on the number of parameter sets. However, the maximum
    /// size of the HTTP request submitted through the Data API is 4 MiB. If the request exceeds
    /// this limit, the Data API returns an error and doesn't process the request. This 4-MiB
    /// limit includes the size of the HTTP headers and the JSON notation in the request.
    /// Thus, the number of parameter sets that you can include depends on a combination of
    /// factors, such as the size of the SQL statement and the size of each parameter set.
    /// </para><para>
    /// The response size limit is 1 MiB. If the call returns more than 1 MiB of response
    /// data, the call is terminated.
    /// </para></note>
    /// </summary>
    [Cmdlet("Invoke", "RDSDStatementBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDSDataService.Model.UpdateResult")]
    [AWSCmdlet("Calls the AWS RDS DataService BatchExecuteStatement API operation.", Operation = new[] {"BatchExecuteStatement"}, SelectReturnType = typeof(Amazon.RDSDataService.Model.BatchExecuteStatementResponse))]
    [AWSCmdletOutput("Amazon.RDSDataService.Model.UpdateResult or Amazon.RDSDataService.Model.BatchExecuteStatementResponse",
        "This cmdlet returns a collection of Amazon.RDSDataService.Model.UpdateResult objects.",
        "The service call response (type Amazon.RDSDataService.Model.BatchExecuteStatementResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeRDSDStatementBatchCmdlet : AmazonRDSDataServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Database
        /// <summary>
        /// <para>
        /// <para>The name of the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Database { get; set; }
        #endregion
        
        #region Parameter ParameterSet
        /// <summary>
        /// <para>
        /// <para>The parameter set for the batch operation.</para><para>The SQL statement is executed as many times as the number of parameter sets provided.
        /// To execute a SQL statement with no parameters, use one of the following options:</para><ul><li><para>Specify one or more empty parameter sets.</para></li><li><para>Use the <code>ExecuteStatement</code> operation instead of the <code>BatchExecuteStatement</code>
        /// operation.</para></li></ul><note><para>Array parameters are not supported.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParameterSets")]
        public Amazon.RDSDataService.Model.SqlParameter[][] ParameterSet { get; set; }
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
        /// <para>The SQL statement to run. Don't include a semicolon (;) at the end of the SQL statement.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UpdateResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDSDataService.Model.BatchExecuteStatementResponse).
        /// Specifying the name of a property of type Amazon.RDSDataService.Model.BatchExecuteStatementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UpdateResults";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-RDSDStatementBatch (BatchExecuteStatement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDSDataService.Model.BatchExecuteStatementResponse, InvokeRDSDStatementBatchCmdlet>(Select) ??
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
            context.Database = this.Database;
            if (this.ParameterSet != null)
            {
                context.ParameterSet = new List<List<Amazon.RDSDataService.Model.SqlParameter>>();
                foreach (var innerList in this.ParameterSet)
                {
                    context.ParameterSet.Add(new List<Amazon.RDSDataService.Model.SqlParameter>(innerList));
                }
            }
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.RDSDataService.Model.BatchExecuteStatementRequest();
            
            if (cmdletContext.Database != null)
            {
                request.Database = cmdletContext.Database;
            }
            if (cmdletContext.ParameterSet != null)
            {
                request.ParameterSets = cmdletContext.ParameterSet;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.RDSDataService.Model.BatchExecuteStatementResponse CallAWSServiceOperation(IAmazonRDSDataService client, Amazon.RDSDataService.Model.BatchExecuteStatementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS RDS DataService", "BatchExecuteStatement");
            try
            {
                #if DESKTOP
                return client.BatchExecuteStatement(request);
                #elif CORECLR
                return client.BatchExecuteStatementAsync(request).GetAwaiter().GetResult();
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
            public System.String Database { get; set; }
            public List<List<Amazon.RDSDataService.Model.SqlParameter>> ParameterSet { get; set; }
            public System.String ResourceArn { get; set; }
            public System.String Schema { get; set; }
            public System.String SecretArn { get; set; }
            public System.String Sql { get; set; }
            public System.String TransactionId { get; set; }
            public System.Func<Amazon.RDSDataService.Model.BatchExecuteStatementResponse, InvokeRDSDStatementBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UpdateResults;
        }
        
    }
}

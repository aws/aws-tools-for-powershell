/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Executes any SQL statement on the target database synchronously
    /// </summary>
    [Cmdlet("Invoke", "RDSDSqlStatement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDSDataService.Model.SqlStatementResult")]
    [AWSCmdlet("Calls the AWS RDS DataService ExecuteSql API operation.", Operation = new[] {"ExecuteSql"})]
    [AWSCmdletOutput("Amazon.RDSDataService.Model.SqlStatementResult",
        "This cmdlet returns a collection of SqlStatementResult objects.",
        "The service call response (type Amazon.RDSDataService.Model.ExecuteSqlResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeRDSDSqlStatementCmdlet : AmazonRDSDataServiceClientCmdlet, IExecutor
    {
        
        #region Parameter AwsSecretStoreArn
        /// <summary>
        /// <para>
        /// ARN of the db credentials in AWS Secret
        /// Store or the friendly secret name
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AwsSecretStoreArn { get; set; }
        #endregion
        
        #region Parameter Database
        /// <summary>
        /// <para>
        /// Target DB name
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Database { get; set; }
        #endregion
        
        #region Parameter DbClusterOrInstanceArn
        /// <summary>
        /// <para>
        /// ARN of the target db cluster or
        /// instance
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DbClusterOrInstanceArn { get; set; }
        #endregion
        
        #region Parameter Schema
        /// <summary>
        /// <para>
        /// Target Schema name
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Schema { get; set; }
        #endregion
        
        #region Parameter SqlStatement
        /// <summary>
        /// <para>
        /// SQL statement(s) to be executed. Statements
        /// can be chained by using semicolons
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("SqlStatements")]
        public System.String SqlStatement { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-RDSDSqlStatement (ExecuteSql)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AwsSecretStoreArn = this.AwsSecretStoreArn;
            context.Database = this.Database;
            context.DbClusterOrInstanceArn = this.DbClusterOrInstanceArn;
            context.Schema = this.Schema;
            context.SqlStatements = this.SqlStatement;
            
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
            var request = new Amazon.RDSDataService.Model.ExecuteSqlRequest();
            
            if (cmdletContext.AwsSecretStoreArn != null)
            {
                request.AwsSecretStoreArn = cmdletContext.AwsSecretStoreArn;
            }
            if (cmdletContext.Database != null)
            {
                request.Database = cmdletContext.Database;
            }
            if (cmdletContext.DbClusterOrInstanceArn != null)
            {
                request.DbClusterOrInstanceArn = cmdletContext.DbClusterOrInstanceArn;
            }
            if (cmdletContext.Schema != null)
            {
                request.Schema = cmdletContext.Schema;
            }
            if (cmdletContext.SqlStatements != null)
            {
                request.SqlStatements = cmdletContext.SqlStatements;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SqlStatementResults;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.RDSDataService.Model.ExecuteSqlResponse CallAWSServiceOperation(IAmazonRDSDataService client, Amazon.RDSDataService.Model.ExecuteSqlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS RDS DataService", "ExecuteSql");
            try
            {
                #if DESKTOP
                return client.ExecuteSql(request);
                #elif CORECLR
                return client.ExecuteSqlAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsSecretStoreArn { get; set; }
            public System.String Database { get; set; }
            public System.String DbClusterOrInstanceArn { get; set; }
            public System.String Schema { get; set; }
            public System.String SqlStatements { get; set; }
        }
        
    }
}

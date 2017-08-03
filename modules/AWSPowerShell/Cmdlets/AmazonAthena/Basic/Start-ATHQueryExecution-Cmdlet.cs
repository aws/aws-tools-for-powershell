/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Athena;
using Amazon.Athena.Model;

namespace Amazon.PowerShell.Cmdlets.ATH
{
    /// <summary>
    /// Runs (executes) the SQL query statements contained in the <code>Query</code> string.
    /// 
    ///  
    /// <para>
    /// For code samples using the AWS SDK for Java, see <a href="http://docs.aws.amazon.com/athena/latest/ug/code-samples.html">Examples
    /// and Code Samples</a> in the <i>Amazon Athena User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "ATHQueryExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the StartQueryExecution operation against Amazon Athena.", Operation = new[] {"StartQueryExecution"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Athena.Model.StartQueryExecutionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartATHQueryExecutionCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive string used to ensure the request to create the query is idempotent
        /// (executes only once). If another <code>StartQueryExecution</code> request is received,
        /// the same response is returned and another query is not created. If a parameter has
        /// changed, for example, the <code>QueryString</code>, an error is returned.</para><important><para>This token is listed as not required because AWS SDKs (for example the AWS SDK for
        /// Java) auto-generate the token for users. If you are not using the AWS SDK or the AWS
        /// CLI, you must provide this token or the action will fail.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter QueryExecutionContext_Database
        /// <summary>
        /// <para>
        /// <para>The name of the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String QueryExecutionContext_Database { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_EncryptionOption
        /// <summary>
        /// <para>
        /// <para>Indicates whether Amazon S3 server-side encryption with Amazon S3-managed keys (<code>SSE-S3</code>),
        /// server-side encryption with KMS-managed keys (<code>SSE-KMS</code>), or client-side
        /// encryption with KMS-managed keys (CSE-KMS) is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResultConfiguration_EncryptionConfiguration_EncryptionOption")]
        [AWSConstantClassSource("Amazon.Athena.EncryptionOption")]
        public Amazon.Athena.EncryptionOption EncryptionConfiguration_EncryptionOption { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKey
        /// <summary>
        /// <para>
        /// <para>For <code>SSE-KMS</code> and <code>CSE-KMS</code>, this is the KMS key ARN or ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResultConfiguration_EncryptionConfiguration_KmsKey")]
        public System.String EncryptionConfiguration_KmsKey { get; set; }
        #endregion
        
        #region Parameter ResultConfiguration_OutputLocation
        /// <summary>
        /// <para>
        /// <para>The location in S3 where query results are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResultConfiguration_OutputLocation { get; set; }
        #endregion
        
        #region Parameter QueryString
        /// <summary>
        /// <para>
        /// <para>The SQL query statements to be executed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String QueryString { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("QueryString", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ATHQueryExecution (StartQueryExecution)"))
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
            
            context.ClientRequestToken = this.ClientRequestToken;
            context.QueryExecutionContext_Database = this.QueryExecutionContext_Database;
            context.QueryString = this.QueryString;
            context.ResultConfiguration_EncryptionConfiguration_EncryptionOption = this.EncryptionConfiguration_EncryptionOption;
            context.ResultConfiguration_EncryptionConfiguration_KmsKey = this.EncryptionConfiguration_KmsKey;
            context.ResultConfiguration_OutputLocation = this.ResultConfiguration_OutputLocation;
            
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
            var request = new Amazon.Athena.Model.StartQueryExecutionRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate QueryExecutionContext
            bool requestQueryExecutionContextIsNull = true;
            request.QueryExecutionContext = new Amazon.Athena.Model.QueryExecutionContext();
            System.String requestQueryExecutionContext_queryExecutionContext_Database = null;
            if (cmdletContext.QueryExecutionContext_Database != null)
            {
                requestQueryExecutionContext_queryExecutionContext_Database = cmdletContext.QueryExecutionContext_Database;
            }
            if (requestQueryExecutionContext_queryExecutionContext_Database != null)
            {
                request.QueryExecutionContext.Database = requestQueryExecutionContext_queryExecutionContext_Database;
                requestQueryExecutionContextIsNull = false;
            }
             // determine if request.QueryExecutionContext should be set to null
            if (requestQueryExecutionContextIsNull)
            {
                request.QueryExecutionContext = null;
            }
            if (cmdletContext.QueryString != null)
            {
                request.QueryString = cmdletContext.QueryString;
            }
            
             // populate ResultConfiguration
            bool requestResultConfigurationIsNull = true;
            request.ResultConfiguration = new Amazon.Athena.Model.ResultConfiguration();
            System.String requestResultConfiguration_resultConfiguration_OutputLocation = null;
            if (cmdletContext.ResultConfiguration_OutputLocation != null)
            {
                requestResultConfiguration_resultConfiguration_OutputLocation = cmdletContext.ResultConfiguration_OutputLocation;
            }
            if (requestResultConfiguration_resultConfiguration_OutputLocation != null)
            {
                request.ResultConfiguration.OutputLocation = requestResultConfiguration_resultConfiguration_OutputLocation;
                requestResultConfigurationIsNull = false;
            }
            Amazon.Athena.Model.EncryptionConfiguration requestResultConfiguration_resultConfiguration_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            bool requestResultConfiguration_resultConfiguration_EncryptionConfigurationIsNull = true;
            requestResultConfiguration_resultConfiguration_EncryptionConfiguration = new Amazon.Athena.Model.EncryptionConfiguration();
            Amazon.Athena.EncryptionOption requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption = null;
            if (cmdletContext.ResultConfiguration_EncryptionConfiguration_EncryptionOption != null)
            {
                requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption = cmdletContext.ResultConfiguration_EncryptionConfiguration_EncryptionOption;
            }
            if (requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption != null)
            {
                requestResultConfiguration_resultConfiguration_EncryptionConfiguration.EncryptionOption = requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption;
                requestResultConfiguration_resultConfiguration_EncryptionConfigurationIsNull = false;
            }
            System.String requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey = null;
            if (cmdletContext.ResultConfiguration_EncryptionConfiguration_KmsKey != null)
            {
                requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey = cmdletContext.ResultConfiguration_EncryptionConfiguration_KmsKey;
            }
            if (requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey != null)
            {
                requestResultConfiguration_resultConfiguration_EncryptionConfiguration.KmsKey = requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey;
                requestResultConfiguration_resultConfiguration_EncryptionConfigurationIsNull = false;
            }
             // determine if requestResultConfiguration_resultConfiguration_EncryptionConfiguration should be set to null
            if (requestResultConfiguration_resultConfiguration_EncryptionConfigurationIsNull)
            {
                requestResultConfiguration_resultConfiguration_EncryptionConfiguration = null;
            }
            if (requestResultConfiguration_resultConfiguration_EncryptionConfiguration != null)
            {
                request.ResultConfiguration.EncryptionConfiguration = requestResultConfiguration_resultConfiguration_EncryptionConfiguration;
                requestResultConfigurationIsNull = false;
            }
             // determine if request.ResultConfiguration should be set to null
            if (requestResultConfigurationIsNull)
            {
                request.ResultConfiguration = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.QueryExecutionId;
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
        
        private Amazon.Athena.Model.StartQueryExecutionResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.StartQueryExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "StartQueryExecution");
            #if DESKTOP
            return client.StartQueryExecution(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.StartQueryExecutionAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ClientRequestToken { get; set; }
            public System.String QueryExecutionContext_Database { get; set; }
            public System.String QueryString { get; set; }
            public Amazon.Athena.EncryptionOption ResultConfiguration_EncryptionConfiguration_EncryptionOption { get; set; }
            public System.String ResultConfiguration_EncryptionConfiguration_KmsKey { get; set; }
            public System.String ResultConfiguration_OutputLocation { get; set; }
        }
        
    }
}

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
using Amazon.Athena;
using Amazon.Athena.Model;

namespace Amazon.PowerShell.Cmdlets.ATH
{
    /// <summary>
    /// Runs the SQL query statements contained in the <c>Query</c>. Requires you to have
    /// access to the workgroup in which the query ran. Running queries against an external
    /// catalog requires <a>GetDataCatalog</a> permission to the catalog. For code samples
    /// using the Amazon Web Services SDK for Java, see <a href="http://docs.aws.amazon.com/athena/latest/ug/code-samples.html">Examples
    /// and Code Samples</a> in the <i>Amazon Athena User Guide</i>.
    /// </summary>
    [Cmdlet("Start", "ATHQueryExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Athena StartQueryExecution API operation.", Operation = new[] {"StartQueryExecution"}, SelectReturnType = typeof(Amazon.Athena.Model.StartQueryExecutionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Athena.Model.StartQueryExecutionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Athena.Model.StartQueryExecutionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartATHQueryExecutionCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter QueryExecutionContext_Catalog
        /// <summary>
        /// <para>
        /// <para>The name of the data catalog used in the query execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryExecutionContext_Catalog { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive string used to ensure the request to create the query is idempotent
        /// (executes only once). If another <c>StartQueryExecution</c> request is received, the
        /// same response is returned and another query is not created. An error is returned if
        /// a parameter, such as <c>QueryString</c>, has changed. A call to <c>StartQueryExecution</c>
        /// that uses a previous client request token returns the same <c>QueryExecutionId</c>
        /// even if the requester doesn't have permission on the tables specified in <c>QueryString</c>.</para><important><para>This token is listed as not required because Amazon Web Services SDKs (for example
        /// the Amazon Web Services SDK for Java) auto-generate the token for users. If you are
        /// not using the Amazon Web Services SDK or the Amazon Web Services CLI, you must provide
        /// this token or the action will fail.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter QueryExecutionContext_Database
        /// <summary>
        /// <para>
        /// <para>The name of the database used in the query execution. The database must exist in the
        /// catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryExecutionContext_Database { get; set; }
        #endregion
        
        #region Parameter ResultReuseByAgeConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>True if previous query results can be reused when the query is run; otherwise, false.
        /// The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultReuseConfiguration_ResultReuseByAgeConfiguration_Enabled")]
        public System.Boolean? ResultReuseByAgeConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_EncryptionOption
        /// <summary>
        /// <para>
        /// <para>Indicates whether Amazon S3 server-side encryption with Amazon S3-managed keys (<c>SSE_S3</c>),
        /// server-side encryption with KMS-managed keys (<c>SSE_KMS</c>), or client-side encryption
        /// with KMS-managed keys (<c>CSE_KMS</c>) is used.</para><para>If a query runs in a workgroup and the workgroup overrides client-side settings, then
        /// the workgroup's setting for encryption is used. It specifies whether query results
        /// must be encrypted, for all queries that run in this workgroup. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultConfiguration_EncryptionConfiguration_EncryptionOption")]
        [AWSConstantClassSource("Amazon.Athena.EncryptionOption")]
        public Amazon.Athena.EncryptionOption EncryptionConfiguration_EncryptionOption { get; set; }
        #endregion
        
        #region Parameter ExecutionParameter
        /// <summary>
        /// <para>
        /// <para>A list of values for the parameters in a query. The values are applied sequentially
        /// to the parameters in the query in the order in which the parameters occur.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionParameters")]
        public System.String[] ExecutionParameter { get; set; }
        #endregion
        
        #region Parameter ResultConfiguration_ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID that you expect to be the owner of the Amazon S3
        /// bucket specified by <a>ResultConfiguration$OutputLocation</a>. If set, Athena uses
        /// the value for <c>ExpectedBucketOwner</c> when it makes Amazon S3 calls to your specified
        /// output location. If the <c>ExpectedBucketOwner</c> Amazon Web Services account ID
        /// does not match the actual owner of the Amazon S3 bucket, the call fails with a permissions
        /// error.</para><para>This is a client-side setting. If workgroup settings override client-side settings,
        /// then the query uses the <c>ExpectedBucketOwner</c> setting that is specified for the
        /// workgroup, and also uses the location for storing query results specified in the workgroup.
        /// See <a>WorkGroupConfiguration$EnforceWorkGroupConfiguration</a> and <a href="https://docs.aws.amazon.com/athena/latest/ug/workgroups-settings-override.html">Workgroup
        /// Settings Override Client-Side Settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResultConfiguration_ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKey
        /// <summary>
        /// <para>
        /// <para>For <c>SSE_KMS</c> and <c>CSE_KMS</c>, this is the KMS key ARN or ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultConfiguration_EncryptionConfiguration_KmsKey")]
        public System.String EncryptionConfiguration_KmsKey { get; set; }
        #endregion
        
        #region Parameter ResultReuseByAgeConfiguration_MaxAgeInMinute
        /// <summary>
        /// <para>
        /// <para>Specifies, in minutes, the maximum age of a previous query result that Athena should
        /// consider for reuse. The default is 60.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultReuseConfiguration_ResultReuseByAgeConfiguration_MaxAgeInMinutes")]
        public System.Int32? ResultReuseByAgeConfiguration_MaxAgeInMinute { get; set; }
        #endregion
        
        #region Parameter ResultConfiguration_OutputLocation
        /// <summary>
        /// <para>
        /// <para>The location in Amazon S3 where your query and calculation results are stored, such
        /// as <c>s3://path/to/query/bucket/</c>. To run the query, you must specify the query
        /// results location using one of the ways: either for individual queries using either
        /// this setting (client-side), or in the workgroup, using <a>WorkGroupConfiguration</a>.
        /// If none of them is set, Athena issues an error that no output location is provided.
        /// If workgroup settings override client-side settings, then the query uses the settings
        /// specified for the workgroup. See <a>WorkGroupConfiguration$EnforceWorkGroupConfiguration</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResultConfiguration_OutputLocation { get; set; }
        #endregion
        
        #region Parameter QueryString
        /// <summary>
        /// <para>
        /// <para>The SQL query statements to be executed.</para>
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
        public System.String QueryString { get; set; }
        #endregion
        
        #region Parameter AclConfiguration_S3AclOption
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 canned ACL that Athena should specify when storing query results. Currently
        /// the only supported canned ACL is <c>BUCKET_OWNER_FULL_CONTROL</c>. If a query runs
        /// in a workgroup and the workgroup overrides client-side settings, then the Amazon S3
        /// canned ACL specified in the workgroup's settings is used for all queries that run
        /// in the workgroup. For more information about Amazon S3 canned ACLs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/acl-overview.html#canned-acl">Canned
        /// ACL</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResultConfiguration_AclConfiguration_S3AclOption")]
        [AWSConstantClassSource("Amazon.Athena.S3AclOption")]
        public Amazon.Athena.S3AclOption AclConfiguration_S3AclOption { get; set; }
        #endregion
        
        #region Parameter WorkGroup
        /// <summary>
        /// <para>
        /// <para>The name of the workgroup in which the query is being started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueryExecutionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Athena.Model.StartQueryExecutionResponse).
        /// Specifying the name of a property of type Amazon.Athena.Model.StartQueryExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueryExecutionId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the QueryString parameter.
        /// The -PassThru parameter is deprecated, use -Select '^QueryString' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^QueryString' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QueryString), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ATHQueryExecution (StartQueryExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Athena.Model.StartQueryExecutionResponse, StartATHQueryExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.QueryString;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.ExecutionParameter != null)
            {
                context.ExecutionParameter = new List<System.String>(this.ExecutionParameter);
            }
            context.QueryExecutionContext_Catalog = this.QueryExecutionContext_Catalog;
            context.QueryExecutionContext_Database = this.QueryExecutionContext_Database;
            context.QueryString = this.QueryString;
            #if MODULAR
            if (this.QueryString == null && ParameterWasBound(nameof(this.QueryString)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AclConfiguration_S3AclOption = this.AclConfiguration_S3AclOption;
            context.EncryptionConfiguration_EncryptionOption = this.EncryptionConfiguration_EncryptionOption;
            context.EncryptionConfiguration_KmsKey = this.EncryptionConfiguration_KmsKey;
            context.ResultConfiguration_ExpectedBucketOwner = this.ResultConfiguration_ExpectedBucketOwner;
            context.ResultConfiguration_OutputLocation = this.ResultConfiguration_OutputLocation;
            context.ResultReuseByAgeConfiguration_Enabled = this.ResultReuseByAgeConfiguration_Enabled;
            context.ResultReuseByAgeConfiguration_MaxAgeInMinute = this.ResultReuseByAgeConfiguration_MaxAgeInMinute;
            context.WorkGroup = this.WorkGroup;
            
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
            if (cmdletContext.ExecutionParameter != null)
            {
                request.ExecutionParameters = cmdletContext.ExecutionParameter;
            }
            
             // populate QueryExecutionContext
            var requestQueryExecutionContextIsNull = true;
            request.QueryExecutionContext = new Amazon.Athena.Model.QueryExecutionContext();
            System.String requestQueryExecutionContext_queryExecutionContext_Catalog = null;
            if (cmdletContext.QueryExecutionContext_Catalog != null)
            {
                requestQueryExecutionContext_queryExecutionContext_Catalog = cmdletContext.QueryExecutionContext_Catalog;
            }
            if (requestQueryExecutionContext_queryExecutionContext_Catalog != null)
            {
                request.QueryExecutionContext.Catalog = requestQueryExecutionContext_queryExecutionContext_Catalog;
                requestQueryExecutionContextIsNull = false;
            }
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
            var requestResultConfigurationIsNull = true;
            request.ResultConfiguration = new Amazon.Athena.Model.ResultConfiguration();
            System.String requestResultConfiguration_resultConfiguration_ExpectedBucketOwner = null;
            if (cmdletContext.ResultConfiguration_ExpectedBucketOwner != null)
            {
                requestResultConfiguration_resultConfiguration_ExpectedBucketOwner = cmdletContext.ResultConfiguration_ExpectedBucketOwner;
            }
            if (requestResultConfiguration_resultConfiguration_ExpectedBucketOwner != null)
            {
                request.ResultConfiguration.ExpectedBucketOwner = requestResultConfiguration_resultConfiguration_ExpectedBucketOwner;
                requestResultConfigurationIsNull = false;
            }
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
            Amazon.Athena.Model.AclConfiguration requestResultConfiguration_resultConfiguration_AclConfiguration = null;
            
             // populate AclConfiguration
            var requestResultConfiguration_resultConfiguration_AclConfigurationIsNull = true;
            requestResultConfiguration_resultConfiguration_AclConfiguration = new Amazon.Athena.Model.AclConfiguration();
            Amazon.Athena.S3AclOption requestResultConfiguration_resultConfiguration_AclConfiguration_aclConfiguration_S3AclOption = null;
            if (cmdletContext.AclConfiguration_S3AclOption != null)
            {
                requestResultConfiguration_resultConfiguration_AclConfiguration_aclConfiguration_S3AclOption = cmdletContext.AclConfiguration_S3AclOption;
            }
            if (requestResultConfiguration_resultConfiguration_AclConfiguration_aclConfiguration_S3AclOption != null)
            {
                requestResultConfiguration_resultConfiguration_AclConfiguration.S3AclOption = requestResultConfiguration_resultConfiguration_AclConfiguration_aclConfiguration_S3AclOption;
                requestResultConfiguration_resultConfiguration_AclConfigurationIsNull = false;
            }
             // determine if requestResultConfiguration_resultConfiguration_AclConfiguration should be set to null
            if (requestResultConfiguration_resultConfiguration_AclConfigurationIsNull)
            {
                requestResultConfiguration_resultConfiguration_AclConfiguration = null;
            }
            if (requestResultConfiguration_resultConfiguration_AclConfiguration != null)
            {
                request.ResultConfiguration.AclConfiguration = requestResultConfiguration_resultConfiguration_AclConfiguration;
                requestResultConfigurationIsNull = false;
            }
            Amazon.Athena.Model.EncryptionConfiguration requestResultConfiguration_resultConfiguration_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestResultConfiguration_resultConfiguration_EncryptionConfigurationIsNull = true;
            requestResultConfiguration_resultConfiguration_EncryptionConfiguration = new Amazon.Athena.Model.EncryptionConfiguration();
            Amazon.Athena.EncryptionOption requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption = null;
            if (cmdletContext.EncryptionConfiguration_EncryptionOption != null)
            {
                requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption = cmdletContext.EncryptionConfiguration_EncryptionOption;
            }
            if (requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption != null)
            {
                requestResultConfiguration_resultConfiguration_EncryptionConfiguration.EncryptionOption = requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_EncryptionOption;
                requestResultConfiguration_resultConfiguration_EncryptionConfigurationIsNull = false;
            }
            System.String requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey = null;
            if (cmdletContext.EncryptionConfiguration_KmsKey != null)
            {
                requestResultConfiguration_resultConfiguration_EncryptionConfiguration_encryptionConfiguration_KmsKey = cmdletContext.EncryptionConfiguration_KmsKey;
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
            
             // populate ResultReuseConfiguration
            var requestResultReuseConfigurationIsNull = true;
            request.ResultReuseConfiguration = new Amazon.Athena.Model.ResultReuseConfiguration();
            Amazon.Athena.Model.ResultReuseByAgeConfiguration requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration = null;
            
             // populate ResultReuseByAgeConfiguration
            var requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfigurationIsNull = true;
            requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration = new Amazon.Athena.Model.ResultReuseByAgeConfiguration();
            System.Boolean? requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration_resultReuseByAgeConfiguration_Enabled = null;
            if (cmdletContext.ResultReuseByAgeConfiguration_Enabled != null)
            {
                requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration_resultReuseByAgeConfiguration_Enabled = cmdletContext.ResultReuseByAgeConfiguration_Enabled.Value;
            }
            if (requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration_resultReuseByAgeConfiguration_Enabled != null)
            {
                requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration.Enabled = requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration_resultReuseByAgeConfiguration_Enabled.Value;
                requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfigurationIsNull = false;
            }
            System.Int32? requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration_resultReuseByAgeConfiguration_MaxAgeInMinute = null;
            if (cmdletContext.ResultReuseByAgeConfiguration_MaxAgeInMinute != null)
            {
                requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration_resultReuseByAgeConfiguration_MaxAgeInMinute = cmdletContext.ResultReuseByAgeConfiguration_MaxAgeInMinute.Value;
            }
            if (requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration_resultReuseByAgeConfiguration_MaxAgeInMinute != null)
            {
                requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration.MaxAgeInMinutes = requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration_resultReuseByAgeConfiguration_MaxAgeInMinute.Value;
                requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfigurationIsNull = false;
            }
             // determine if requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration should be set to null
            if (requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfigurationIsNull)
            {
                requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration = null;
            }
            if (requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration != null)
            {
                request.ResultReuseConfiguration.ResultReuseByAgeConfiguration = requestResultReuseConfiguration_resultReuseConfiguration_ResultReuseByAgeConfiguration;
                requestResultReuseConfigurationIsNull = false;
            }
             // determine if request.ResultReuseConfiguration should be set to null
            if (requestResultReuseConfigurationIsNull)
            {
                request.ResultReuseConfiguration = null;
            }
            if (cmdletContext.WorkGroup != null)
            {
                request.WorkGroup = cmdletContext.WorkGroup;
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
        
        private Amazon.Athena.Model.StartQueryExecutionResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.StartQueryExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "StartQueryExecution");
            try
            {
                #if DESKTOP
                return client.StartQueryExecution(request);
                #elif CORECLR
                return client.StartQueryExecutionAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public List<System.String> ExecutionParameter { get; set; }
            public System.String QueryExecutionContext_Catalog { get; set; }
            public System.String QueryExecutionContext_Database { get; set; }
            public System.String QueryString { get; set; }
            public Amazon.Athena.S3AclOption AclConfiguration_S3AclOption { get; set; }
            public Amazon.Athena.EncryptionOption EncryptionConfiguration_EncryptionOption { get; set; }
            public System.String EncryptionConfiguration_KmsKey { get; set; }
            public System.String ResultConfiguration_ExpectedBucketOwner { get; set; }
            public System.String ResultConfiguration_OutputLocation { get; set; }
            public System.Boolean? ResultReuseByAgeConfiguration_Enabled { get; set; }
            public System.Int32? ResultReuseByAgeConfiguration_MaxAgeInMinute { get; set; }
            public System.String WorkGroup { get; set; }
            public System.Func<Amazon.Athena.Model.StartQueryExecutionResponse, StartATHQueryExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueryExecutionId;
        }
        
    }
}

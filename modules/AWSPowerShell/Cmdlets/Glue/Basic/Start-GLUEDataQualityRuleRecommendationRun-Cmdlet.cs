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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Starts a recommendation run that is used to generate rules when you don't know what
    /// rules to write. Glue Data Quality analyzes the data and comes up with recommendations
    /// for a potential ruleset. You can then triage the ruleset and modify the generated
    /// ruleset to your liking.
    /// 
    ///  
    /// <para>
    /// Recommendation runs are automatically deleted after 90 days.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "GLUEDataQualityRuleRecommendationRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue StartDataQualityRuleRecommendationRun API operation.", Operation = new[] {"StartDataQualityRuleRecommendationRun"}, SelectReturnType = typeof(Amazon.Glue.Model.StartDataQualityRuleRecommendationRunResponse))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.StartDataQualityRuleRecommendationRunResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Glue.Model.StartDataQualityRuleRecommendationRunResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartGLUEDataQualityRuleRecommendationRunCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GlueTable_AdditionalOption
        /// <summary>
        /// <para>
        /// <para>Additional options for the table. Currently there are two keys supported:</para><ul><li><para><c>pushDownPredicate</c>: to filter on partitions without having to list and read
        /// all the files in your dataset.</para></li><li><para><c>catalogPartitionPredicate</c>: to use server-side partition pruning using partition
        /// indexes in the Glue Data Catalog.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSource_GlueTable_AdditionalOptions")]
        public System.Collections.Hashtable GlueTable_AdditionalOption { get; set; }
        #endregion
        
        #region Parameter GlueTable_CatalogId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSource_GlueTable_CatalogId")]
        public System.String GlueTable_CatalogId { get; set; }
        #endregion
        
        #region Parameter GlueTable_ConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the connection to the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSource_GlueTable_ConnectionName")]
        public System.String GlueTable_ConnectionName { get; set; }
        #endregion
        
        #region Parameter CreatedRulesetName
        /// <summary>
        /// <para>
        /// <para>A name for the ruleset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatedRulesetName { get; set; }
        #endregion
        
        #region Parameter GlueTable_DatabaseName
        /// <summary>
        /// <para>
        /// <para>A database name in the Glue Data Catalog.</para>
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
        [Alias("DataSource_GlueTable_DatabaseName")]
        public System.String GlueTable_DatabaseName { get; set; }
        #endregion
        
        #region Parameter DataQualitySecurityConfiguration
        /// <summary>
        /// <para>
        /// <para>The name of the security configuration created with the data quality encryption option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataQualitySecurityConfiguration { get; set; }
        #endregion
        
        #region Parameter NumberOfWorker
        /// <summary>
        /// <para>
        /// <para>The number of <c>G.1X</c> workers to be used in the run. The default is 5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumberOfWorkers")]
        public System.Int32? NumberOfWorker { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>An IAM role supplied to encrypt the results of the run.</para>
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
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter GlueTable_TableName
        /// <summary>
        /// <para>
        /// <para>A table name in the Glue Data Catalog.</para>
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
        [Alias("DataSource_GlueTable_TableName")]
        public System.String GlueTable_TableName { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The timeout for a run in minutes. This is the maximum time that a run can consume
        /// resources before it is terminated and enters <c>TIMEOUT</c> status. The default is
        /// 2,880 minutes (48 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Timeout { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Used for idempotency and is recommended to be set to a random ID (such as a UUID)
        /// to avoid creating or starting multiple instances of the same resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RunId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.StartDataQualityRuleRecommendationRunResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.StartDataQualityRuleRecommendationRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RunId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-GLUEDataQualityRuleRecommendationRun (StartDataQualityRuleRecommendationRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.StartDataQualityRuleRecommendationRunResponse, StartGLUEDataQualityRuleRecommendationRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CreatedRulesetName = this.CreatedRulesetName;
            context.DataQualitySecurityConfiguration = this.DataQualitySecurityConfiguration;
            if (this.GlueTable_AdditionalOption != null)
            {
                context.GlueTable_AdditionalOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.GlueTable_AdditionalOption.Keys)
                {
                    context.GlueTable_AdditionalOption.Add((String)hashKey, (System.String)(this.GlueTable_AdditionalOption[hashKey]));
                }
            }
            context.GlueTable_CatalogId = this.GlueTable_CatalogId;
            context.GlueTable_ConnectionName = this.GlueTable_ConnectionName;
            context.GlueTable_DatabaseName = this.GlueTable_DatabaseName;
            #if MODULAR
            if (this.GlueTable_DatabaseName == null && ParameterWasBound(nameof(this.GlueTable_DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter GlueTable_DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GlueTable_TableName = this.GlueTable_TableName;
            #if MODULAR
            if (this.GlueTable_TableName == null && ParameterWasBound(nameof(this.GlueTable_TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter GlueTable_TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NumberOfWorker = this.NumberOfWorker;
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Timeout = this.Timeout;
            
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
            var request = new Amazon.Glue.Model.StartDataQualityRuleRecommendationRunRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CreatedRulesetName != null)
            {
                request.CreatedRulesetName = cmdletContext.CreatedRulesetName;
            }
            if (cmdletContext.DataQualitySecurityConfiguration != null)
            {
                request.DataQualitySecurityConfiguration = cmdletContext.DataQualitySecurityConfiguration;
            }
            
             // populate DataSource
            var requestDataSourceIsNull = true;
            request.DataSource = new Amazon.Glue.Model.DataSource();
            Amazon.Glue.Model.GlueTable requestDataSource_dataSource_GlueTable = null;
            
             // populate GlueTable
            var requestDataSource_dataSource_GlueTableIsNull = true;
            requestDataSource_dataSource_GlueTable = new Amazon.Glue.Model.GlueTable();
            Dictionary<System.String, System.String> requestDataSource_dataSource_GlueTable_glueTable_AdditionalOption = null;
            if (cmdletContext.GlueTable_AdditionalOption != null)
            {
                requestDataSource_dataSource_GlueTable_glueTable_AdditionalOption = cmdletContext.GlueTable_AdditionalOption;
            }
            if (requestDataSource_dataSource_GlueTable_glueTable_AdditionalOption != null)
            {
                requestDataSource_dataSource_GlueTable.AdditionalOptions = requestDataSource_dataSource_GlueTable_glueTable_AdditionalOption;
                requestDataSource_dataSource_GlueTableIsNull = false;
            }
            System.String requestDataSource_dataSource_GlueTable_glueTable_CatalogId = null;
            if (cmdletContext.GlueTable_CatalogId != null)
            {
                requestDataSource_dataSource_GlueTable_glueTable_CatalogId = cmdletContext.GlueTable_CatalogId;
            }
            if (requestDataSource_dataSource_GlueTable_glueTable_CatalogId != null)
            {
                requestDataSource_dataSource_GlueTable.CatalogId = requestDataSource_dataSource_GlueTable_glueTable_CatalogId;
                requestDataSource_dataSource_GlueTableIsNull = false;
            }
            System.String requestDataSource_dataSource_GlueTable_glueTable_ConnectionName = null;
            if (cmdletContext.GlueTable_ConnectionName != null)
            {
                requestDataSource_dataSource_GlueTable_glueTable_ConnectionName = cmdletContext.GlueTable_ConnectionName;
            }
            if (requestDataSource_dataSource_GlueTable_glueTable_ConnectionName != null)
            {
                requestDataSource_dataSource_GlueTable.ConnectionName = requestDataSource_dataSource_GlueTable_glueTable_ConnectionName;
                requestDataSource_dataSource_GlueTableIsNull = false;
            }
            System.String requestDataSource_dataSource_GlueTable_glueTable_DatabaseName = null;
            if (cmdletContext.GlueTable_DatabaseName != null)
            {
                requestDataSource_dataSource_GlueTable_glueTable_DatabaseName = cmdletContext.GlueTable_DatabaseName;
            }
            if (requestDataSource_dataSource_GlueTable_glueTable_DatabaseName != null)
            {
                requestDataSource_dataSource_GlueTable.DatabaseName = requestDataSource_dataSource_GlueTable_glueTable_DatabaseName;
                requestDataSource_dataSource_GlueTableIsNull = false;
            }
            System.String requestDataSource_dataSource_GlueTable_glueTable_TableName = null;
            if (cmdletContext.GlueTable_TableName != null)
            {
                requestDataSource_dataSource_GlueTable_glueTable_TableName = cmdletContext.GlueTable_TableName;
            }
            if (requestDataSource_dataSource_GlueTable_glueTable_TableName != null)
            {
                requestDataSource_dataSource_GlueTable.TableName = requestDataSource_dataSource_GlueTable_glueTable_TableName;
                requestDataSource_dataSource_GlueTableIsNull = false;
            }
             // determine if requestDataSource_dataSource_GlueTable should be set to null
            if (requestDataSource_dataSource_GlueTableIsNull)
            {
                requestDataSource_dataSource_GlueTable = null;
            }
            if (requestDataSource_dataSource_GlueTable != null)
            {
                request.DataSource.GlueTable = requestDataSource_dataSource_GlueTable;
                requestDataSourceIsNull = false;
            }
             // determine if request.DataSource should be set to null
            if (requestDataSourceIsNull)
            {
                request.DataSource = null;
            }
            if (cmdletContext.NumberOfWorker != null)
            {
                request.NumberOfWorkers = cmdletContext.NumberOfWorker.Value;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
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
        
        private Amazon.Glue.Model.StartDataQualityRuleRecommendationRunResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.StartDataQualityRuleRecommendationRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "StartDataQualityRuleRecommendationRun");
            try
            {
                return client.StartDataQualityRuleRecommendationRunAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CreatedRulesetName { get; set; }
            public System.String DataQualitySecurityConfiguration { get; set; }
            public Dictionary<System.String, System.String> GlueTable_AdditionalOption { get; set; }
            public System.String GlueTable_CatalogId { get; set; }
            public System.String GlueTable_ConnectionName { get; set; }
            public System.String GlueTable_DatabaseName { get; set; }
            public System.String GlueTable_TableName { get; set; }
            public System.Int32? NumberOfWorker { get; set; }
            public System.String Role { get; set; }
            public System.Int32? Timeout { get; set; }
            public System.Func<Amazon.Glue.Model.StartDataQualityRuleRecommendationRunResponse, StartGLUEDataQualityRuleRecommendationRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RunId;
        }
        
    }
}

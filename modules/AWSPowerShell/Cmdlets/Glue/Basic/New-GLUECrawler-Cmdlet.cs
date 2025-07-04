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
    /// Creates a new crawler with specified targets, role, configuration, and optional schedule.
    /// At least one crawl target must be specified, in the <c>s3Targets</c> field, the <c>jdbcTargets</c>
    /// field, or the <c>DynamoDBTargets</c> field.
    /// </summary>
    [Cmdlet("New", "GLUECrawler", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue CreateCrawler API operation.", Operation = new[] {"CreateCrawler"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateCrawlerResponse))]
    [AWSCmdletOutput("None or Amazon.Glue.Model.CreateCrawlerResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glue.Model.CreateCrawlerResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewGLUECrawlerCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LakeFormationConfiguration_AccountId
        /// <summary>
        /// <para>
        /// <para>Required for cross account crawls. For same account crawls as the target data, this
        /// can be left as null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LakeFormationConfiguration_AccountId { get; set; }
        #endregion
        
        #region Parameter Classifier
        /// <summary>
        /// <para>
        /// <para>A list of custom classifiers that the user has registered. By default, all built-in
        /// classifiers are included in a crawl, but these custom classifiers always override
        /// the default classifiers for a given classification.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Classifiers")]
        public System.String[] Classifier { get; set; }
        #endregion
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>Crawler configuration information. This versioned JSON string allows users to specify
        /// aspects of a crawler's behavior. For more information, see <a href="https://docs.aws.amazon.com/glue/latest/dg/crawler-configuration.html">Setting
        /// crawler configuration options</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration { get; set; }
        #endregion
        
        #region Parameter LineageConfiguration_CrawlerLineageSetting
        /// <summary>
        /// <para>
        /// <para>Specifies whether data lineage is enabled for the crawler. Valid values are:</para><ul><li><para>ENABLE: enables data lineage for the crawler</para></li><li><para>DISABLE: disables data lineage for the crawler</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LineageConfiguration_CrawlerLineageSettings")]
        [AWSConstantClassSource("Amazon.Glue.CrawlerLineageSettings")]
        public Amazon.Glue.CrawlerLineageSettings LineageConfiguration_CrawlerLineageSetting { get; set; }
        #endregion
        
        #region Parameter CrawlerSecurityConfiguration
        /// <summary>
        /// <para>
        /// <para>The name of the <c>SecurityConfiguration</c> structure to be used by this crawler.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CrawlerSecurityConfiguration { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The Glue database where results are written, such as: <c>arn:aws:daylight:us-east-1::database/sometable/*</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the new crawler.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the new crawler.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RecrawlPolicy_RecrawlBehavior
        /// <summary>
        /// <para>
        /// <para>Specifies whether to crawl the entire dataset again or to crawl only folders that
        /// were added since the last crawler run.</para><para>A value of <c>CRAWL_EVERYTHING</c> specifies crawling the entire dataset again.</para><para>A value of <c>CRAWL_NEW_FOLDERS_ONLY</c> specifies crawling only folders that were
        /// added since the last crawler run.</para><para>A value of <c>CRAWL_EVENT_MODE</c> specifies crawling only the changes identified
        /// by Amazon S3 events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.RecrawlBehavior")]
        public Amazon.Glue.RecrawlBehavior RecrawlPolicy_RecrawlBehavior { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The IAM role or Amazon Resource Name (ARN) of an IAM role used by the new crawler
        /// to access customer resources.</para>
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
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter Schedule
        /// <summary>
        /// <para>
        /// <para>A <c>cron</c> expression used to specify the schedule (see <a href="https://docs.aws.amazon.com/glue/latest/dg/monitor-data-warehouse-schedule.html">Time-Based
        /// Schedules for Jobs and Crawlers</a>. For example, to run something every day at 12:15
        /// UTC, you would specify: <c>cron(15 12 * * ? *)</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule { get; set; }
        #endregion
        
        #region Parameter SchemaChangePolicy
        /// <summary>
        /// <para>
        /// <para>The policy for the crawler's update and deletion behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Glue.Model.SchemaChangePolicy SchemaChangePolicy { get; set; }
        #endregion
        
        #region Parameter TablePrefix
        /// <summary>
        /// <para>
        /// <para>The table prefix used for catalog tables that are created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TablePrefix { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to use with this crawler request. You may use tags to limit access to the
        /// crawler. For more information about tags in Glue, see <a href="https://docs.aws.amazon.com/glue/latest/dg/monitor-tags.html">Amazon
        /// Web Services Tags in Glue</a> in the developer guide.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>A list of collection of targets to crawl.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Targets")]
        public Amazon.Glue.Model.CrawlerTargets Target { get; set; }
        #endregion
        
        #region Parameter LakeFormationConfiguration_UseLakeFormationCredential
        /// <summary>
        /// <para>
        /// <para>Specifies whether to use Lake Formation credentials for the crawler instead of the
        /// IAM role credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LakeFormationConfiguration_UseLakeFormationCredentials")]
        public System.Boolean? LakeFormationConfiguration_UseLakeFormationCredential { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateCrawlerResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUECrawler (CreateCrawler)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateCrawlerResponse, NewGLUECrawlerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Classifier != null)
            {
                context.Classifier = new List<System.String>(this.Classifier);
            }
            context.Configuration = this.Configuration;
            context.CrawlerSecurityConfiguration = this.CrawlerSecurityConfiguration;
            context.DatabaseName = this.DatabaseName;
            context.Description = this.Description;
            context.LakeFormationConfiguration_AccountId = this.LakeFormationConfiguration_AccountId;
            context.LakeFormationConfiguration_UseLakeFormationCredential = this.LakeFormationConfiguration_UseLakeFormationCredential;
            context.LineageConfiguration_CrawlerLineageSetting = this.LineageConfiguration_CrawlerLineageSetting;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecrawlPolicy_RecrawlBehavior = this.RecrawlPolicy_RecrawlBehavior;
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Schedule = this.Schedule;
            context.SchemaChangePolicy = this.SchemaChangePolicy;
            context.TablePrefix = this.TablePrefix;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Target = this.Target;
            #if MODULAR
            if (this.Target == null && ParameterWasBound(nameof(this.Target)))
            {
                WriteWarning("You are passing $null as a value for parameter Target which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.CreateCrawlerRequest();
            
            if (cmdletContext.Classifier != null)
            {
                request.Classifiers = cmdletContext.Classifier;
            }
            if (cmdletContext.Configuration != null)
            {
                request.Configuration = cmdletContext.Configuration;
            }
            if (cmdletContext.CrawlerSecurityConfiguration != null)
            {
                request.CrawlerSecurityConfiguration = cmdletContext.CrawlerSecurityConfiguration;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate LakeFormationConfiguration
            var requestLakeFormationConfigurationIsNull = true;
            request.LakeFormationConfiguration = new Amazon.Glue.Model.LakeFormationConfiguration();
            System.String requestLakeFormationConfiguration_lakeFormationConfiguration_AccountId = null;
            if (cmdletContext.LakeFormationConfiguration_AccountId != null)
            {
                requestLakeFormationConfiguration_lakeFormationConfiguration_AccountId = cmdletContext.LakeFormationConfiguration_AccountId;
            }
            if (requestLakeFormationConfiguration_lakeFormationConfiguration_AccountId != null)
            {
                request.LakeFormationConfiguration.AccountId = requestLakeFormationConfiguration_lakeFormationConfiguration_AccountId;
                requestLakeFormationConfigurationIsNull = false;
            }
            System.Boolean? requestLakeFormationConfiguration_lakeFormationConfiguration_UseLakeFormationCredential = null;
            if (cmdletContext.LakeFormationConfiguration_UseLakeFormationCredential != null)
            {
                requestLakeFormationConfiguration_lakeFormationConfiguration_UseLakeFormationCredential = cmdletContext.LakeFormationConfiguration_UseLakeFormationCredential.Value;
            }
            if (requestLakeFormationConfiguration_lakeFormationConfiguration_UseLakeFormationCredential != null)
            {
                request.LakeFormationConfiguration.UseLakeFormationCredentials = requestLakeFormationConfiguration_lakeFormationConfiguration_UseLakeFormationCredential.Value;
                requestLakeFormationConfigurationIsNull = false;
            }
             // determine if request.LakeFormationConfiguration should be set to null
            if (requestLakeFormationConfigurationIsNull)
            {
                request.LakeFormationConfiguration = null;
            }
            
             // populate LineageConfiguration
            var requestLineageConfigurationIsNull = true;
            request.LineageConfiguration = new Amazon.Glue.Model.LineageConfiguration();
            Amazon.Glue.CrawlerLineageSettings requestLineageConfiguration_lineageConfiguration_CrawlerLineageSetting = null;
            if (cmdletContext.LineageConfiguration_CrawlerLineageSetting != null)
            {
                requestLineageConfiguration_lineageConfiguration_CrawlerLineageSetting = cmdletContext.LineageConfiguration_CrawlerLineageSetting;
            }
            if (requestLineageConfiguration_lineageConfiguration_CrawlerLineageSetting != null)
            {
                request.LineageConfiguration.CrawlerLineageSettings = requestLineageConfiguration_lineageConfiguration_CrawlerLineageSetting;
                requestLineageConfigurationIsNull = false;
            }
             // determine if request.LineageConfiguration should be set to null
            if (requestLineageConfigurationIsNull)
            {
                request.LineageConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate RecrawlPolicy
            var requestRecrawlPolicyIsNull = true;
            request.RecrawlPolicy = new Amazon.Glue.Model.RecrawlPolicy();
            Amazon.Glue.RecrawlBehavior requestRecrawlPolicy_recrawlPolicy_RecrawlBehavior = null;
            if (cmdletContext.RecrawlPolicy_RecrawlBehavior != null)
            {
                requestRecrawlPolicy_recrawlPolicy_RecrawlBehavior = cmdletContext.RecrawlPolicy_RecrawlBehavior;
            }
            if (requestRecrawlPolicy_recrawlPolicy_RecrawlBehavior != null)
            {
                request.RecrawlPolicy.RecrawlBehavior = requestRecrawlPolicy_recrawlPolicy_RecrawlBehavior;
                requestRecrawlPolicyIsNull = false;
            }
             // determine if request.RecrawlPolicy should be set to null
            if (requestRecrawlPolicyIsNull)
            {
                request.RecrawlPolicy = null;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.Schedule != null)
            {
                request.Schedule = cmdletContext.Schedule;
            }
            if (cmdletContext.SchemaChangePolicy != null)
            {
                request.SchemaChangePolicy = cmdletContext.SchemaChangePolicy;
            }
            if (cmdletContext.TablePrefix != null)
            {
                request.TablePrefix = cmdletContext.TablePrefix;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Target != null)
            {
                request.Targets = cmdletContext.Target;
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
        
        private Amazon.Glue.Model.CreateCrawlerResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateCrawlerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateCrawler");
            try
            {
                return client.CreateCrawlerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Classifier { get; set; }
            public System.String Configuration { get; set; }
            public System.String CrawlerSecurityConfiguration { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String Description { get; set; }
            public System.String LakeFormationConfiguration_AccountId { get; set; }
            public System.Boolean? LakeFormationConfiguration_UseLakeFormationCredential { get; set; }
            public Amazon.Glue.CrawlerLineageSettings LineageConfiguration_CrawlerLineageSetting { get; set; }
            public System.String Name { get; set; }
            public Amazon.Glue.RecrawlBehavior RecrawlPolicy_RecrawlBehavior { get; set; }
            public System.String Role { get; set; }
            public System.String Schedule { get; set; }
            public Amazon.Glue.Model.SchemaChangePolicy SchemaChangePolicy { get; set; }
            public System.String TablePrefix { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.Glue.Model.CrawlerTargets Target { get; set; }
            public System.Func<Amazon.Glue.Model.CreateCrawlerResponse, NewGLUECrawlerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

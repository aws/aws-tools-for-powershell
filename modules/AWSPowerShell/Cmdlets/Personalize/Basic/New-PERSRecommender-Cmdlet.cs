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
using Amazon.Personalize;
using Amazon.Personalize.Model;

namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// Creates a recommender with the recipe (a Domain dataset group use case) you specify.
    /// You create recommenders for a Domain dataset group and specify the recommender's Amazon
    /// Resource Name (ARN) when you make a <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_RS_GetRecommendations.html">GetRecommendations</a>
    /// request. 
    /// 
    ///  
    /// <para><b>Minimum recommendation requests per second</b></para><important><para>
    /// A high <code>minRecommendationRequestsPerSecond</code> will increase your bill. We
    /// recommend starting with 1 for <code>minRecommendationRequestsPerSecond</code> (the
    /// default). Track your usage using Amazon CloudWatch metrics, and increase the <code>minRecommendationRequestsPerSecond</code>
    /// as necessary.
    /// </para></important><para>
    /// When you create a recommender, you can configure the recommender's minimum recommendation
    /// requests per second. The minimum recommendation requests per second (<code>minRecommendationRequestsPerSecond</code>)
    /// specifies the baseline recommendation request throughput provisioned by Amazon Personalize.
    /// The default minRecommendationRequestsPerSecond is <code>1</code>. A recommendation
    /// request is a single <code>GetRecommendations</code> operation. Request throughput
    /// is measured in requests per second and Amazon Personalize uses your requests per second
    /// to derive your requests per hour and the price of your recommender usage. 
    /// </para><para>
    ///  If your requests per second increases beyond <code>minRecommendationRequestsPerSecond</code>,
    /// Amazon Personalize auto-scales the provisioned capacity up and down, but never below
    /// <code>minRecommendationRequestsPerSecond</code>. There's a short time delay while
    /// the capacity is increased that might cause loss of requests.
    /// </para><para>
    ///  Your bill is the greater of either the minimum requests per hour (based on minRecommendationRequestsPerSecond)
    /// or the actual number of requests. The actual request throughput used is calculated
    /// as the average requests/second within a one-hour window. We recommend starting with
    /// the default <code>minRecommendationRequestsPerSecond</code>, track your usage using
    /// Amazon CloudWatch metrics, and then increase the <code>minRecommendationRequestsPerSecond</code>
    /// as necessary. 
    /// </para><para><b>Status</b></para><para>
    /// A recommender can be in one of the following states:
    /// </para><ul><li><para>
    /// CREATE PENDING &gt; CREATE IN_PROGRESS &gt; ACTIVE -or- CREATE FAILED
    /// </para></li><li><para>
    /// STOP PENDING &gt; STOP IN_PROGRESS &gt; INACTIVE &gt; START PENDING &gt; START IN_PROGRESS
    /// &gt; ACTIVE
    /// </para></li><li><para>
    /// DELETE PENDING &gt; DELETE IN_PROGRESS
    /// </para></li></ul><para>
    /// To get the recommender status, call <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeRecommender.html">DescribeRecommender</a>.
    /// </para><note><para>
    /// Wait until the <code>status</code> of the recommender is <code>ACTIVE</code> before
    /// asking the recommender for recommendations.
    /// </para></note><para><b>Related APIs</b></para><ul><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_ListRecommenders.html">ListRecommenders</a></para></li><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeRecommender.html">DescribeRecommender</a></para></li><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_UpdateRecommender.html">UpdateRecommender</a></para></li><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DeleteRecommender.html">DeleteRecommender</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "PERSRecommender", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Personalize CreateRecommender API operation.", Operation = new[] {"CreateRecommender"}, SelectReturnType = typeof(Amazon.Personalize.Model.CreateRecommenderResponse))]
    [AWSCmdletOutput("System.String or Amazon.Personalize.Model.CreateRecommenderResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Personalize.Model.CreateRecommenderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPERSRecommenderCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatasetGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination domain dataset group for the recommender.</para>
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
        public System.String DatasetGroupArn { get; set; }
        #endregion
        
        #region Parameter RecommenderConfig_EnableMetadataWithRecommendation
        /// <summary>
        /// <para>
        /// <para>Whether metadata with recommendations is enabled for the recommender. If enabled,
        /// you can specify the columns from your Items dataset in your request for recommendations.
        /// Amazon Personalize returns this data for each item in the recommendation response.
        /// </para><para> If you enable metadata in recommendations, you will incur additional costs. For more
        /// information, see <a href="https://aws.amazon.com/personalize/pricing/">Amazon Personalize
        /// pricing</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommenderConfig_EnableMetadataWithRecommendations")]
        public System.Boolean? RecommenderConfig_EnableMetadataWithRecommendation { get; set; }
        #endregion
        
        #region Parameter TrainingDataConfig_ExcludedDatasetColumn
        /// <summary>
        /// <para>
        /// <para>Specifies the columns to exclude from training. Each key is a dataset type, and each
        /// value is a list of columns. Exclude columns to control what data Amazon Personalize
        /// uses to generate recommendations. For example, you might have a column that you want
        /// to use only to filter recommendations. You can exclude this column from training and
        /// Amazon Personalize considers it only when filtering. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommenderConfig_TrainingDataConfig_ExcludedDatasetColumns")]
        public System.Collections.Hashtable TrainingDataConfig_ExcludedDatasetColumn { get; set; }
        #endregion
        
        #region Parameter RecommenderConfig_ItemExplorationConfig
        /// <summary>
        /// <para>
        /// <para>Specifies the exploration configuration hyperparameters, including <code>explorationWeight</code>
        /// and <code>explorationItemAgeCutOff</code>, you want to use to configure the amount
        /// of item exploration Amazon Personalize uses when recommending items. Provide <code>itemExplorationConfig</code>
        /// data only if your recommenders generate personalized recommendations for a user (not
        /// popular items or similar items).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable RecommenderConfig_ItemExplorationConfig { get; set; }
        #endregion
        
        #region Parameter RecommenderConfig_MinRecommendationRequestsPerSecond
        /// <summary>
        /// <para>
        /// <para>Specifies the requested minimum provisioned recommendation requests per second that
        /// Amazon Personalize will support. A high <code>minRecommendationRequestsPerSecond</code>
        /// will increase your bill. We recommend starting with 1 for <code>minRecommendationRequestsPerSecond</code>
        /// (the default). Track your usage using Amazon CloudWatch metrics, and increase the
        /// <code>minRecommendationRequestsPerSecond</code> as necessary.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RecommenderConfig_MinRecommendationRequestsPerSecond { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the recommender.</para>
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
        
        #region Parameter RecipeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the recipe that the recommender will use. For a
        /// recommender, a recipe is a Domain dataset group use case. Only Domain dataset group
        /// use cases can be used to create a recommender. For information about use cases see
        /// <a href="https://docs.aws.amazon.com/personalize/latest/dg/domain-use-cases.html">Choosing
        /// recommender use cases</a>. </para>
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
        public System.String RecipeArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://docs.aws.amazon.com/personalize/latest/dg/tagging-resources.html">tags</a>
        /// to apply to the recommender.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Personalize.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecommenderArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.CreateRecommenderResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.CreateRecommenderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecommenderArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PERSRecommender (CreateRecommender)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.CreateRecommenderResponse, NewPERSRecommenderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DatasetGroupArn = this.DatasetGroupArn;
            #if MODULAR
            if (this.DatasetGroupArn == null && ParameterWasBound(nameof(this.DatasetGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecipeArn = this.RecipeArn;
            #if MODULAR
            if (this.RecipeArn == null && ParameterWasBound(nameof(this.RecipeArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RecipeArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecommenderConfig_EnableMetadataWithRecommendation = this.RecommenderConfig_EnableMetadataWithRecommendation;
            if (this.RecommenderConfig_ItemExplorationConfig != null)
            {
                context.RecommenderConfig_ItemExplorationConfig = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RecommenderConfig_ItemExplorationConfig.Keys)
                {
                    context.RecommenderConfig_ItemExplorationConfig.Add((String)hashKey, (String)(this.RecommenderConfig_ItemExplorationConfig[hashKey]));
                }
            }
            context.RecommenderConfig_MinRecommendationRequestsPerSecond = this.RecommenderConfig_MinRecommendationRequestsPerSecond;
            if (this.TrainingDataConfig_ExcludedDatasetColumn != null)
            {
                context.TrainingDataConfig_ExcludedDatasetColumn = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.TrainingDataConfig_ExcludedDatasetColumn.Keys)
                {
                    object hashValue = this.TrainingDataConfig_ExcludedDatasetColumn[hashKey];
                    if (hashValue == null)
                    {
                        context.TrainingDataConfig_ExcludedDatasetColumn.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.TrainingDataConfig_ExcludedDatasetColumn.Add((String)hashKey, valueSet);
                }
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Personalize.Model.Tag>(this.Tag);
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
            var request = new Amazon.Personalize.Model.CreateRecommenderRequest();
            
            if (cmdletContext.DatasetGroupArn != null)
            {
                request.DatasetGroupArn = cmdletContext.DatasetGroupArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RecipeArn != null)
            {
                request.RecipeArn = cmdletContext.RecipeArn;
            }
            
             // populate RecommenderConfig
            var requestRecommenderConfigIsNull = true;
            request.RecommenderConfig = new Amazon.Personalize.Model.RecommenderConfig();
            System.Boolean? requestRecommenderConfig_recommenderConfig_EnableMetadataWithRecommendation = null;
            if (cmdletContext.RecommenderConfig_EnableMetadataWithRecommendation != null)
            {
                requestRecommenderConfig_recommenderConfig_EnableMetadataWithRecommendation = cmdletContext.RecommenderConfig_EnableMetadataWithRecommendation.Value;
            }
            if (requestRecommenderConfig_recommenderConfig_EnableMetadataWithRecommendation != null)
            {
                request.RecommenderConfig.EnableMetadataWithRecommendations = requestRecommenderConfig_recommenderConfig_EnableMetadataWithRecommendation.Value;
                requestRecommenderConfigIsNull = false;
            }
            Dictionary<System.String, System.String> requestRecommenderConfig_recommenderConfig_ItemExplorationConfig = null;
            if (cmdletContext.RecommenderConfig_ItemExplorationConfig != null)
            {
                requestRecommenderConfig_recommenderConfig_ItemExplorationConfig = cmdletContext.RecommenderConfig_ItemExplorationConfig;
            }
            if (requestRecommenderConfig_recommenderConfig_ItemExplorationConfig != null)
            {
                request.RecommenderConfig.ItemExplorationConfig = requestRecommenderConfig_recommenderConfig_ItemExplorationConfig;
                requestRecommenderConfigIsNull = false;
            }
            System.Int32? requestRecommenderConfig_recommenderConfig_MinRecommendationRequestsPerSecond = null;
            if (cmdletContext.RecommenderConfig_MinRecommendationRequestsPerSecond != null)
            {
                requestRecommenderConfig_recommenderConfig_MinRecommendationRequestsPerSecond = cmdletContext.RecommenderConfig_MinRecommendationRequestsPerSecond.Value;
            }
            if (requestRecommenderConfig_recommenderConfig_MinRecommendationRequestsPerSecond != null)
            {
                request.RecommenderConfig.MinRecommendationRequestsPerSecond = requestRecommenderConfig_recommenderConfig_MinRecommendationRequestsPerSecond.Value;
                requestRecommenderConfigIsNull = false;
            }
            Amazon.Personalize.Model.TrainingDataConfig requestRecommenderConfig_recommenderConfig_TrainingDataConfig = null;
            
             // populate TrainingDataConfig
            var requestRecommenderConfig_recommenderConfig_TrainingDataConfigIsNull = true;
            requestRecommenderConfig_recommenderConfig_TrainingDataConfig = new Amazon.Personalize.Model.TrainingDataConfig();
            Dictionary<System.String, List<System.String>> requestRecommenderConfig_recommenderConfig_TrainingDataConfig_trainingDataConfig_ExcludedDatasetColumn = null;
            if (cmdletContext.TrainingDataConfig_ExcludedDatasetColumn != null)
            {
                requestRecommenderConfig_recommenderConfig_TrainingDataConfig_trainingDataConfig_ExcludedDatasetColumn = cmdletContext.TrainingDataConfig_ExcludedDatasetColumn;
            }
            if (requestRecommenderConfig_recommenderConfig_TrainingDataConfig_trainingDataConfig_ExcludedDatasetColumn != null)
            {
                requestRecommenderConfig_recommenderConfig_TrainingDataConfig.ExcludedDatasetColumns = requestRecommenderConfig_recommenderConfig_TrainingDataConfig_trainingDataConfig_ExcludedDatasetColumn;
                requestRecommenderConfig_recommenderConfig_TrainingDataConfigIsNull = false;
            }
             // determine if requestRecommenderConfig_recommenderConfig_TrainingDataConfig should be set to null
            if (requestRecommenderConfig_recommenderConfig_TrainingDataConfigIsNull)
            {
                requestRecommenderConfig_recommenderConfig_TrainingDataConfig = null;
            }
            if (requestRecommenderConfig_recommenderConfig_TrainingDataConfig != null)
            {
                request.RecommenderConfig.TrainingDataConfig = requestRecommenderConfig_recommenderConfig_TrainingDataConfig;
                requestRecommenderConfigIsNull = false;
            }
             // determine if request.RecommenderConfig should be set to null
            if (requestRecommenderConfigIsNull)
            {
                request.RecommenderConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Personalize.Model.CreateRecommenderResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.CreateRecommenderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "CreateRecommender");
            try
            {
                #if DESKTOP
                return client.CreateRecommender(request);
                #elif CORECLR
                return client.CreateRecommenderAsync(request).GetAwaiter().GetResult();
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
            public System.String DatasetGroupArn { get; set; }
            public System.String Name { get; set; }
            public System.String RecipeArn { get; set; }
            public System.Boolean? RecommenderConfig_EnableMetadataWithRecommendation { get; set; }
            public Dictionary<System.String, System.String> RecommenderConfig_ItemExplorationConfig { get; set; }
            public System.Int32? RecommenderConfig_MinRecommendationRequestsPerSecond { get; set; }
            public Dictionary<System.String, List<System.String>> TrainingDataConfig_ExcludedDatasetColumn { get; set; }
            public List<Amazon.Personalize.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Personalize.Model.CreateRecommenderResponse, NewPERSRecommenderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecommenderArn;
        }
        
    }
}

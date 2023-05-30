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
    /// Updates the recommender to modify the recommender configuration. If you update the
    /// recommender to modify the columns used in training, Amazon Personalize automatically
    /// starts a full retraining of the models backing your recommender. While the update
    /// completes, you can still get recommendations from the recommender. The recommender
    /// uses the previous configuration until the update completes. To track the status of
    /// this update, use the <code>latestRecommenderUpdate</code> returned in the <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeRecommender.html">DescribeRecommender</a>
    /// operation.
    /// </summary>
    [Cmdlet("Update", "PERSRecommender", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Personalize UpdateRecommender API operation.", Operation = new[] {"UpdateRecommender"}, SelectReturnType = typeof(Amazon.Personalize.Model.UpdateRecommenderResponse))]
    [AWSCmdletOutput("System.String or Amazon.Personalize.Model.UpdateRecommenderResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Personalize.Model.UpdateRecommenderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePERSRecommenderCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter RecommenderArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the recommender to modify.</para>
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
        public System.String RecommenderArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecommenderArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.UpdateRecommenderResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.UpdateRecommenderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecommenderArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RecommenderArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RecommenderArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RecommenderArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecommenderArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PERSRecommender (UpdateRecommender)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.UpdateRecommenderResponse, UpdatePERSRecommenderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RecommenderArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RecommenderArn = this.RecommenderArn;
            #if MODULAR
            if (this.RecommenderArn == null && ParameterWasBound(nameof(this.RecommenderArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommenderArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Personalize.Model.UpdateRecommenderRequest();
            
            if (cmdletContext.RecommenderArn != null)
            {
                request.RecommenderArn = cmdletContext.RecommenderArn;
            }
            
             // populate RecommenderConfig
            var requestRecommenderConfigIsNull = true;
            request.RecommenderConfig = new Amazon.Personalize.Model.RecommenderConfig();
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
        
        private Amazon.Personalize.Model.UpdateRecommenderResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.UpdateRecommenderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "UpdateRecommender");
            try
            {
                #if DESKTOP
                return client.UpdateRecommender(request);
                #elif CORECLR
                return client.UpdateRecommenderAsync(request).GetAwaiter().GetResult();
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
            public System.String RecommenderArn { get; set; }
            public Dictionary<System.String, System.String> RecommenderConfig_ItemExplorationConfig { get; set; }
            public System.Int32? RecommenderConfig_MinRecommendationRequestsPerSecond { get; set; }
            public Dictionary<System.String, List<System.String>> TrainingDataConfig_ExcludedDatasetColumn { get; set; }
            public System.Func<Amazon.Personalize.Model.UpdateRecommenderResponse, UpdatePERSRecommenderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecommenderArn;
        }
        
    }
}

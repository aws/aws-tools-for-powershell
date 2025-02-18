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
using Amazon.Personalize;
using Amazon.Personalize.Model;

namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// <important><para>
    ///  You incur campaign costs while it is active. To avoid unnecessary costs, make sure
    /// to delete the campaign when you are finished. For information about campaign costs,
    /// see <a href="https://aws.amazon.com/personalize/pricing/">Amazon Personalize pricing</a>.
    /// </para></important><para>
    /// Creates a campaign that deploys a solution version. When a client calls the <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_RS_GetRecommendations.html">GetRecommendations</a>
    /// and <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_RS_GetPersonalizedRanking.html">GetPersonalizedRanking</a>
    /// APIs, a campaign is specified in the request.
    /// </para><para><b>Minimum Provisioned TPS and Auto-Scaling</b></para><important><para>
    ///  A high <c>minProvisionedTPS</c> will increase your cost. We recommend starting with
    /// 1 for <c>minProvisionedTPS</c> (the default). Track your usage using Amazon CloudWatch
    /// metrics, and increase the <c>minProvisionedTPS</c> as necessary.
    /// </para></important><para>
    ///  When you create an Amazon Personalize campaign, you can specify the minimum provisioned
    /// transactions per second (<c>minProvisionedTPS</c>) for the campaign. This is the baseline
    /// transaction throughput for the campaign provisioned by Amazon Personalize. It sets
    /// the minimum billing charge for the campaign while it is active. A transaction is a
    /// single <c>GetRecommendations</c> or <c>GetPersonalizedRanking</c> request. The default
    /// <c>minProvisionedTPS</c> is 1.
    /// </para><para>
    ///  If your TPS increases beyond the <c>minProvisionedTPS</c>, Amazon Personalize auto-scales
    /// the provisioned capacity up and down, but never below <c>minProvisionedTPS</c>. There's
    /// a short time delay while the capacity is increased that might cause loss of transactions.
    /// When your traffic reduces, capacity returns to the <c>minProvisionedTPS</c>. 
    /// </para><para>
    /// You are charged for the the minimum provisioned TPS or, if your requests exceed the
    /// <c>minProvisionedTPS</c>, the actual TPS. The actual TPS is the total number of recommendation
    /// requests you make. We recommend starting with a low <c>minProvisionedTPS</c>, track
    /// your usage using Amazon CloudWatch metrics, and then increase the <c>minProvisionedTPS</c>
    /// as necessary.
    /// </para><para>
    /// For more information about campaign costs, see <a href="https://aws.amazon.com/personalize/pricing/">Amazon
    /// Personalize pricing</a>.
    /// </para><para><b>Status</b></para><para>
    /// A campaign can be in one of the following states:
    /// </para><ul><li><para>
    /// CREATE PENDING &gt; CREATE IN_PROGRESS &gt; ACTIVE -or- CREATE FAILED
    /// </para></li><li><para>
    /// DELETE PENDING &gt; DELETE IN_PROGRESS
    /// </para></li></ul><para>
    /// To get the campaign status, call <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeCampaign.html">DescribeCampaign</a>.
    /// </para><note><para>
    /// Wait until the <c>status</c> of the campaign is <c>ACTIVE</c> before asking the campaign
    /// for recommendations.
    /// </para></note><para><b>Related APIs</b></para><ul><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_ListCampaigns.html">ListCampaigns</a></para></li><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeCampaign.html">DescribeCampaign</a></para></li><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_UpdateCampaign.html">UpdateCampaign</a></para></li><li><para><a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DeleteCampaign.html">DeleteCampaign</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "PERSCampaign", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Personalize CreateCampaign API operation.", Operation = new[] {"CreateCampaign"}, SelectReturnType = typeof(Amazon.Personalize.Model.CreateCampaignResponse))]
    [AWSCmdletOutput("System.String or Amazon.Personalize.Model.CreateCampaignResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Personalize.Model.CreateCampaignResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPERSCampaignCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CampaignConfig_EnableMetadataWithRecommendation
        /// <summary>
        /// <para>
        /// <para>Whether metadata with recommendations is enabled for the campaign. If enabled, you
        /// can specify the columns from your Items dataset in your request for recommendations.
        /// Amazon Personalize returns this data for each item in the recommendation response.
        /// For information about enabling metadata for a campaign, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/campaigns.html#create-campaign-return-metadata">Enabling
        /// metadata in recommendations for a campaign</a>.</para><para> If you enable metadata in recommendations, you will incur additional costs. For more
        /// information, see <a href="https://aws.amazon.com/personalize/pricing/">Amazon Personalize
        /// pricing</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CampaignConfig_EnableMetadataWithRecommendations")]
        public System.Boolean? CampaignConfig_EnableMetadataWithRecommendation { get; set; }
        #endregion
        
        #region Parameter CampaignConfig_ItemExplorationConfig
        /// <summary>
        /// <para>
        /// <para>Specifies the exploration configuration hyperparameters, including <c>explorationWeight</c>
        /// and <c>explorationItemAgeCutOff</c>, you want to use to configure the amount of item
        /// exploration Amazon Personalize uses when recommending items. Provide <c>itemExplorationConfig</c>
        /// data only if your solution uses the <a href="https://docs.aws.amazon.com/personalize/latest/dg/native-recipe-new-item-USER_PERSONALIZATION.html">User-Personalization</a>
        /// recipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable CampaignConfig_ItemExplorationConfig { get; set; }
        #endregion
        
        #region Parameter MinProvisionedTPS
        /// <summary>
        /// <para>
        /// <para>Specifies the requested minimum provisioned transactions (recommendations) per second
        /// that Amazon Personalize will support. A high <c>minProvisionedTPS</c> will increase
        /// your bill. We recommend starting with 1 for <c>minProvisionedTPS</c> (the default).
        /// Track your usage using Amazon CloudWatch metrics, and increase the <c>minProvisionedTPS</c>
        /// as necessary.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinProvisionedTPS { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the new campaign. The campaign name must be unique within your account.</para>
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
        
        #region Parameter SolutionVersionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the trained model to deploy with the campaign. To
        /// specify the latest solution version of your solution, specify the ARN of your <i>solution</i>
        /// in <c>SolutionArn/$LATEST</c> format. You must use this format if you set <c>syncWithLatestSolutionVersion</c>
        /// to <c>True</c> in the <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_CampaignConfig.html">CampaignConfig</a>.
        /// </para><para> To deploy a model that isn't the latest solution version of your solution, specify
        /// the ARN of the solution version. </para><para> For more information about automatic campaign updates, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/campaigns.html#create-campaign-automatic-latest-sv-update">Enabling
        /// automatic campaign updates</a>. </para>
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
        public System.String SolutionVersionArn { get; set; }
        #endregion
        
        #region Parameter CampaignConfig_SyncWithLatestSolutionVersion
        /// <summary>
        /// <para>
        /// <para>Whether the campaign automatically updates to use the latest solution version (trained
        /// model) of a solution. If you specify <c>True</c>, you must specify the ARN of your
        /// <i>solution</i> for the <c>SolutionVersionArn</c> parameter. It must be in <c>SolutionArn/$LATEST</c>
        /// format. The default is <c>False</c> and you must manually update the campaign to deploy
        /// the latest solution version. </para><para> For more information about automatic campaign updates, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/campaigns.html#create-campaign-automatic-latest-sv-update">Enabling
        /// automatic campaign updates</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CampaignConfig_SyncWithLatestSolutionVersion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://docs.aws.amazon.com/personalize/latest/dg/tagging-resources.html">tags</a>
        /// to apply to the campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Personalize.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CampaignArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.CreateCampaignResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.CreateCampaignResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CampaignArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PERSCampaign (CreateCampaign)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.CreateCampaignResponse, NewPERSCampaignCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CampaignConfig_EnableMetadataWithRecommendation = this.CampaignConfig_EnableMetadataWithRecommendation;
            if (this.CampaignConfig_ItemExplorationConfig != null)
            {
                context.CampaignConfig_ItemExplorationConfig = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CampaignConfig_ItemExplorationConfig.Keys)
                {
                    context.CampaignConfig_ItemExplorationConfig.Add((String)hashKey, (System.String)(this.CampaignConfig_ItemExplorationConfig[hashKey]));
                }
            }
            context.CampaignConfig_SyncWithLatestSolutionVersion = this.CampaignConfig_SyncWithLatestSolutionVersion;
            context.MinProvisionedTPS = this.MinProvisionedTPS;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SolutionVersionArn = this.SolutionVersionArn;
            #if MODULAR
            if (this.SolutionVersionArn == null && ParameterWasBound(nameof(this.SolutionVersionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SolutionVersionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Personalize.Model.CreateCampaignRequest();
            
            
             // populate CampaignConfig
            var requestCampaignConfigIsNull = true;
            request.CampaignConfig = new Amazon.Personalize.Model.CampaignConfig();
            System.Boolean? requestCampaignConfig_campaignConfig_EnableMetadataWithRecommendation = null;
            if (cmdletContext.CampaignConfig_EnableMetadataWithRecommendation != null)
            {
                requestCampaignConfig_campaignConfig_EnableMetadataWithRecommendation = cmdletContext.CampaignConfig_EnableMetadataWithRecommendation.Value;
            }
            if (requestCampaignConfig_campaignConfig_EnableMetadataWithRecommendation != null)
            {
                request.CampaignConfig.EnableMetadataWithRecommendations = requestCampaignConfig_campaignConfig_EnableMetadataWithRecommendation.Value;
                requestCampaignConfigIsNull = false;
            }
            Dictionary<System.String, System.String> requestCampaignConfig_campaignConfig_ItemExplorationConfig = null;
            if (cmdletContext.CampaignConfig_ItemExplorationConfig != null)
            {
                requestCampaignConfig_campaignConfig_ItemExplorationConfig = cmdletContext.CampaignConfig_ItemExplorationConfig;
            }
            if (requestCampaignConfig_campaignConfig_ItemExplorationConfig != null)
            {
                request.CampaignConfig.ItemExplorationConfig = requestCampaignConfig_campaignConfig_ItemExplorationConfig;
                requestCampaignConfigIsNull = false;
            }
            System.Boolean? requestCampaignConfig_campaignConfig_SyncWithLatestSolutionVersion = null;
            if (cmdletContext.CampaignConfig_SyncWithLatestSolutionVersion != null)
            {
                requestCampaignConfig_campaignConfig_SyncWithLatestSolutionVersion = cmdletContext.CampaignConfig_SyncWithLatestSolutionVersion.Value;
            }
            if (requestCampaignConfig_campaignConfig_SyncWithLatestSolutionVersion != null)
            {
                request.CampaignConfig.SyncWithLatestSolutionVersion = requestCampaignConfig_campaignConfig_SyncWithLatestSolutionVersion.Value;
                requestCampaignConfigIsNull = false;
            }
             // determine if request.CampaignConfig should be set to null
            if (requestCampaignConfigIsNull)
            {
                request.CampaignConfig = null;
            }
            if (cmdletContext.MinProvisionedTPS != null)
            {
                request.MinProvisionedTPS = cmdletContext.MinProvisionedTPS.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SolutionVersionArn != null)
            {
                request.SolutionVersionArn = cmdletContext.SolutionVersionArn;
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
        
        private Amazon.Personalize.Model.CreateCampaignResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.CreateCampaignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "CreateCampaign");
            try
            {
                return client.CreateCampaignAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? CampaignConfig_EnableMetadataWithRecommendation { get; set; }
            public Dictionary<System.String, System.String> CampaignConfig_ItemExplorationConfig { get; set; }
            public System.Boolean? CampaignConfig_SyncWithLatestSolutionVersion { get; set; }
            public System.Int32? MinProvisionedTPS { get; set; }
            public System.String Name { get; set; }
            public System.String SolutionVersionArn { get; set; }
            public List<Amazon.Personalize.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Personalize.Model.CreateCampaignResponse, NewPERSCampaignCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CampaignArn;
        }
        
    }
}

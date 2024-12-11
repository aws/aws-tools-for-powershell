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
    /// Updates a campaign to deploy a retrained solution version with an existing campaign,
    /// change your campaign's <c>minProvisionedTPS</c>, or modify your campaign's configuration.
    /// For example, you can set <c>enableMetadataWithRecommendations</c> to true for an existing
    /// campaign.
    /// 
    ///  
    /// <para>
    ///  To update a campaign to start automatically using the latest solution version, specify
    /// the following:
    /// </para><ul><li><para>
    /// For the <c>SolutionVersionArn</c> parameter, specify the Amazon Resource Name (ARN)
    /// of your solution in <c>SolutionArn/$LATEST</c> format. 
    /// </para></li><li><para>
    ///  In the <c>campaignConfig</c>, set <c>syncWithLatestSolutionVersion</c> to <c>true</c>.
    /// 
    /// </para></li></ul><para>
    /// To update a campaign, the campaign status must be ACTIVE or CREATE FAILED. Check the
    /// campaign status using the <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_DescribeCampaign.html">DescribeCampaign</a>
    /// operation.
    /// </para><note><para>
    /// You can still get recommendations from a campaign while an update is in progress.
    /// The campaign will use the previous solution version and campaign configuration to
    /// generate recommendations until the latest campaign update status is <c>Active</c>.
    /// 
    /// </para></note><para>
    /// For more information about updating a campaign, including code samples, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/update-campaigns.html">Updating
    /// a campaign</a>. For more information about campaigns, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/campaigns.html">Creating
    /// a campaign</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "PERSCampaign", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Personalize UpdateCampaign API operation.", Operation = new[] {"UpdateCampaign"}, SelectReturnType = typeof(Amazon.Personalize.Model.UpdateCampaignResponse))]
    [AWSCmdletOutput("System.String or Amazon.Personalize.Model.UpdateCampaignResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Personalize.Model.UpdateCampaignResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePERSCampaignCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CampaignArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the campaign.</para>
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
        public System.String CampaignArn { get; set; }
        #endregion
        
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
        
        #region Parameter SolutionVersionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a new model to deploy. To specify the latest solution
        /// version of your solution, specify the ARN of your <i>solution</i> in <c>SolutionArn/$LATEST</c>
        /// format. You must use this format if you set <c>syncWithLatestSolutionVersion</c> to
        /// <c>True</c> in the <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_CampaignConfig.html">CampaignConfig</a>.
        /// </para><para> To deploy a model that isn't the latest solution version of your solution, specify
        /// the ARN of the solution version. </para><para> For more information about automatic campaign updates, see <a href="https://docs.aws.amazon.com/personalize/latest/dg/campaigns.html#create-campaign-automatic-latest-sv-update">Enabling
        /// automatic campaign updates</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CampaignArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.UpdateCampaignResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.UpdateCampaignResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CampaignArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PERSCampaign (UpdateCampaign)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.UpdateCampaignResponse, UpdatePERSCampaignCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CampaignArn = this.CampaignArn;
            #if MODULAR
            if (this.CampaignArn == null && ParameterWasBound(nameof(this.CampaignArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CampaignArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.SolutionVersionArn = this.SolutionVersionArn;
            
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
            var request = new Amazon.Personalize.Model.UpdateCampaignRequest();
            
            if (cmdletContext.CampaignArn != null)
            {
                request.CampaignArn = cmdletContext.CampaignArn;
            }
            
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
            if (cmdletContext.SolutionVersionArn != null)
            {
                request.SolutionVersionArn = cmdletContext.SolutionVersionArn;
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
        
        private Amazon.Personalize.Model.UpdateCampaignResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.UpdateCampaignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "UpdateCampaign");
            try
            {
                #if DESKTOP
                return client.UpdateCampaign(request);
                #elif CORECLR
                return client.UpdateCampaignAsync(request).GetAwaiter().GetResult();
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
            public System.String CampaignArn { get; set; }
            public System.Boolean? CampaignConfig_EnableMetadataWithRecommendation { get; set; }
            public Dictionary<System.String, System.String> CampaignConfig_ItemExplorationConfig { get; set; }
            public System.Boolean? CampaignConfig_SyncWithLatestSolutionVersion { get; set; }
            public System.Int32? MinProvisionedTPS { get; set; }
            public System.String SolutionVersionArn { get; set; }
            public System.Func<Amazon.Personalize.Model.UpdateCampaignResponse, UpdatePERSCampaignCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CampaignArn;
        }
        
    }
}

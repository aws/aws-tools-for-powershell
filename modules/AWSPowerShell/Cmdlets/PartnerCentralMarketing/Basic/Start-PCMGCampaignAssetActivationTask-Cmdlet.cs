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
using Amazon.PartnerCentralMarketing;
using Amazon.PartnerCentralMarketing.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCMG
{
    /// <summary>
    /// Activates 1–25 of a campaign's assets as one ordered unit, and returns a task to poll.
    /// Takes a **list** because the service owns the ordering. Assets link to one another
    /// by URL — an email's call-to-action carries the landing page's URL, the landing page's
    /// download field carries the document's — and a URL does not exist until the asset it
    /// points at is activated. Those edges are derived by the service from the campaign's
    /// pinned template, so reconstructing and topologically sorting them is work the service
    /// has already done, and getting it wrong arms an email with a dead link. Name every
    /// asset you want live and the service sequences them; "activate everything" is the list
    /// with every id in it, which ListCampaignAssets already gave you. Asynchronous, because
    /// activating an asset installs or arms behaviour that runs later and an email activation
    /// bulk-loads its audience into the delivery platform. Everything decidable **without**
    /// a write to the delivery platform is evaluated before this returns; everything else
    /// lands on the task. A refusal that applies to one asset does not fail the request:
    /// that asset is on the task already FAILED, with its reason, and the rest run. A refusal
    /// that applies to the whole request — a malformed list, an unknown campaign, another
    /// task already running on this campaign, this service's service-linked role being deleted
    /// (ConflictException `SERVICE_LINKED_ROLE_DELETION_IN_PROGRESS`), a campaign setting
    /// an asset in the request needs (ValidationException `CAMPAIGN_INCOMPLETE`), a campaign
    /// sender that no longer passes `CreateCampaign`'s sender rules while the request names
    /// an email (ValidationException with no `FieldList`, whose message ends with one `Reason:
    /// &lt;c&gt;` token per failed rule: `PATTERN_MISMATCH`, `SENDER_DOMAIN_NOT_ALLIANCE_LEAD`,
    /// or `SENDER_DOMAIN_DKIM_MISSING` and/or `SENDER_DOMAIN_DMARC_MISSING`) — is thrown,
    /// and nothing starts. One task runs on a campaign at a time. A second concurrent call
    /// is refused with ConflictException / CAMPAIGN_ACTIVATION_IN_PROGRESS, whose `ResourceId`
    /// names the task already holding the campaign. Two tasks over *disjoint* asset sets
    /// are refused too: the guard is deliberately campaign-wide, because overlapping runs
    /// made the per-asset status misleading rather than merely contended.
    /// </summary>
    [Cmdlet("Start", "PCMGCampaignAssetActivationTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralMarketing.Model.StartCampaignAssetActivationTaskResponse")]
    [AWSCmdlet("Calls the Partner Central Marketing API StartCampaignAssetActivationTask API operation.", Operation = new[] {"StartCampaignAssetActivationTask"}, SelectReturnType = typeof(Amazon.PartnerCentralMarketing.Model.StartCampaignAssetActivationTaskResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralMarketing.Model.StartCampaignAssetActivationTaskResponse",
        "This cmdlet returns an Amazon.PartnerCentralMarketing.Model.StartCampaignAssetActivationTaskResponse object containing multiple properties."
    )]
    public partial class StartPCMGCampaignAssetActivationTaskCmdlet : AmazonPartnerCentralMarketingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CampaignAssetIdentifier
        /// <summary>
        /// <para>
        /// The assets to activate, in any
        /// order — the service derives the dependency order and ignores the order given here.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("CampaignAssetIdentifiers")]
        public System.String[] CampaignAssetIdentifier { get; set; }
        #endregion
        
        #region Parameter CampaignIdentifier
        /// <summary>
        /// <para>
        /// The campaign identifier, which also
        /// authorizes the call.
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
        public System.String CampaignIdentifier { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// The catalog (AWS or Sandbox).
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralMarketing.Catalog")]
        public Amazon.PartnerCentralMarketing.Catalog Catalog { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// Idempotency token. Two requests carrying the
        /// same token are one request, and the second returns the first one's task rather than
        /// starting a second. The deduplication window is the **life of the task record**, not
        /// a fixed number of hours: replaying a token after the task has expired starts a new
        /// task. Stated because a caller would otherwise assume the usual few-hour guarantee.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralMarketing.Model.StartCampaignAssetActivationTaskResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralMarketing.Model.StartCampaignAssetActivationTaskResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-PCMGCampaignAssetActivationTask (StartCampaignAssetActivationTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralMarketing.Model.StartCampaignAssetActivationTaskResponse, StartPCMGCampaignAssetActivationTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CampaignAssetIdentifier != null)
            {
                context.CampaignAssetIdentifier = new List<System.String>(this.CampaignAssetIdentifier);
            }
            #if MODULAR
            if (this.CampaignAssetIdentifier == null && ParameterWasBound(nameof(this.CampaignAssetIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CampaignAssetIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CampaignIdentifier = this.CampaignIdentifier;
            #if MODULAR
            if (this.CampaignIdentifier == null && ParameterWasBound(nameof(this.CampaignIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CampaignIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            
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
            var request = new Amazon.PartnerCentralMarketing.Model.StartCampaignAssetActivationTaskRequest();
            
            if (cmdletContext.CampaignAssetIdentifier != null)
            {
                request.CampaignAssetIdentifiers = cmdletContext.CampaignAssetIdentifier;
            }
            if (cmdletContext.CampaignIdentifier != null)
            {
                request.CampaignIdentifier = cmdletContext.CampaignIdentifier;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
        
        private Amazon.PartnerCentralMarketing.Model.StartCampaignAssetActivationTaskResponse CallAWSServiceOperation(IAmazonPartnerCentralMarketing client, Amazon.PartnerCentralMarketing.Model.StartCampaignAssetActivationTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Marketing API", "StartCampaignAssetActivationTask");
            try
            {
                return client.StartCampaignAssetActivationTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> CampaignAssetIdentifier { get; set; }
            public System.String CampaignIdentifier { get; set; }
            public Amazon.PartnerCentralMarketing.Catalog Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public System.Func<Amazon.PartnerCentralMarketing.Model.StartCampaignAssetActivationTaskResponse, StartPCMGCampaignAssetActivationTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

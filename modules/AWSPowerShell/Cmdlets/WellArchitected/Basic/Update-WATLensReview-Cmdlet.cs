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
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// Update lens review for a particular workload.
    /// </summary>
    [Cmdlet("Update", "WATLensReview", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WellArchitected.Model.UpdateLensReviewResponse")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool UpdateLensReview API operation.", Operation = new[] {"UpdateLensReview"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.UpdateLensReviewResponse))]
    [AWSCmdletOutput("Amazon.WellArchitected.Model.UpdateLensReviewResponse",
        "This cmdlet returns an Amazon.WellArchitected.Model.UpdateLensReviewResponse object containing multiple properties."
    )]
    public partial class UpdateWATLensReviewCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LensAlias
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String LensAlias { get; set; }
        #endregion
        
        #region Parameter LensNote
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LensNotes")]
        public System.String LensNote { get; set; }
        #endregion
        
        #region Parameter PillarNote
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PillarNotes")]
        public System.Collections.Hashtable PillarNote { get; set; }
        #endregion
        
        #region Parameter JiraConfiguration_SelectedPillar
        /// <summary>
        /// <para>
        /// <para>Selected pillars in the workload.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JiraConfiguration_SelectedPillars")]
        public Amazon.WellArchitected.Model.SelectedPillar[] JiraConfiguration_SelectedPillar { get; set; }
        #endregion
        
        #region Parameter WorkloadId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String WorkloadId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.UpdateLensReviewResponse).
        /// Specifying the name of a property of type Amazon.WellArchitected.Model.UpdateLensReviewResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkloadId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WATLensReview (UpdateLensReview)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.UpdateLensReviewResponse, UpdateWATLensReviewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.JiraConfiguration_SelectedPillar != null)
            {
                context.JiraConfiguration_SelectedPillar = new List<Amazon.WellArchitected.Model.SelectedPillar>(this.JiraConfiguration_SelectedPillar);
            }
            context.LensAlias = this.LensAlias;
            #if MODULAR
            if (this.LensAlias == null && ParameterWasBound(nameof(this.LensAlias)))
            {
                WriteWarning("You are passing $null as a value for parameter LensAlias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LensNote = this.LensNote;
            if (this.PillarNote != null)
            {
                context.PillarNote = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.PillarNote.Keys)
                {
                    context.PillarNote.Add((String)hashKey, (System.String)(this.PillarNote[hashKey]));
                }
            }
            context.WorkloadId = this.WorkloadId;
            #if MODULAR
            if (this.WorkloadId == null && ParameterWasBound(nameof(this.WorkloadId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkloadId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WellArchitected.Model.UpdateLensReviewRequest();
            
            
             // populate JiraConfiguration
            var requestJiraConfigurationIsNull = true;
            request.JiraConfiguration = new Amazon.WellArchitected.Model.JiraSelectedQuestionConfiguration();
            List<Amazon.WellArchitected.Model.SelectedPillar> requestJiraConfiguration_jiraConfiguration_SelectedPillar = null;
            if (cmdletContext.JiraConfiguration_SelectedPillar != null)
            {
                requestJiraConfiguration_jiraConfiguration_SelectedPillar = cmdletContext.JiraConfiguration_SelectedPillar;
            }
            if (requestJiraConfiguration_jiraConfiguration_SelectedPillar != null)
            {
                request.JiraConfiguration.SelectedPillars = requestJiraConfiguration_jiraConfiguration_SelectedPillar;
                requestJiraConfigurationIsNull = false;
            }
             // determine if request.JiraConfiguration should be set to null
            if (requestJiraConfigurationIsNull)
            {
                request.JiraConfiguration = null;
            }
            if (cmdletContext.LensAlias != null)
            {
                request.LensAlias = cmdletContext.LensAlias;
            }
            if (cmdletContext.LensNote != null)
            {
                request.LensNotes = cmdletContext.LensNote;
            }
            if (cmdletContext.PillarNote != null)
            {
                request.PillarNotes = cmdletContext.PillarNote;
            }
            if (cmdletContext.WorkloadId != null)
            {
                request.WorkloadId = cmdletContext.WorkloadId;
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
        
        private Amazon.WellArchitected.Model.UpdateLensReviewResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.UpdateLensReviewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "UpdateLensReview");
            try
            {
                return client.UpdateLensReviewAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.WellArchitected.Model.SelectedPillar> JiraConfiguration_SelectedPillar { get; set; }
            public System.String LensAlias { get; set; }
            public System.String LensNote { get; set; }
            public Dictionary<System.String, System.String> PillarNote { get; set; }
            public System.String WorkloadId { get; set; }
            public System.Func<Amazon.WellArchitected.Model.UpdateLensReviewResponse, UpdateWATLensReviewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

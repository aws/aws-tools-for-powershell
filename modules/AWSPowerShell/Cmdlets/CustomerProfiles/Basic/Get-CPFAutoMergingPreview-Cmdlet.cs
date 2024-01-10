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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Tests the auto-merging settings of your Identity Resolution Job without merging your
    /// data. It randomly selects a sample of matching groups from the existing matching results,
    /// and applies the automerging settings that you provided. You can then view the number
    /// of profiles in the sample, the number of matches, and the number of profiles identified
    /// to be merged. This enables you to evaluate the accuracy of the attributes in your
    /// matching list. 
    /// 
    ///  
    /// <para>
    /// You can't view which profiles are matched and would be merged.
    /// </para><important><para>
    /// We strongly recommend you use this API to do a dry run of the automerging process
    /// before running the Identity Resolution Job. Include <b>at least</b> two matching attributes.
    /// If your matching list includes too few attributes (such as only <c>FirstName</c> or
    /// only <c>LastName</c>), there may be a large number of matches. This increases the
    /// chances of erroneous merges.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "CPFAutoMergingPreview")]
    [OutputType("Amazon.CustomerProfiles.Model.GetAutoMergingPreviewResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles GetAutoMergingPreview API operation.", Operation = new[] {"GetAutoMergingPreview"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.GetAutoMergingPreviewResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.GetAutoMergingPreviewResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.GetAutoMergingPreviewResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCPFAutoMergingPreviewCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConflictResolution_ConflictResolvingModel
        /// <summary>
        /// <para>
        /// <para>How the auto-merging process should resolve conflicts between different profiles.</para><ul><li><para><c>RECENCY</c>: Uses the data that was most recently updated.</para></li><li><para><c>SOURCE</c>: Uses the data from a specific source. For example, if a company has
        /// been aquired or two departments have merged, data from the specified source is used.
        /// If two duplicate profiles are from the same source, then <c>RECENCY</c> is used again.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CustomerProfiles.ConflictResolvingModel")]
        public Amazon.CustomerProfiles.ConflictResolvingModel ConflictResolution_ConflictResolvingModel { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The unique name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter Consolidation_MatchingAttributesList
        /// <summary>
        /// <para>
        /// <para>A list of matching criteria.</para>
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
        public System.String[][] Consolidation_MatchingAttributesList { get; set; }
        #endregion
        
        #region Parameter MinAllowedConfidenceScoreForMerging
        /// <summary>
        /// <para>
        /// <para>Minimum confidence score required for profiles within a matching group to be merged
        /// during the auto-merge process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? MinAllowedConfidenceScoreForMerging { get; set; }
        #endregion
        
        #region Parameter ConflictResolution_SourceName
        /// <summary>
        /// <para>
        /// <para>The <c>ObjectType</c> name that is used to resolve profile merging conflicts when
        /// choosing <c>SOURCE</c> as the <c>ConflictResolvingModel</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConflictResolution_SourceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.GetAutoMergingPreviewResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.GetAutoMergingPreviewResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.GetAutoMergingPreviewResponse, GetCPFAutoMergingPreviewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConflictResolution_ConflictResolvingModel = this.ConflictResolution_ConflictResolvingModel;
            #if MODULAR
            if (this.ConflictResolution_ConflictResolvingModel == null && ParameterWasBound(nameof(this.ConflictResolution_ConflictResolvingModel)))
            {
                WriteWarning("You are passing $null as a value for parameter ConflictResolution_ConflictResolvingModel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConflictResolution_SourceName = this.ConflictResolution_SourceName;
            if (this.Consolidation_MatchingAttributesList != null)
            {
                context.Consolidation_MatchingAttributesList = new List<List<System.String>>();
                foreach (var innerList in this.Consolidation_MatchingAttributesList)
                {
                    context.Consolidation_MatchingAttributesList.Add(new List<System.String>(innerList));
                }
            }
            #if MODULAR
            if (this.Consolidation_MatchingAttributesList == null && ParameterWasBound(nameof(this.Consolidation_MatchingAttributesList)))
            {
                WriteWarning("You are passing $null as a value for parameter Consolidation_MatchingAttributesList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinAllowedConfidenceScoreForMerging = this.MinAllowedConfidenceScoreForMerging;
            
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
            var request = new Amazon.CustomerProfiles.Model.GetAutoMergingPreviewRequest();
            
            
             // populate ConflictResolution
            var requestConflictResolutionIsNull = true;
            request.ConflictResolution = new Amazon.CustomerProfiles.Model.ConflictResolution();
            Amazon.CustomerProfiles.ConflictResolvingModel requestConflictResolution_conflictResolution_ConflictResolvingModel = null;
            if (cmdletContext.ConflictResolution_ConflictResolvingModel != null)
            {
                requestConflictResolution_conflictResolution_ConflictResolvingModel = cmdletContext.ConflictResolution_ConflictResolvingModel;
            }
            if (requestConflictResolution_conflictResolution_ConflictResolvingModel != null)
            {
                request.ConflictResolution.ConflictResolvingModel = requestConflictResolution_conflictResolution_ConflictResolvingModel;
                requestConflictResolutionIsNull = false;
            }
            System.String requestConflictResolution_conflictResolution_SourceName = null;
            if (cmdletContext.ConflictResolution_SourceName != null)
            {
                requestConflictResolution_conflictResolution_SourceName = cmdletContext.ConflictResolution_SourceName;
            }
            if (requestConflictResolution_conflictResolution_SourceName != null)
            {
                request.ConflictResolution.SourceName = requestConflictResolution_conflictResolution_SourceName;
                requestConflictResolutionIsNull = false;
            }
             // determine if request.ConflictResolution should be set to null
            if (requestConflictResolutionIsNull)
            {
                request.ConflictResolution = null;
            }
            
             // populate Consolidation
            var requestConsolidationIsNull = true;
            request.Consolidation = new Amazon.CustomerProfiles.Model.Consolidation();
            List<List<System.String>> requestConsolidation_consolidation_MatchingAttributesList = null;
            if (cmdletContext.Consolidation_MatchingAttributesList != null)
            {
                requestConsolidation_consolidation_MatchingAttributesList = cmdletContext.Consolidation_MatchingAttributesList;
            }
            if (requestConsolidation_consolidation_MatchingAttributesList != null)
            {
                request.Consolidation.MatchingAttributesList = requestConsolidation_consolidation_MatchingAttributesList;
                requestConsolidationIsNull = false;
            }
             // determine if request.Consolidation should be set to null
            if (requestConsolidationIsNull)
            {
                request.Consolidation = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.MinAllowedConfidenceScoreForMerging != null)
            {
                request.MinAllowedConfidenceScoreForMerging = cmdletContext.MinAllowedConfidenceScoreForMerging.Value;
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
        
        private Amazon.CustomerProfiles.Model.GetAutoMergingPreviewResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.GetAutoMergingPreviewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "GetAutoMergingPreview");
            try
            {
                #if DESKTOP
                return client.GetAutoMergingPreview(request);
                #elif CORECLR
                return client.GetAutoMergingPreviewAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CustomerProfiles.ConflictResolvingModel ConflictResolution_ConflictResolvingModel { get; set; }
            public System.String ConflictResolution_SourceName { get; set; }
            public List<List<System.String>> Consolidation_MatchingAttributesList { get; set; }
            public System.String DomainName { get; set; }
            public System.Double? MinAllowedConfidenceScoreForMerging { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.GetAutoMergingPreviewResponse, GetCPFAutoMergingPreviewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

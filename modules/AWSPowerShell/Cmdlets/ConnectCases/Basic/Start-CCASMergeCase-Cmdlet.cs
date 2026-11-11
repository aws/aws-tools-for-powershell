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
using Amazon.ConnectCases;
using Amazon.ConnectCases.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCAS
{
    /// <summary>
    /// Merges a secondary case into a primary case. The primary case, which you specify in
    /// the request URI, remains active. Both cases must belong to the same domain.
    /// 
    ///  
    /// <para>
    /// The merge runs asynchronously. To track its progress, call <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_connect-cases_GetMergeCasesStatus.html">GetMergeCasesStatus</a>.
    /// When the merge finishes, the selected field values and related items from the secondary
    /// case are on the primary case, the two cases are linked, and the secondary case is
    /// closed. Both cases record the merge in their audit history. For more information,
    /// see <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_connect-cases_GetCaseAuditEvents.html">GetCaseAuditEvents</a>.
    /// </para><para><b>Important things to know</b></para><ul><li><para>
    /// Both cases must have the same customer, or at least one of them must have no customer.
    /// </para></li><li><para>
    /// While the merge runs, you can't modify the secondary case or its related items, and
    /// you can't delete the primary case. These requests return a <c>ConflictException</c>.
    /// </para></li><li><para>
    /// After the merge, the secondary case can be reopened, updated, and deleted, but it
    /// can't be merged again.
    /// </para></li></ul><para>
    /// The request fails with a <c>ValidationException</c>, and no merge starts, if:
    /// </para><ul><li><para>
    /// The primary case and the secondary case are the same case.
    /// </para></li><li><para>
    /// Either case is closed.
    /// </para></li><li><para>
    /// Both cases have a customer, and the customers are different.
    /// </para></li><li><para><c>fieldsConfiguration</c> selects a field that can't be merged, or a field that
    /// the secondary case doesn't have.
    /// </para></li><li><para>
    /// After the merge, the primary case would have more than 500 field values, or would
    /// exceed the maximum case size.
    /// </para></li></ul><para>
    /// The request fails with a <c>ServiceQuotaExceededException</c> if, after the merge,
    /// either case would exceed the quota for related items per case. For the primary case,
    /// the count is its existing related items, plus the related items moved from the secondary
    /// case, plus the new case link. See <a href="https://docs.aws.amazon.com/connect/latest/adminguide/amazon-connect-service-limits.html#cases-quotas">Connect
    /// Customer Cases quotas</a>.
    /// </para><para>
    /// The request fails with a <c>ConflictException</c> if either case is already part of
    /// a merge that is running, or was previously merged into another case as the secondary
    /// case.
    /// </para><para><b>Endpoints</b>: See <a href="https://docs.aws.amazon.com/general/latest/gr/connect_region.html">Connect
    /// Customer endpoints and quotas</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CCASMergeCase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Cases StartMergeCases API operation.", Operation = new[] {"StartMergeCases"}, SelectReturnType = typeof(Amazon.ConnectCases.Model.StartMergeCasesResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectCases.Model.StartMergeCasesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectCases.Model.StartMergeCasesResponse) be returned by specifying '-Select *'."
    )]
    public partial class StartCCASMergeCaseCmdlet : AmazonConnectCasesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the primary case. The primary case remains active and receives
        /// the merged field values and related items. The cases can use different templates,
        /// and the primary case keeps its template.</para>
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
        public System.String CaseId { get; set; }
        #endregion
        
        #region Parameter RelatedItemsConfiguration_Comment
        /// <summary>
        /// <para>
        /// <para>Whether to move Comment related items to the primary case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RelatedItemsConfiguration_Comment { get; set; }
        #endregion
        
        #region Parameter RelatedItemsConfiguration_ConnectCase
        /// <summary>
        /// <para>
        /// <para>Whether to move Case related items to the primary case. If the primary case already
        /// links to the same case, the secondary case's link is removed instead of moved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RelatedItemsConfiguration_ConnectCase { get; set; }
        #endregion
        
        #region Parameter RelatedItemsConfiguration_Contact
        /// <summary>
        /// <para>
        /// <para>Whether to move Contact related items to the primary case. If the same contact is
        /// related to both cases, the primary case keeps its related item and gets any tag keys
        /// that only the secondary case's related item has.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RelatedItemsConfiguration_Contact { get; set; }
        #endregion
        
        #region Parameter RelatedItemsConfiguration_Custom
        /// <summary>
        /// <para>
        /// <para>Whether to move Custom related items to the primary case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RelatedItemsConfiguration_Custom { get; set; }
        #endregion
        
        #region Parameter PerformedBy_CustomEntity
        /// <summary>
        /// <para>
        /// <para>Any provided entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformedBy_CustomEntity { get; set; }
        #endregion
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Cases domain. </para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter FieldsConfiguration
        /// <summary>
        /// <para>
        /// <para>The fields whose values to take from the secondary case. You can only merge custom
        /// fields and the following system fields: <c>assigned_queue</c>, <c>assigned_user</c>,
        /// <c>summary</c>, and <c>case_reason</c>. If you select any other system field, the
        /// request fails with a <c>ValidationException</c>.</para><para>For each field that can be merged, the merge works as follows:</para><ul><li><para>If you select the field, the primary case gets the secondary case's value. If the
        /// secondary case's value is empty, the primary case's value is cleared.</para></li><li><para>If you don't select the field and the primary case has a value for it, the primary
        /// case keeps its value.</para></li><li><para>If you don't select the field and the primary case doesn't have the field, or its
        /// value is empty, the primary case gets the secondary case's value. This applies even
        /// when the field isn't on the primary case's template.</para></li></ul><para>Field values are read from both cases when the merge runs, so changes that you make
        /// to the primary case after you start the merge are taken into account.</para><para>Specify at most one entry, and set its <c>sourceCaseId</c> to the secondary case ID.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ConnectCases.Model.FieldsConfiguration[] FieldsConfiguration { get; set; }
        #endregion
        
        #region Parameter SecondaryCaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the secondary case to merge into the primary case. The secondary
        /// case is closed when the merge finishes. Specify exactly one case ID.</para><para />
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
        [Alias("SecondaryCaseIds")]
        public System.String[] SecondaryCaseId { get; set; }
        #endregion
        
        #region Parameter PerformedBy_UserArn
        /// <summary>
        /// <para>
        /// <para>Represents the Connect Customer ARN of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformedBy_UserArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCases.Model.StartMergeCasesResponse).
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.CaseId),
                nameof(this.DomainId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CCASMergeCase (StartMergeCases)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCases.Model.StartMergeCasesResponse, StartCCASMergeCaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CaseId = this.CaseId;
            #if MODULAR
            if (this.CaseId == null && ParameterWasBound(nameof(this.CaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter CaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FieldsConfiguration != null)
            {
                context.FieldsConfiguration = new List<Amazon.ConnectCases.Model.FieldsConfiguration>(this.FieldsConfiguration);
            }
            context.PerformedBy_CustomEntity = this.PerformedBy_CustomEntity;
            context.PerformedBy_UserArn = this.PerformedBy_UserArn;
            context.RelatedItemsConfiguration_Comment = this.RelatedItemsConfiguration_Comment;
            context.RelatedItemsConfiguration_ConnectCase = this.RelatedItemsConfiguration_ConnectCase;
            context.RelatedItemsConfiguration_Contact = this.RelatedItemsConfiguration_Contact;
            context.RelatedItemsConfiguration_Custom = this.RelatedItemsConfiguration_Custom;
            if (this.SecondaryCaseId != null)
            {
                context.SecondaryCaseId = new List<System.String>(this.SecondaryCaseId);
            }
            #if MODULAR
            if (this.SecondaryCaseId == null && ParameterWasBound(nameof(this.SecondaryCaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecondaryCaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectCases.Model.StartMergeCasesRequest();
            
            if (cmdletContext.CaseId != null)
            {
                request.CaseId = cmdletContext.CaseId;
            }
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            if (cmdletContext.FieldsConfiguration != null)
            {
                request.FieldsConfiguration = cmdletContext.FieldsConfiguration;
            }
            
             // populate PerformedBy
            var requestPerformedByIsNull = true;
            request.PerformedBy = new Amazon.ConnectCases.Model.UserUnion();
            System.String requestPerformedBy_performedBy_CustomEntity = null;
            if (cmdletContext.PerformedBy_CustomEntity != null)
            {
                requestPerformedBy_performedBy_CustomEntity = cmdletContext.PerformedBy_CustomEntity;
            }
            if (requestPerformedBy_performedBy_CustomEntity != null)
            {
                request.PerformedBy.CustomEntity = requestPerformedBy_performedBy_CustomEntity;
                requestPerformedByIsNull = false;
            }
            System.String requestPerformedBy_performedBy_UserArn = null;
            if (cmdletContext.PerformedBy_UserArn != null)
            {
                requestPerformedBy_performedBy_UserArn = cmdletContext.PerformedBy_UserArn;
            }
            if (requestPerformedBy_performedBy_UserArn != null)
            {
                request.PerformedBy.UserArn = requestPerformedBy_performedBy_UserArn;
                requestPerformedByIsNull = false;
            }
             // determine if request.PerformedBy should be set to null
            if (requestPerformedByIsNull)
            {
                request.PerformedBy = null;
            }
            
             // populate RelatedItemsConfiguration
            var requestRelatedItemsConfigurationIsNull = true;
            request.RelatedItemsConfiguration = new Amazon.ConnectCases.Model.RelatedItemsConfiguration();
            System.Boolean? requestRelatedItemsConfiguration_relatedItemsConfiguration_Comment = null;
            if (cmdletContext.RelatedItemsConfiguration_Comment != null)
            {
                requestRelatedItemsConfiguration_relatedItemsConfiguration_Comment = cmdletContext.RelatedItemsConfiguration_Comment.Value;
            }
            if (requestRelatedItemsConfiguration_relatedItemsConfiguration_Comment != null)
            {
                request.RelatedItemsConfiguration.Comment = requestRelatedItemsConfiguration_relatedItemsConfiguration_Comment.Value;
                requestRelatedItemsConfigurationIsNull = false;
            }
            System.Boolean? requestRelatedItemsConfiguration_relatedItemsConfiguration_ConnectCase = null;
            if (cmdletContext.RelatedItemsConfiguration_ConnectCase != null)
            {
                requestRelatedItemsConfiguration_relatedItemsConfiguration_ConnectCase = cmdletContext.RelatedItemsConfiguration_ConnectCase.Value;
            }
            if (requestRelatedItemsConfiguration_relatedItemsConfiguration_ConnectCase != null)
            {
                request.RelatedItemsConfiguration.ConnectCase = requestRelatedItemsConfiguration_relatedItemsConfiguration_ConnectCase.Value;
                requestRelatedItemsConfigurationIsNull = false;
            }
            System.Boolean? requestRelatedItemsConfiguration_relatedItemsConfiguration_Contact = null;
            if (cmdletContext.RelatedItemsConfiguration_Contact != null)
            {
                requestRelatedItemsConfiguration_relatedItemsConfiguration_Contact = cmdletContext.RelatedItemsConfiguration_Contact.Value;
            }
            if (requestRelatedItemsConfiguration_relatedItemsConfiguration_Contact != null)
            {
                request.RelatedItemsConfiguration.Contact = requestRelatedItemsConfiguration_relatedItemsConfiguration_Contact.Value;
                requestRelatedItemsConfigurationIsNull = false;
            }
            System.Boolean? requestRelatedItemsConfiguration_relatedItemsConfiguration_Custom = null;
            if (cmdletContext.RelatedItemsConfiguration_Custom != null)
            {
                requestRelatedItemsConfiguration_relatedItemsConfiguration_Custom = cmdletContext.RelatedItemsConfiguration_Custom.Value;
            }
            if (requestRelatedItemsConfiguration_relatedItemsConfiguration_Custom != null)
            {
                request.RelatedItemsConfiguration.Custom = requestRelatedItemsConfiguration_relatedItemsConfiguration_Custom.Value;
                requestRelatedItemsConfigurationIsNull = false;
            }
             // determine if request.RelatedItemsConfiguration should be set to null
            if (requestRelatedItemsConfigurationIsNull)
            {
                request.RelatedItemsConfiguration = null;
            }
            if (cmdletContext.SecondaryCaseId != null)
            {
                request.SecondaryCaseIds = cmdletContext.SecondaryCaseId;
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
        
        private Amazon.ConnectCases.Model.StartMergeCasesResponse CallAWSServiceOperation(IAmazonConnectCases client, Amazon.ConnectCases.Model.StartMergeCasesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Cases", "StartMergeCases");
            try
            {
                return client.StartMergeCasesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CaseId { get; set; }
            public System.String DomainId { get; set; }
            public List<Amazon.ConnectCases.Model.FieldsConfiguration> FieldsConfiguration { get; set; }
            public System.String PerformedBy_CustomEntity { get; set; }
            public System.String PerformedBy_UserArn { get; set; }
            public System.Boolean? RelatedItemsConfiguration_Comment { get; set; }
            public System.Boolean? RelatedItemsConfiguration_ConnectCase { get; set; }
            public System.Boolean? RelatedItemsConfiguration_Contact { get; set; }
            public System.Boolean? RelatedItemsConfiguration_Custom { get; set; }
            public List<System.String> SecondaryCaseId { get; set; }
            public System.Func<Amazon.ConnectCases.Model.StartMergeCasesResponse, StartCCASMergeCaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

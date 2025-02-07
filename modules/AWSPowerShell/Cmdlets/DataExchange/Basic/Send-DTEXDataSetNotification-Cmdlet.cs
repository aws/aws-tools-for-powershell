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
using Amazon.DataExchange;
using Amazon.DataExchange.Model;

namespace Amazon.PowerShell.Cmdlets.DTEX
{
    /// <summary>
    /// The type of event associated with the data set.
    /// </summary>
    [Cmdlet("Send", "DTEXDataSetNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Data Exchange SendDataSetNotification API operation.", Operation = new[] {"SendDataSetNotification"}, SelectReturnType = typeof(Amazon.DataExchange.Model.SendDataSetNotificationResponse))]
    [AWSCmdletOutput("None or Amazon.DataExchange.Model.SendDataSetNotificationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DataExchange.Model.SendDataSetNotificationResponse) be returned by specifying '-Select *'."
    )]
    public partial class SendDTEXDataSetNotificationCmdlet : AmazonDataExchangeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SchemaChange_Change
        /// <summary>
        /// <para>
        /// <para>List of schema changes happening in the scope of this notification. This can have
        /// up to 100 entries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_SchemaChange_Changes")]
        public Amazon.DataExchange.Model.SchemaChangeDetails[] SchemaChange_Change { get; set; }
        #endregion
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>Free-form text field for providers to add information about their notifications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter DataSetId
        /// <summary>
        /// <para>
        /// <para>Affected data set of the notification.</para>
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
        public System.String DataSetId { get; set; }
        #endregion
        
        #region Parameter DataUpdate_DataUpdatedAt
        /// <summary>
        /// <para>
        /// <para>A datetime in the past when the data was updated. This typically means that the underlying
        /// resource supporting the data set was updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_DataUpdate_DataUpdatedAt")]
        public System.DateTime? DataUpdate_DataUpdatedAt { get; set; }
        #endregion
        
        #region Parameter Deprecation_DeprecationAt
        /// <summary>
        /// <para>
        /// <para>A datetime in the future when the data set will be deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_Deprecation_DeprecationAt")]
        public System.DateTime? Deprecation_DeprecationAt { get; set; }
        #endregion
        
        #region Parameter Scope_LakeFormationTagPolicy
        /// <summary>
        /// <para>
        /// <para>Underlying LF resources that will be affected by this notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scope_LakeFormationTagPolicies")]
        public Amazon.DataExchange.Model.LakeFormationTagPolicyDetails[] Scope_LakeFormationTagPolicy { get; set; }
        #endregion
        
        #region Parameter Scope_RedshiftDataShare
        /// <summary>
        /// <para>
        /// <para>Underlying Redshift resources that will be affected by this notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scope_RedshiftDataShares")]
        public Amazon.DataExchange.Model.RedshiftDataShareDetails[] Scope_RedshiftDataShare { get; set; }
        #endregion
        
        #region Parameter Scope_S3DataAccess
        /// <summary>
        /// <para>
        /// <para>Underlying S3 resources that will be affected by this notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scope_S3DataAccesses")]
        public Amazon.DataExchange.Model.S3DataAccessDetails[] Scope_S3DataAccess { get; set; }
        #endregion
        
        #region Parameter SchemaChange_SchemaChangeAt
        /// <summary>
        /// <para>
        /// <para>A date in the future when the schema change is taking effect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_SchemaChange_SchemaChangeAt")]
        public System.DateTime? SchemaChange_SchemaChangeAt { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the notification. Describing the kind of event the notification is alerting
        /// you to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DataExchange.NotificationType")]
        public Amazon.DataExchange.NotificationType Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency key for the notification, this key allows us to deduplicate notifications
        /// that are sent in quick succession erroneously.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataExchange.Model.SendDataSetNotificationResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-DTEXDataSetNotification (SendDataSetNotification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataExchange.Model.SendDataSetNotificationResponse, SendDTEXDataSetNotificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Comment = this.Comment;
            context.DataSetId = this.DataSetId;
            #if MODULAR
            if (this.DataSetId == null && ParameterWasBound(nameof(this.DataSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataUpdate_DataUpdatedAt = this.DataUpdate_DataUpdatedAt;
            context.Deprecation_DeprecationAt = this.Deprecation_DeprecationAt;
            if (this.SchemaChange_Change != null)
            {
                context.SchemaChange_Change = new List<Amazon.DataExchange.Model.SchemaChangeDetails>(this.SchemaChange_Change);
            }
            context.SchemaChange_SchemaChangeAt = this.SchemaChange_SchemaChangeAt;
            if (this.Scope_LakeFormationTagPolicy != null)
            {
                context.Scope_LakeFormationTagPolicy = new List<Amazon.DataExchange.Model.LakeFormationTagPolicyDetails>(this.Scope_LakeFormationTagPolicy);
            }
            if (this.Scope_RedshiftDataShare != null)
            {
                context.Scope_RedshiftDataShare = new List<Amazon.DataExchange.Model.RedshiftDataShareDetails>(this.Scope_RedshiftDataShare);
            }
            if (this.Scope_S3DataAccess != null)
            {
                context.Scope_S3DataAccess = new List<Amazon.DataExchange.Model.S3DataAccessDetails>(this.Scope_S3DataAccess);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataExchange.Model.SendDataSetNotificationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.DataSetId != null)
            {
                request.DataSetId = cmdletContext.DataSetId;
            }
            
             // populate Details
            var requestDetailsIsNull = true;
            request.Details = new Amazon.DataExchange.Model.NotificationDetails();
            Amazon.DataExchange.Model.DataUpdateRequestDetails requestDetails_details_DataUpdate = null;
            
             // populate DataUpdate
            var requestDetails_details_DataUpdateIsNull = true;
            requestDetails_details_DataUpdate = new Amazon.DataExchange.Model.DataUpdateRequestDetails();
            System.DateTime? requestDetails_details_DataUpdate_dataUpdate_DataUpdatedAt = null;
            if (cmdletContext.DataUpdate_DataUpdatedAt != null)
            {
                requestDetails_details_DataUpdate_dataUpdate_DataUpdatedAt = cmdletContext.DataUpdate_DataUpdatedAt.Value;
            }
            if (requestDetails_details_DataUpdate_dataUpdate_DataUpdatedAt != null)
            {
                requestDetails_details_DataUpdate.DataUpdatedAt = requestDetails_details_DataUpdate_dataUpdate_DataUpdatedAt.Value;
                requestDetails_details_DataUpdateIsNull = false;
            }
             // determine if requestDetails_details_DataUpdate should be set to null
            if (requestDetails_details_DataUpdateIsNull)
            {
                requestDetails_details_DataUpdate = null;
            }
            if (requestDetails_details_DataUpdate != null)
            {
                request.Details.DataUpdate = requestDetails_details_DataUpdate;
                requestDetailsIsNull = false;
            }
            Amazon.DataExchange.Model.DeprecationRequestDetails requestDetails_details_Deprecation = null;
            
             // populate Deprecation
            var requestDetails_details_DeprecationIsNull = true;
            requestDetails_details_Deprecation = new Amazon.DataExchange.Model.DeprecationRequestDetails();
            System.DateTime? requestDetails_details_Deprecation_deprecation_DeprecationAt = null;
            if (cmdletContext.Deprecation_DeprecationAt != null)
            {
                requestDetails_details_Deprecation_deprecation_DeprecationAt = cmdletContext.Deprecation_DeprecationAt.Value;
            }
            if (requestDetails_details_Deprecation_deprecation_DeprecationAt != null)
            {
                requestDetails_details_Deprecation.DeprecationAt = requestDetails_details_Deprecation_deprecation_DeprecationAt.Value;
                requestDetails_details_DeprecationIsNull = false;
            }
             // determine if requestDetails_details_Deprecation should be set to null
            if (requestDetails_details_DeprecationIsNull)
            {
                requestDetails_details_Deprecation = null;
            }
            if (requestDetails_details_Deprecation != null)
            {
                request.Details.Deprecation = requestDetails_details_Deprecation;
                requestDetailsIsNull = false;
            }
            Amazon.DataExchange.Model.SchemaChangeRequestDetails requestDetails_details_SchemaChange = null;
            
             // populate SchemaChange
            var requestDetails_details_SchemaChangeIsNull = true;
            requestDetails_details_SchemaChange = new Amazon.DataExchange.Model.SchemaChangeRequestDetails();
            List<Amazon.DataExchange.Model.SchemaChangeDetails> requestDetails_details_SchemaChange_schemaChange_Change = null;
            if (cmdletContext.SchemaChange_Change != null)
            {
                requestDetails_details_SchemaChange_schemaChange_Change = cmdletContext.SchemaChange_Change;
            }
            if (requestDetails_details_SchemaChange_schemaChange_Change != null)
            {
                requestDetails_details_SchemaChange.Changes = requestDetails_details_SchemaChange_schemaChange_Change;
                requestDetails_details_SchemaChangeIsNull = false;
            }
            System.DateTime? requestDetails_details_SchemaChange_schemaChange_SchemaChangeAt = null;
            if (cmdletContext.SchemaChange_SchemaChangeAt != null)
            {
                requestDetails_details_SchemaChange_schemaChange_SchemaChangeAt = cmdletContext.SchemaChange_SchemaChangeAt.Value;
            }
            if (requestDetails_details_SchemaChange_schemaChange_SchemaChangeAt != null)
            {
                requestDetails_details_SchemaChange.SchemaChangeAt = requestDetails_details_SchemaChange_schemaChange_SchemaChangeAt.Value;
                requestDetails_details_SchemaChangeIsNull = false;
            }
             // determine if requestDetails_details_SchemaChange should be set to null
            if (requestDetails_details_SchemaChangeIsNull)
            {
                requestDetails_details_SchemaChange = null;
            }
            if (requestDetails_details_SchemaChange != null)
            {
                request.Details.SchemaChange = requestDetails_details_SchemaChange;
                requestDetailsIsNull = false;
            }
             // determine if request.Details should be set to null
            if (requestDetailsIsNull)
            {
                request.Details = null;
            }
            
             // populate Scope
            var requestScopeIsNull = true;
            request.Scope = new Amazon.DataExchange.Model.ScopeDetails();
            List<Amazon.DataExchange.Model.LakeFormationTagPolicyDetails> requestScope_scope_LakeFormationTagPolicy = null;
            if (cmdletContext.Scope_LakeFormationTagPolicy != null)
            {
                requestScope_scope_LakeFormationTagPolicy = cmdletContext.Scope_LakeFormationTagPolicy;
            }
            if (requestScope_scope_LakeFormationTagPolicy != null)
            {
                request.Scope.LakeFormationTagPolicies = requestScope_scope_LakeFormationTagPolicy;
                requestScopeIsNull = false;
            }
            List<Amazon.DataExchange.Model.RedshiftDataShareDetails> requestScope_scope_RedshiftDataShare = null;
            if (cmdletContext.Scope_RedshiftDataShare != null)
            {
                requestScope_scope_RedshiftDataShare = cmdletContext.Scope_RedshiftDataShare;
            }
            if (requestScope_scope_RedshiftDataShare != null)
            {
                request.Scope.RedshiftDataShares = requestScope_scope_RedshiftDataShare;
                requestScopeIsNull = false;
            }
            List<Amazon.DataExchange.Model.S3DataAccessDetails> requestScope_scope_S3DataAccess = null;
            if (cmdletContext.Scope_S3DataAccess != null)
            {
                requestScope_scope_S3DataAccess = cmdletContext.Scope_S3DataAccess;
            }
            if (requestScope_scope_S3DataAccess != null)
            {
                request.Scope.S3DataAccesses = requestScope_scope_S3DataAccess;
                requestScopeIsNull = false;
            }
             // determine if request.Scope should be set to null
            if (requestScopeIsNull)
            {
                request.Scope = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.DataExchange.Model.SendDataSetNotificationResponse CallAWSServiceOperation(IAmazonDataExchange client, Amazon.DataExchange.Model.SendDataSetNotificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Exchange", "SendDataSetNotification");
            try
            {
                #if DESKTOP
                return client.SendDataSetNotification(request);
                #elif CORECLR
                return client.SendDataSetNotificationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Comment { get; set; }
            public System.String DataSetId { get; set; }
            public System.DateTime? DataUpdate_DataUpdatedAt { get; set; }
            public System.DateTime? Deprecation_DeprecationAt { get; set; }
            public List<Amazon.DataExchange.Model.SchemaChangeDetails> SchemaChange_Change { get; set; }
            public System.DateTime? SchemaChange_SchemaChangeAt { get; set; }
            public List<Amazon.DataExchange.Model.LakeFormationTagPolicyDetails> Scope_LakeFormationTagPolicy { get; set; }
            public List<Amazon.DataExchange.Model.RedshiftDataShareDetails> Scope_RedshiftDataShare { get; set; }
            public List<Amazon.DataExchange.Model.S3DataAccessDetails> Scope_S3DataAccess { get; set; }
            public Amazon.DataExchange.NotificationType Type { get; set; }
            public System.Func<Amazon.DataExchange.Model.SendDataSetNotificationResponse, SendDTEXDataSetNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

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
using Amazon.SecurityIR;
using Amazon.SecurityIR.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SecurityIR
{
    /// <summary>
    /// Updates membership configuration.
    /// </summary>
    [Cmdlet("Update", "SecurityIRMembership", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Security Incident Response UpdateMembership API operation.", Operation = new[] {"UpdateMembership"}, SelectReturnType = typeof(Amazon.SecurityIR.Model.UpdateMembershipResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityIR.Model.UpdateMembershipResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityIR.Model.UpdateMembershipResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSecurityIRMembershipCmdlet : AmazonSecurityIRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MembershipAccountsConfigurationsUpdate_CoverEntireOrganization
        /// <summary>
        /// <para>
        /// <para>The <c>coverEntireOrganization</c> field is a boolean value that determines whether
        /// the membership configuration should be applied across the entire Amazon Web Services
        /// Organization. </para><para>When set to <c>true</c>, the configuration will be applied to all accounts within
        /// the organization. When set to <c>false</c>, the configuration will only apply to specifically
        /// designated accounts. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MembershipAccountsConfigurationsUpdate_CoverEntireOrganization { get; set; }
        #endregion
        
        #region Parameter IncidentResponseTeam
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateMembership to update the membership name.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityIR.Model.IncidentResponder[] IncidentResponseTeam { get; set; }
        #endregion
        
        #region Parameter MembershipId
        /// <summary>
        /// <para>
        /// <para>Required element for UpdateMembership to identify the membership to update.</para>
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
        public System.String MembershipId { get; set; }
        #endregion
        
        #region Parameter MembershipName
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateMembership to update the membership name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MembershipName { get; set; }
        #endregion
        
        #region Parameter OptInFeature
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateMembership to enable or disable opt-in features for the
        /// service.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OptInFeatures")]
        public Amazon.SecurityIR.Model.OptInFeature[] OptInFeature { get; set; }
        #endregion
        
        #region Parameter MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd
        /// <summary>
        /// <para>
        /// <para>A list of organizational unit IDs to add to the membership configuration. Each organizational
        /// unit ID must match the pattern <c>ou-[0-9a-z]{4,32}-[a-z0-9]{8,32}</c>. </para><para>The list must contain between 1 and 5 organizational unit IDs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd { get; set; }
        #endregion
        
        #region Parameter MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove
        /// <summary>
        /// <para>
        /// <para>A list of organizational unit IDs to remove from the membership configuration. Each
        /// organizational unit ID must match the pattern <c>ou-[0-9a-z]{4,32}-[a-z0-9]{8,32}</c>.
        /// </para><para>The list must contain between 1 and 5 organizational unit IDs per invocation of the
        /// API request.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove { get; set; }
        #endregion
        
        #region Parameter UndoMembershipCancellation
        /// <summary>
        /// <para>
        /// <para>The <c>undoMembershipCancellation</c> parameter is a boolean flag that indicates whether
        /// to reverse a previously requested membership cancellation. When set to true, this
        /// will revoke the cancellation request and maintain the membership status. </para><para>This parameter is optional and can be used in scenarios where you need to restore
        /// a membership that was marked for cancellation but hasn't been fully terminated yet.
        /// </para><ul><li><para>If set to <c>true</c>, the cancellation request will be revoked </para></li><li><para>If set to <c>false</c> the service will throw a ValidationException. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UndoMembershipCancellation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityIR.Model.UpdateMembershipResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MembershipId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SecurityIRMembership (UpdateMembership)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityIR.Model.UpdateMembershipResponse, UpdateSecurityIRMembershipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.IncidentResponseTeam != null)
            {
                context.IncidentResponseTeam = new List<Amazon.SecurityIR.Model.IncidentResponder>(this.IncidentResponseTeam);
            }
            context.MembershipAccountsConfigurationsUpdate_CoverEntireOrganization = this.MembershipAccountsConfigurationsUpdate_CoverEntireOrganization;
            if (this.MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd != null)
            {
                context.MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd = new List<System.String>(this.MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd);
            }
            if (this.MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove != null)
            {
                context.MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove = new List<System.String>(this.MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove);
            }
            context.MembershipId = this.MembershipId;
            #if MODULAR
            if (this.MembershipId == null && ParameterWasBound(nameof(this.MembershipId)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipName = this.MembershipName;
            if (this.OptInFeature != null)
            {
                context.OptInFeature = new List<Amazon.SecurityIR.Model.OptInFeature>(this.OptInFeature);
            }
            context.UndoMembershipCancellation = this.UndoMembershipCancellation;
            
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
            var request = new Amazon.SecurityIR.Model.UpdateMembershipRequest();
            
            if (cmdletContext.IncidentResponseTeam != null)
            {
                request.IncidentResponseTeam = cmdletContext.IncidentResponseTeam;
            }
            
             // populate MembershipAccountsConfigurationsUpdate
            var requestMembershipAccountsConfigurationsUpdateIsNull = true;
            request.MembershipAccountsConfigurationsUpdate = new Amazon.SecurityIR.Model.MembershipAccountsConfigurationsUpdate();
            System.Boolean? requestMembershipAccountsConfigurationsUpdate_membershipAccountsConfigurationsUpdate_CoverEntireOrganization = null;
            if (cmdletContext.MembershipAccountsConfigurationsUpdate_CoverEntireOrganization != null)
            {
                requestMembershipAccountsConfigurationsUpdate_membershipAccountsConfigurationsUpdate_CoverEntireOrganization = cmdletContext.MembershipAccountsConfigurationsUpdate_CoverEntireOrganization.Value;
            }
            if (requestMembershipAccountsConfigurationsUpdate_membershipAccountsConfigurationsUpdate_CoverEntireOrganization != null)
            {
                request.MembershipAccountsConfigurationsUpdate.CoverEntireOrganization = requestMembershipAccountsConfigurationsUpdate_membershipAccountsConfigurationsUpdate_CoverEntireOrganization.Value;
                requestMembershipAccountsConfigurationsUpdateIsNull = false;
            }
            List<System.String> requestMembershipAccountsConfigurationsUpdate_membershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd = null;
            if (cmdletContext.MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd != null)
            {
                requestMembershipAccountsConfigurationsUpdate_membershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd = cmdletContext.MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd;
            }
            if (requestMembershipAccountsConfigurationsUpdate_membershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd != null)
            {
                request.MembershipAccountsConfigurationsUpdate.OrganizationalUnitsToAdd = requestMembershipAccountsConfigurationsUpdate_membershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd;
                requestMembershipAccountsConfigurationsUpdateIsNull = false;
            }
            List<System.String> requestMembershipAccountsConfigurationsUpdate_membershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove = null;
            if (cmdletContext.MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove != null)
            {
                requestMembershipAccountsConfigurationsUpdate_membershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove = cmdletContext.MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove;
            }
            if (requestMembershipAccountsConfigurationsUpdate_membershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove != null)
            {
                request.MembershipAccountsConfigurationsUpdate.OrganizationalUnitsToRemove = requestMembershipAccountsConfigurationsUpdate_membershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove;
                requestMembershipAccountsConfigurationsUpdateIsNull = false;
            }
             // determine if request.MembershipAccountsConfigurationsUpdate should be set to null
            if (requestMembershipAccountsConfigurationsUpdateIsNull)
            {
                request.MembershipAccountsConfigurationsUpdate = null;
            }
            if (cmdletContext.MembershipId != null)
            {
                request.MembershipId = cmdletContext.MembershipId;
            }
            if (cmdletContext.MembershipName != null)
            {
                request.MembershipName = cmdletContext.MembershipName;
            }
            if (cmdletContext.OptInFeature != null)
            {
                request.OptInFeatures = cmdletContext.OptInFeature;
            }
            if (cmdletContext.UndoMembershipCancellation != null)
            {
                request.UndoMembershipCancellation = cmdletContext.UndoMembershipCancellation.Value;
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
        
        private Amazon.SecurityIR.Model.UpdateMembershipResponse CallAWSServiceOperation(IAmazonSecurityIR client, Amazon.SecurityIR.Model.UpdateMembershipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Security Incident Response", "UpdateMembership");
            try
            {
                return client.UpdateMembershipAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityIR.Model.IncidentResponder> IncidentResponseTeam { get; set; }
            public System.Boolean? MembershipAccountsConfigurationsUpdate_CoverEntireOrganization { get; set; }
            public List<System.String> MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd { get; set; }
            public List<System.String> MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove { get; set; }
            public System.String MembershipId { get; set; }
            public System.String MembershipName { get; set; }
            public List<Amazon.SecurityIR.Model.OptInFeature> OptInFeature { get; set; }
            public System.Boolean? UndoMembershipCancellation { get; set; }
            public System.Func<Amazon.SecurityIR.Model.UpdateMembershipResponse, UpdateSecurityIRMembershipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

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
using Amazon.SecurityIR;
using Amazon.SecurityIR.Model;

namespace Amazon.PowerShell.Cmdlets.SecurityIR
{
    /// <summary>
    /// Grants permission to update an existing case.
    /// </summary>
    [Cmdlet("Update", "SecurityIRCase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Security Incident Response UpdateCase API operation.", Operation = new[] {"UpdateCase"}, SelectReturnType = typeof(Amazon.SecurityIR.Model.UpdateCaseResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityIR.Model.UpdateCaseResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityIR.Model.UpdateCaseResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSecurityIRCaseCmdlet : AmazonSecurityIRClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActualIncidentStartDate
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content for the incident start date field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ActualIncidentStartDate { get; set; }
        #endregion
        
        #region Parameter CaseId
        /// <summary>
        /// <para>
        /// <para>Required element for UpdateCase to identify the case ID for updates.</para>
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
        public System.String CaseId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content for the description field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EngagementType
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content for the engagement type field.
        /// <c>Available engagement types include Security Incident | Investigation</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityIR.EngagementType")]
        public Amazon.SecurityIR.EngagementType EngagementType { get; set; }
        #endregion
        
        #region Parameter ImpactedAccountsToAdd
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content to add accounts impacted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ImpactedAccountsToAdd { get; set; }
        #endregion
        
        #region Parameter ImpactedAccountsToDelete
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content to add accounts impacted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ImpactedAccountsToDelete { get; set; }
        #endregion
        
        #region Parameter ImpactedAwsRegionsToAdd
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content to add regions impacted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityIR.Model.ImpactedAwsRegion[] ImpactedAwsRegionsToAdd { get; set; }
        #endregion
        
        #region Parameter ImpactedAwsRegionsToDelete
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content to remove regions impacted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityIR.Model.ImpactedAwsRegion[] ImpactedAwsRegionsToDelete { get; set; }
        #endregion
        
        #region Parameter ImpactedServicesToAdd
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content to add services impacted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ImpactedServicesToAdd { get; set; }
        #endregion
        
        #region Parameter ImpactedServicesToDelete
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content to remove services impacted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ImpactedServicesToDelete { get; set; }
        #endregion
        
        #region Parameter ReportedIncidentStartDate
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content for the customer reported incident
        /// start date field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ReportedIncidentStartDate { get; set; }
        #endregion
        
        #region Parameter ThreatActorIpAddressesToAdd
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content to add additional suspicious IP
        /// addresses related to a case. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityIR.Model.ThreatActorIp[] ThreatActorIpAddressesToAdd { get; set; }
        #endregion
        
        #region Parameter ThreatActorIpAddressesToDelete
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content to remove suspicious IP addresses
        /// from a case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityIR.Model.ThreatActorIp[] ThreatActorIpAddressesToDelete { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content for the title field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter WatchersToAdd
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content to add additional watchers to a
        /// case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityIR.Model.Watcher[] WatchersToAdd { get; set; }
        #endregion
        
        #region Parameter WatchersToDelete
        /// <summary>
        /// <para>
        /// <para>Optional element for UpdateCase to provide content to remove existing watchers from
        /// a case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityIR.Model.Watcher[] WatchersToDelete { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityIR.Model.UpdateCaseResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CaseId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CaseId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CaseId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SecurityIRCase (UpdateCase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityIR.Model.UpdateCaseResponse, UpdateSecurityIRCaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CaseId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActualIncidentStartDate = this.ActualIncidentStartDate;
            context.CaseId = this.CaseId;
            #if MODULAR
            if (this.CaseId == null && ParameterWasBound(nameof(this.CaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter CaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.EngagementType = this.EngagementType;
            if (this.ImpactedAccountsToAdd != null)
            {
                context.ImpactedAccountsToAdd = new List<System.String>(this.ImpactedAccountsToAdd);
            }
            if (this.ImpactedAccountsToDelete != null)
            {
                context.ImpactedAccountsToDelete = new List<System.String>(this.ImpactedAccountsToDelete);
            }
            if (this.ImpactedAwsRegionsToAdd != null)
            {
                context.ImpactedAwsRegionsToAdd = new List<Amazon.SecurityIR.Model.ImpactedAwsRegion>(this.ImpactedAwsRegionsToAdd);
            }
            if (this.ImpactedAwsRegionsToDelete != null)
            {
                context.ImpactedAwsRegionsToDelete = new List<Amazon.SecurityIR.Model.ImpactedAwsRegion>(this.ImpactedAwsRegionsToDelete);
            }
            if (this.ImpactedServicesToAdd != null)
            {
                context.ImpactedServicesToAdd = new List<System.String>(this.ImpactedServicesToAdd);
            }
            if (this.ImpactedServicesToDelete != null)
            {
                context.ImpactedServicesToDelete = new List<System.String>(this.ImpactedServicesToDelete);
            }
            context.ReportedIncidentStartDate = this.ReportedIncidentStartDate;
            if (this.ThreatActorIpAddressesToAdd != null)
            {
                context.ThreatActorIpAddressesToAdd = new List<Amazon.SecurityIR.Model.ThreatActorIp>(this.ThreatActorIpAddressesToAdd);
            }
            if (this.ThreatActorIpAddressesToDelete != null)
            {
                context.ThreatActorIpAddressesToDelete = new List<Amazon.SecurityIR.Model.ThreatActorIp>(this.ThreatActorIpAddressesToDelete);
            }
            context.Title = this.Title;
            if (this.WatchersToAdd != null)
            {
                context.WatchersToAdd = new List<Amazon.SecurityIR.Model.Watcher>(this.WatchersToAdd);
            }
            if (this.WatchersToDelete != null)
            {
                context.WatchersToDelete = new List<Amazon.SecurityIR.Model.Watcher>(this.WatchersToDelete);
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
            var request = new Amazon.SecurityIR.Model.UpdateCaseRequest();
            
            if (cmdletContext.ActualIncidentStartDate != null)
            {
                request.ActualIncidentStartDate = cmdletContext.ActualIncidentStartDate.Value;
            }
            if (cmdletContext.CaseId != null)
            {
                request.CaseId = cmdletContext.CaseId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EngagementType != null)
            {
                request.EngagementType = cmdletContext.EngagementType;
            }
            if (cmdletContext.ImpactedAccountsToAdd != null)
            {
                request.ImpactedAccountsToAdd = cmdletContext.ImpactedAccountsToAdd;
            }
            if (cmdletContext.ImpactedAccountsToDelete != null)
            {
                request.ImpactedAccountsToDelete = cmdletContext.ImpactedAccountsToDelete;
            }
            if (cmdletContext.ImpactedAwsRegionsToAdd != null)
            {
                request.ImpactedAwsRegionsToAdd = cmdletContext.ImpactedAwsRegionsToAdd;
            }
            if (cmdletContext.ImpactedAwsRegionsToDelete != null)
            {
                request.ImpactedAwsRegionsToDelete = cmdletContext.ImpactedAwsRegionsToDelete;
            }
            if (cmdletContext.ImpactedServicesToAdd != null)
            {
                request.ImpactedServicesToAdd = cmdletContext.ImpactedServicesToAdd;
            }
            if (cmdletContext.ImpactedServicesToDelete != null)
            {
                request.ImpactedServicesToDelete = cmdletContext.ImpactedServicesToDelete;
            }
            if (cmdletContext.ReportedIncidentStartDate != null)
            {
                request.ReportedIncidentStartDate = cmdletContext.ReportedIncidentStartDate.Value;
            }
            if (cmdletContext.ThreatActorIpAddressesToAdd != null)
            {
                request.ThreatActorIpAddressesToAdd = cmdletContext.ThreatActorIpAddressesToAdd;
            }
            if (cmdletContext.ThreatActorIpAddressesToDelete != null)
            {
                request.ThreatActorIpAddressesToDelete = cmdletContext.ThreatActorIpAddressesToDelete;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
            }
            if (cmdletContext.WatchersToAdd != null)
            {
                request.WatchersToAdd = cmdletContext.WatchersToAdd;
            }
            if (cmdletContext.WatchersToDelete != null)
            {
                request.WatchersToDelete = cmdletContext.WatchersToDelete;
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
        
        private Amazon.SecurityIR.Model.UpdateCaseResponse CallAWSServiceOperation(IAmazonSecurityIR client, Amazon.SecurityIR.Model.UpdateCaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Security Incident Response", "UpdateCase");
            try
            {
                #if DESKTOP
                return client.UpdateCase(request);
                #elif CORECLR
                return client.UpdateCaseAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? ActualIncidentStartDate { get; set; }
            public System.String CaseId { get; set; }
            public System.String Description { get; set; }
            public Amazon.SecurityIR.EngagementType EngagementType { get; set; }
            public List<System.String> ImpactedAccountsToAdd { get; set; }
            public List<System.String> ImpactedAccountsToDelete { get; set; }
            public List<Amazon.SecurityIR.Model.ImpactedAwsRegion> ImpactedAwsRegionsToAdd { get; set; }
            public List<Amazon.SecurityIR.Model.ImpactedAwsRegion> ImpactedAwsRegionsToDelete { get; set; }
            public List<System.String> ImpactedServicesToAdd { get; set; }
            public List<System.String> ImpactedServicesToDelete { get; set; }
            public System.DateTime? ReportedIncidentStartDate { get; set; }
            public List<Amazon.SecurityIR.Model.ThreatActorIp> ThreatActorIpAddressesToAdd { get; set; }
            public List<Amazon.SecurityIR.Model.ThreatActorIp> ThreatActorIpAddressesToDelete { get; set; }
            public System.String Title { get; set; }
            public List<Amazon.SecurityIR.Model.Watcher> WatchersToAdd { get; set; }
            public List<Amazon.SecurityIR.Model.Watcher> WatchersToDelete { get; set; }
            public System.Func<Amazon.SecurityIR.Model.UpdateCaseResponse, UpdateSecurityIRCaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

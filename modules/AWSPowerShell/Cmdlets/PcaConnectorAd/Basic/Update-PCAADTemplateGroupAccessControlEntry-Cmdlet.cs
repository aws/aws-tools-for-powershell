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
using Amazon.PcaConnectorAd;
using Amazon.PcaConnectorAd.Model;

namespace Amazon.PowerShell.Cmdlets.PCAAD
{
    /// <summary>
    /// Update a group access control entry you created using <a href="https://docs.aws.amazon.com/pca-connector-ad/latest/APIReference/API_CreateTemplateGroupAccessControlEntry.html">CreateTemplateGroupAccessControlEntry</a>.
    /// </summary>
    [Cmdlet("Update", "PCAADTemplateGroupAccessControlEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Pca Connector Ad UpdateTemplateGroupAccessControlEntry API operation.", Operation = new[] {"UpdateTemplateGroupAccessControlEntry"}, SelectReturnType = typeof(Amazon.PcaConnectorAd.Model.UpdateTemplateGroupAccessControlEntryResponse))]
    [AWSCmdletOutput("None or Amazon.PcaConnectorAd.Model.UpdateTemplateGroupAccessControlEntryResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.PcaConnectorAd.Model.UpdateTemplateGroupAccessControlEntryResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePCAADTemplateGroupAccessControlEntryCmdlet : AmazonPcaConnectorAdClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessRights_AutoEnroll
        /// <summary>
        /// <para>
        /// <para>Allow or deny an Active Directory group from autoenrolling certificates issued against
        /// a template. The Active Directory group must be allowed to enroll to allow autoenrollment</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.AccessRight")]
        public Amazon.PcaConnectorAd.AccessRight AccessRights_AutoEnroll { get; set; }
        #endregion
        
        #region Parameter AccessRights_Enroll
        /// <summary>
        /// <para>
        /// <para>Allow or deny an Active Directory group from enrolling certificates issued against
        /// a template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.AccessRight")]
        public Amazon.PcaConnectorAd.AccessRight AccessRights_Enroll { get; set; }
        #endregion
        
        #region Parameter GroupDisplayName
        /// <summary>
        /// <para>
        /// <para>Name of the Active Directory group. This name does not need to match the group name
        /// in Active Directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupDisplayName { get; set; }
        #endregion
        
        #region Parameter GroupSecurityIdentifier
        /// <summary>
        /// <para>
        /// <para>Security identifier (SID) of the group object from Active Directory. The SID starts
        /// with "S-".</para>
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
        public System.String GroupSecurityIdentifier { get; set; }
        #endregion
        
        #region Parameter TemplateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a href="https://docs.aws.amazon.com/pca-connector-ad/latest/APIReference/API_CreateTemplate.html">CreateTemplate</a>.</para>
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
        public System.String TemplateArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PcaConnectorAd.Model.UpdateTemplateGroupAccessControlEntryResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GroupSecurityIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PCAADTemplateGroupAccessControlEntry (UpdateTemplateGroupAccessControlEntry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PcaConnectorAd.Model.UpdateTemplateGroupAccessControlEntryResponse, UpdatePCAADTemplateGroupAccessControlEntryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessRights_AutoEnroll = this.AccessRights_AutoEnroll;
            context.AccessRights_Enroll = this.AccessRights_Enroll;
            context.GroupDisplayName = this.GroupDisplayName;
            context.GroupSecurityIdentifier = this.GroupSecurityIdentifier;
            #if MODULAR
            if (this.GroupSecurityIdentifier == null && ParameterWasBound(nameof(this.GroupSecurityIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupSecurityIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TemplateArn = this.TemplateArn;
            #if MODULAR
            if (this.TemplateArn == null && ParameterWasBound(nameof(this.TemplateArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PcaConnectorAd.Model.UpdateTemplateGroupAccessControlEntryRequest();
            
            
             // populate AccessRights
            var requestAccessRightsIsNull = true;
            request.AccessRights = new Amazon.PcaConnectorAd.Model.AccessRights();
            Amazon.PcaConnectorAd.AccessRight requestAccessRights_accessRights_AutoEnroll = null;
            if (cmdletContext.AccessRights_AutoEnroll != null)
            {
                requestAccessRights_accessRights_AutoEnroll = cmdletContext.AccessRights_AutoEnroll;
            }
            if (requestAccessRights_accessRights_AutoEnroll != null)
            {
                request.AccessRights.AutoEnroll = requestAccessRights_accessRights_AutoEnroll;
                requestAccessRightsIsNull = false;
            }
            Amazon.PcaConnectorAd.AccessRight requestAccessRights_accessRights_Enroll = null;
            if (cmdletContext.AccessRights_Enroll != null)
            {
                requestAccessRights_accessRights_Enroll = cmdletContext.AccessRights_Enroll;
            }
            if (requestAccessRights_accessRights_Enroll != null)
            {
                request.AccessRights.Enroll = requestAccessRights_accessRights_Enroll;
                requestAccessRightsIsNull = false;
            }
             // determine if request.AccessRights should be set to null
            if (requestAccessRightsIsNull)
            {
                request.AccessRights = null;
            }
            if (cmdletContext.GroupDisplayName != null)
            {
                request.GroupDisplayName = cmdletContext.GroupDisplayName;
            }
            if (cmdletContext.GroupSecurityIdentifier != null)
            {
                request.GroupSecurityIdentifier = cmdletContext.GroupSecurityIdentifier;
            }
            if (cmdletContext.TemplateArn != null)
            {
                request.TemplateArn = cmdletContext.TemplateArn;
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
        
        private Amazon.PcaConnectorAd.Model.UpdateTemplateGroupAccessControlEntryResponse CallAWSServiceOperation(IAmazonPcaConnectorAd client, Amazon.PcaConnectorAd.Model.UpdateTemplateGroupAccessControlEntryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Pca Connector Ad", "UpdateTemplateGroupAccessControlEntry");
            try
            {
                #if DESKTOP
                return client.UpdateTemplateGroupAccessControlEntry(request);
                #elif CORECLR
                return client.UpdateTemplateGroupAccessControlEntryAsync(request).GetAwaiter().GetResult();
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
            public Amazon.PcaConnectorAd.AccessRight AccessRights_AutoEnroll { get; set; }
            public Amazon.PcaConnectorAd.AccessRight AccessRights_Enroll { get; set; }
            public System.String GroupDisplayName { get; set; }
            public System.String GroupSecurityIdentifier { get; set; }
            public System.String TemplateArn { get; set; }
            public System.Func<Amazon.PcaConnectorAd.Model.UpdateTemplateGroupAccessControlEntryResponse, UpdatePCAADTemplateGroupAccessControlEntryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

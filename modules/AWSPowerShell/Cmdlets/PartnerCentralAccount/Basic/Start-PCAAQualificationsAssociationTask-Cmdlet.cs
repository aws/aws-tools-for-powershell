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
using Amazon.PartnerCentralAccount;
using Amazon.PartnerCentralAccount.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCAA
{
    /// <summary>
    /// Initiates an asynchronous task to associate your partner qualifications with a primary
    /// account. You must be a subsidiary of the primary account with an active subsidiary
    /// connection. Use <c>GetQualificationsAssociationTask</c> to monitor task progress.
    /// </summary>
    [Cmdlet("Start", "PCAAQualificationsAssociationTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralAccount.Model.StartQualificationsAssociationTaskResponse")]
    [AWSCmdlet("Calls the Partner Central Account API StartQualificationsAssociationTask API operation.", Operation = new[] {"StartQualificationsAssociationTask"}, SelectReturnType = typeof(Amazon.PartnerCentralAccount.Model.StartQualificationsAssociationTaskResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralAccount.Model.StartQualificationsAssociationTaskResponse",
        "This cmdlet returns an Amazon.PartnerCentralAccount.Model.StartQualificationsAssociationTaskResponse object containing multiple properties."
    )]
    public partial class StartPCAAQualificationsAssociationTaskCmdlet : AmazonPartnerCentralAccountClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PrimaryPartner_AccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit AWS account ID linked to the partner profile. Required in requests if
        /// <c>ProfileId</c> is not provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrimaryPartner_AccountId { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog in which to perform the qualifications association. Valid values: <c>AWS</c>,
        /// <c>Sandbox</c>.</para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>Your partner identifier. You can provide either a partner ID (for example, <c>partner-abc123</c>)
        /// or a partner ARN. You must own this identifier.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter PrimaryPartner_ProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the partner profile, in the format <c>pprofile-*</c>. Required
        /// in requests if <c>AccountId</c> is not provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrimaryPartner_ProfileId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralAccount.Model.StartQualificationsAssociationTaskResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralAccount.Model.StartQualificationsAssociationTaskResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-PCAAQualificationsAssociationTask (StartQualificationsAssociationTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralAccount.Model.StartQualificationsAssociationTaskResponse, StartPCAAQualificationsAssociationTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrimaryPartner_AccountId = this.PrimaryPartner_AccountId;
            context.PrimaryPartner_ProfileId = this.PrimaryPartner_ProfileId;
            
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
            var request = new Amazon.PartnerCentralAccount.Model.StartQualificationsAssociationTaskRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            
             // populate PrimaryPartner
            var requestPrimaryPartnerIsNull = true;
            request.PrimaryPartner = new Amazon.PartnerCentralAccount.Model.QualificationsAssociationPartner();
            System.String requestPrimaryPartner_primaryPartner_AccountId = null;
            if (cmdletContext.PrimaryPartner_AccountId != null)
            {
                requestPrimaryPartner_primaryPartner_AccountId = cmdletContext.PrimaryPartner_AccountId;
            }
            if (requestPrimaryPartner_primaryPartner_AccountId != null)
            {
                request.PrimaryPartner.AccountId = requestPrimaryPartner_primaryPartner_AccountId;
                requestPrimaryPartnerIsNull = false;
            }
            System.String requestPrimaryPartner_primaryPartner_ProfileId = null;
            if (cmdletContext.PrimaryPartner_ProfileId != null)
            {
                requestPrimaryPartner_primaryPartner_ProfileId = cmdletContext.PrimaryPartner_ProfileId;
            }
            if (requestPrimaryPartner_primaryPartner_ProfileId != null)
            {
                request.PrimaryPartner.ProfileId = requestPrimaryPartner_primaryPartner_ProfileId;
                requestPrimaryPartnerIsNull = false;
            }
             // determine if request.PrimaryPartner should be set to null
            if (requestPrimaryPartnerIsNull)
            {
                request.PrimaryPartner = null;
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
        
        private Amazon.PartnerCentralAccount.Model.StartQualificationsAssociationTaskResponse CallAWSServiceOperation(IAmazonPartnerCentralAccount client, Amazon.PartnerCentralAccount.Model.StartQualificationsAssociationTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Account API", "StartQualificationsAssociationTask");
            try
            {
                return client.StartQualificationsAssociationTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Identifier { get; set; }
            public System.String PrimaryPartner_AccountId { get; set; }
            public System.String PrimaryPartner_ProfileId { get; set; }
            public System.Func<Amazon.PartnerCentralAccount.Model.StartQualificationsAssociationTaskResponse, StartPCAAQualificationsAssociationTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

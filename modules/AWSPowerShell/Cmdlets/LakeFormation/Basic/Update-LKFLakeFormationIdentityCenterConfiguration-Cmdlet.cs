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
using Amazon.LakeFormation;
using Amazon.LakeFormation.Model;

namespace Amazon.PowerShell.Cmdlets.LKF
{
    /// <summary>
    /// Updates the IAM Identity Center connection parameters.
    /// </summary>
    [Cmdlet("Update", "LKFLakeFormationIdentityCenterConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Lake Formation UpdateLakeFormationIdentityCenterConfiguration API operation.", Operation = new[] {"UpdateLakeFormationIdentityCenterConfiguration"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.UpdateLakeFormationIdentityCenterConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.LakeFormation.Model.UpdateLakeFormationIdentityCenterConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.LakeFormation.Model.UpdateLakeFormationIdentityCenterConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLKFLakeFormationIdentityCenterConfigurationCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationStatus
        /// <summary>
        /// <para>
        /// <para>Allows to enable or disable the IAM Identity Center connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LakeFormation.ApplicationStatus")]
        public Amazon.LakeFormation.ApplicationStatus ApplicationStatus { get; set; }
        #endregion
        
        #region Parameter ExternalFiltering_AuthorizedTarget
        /// <summary>
        /// <para>
        /// <para>List of third-party application <c>ARNs</c> integrated with Lake Formation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExternalFiltering_AuthorizedTargets")]
        public System.String[] ExternalFiltering_AuthorizedTarget { get; set; }
        #endregion
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, the account ID. The Data Catalog
        /// is the persistent metadata store. It contains database definitions, table definitions,
        /// view definitions, and other control information to manage your Lake Formation environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter ShareRecipient
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Web Services account IDs or Amazon Web Services organization/organizational
        /// unit ARNs that are allowed to access to access data managed by Lake Formation. </para><para>If the <c>ShareRecipients</c> list includes valid values, then the resource share
        /// is updated with the principals you want to have access to the resources.</para><para>If the <c>ShareRecipients</c> value is null, both the list of share recipients and
        /// the resource share remain unchanged.</para><para>If the <c>ShareRecipients</c> value is an empty list, then the existing share recipients
        /// list will be cleared, and the resource share will be deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ShareRecipients")]
        public Amazon.LakeFormation.Model.DataLakePrincipal[] ShareRecipient { get; set; }
        #endregion
        
        #region Parameter ExternalFiltering_Status
        /// <summary>
        /// <para>
        /// <para>Allows to enable or disable the third-party applications that are allowed to access
        /// data managed by Lake Formation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LakeFormation.EnableStatus")]
        public Amazon.LakeFormation.EnableStatus ExternalFiltering_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.UpdateLakeFormationIdentityCenterConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CatalogId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CatalogId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CatalogId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CatalogId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LKFLakeFormationIdentityCenterConfiguration (UpdateLakeFormationIdentityCenterConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.UpdateLakeFormationIdentityCenterConfigurationResponse, UpdateLKFLakeFormationIdentityCenterConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CatalogId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationStatus = this.ApplicationStatus;
            context.CatalogId = this.CatalogId;
            if (this.ExternalFiltering_AuthorizedTarget != null)
            {
                context.ExternalFiltering_AuthorizedTarget = new List<System.String>(this.ExternalFiltering_AuthorizedTarget);
            }
            context.ExternalFiltering_Status = this.ExternalFiltering_Status;
            if (this.ShareRecipient != null)
            {
                context.ShareRecipient = new List<Amazon.LakeFormation.Model.DataLakePrincipal>(this.ShareRecipient);
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
            var request = new Amazon.LakeFormation.Model.UpdateLakeFormationIdentityCenterConfigurationRequest();
            
            if (cmdletContext.ApplicationStatus != null)
            {
                request.ApplicationStatus = cmdletContext.ApplicationStatus;
            }
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            
             // populate ExternalFiltering
            var requestExternalFilteringIsNull = true;
            request.ExternalFiltering = new Amazon.LakeFormation.Model.ExternalFilteringConfiguration();
            List<System.String> requestExternalFiltering_externalFiltering_AuthorizedTarget = null;
            if (cmdletContext.ExternalFiltering_AuthorizedTarget != null)
            {
                requestExternalFiltering_externalFiltering_AuthorizedTarget = cmdletContext.ExternalFiltering_AuthorizedTarget;
            }
            if (requestExternalFiltering_externalFiltering_AuthorizedTarget != null)
            {
                request.ExternalFiltering.AuthorizedTargets = requestExternalFiltering_externalFiltering_AuthorizedTarget;
                requestExternalFilteringIsNull = false;
            }
            Amazon.LakeFormation.EnableStatus requestExternalFiltering_externalFiltering_Status = null;
            if (cmdletContext.ExternalFiltering_Status != null)
            {
                requestExternalFiltering_externalFiltering_Status = cmdletContext.ExternalFiltering_Status;
            }
            if (requestExternalFiltering_externalFiltering_Status != null)
            {
                request.ExternalFiltering.Status = requestExternalFiltering_externalFiltering_Status;
                requestExternalFilteringIsNull = false;
            }
             // determine if request.ExternalFiltering should be set to null
            if (requestExternalFilteringIsNull)
            {
                request.ExternalFiltering = null;
            }
            if (cmdletContext.ShareRecipient != null)
            {
                request.ShareRecipients = cmdletContext.ShareRecipient;
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
        
        private Amazon.LakeFormation.Model.UpdateLakeFormationIdentityCenterConfigurationResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.UpdateLakeFormationIdentityCenterConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "UpdateLakeFormationIdentityCenterConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateLakeFormationIdentityCenterConfiguration(request);
                #elif CORECLR
                return client.UpdateLakeFormationIdentityCenterConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.LakeFormation.ApplicationStatus ApplicationStatus { get; set; }
            public System.String CatalogId { get; set; }
            public List<System.String> ExternalFiltering_AuthorizedTarget { get; set; }
            public Amazon.LakeFormation.EnableStatus ExternalFiltering_Status { get; set; }
            public List<Amazon.LakeFormation.Model.DataLakePrincipal> ShareRecipient { get; set; }
            public System.Func<Amazon.LakeFormation.Model.UpdateLakeFormationIdentityCenterConfigurationResponse, UpdateLKFLakeFormationIdentityCenterConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

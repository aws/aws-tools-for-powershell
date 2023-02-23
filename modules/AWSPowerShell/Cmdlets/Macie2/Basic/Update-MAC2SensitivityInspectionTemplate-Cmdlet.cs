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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Updates the settings for the sensitivity inspection template for an account.
    /// </summary>
    [Cmdlet("Update", "MAC2SensitivityInspectionTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Macie 2 UpdateSensitivityInspectionTemplate API operation.", Operation = new[] {"UpdateSensitivityInspectionTemplate"}, SelectReturnType = typeof(Amazon.Macie2.Model.UpdateSensitivityInspectionTemplateResponse))]
    [AWSCmdletOutput("None or Amazon.Macie2.Model.UpdateSensitivityInspectionTemplateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Macie2.Model.UpdateSensitivityInspectionTemplateResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMAC2SensitivityInspectionTemplateCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        #region Parameter Includes_AllowListId
        /// <summary>
        /// <para>
        /// <para>An array of unique identifiers, one for each allow list to include.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Includes_AllowListIds")]
        public System.String[] Includes_AllowListId { get; set; }
        #endregion
        
        #region Parameter Includes_CustomDataIdentifierId
        /// <summary>
        /// <para>
        /// <para>An array of unique identifiers, one for each custom data identifier to include.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Includes_CustomDataIdentifierIds")]
        public System.String[] Includes_CustomDataIdentifierId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A custom description of the template. The description can contain as many as 200 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the Amazon Macie resource that the request applies to.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Excludes_ManagedDataIdentifierId
        /// <summary>
        /// <para>
        /// <para>An array of unique identifiers, one for each managed data identifier to exclude. To
        /// retrieve a list of valid values, use the ListManagedDataIdentifiers operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Excludes_ManagedDataIdentifierIds")]
        public System.String[] Excludes_ManagedDataIdentifierId { get; set; }
        #endregion
        
        #region Parameter Includes_ManagedDataIdentifierId
        /// <summary>
        /// <para>
        /// <para>An array of unique identifiers, one for each managed data identifier to include.</para><para>Amazon Macie uses these managed data identifiers in addition to managed data identifiers
        /// that are subsequently released and recommended for automated sensitive data discovery.
        /// To retrieve a list of valid values for the managed data identifiers that are currently
        /// available, use the ListManagedDataIdentifiers operation.</para><para />
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Includes_ManagedDataIdentifierIds")]
        public System.String[] Includes_ManagedDataIdentifierId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.UpdateSensitivityInspectionTemplateResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MAC2SensitivityInspectionTemplate (UpdateSensitivityInspectionTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.UpdateSensitivityInspectionTemplateResponse, UpdateMAC2SensitivityInspectionTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            if (this.Excludes_ManagedDataIdentifierId != null)
            {
                context.Excludes_ManagedDataIdentifierId = new List<System.String>(this.Excludes_ManagedDataIdentifierId);
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Includes_AllowListId != null)
            {
                context.Includes_AllowListId = new List<System.String>(this.Includes_AllowListId);
            }
            if (this.Includes_CustomDataIdentifierId != null)
            {
                context.Includes_CustomDataIdentifierId = new List<System.String>(this.Includes_CustomDataIdentifierId);
            }
            if (this.Includes_ManagedDataIdentifierId != null)
            {
                context.Includes_ManagedDataIdentifierId = new List<System.String>(this.Includes_ManagedDataIdentifierId);
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
            var request = new Amazon.Macie2.Model.UpdateSensitivityInspectionTemplateRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Excludes
            var requestExcludesIsNull = true;
            request.Excludes = new Amazon.Macie2.Model.SensitivityInspectionTemplateExcludes();
            List<System.String> requestExcludes_excludes_ManagedDataIdentifierId = null;
            if (cmdletContext.Excludes_ManagedDataIdentifierId != null)
            {
                requestExcludes_excludes_ManagedDataIdentifierId = cmdletContext.Excludes_ManagedDataIdentifierId;
            }
            if (requestExcludes_excludes_ManagedDataIdentifierId != null)
            {
                request.Excludes.ManagedDataIdentifierIds = requestExcludes_excludes_ManagedDataIdentifierId;
                requestExcludesIsNull = false;
            }
             // determine if request.Excludes should be set to null
            if (requestExcludesIsNull)
            {
                request.Excludes = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate Includes
            var requestIncludesIsNull = true;
            request.Includes = new Amazon.Macie2.Model.SensitivityInspectionTemplateIncludes();
            List<System.String> requestIncludes_includes_AllowListId = null;
            if (cmdletContext.Includes_AllowListId != null)
            {
                requestIncludes_includes_AllowListId = cmdletContext.Includes_AllowListId;
            }
            if (requestIncludes_includes_AllowListId != null)
            {
                request.Includes.AllowListIds = requestIncludes_includes_AllowListId;
                requestIncludesIsNull = false;
            }
            List<System.String> requestIncludes_includes_CustomDataIdentifierId = null;
            if (cmdletContext.Includes_CustomDataIdentifierId != null)
            {
                requestIncludes_includes_CustomDataIdentifierId = cmdletContext.Includes_CustomDataIdentifierId;
            }
            if (requestIncludes_includes_CustomDataIdentifierId != null)
            {
                request.Includes.CustomDataIdentifierIds = requestIncludes_includes_CustomDataIdentifierId;
                requestIncludesIsNull = false;
            }
            List<System.String> requestIncludes_includes_ManagedDataIdentifierId = null;
            if (cmdletContext.Includes_ManagedDataIdentifierId != null)
            {
                requestIncludes_includes_ManagedDataIdentifierId = cmdletContext.Includes_ManagedDataIdentifierId;
            }
            if (requestIncludes_includes_ManagedDataIdentifierId != null)
            {
                request.Includes.ManagedDataIdentifierIds = requestIncludes_includes_ManagedDataIdentifierId;
                requestIncludesIsNull = false;
            }
             // determine if request.Includes should be set to null
            if (requestIncludesIsNull)
            {
                request.Includes = null;
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
        
        private Amazon.Macie2.Model.UpdateSensitivityInspectionTemplateResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.UpdateSensitivityInspectionTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "UpdateSensitivityInspectionTemplate");
            try
            {
                #if DESKTOP
                return client.UpdateSensitivityInspectionTemplate(request);
                #elif CORECLR
                return client.UpdateSensitivityInspectionTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public List<System.String> Excludes_ManagedDataIdentifierId { get; set; }
            public System.String Id { get; set; }
            public List<System.String> Includes_AllowListId { get; set; }
            public List<System.String> Includes_CustomDataIdentifierId { get; set; }
            public List<System.String> Includes_ManagedDataIdentifierId { get; set; }
            public System.Func<Amazon.Macie2.Model.UpdateSensitivityInspectionTemplateResponse, UpdateMAC2SensitivityInspectionTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

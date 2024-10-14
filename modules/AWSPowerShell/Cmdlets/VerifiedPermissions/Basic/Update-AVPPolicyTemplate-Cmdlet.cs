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
using Amazon.VerifiedPermissions;
using Amazon.VerifiedPermissions.Model;

namespace Amazon.PowerShell.Cmdlets.AVP
{
    /// <summary>
    /// Updates the specified policy template. You can update only the description and the
    /// some elements of the <a href="https://docs.aws.amazon.com/verifiedpermissions/latest/apireference/API_UpdatePolicyTemplate.html#amazonverifiedpermissions-UpdatePolicyTemplate-request-policyBody">policyBody</a>.
    /// 
    /// 
    ///  <important><para>
    /// Changes you make to the policy template content are immediately (within the constraints
    /// of eventual consistency) reflected in authorization decisions that involve all template-linked
    /// policies instantiated from this template.
    /// </para></important><note><para>
    /// Verified Permissions is <i><a href="https://wikipedia.org/wiki/Eventual_consistency">eventually
    /// consistent</a></i>. It can take a few seconds for a new or changed element to propagate
    /// through the service and be visible in the results of other Verified Permissions operations.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "AVPPolicyTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VerifiedPermissions.Model.UpdatePolicyTemplateResponse")]
    [AWSCmdlet("Calls the Amazon Verified Permissions UpdatePolicyTemplate API operation.", Operation = new[] {"UpdatePolicyTemplate"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.UpdatePolicyTemplateResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.UpdatePolicyTemplateResponse",
        "This cmdlet returns an Amazon.VerifiedPermissions.Model.UpdatePolicyTemplateResponse object containing multiple properties."
    )]
    public partial class UpdateAVPPolicyTemplateCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Specifies a new description to apply to the policy template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter PolicyStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy store that contains the policy template that you want
        /// to update.</para>
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
        public System.String PolicyStoreId { get; set; }
        #endregion
        
        #region Parameter PolicyTemplateId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy template that you want to update.</para>
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
        public System.String PolicyTemplateId { get; set; }
        #endregion
        
        #region Parameter Statement
        /// <summary>
        /// <para>
        /// <para>Specifies new statement content written in Cedar policy language to replace the current
        /// body of the policy template.</para><para>You can change only the following elements of the policy body:</para><ul><li><para>The <c>action</c> referenced by the policy template.</para></li><li><para>Any conditional clauses, such as <c>when</c> or <c>unless</c> clauses.</para></li></ul><para>You <b>can't</b> change the following elements:</para><ul><li><para>The effect (<c>permit</c> or <c>forbid</c>) of the policy template.</para></li><li><para>The <c>principal</c> referenced by the policy template.</para></li><li><para>The <c>resource</c> referenced by the policy template.</para></li></ul>
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
        public System.String Statement { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.UpdatePolicyTemplateResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.UpdatePolicyTemplateResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyTemplateId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AVPPolicyTemplate (UpdatePolicyTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.UpdatePolicyTemplateResponse, UpdateAVPPolicyTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.PolicyStoreId = this.PolicyStoreId;
            #if MODULAR
            if (this.PolicyStoreId == null && ParameterWasBound(nameof(this.PolicyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyTemplateId = this.PolicyTemplateId;
            #if MODULAR
            if (this.PolicyTemplateId == null && ParameterWasBound(nameof(this.PolicyTemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyTemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Statement = this.Statement;
            #if MODULAR
            if (this.Statement == null && ParameterWasBound(nameof(this.Statement)))
            {
                WriteWarning("You are passing $null as a value for parameter Statement which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VerifiedPermissions.Model.UpdatePolicyTemplateRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.PolicyStoreId != null)
            {
                request.PolicyStoreId = cmdletContext.PolicyStoreId;
            }
            if (cmdletContext.PolicyTemplateId != null)
            {
                request.PolicyTemplateId = cmdletContext.PolicyTemplateId;
            }
            if (cmdletContext.Statement != null)
            {
                request.Statement = cmdletContext.Statement;
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
        
        private Amazon.VerifiedPermissions.Model.UpdatePolicyTemplateResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.UpdatePolicyTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "UpdatePolicyTemplate");
            try
            {
                #if DESKTOP
                return client.UpdatePolicyTemplate(request);
                #elif CORECLR
                return client.UpdatePolicyTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String PolicyStoreId { get; set; }
            public System.String PolicyTemplateId { get; set; }
            public System.String Statement { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.UpdatePolicyTemplateResponse, UpdateAVPPolicyTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

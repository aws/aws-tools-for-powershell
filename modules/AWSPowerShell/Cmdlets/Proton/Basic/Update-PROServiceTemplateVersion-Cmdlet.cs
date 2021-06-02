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
using Amazon.Proton;
using Amazon.Proton.Model;

namespace Amazon.PowerShell.Cmdlets.PRO
{
    /// <summary>
    /// Update a major or minor version of a service template.
    /// </summary>
    [Cmdlet("Update", "PROServiceTemplateVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Proton.Model.ServiceTemplateVersion")]
    [AWSCmdlet("Calls the AWS Proton UpdateServiceTemplateVersion API operation.", Operation = new[] {"UpdateServiceTemplateVersion"}, SelectReturnType = typeof(Amazon.Proton.Model.UpdateServiceTemplateVersionResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.ServiceTemplateVersion or Amazon.Proton.Model.UpdateServiceTemplateVersionResponse",
        "This cmdlet returns an Amazon.Proton.Model.ServiceTemplateVersion object.",
        "The service call response (type Amazon.Proton.Model.UpdateServiceTemplateVersionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePROServiceTemplateVersionCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        #region Parameter CompatibleEnvironmentTemplate
        /// <summary>
        /// <para>
        /// <para>An array of compatible environment names for a service template major or minor version
        /// to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CompatibleEnvironmentTemplates")]
        public Amazon.Proton.Model.CompatibleEnvironmentTemplateInput[] CompatibleEnvironmentTemplate { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of a service template version to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MajorVersion
        /// <summary>
        /// <para>
        /// <para>To update a major version of a service template, include <code>majorVersion</code>.</para>
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
        public System.String MajorVersion { get; set; }
        #endregion
        
        #region Parameter MinorVersion
        /// <summary>
        /// <para>
        /// <para>To update a minor version of a service template, include <code>minorVersion</code>.</para>
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
        public System.String MinorVersion { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the service template minor version to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Proton.TemplateVersionStatus")]
        public Amazon.Proton.TemplateVersionStatus Status { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the service template.</para>
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
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceTemplateVersion'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.UpdateServiceTemplateVersionResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.UpdateServiceTemplateVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceTemplateVersion";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PROServiceTemplateVersion (UpdateServiceTemplateVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.UpdateServiceTemplateVersionResponse, UpdatePROServiceTemplateVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CompatibleEnvironmentTemplate != null)
            {
                context.CompatibleEnvironmentTemplate = new List<Amazon.Proton.Model.CompatibleEnvironmentTemplateInput>(this.CompatibleEnvironmentTemplate);
            }
            context.Description = this.Description;
            context.MajorVersion = this.MajorVersion;
            #if MODULAR
            if (this.MajorVersion == null && ParameterWasBound(nameof(this.MajorVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter MajorVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinorVersion = this.MinorVersion;
            #if MODULAR
            if (this.MinorVersion == null && ParameterWasBound(nameof(this.MinorVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter MinorVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            context.TemplateName = this.TemplateName;
            #if MODULAR
            if (this.TemplateName == null && ParameterWasBound(nameof(this.TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Proton.Model.UpdateServiceTemplateVersionRequest();
            
            if (cmdletContext.CompatibleEnvironmentTemplate != null)
            {
                request.CompatibleEnvironmentTemplates = cmdletContext.CompatibleEnvironmentTemplate;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MajorVersion != null)
            {
                request.MajorVersion = cmdletContext.MajorVersion;
            }
            if (cmdletContext.MinorVersion != null)
            {
                request.MinorVersion = cmdletContext.MinorVersion;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
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
        
        private Amazon.Proton.Model.UpdateServiceTemplateVersionResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.UpdateServiceTemplateVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "UpdateServiceTemplateVersion");
            try
            {
                #if DESKTOP
                return client.UpdateServiceTemplateVersion(request);
                #elif CORECLR
                return client.UpdateServiceTemplateVersionAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Proton.Model.CompatibleEnvironmentTemplateInput> CompatibleEnvironmentTemplate { get; set; }
            public System.String Description { get; set; }
            public System.String MajorVersion { get; set; }
            public System.String MinorVersion { get; set; }
            public Amazon.Proton.TemplateVersionStatus Status { get; set; }
            public System.String TemplateName { get; set; }
            public System.Func<Amazon.Proton.Model.UpdateServiceTemplateVersionResponse, UpdatePROServiceTemplateVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceTemplateVersion;
        }
        
    }
}

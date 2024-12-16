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
using Amazon.IoTThingsGraph;
using Amazon.IoTThingsGraph.Model;

namespace Amazon.PowerShell.Cmdlets.IOTTG
{
    /// <summary>
    /// Updates the specified system. You don't need to run this action after updating a workflow.
    /// Any deployment that uses the system will see the changes in the system when it is
    /// redeployed.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Update", "IOTTGSystemTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTThingsGraph.Model.SystemTemplateSummary")]
    [AWSCmdlet("Calls the AWS IoT Things Graph UpdateSystemTemplate API operation.", Operation = new[] {"UpdateSystemTemplate"}, SelectReturnType = typeof(Amazon.IoTThingsGraph.Model.UpdateSystemTemplateResponse))]
    [AWSCmdletOutput("Amazon.IoTThingsGraph.Model.SystemTemplateSummary or Amazon.IoTThingsGraph.Model.UpdateSystemTemplateResponse",
        "This cmdlet returns an Amazon.IoTThingsGraph.Model.SystemTemplateSummary object.",
        "The service call response (type Amazon.IoTThingsGraph.Model.UpdateSystemTemplateResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("since: 2022-08-30")]
    public partial class UpdateIOTTGSystemTemplateCmdlet : AmazonIoTThingsGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CompatibleNamespaceVersion
        /// <summary>
        /// <para>
        /// <para>The version of the user's namespace. Defaults to the latest version of the user's
        /// namespace.</para><para>If no value is specified, the latest version is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CompatibleNamespaceVersion { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the system to be updated.</para><para>The ID should be in the following format.</para><para><c>urn:tdm:REGION/ACCOUNT ID/default:system:SYSTEMNAME</c></para>
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
        
        #region Parameter Definition_Language
        /// <summary>
        /// <para>
        /// <para>The language used to define the entity. <c>GRAPHQL</c> is the only valid value.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTThingsGraph.DefinitionLanguage")]
        public Amazon.IoTThingsGraph.DefinitionLanguage Definition_Language { get; set; }
        #endregion
        
        #region Parameter Definition_Text
        /// <summary>
        /// <para>
        /// <para>The GraphQL text that defines the entity.</para>
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
        public System.String Definition_Text { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Summary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTThingsGraph.Model.UpdateSystemTemplateResponse).
        /// Specifying the name of a property of type Amazon.IoTThingsGraph.Model.UpdateSystemTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Summary";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTTGSystemTemplate (UpdateSystemTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTThingsGraph.Model.UpdateSystemTemplateResponse, UpdateIOTTGSystemTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CompatibleNamespaceVersion = this.CompatibleNamespaceVersion;
            context.Definition_Language = this.Definition_Language;
            #if MODULAR
            if (this.Definition_Language == null && ParameterWasBound(nameof(this.Definition_Language)))
            {
                WriteWarning("You are passing $null as a value for parameter Definition_Language which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Definition_Text = this.Definition_Text;
            #if MODULAR
            if (this.Definition_Text == null && ParameterWasBound(nameof(this.Definition_Text)))
            {
                WriteWarning("You are passing $null as a value for parameter Definition_Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTThingsGraph.Model.UpdateSystemTemplateRequest();
            
            if (cmdletContext.CompatibleNamespaceVersion != null)
            {
                request.CompatibleNamespaceVersion = cmdletContext.CompatibleNamespaceVersion.Value;
            }
            
             // populate Definition
            var requestDefinitionIsNull = true;
            request.Definition = new Amazon.IoTThingsGraph.Model.DefinitionDocument();
            Amazon.IoTThingsGraph.DefinitionLanguage requestDefinition_definition_Language = null;
            if (cmdletContext.Definition_Language != null)
            {
                requestDefinition_definition_Language = cmdletContext.Definition_Language;
            }
            if (requestDefinition_definition_Language != null)
            {
                request.Definition.Language = requestDefinition_definition_Language;
                requestDefinitionIsNull = false;
            }
            System.String requestDefinition_definition_Text = null;
            if (cmdletContext.Definition_Text != null)
            {
                requestDefinition_definition_Text = cmdletContext.Definition_Text;
            }
            if (requestDefinition_definition_Text != null)
            {
                request.Definition.Text = requestDefinition_definition_Text;
                requestDefinitionIsNull = false;
            }
             // determine if request.Definition should be set to null
            if (requestDefinitionIsNull)
            {
                request.Definition = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.IoTThingsGraph.Model.UpdateSystemTemplateResponse CallAWSServiceOperation(IAmazonIoTThingsGraph client, Amazon.IoTThingsGraph.Model.UpdateSystemTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Things Graph", "UpdateSystemTemplate");
            try
            {
                #if DESKTOP
                return client.UpdateSystemTemplate(request);
                #elif CORECLR
                return client.UpdateSystemTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? CompatibleNamespaceVersion { get; set; }
            public Amazon.IoTThingsGraph.DefinitionLanguage Definition_Language { get; set; }
            public System.String Definition_Text { get; set; }
            public System.String Id { get; set; }
            public System.Func<Amazon.IoTThingsGraph.Model.UpdateSystemTemplateResponse, UpdateIOTTGSystemTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Summary;
        }
        
    }
}

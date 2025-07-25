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
using Amazon.IoTThingsGraph;
using Amazon.IoTThingsGraph.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTTG
{
    /// <summary>
    /// Creates a workflow template. Workflows can be created only in the user's namespace.
    /// (The public namespace contains only entities.) The workflow can contain only entities
    /// in the specified namespace. The workflow is validated against the entities in the
    /// latest version of the user's namespace unless another namespace version is specified
    /// in the request.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("New", "IOTTGFlowTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTThingsGraph.Model.FlowTemplateSummary")]
    [AWSCmdlet("Calls the AWS IoT Things Graph CreateFlowTemplate API operation.", Operation = new[] {"CreateFlowTemplate"}, SelectReturnType = typeof(Amazon.IoTThingsGraph.Model.CreateFlowTemplateResponse))]
    [AWSCmdletOutput("Amazon.IoTThingsGraph.Model.FlowTemplateSummary or Amazon.IoTThingsGraph.Model.CreateFlowTemplateResponse",
        "This cmdlet returns an Amazon.IoTThingsGraph.Model.FlowTemplateSummary object.",
        "The service call response (type Amazon.IoTThingsGraph.Model.CreateFlowTemplateResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("since: 2022-08-30")]
    public partial class NewIOTTGFlowTemplateCmdlet : AmazonIoTThingsGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CompatibleNamespaceVersion
        /// <summary>
        /// <para>
        /// <para>The namespace version in which the workflow is to be created.</para><para>If no value is specified, the latest version is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CompatibleNamespaceVersion { get; set; }
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Definition_Text { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Summary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTThingsGraph.Model.CreateFlowTemplateResponse).
        /// Specifying the name of a property of type Amazon.IoTThingsGraph.Model.CreateFlowTemplateResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTTGFlowTemplate (CreateFlowTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTThingsGraph.Model.CreateFlowTemplateResponse, NewIOTTGFlowTemplateCmdlet>(Select) ??
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
            var request = new Amazon.IoTThingsGraph.Model.CreateFlowTemplateRequest();
            
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
        
        private Amazon.IoTThingsGraph.Model.CreateFlowTemplateResponse CallAWSServiceOperation(IAmazonIoTThingsGraph client, Amazon.IoTThingsGraph.Model.CreateFlowTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Things Graph", "CreateFlowTemplate");
            try
            {
                return client.CreateFlowTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.IoTThingsGraph.Model.CreateFlowTemplateResponse, NewIOTTGFlowTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Summary;
        }
        
    }
}

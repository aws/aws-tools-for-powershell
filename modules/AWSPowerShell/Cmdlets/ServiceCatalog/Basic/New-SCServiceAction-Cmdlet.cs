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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Creates a self-service action.
    /// </summary>
    [Cmdlet("New", "SCServiceAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.ServiceActionDetail")]
    [AWSCmdlet("Calls the AWS Service Catalog CreateServiceAction API operation.", Operation = new[] {"CreateServiceAction"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.CreateServiceActionResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.ServiceActionDetail or Amazon.ServiceCatalog.Model.CreateServiceActionResponse",
        "This cmdlet returns an Amazon.ServiceCatalog.Model.ServiceActionDetail object.",
        "The service call response (type Amazon.ServiceCatalog.Model.CreateServiceActionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSCServiceActionCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><c>jp</c> - Japanese</para></li><li><para><c>zh</c> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter Definition
        /// <summary>
        /// <para>
        /// <para>The self-service action definition. Can be one of the following:</para><dl><dt>Name</dt><dd><para>The name of the Amazon Web Services Systems Manager document (SSM document). For example,
        /// <c>AWS-RestartEC2Instance</c>.</para><para>If you are using a shared SSM document, you must provide the ARN instead of the name.</para></dd><dt>Version</dt><dd><para>The Amazon Web Services Systems Manager automation document version. For example,
        /// <c>"Version": "1"</c></para></dd><dt>AssumeRole</dt><dd><para>The Amazon Resource Name (ARN) of the role that performs the self-service actions
        /// on your behalf. For example, <c>"AssumeRole": "arn:aws:iam::12345678910:role/ActionRole"</c>.</para><para>To reuse the provisioned product launch role, set to <c>"AssumeRole": "LAUNCH_ROLE"</c>.</para></dd><dt>Parameters</dt><dd><para>The list of parameters in JSON format.</para><para>For example: <c>[{\"Name\":\"InstanceId\",\"Type\":\"TARGET\"}]</c> or <c>[{\"Name\":\"InstanceId\",\"Type\":\"TEXT_VALUE\"}]</c>.</para></dd></dl>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Collections.Hashtable Definition { get; set; }
        #endregion
        
        #region Parameter DefinitionType
        /// <summary>
        /// <para>
        /// <para>The service action definition type. For example, <c>SSM_AUTOMATION</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.ServiceActionDefinitionType")]
        public Amazon.ServiceCatalog.ServiceActionDefinitionType DefinitionType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The self-service action description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier that you provide to ensure idempotency. If multiple requests differ
        /// only by the idempotency token, the same response is returned for each repeated request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The self-service action name.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceActionDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.CreateServiceActionResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.CreateServiceActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceActionDetail";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SCServiceAction (CreateServiceAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.CreateServiceActionResponse, NewSCServiceActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptLanguage = this.AcceptLanguage;
            if (this.Definition != null)
            {
                context.Definition = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Definition.Keys)
                {
                    context.Definition.Add((String)hashKey, (System.String)(this.Definition[hashKey]));
                }
            }
            #if MODULAR
            if (this.Definition == null && ParameterWasBound(nameof(this.Definition)))
            {
                WriteWarning("You are passing $null as a value for parameter Definition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefinitionType = this.DefinitionType;
            #if MODULAR
            if (this.DefinitionType == null && ParameterWasBound(nameof(this.DefinitionType)))
            {
                WriteWarning("You are passing $null as a value for parameter DefinitionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.IdempotencyToken = this.IdempotencyToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServiceCatalog.Model.CreateServiceActionRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.Definition != null)
            {
                request.Definition = cmdletContext.Definition;
            }
            if (cmdletContext.DefinitionType != null)
            {
                request.DefinitionType = cmdletContext.DefinitionType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.ServiceCatalog.Model.CreateServiceActionResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.CreateServiceActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "CreateServiceAction");
            try
            {
                return client.CreateServiceActionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AcceptLanguage { get; set; }
            public Dictionary<System.String, System.String> Definition { get; set; }
            public Amazon.ServiceCatalog.ServiceActionDefinitionType DefinitionType { get; set; }
            public System.String Description { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.CreateServiceActionResponse, NewSCServiceActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceActionDetail;
        }
        
    }
}

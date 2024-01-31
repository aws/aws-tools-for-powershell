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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Updates a generated template. This can be used to change the name, add and remove
    /// resources, refresh resources, and change the <c>DeletionPolicy</c> and <c>UpdateReplacePolicy</c>
    /// settings. You can check the status of the update to the generated template using the
    /// <c>DescribeGeneratedTemplate</c> API action.
    /// </summary>
    [Cmdlet("Update", "CFNGeneratedTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation UpdateGeneratedTemplate API operation.", Operation = new[] {"UpdateGeneratedTemplate"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.UpdateGeneratedTemplateResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.UpdateGeneratedTemplateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.UpdateGeneratedTemplateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCFNGeneratedTemplateCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddResource
        /// <summary>
        /// <para>
        /// <para>An optional list of resources to be added to the generated template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddResources")]
        public Amazon.CloudFormation.Model.ResourceDefinition[] AddResource { get; set; }
        #endregion
        
        #region Parameter TemplateConfiguration_DeletionPolicy
        /// <summary>
        /// <para>
        /// <para>The <c>DeletionPolicy</c> assigned to resources in the generated template. Supported
        /// values are:</para><ul><li><para><c>DELETE</c> - delete all resources when the stack is deleted.</para></li><li><para><c>RETAIN</c> - retain all resources when the stack is deleted.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-attribute-deletionpolicy.html"><c>DeletionPolicy</c> attribute</a> in the <i>CloudFormation User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.GeneratedTemplateDeletionPolicy")]
        public Amazon.CloudFormation.GeneratedTemplateDeletionPolicy TemplateConfiguration_DeletionPolicy { get; set; }
        #endregion
        
        #region Parameter GeneratedTemplateName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of a generated template.</para>
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
        public System.String GeneratedTemplateName { get; set; }
        #endregion
        
        #region Parameter NewGeneratedTemplateName
        /// <summary>
        /// <para>
        /// <para>An optional new name to assign to the generated template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewGeneratedTemplateName { get; set; }
        #endregion
        
        #region Parameter RefreshAllResource
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, update the resource properties in the generated template with their
        /// current live state. This feature is useful when the resource properties in your generated
        /// a template does not reflect the live state of the resource properties. This happens
        /// when a user update the resource properties after generating a template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RefreshAllResources")]
        public System.Boolean? RefreshAllResource { get; set; }
        #endregion
        
        #region Parameter RemoveResource
        /// <summary>
        /// <para>
        /// <para>A list of logical ids for resources to remove from the generated template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveResources")]
        public System.String[] RemoveResource { get; set; }
        #endregion
        
        #region Parameter TemplateConfiguration_UpdateReplacePolicy
        /// <summary>
        /// <para>
        /// <para>The <c>UpdateReplacePolicy</c> assigned to resources in the generated template. Supported
        /// values are:</para><ul><li><para><c>DELETE</c> - delete all resources when the resource is replaced during an update
        /// operation.</para></li><li><para><c>RETAIN</c> - retain all resources when the resource is replaced during an update
        /// operation.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-attribute-updatereplacepolicy.html"><c>UpdateReplacePolicy</c> attribute</a> in the <i>CloudFormation User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.GeneratedTemplateUpdateReplacePolicy")]
        public Amazon.CloudFormation.GeneratedTemplateUpdateReplacePolicy TemplateConfiguration_UpdateReplacePolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GeneratedTemplateId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.UpdateGeneratedTemplateResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.UpdateGeneratedTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GeneratedTemplateId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GeneratedTemplateName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GeneratedTemplateName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GeneratedTemplateName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GeneratedTemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFNGeneratedTemplate (UpdateGeneratedTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.UpdateGeneratedTemplateResponse, UpdateCFNGeneratedTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GeneratedTemplateName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AddResource != null)
            {
                context.AddResource = new List<Amazon.CloudFormation.Model.ResourceDefinition>(this.AddResource);
            }
            context.GeneratedTemplateName = this.GeneratedTemplateName;
            #if MODULAR
            if (this.GeneratedTemplateName == null && ParameterWasBound(nameof(this.GeneratedTemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter GeneratedTemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewGeneratedTemplateName = this.NewGeneratedTemplateName;
            context.RefreshAllResource = this.RefreshAllResource;
            if (this.RemoveResource != null)
            {
                context.RemoveResource = new List<System.String>(this.RemoveResource);
            }
            context.TemplateConfiguration_DeletionPolicy = this.TemplateConfiguration_DeletionPolicy;
            context.TemplateConfiguration_UpdateReplacePolicy = this.TemplateConfiguration_UpdateReplacePolicy;
            
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
            var request = new Amazon.CloudFormation.Model.UpdateGeneratedTemplateRequest();
            
            if (cmdletContext.AddResource != null)
            {
                request.AddResources = cmdletContext.AddResource;
            }
            if (cmdletContext.GeneratedTemplateName != null)
            {
                request.GeneratedTemplateName = cmdletContext.GeneratedTemplateName;
            }
            if (cmdletContext.NewGeneratedTemplateName != null)
            {
                request.NewGeneratedTemplateName = cmdletContext.NewGeneratedTemplateName;
            }
            if (cmdletContext.RefreshAllResource != null)
            {
                request.RefreshAllResources = cmdletContext.RefreshAllResource.Value;
            }
            if (cmdletContext.RemoveResource != null)
            {
                request.RemoveResources = cmdletContext.RemoveResource;
            }
            
             // populate TemplateConfiguration
            var requestTemplateConfigurationIsNull = true;
            request.TemplateConfiguration = new Amazon.CloudFormation.Model.TemplateConfiguration();
            Amazon.CloudFormation.GeneratedTemplateDeletionPolicy requestTemplateConfiguration_templateConfiguration_DeletionPolicy = null;
            if (cmdletContext.TemplateConfiguration_DeletionPolicy != null)
            {
                requestTemplateConfiguration_templateConfiguration_DeletionPolicy = cmdletContext.TemplateConfiguration_DeletionPolicy;
            }
            if (requestTemplateConfiguration_templateConfiguration_DeletionPolicy != null)
            {
                request.TemplateConfiguration.DeletionPolicy = requestTemplateConfiguration_templateConfiguration_DeletionPolicy;
                requestTemplateConfigurationIsNull = false;
            }
            Amazon.CloudFormation.GeneratedTemplateUpdateReplacePolicy requestTemplateConfiguration_templateConfiguration_UpdateReplacePolicy = null;
            if (cmdletContext.TemplateConfiguration_UpdateReplacePolicy != null)
            {
                requestTemplateConfiguration_templateConfiguration_UpdateReplacePolicy = cmdletContext.TemplateConfiguration_UpdateReplacePolicy;
            }
            if (requestTemplateConfiguration_templateConfiguration_UpdateReplacePolicy != null)
            {
                request.TemplateConfiguration.UpdateReplacePolicy = requestTemplateConfiguration_templateConfiguration_UpdateReplacePolicy;
                requestTemplateConfigurationIsNull = false;
            }
             // determine if request.TemplateConfiguration should be set to null
            if (requestTemplateConfigurationIsNull)
            {
                request.TemplateConfiguration = null;
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
        
        private Amazon.CloudFormation.Model.UpdateGeneratedTemplateResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.UpdateGeneratedTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "UpdateGeneratedTemplate");
            try
            {
                #if DESKTOP
                return client.UpdateGeneratedTemplate(request);
                #elif CORECLR
                return client.UpdateGeneratedTemplateAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudFormation.Model.ResourceDefinition> AddResource { get; set; }
            public System.String GeneratedTemplateName { get; set; }
            public System.String NewGeneratedTemplateName { get; set; }
            public System.Boolean? RefreshAllResource { get; set; }
            public List<System.String> RemoveResource { get; set; }
            public Amazon.CloudFormation.GeneratedTemplateDeletionPolicy TemplateConfiguration_DeletionPolicy { get; set; }
            public Amazon.CloudFormation.GeneratedTemplateUpdateReplacePolicy TemplateConfiguration_UpdateReplacePolicy { get; set; }
            public System.Func<Amazon.CloudFormation.Model.UpdateGeneratedTemplateResponse, UpdateCFNGeneratedTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GeneratedTemplateId;
        }
        
    }
}

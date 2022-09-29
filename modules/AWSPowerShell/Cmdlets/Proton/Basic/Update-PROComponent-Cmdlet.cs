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
    /// Update a component.
    /// 
    ///  
    /// <para>
    /// There are a few modes for updating a component. The <code>deploymentType</code> field
    /// defines the mode.
    /// </para><note><para>
    /// You can't update a component while its deployment status, or the deployment status
    /// of a service instance attached to it, is <code>IN_PROGRESS</code>.
    /// </para></note><para>
    /// For more information about components, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-components.html">Proton
    /// components</a> in the <i>Proton User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "PROComponent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Proton.Model.Component")]
    [AWSCmdlet("Calls the AWS Proton UpdateComponent API operation.", Operation = new[] {"UpdateComponent"}, SelectReturnType = typeof(Amazon.Proton.Model.UpdateComponentResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.Component or Amazon.Proton.Model.UpdateComponentResponse",
        "This cmdlet returns an Amazon.Proton.Model.Component object.",
        "The service call response (type Amazon.Proton.Model.UpdateComponentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePROComponentCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        #region Parameter DeploymentType
        /// <summary>
        /// <para>
        /// <para>The deployment type. It defines the mode for updating a component, as follows:</para><dl><dt /><dd><para><code>NONE</code></para><para>In this mode, a deployment <i>doesn't</i> occur. Only the requested metadata parameters
        /// are updated. You can only specify <code>description</code> in this mode.</para></dd><dt /><dd><para><code>CURRENT_VERSION</code></para><para>In this mode, the component is deployed and updated with the new <code>serviceSpec</code>,
        /// <code>templateSource</code>, and/or <code>type</code> that you provide. Only requested
        /// parameters are updated.</para></dd></dl>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Proton.ComponentDeploymentUpdateType")]
        public Amazon.Proton.ComponentDeploymentUpdateType DeploymentType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional customer-provided description of the component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the component to update.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ServiceInstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the service instance that you want to attach this component to. Don't
        /// specify to keep the component's current service instance attachment. Specify an empty
        /// string to detach the component from the service instance it's attached to. Specify
        /// non-empty values for both <code>serviceInstanceName</code> and <code>serviceName</code>
        /// or for neither of them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceInstanceName { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the service that <code>serviceInstanceName</code> is associated with.
        /// Don't specify to keep the component's current service instance attachment. Specify
        /// an empty string to detach the component from the service instance it's attached to.
        /// Specify non-empty values for both <code>serviceInstanceName</code> and <code>serviceName</code>
        /// or for neither of them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter ServiceSpec
        /// <summary>
        /// <para>
        /// <para>The service spec that you want the component to use to access service inputs. Set
        /// this only when the component is attached to a service instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceSpec { get; set; }
        #endregion
        
        #region Parameter TemplateFile
        /// <summary>
        /// <para>
        /// <para>A path to the Infrastructure as Code (IaC) file describing infrastructure that a custom
        /// component provisions.</para><note><para>Components support a single IaC file, even if you use Terraform as your template language.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateFile { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Component'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.UpdateComponentResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.UpdateComponentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Component";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PROComponent (UpdateComponent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.UpdateComponentResponse, UpdatePROComponentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeploymentType = this.DeploymentType;
            #if MODULAR
            if (this.DeploymentType == null && ParameterWasBound(nameof(this.DeploymentType)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceInstanceName = this.ServiceInstanceName;
            context.ServiceName = this.ServiceName;
            context.ServiceSpec = this.ServiceSpec;
            context.TemplateFile = this.TemplateFile;
            
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
            var request = new Amazon.Proton.Model.UpdateComponentRequest();
            
            if (cmdletContext.DeploymentType != null)
            {
                request.DeploymentType = cmdletContext.DeploymentType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ServiceInstanceName != null)
            {
                request.ServiceInstanceName = cmdletContext.ServiceInstanceName;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            if (cmdletContext.ServiceSpec != null)
            {
                request.ServiceSpec = cmdletContext.ServiceSpec;
            }
            if (cmdletContext.TemplateFile != null)
            {
                request.TemplateFile = cmdletContext.TemplateFile;
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
        
        private Amazon.Proton.Model.UpdateComponentResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.UpdateComponentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "UpdateComponent");
            try
            {
                #if DESKTOP
                return client.UpdateComponent(request);
                #elif CORECLR
                return client.UpdateComponentAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Proton.ComponentDeploymentUpdateType DeploymentType { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String ServiceInstanceName { get; set; }
            public System.String ServiceName { get; set; }
            public System.String ServiceSpec { get; set; }
            public System.String TemplateFile { get; set; }
            public System.Func<Amazon.Proton.Model.UpdateComponentResponse, UpdatePROComponentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Component;
        }
        
    }
}

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
using Amazon.Proton;
using Amazon.Proton.Model;

namespace Amazon.PowerShell.Cmdlets.PRO
{
    /// <summary>
    /// Update a service instance.
    /// 
    ///  
    /// <para>
    /// There are a few modes for updating a service instance. The <c>deploymentType</c> field
    /// defines the mode.
    /// </para><note><para>
    /// You can't update a service instance while its deployment status, or the deployment
    /// status of a component attached to it, is <c>IN_PROGRESS</c>.
    /// </para><para>
    /// For more information about components, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-components.html">Proton
    /// components</a> in the <i>Proton User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "PROServiceInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Proton.Model.ServiceInstance")]
    [AWSCmdlet("Calls the AWS Proton UpdateServiceInstance API operation.", Operation = new[] {"UpdateServiceInstance"}, SelectReturnType = typeof(Amazon.Proton.Model.UpdateServiceInstanceResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.ServiceInstance or Amazon.Proton.Model.UpdateServiceInstanceResponse",
        "This cmdlet returns an Amazon.Proton.Model.ServiceInstance object.",
        "The service call response (type Amazon.Proton.Model.UpdateServiceInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePROServiceInstanceCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeploymentType
        /// <summary>
        /// <para>
        /// <para>The deployment type. It defines the mode for updating a service instance, as follows:</para><dl><dt /><dd><para><c>NONE</c></para><para>In this mode, a deployment <i>doesn't</i> occur. Only the requested metadata parameters
        /// are updated.</para></dd><dt /><dd><para><c>CURRENT_VERSION</c></para><para>In this mode, the service instance is deployed and updated with the new spec that
        /// you provide. Only requested parameters are updated. <i>Don’t</i> include major or
        /// minor version parameters when you use this deployment type.</para></dd><dt /><dd><para><c>MINOR_VERSION</c></para><para>In this mode, the service instance is deployed and updated with the published, recommended
        /// (latest) minor version of the current major version in use, by default. You can also
        /// specify a different minor version of the current major version in use.</para></dd><dt /><dd><para><c>MAJOR_VERSION</c></para><para>In this mode, the service instance is deployed and updated with the published, recommended
        /// (latest) major and minor version of the current template, by default. You can specify
        /// a different major version that's higher than the major version in use and a minor
        /// version.</para></dd></dl>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Proton.DeploymentUpdateType")]
        public Amazon.Proton.DeploymentUpdateType DeploymentType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the service instance to update.</para>
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
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the service that the service instance belongs to.</para>
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
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter Spec
        /// <summary>
        /// <para>
        /// <para>The formatted specification that defines the service instance update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec { get; set; }
        #endregion
        
        #region Parameter TemplateMajorVersion
        /// <summary>
        /// <para>
        /// <para>The major version of the service template to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateMajorVersion { get; set; }
        #endregion
        
        #region Parameter TemplateMinorVersion
        /// <summary>
        /// <para>
        /// <para>The minor version of the service template to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateMinorVersion { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client token of the service instance to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.UpdateServiceInstanceResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.UpdateServiceInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceInstance";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PROServiceInstance (UpdateServiceInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.UpdateServiceInstanceResponse, UpdatePROServiceInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DeploymentType = this.DeploymentType;
            #if MODULAR
            if (this.DeploymentType == null && ParameterWasBound(nameof(this.DeploymentType)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceName = this.ServiceName;
            #if MODULAR
            if (this.ServiceName == null && ParameterWasBound(nameof(this.ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Spec = this.Spec;
            context.TemplateMajorVersion = this.TemplateMajorVersion;
            context.TemplateMinorVersion = this.TemplateMinorVersion;
            
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
            var request = new Amazon.Proton.Model.UpdateServiceInstanceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeploymentType != null)
            {
                request.DeploymentType = cmdletContext.DeploymentType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            if (cmdletContext.Spec != null)
            {
                request.Spec = cmdletContext.Spec;
            }
            if (cmdletContext.TemplateMajorVersion != null)
            {
                request.TemplateMajorVersion = cmdletContext.TemplateMajorVersion;
            }
            if (cmdletContext.TemplateMinorVersion != null)
            {
                request.TemplateMinorVersion = cmdletContext.TemplateMinorVersion;
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
        
        private Amazon.Proton.Model.UpdateServiceInstanceResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.UpdateServiceInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "UpdateServiceInstance");
            try
            {
                #if DESKTOP
                return client.UpdateServiceInstance(request);
                #elif CORECLR
                return client.UpdateServiceInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.Proton.DeploymentUpdateType DeploymentType { get; set; }
            public System.String Name { get; set; }
            public System.String ServiceName { get; set; }
            public System.String Spec { get; set; }
            public System.String TemplateMajorVersion { get; set; }
            public System.String TemplateMinorVersion { get; set; }
            public System.Func<Amazon.Proton.Model.UpdateServiceInstanceResponse, UpdatePROServiceInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceInstance;
        }
        
    }
}

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
    /// Update the service pipeline.
    /// 
    ///  
    /// <para>
    /// There are four modes for updating a service pipeline. The <code>deploymentType</code>
    /// field defines the mode.
    /// </para><dl><dt /><dd><para><code>NONE</code></para><para>
    /// In this mode, a deployment <i>doesn't</i> occur. Only the requested metadata parameters
    /// are updated.
    /// </para></dd><dt /><dd><para><code>CURRENT_VERSION</code></para><para>
    /// In this mode, the service pipeline is deployed and updated with the new spec that
    /// you provide. Only requested parameters are updated. <i>Don’t</i> include major or
    /// minor version parameters when you use this <code>deployment-type</code>.
    /// </para></dd><dt /><dd><para><code>MINOR_VERSION</code></para><para>
    /// In this mode, the service pipeline is deployed and updated with the published, recommended
    /// (latest) minor version of the current major version in use, by default. You can specify
    /// a different minor version of the current major version in use.
    /// </para></dd><dt /><dd><para><code>MAJOR_VERSION</code></para><para>
    /// In this mode, the service pipeline is deployed and updated with the published, recommended
    /// (latest) major and minor version of the current template by default. You can specify
    /// a different major version that's higher than the major version in use and a minor
    /// version.
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Update", "PROServicePipeline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Proton.Model.ServicePipeline")]
    [AWSCmdlet("Calls the AWS Proton UpdateServicePipeline API operation.", Operation = new[] {"UpdateServicePipeline"}, SelectReturnType = typeof(Amazon.Proton.Model.UpdateServicePipelineResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.ServicePipeline or Amazon.Proton.Model.UpdateServicePipelineResponse",
        "This cmdlet returns an Amazon.Proton.Model.ServicePipeline object.",
        "The service call response (type Amazon.Proton.Model.UpdateServicePipelineResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePROServicePipelineCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        #region Parameter DeploymentType
        /// <summary>
        /// <para>
        /// <para>The deployment type.</para><para>There are four modes for updating a service pipeline. The <code>deploymentType</code>
        /// field defines the mode.</para><dl><dt /><dd><para><code>NONE</code></para><para>In this mode, a deployment <i>doesn't</i> occur. Only the requested metadata parameters
        /// are updated.</para></dd><dt /><dd><para><code>CURRENT_VERSION</code></para><para>In this mode, the service pipeline is deployed and updated with the new spec that
        /// you provide. Only requested parameters are updated. <i>Don’t</i> include major or
        /// minor version parameters when you use this <code>deployment-type</code>.</para></dd><dt /><dd><para><code>MINOR_VERSION</code></para><para>In this mode, the service pipeline is deployed and updated with the published, recommended
        /// (latest) minor version of the current major version in use, by default. You can specify
        /// a different minor version of the current major version in use.</para></dd><dt /><dd><para><code>MAJOR_VERSION</code></para><para>In this mode, the service pipeline is deployed and updated with the published, recommended
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
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the service to that the pipeline is associated with.</para>
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
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter Spec
        /// <summary>
        /// <para>
        /// <para>The spec for the service pipeline to update.</para>
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
        public System.String Spec { get; set; }
        #endregion
        
        #region Parameter TemplateMajorVersion
        /// <summary>
        /// <para>
        /// <para>The major version of the service template that was used to create the service that
        /// the pipeline is associated with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateMajorVersion { get; set; }
        #endregion
        
        #region Parameter TemplateMinorVersion
        /// <summary>
        /// <para>
        /// <para>The minor version of the service template that was used to create the service that
        /// the pipeline is associated with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateMinorVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Pipeline'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.UpdateServicePipelineResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.UpdateServicePipelineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Pipeline";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PROServicePipeline (UpdateServicePipeline)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.UpdateServicePipelineResponse, UpdatePROServicePipelineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeploymentType = this.DeploymentType;
            #if MODULAR
            if (this.DeploymentType == null && ParameterWasBound(nameof(this.DeploymentType)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #if MODULAR
            if (this.Spec == null && ParameterWasBound(nameof(this.Spec)))
            {
                WriteWarning("You are passing $null as a value for parameter Spec which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Proton.Model.UpdateServicePipelineRequest();
            
            if (cmdletContext.DeploymentType != null)
            {
                request.DeploymentType = cmdletContext.DeploymentType;
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
        
        private Amazon.Proton.Model.UpdateServicePipelineResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.UpdateServicePipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "UpdateServicePipeline");
            try
            {
                #if DESKTOP
                return client.UpdateServicePipeline(request);
                #elif CORECLR
                return client.UpdateServicePipelineAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Proton.DeploymentUpdateType DeploymentType { get; set; }
            public System.String ServiceName { get; set; }
            public System.String Spec { get; set; }
            public System.String TemplateMajorVersion { get; set; }
            public System.String TemplateMinorVersion { get; set; }
            public System.Func<Amazon.Proton.Model.UpdateServicePipelineResponse, UpdatePROServicePipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Pipeline;
        }
        
    }
}

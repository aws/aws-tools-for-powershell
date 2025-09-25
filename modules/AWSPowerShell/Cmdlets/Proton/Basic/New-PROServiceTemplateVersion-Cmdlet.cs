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
    /// Create a new major or minor version of a service template. A major version of a service
    /// template is a version that <i>isn't</i> backward compatible. A minor version of a
    /// service template is a version that's backward compatible within its major version.
    /// </summary>
    [Cmdlet("New", "PROServiceTemplateVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Proton.Model.ServiceTemplateVersion")]
    [AWSCmdlet("Calls the AWS Proton CreateServiceTemplateVersion API operation.", Operation = new[] {"CreateServiceTemplateVersion"}, SelectReturnType = typeof(Amazon.Proton.Model.CreateServiceTemplateVersionResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.ServiceTemplateVersion or Amazon.Proton.Model.CreateServiceTemplateVersionResponse",
        "This cmdlet returns an Amazon.Proton.Model.ServiceTemplateVersion object.",
        "The service call response (type Amazon.Proton.Model.CreateServiceTemplateVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPROServiceTemplateVersionCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket that contains a template bundle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter CompatibleEnvironmentTemplate
        /// <summary>
        /// <para>
        /// <para>An array of environment template objects that are compatible with the new service
        /// template version. A service instance based on this service template version can run
        /// in environments based on compatible templates.</para>
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
        [Alias("CompatibleEnvironmentTemplates")]
        public Amazon.Proton.Model.CompatibleEnvironmentTemplateInput[] CompatibleEnvironmentTemplate { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the new version of a service template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter S3_Key
        /// <summary>
        /// <para>
        /// <para>The path to the S3 bucket that contains a template bundle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_S3_Key")]
        public System.String S3_Key { get; set; }
        #endregion
        
        #region Parameter MajorVersion
        /// <summary>
        /// <para>
        /// <para>To create a new minor version of the service template, include a <c>major Version</c>.</para><para>To create a new major and minor version of the service template, <i>exclude</i><c>major
        /// Version</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MajorVersion { get; set; }
        #endregion
        
        #region Parameter SupportedComponentSource
        /// <summary>
        /// <para>
        /// <para>An array of supported component sources. Components with supported sources can be
        /// attached to service instances based on this service template version.</para><para>For more information about components, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-components.html">Proton
        /// components</a> in the <i>Proton User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportedComponentSources")]
        public System.String[] SupportedComponentSource { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional list of metadata items that you can associate with the Proton service
        /// template version. A tag is a key-value pair.</para><para>For more information, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/resources.html">Proton
        /// resources and tagging</a> in the <i>Proton User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Proton.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the service template.</para>
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
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>When included, if two identical requests are made with the same client token, Proton
        /// returns the service template version that the first request created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceTemplateVersion'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.CreateServiceTemplateVersionResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.CreateServiceTemplateVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceTemplateVersion";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TemplateName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TemplateName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TemplateName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PROServiceTemplateVersion (CreateServiceTemplateVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.CreateServiceTemplateVersionResponse, NewPROServiceTemplateVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TemplateName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            if (this.CompatibleEnvironmentTemplate != null)
            {
                context.CompatibleEnvironmentTemplate = new List<Amazon.Proton.Model.CompatibleEnvironmentTemplateInput>(this.CompatibleEnvironmentTemplate);
            }
            #if MODULAR
            if (this.CompatibleEnvironmentTemplate == null && ParameterWasBound(nameof(this.CompatibleEnvironmentTemplate)))
            {
                WriteWarning("You are passing $null as a value for parameter CompatibleEnvironmentTemplate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.MajorVersion = this.MajorVersion;
            context.S3_Bucket = this.S3_Bucket;
            context.S3_Key = this.S3_Key;
            if (this.SupportedComponentSource != null)
            {
                context.SupportedComponentSource = new List<System.String>(this.SupportedComponentSource);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Proton.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.Proton.Model.CreateServiceTemplateVersionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
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
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.Proton.Model.TemplateVersionSourceInput();
            Amazon.Proton.Model.S3ObjectSource requestSource_source_S3 = null;
            
             // populate S3
            var requestSource_source_S3IsNull = true;
            requestSource_source_S3 = new Amazon.Proton.Model.S3ObjectSource();
            System.String requestSource_source_S3_s3_Bucket = null;
            if (cmdletContext.S3_Bucket != null)
            {
                requestSource_source_S3_s3_Bucket = cmdletContext.S3_Bucket;
            }
            if (requestSource_source_S3_s3_Bucket != null)
            {
                requestSource_source_S3.Bucket = requestSource_source_S3_s3_Bucket;
                requestSource_source_S3IsNull = false;
            }
            System.String requestSource_source_S3_s3_Key = null;
            if (cmdletContext.S3_Key != null)
            {
                requestSource_source_S3_s3_Key = cmdletContext.S3_Key;
            }
            if (requestSource_source_S3_s3_Key != null)
            {
                requestSource_source_S3.Key = requestSource_source_S3_s3_Key;
                requestSource_source_S3IsNull = false;
            }
             // determine if requestSource_source_S3 should be set to null
            if (requestSource_source_S3IsNull)
            {
                requestSource_source_S3 = null;
            }
            if (requestSource_source_S3 != null)
            {
                request.Source.S3 = requestSource_source_S3;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
            }
            if (cmdletContext.SupportedComponentSource != null)
            {
                request.SupportedComponentSources = cmdletContext.SupportedComponentSource;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Proton.Model.CreateServiceTemplateVersionResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.CreateServiceTemplateVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "CreateServiceTemplateVersion");
            try
            {
                #if DESKTOP
                return client.CreateServiceTemplateVersion(request);
                #elif CORECLR
                return client.CreateServiceTemplateVersionAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Proton.Model.CompatibleEnvironmentTemplateInput> CompatibleEnvironmentTemplate { get; set; }
            public System.String Description { get; set; }
            public System.String MajorVersion { get; set; }
            public System.String S3_Bucket { get; set; }
            public System.String S3_Key { get; set; }
            public List<System.String> SupportedComponentSource { get; set; }
            public List<Amazon.Proton.Model.Tag> Tag { get; set; }
            public System.String TemplateName { get; set; }
            public System.Func<Amazon.Proton.Model.CreateServiceTemplateVersionResponse, NewPROServiceTemplateVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceTemplateVersion;
        }
        
    }
}

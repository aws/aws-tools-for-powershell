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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a new version of a launch template. You must specify an existing launch template,
    /// either by name or ID. You can determine whether the new version inherits parameters
    /// from a source version, and add or overwrite parameters as needed.
    /// 
    ///  
    /// <para>
    /// Launch template versions are numbered in the order in which they are created. You
    /// can't specify, change, or replace the numbering of launch template versions.
    /// </para><para>
    /// Launch templates are immutable; after you create a launch template, you can't modify
    /// it. Instead, you can create a new version of the launch template that includes the
    /// changes that you require.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-launch-templates.html#manage-launch-template-versions">Modify
    /// a launch template (manage launch template versions)</a> in the <i>Amazon EC2 User
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2LaunchTemplateVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.LaunchTemplateVersion")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateLaunchTemplateVersion API operation.", Operation = new[] {"CreateLaunchTemplateVersion"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateLaunchTemplateVersionResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.LaunchTemplateVersion or Amazon.EC2.Model.CreateLaunchTemplateVersionResponse",
        "This cmdlet returns an Amazon.EC2.Model.LaunchTemplateVersion object.",
        "The service call response (type Amazon.EC2.Model.CreateLaunchTemplateVersionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2LaunchTemplateVersionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LaunchTemplateData
        /// <summary>
        /// <para>
        /// <para>The information for the launch template.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.EC2.Model.RequestLaunchTemplateData LaunchTemplateData { get; set; }
        #endregion
        
        #region Parameter LaunchTemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template.</para><para>You must specify either the launch template ID or the launch template name, but not
        /// both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplateId { get; set; }
        #endregion
        
        #region Parameter LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the launch template.</para><para>You must specify either the launch template ID or the launch template name, but not
        /// both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter ResolveAlias
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, and if a Systems Manager parameter is specified for <c>ImageId</c>,
        /// the AMI ID is displayed in the response for <c>imageID</c>. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-launch-templates.html#use-an-ssm-parameter-instead-of-an-ami-id">Use
        /// a Systems Manager parameter instead of an AMI ID</a> in the <i>Amazon EC2 User Guide</i>.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ResolveAlias { get; set; }
        #endregion
        
        #region Parameter SourceVersion
        /// <summary>
        /// <para>
        /// <para>The version of the launch template on which to base the new version. Snapshots applied
        /// to the block device mapping are ignored when creating a new version unless they are
        /// explicitly included.</para><para>If you specify this parameter, the new version inherits the launch parameters from
        /// the source version. If you specify additional launch parameters for the new version,
        /// they overwrite any corresponding launch parameters inherited from the source version.</para><para>If you omit this parameter, the new version contains only the launch parameters that
        /// you specify for the new version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceVersion { get; set; }
        #endregion
        
        #region Parameter VersionDescription
        /// <summary>
        /// <para>
        /// <para>A description for the version of the launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionDescription { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para><para>Constraint: Maximum 128 ASCII characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LaunchTemplateVersion'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateLaunchTemplateVersionResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateLaunchTemplateVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LaunchTemplateVersion";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2LaunchTemplateVersion (CreateLaunchTemplateVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateLaunchTemplateVersionResponse, NewEC2LaunchTemplateVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.LaunchTemplateData = this.LaunchTemplateData;
            #if MODULAR
            if (this.LaunchTemplateData == null && ParameterWasBound(nameof(this.LaunchTemplateData)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchTemplateData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LaunchTemplateId = this.LaunchTemplateId;
            context.LaunchTemplateName = this.LaunchTemplateName;
            context.ResolveAlias = this.ResolveAlias;
            context.SourceVersion = this.SourceVersion;
            context.VersionDescription = this.VersionDescription;
            
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
            var request = new Amazon.EC2.Model.CreateLaunchTemplateVersionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.LaunchTemplateData != null)
            {
                request.LaunchTemplateData = cmdletContext.LaunchTemplateData;
            }
            if (cmdletContext.LaunchTemplateId != null)
            {
                request.LaunchTemplateId = cmdletContext.LaunchTemplateId;
            }
            if (cmdletContext.LaunchTemplateName != null)
            {
                request.LaunchTemplateName = cmdletContext.LaunchTemplateName;
            }
            if (cmdletContext.ResolveAlias != null)
            {
                request.ResolveAlias = cmdletContext.ResolveAlias.Value;
            }
            if (cmdletContext.SourceVersion != null)
            {
                request.SourceVersion = cmdletContext.SourceVersion;
            }
            if (cmdletContext.VersionDescription != null)
            {
                request.VersionDescription = cmdletContext.VersionDescription;
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
        
        private Amazon.EC2.Model.CreateLaunchTemplateVersionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateLaunchTemplateVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateLaunchTemplateVersion");
            try
            {
                #if DESKTOP
                return client.CreateLaunchTemplateVersion(request);
                #elif CORECLR
                return client.CreateLaunchTemplateVersionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EC2.Model.RequestLaunchTemplateData LaunchTemplateData { get; set; }
            public System.String LaunchTemplateId { get; set; }
            public System.String LaunchTemplateName { get; set; }
            public System.Boolean? ResolveAlias { get; set; }
            public System.String SourceVersion { get; set; }
            public System.String VersionDescription { get; set; }
            public System.Func<Amazon.EC2.Model.CreateLaunchTemplateVersionResponse, NewEC2LaunchTemplateVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LaunchTemplateVersion;
        }
        
    }
}

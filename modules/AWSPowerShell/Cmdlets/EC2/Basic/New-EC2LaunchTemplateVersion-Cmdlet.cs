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
    /// Creates a new version for a launch template. You can specify an existing version of
    /// launch template from which to base the new version.
    /// 
    ///  
    /// <para>
    /// Launch template versions are numbered in the order in which they are created. You
    /// cannot specify, change, or replace the numbering of launch template versions.
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
        /// <para>The ID of the launch template. You must specify either the launch template ID or launch
        /// template name in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplateId { get; set; }
        #endregion
        
        #region Parameter LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the launch template. You must specify either the launch template ID or
        /// launch template name in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter SourceVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the launch template version on which to base the new version.
        /// The new version inherits the same launch parameters as the source version, except
        /// for parameters that you specify in <code>LaunchTemplateData</code>. Snapshots applied
        /// to the block device mapping are ignored when creating a new version unless they are
        /// explicitly included.</para>
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
        /// Idempotency</a>.</para><para>Constraint: Maximum 128 ASCII characters.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LaunchTemplateData parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LaunchTemplateData' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LaunchTemplateData' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2LaunchTemplateVersion (CreateLaunchTemplateVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateLaunchTemplateVersionResponse, NewEC2LaunchTemplateVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LaunchTemplateData;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            public System.String SourceVersion { get; set; }
            public System.String VersionDescription { get; set; }
            public System.Func<Amazon.EC2.Model.CreateLaunchTemplateVersionResponse, NewEC2LaunchTemplateVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LaunchTemplateVersion;
        }
        
    }
}

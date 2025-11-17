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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Creates a custom WorkSpaces Applications image by importing an EC2 AMI. This allows
    /// you to use your own customized AMI to create WorkSpaces Applications images that support
    /// additional instance types beyond the standard stream.* instances.
    /// </summary>
    [Cmdlet("New", "APSImportedImage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.Image")]
    [AWSCmdlet("Calls the Amazon AppStream CreateImportedImage API operation.", Operation = new[] {"CreateImportedImage"}, SelectReturnType = typeof(Amazon.AppStream.Model.CreateImportedImageResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.Image or Amazon.AppStream.Model.CreateImportedImageResponse",
        "This cmdlet returns an Amazon.AppStream.Model.Image object.",
        "The service call response (type Amazon.AppStream.Model.CreateImportedImageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAPSImportedImageCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentSoftwareVersion
        /// <summary>
        /// <para>
        /// <para>The version of the WorkSpaces Applications agent to use for the imported image. Choose
        /// CURRENT_LATEST to use the agent version available at the time of import, or ALWAYS_LATEST
        /// to automatically update to the latest agent version when new versions are released.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.AgentSoftwareVersion")]
        public Amazon.AppStream.AgentSoftwareVersion AgentSoftwareVersion { get; set; }
        #endregion
        
        #region Parameter AppCatalogConfig
        /// <summary>
        /// <para>
        /// <para>Configuration for the application catalog of the imported image. This allows you to
        /// specify applications available for streaming, including their paths, icons, and launch
        /// parameters. This field contains sensitive data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AppStream.Model.ApplicationConfig[] AppCatalogConfig { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the imported image. The description must match approved
        /// regex patterns and can be up to 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>An optional display name for the imported image. The display name must match approved
        /// regex patterns and can be up to 100 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>When set to true, performs validation checks without actually creating the imported
        /// image. Use this to verify your configuration before executing the actual import operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that allows WorkSpaces Applications to access your AMI. The
        /// role must have permissions to modify image attributes and describe images, with a
        /// trust relationship allowing appstream.amazonaws.com to assume the role.</para>
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
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter RuntimeValidationConfig_IntendedInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type to use for runtime validation testing. It's recommended to use the
        /// same instance type you plan to use for your fleet to ensure accurate validation results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuntimeValidationConfig_IntendedInstanceType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A unique name for the imported image. The name must be between 1 and 100 characters
        /// and can contain letters, numbers, underscores, periods, and hyphens.</para>
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
        
        #region Parameter SourceAmiId
        /// <summary>
        /// <para>
        /// <para>The ID of the EC2 AMI to import. The AMI must meet specific requirements including
        /// Windows Server 2022 Full Base, UEFI boot mode, TPM 2.0 support, and proper drivers.</para>
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
        public System.String SourceAmiId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the imported image. Tags help you organize and manage your WorkSpaces
        /// Applications resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Image'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.CreateImportedImageResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.CreateImportedImageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Image";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.SourceAmiId),
                nameof(this.Name),
                nameof(this.IamRoleArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSImportedImage (CreateImportedImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.CreateImportedImageResponse, NewAPSImportedImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentSoftwareVersion = this.AgentSoftwareVersion;
            if (this.AppCatalogConfig != null)
            {
                context.AppCatalogConfig = new List<Amazon.AppStream.Model.ApplicationConfig>(this.AppCatalogConfig);
            }
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.DryRun = this.DryRun;
            context.IamRoleArn = this.IamRoleArn;
            #if MODULAR
            if (this.IamRoleArn == null && ParameterWasBound(nameof(this.IamRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IamRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuntimeValidationConfig_IntendedInstanceType = this.RuntimeValidationConfig_IntendedInstanceType;
            context.SourceAmiId = this.SourceAmiId;
            #if MODULAR
            if (this.SourceAmiId == null && ParameterWasBound(nameof(this.SourceAmiId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceAmiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.AppStream.Model.CreateImportedImageRequest();
            
            if (cmdletContext.AgentSoftwareVersion != null)
            {
                request.AgentSoftwareVersion = cmdletContext.AgentSoftwareVersion;
            }
            if (cmdletContext.AppCatalogConfig != null)
            {
                request.AppCatalogConfig = cmdletContext.AppCatalogConfig;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate RuntimeValidationConfig
            var requestRuntimeValidationConfigIsNull = true;
            request.RuntimeValidationConfig = new Amazon.AppStream.Model.RuntimeValidationConfig();
            System.String requestRuntimeValidationConfig_runtimeValidationConfig_IntendedInstanceType = null;
            if (cmdletContext.RuntimeValidationConfig_IntendedInstanceType != null)
            {
                requestRuntimeValidationConfig_runtimeValidationConfig_IntendedInstanceType = cmdletContext.RuntimeValidationConfig_IntendedInstanceType;
            }
            if (requestRuntimeValidationConfig_runtimeValidationConfig_IntendedInstanceType != null)
            {
                request.RuntimeValidationConfig.IntendedInstanceType = requestRuntimeValidationConfig_runtimeValidationConfig_IntendedInstanceType;
                requestRuntimeValidationConfigIsNull = false;
            }
             // determine if request.RuntimeValidationConfig should be set to null
            if (requestRuntimeValidationConfigIsNull)
            {
                request.RuntimeValidationConfig = null;
            }
            if (cmdletContext.SourceAmiId != null)
            {
                request.SourceAmiId = cmdletContext.SourceAmiId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.AppStream.Model.CreateImportedImageResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateImportedImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "CreateImportedImage");
            try
            {
                #if DESKTOP
                return client.CreateImportedImage(request);
                #elif CORECLR
                return client.CreateImportedImageAsync(request).GetAwaiter().GetResult();
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
            public Amazon.AppStream.AgentSoftwareVersion AgentSoftwareVersion { get; set; }
            public List<Amazon.AppStream.Model.ApplicationConfig> AppCatalogConfig { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String Name { get; set; }
            public System.String RuntimeValidationConfig_IntendedInstanceType { get; set; }
            public System.String SourceAmiId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AppStream.Model.CreateImportedImageResponse, NewAPSImportedImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Image;
        }
        
    }
}

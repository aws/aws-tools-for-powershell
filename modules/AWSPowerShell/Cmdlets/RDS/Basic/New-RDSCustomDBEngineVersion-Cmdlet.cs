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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates a custom DB engine version (CEV).
    /// </summary>
    [Cmdlet("New", "RDSCustomDBEngineVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.CreateCustomDBEngineVersionResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateCustomDBEngineVersion API operation.", Operation = new[] {"CreateCustomDBEngineVersion"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateCustomDBEngineVersionResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.CreateCustomDBEngineVersionResponse",
        "This cmdlet returns an Amazon.RDS.Model.CreateCustomDBEngineVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRDSCustomDBEngineVersionCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatabaseInstallationFilesS3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of an Amazon S3 bucket that contains database installation files for your
        /// CEV. For example, a valid bucket name is <c>my-custom-installation-files</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseInstallationFilesS3BucketName { get; set; }
        #endregion
        
        #region Parameter DatabaseInstallationFilesS3Prefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 directory that contains the database installation files for your CEV.
        /// For example, a valid bucket name is <c>123456789012/cev1</c>. If this setting isn't
        /// specified, no prefix is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseInstallationFilesS3Prefix { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of your CEV.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The database engine to use for your custom engine version (CEV). The only supported
        /// value is <c>custom-oracle-ee</c>.</para>
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
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The name of your CEV. The name format is 19.<i>customized_string</i>. For example,
        /// a valid CEV name is <c>19.my_cev1</c>. This setting is required for RDS Custom for
        /// Oracle, but optional for Amazon RDS. The combination of <c>Engine</c> and <c>EngineVersion</c>
        /// is unique per customer per Region.</para>
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
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Machine Image (AMI). For RDS Custom for SQL Server, an AMI ID
        /// is required to create a CEV. For RDS Custom for Oracle, the default is the most recent
        /// AMI available, but you can specify an AMI ID that was used in a different Oracle CEV.
        /// Find the AMIs used by your CEVs by calling the <a href="https://docs.aws.amazon.com/AmazonRDS/latest/APIReference/API_DescribeDBEngineVersions.html">DescribeDBEngineVersions</a>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageId { get; set; }
        #endregion
        
        #region Parameter KMSKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier for an encrypted CEV. A symmetric encryption
        /// KMS key is required for RDS Custom, but optional for Amazon RDS.</para><para>If you have an existing symmetric encryption KMS key in your account, you can use
        /// it with RDS Custom. No further action is necessary. If you don't already have a symmetric
        /// encryption KMS key in your account, follow the instructions in <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-keys.html#create-symmetric-cmk">
        /// Creating a symmetric encryption KMS key</a> in the <i>Amazon Web Services Key Management
        /// Service Developer Guide</i>.</para><para>You can choose the same symmetric encryption key when you create a CEV and a DB instance,
        /// or choose different keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKeyId { get; set; }
        #endregion
        
        #region Parameter Manifest
        /// <summary>
        /// <para>
        /// <para>The CEV manifest, which is a JSON document that describes the installation .zip files
        /// stored in Amazon S3. Specify the name/value pairs in a file or a quoted string. RDS
        /// Custom applies the patches in the order in which they are listed.</para><para>The following JSON fields are valid:</para><dl><dt>MediaImportTemplateVersion</dt><dd><para>Version of the CEV manifest. The date is in the format <c>YYYY-MM-DD</c>.</para></dd><dt>databaseInstallationFileNames</dt><dd><para>Ordered list of installation files for the CEV.</para></dd><dt>opatchFileNames</dt><dd><para>Ordered list of OPatch installers used for the Oracle DB engine.</para></dd><dt>psuRuPatchFileNames</dt><dd><para>The PSU and RU patches for this CEV.</para></dd><dt>OtherPatchFileNames</dt><dd><para>The patches that are not in the list of PSU and RU patches. Amazon RDS applies these
        /// patches after applying the PSU and RU patches.</para></dd></dl><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/custom-cev.html#custom-cev.preparing.manifest">
        /// Creating the CEV manifest</a> in the <i>Amazon RDS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Manifest { get; set; }
        #endregion
        
        #region Parameter SourceCustomDbEngineVersionIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN of a CEV to use as a source for creating a new CEV. You can specify a different
        /// Amazon Machine Imagine (AMI) by using either <c>Source</c> or <c>UseAwsProvidedLatestImage</c>.
        /// You can't specify a different JSON manifest when you specify <c>SourceCustomDbEngineVersionIdentifier</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceCustomDbEngineVersionIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UseAwsProvidedLatestImage
        /// <summary>
        /// <para>
        /// <para>Specifies whether to use the latest service-provided Amazon Machine Image (AMI) for
        /// the CEV. If you specify <c>UseAwsProvidedLatestImage</c>, you can't also specify <c>ImageId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseAwsProvidedLatestImage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateCustomDBEngineVersionResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateCustomDBEngineVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSCustomDBEngineVersion (CreateCustomDBEngineVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateCustomDBEngineVersionResponse, NewRDSCustomDBEngineVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatabaseInstallationFilesS3BucketName = this.DatabaseInstallationFilesS3BucketName;
            context.DatabaseInstallationFilesS3Prefix = this.DatabaseInstallationFilesS3Prefix;
            context.Description = this.Description;
            context.Engine = this.Engine;
            #if MODULAR
            if (this.Engine == null && ParameterWasBound(nameof(this.Engine)))
            {
                WriteWarning("You are passing $null as a value for parameter Engine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngineVersion = this.EngineVersion;
            #if MODULAR
            if (this.EngineVersion == null && ParameterWasBound(nameof(this.EngineVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter EngineVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageId = this.ImageId;
            context.KMSKeyId = this.KMSKeyId;
            context.Manifest = this.Manifest;
            context.SourceCustomDbEngineVersionIdentifier = this.SourceCustomDbEngineVersionIdentifier;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.UseAwsProvidedLatestImage = this.UseAwsProvidedLatestImage;
            
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
            var request = new Amazon.RDS.Model.CreateCustomDBEngineVersionRequest();
            
            if (cmdletContext.DatabaseInstallationFilesS3BucketName != null)
            {
                request.DatabaseInstallationFilesS3BucketName = cmdletContext.DatabaseInstallationFilesS3BucketName;
            }
            if (cmdletContext.DatabaseInstallationFilesS3Prefix != null)
            {
                request.DatabaseInstallationFilesS3Prefix = cmdletContext.DatabaseInstallationFilesS3Prefix;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.ImageId != null)
            {
                request.ImageId = cmdletContext.ImageId;
            }
            if (cmdletContext.KMSKeyId != null)
            {
                request.KMSKeyId = cmdletContext.KMSKeyId;
            }
            if (cmdletContext.Manifest != null)
            {
                request.Manifest = cmdletContext.Manifest;
            }
            if (cmdletContext.SourceCustomDbEngineVersionIdentifier != null)
            {
                request.SourceCustomDbEngineVersionIdentifier = cmdletContext.SourceCustomDbEngineVersionIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UseAwsProvidedLatestImage != null)
            {
                request.UseAwsProvidedLatestImage = cmdletContext.UseAwsProvidedLatestImage.Value;
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
        
        private Amazon.RDS.Model.CreateCustomDBEngineVersionResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateCustomDBEngineVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateCustomDBEngineVersion");
            try
            {
                #if DESKTOP
                return client.CreateCustomDBEngineVersion(request);
                #elif CORECLR
                return client.CreateCustomDBEngineVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String DatabaseInstallationFilesS3BucketName { get; set; }
            public System.String DatabaseInstallationFilesS3Prefix { get; set; }
            public System.String Description { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String ImageId { get; set; }
            public System.String KMSKeyId { get; set; }
            public System.String Manifest { get; set; }
            public System.String SourceCustomDbEngineVersionIdentifier { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.Boolean? UseAwsProvidedLatestImage { get; set; }
            public System.Func<Amazon.RDS.Model.CreateCustomDBEngineVersionResponse, NewRDSCustomDBEngineVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

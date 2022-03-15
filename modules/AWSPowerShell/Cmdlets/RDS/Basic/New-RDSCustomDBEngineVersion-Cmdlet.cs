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
    /// Creates a custom DB engine version (CEV). A CEV is a binary volume snapshot of a database
    /// engine and specific AMI. The supported engines are the following:
    /// 
    ///  <ul><li><para>
    /// Oracle Database 12.1 Enterprise Edition with the January 2021 or later RU/RUR
    /// </para></li><li><para>
    /// Oracle Database 19c Enterprise Edition with the January 2021 or later RU/RUR
    /// </para></li></ul><para>
    /// Amazon RDS, which is a fully managed service, supplies the Amazon Machine Image (AMI)
    /// and database software. The Amazon RDS database software is preinstalled, so you need
    /// only select a DB engine and version, and create your database. With Amazon RDS Custom
    /// for Oracle, you upload your database installation files in Amazon S3.
    /// </para><para>
    /// When you create a custom engine version, you specify the files in a JSON document
    /// called a CEV manifest. This document describes installation .zip files stored in Amazon
    /// S3. RDS Custom creates your CEV from the installation files that you provided. This
    /// service model is called Bring Your Own Media (BYOM).
    /// </para><para>
    /// Creation takes approximately two hours. If creation fails, RDS Custom issues <code>RDS-EVENT-0196</code>
    /// with the message <code>Creation failed for custom engine version</code>, and includes
    /// details about the failure. For example, the event prints missing files.
    /// </para><para>
    /// After you create the CEV, it is available for use. You can create multiple CEVs, and
    /// create multiple RDS Custom instances from any CEV. You can also change the status
    /// of a CEV to make it available or inactive.
    /// </para><note><para>
    /// The MediaImport service that imports files from Amazon S3 to create CEVs isn't integrated
    /// with Amazon Web Services CloudTrail. If you turn on data logging for Amazon RDS in
    /// CloudTrail, calls to the <code>CreateCustomDbEngineVersion</code> event aren't logged.
    /// However, you might see calls from the API gateway that accesses your Amazon S3 bucket.
    /// These calls originate from the MediaImport service for the <code>CreateCustomDbEngineVersion</code>
    /// event.
    /// </para></note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/custom-cev.html#custom-cev.create">
    /// Creating a CEV</a> in the <i>Amazon RDS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "RDSCustomDBEngineVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.CreateCustomDBEngineVersionResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateCustomDBEngineVersion API operation.", Operation = new[] {"CreateCustomDBEngineVersion"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateCustomDBEngineVersionResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.CreateCustomDBEngineVersionResponse",
        "This cmdlet returns an Amazon.RDS.Model.CreateCustomDBEngineVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRDSCustomDBEngineVersionCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DatabaseInstallationFilesS3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of an Amazon S3 bucket that contains database installation files for your
        /// CEV. For example, a valid bucket name is <code>my-custom-installation-files</code>.</para>
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
        public System.String DatabaseInstallationFilesS3BucketName { get; set; }
        #endregion
        
        #region Parameter DatabaseInstallationFilesS3Prefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 directory that contains the database installation files for your CEV.
        /// For example, a valid bucket name is <code>123456789012/cev1</code>. If this setting
        /// isn't specified, no prefix is assumed.</para>
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
        /// value is <code>custom-oracle-ee</code>.</para>
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
        /// <para>The name of your CEV. The name format is <code>19.<i>customized_string</i></code>.
        /// For example, a valid name is <code>19.my_cev1</code>. This setting is required for
        /// RDS Custom for Oracle, but optional for Amazon RDS. The combination of <code>Engine</code>
        /// and <code>EngineVersion</code> is unique per customer per Region.</para>
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
        
        #region Parameter KMSKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier for an encrypted CEV. A symmetric KMS key
        /// is required for RDS Custom, but optional for Amazon RDS.</para><para>If you have an existing symmetric KMS key in your account, you can use it with RDS
        /// Custom. No further action is necessary. If you don't already have a symmetric KMS
        /// key in your account, follow the instructions in <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-keys.html#create-symmetric-cmk">
        /// Creating symmetric KMS keys</a> in the <i>Amazon Web Services Key Management Service
        /// Developer Guide</i>.</para><para>You can choose the same symmetric key when you create a CEV and a DB instance, or
        /// choose different keys.</para>
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
        public System.String KMSKeyId { get; set; }
        #endregion
        
        #region Parameter Manifest
        /// <summary>
        /// <para>
        /// <para>The CEV manifest, which is a JSON document that describes the installation .zip files
        /// stored in Amazon S3. Specify the name/value pairs in a file or a quoted string. RDS
        /// Custom applies the patches in the order in which they are listed.</para><para>The following JSON fields are valid:</para><dl><dt>MediaImportTemplateVersion</dt><dd><para>Version of the CEV manifest. The date is in the format <code>YYYY-MM-DD</code>.</para></dd><dt>databaseInstallationFileNames</dt><dd><para>Ordered list of installation files for the CEV.</para></dd><dt>opatchFileNames</dt><dd><para>Ordered list of OPatch installers used for the Oracle DB engine.</para></dd><dt>psuRuPatchFileNames</dt><dd><para>The PSU and RU patches for this CEV.</para></dd><dt>OtherPatchFileNames</dt><dd><para>The patches that are not in the list of PSU and RU patches. Amazon RDS applies these
        /// patches after applying the PSU and RU patches.</para></dd></dl><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/custom-cev.html#custom-cev.preparing.manifest">
        /// Creating the CEV manifest</a> in the <i>Amazon RDS User Guide</i>.</para>
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
        public System.String Manifest { get; set; }
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
            #if MODULAR
            if (this.DatabaseInstallationFilesS3BucketName == null && ParameterWasBound(nameof(this.DatabaseInstallationFilesS3BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseInstallationFilesS3BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.KMSKeyId = this.KMSKeyId;
            #if MODULAR
            if (this.KMSKeyId == null && ParameterWasBound(nameof(this.KMSKeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KMSKeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Manifest = this.Manifest;
            #if MODULAR
            if (this.Manifest == null && ParameterWasBound(nameof(this.Manifest)))
            {
                WriteWarning("You are passing $null as a value for parameter Manifest which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
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
            if (cmdletContext.KMSKeyId != null)
            {
                request.KMSKeyId = cmdletContext.KMSKeyId;
            }
            if (cmdletContext.Manifest != null)
            {
                request.Manifest = cmdletContext.Manifest;
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
            public System.String KMSKeyId { get; set; }
            public System.String Manifest { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.RDS.Model.CreateCustomDBEngineVersionResponse, NewRDSCustomDBEngineVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Creates an Amazon FSx for Lustre data repository association (DRA). A data repository
    /// association is a link between a directory on the file system and an Amazon S3 bucket
    /// or prefix. You can have a maximum of 8 data repository associations on a file system.
    /// Data repository associations are supported on all FSx for Lustre 2.12 and 2.15 file
    /// systems, excluding <c>scratch_1</c> deployment type.
    /// 
    ///  
    /// <para>
    /// Each data repository association must have a unique Amazon FSx file system directory
    /// and a unique S3 bucket or prefix associated with it. You can configure a data repository
    /// association for automatic import only, for automatic export only, or for both. To
    /// learn more about linking a data repository to your file system, see <a href="https://docs.aws.amazon.com/fsx/latest/LustreGuide/create-dra-linked-data-repo.html">Linking
    /// your file system to an S3 bucket</a>.
    /// </para><note><para><c>CreateDataRepositoryAssociation</c> isn't supported on Amazon File Cache resources.
    /// To create a DRA on Amazon File Cache, use the <c>CreateFileCache</c> operation.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "FSXDataRepositoryAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.DataRepositoryAssociation")]
    [AWSCmdlet("Calls the Amazon FSx CreateDataRepositoryAssociation API operation.", Operation = new[] {"CreateDataRepositoryAssociation"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateDataRepositoryAssociationResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.DataRepositoryAssociation or Amazon.FSx.Model.CreateDataRepositoryAssociationResponse",
        "This cmdlet returns an Amazon.FSx.Model.DataRepositoryAssociation object.",
        "The service call response (type Amazon.FSx.Model.CreateDataRepositoryAssociationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFSXDataRepositoryAssociationCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BatchImportMetaDataOnCreate
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to run an import data repository task to import metadata from the
        /// data repository to the file system after the data repository association is created.
        /// Default is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BatchImportMetaDataOnCreate { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DataRepositoryPath
        /// <summary>
        /// <para>
        /// <para>The path to the Amazon S3 data repository that will be linked to the file system.
        /// The path can be an S3 bucket or prefix in the format <c>s3://bucket-name/prefix/</c>
        /// (where <c>prefix</c> is optional). This path specifies where in the S3 data repository
        /// files will be imported from or exported to.</para>
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
        public System.String DataRepositoryPath { get; set; }
        #endregion
        
        #region Parameter AutoExportPolicy_Event
        /// <summary>
        /// <para>
        /// <para>The <c>AutoExportPolicy</c> can have the following event values:</para><ul><li><para><c>NEW</c> - New files and directories are automatically exported to the data repository
        /// as they are added to the file system.</para></li><li><para><c>CHANGED</c> - Changes to files and directories on the file system are automatically
        /// exported to the data repository.</para></li><li><para><c>DELETED</c> - Files and directories are automatically deleted on the data repository
        /// when they are deleted on the file system.</para></li></ul><para>You can define any combination of event types for your <c>AutoExportPolicy</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3_AutoExportPolicy_Events")]
        public System.String[] AutoExportPolicy_Event { get; set; }
        #endregion
        
        #region Parameter AutoImportPolicy_Event
        /// <summary>
        /// <para>
        /// <para>The <c>AutoImportPolicy</c> can have the following event values:</para><ul><li><para><c>NEW</c> - Amazon FSx automatically imports metadata of files added to the linked
        /// S3 bucket that do not currently exist in the FSx file system.</para></li><li><para><c>CHANGED</c> - Amazon FSx automatically updates file metadata and invalidates existing
        /// file content on the file system as files change in the data repository.</para></li><li><para><c>DELETED</c> - Amazon FSx automatically deletes files on the file system as corresponding
        /// files are deleted in the data repository.</para></li></ul><para>You can define any combination of event types for your <c>AutoImportPolicy</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3_AutoImportPolicy_Events")]
        public System.String[] AutoImportPolicy_Event { get; set; }
        #endregion
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter FileSystemPath
        /// <summary>
        /// <para>
        /// <para>A path on the file system that points to a high-level directory (such as <c>/ns1/</c>)
        /// or subdirectory (such as <c>/ns1/subdir/</c>) that will be mapped 1-1 with <c>DataRepositoryPath</c>.
        /// The leading forward slash in the name is required. Two data repository associations
        /// cannot have overlapping file system paths. For example, if a data repository is associated
        /// with file system path <c>/ns1/</c>, then you cannot link another data repository with
        /// file system path <c>/ns1/ns2</c>.</para><para>This path specifies where in your file system files will be exported from or imported
        /// to. This file system directory can be linked to only one Amazon S3 bucket, and no
        /// other S3 bucket can be linked to the directory.</para><note><para>If you specify only a forward slash (<c>/</c>) as the file system path, you can link
        /// only one data repository to the file system. You can only specify "/" as the file
        /// system path for the first data repository associated with a file system.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FileSystemPath { get; set; }
        #endregion
        
        #region Parameter ImportedFileChunkSize
        /// <summary>
        /// <para>
        /// <para>For files imported from a data repository, this value determines the stripe count
        /// and maximum amount of data per file (in MiB) stored on a single physical disk. The
        /// maximum number of disks that a single file can be striped across is limited by the
        /// total number of disks that make up the file system.</para><para>The default chunk size is 1,024 MiB (1 GiB) and can go as high as 512,000 MiB (500
        /// GiB). Amazon S3 objects have a maximum size of 5 TB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ImportedFileChunkSize { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Association'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateDataRepositoryAssociationResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateDataRepositoryAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Association";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXDataRepositoryAssociation (CreateDataRepositoryAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateDataRepositoryAssociationResponse, NewFSXDataRepositoryAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BatchImportMetaDataOnCreate = this.BatchImportMetaDataOnCreate;
            context.ClientRequestToken = this.ClientRequestToken;
            context.DataRepositoryPath = this.DataRepositoryPath;
            #if MODULAR
            if (this.DataRepositoryPath == null && ParameterWasBound(nameof(this.DataRepositoryPath)))
            {
                WriteWarning("You are passing $null as a value for parameter DataRepositoryPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileSystemPath = this.FileSystemPath;
            context.ImportedFileChunkSize = this.ImportedFileChunkSize;
            if (this.AutoExportPolicy_Event != null)
            {
                context.AutoExportPolicy_Event = new List<System.String>(this.AutoExportPolicy_Event);
            }
            if (this.AutoImportPolicy_Event != null)
            {
                context.AutoImportPolicy_Event = new List<System.String>(this.AutoImportPolicy_Event);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FSx.Model.Tag>(this.Tag);
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
            var request = new Amazon.FSx.Model.CreateDataRepositoryAssociationRequest();
            
            if (cmdletContext.BatchImportMetaDataOnCreate != null)
            {
                request.BatchImportMetaDataOnCreate = cmdletContext.BatchImportMetaDataOnCreate.Value;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DataRepositoryPath != null)
            {
                request.DataRepositoryPath = cmdletContext.DataRepositoryPath;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.FileSystemPath != null)
            {
                request.FileSystemPath = cmdletContext.FileSystemPath;
            }
            if (cmdletContext.ImportedFileChunkSize != null)
            {
                request.ImportedFileChunkSize = cmdletContext.ImportedFileChunkSize.Value;
            }
            
             // populate S3
            var requestS3IsNull = true;
            request.S3 = new Amazon.FSx.Model.S3DataRepositoryConfiguration();
            Amazon.FSx.Model.AutoExportPolicy requestS3_s3_AutoExportPolicy = null;
            
             // populate AutoExportPolicy
            var requestS3_s3_AutoExportPolicyIsNull = true;
            requestS3_s3_AutoExportPolicy = new Amazon.FSx.Model.AutoExportPolicy();
            List<System.String> requestS3_s3_AutoExportPolicy_autoExportPolicy_Event = null;
            if (cmdletContext.AutoExportPolicy_Event != null)
            {
                requestS3_s3_AutoExportPolicy_autoExportPolicy_Event = cmdletContext.AutoExportPolicy_Event;
            }
            if (requestS3_s3_AutoExportPolicy_autoExportPolicy_Event != null)
            {
                requestS3_s3_AutoExportPolicy.Events = requestS3_s3_AutoExportPolicy_autoExportPolicy_Event;
                requestS3_s3_AutoExportPolicyIsNull = false;
            }
             // determine if requestS3_s3_AutoExportPolicy should be set to null
            if (requestS3_s3_AutoExportPolicyIsNull)
            {
                requestS3_s3_AutoExportPolicy = null;
            }
            if (requestS3_s3_AutoExportPolicy != null)
            {
                request.S3.AutoExportPolicy = requestS3_s3_AutoExportPolicy;
                requestS3IsNull = false;
            }
            Amazon.FSx.Model.AutoImportPolicy requestS3_s3_AutoImportPolicy = null;
            
             // populate AutoImportPolicy
            var requestS3_s3_AutoImportPolicyIsNull = true;
            requestS3_s3_AutoImportPolicy = new Amazon.FSx.Model.AutoImportPolicy();
            List<System.String> requestS3_s3_AutoImportPolicy_autoImportPolicy_Event = null;
            if (cmdletContext.AutoImportPolicy_Event != null)
            {
                requestS3_s3_AutoImportPolicy_autoImportPolicy_Event = cmdletContext.AutoImportPolicy_Event;
            }
            if (requestS3_s3_AutoImportPolicy_autoImportPolicy_Event != null)
            {
                requestS3_s3_AutoImportPolicy.Events = requestS3_s3_AutoImportPolicy_autoImportPolicy_Event;
                requestS3_s3_AutoImportPolicyIsNull = false;
            }
             // determine if requestS3_s3_AutoImportPolicy should be set to null
            if (requestS3_s3_AutoImportPolicyIsNull)
            {
                requestS3_s3_AutoImportPolicy = null;
            }
            if (requestS3_s3_AutoImportPolicy != null)
            {
                request.S3.AutoImportPolicy = requestS3_s3_AutoImportPolicy;
                requestS3IsNull = false;
            }
             // determine if request.S3 should be set to null
            if (requestS3IsNull)
            {
                request.S3 = null;
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
        
        private Amazon.FSx.Model.CreateDataRepositoryAssociationResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateDataRepositoryAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateDataRepositoryAssociation");
            try
            {
                #if DESKTOP
                return client.CreateDataRepositoryAssociation(request);
                #elif CORECLR
                return client.CreateDataRepositoryAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? BatchImportMetaDataOnCreate { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String DataRepositoryPath { get; set; }
            public System.String FileSystemId { get; set; }
            public System.String FileSystemPath { get; set; }
            public System.Int32? ImportedFileChunkSize { get; set; }
            public List<System.String> AutoExportPolicy_Event { get; set; }
            public List<System.String> AutoImportPolicy_Event { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.FSx.Model.CreateDataRepositoryAssociationResponse, NewFSXDataRepositoryAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Association;
        }
        
    }
}

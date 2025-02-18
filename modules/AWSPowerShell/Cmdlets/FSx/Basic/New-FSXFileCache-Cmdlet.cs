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
using System.Threading;
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Creates a new Amazon File Cache resource.
    /// 
    ///  
    /// <para>
    /// You can use this operation with a client request token in the request that Amazon
    /// File Cache uses to ensure idempotent creation. If a cache with the specified client
    /// request token exists and the parameters match, <c>CreateFileCache</c> returns the
    /// description of the existing cache. If a cache with the specified client request token
    /// exists and the parameters don't match, this call returns <c>IncompatibleParameterError</c>.
    /// If a file cache with the specified client request token doesn't exist, <c>CreateFileCache</c>
    /// does the following: 
    /// </para><ul><li><para>
    /// Creates a new, empty Amazon File Cache resourcewith an assigned ID, and an initial
    /// lifecycle state of <c>CREATING</c>.
    /// </para></li><li><para>
    /// Returns the description of the cache in JSON format.
    /// </para></li></ul><note><para>
    /// The <c>CreateFileCache</c> call returns while the cache's lifecycle state is still
    /// <c>CREATING</c>. You can check the cache creation status by calling the <a href="https://docs.aws.amazon.com/fsx/latest/APIReference/API_DescribeFileCaches.html">DescribeFileCaches</a>
    /// operation, which returns the cache state along with other information.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "FSXFileCache", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.FileCacheCreating")]
    [AWSCmdlet("Calls the Amazon FSx CreateFileCache API operation.", Operation = new[] {"CreateFileCache"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateFileCacheResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.FileCacheCreating or Amazon.FSx.Model.CreateFileCacheResponse",
        "This cmdlet returns an Amazon.FSx.Model.FileCacheCreating object.",
        "The service call response (type Amazon.FSx.Model.CreateFileCacheResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewFSXFileCacheCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token for resource creation, in a string of up to 63 ASCII characters.
        /// This token is automatically filled on your behalf when you use the Command Line Interface
        /// (CLI) or an Amazon Web Services SDK.</para><para>By using the idempotent operation, you can retry a <c>CreateFileCache</c> operation
        /// without the risk of creating an extra cache. This approach can be useful when an initial
        /// call fails in a way that makes it unclear whether a cache was created. Examples are
        /// if a transport level timeout occurred, or your connection was reset. If you use the
        /// same client request token and the initial call created a cache, the client receives
        /// success as long as the parameters are the same.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter CopyTagsToDataRepositoryAssociation
        /// <summary>
        /// <para>
        /// <para>A boolean flag indicating whether tags for the cache should be copied to data repository
        /// associations. This value defaults to false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyTagsToDataRepositoryAssociations")]
        public System.Boolean? CopyTagsToDataRepositoryAssociation { get; set; }
        #endregion
        
        #region Parameter DataRepositoryAssociation
        /// <summary>
        /// <para>
        /// <para>A list of up to 8 configurations for data repository associations (DRAs) to be created
        /// during the cache creation. The DRAs link the cache to either an Amazon S3 data repository
        /// or a Network File System (NFS) data repository that supports the NFSv3 protocol.</para><para>The DRA configurations must meet the following requirements:</para><ul><li><para>All configurations on the list must be of the same data repository type, either all
        /// S3 or all NFS. A cache can't link to different data repository types at the same time.</para></li><li><para>An NFS DRA must link to an NFS file system that supports the NFSv3 protocol.</para></li></ul><para>DRA automatic import and automatic export is not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataRepositoryAssociations")]
        public Amazon.FSx.Model.FileCacheDataRepositoryAssociation[] DataRepositoryAssociation { get; set; }
        #endregion
        
        #region Parameter LustreConfiguration_DeploymentType
        /// <summary>
        /// <para>
        /// <para>Specifies the cache deployment type, which must be <c>CACHE_1</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.FileCacheLustreDeploymentType")]
        public Amazon.FSx.FileCacheLustreDeploymentType LustreConfiguration_DeploymentType { get; set; }
        #endregion
        
        #region Parameter FileCacheType
        /// <summary>
        /// <para>
        /// <para>The type of cache that you're creating, which must be <c>LUSTRE</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FSx.FileCacheType")]
        public Amazon.FSx.FileCacheType FileCacheType { get; set; }
        #endregion
        
        #region Parameter FileCacheTypeVersion
        /// <summary>
        /// <para>
        /// <para>Sets the Lustre version for the cache that you're creating, which must be <c>2.12</c>.</para>
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
        public System.String FileCacheTypeVersion { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the Key Management Service (KMS) key to use for encrypting data
        /// on an Amazon File Cache. If a <c>KmsKeyId</c> isn't specified, the Amazon FSx-managed
        /// KMS key for your account is used. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_Encrypt.html">Encrypt</a>
        /// in the <i>Key Management Service API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LustreConfiguration_PerUnitStorageThroughput
        /// <summary>
        /// <para>
        /// <para>Provisions the amount of read and write throughput for each 1 tebibyte (TiB) of cache
        /// storage capacity, in MB/s/TiB. The only supported value is <c>1000</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LustreConfiguration_PerUnitStorageThroughput { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of IDs specifying the security groups to apply to all network interfaces created
        /// for Amazon File Cache access. This list isn't returned in later requests to describe
        /// the cache.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter MetadataConfiguration_StorageCapacity
        /// <summary>
        /// <para>
        /// <para>The storage capacity of the Lustre MDT (Metadata Target) storage volume in gibibytes
        /// (GiB). The only supported value is <c>2400</c> GiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LustreConfiguration_MetadataConfiguration_StorageCapacity")]
        public System.Int32? MetadataConfiguration_StorageCapacity { get; set; }
        #endregion
        
        #region Parameter StorageCapacity
        /// <summary>
        /// <para>
        /// <para>The storage capacity of the cache in gibibytes (GiB). Valid values are 1200 GiB, 2400
        /// GiB, and increments of 2400 GiB.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? StorageCapacity { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
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
        
        #region Parameter LustreConfiguration_WeeklyMaintenanceStartTime
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LustreConfiguration_WeeklyMaintenanceStartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FileCache'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateFileCacheResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateFileCacheResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FileCache";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KmsKeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXFileCache (CreateFileCache)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateFileCacheResponse, NewFSXFileCacheCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.CopyTagsToDataRepositoryAssociation = this.CopyTagsToDataRepositoryAssociation;
            if (this.DataRepositoryAssociation != null)
            {
                context.DataRepositoryAssociation = new List<Amazon.FSx.Model.FileCacheDataRepositoryAssociation>(this.DataRepositoryAssociation);
            }
            context.FileCacheType = this.FileCacheType;
            #if MODULAR
            if (this.FileCacheType == null && ParameterWasBound(nameof(this.FileCacheType)))
            {
                WriteWarning("You are passing $null as a value for parameter FileCacheType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileCacheTypeVersion = this.FileCacheTypeVersion;
            #if MODULAR
            if (this.FileCacheTypeVersion == null && ParameterWasBound(nameof(this.FileCacheTypeVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter FileCacheTypeVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            context.LustreConfiguration_DeploymentType = this.LustreConfiguration_DeploymentType;
            context.MetadataConfiguration_StorageCapacity = this.MetadataConfiguration_StorageCapacity;
            context.LustreConfiguration_PerUnitStorageThroughput = this.LustreConfiguration_PerUnitStorageThroughput;
            context.LustreConfiguration_WeeklyMaintenanceStartTime = this.LustreConfiguration_WeeklyMaintenanceStartTime;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.StorageCapacity = this.StorageCapacity;
            #if MODULAR
            if (this.StorageCapacity == null && ParameterWasBound(nameof(this.StorageCapacity)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageCapacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.FSx.Model.CreateFileCacheRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.CopyTagsToDataRepositoryAssociation != null)
            {
                request.CopyTagsToDataRepositoryAssociations = cmdletContext.CopyTagsToDataRepositoryAssociation.Value;
            }
            if (cmdletContext.DataRepositoryAssociation != null)
            {
                request.DataRepositoryAssociations = cmdletContext.DataRepositoryAssociation;
            }
            if (cmdletContext.FileCacheType != null)
            {
                request.FileCacheType = cmdletContext.FileCacheType;
            }
            if (cmdletContext.FileCacheTypeVersion != null)
            {
                request.FileCacheTypeVersion = cmdletContext.FileCacheTypeVersion;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            
             // populate LustreConfiguration
            var requestLustreConfigurationIsNull = true;
            request.LustreConfiguration = new Amazon.FSx.Model.CreateFileCacheLustreConfiguration();
            Amazon.FSx.FileCacheLustreDeploymentType requestLustreConfiguration_lustreConfiguration_DeploymentType = null;
            if (cmdletContext.LustreConfiguration_DeploymentType != null)
            {
                requestLustreConfiguration_lustreConfiguration_DeploymentType = cmdletContext.LustreConfiguration_DeploymentType;
            }
            if (requestLustreConfiguration_lustreConfiguration_DeploymentType != null)
            {
                request.LustreConfiguration.DeploymentType = requestLustreConfiguration_lustreConfiguration_DeploymentType;
                requestLustreConfigurationIsNull = false;
            }
            System.Int32? requestLustreConfiguration_lustreConfiguration_PerUnitStorageThroughput = null;
            if (cmdletContext.LustreConfiguration_PerUnitStorageThroughput != null)
            {
                requestLustreConfiguration_lustreConfiguration_PerUnitStorageThroughput = cmdletContext.LustreConfiguration_PerUnitStorageThroughput.Value;
            }
            if (requestLustreConfiguration_lustreConfiguration_PerUnitStorageThroughput != null)
            {
                request.LustreConfiguration.PerUnitStorageThroughput = requestLustreConfiguration_lustreConfiguration_PerUnitStorageThroughput.Value;
                requestLustreConfigurationIsNull = false;
            }
            System.String requestLustreConfiguration_lustreConfiguration_WeeklyMaintenanceStartTime = null;
            if (cmdletContext.LustreConfiguration_WeeklyMaintenanceStartTime != null)
            {
                requestLustreConfiguration_lustreConfiguration_WeeklyMaintenanceStartTime = cmdletContext.LustreConfiguration_WeeklyMaintenanceStartTime;
            }
            if (requestLustreConfiguration_lustreConfiguration_WeeklyMaintenanceStartTime != null)
            {
                request.LustreConfiguration.WeeklyMaintenanceStartTime = requestLustreConfiguration_lustreConfiguration_WeeklyMaintenanceStartTime;
                requestLustreConfigurationIsNull = false;
            }
            Amazon.FSx.Model.FileCacheLustreMetadataConfiguration requestLustreConfiguration_lustreConfiguration_MetadataConfiguration = null;
            
             // populate MetadataConfiguration
            var requestLustreConfiguration_lustreConfiguration_MetadataConfigurationIsNull = true;
            requestLustreConfiguration_lustreConfiguration_MetadataConfiguration = new Amazon.FSx.Model.FileCacheLustreMetadataConfiguration();
            System.Int32? requestLustreConfiguration_lustreConfiguration_MetadataConfiguration_metadataConfiguration_StorageCapacity = null;
            if (cmdletContext.MetadataConfiguration_StorageCapacity != null)
            {
                requestLustreConfiguration_lustreConfiguration_MetadataConfiguration_metadataConfiguration_StorageCapacity = cmdletContext.MetadataConfiguration_StorageCapacity.Value;
            }
            if (requestLustreConfiguration_lustreConfiguration_MetadataConfiguration_metadataConfiguration_StorageCapacity != null)
            {
                requestLustreConfiguration_lustreConfiguration_MetadataConfiguration.StorageCapacity = requestLustreConfiguration_lustreConfiguration_MetadataConfiguration_metadataConfiguration_StorageCapacity.Value;
                requestLustreConfiguration_lustreConfiguration_MetadataConfigurationIsNull = false;
            }
             // determine if requestLustreConfiguration_lustreConfiguration_MetadataConfiguration should be set to null
            if (requestLustreConfiguration_lustreConfiguration_MetadataConfigurationIsNull)
            {
                requestLustreConfiguration_lustreConfiguration_MetadataConfiguration = null;
            }
            if (requestLustreConfiguration_lustreConfiguration_MetadataConfiguration != null)
            {
                request.LustreConfiguration.MetadataConfiguration = requestLustreConfiguration_lustreConfiguration_MetadataConfiguration;
                requestLustreConfigurationIsNull = false;
            }
             // determine if request.LustreConfiguration should be set to null
            if (requestLustreConfigurationIsNull)
            {
                request.LustreConfiguration = null;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.StorageCapacity != null)
            {
                request.StorageCapacity = cmdletContext.StorageCapacity.Value;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
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
        
        private Amazon.FSx.Model.CreateFileCacheResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateFileCacheRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateFileCache");
            try
            {
                return client.CreateFileCacheAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.Boolean? CopyTagsToDataRepositoryAssociation { get; set; }
            public List<Amazon.FSx.Model.FileCacheDataRepositoryAssociation> DataRepositoryAssociation { get; set; }
            public Amazon.FSx.FileCacheType FileCacheType { get; set; }
            public System.String FileCacheTypeVersion { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.FSx.FileCacheLustreDeploymentType LustreConfiguration_DeploymentType { get; set; }
            public System.Int32? MetadataConfiguration_StorageCapacity { get; set; }
            public System.Int32? LustreConfiguration_PerUnitStorageThroughput { get; set; }
            public System.String LustreConfiguration_WeeklyMaintenanceStartTime { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.Int32? StorageCapacity { get; set; }
            public List<System.String> SubnetId { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.FSx.Model.CreateFileCacheResponse, NewFSXFileCacheCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileCache;
        }
        
    }
}

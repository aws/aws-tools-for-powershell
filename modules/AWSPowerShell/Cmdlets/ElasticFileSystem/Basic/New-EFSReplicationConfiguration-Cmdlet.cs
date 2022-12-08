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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Creates a replication configuration that replicates an existing EFS file system to
    /// a new, read-only file system. For more information, see <a href="https://docs.aws.amazon.com/efs/latest/ug/efs-replication.html">Amazon
    /// EFS replication</a> in the <i>Amazon EFS User Guide</i>. The replication configuration
    /// specifies the following:
    /// 
    ///  <ul><li><para><b>Source file system</b> - An existing EFS file system that you want replicated.
    /// The source file system cannot be a destination file system in an existing replication
    /// configuration.
    /// </para></li><li><para><b>Destination file system configuration</b> - The configuration of the destination
    /// file system to which the source file system will be replicated. There can only be
    /// one destination file system in a replication configuration. The destination file system
    /// configuration consists of the following properties:
    /// </para><ul><li><para><b>Amazon Web Services Region</b> - The Amazon Web Services Region in which the destination
    /// file system is created. Amazon EFS replication is available in all Amazon Web Services
    /// Regions that Amazon EFS is available in, except Africa (Cape Town), Asia Pacific (Hong
    /// Kong), Asia Pacific (Jakarta), Europe (Milan), and Middle East (Bahrain).
    /// </para></li><li><para><b>Availability Zone</b> - If you want the destination file system to use EFS One
    /// Zone availability and durability, you must specify the Availability Zone to create
    /// the file system in. For more information about EFS storage classes, see <a href="https://docs.aws.amazon.com/efs/latest/ug/storage-classes.html">
    /// Amazon EFS storage classes</a> in the <i>Amazon EFS User Guide</i>.
    /// </para></li><li><para><b>Encryption</b> - All destination file systems are created with encryption at rest
    /// enabled. You can specify the Key Management Service (KMS) key that is used to encrypt
    /// the destination file system. If you don't specify a KMS key, your service-managed
    /// KMS key for Amazon EFS is used. 
    /// </para><note><para>
    /// After the file system is created, you cannot change the KMS key.
    /// </para></note></li></ul></li></ul><para>
    /// The following properties are set by default:
    /// </para><ul><li><para><b>Performance mode</b> - The destination file system's performance mode matches
    /// that of the source file system, unless the destination file system uses EFS One Zone
    /// storage. In that case, the General Purpose performance mode is used. The performance
    /// mode cannot be changed.
    /// </para></li><li><para><b>Throughput mode</b> - The destination file system uses the Bursting Throughput
    /// mode by default. After the file system is created, you can modify the throughput mode.
    /// </para></li></ul><para>
    /// The following properties are turned off by default:
    /// </para><ul><li><para><b>Lifecycle management</b> - EFS lifecycle management and EFS Intelligent-Tiering
    /// are not enabled on the destination file system. After the destination file system
    /// is created, you can enable EFS lifecycle management and EFS Intelligent-Tiering.
    /// </para></li><li><para><b>Automatic backups</b> - Automatic daily backups not enabled on the destination
    /// file system. After the file system is created, you can change this setting.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/efs/latest/ug/efs-replication.html">Amazon
    /// EFS replication</a> in the <i>Amazon EFS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EFSReplicationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Elastic File System CreateReplicationConfiguration API operation.", Operation = new[] {"CreateReplicationConfiguration"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse",
        "This cmdlet returns an Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEFSReplicationConfigurationCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>An array of destination configuration objects. Only one destination configuration
        /// object is supported.</para>
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
        [Alias("Destinations")]
        public Amazon.ElasticFileSystem.Model.DestinationToCreate[] Destination { get; set; }
        #endregion
        
        #region Parameter SourceFileSystemId
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon EFS file system that you want to replicate. This file system
        /// cannot already be a source or destination file system in another replication configuration.</para>
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
        public System.String SourceFileSystemId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceFileSystemId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceFileSystemId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceFileSystemId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceFileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EFSReplicationConfiguration (CreateReplicationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse, NewEFSReplicationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceFileSystemId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Destination != null)
            {
                context.Destination = new List<Amazon.ElasticFileSystem.Model.DestinationToCreate>(this.Destination);
            }
            #if MODULAR
            if (this.Destination == null && ParameterWasBound(nameof(this.Destination)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceFileSystemId = this.SourceFileSystemId;
            #if MODULAR
            if (this.SourceFileSystemId == null && ParameterWasBound(nameof(this.SourceFileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceFileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationRequest();
            
            if (cmdletContext.Destination != null)
            {
                request.Destinations = cmdletContext.Destination;
            }
            if (cmdletContext.SourceFileSystemId != null)
            {
                request.SourceFileSystemId = cmdletContext.SourceFileSystemId;
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
        
        private Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "CreateReplicationConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateReplicationConfiguration(request);
                #elif CORECLR
                return client.CreateReplicationConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ElasticFileSystem.Model.DestinationToCreate> Destination { get; set; }
            public System.String SourceFileSystemId { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.CreateReplicationConfigurationResponse, NewEFSReplicationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

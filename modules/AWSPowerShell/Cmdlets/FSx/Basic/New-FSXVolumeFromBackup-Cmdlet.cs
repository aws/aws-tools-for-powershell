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
    /// Creates a new Amazon FSx for NetApp ONTAP volume from an existing Amazon FSx volume
    /// backup.
    /// </summary>
    [Cmdlet("New", "FSXVolumeFromBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.Volume")]
    [AWSCmdlet("Calls the Amazon FSx CreateVolumeFromBackup API operation.", Operation = new[] {"CreateVolumeFromBackup"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateVolumeFromBackupResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.Volume or Amazon.FSx.Model.CreateVolumeFromBackupResponse",
        "This cmdlet returns an Amazon.FSx.Model.Volume object.",
        "The service call response (type Amazon.FSx.Model.CreateVolumeFromBackupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFSXVolumeFromBackupCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        #region Parameter BackupId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String BackupId { get; set; }
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
        
        #region Parameter TieringPolicy_CoolingPeriod
        /// <summary>
        /// <para>
        /// <para>Specifies the number of days that user data in a volume must remain inactive before
        /// it is considered "cold" and moved to the capacity pool. Used with the <code>AUTO</code>
        /// and <code>SNAPSHOT_ONLY</code> tiering policies. Enter a whole number between 2 and
        /// 183. Default values are 31 days for <code>AUTO</code> and 2 days for <code>SNAPSHOT_ONLY</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_TieringPolicy_CoolingPeriod")]
        public System.Int32? TieringPolicy_CoolingPeriod { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_JunctionPath
        /// <summary>
        /// <para>
        /// <para>Specifies the location in the SVM's namespace where the volume is mounted. The <code>JunctionPath</code>
        /// must have a leading forward slash, such as <code>/vol3</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_JunctionPath { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the new volume you're creating.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TieringPolicy_Name
        /// <summary>
        /// <para>
        /// <para>Specifies the tiering policy used to transition data. Default value is <code>SNAPSHOT_ONLY</code>.</para><ul><li><para><code>SNAPSHOT_ONLY</code> - moves cold snapshots to the capacity pool storage tier.</para></li><li><para><code>AUTO</code> - moves cold user data and snapshots to the capacity pool storage
        /// tier based on your access patterns.</para></li><li><para><code>ALL</code> - moves all user data blocks in both the active file system and
        /// Snapshot copies to the storage pool tier.</para></li><li><para><code>NONE</code> - keeps a volume's data in the primary storage tier, preventing
        /// it from being moved to the capacity pool tier.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_TieringPolicy_Name")]
        [AWSConstantClassSource("Amazon.FSx.TieringPolicyName")]
        public Amazon.FSx.TieringPolicyName TieringPolicy_Name { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_SecurityStyle
        /// <summary>
        /// <para>
        /// <para>Specifies the security style for the volume. If a volume's security style is not specified,
        /// it is automatically set to the root volume's security style. The security style determines
        /// the type of permissions that FSx for ONTAP uses to control data access. For more information,
        /// see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/managing-volumes.html#volume-security-style">Volume
        /// security style</a> in the <i>Amazon FSx for NetApp ONTAP User Guide</i>. Specify one
        /// of the following values:</para><ul><li><para><code>UNIX</code> if the file system is managed by a UNIX administrator, the majority
        /// of users are NFS clients, and an application accessing the data uses a UNIX user as
        /// the service account. </para></li><li><para><code>NTFS</code> if the file system is managed by a Windows administrator, the majority
        /// of users are SMB clients, and an application accessing the data uses a Windows user
        /// as the service account.</para></li><li><para><code>MIXED</code> if the file system is managed by both UNIX and Windows administrators
        /// and users consist of both NFS and SMB clients.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.SecurityStyle")]
        public Amazon.FSx.SecurityStyle OntapConfiguration_SecurityStyle { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_SizeInMegabyte
        /// <summary>
        /// <para>
        /// <para>Specifies the size of the volume, in megabytes (MB), that you are creating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SizeInMegabytes")]
        public System.Int32? OntapConfiguration_SizeInMegabyte { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_StorageEfficiencyEnabled
        /// <summary>
        /// <para>
        /// <para>Set to true to enable deduplication, compression, and compaction storage efficiency
        /// features on the volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OntapConfiguration_StorageEfficiencyEnabled { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_StorageVirtualMachineId
        /// <summary>
        /// <para>
        /// <para>Specifies the ONTAP SVM in which to create the volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_StorageVirtualMachineId { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Volume'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateVolumeFromBackupResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateVolumeFromBackupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Volume";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXVolumeFromBackup (CreateVolumeFromBackup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateVolumeFromBackupResponse, NewFSXVolumeFromBackupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupId = this.BackupId;
            #if MODULAR
            if (this.BackupId == null && ParameterWasBound(nameof(this.BackupId)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OntapConfiguration_JunctionPath = this.OntapConfiguration_JunctionPath;
            context.OntapConfiguration_SecurityStyle = this.OntapConfiguration_SecurityStyle;
            context.OntapConfiguration_SizeInMegabyte = this.OntapConfiguration_SizeInMegabyte;
            context.OntapConfiguration_StorageEfficiencyEnabled = this.OntapConfiguration_StorageEfficiencyEnabled;
            context.OntapConfiguration_StorageVirtualMachineId = this.OntapConfiguration_StorageVirtualMachineId;
            context.TieringPolicy_CoolingPeriod = this.TieringPolicy_CoolingPeriod;
            context.TieringPolicy_Name = this.TieringPolicy_Name;
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
            var request = new Amazon.FSx.Model.CreateVolumeFromBackupRequest();
            
            if (cmdletContext.BackupId != null)
            {
                request.BackupId = cmdletContext.BackupId;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OntapConfiguration
            var requestOntapConfigurationIsNull = true;
            request.OntapConfiguration = new Amazon.FSx.Model.CreateOntapVolumeConfiguration();
            System.String requestOntapConfiguration_ontapConfiguration_JunctionPath = null;
            if (cmdletContext.OntapConfiguration_JunctionPath != null)
            {
                requestOntapConfiguration_ontapConfiguration_JunctionPath = cmdletContext.OntapConfiguration_JunctionPath;
            }
            if (requestOntapConfiguration_ontapConfiguration_JunctionPath != null)
            {
                request.OntapConfiguration.JunctionPath = requestOntapConfiguration_ontapConfiguration_JunctionPath;
                requestOntapConfigurationIsNull = false;
            }
            Amazon.FSx.SecurityStyle requestOntapConfiguration_ontapConfiguration_SecurityStyle = null;
            if (cmdletContext.OntapConfiguration_SecurityStyle != null)
            {
                requestOntapConfiguration_ontapConfiguration_SecurityStyle = cmdletContext.OntapConfiguration_SecurityStyle;
            }
            if (requestOntapConfiguration_ontapConfiguration_SecurityStyle != null)
            {
                request.OntapConfiguration.SecurityStyle = requestOntapConfiguration_ontapConfiguration_SecurityStyle;
                requestOntapConfigurationIsNull = false;
            }
            System.Int32? requestOntapConfiguration_ontapConfiguration_SizeInMegabyte = null;
            if (cmdletContext.OntapConfiguration_SizeInMegabyte != null)
            {
                requestOntapConfiguration_ontapConfiguration_SizeInMegabyte = cmdletContext.OntapConfiguration_SizeInMegabyte.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_SizeInMegabyte != null)
            {
                request.OntapConfiguration.SizeInMegabytes = requestOntapConfiguration_ontapConfiguration_SizeInMegabyte.Value;
                requestOntapConfigurationIsNull = false;
            }
            System.Boolean? requestOntapConfiguration_ontapConfiguration_StorageEfficiencyEnabled = null;
            if (cmdletContext.OntapConfiguration_StorageEfficiencyEnabled != null)
            {
                requestOntapConfiguration_ontapConfiguration_StorageEfficiencyEnabled = cmdletContext.OntapConfiguration_StorageEfficiencyEnabled.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_StorageEfficiencyEnabled != null)
            {
                request.OntapConfiguration.StorageEfficiencyEnabled = requestOntapConfiguration_ontapConfiguration_StorageEfficiencyEnabled.Value;
                requestOntapConfigurationIsNull = false;
            }
            System.String requestOntapConfiguration_ontapConfiguration_StorageVirtualMachineId = null;
            if (cmdletContext.OntapConfiguration_StorageVirtualMachineId != null)
            {
                requestOntapConfiguration_ontapConfiguration_StorageVirtualMachineId = cmdletContext.OntapConfiguration_StorageVirtualMachineId;
            }
            if (requestOntapConfiguration_ontapConfiguration_StorageVirtualMachineId != null)
            {
                request.OntapConfiguration.StorageVirtualMachineId = requestOntapConfiguration_ontapConfiguration_StorageVirtualMachineId;
                requestOntapConfigurationIsNull = false;
            }
            Amazon.FSx.Model.TieringPolicy requestOntapConfiguration_ontapConfiguration_TieringPolicy = null;
            
             // populate TieringPolicy
            var requestOntapConfiguration_ontapConfiguration_TieringPolicyIsNull = true;
            requestOntapConfiguration_ontapConfiguration_TieringPolicy = new Amazon.FSx.Model.TieringPolicy();
            System.Int32? requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_CoolingPeriod = null;
            if (cmdletContext.TieringPolicy_CoolingPeriod != null)
            {
                requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_CoolingPeriod = cmdletContext.TieringPolicy_CoolingPeriod.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_CoolingPeriod != null)
            {
                requestOntapConfiguration_ontapConfiguration_TieringPolicy.CoolingPeriod = requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_CoolingPeriod.Value;
                requestOntapConfiguration_ontapConfiguration_TieringPolicyIsNull = false;
            }
            Amazon.FSx.TieringPolicyName requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_Name = null;
            if (cmdletContext.TieringPolicy_Name != null)
            {
                requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_Name = cmdletContext.TieringPolicy_Name;
            }
            if (requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_Name != null)
            {
                requestOntapConfiguration_ontapConfiguration_TieringPolicy.Name = requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_Name;
                requestOntapConfiguration_ontapConfiguration_TieringPolicyIsNull = false;
            }
             // determine if requestOntapConfiguration_ontapConfiguration_TieringPolicy should be set to null
            if (requestOntapConfiguration_ontapConfiguration_TieringPolicyIsNull)
            {
                requestOntapConfiguration_ontapConfiguration_TieringPolicy = null;
            }
            if (requestOntapConfiguration_ontapConfiguration_TieringPolicy != null)
            {
                request.OntapConfiguration.TieringPolicy = requestOntapConfiguration_ontapConfiguration_TieringPolicy;
                requestOntapConfigurationIsNull = false;
            }
             // determine if request.OntapConfiguration should be set to null
            if (requestOntapConfigurationIsNull)
            {
                request.OntapConfiguration = null;
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
        
        private Amazon.FSx.Model.CreateVolumeFromBackupResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateVolumeFromBackupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateVolumeFromBackup");
            try
            {
                #if DESKTOP
                return client.CreateVolumeFromBackup(request);
                #elif CORECLR
                return client.CreateVolumeFromBackupAsync(request).GetAwaiter().GetResult();
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
            public System.String BackupId { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String Name { get; set; }
            public System.String OntapConfiguration_JunctionPath { get; set; }
            public Amazon.FSx.SecurityStyle OntapConfiguration_SecurityStyle { get; set; }
            public System.Int32? OntapConfiguration_SizeInMegabyte { get; set; }
            public System.Boolean? OntapConfiguration_StorageEfficiencyEnabled { get; set; }
            public System.String OntapConfiguration_StorageVirtualMachineId { get; set; }
            public System.Int32? TieringPolicy_CoolingPeriod { get; set; }
            public Amazon.FSx.TieringPolicyName TieringPolicy_Name { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.FSx.Model.CreateVolumeFromBackupResponse, NewFSXVolumeFromBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Volume;
        }
        
    }
}

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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Restores a cluster to an arbitrary point in time. Users can restore to any point in
    /// time before <code>LatestRestorableTime</code> for up to <code>BackupRetentionPeriod</code>
    /// days. The target cluster is created from the source cluster with the same configuration
    /// as the original cluster, except that the new cluster is created with the default security
    /// group.
    /// </summary>
    [Cmdlet("Restore", "DOCDBClusterToPointInTime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) RestoreDBClusterToPointInTime API operation.", Operation = new[] {"RestoreDBClusterToPointInTime"}, SelectReturnType = typeof(Amazon.DocDB.Model.RestoreDBClusterToPointInTimeResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.DBCluster or Amazon.DocDB.Model.RestoreDBClusterToPointInTimeResponse",
        "This cmdlet returns an Amazon.DocDB.Model.DBCluster object.",
        "The service call response (type Amazon.DocDB.Model.RestoreDBClusterToPointInTimeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreDOCDBClusterToPointInTimeCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of the new cluster to be created.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul>
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
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The subnet group name to use for the new cluster.</para><para>Constraints: If provided, must match the name of an existing <code>DBSubnetGroup</code>.</para><para>Example: <code>mySubnetgroup</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Specifies whether this cluster can be deleted. If <code>DeletionProtection</code>
        /// is enabled, the cluster cannot be deleted unless it is modified and <code>DeletionProtection</code>
        /// is disabled. <code>DeletionProtection</code> protects clusters from being accidentally
        /// deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLogsExport
        /// <summary>
        /// <para>
        /// <para>A list of log types that must be enabled for exporting to Amazon CloudWatch Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableCloudwatchLogsExports")]
        public System.String[] EnableCloudwatchLogsExport { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key identifier to use when restoring an encrypted cluster from an encrypted
        /// cluster.</para><para>The KMS key identifier is the Amazon Resource Name (ARN) for the KMS encryption key.
        /// If you are restoring a cluster with the same Amazon Web Services account that owns
        /// the KMS encryption key used to encrypt the new cluster, then you can use the KMS key
        /// alias instead of the ARN for the KMS encryption key.</para><para>You can restore to a new cluster and encrypt the new cluster with an KMS key that
        /// is different from the KMS key used to encrypt the source cluster. The new DB cluster
        /// is encrypted with the KMS key identified by the <code>KmsKeyId</code> parameter.</para><para>If you do not specify a value for the <code>KmsKeyId</code> parameter, then the following
        /// occurs:</para><ul><li><para>If the cluster is encrypted, then the restored cluster is encrypted using the KMS
        /// key that was used to encrypt the source cluster.</para></li><li><para>If the cluster is not encrypted, then the restored cluster is not encrypted.</para></li></ul><para>If <code>DBClusterIdentifier</code> refers to a cluster that is not encrypted, then
        /// the restore request is rejected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the new cluster accepts connections.</para><para>Constraints: Must be a value from <code>1150</code> to <code>65535</code>. </para><para>Default: The default port for the engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter RestoreToTime
        /// <summary>
        /// <para>
        /// <para>The date and time to restore the cluster to.</para><para>Valid values: A time in Universal Coordinated Time (UTC) format.</para><para>Constraints:</para><ul><li><para>Must be before the latest restorable time for the instance.</para></li><li><para>Must be specified if the <code>UseLatestRestorableTime</code> parameter is not provided.</para></li><li><para>Cannot be specified if the <code>UseLatestRestorableTime</code> parameter is <code>true</code>.</para></li><li><para>Cannot be specified if the <code>RestoreType</code> parameter is <code>copy-on-write</code>.</para></li></ul><para>Example: <code>2015-03-07T23:45:00Z</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RestoreToTime { get; set; }
        #endregion
        
        #region Parameter RestoreType
        /// <summary>
        /// <para>
        /// <para>The type of restore to be performed. You can specify one of the following values:</para><ul><li><para><code>full-copy</code> - The new DB cluster is restored as a full copy of the source
        /// DB cluster.</para></li><li><para><code>copy-on-write</code> - The new DB cluster is restored as a clone of the source
        /// DB cluster.</para></li></ul><para>If you don't specify a <code>RestoreType</code> value, then the new DB cluster is
        /// restored as a full copy of the source DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestoreType { get; set; }
        #endregion
        
        #region Parameter SourceDBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the source cluster from which to restore.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing <code>DBCluster</code>.</para></li></ul>
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
        public System.String SourceDBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to the restored cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DocDB.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UseLatestRestorableTime
        /// <summary>
        /// <para>
        /// <para>A value that is set to <code>true</code> to restore the cluster to the latest restorable
        /// backup time, and <code>false</code> otherwise. </para><para>Default: <code>false</code></para><para>Constraints: Cannot be specified if the <code>RestoreToTime</code> parameter is provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseLatestRestorableTime { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of VPC security groups that the new cluster belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.RestoreDBClusterToPointInTimeResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.RestoreDBClusterToPointInTimeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBCluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBClusterIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-DOCDBClusterToPointInTime (RestoreDBClusterToPointInTime)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.RestoreDBClusterToPointInTimeResponse, RestoreDOCDBClusterToPointInTimeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            #if MODULAR
            if (this.DBClusterIdentifier == null && ParameterWasBound(nameof(this.DBClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            context.DeletionProtection = this.DeletionProtection;
            if (this.EnableCloudwatchLogsExport != null)
            {
                context.EnableCloudwatchLogsExport = new List<System.String>(this.EnableCloudwatchLogsExport);
            }
            context.KmsKeyId = this.KmsKeyId;
            context.Port = this.Port;
            context.RestoreToTime = this.RestoreToTime;
            context.RestoreType = this.RestoreType;
            context.SourceDBClusterIdentifier = this.SourceDBClusterIdentifier;
            #if MODULAR
            if (this.SourceDBClusterIdentifier == null && ParameterWasBound(nameof(this.SourceDBClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceDBClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DocDB.Model.Tag>(this.Tag);
            }
            context.UseLatestRestorableTime = this.UseLatestRestorableTime;
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupId = new List<System.String>(this.VpcSecurityGroupId);
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
            var request = new Amazon.DocDB.Model.RestoreDBClusterToPointInTimeRequest();
            
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.DBSubnetGroupName != null)
            {
                request.DBSubnetGroupName = cmdletContext.DBSubnetGroupName;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.EnableCloudwatchLogsExport != null)
            {
                request.EnableCloudwatchLogsExports = cmdletContext.EnableCloudwatchLogsExport;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.RestoreToTime != null)
            {
                request.RestoreToTime = cmdletContext.RestoreToTime.Value;
            }
            if (cmdletContext.RestoreType != null)
            {
                request.RestoreType = cmdletContext.RestoreType;
            }
            if (cmdletContext.SourceDBClusterIdentifier != null)
            {
                request.SourceDBClusterIdentifier = cmdletContext.SourceDBClusterIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UseLatestRestorableTime != null)
            {
                request.UseLatestRestorableTime = cmdletContext.UseLatestRestorableTime.Value;
            }
            if (cmdletContext.VpcSecurityGroupId != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupId;
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
        
        private Amazon.DocDB.Model.RestoreDBClusterToPointInTimeResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.RestoreDBClusterToPointInTimeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "RestoreDBClusterToPointInTime");
            try
            {
                #if DESKTOP
                return client.RestoreDBClusterToPointInTime(request);
                #elif CORECLR
                return client.RestoreDBClusterToPointInTimeAsync(request).GetAwaiter().GetResult();
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
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public List<System.String> EnableCloudwatchLogsExport { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Int32? Port { get; set; }
            public System.DateTime? RestoreToTime { get; set; }
            public System.String RestoreType { get; set; }
            public System.String SourceDBClusterIdentifier { get; set; }
            public List<Amazon.DocDB.Model.Tag> Tag { get; set; }
            public System.Boolean? UseLatestRestorableTime { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.DocDB.Model.RestoreDBClusterToPointInTimeResponse, RestoreDOCDBClusterToPointInTimeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCluster;
        }
        
    }
}

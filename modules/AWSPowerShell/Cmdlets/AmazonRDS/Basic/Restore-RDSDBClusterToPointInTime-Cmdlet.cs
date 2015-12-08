/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Restores a DB cluster to an arbitrary point in time. Users can restore to any point
    /// in time before <code>LatestRestorableTime</code> for up to <code>BackupRetentionPeriod</code>
    /// days. The target DB cluster is created from the source DB cluster with the same configuration
    /// as the original DB cluster, except that the new DB cluster is created with the default
    /// DB security group. 
    /// 
    ///  
    /// <para>
    /// For more information on Amazon Aurora, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Aurora.html">Aurora
    /// on Amazon RDS</a> in the <i>Amazon RDS User Guide.</i></para>
    /// </summary>
    [Cmdlet("Restore", "RDSDBClusterToPointInTime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCluster")]
    [AWSCmdlet("Invokes the RestoreDBClusterToPointInTime operation against Amazon Relational Database Service.", Operation = new[] {"RestoreDBClusterToPointInTime"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCluster",
        "This cmdlet returns a DBCluster object.",
        "The service call response (type Amazon.RDS.Model.RestoreDBClusterToPointInTimeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RestoreRDSDBClusterToPointInTimeCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The name of the new DB cluster to be created. </para><para>Constraints:</para><ul><li>Must contain from 1 to 63 alphanumeric characters or hyphens</li><li>First
        /// character must be a letter</li><li>Cannot end with a hyphen or contain two consecutive
        /// hyphens</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DBClusterIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The DB subnet group name to use for the new DB cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The KMS key identifier to use when restoring an encrypted DB cluster.</para><para>The KMS key identifier is the Amazon Resource Name (ARN) for the KMS encryption key.
        /// If you are restoring a DB cluster with the same AWS account that owns the KMS encryption
        /// key used to encrypt the new DB cluster, then you can use the KMS key alias instead
        /// of the ARN for the KMS encryption key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the option group for the new DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The port number on which the new DB cluster accepts connections. </para><para>Constraints: Value must be <code>1150-65535</code></para><para>Default: The same port as the original DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The date and time to restore the DB cluster to. </para><para>Valid Values: Value must be a time in Universal Coordinated Time (UTC) format</para><para>Constraints:</para><ul><li>Must be before the latest restorable time for the DB instance</li><li>Cannot
        /// be specified if <code>UseLatestRestorableTime</code> parameter is true</li></ul><para>Example: <code>2015-03-07T23:45:00Z</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime RestoreToTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The identifier of the source DB cluster from which to restore. </para><para>Constraints:</para><ul><li>Must be the identifier of an existing database instance</li><li>Must contain
        /// from 1 to 63 alphanumeric characters or hyphens</li><li>First character must be a
        /// letter</li><li>Cannot end with a hyphen or contain two consecutive hyphens</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceDBClusterIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A value that is set to <code>true</code> to restore the DB cluster to the latest restorable
        /// backup time, and <code>false</code> otherwise. </para><para>Default: <code>false</code></para><para>Constraints: Cannot be specified if <code>RestoreToTime</code> parameter is provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean UseLatestRestorableTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A lst of VPC security groups that the new DB cluster belongs to. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBClusterIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-RDSDBClusterToPointInTime (RestoreDBClusterToPointInTime)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            context.KmsKeyId = this.KmsKeyId;
            context.OptionGroupName = this.OptionGroupName;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            if (ParameterWasBound("RestoreToTime"))
                context.RestoreToTime = this.RestoreToTime;
            context.SourceDBClusterIdentifier = this.SourceDBClusterIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            if (ParameterWasBound("UseLatestRestorableTime"))
                context.UseLatestRestorableTime = this.UseLatestRestorableTime;
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupIds = new List<System.String>(this.VpcSecurityGroupId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.RDS.Model.RestoreDBClusterToPointInTimeRequest();
            
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.DBSubnetGroupName != null)
            {
                request.DBSubnetGroupName = cmdletContext.DBSubnetGroupName;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.RestoreToTime != null)
            {
                request.RestoreToTime = cmdletContext.RestoreToTime.Value;
            }
            if (cmdletContext.SourceDBClusterIdentifier != null)
            {
                request.SourceDBClusterIdentifier = cmdletContext.SourceDBClusterIdentifier;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.UseLatestRestorableTime != null)
            {
                request.UseLatestRestorableTime = cmdletContext.UseLatestRestorableTime.Value;
            }
            if (cmdletContext.VpcSecurityGroupIds != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RestoreDBClusterToPointInTime(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBCluster;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.Int32? Port { get; set; }
            public System.DateTime? RestoreToTime { get; set; }
            public System.String SourceDBClusterIdentifier { get; set; }
            public List<Amazon.RDS.Model.Tag> Tags { get; set; }
            public System.Boolean? UseLatestRestorableTime { get; set; }
            public List<System.String> VpcSecurityGroupIds { get; set; }
        }
        
    }
}

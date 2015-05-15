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
    /// Creates a new DB instance from a DB snapshot. The target database is created from
    /// the source database restore point with the same configuration as the original source
    /// database, except that the new RDS instance is created with the default security group.
    /// 
    /// 
    ///  
    /// <para>
    /// If your intent is to replace your original DB instance with the new, restored DB instance,
    /// then rename your original DB instance before you call the RestoreDBInstanceFromDBSnapshot
    /// action. RDS does not allow two DB instances with the same name. Once you have renamed
    /// your original DB instance with a different identifier, then you can pass the original
    /// name of the DB instance as the DBInstanceIdentifier in the call to the RestoreDBInstanceFromDBSnapshot
    /// action. The result is that you will replace the original DB instance with the DB instance
    /// created from the snapshot.
    /// </para>
    /// </summary>
    [Cmdlet("Restore", "RDSDBInstanceFromDBSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Invokes the RestoreDBInstanceFromDBSnapshot operation against Amazon Relational Database Service.", Operation = new[] {"RestoreDBInstanceFromDBSnapshot"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance",
        "This cmdlet returns a DBInstance object.",
        "The service call response (type RestoreDBInstanceFromDBSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RestoreRDSDBInstanceFromDBSnapshotCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> Indicates that minor version upgrades will be applied automatically to the DB instance
        /// during the maintenance window. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean AutoMinorVersionUpgrade { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The EC2 Availability Zone that the database instance will be created in. </para><para>Default: A random, system-chosen Availability Zone.</para><para>Constraint: You cannot specify the AvailabilityZone parameter if the MultiAZ parameter
        /// is set to <code>true</code>.</para><para>Example: <code>us-east-1a</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AvailabilityZone { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The compute and memory capacity of the Amazon RDS DB instance. </para><para>Valid Values: <code>db.t1.micro | db.m1.small | db.m1.medium | db.m1.large | db.m1.xlarge
        /// | db.m2.2xlarge | db.m2.4xlarge | db.m3.medium | db.m3.large | db.m3.xlarge | db.m3.2xlarge
        /// | db.r3.large | db.r3.xlarge | db.r3.2xlarge | db.r3.4xlarge | db.r3.8xlarge | db.t2.micro
        /// | db.t2.small | db.t2.medium</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String DBInstanceClass { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Name of the DB instance to create from the DB snapshot. This parameter isn't case
        /// sensitive. </para><para>Constraints:</para><ul><li>Must contain from 1 to 255 alphanumeric characters or hyphens</li><li>First
        /// character must be a letter</li><li>Cannot end with a hyphen or contain two consecutive
        /// hyphens</li></ul><para>Example: <code>my-snapshot-id</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String DBInstanceIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The database name for the restored DB instance. </para><note><para>This parameter doesn't apply to the MySQL engine.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DBName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The identifier for the DB snapshot to restore from. </para><para>Constraints:</para><ul><li>Must contain from 1 to 63 alphanumeric characters or hyphens</li><li>First
        /// character must be a letter</li><li>Cannot end with a hyphen or contain two consecutive
        /// hyphens</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String DBSnapshotIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The DB subnet group name to use for the new instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String DBSubnetGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The database engine to use for the new instance. </para><para>Default: The same as source</para><para>Constraint: Must be compatible with the engine of the source</para><para> Valid Values: <code>MySQL</code> | <code>oracle-se1</code> | <code>oracle-se</code>
        /// | <code>oracle-ee</code> | <code>sqlserver-ee</code> | <code>sqlserver-se</code> |
        /// <code>sqlserver-ex</code> | <code>sqlserver-web</code> | <code>postgres</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String Engine { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Specifies the amount of provisioned IOPS for the DB instance, expressed in I/O operations
        /// per second. If this parameter is not specified, the IOPS value will be taken from
        /// the backup. If this parameter is set to 0, the new instance will be converted to a
        /// non-PIOPS instance, which will take additional time, though your DB instance will
        /// be available for connections before the conversion starts. </para><para> Constraints: Must be an integer greater than 1000.</para><para><b>SQL Server</b></para><para>Setting the IOPS value for the SQL Server database engine is not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Iops { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> License model information for the restored DB instance. </para><para> Default: Same as source. </para><para> Valid values: <code>license-included</code> | <code>bring-your-own-license</code>
        /// | <code>general-public-license</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String LicenseModel { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Specifies if the DB instance is a Multi-AZ deployment. </para><para>Constraint: You cannot specify the AvailabilityZone parameter if the MultiAZ parameter
        /// is set to <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean MultiAZ { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the option group to be used for the restored DB instance.</para><para>Permanent options, such as the TDE option for Oracle Advanced Security TDE, cannot
        /// be removed from an option group, and that option group cannot be removed from a DB
        /// instance once it is associated with a DB instance </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String OptionGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The port number on which the database accepts connections. </para><para>Default: The same port as the original DB instance</para><para>Constraints: Value must be <code>1150-65535</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Port { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Specifies the accessibility options for the DB instance. A value of true specifies
        /// an Internet-facing instance with a publicly resolvable DNS name, which resolves to
        /// a public IP address. A value of false specifies an internal instance with a DNS name
        /// that resolves to a private IP address. </para><para> Default: The default behavior varies depending on whether a VPC has been requested
        /// or not. The following list shows the default behavior in each case. </para><ul><li><b>Default VPC:</b> true</li><li><b>VPC:</b> false</li></ul><para> If no DB subnet group has been specified as part of the request and the PubliclyAccessible
        /// value has not been set, the DB instance will be publicly accessible. If a specific
        /// DB subnet group has been specified as part of the request and the PubliclyAccessible
        /// value has not been set, the DB instance will be private. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean PubliclyAccessible { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Specifies the storage type to be associated with the DB instance. </para><para> Valid values: <code>standard | gp2 | io1</code></para><para> If you specify <code>io1</code>, you must also include a value for the <code>Iops</code>
        /// parameter. </para><para> Default: <code>io1</code> if the <code>Iops</code> parameter is specified; otherwise
        /// <code>standard</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String StorageType { get; set; }
        
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
        /// <para> The ARN from the Key Store with which to associate the instance for TDE encryption.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String TdeCredentialArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The password for the given ARN from the Key Store in order to access the device.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String TdeCredentialPassword { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBInstanceIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-RDSDBInstanceFromDBSnapshot (RestoreDBInstanceFromDBSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("AutoMinorVersionUpgrade"))
                context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AvailabilityZone = this.AvailabilityZone;
            context.DBInstanceClass = this.DBInstanceClass;
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            context.DBName = this.DBName;
            context.DBSnapshotIdentifier = this.DBSnapshotIdentifier;
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            context.Engine = this.Engine;
            if (ParameterWasBound("Iops"))
                context.Iops = this.Iops;
            context.LicenseModel = this.LicenseModel;
            if (ParameterWasBound("MultiAZ"))
                context.MultiAZ = this.MultiAZ;
            context.OptionGroupName = this.OptionGroupName;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
            context.StorageType = this.StorageType;
            if (this.Tag != null)
            {
                context.Tags = new List<Tag>(this.Tag);
            }
            context.TdeCredentialArn = this.TdeCredentialArn;
            context.TdeCredentialPassword = this.TdeCredentialPassword;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new RestoreDBInstanceFromDBSnapshotRequest();
            
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.DBInstanceClass != null)
            {
                request.DBInstanceClass = cmdletContext.DBInstanceClass;
            }
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.DBName != null)
            {
                request.DBName = cmdletContext.DBName;
            }
            if (cmdletContext.DBSnapshotIdentifier != null)
            {
                request.DBSnapshotIdentifier = cmdletContext.DBSnapshotIdentifier;
            }
            if (cmdletContext.DBSubnetGroupName != null)
            {
                request.DBSubnetGroupName = cmdletContext.DBSubnetGroupName;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.Iops != null)
            {
                request.Iops = cmdletContext.Iops.Value;
            }
            if (cmdletContext.LicenseModel != null)
            {
                request.LicenseModel = cmdletContext.LicenseModel;
            }
            if (cmdletContext.MultiAZ != null)
            {
                request.MultiAZ = cmdletContext.MultiAZ.Value;
            }
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.StorageType != null)
            {
                request.StorageType = cmdletContext.StorageType;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TdeCredentialArn != null)
            {
                request.TdeCredentialArn = cmdletContext.TdeCredentialArn;
            }
            if (cmdletContext.TdeCredentialPassword != null)
            {
                request.TdeCredentialPassword = cmdletContext.TdeCredentialPassword;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RestoreDBInstanceFromDBSnapshot(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBInstance;
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
            public Boolean? AutoMinorVersionUpgrade { get; set; }
            public String AvailabilityZone { get; set; }
            public String DBInstanceClass { get; set; }
            public String DBInstanceIdentifier { get; set; }
            public String DBName { get; set; }
            public String DBSnapshotIdentifier { get; set; }
            public String DBSubnetGroupName { get; set; }
            public String Engine { get; set; }
            public Int32? Iops { get; set; }
            public String LicenseModel { get; set; }
            public Boolean? MultiAZ { get; set; }
            public String OptionGroupName { get; set; }
            public Int32? Port { get; set; }
            public Boolean? PubliclyAccessible { get; set; }
            public String StorageType { get; set; }
            public List<Tag> Tags { get; set; }
            public String TdeCredentialArn { get; set; }
            public String TdeCredentialPassword { get; set; }
        }
        
    }
}

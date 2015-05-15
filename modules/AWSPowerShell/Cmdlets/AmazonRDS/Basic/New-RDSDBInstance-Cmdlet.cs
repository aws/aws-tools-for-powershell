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
    /// Creates a new DB instance.
    /// </summary>
    [Cmdlet("New", "RDSDBInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Invokes the CreateDBInstance operation against Amazon Relational Database Service.", Operation = new[] {"CreateDBInstance"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance",
        "This cmdlet returns a DBInstance object.",
        "The service call response (type CreateDBInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewRDSDBInstanceCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The amount of storage (in gigabytes) to be initially allocated for the database instance.
        /// </para><para> Type: Integer</para><para><b>MySQL</b></para><para> Constraints: Must be an integer from 5 to 3072.</para><para><b>PostgreSQL</b></para><para> Constraints: Must be an integer from 5 to 3072.</para><para><b>Oracle</b></para><para> Constraints: Must be an integer from 10 to 3072.</para><para><b>SQL Server</b></para><para> Constraints: Must be an integer from 200 to 1024 (Standard Edition and Enterprise
        /// Edition) or from 20 to 1024 (Express Edition and Web Edition)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 AllocatedStorage { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Indicates that minor engine upgrades will be applied automatically to the DB instance
        /// during the maintenance window. </para><para>Default: <code>true</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean AutoMinorVersionUpgrade { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The EC2 Availability Zone that the database instance will be created in. For information
        /// on regions and Availability Zones, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.RegionsAndAvailabilityZones.html">Regions
        /// and Availability Zones</a>. </para><para> Default: A random, system-chosen Availability Zone in the endpoint's region. </para><para> Example: <code>us-east-1d</code></para><para> Constraint: The AvailabilityZone parameter cannot be specified if the MultiAZ parameter
        /// is set to <code>true</code>. The specified Availability Zone must be in the same region
        /// as the current endpoint. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AvailabilityZone { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The number of days for which automated backups are retained. Setting this parameter
        /// to a positive number enables backups. Setting this parameter to 0 disables automated
        /// backups. </para><para> Default: 1 </para><para>Constraints:</para><ul><li>Must be a value from 0 to 35</li><li>Cannot be set to 0 if the DB instance
        /// is a source to Read Replicas</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 BackupRetentionPeriod { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> For supported engines, indicates that the DB instance should be associated with the
        /// specified CharacterSet. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CharacterSetName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The compute and memory capacity of the DB instance. </para><para> Valid Values: <code>db.t1.micro | db.m1.small | db.m1.medium | db.m1.large | db.m1.xlarge
        /// | db.m2.xlarge |db.m2.2xlarge | db.m2.4xlarge | db.m3.medium | db.m3.large | db.m3.xlarge
        /// | db.m3.2xlarge | db.r3.large | db.r3.xlarge | db.r3.2xlarge | db.r3.4xlarge | db.r3.8xlarge
        /// | db.t2.micro | db.t2.small | db.t2.medium</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String DBInstanceClass { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The DB instance identifier. This parameter is stored as a lowercase string. </para><para>Constraints:</para><ul><li>Must contain from 1 to 63 alphanumeric characters or hyphens (1 to 15 for
        /// SQL Server).</li><li>First character must be a letter.</li><li>Cannot end with a
        /// hyphen or contain two consecutive hyphens.</li></ul><para>Example: <code>mydbinstance</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String DBInstanceIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The meaning of this parameter differs according to the database engine you use.</para><para>Type: String</para><para><b>MySQL</b></para><para>The name of the database to create when the DB instance is created. If this parameter
        /// is not specified, no database is created in the DB instance. </para><para>Constraints:</para><ul><li>Must contain 1 to 64 alphanumeric characters</li><li>Cannot be a word reserved
        /// by the specified database engine</li></ul><para><b>PostgreSQL</b></para><para>The name of the database to create when the DB instance is created. If this parameter
        /// is not specified, no database is created in the DB instance. </para><para>Constraints:</para><ul><li>Must contain 1 to 63 alphanumeric characters</li><li>Must begin with a
        /// letter or an underscore. Subsequent characters can be letters, underscores, or digits
        /// (0-9).</li><li>Cannot be a word reserved by the specified database engine</li></ul><para><b>Oracle</b></para><para> The Oracle System ID (SID) of the created DB instance. </para><para>Default: <code>ORCL</code></para><para>Constraints:</para><ul><li>Cannot be longer than 8 characters</li></ul><para><b>SQL Server</b></para><para>Not applicable. Must be null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String DBName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the DB parameter group to associate with this DB instance. If this argument
        /// is omitted, the default DBParameterGroup for the specified engine will be used. </para><para> Constraints: </para><ul><li>Must be 1 to 255 alphanumeric characters</li><li>First character must be
        /// a letter</li><li>Cannot end with a hyphen or contain two consecutive hyphens</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String DBParameterGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A list of DB security groups to associate with this DB instance. </para><para> Default: The default DB security group for the database engine. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DBSecurityGroups")]
        public System.String[] DBSecurityGroup { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A DB subnet group to associate with this DB instance. </para><para> If there is no DB subnet group, then it is a non-VPC DB instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String DBSubnetGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the database engine to be used for this instance. </para><para> Valid Values: <code>MySQL</code> | <code>oracle-se1</code> | <code>oracle-se</code>
        /// | <code>oracle-ee</code> | <code>sqlserver-ee</code> | <code>sqlserver-se</code> |
        /// <code>sqlserver-ex</code> | <code>sqlserver-web</code> | <code>postgres</code></para><para> Not every database engine is available for every AWS region. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String Engine { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The version number of the database engine to use. </para><para> The following are the database engines and major and minor versions that are available
        /// with Amazon RDS. Not every database engine is available for every AWS region. </para><para><b>MySQL</b></para><ul><li><b>Version 5.1 (Only available in the following regions: ap-northeast-1,
        /// ap-southeast-1, ap-southeast-2, eu-west-1, sa-east-1, us-west-1, us-west-2):</b><code>
        /// 5.1.73a | 5.1.73b</code></li><li><b>Version 5.5 (Only available in the following
        /// regions: ap-northeast-1, ap-southeast-1, ap-southeast-2, eu-west-1, sa-east-1, us-west-1,
        /// us-west-2):</b><code> 5.5.40 | 5.5.40a</code></li><li><b>Version 5.5 (Available
        /// in all regions):</b><code> 5.5.40b | 5.5.41</code></li><li><b>Version 5.6 (Available
        /// in all regions):</b><code> 5.6.19a | 5.6.19b | 5.6.21 | 5.6.21b | 5.6.22</code></li></ul><para><b>MySQL</b></para><ul><li><b>Version 5.1 (Only available in the following regions: ap-northeast-1,
        /// ap-southeast-1, ap-southeast-2, eu-west-1, sa-east-1, us-west-1, us-west-2):</b><code>
        /// 5.1.73a | 5.1.73b</code></li><li><b>Version 5.5 (Only available in the following
        /// regions: ap-northeast-1, ap-southeast-1, ap-southeast-2, eu-west-1, sa-east-1, us-west-1,
        /// us-west-2):</b><code> 5.5.40 | 5.5.40a</code></li><li><b>Version 5.5 (Available
        /// in all regions):</b><code> 5.5.40b | 5.5.41</code></li><li><b>Version 5.6 (Available
        /// in all regions):</b><code> 5.6.19a | 5.6.19b | 5.6.21 | 5.6.21b | 5.6.22</code></li></ul><para><b>MySQL</b></para><ul><li><b>Version 5.1 (Only available in the following regions: ap-northeast-1,
        /// ap-southeast-1, ap-southeast-2, eu-west-1, sa-east-1, us-west-1, us-west-2):</b><code>
        /// 5.1.73a | 5.1.73b</code></li><li><b>Version 5.5 (Only available in the following
        /// regions: ap-northeast-1, ap-southeast-1, ap-southeast-2, eu-west-1, sa-east-1, us-west-1,
        /// us-west-2):</b><code> 5.5.40 | 5.5.40a</code></li><li><b>Version 5.5 (Available
        /// in all regions):</b><code> 5.5.40b | 5.5.41</code></li><li><b>Version 5.6 (Available
        /// in all regions):</b><code> 5.6.19a | 5.6.19b | 5.6.21 | 5.6.21b | 5.6.22</code></li></ul><para><b>MySQL</b></para><ul><li><b>Version 5.1 (Only available in the following regions: ap-northeast-1,
        /// ap-southeast-1, ap-southeast-2, eu-west-1, sa-east-1, us-west-1, us-west-2):</b><code>
        /// 5.1.73a | 5.1.73b</code></li><li><b>Version 5.5 (Only available in the following
        /// regions: ap-northeast-1, ap-southeast-1, ap-southeast-2, eu-west-1, sa-east-1, us-west-1,
        /// us-west-2):</b><code> 5.5.40 | 5.5.40a</code></li><li><b>Version 5.5 (Available
        /// in all regions):</b><code> 5.5.40b | 5.5.41</code></li><li><b>Version 5.6 (Available
        /// in all regions):</b><code> 5.6.19a | 5.6.19b | 5.6.21 | 5.6.21b | 5.6.22</code></li></ul><para><b>Oracle Database Enterprise Edition (oracle-ee)</b></para><ul><li><b>Version 11.2 (Only available in the following regions: ap-northeast-1,
        /// ap-southeast-1, ap-southeast-2, eu-west-1, sa-east-1, us-west-1, us-west-2):</b><code>
        /// 11.2.0.2.v3 | 11.2.0.2.v4 | 11.2.0.2.v5 | 11.2.0.2.v6 | 11.2.0.2.v7</code></li><li><b>Version 11.2 (Available in all regions):</b><code> 11.2.0.3.v1 | 11.2.0.3.v2 |
        /// 11.2.0.4.v1 | 11.2.0.4.v3</code></li></ul><para><b>Oracle Database Enterprise Edition (oracle-ee)</b></para><ul><li><b>Version 11.2 (Only available in the following regions: ap-northeast-1,
        /// ap-southeast-1, ap-southeast-2, eu-west-1, sa-east-1, us-west-1, us-west-2):</b><code>
        /// 11.2.0.2.v3 | 11.2.0.2.v4 | 11.2.0.2.v5 | 11.2.0.2.v6 | 11.2.0.2.v7</code></li><li><b>Version 11.2 (Available in all regions):</b><code> 11.2.0.3.v1 | 11.2.0.3.v2 |
        /// 11.2.0.4.v1 | 11.2.0.4.v3</code></li></ul><para><b>Oracle Database Standard Edition (oracle-se)</b></para><ul><li><b>Version 11.2 (Only available in the following regions: us-west-1):</b><code> 11.2.0.2.v3 | 11.2.0.2.v4 | 11.2.0.2.v5 | 11.2.0.2.v6 | 11.2.0.2.v7</code></li><li><b>Version 11.2 (Only available in the following regions: eu-central-1,
        /// us-west-1):</b><code> 11.2.0.3.v1 | 11.2.0.3.v2 | 11.2.0.4.v1 | 11.2.0.4.v3</code></li></ul><para><b>Oracle Database Standard Edition (oracle-se)</b></para><ul><li><b>Version 11.2 (Only available in the following regions: us-west-1):</b><code> 11.2.0.2.v3 | 11.2.0.2.v4 | 11.2.0.2.v5 | 11.2.0.2.v6 | 11.2.0.2.v7</code></li><li><b>Version 11.2 (Only available in the following regions: eu-central-1,
        /// us-west-1):</b><code> 11.2.0.3.v1 | 11.2.0.3.v2 | 11.2.0.4.v1 | 11.2.0.4.v3</code></li></ul><para><b>Oracle Database Standard Edition One (oracle-se1)</b></para><ul><li><b>Version 11.2 (Only available in the following regions: us-west-1):</b><code> 11.2.0.2.v3 | 11.2.0.2.v4 | 11.2.0.2.v5 | 11.2.0.2.v6 | 11.2.0.2.v7</code></li><li><b>Version 11.2 (Only available in the following regions: eu-central-1,
        /// us-west-1):</b><code> 11.2.0.3.v1 | 11.2.0.3.v2 | 11.2.0.4.v1 | 11.2.0.4.v3</code></li></ul><para><b>Oracle Database Standard Edition One (oracle-se1)</b></para><ul><li><b>Version 11.2 (Only available in the following regions: us-west-1):</b><code> 11.2.0.2.v3 | 11.2.0.2.v4 | 11.2.0.2.v5 | 11.2.0.2.v6 | 11.2.0.2.v7</code></li><li><b>Version 11.2 (Only available in the following regions: eu-central-1,
        /// us-west-1):</b><code> 11.2.0.3.v1 | 11.2.0.3.v2 | 11.2.0.4.v1 | 11.2.0.4.v3</code></li></ul><para><b>PostgreSQL</b></para><ul><li><b>Version 9.3 (Only available in the following regions: ap-northeast-1,
        /// ap-southeast-1, ap-southeast-2, eu-west-1, sa-east-1, us-west-1, us-west-2):</b><code>
        /// 9.3.1 | 9.3.2</code></li><li><b>Version 9.3 (Available in all regions):</b><code>
        /// 9.3.3 | 9.3.5</code></li></ul><para><b>PostgreSQL</b></para><ul><li><b>Version 9.3 (Only available in the following regions: ap-northeast-1,
        /// ap-southeast-1, ap-southeast-2, eu-west-1, sa-east-1, us-west-1, us-west-2):</b><code>
        /// 9.3.1 | 9.3.2</code></li><li><b>Version 9.3 (Available in all regions):</b><code>
        /// 9.3.3 | 9.3.5</code></li></ul><para><b>Microsoft SQL Server Enterprise Edition (sqlserver-ee)</b></para><ul><li><b>Version 10.50 (Only available in the following regions: eu-central-1,
        /// us-west-1):</b><code> 10.50.2789.0.v1</code></li><li><b>Version 11.00 (Only available
        /// in the following regions: eu-central-1, us-west-1):</b><code> 11.00.2100.60.v1</code></li></ul><para><b>Microsoft SQL Server Enterprise Edition (sqlserver-ee)</b></para><ul><li><b>Version 10.50 (Only available in the following regions: eu-central-1,
        /// us-west-1):</b><code> 10.50.2789.0.v1</code></li><li><b>Version 11.00 (Only available
        /// in the following regions: eu-central-1, us-west-1):</b><code> 11.00.2100.60.v1</code></li></ul><para><b>Microsoft SQL Server Express Edition (sqlserver-ex)</b></para><ul><li><b>Version 10.50 (Available in all regions):</b><code> 10.50.2789.0.v1</code></li><li><b>Version 11.00 (Available in all regions):</b><code> 11.00.2100.60.v1</code></li></ul><para><b>Microsoft SQL Server Express Edition (sqlserver-ex)</b></para><ul><li><b>Version 10.50 (Available in all regions):</b><code> 10.50.2789.0.v1</code></li><li><b>Version 11.00 (Available in all regions):</b><code> 11.00.2100.60.v1</code></li></ul><para><b>Microsoft SQL Server Standard Edition (sqlserver-se)</b></para><ul><li><b>Version 10.50 (Available in all regions):</b><code> 10.50.2789.0.v1</code></li><li><b>Version 11.00 (Available in all regions):</b><code> 11.00.2100.60.v1</code></li></ul><para><b>Microsoft SQL Server Standard Edition (sqlserver-se)</b></para><ul><li><b>Version 10.50 (Available in all regions):</b><code> 10.50.2789.0.v1</code></li><li><b>Version 11.00 (Available in all regions):</b><code> 11.00.2100.60.v1</code></li></ul><para><b>Microsoft SQL Server Web Edition (sqlserver-web)</b></para><ul><li><b>Version 10.50 (Available in all regions):</b><code> 10.50.2789.0.v1</code></li><li><b>Version 11.00 (Available in all regions):</b><code> 11.00.2100.60.v1</code></li></ul><para><b>Microsoft SQL Server Web Edition (sqlserver-web)</b></para><ul><li><b>Version 10.50 (Available in all regions):</b><code> 10.50.2789.0.v1</code></li><li><b>Version 11.00 (Available in all regions):</b><code> 11.00.2100.60.v1</code></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String EngineVersion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The amount of Provisioned IOPS (input/output operations per second) to be initially
        /// allocated for the DB instance. </para><para> Constraints: To use PIOPS, this value must be an integer greater than 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Iops { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The KMS key identifier for an encrypted DB instance. </para><para>The KMS key identifier is the Amazon Resoure Name (ARN) for the KMS encryption key.
        /// If you are creating a DB instance with the same AWS account that owns the KMS encryption
        /// key used to encrypt the new DB instance, then you can use the KMS key alias instead
        /// of the ARN for the KM encryption key.</para><para>If the <code>StorageEncrypted</code> parameter is true, and you do not specify a value
        /// for the <code>KmsKeyId</code> parameter, then Amazon RDS will use your default encryption
        /// key. AWS KMS creates the default encryption key for your AWS account. Your AWS account
        /// has a different default encryption key for each AWS region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String KmsKeyId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> License model information for this DB instance. </para><para> Valid values: <code>license-included</code> | <code>bring-your-own-license</code>
        /// | <code>general-public-license</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String LicenseModel { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of master user for the client DB instance. </para><para><b>MySQL</b></para><para>Constraints:</para><ul><li>Must be 1 to 16 alphanumeric characters.</li><li>First character must be
        /// a letter.</li><li>Cannot be a reserved word for the chosen database engine.</li></ul><para>Type: String</para><para><b>Oracle</b></para><para>Constraints:</para><ul><li>Must be 1 to 30 alphanumeric characters.</li><li>First character must be
        /// a letter.</li><li>Cannot be a reserved word for the chosen database engine.</li></ul><para><b>SQL Server</b></para><para>Constraints:</para><ul><li>Must be 1 to 128 alphanumeric characters.</li><li>First character must
        /// be a letter.</li><li>Cannot be a reserved word for the chosen database engine.</li></ul><para><b>PostgreSQL</b></para><para>Constraints:</para><ul><li>Must be 1 to 63 alphanumeric characters.</li><li>First character must be
        /// a letter.</li><li>Cannot be a reserved word for the chosen database engine.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String MasterUsername { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The password for the master database user. Can be any printable ASCII character except
        /// "/", """, or "@". </para><para>Type: String</para><para><b>MySQL</b></para><para> Constraints: Must contain from 8 to 41 characters. </para><para><b>Oracle</b></para><para> Constraints: Must contain from 8 to 30 characters. </para><para><b>SQL Server</b></para><para> Constraints: Must contain from 8 to 128 characters. </para><para><b>PostgreSQL</b></para><para> Constraints: Must contain from 8 to 128 characters. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String MasterUserPassword { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Specifies if the DB instance is a Multi-AZ deployment. You cannot set the AvailabilityZone
        /// parameter if the MultiAZ parameter is set to true. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean MultiAZ { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Indicates that the DB instance should be associated with the specified option group.
        /// </para><para> Permanent options, such as the TDE option for Oracle Advanced Security TDE, cannot
        /// be removed from an option group, and that option group cannot be removed from a DB
        /// instance once it is associated with a DB instance </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String OptionGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The port number on which the database accepts connections. </para><para><b>MySQL</b></para><para> Default: <code>3306</code></para><para> Valid Values: <code>1150-65535</code></para><para>Type: Integer </para><para><b>PostgreSQL</b></para><para> Default: <code>5432</code></para><para> Valid Values: <code>1150-65535</code></para><para>Type: Integer </para><para><b>Oracle</b></para><para> Default: <code>1521</code></para><para> Valid Values: <code>1150-65535</code></para><para><b>SQL Server</b></para><para> Default: <code>1433</code></para><para> Valid Values: <code>1150-65535</code> except for <code>1434</code>, <code>3389</code>,
        /// <code>47001</code>, <code>49152</code>, and <code>49152</code> through <code>49156</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Port { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The daily time range during which automated backups are created if automated backups
        /// are enabled, using the <code>BackupRetentionPeriod</code> parameter. For more information,
        /// see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Overview.BackingUpAndRestoringAmazonRDSInstances.html">DB
        /// Instance Backups</a>. </para><para> Default: A 30-minute window selected at random from an 8-hour block of time per region.
        /// See the Amazon RDS User Guide for the time blocks for each region from which the default
        /// backup windows are assigned. </para><para> Constraints: Must be in the format <code>hh24:mi-hh24:mi</code>. Times should be
        /// Universal Time Coordinated (UTC). Must not conflict with the preferred maintenance
        /// window. Must be at least 30 minutes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PreferredBackupWindow { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The weekly time range (in UTC) during which system maintenance can occur. For more
        /// information, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBMaintenance.html">DB
        /// Instance Maintenance</a>. </para><para> Format: <code>ddd:hh24:mi-ddd:hh24:mi</code></para><para> Default: A 30-minute window selected at random from an 8-hour block of time per region,
        /// occurring on a random day of the week. To see the time blocks available, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/AdjustingTheMaintenanceWindow.html">
        /// Adjusting the Preferred Maintenance Window</a> in the Amazon RDS User Guide. </para><para>Valid Days: Mon, Tue, Wed, Thu, Fri, Sat, Sun</para><para>Constraints: Minimum 30-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PreferredMaintenanceWindow { get; set; }
        
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
        /// <para> Specifies whether the DB instance is encrypted. </para><para> Default: false </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean StorageEncrypted { get; set; }
        
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
        /// <para>
        /// <para> A list of EC2 VPC security groups to associate with this DB instance. </para><para> Default: The default EC2 VPC security group for the DB subnet group's VPC. </para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSDBInstance (CreateDBInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("AllocatedStorage"))
                context.AllocatedStorage = this.AllocatedStorage;
            if (ParameterWasBound("AutoMinorVersionUpgrade"))
                context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AvailabilityZone = this.AvailabilityZone;
            if (ParameterWasBound("BackupRetentionPeriod"))
                context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.CharacterSetName = this.CharacterSetName;
            context.DBInstanceClass = this.DBInstanceClass;
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            context.DBName = this.DBName;
            context.DBParameterGroupName = this.DBParameterGroupName;
            if (this.DBSecurityGroup != null)
            {
                context.DBSecurityGroups = new List<String>(this.DBSecurityGroup);
            }
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            if (ParameterWasBound("Iops"))
                context.Iops = this.Iops;
            context.KmsKeyId = this.KmsKeyId;
            context.LicenseModel = this.LicenseModel;
            context.MasterUsername = this.MasterUsername;
            context.MasterUserPassword = this.MasterUserPassword;
            if (ParameterWasBound("MultiAZ"))
                context.MultiAZ = this.MultiAZ;
            context.OptionGroupName = this.OptionGroupName;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
            if (ParameterWasBound("StorageEncrypted"))
                context.StorageEncrypted = this.StorageEncrypted;
            context.StorageType = this.StorageType;
            if (this.Tag != null)
            {
                context.Tags = new List<Tag>(this.Tag);
            }
            context.TdeCredentialArn = this.TdeCredentialArn;
            context.TdeCredentialPassword = this.TdeCredentialPassword;
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupIds = new List<String>(this.VpcSecurityGroupId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateDBInstanceRequest();
            
            if (cmdletContext.AllocatedStorage != null)
            {
                request.AllocatedStorage = cmdletContext.AllocatedStorage.Value;
            }
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.BackupRetentionPeriod != null)
            {
                request.BackupRetentionPeriod = cmdletContext.BackupRetentionPeriod.Value;
            }
            if (cmdletContext.CharacterSetName != null)
            {
                request.CharacterSetName = cmdletContext.CharacterSetName;
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
            if (cmdletContext.DBParameterGroupName != null)
            {
                request.DBParameterGroupName = cmdletContext.DBParameterGroupName;
            }
            if (cmdletContext.DBSecurityGroups != null)
            {
                request.DBSecurityGroups = cmdletContext.DBSecurityGroups;
            }
            if (cmdletContext.DBSubnetGroupName != null)
            {
                request.DBSubnetGroupName = cmdletContext.DBSubnetGroupName;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.Iops != null)
            {
                request.Iops = cmdletContext.Iops.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.LicenseModel != null)
            {
                request.LicenseModel = cmdletContext.LicenseModel;
            }
            if (cmdletContext.MasterUsername != null)
            {
                request.MasterUsername = cmdletContext.MasterUsername;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
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
            if (cmdletContext.PreferredBackupWindow != null)
            {
                request.PreferredBackupWindow = cmdletContext.PreferredBackupWindow;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.StorageEncrypted != null)
            {
                request.StorageEncrypted = cmdletContext.StorageEncrypted.Value;
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
            if (cmdletContext.VpcSecurityGroupIds != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateDBInstance(request);
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
            public Int32? AllocatedStorage { get; set; }
            public Boolean? AutoMinorVersionUpgrade { get; set; }
            public String AvailabilityZone { get; set; }
            public Int32? BackupRetentionPeriod { get; set; }
            public String CharacterSetName { get; set; }
            public String DBInstanceClass { get; set; }
            public String DBInstanceIdentifier { get; set; }
            public String DBName { get; set; }
            public String DBParameterGroupName { get; set; }
            public List<String> DBSecurityGroups { get; set; }
            public String DBSubnetGroupName { get; set; }
            public String Engine { get; set; }
            public String EngineVersion { get; set; }
            public Int32? Iops { get; set; }
            public String KmsKeyId { get; set; }
            public String LicenseModel { get; set; }
            public String MasterUsername { get; set; }
            public String MasterUserPassword { get; set; }
            public Boolean? MultiAZ { get; set; }
            public String OptionGroupName { get; set; }
            public Int32? Port { get; set; }
            public String PreferredBackupWindow { get; set; }
            public String PreferredMaintenanceWindow { get; set; }
            public Boolean? PubliclyAccessible { get; set; }
            public Boolean? StorageEncrypted { get; set; }
            public String StorageType { get; set; }
            public List<Tag> Tags { get; set; }
            public String TdeCredentialArn { get; set; }
            public String TdeCredentialPassword { get; set; }
            public List<String> VpcSecurityGroupIds { get; set; }
        }
        
    }
}

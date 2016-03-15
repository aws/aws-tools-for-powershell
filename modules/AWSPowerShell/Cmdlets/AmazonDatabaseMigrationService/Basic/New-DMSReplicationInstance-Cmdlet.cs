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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Creates the replication instance using the specified parameters.
    /// 
    ///  <note />
    /// </summary>
    [Cmdlet("New", "DMSReplicationInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.ReplicationInstance")]
    [AWSCmdlet("Invokes the CreateReplicationInstance operation against AWS Database Migration Service.", Operation = new[] {"CreateReplicationInstance"})]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.ReplicationInstance",
        "This cmdlet returns a ReplicationInstance object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.CreateReplicationInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewDMSReplicationInstanceCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter AllocatedStorage
        /// <summary>
        /// <para>
        /// <para> The amount of storage (in gigabytes) to be initially allocated for the replication
        /// instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 AllocatedStorage { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para> Indicates that minor engine upgrades will be applied automatically to the replication
        /// instance during the maintenance window. </para><para>Default: <code>true</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para> The EC2 Availability Zone that the replication instance will be created in. </para><para> Default: A random, system-chosen Availability Zone in the endpoint's region. </para><para> Example: <code>us-east-1d</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para> The engine version number of the replication instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para> The KMS key identifier that will be used to encrypt the content on the replication
        /// instance. If you do not specify a value for the KmsKeyId parameter, then AWS DMS will
        /// use your default encryption key. AWS KMS creates the default encryption key for your
        /// AWS account. Your AWS account has a different default encryption key for each AWS
        /// region. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para> The weekly time range during which system maintenance can occur, in Universal Coordinated
        /// Time (UTC). </para><para> Format: <code>ddd:hh24:mi-ddd:hh24:mi</code></para><para> Default: A 30-minute window selected at random from an 8-hour block of time per region,
        /// occurring on a random day of the week. </para><para>Valid Days: Mon, Tue, Wed, Thu, Fri, Sat, Sun</para><para>Constraints: Minimum 30-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para> Specifies the accessibility options for the replication instance. A value of <code>true</code>
        /// represents an instance with a public IP address. A value of <code>false</code> represents
        /// an instance with a private IP address. The default value is <code>true</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter ReplicationInstanceClass
        /// <summary>
        /// <para>
        /// <para> The compute and memory capacity of the replication instance as specified by the replication
        /// instance class. </para><para> Valid Values: <code>dms.t2.micro | dms.t2.small | dms.t2.medium | dms.t2.large |
        /// dms.c4.large | dms.c4.xlarge | dms.c4.2xlarge | dms.c4.4xlarge </code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReplicationInstanceClass { get; set; }
        #endregion
        
        #region Parameter ReplicationInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The replication instance identifier. This parameter is stored as a lowercase string.</para><para>Constraints:</para><ul><li>Must contain from 1 to 63 alphanumeric characters or hyphens.</li><li>First
        /// character must be a letter.</li><li>Cannot end with a hyphen or contain two consecutive
        /// hyphens.</li></ul><para>Example: <code>myrepinstance</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReplicationInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter ReplicationSubnetGroupIdentifier
        /// <summary>
        /// <para>
        /// <para> A subnet group to associate with the replication instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationSubnetGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to be associated with the replication instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DatabaseMigrationService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("KmsKeyId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DMSReplicationInstance (CreateReplicationInstance)"))
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
            context.EngineVersion = this.EngineVersion;
            context.KmsKeyId = this.KmsKeyId;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
            context.ReplicationInstanceClass = this.ReplicationInstanceClass;
            context.ReplicationInstanceIdentifier = this.ReplicationInstanceIdentifier;
            context.ReplicationSubnetGroupIdentifier = this.ReplicationSubnetGroupIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DatabaseMigrationService.Model.Tag>(this.Tag);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DatabaseMigrationService.Model.CreateReplicationInstanceRequest();
            
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
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.ReplicationInstanceClass != null)
            {
                request.ReplicationInstanceClass = cmdletContext.ReplicationInstanceClass;
            }
            if (cmdletContext.ReplicationInstanceIdentifier != null)
            {
                request.ReplicationInstanceIdentifier = cmdletContext.ReplicationInstanceIdentifier;
            }
            if (cmdletContext.ReplicationSubnetGroupIdentifier != null)
            {
                request.ReplicationSubnetGroupIdentifier = cmdletContext.ReplicationSubnetGroupIdentifier;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateReplicationInstance(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReplicationInstance;
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
            public System.Int32? AllocatedStorage { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String ReplicationInstanceClass { get; set; }
            public System.String ReplicationInstanceIdentifier { get; set; }
            public System.String ReplicationSubnetGroupIdentifier { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.Tag> Tags { get; set; }
        }
        
    }
}

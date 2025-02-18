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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates a blue/green deployment.
    /// 
    ///  
    /// <para>
    /// A blue/green deployment creates a staging environment that copies the production environment.
    /// In a blue/green deployment, the blue environment is the current production environment.
    /// The green environment is the staging environment, and it stays in sync with the current
    /// production environment.
    /// </para><para>
    /// You can make changes to the databases in the green environment without affecting production
    /// workloads. For example, you can upgrade the major or minor DB engine version, change
    /// database parameters, or make schema changes in the staging environment. You can thoroughly
    /// test changes in the green environment. When ready, you can switch over the environments
    /// to promote the green environment to be the new production environment. The switchover
    /// typically takes under a minute.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/blue-green-deployments.html">Using
    /// Amazon RDS Blue/Green Deployments for database updates</a> in the <i>Amazon RDS User
    /// Guide</i> and <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/blue-green-deployments.html">
    /// Using Amazon RDS Blue/Green Deployments for database updates</a> in the <i>Amazon
    /// Aurora User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "RDSBlueGreenDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.BlueGreenDeployment")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateBlueGreenDeployment API operation.", Operation = new[] {"CreateBlueGreenDeployment"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateBlueGreenDeploymentResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.BlueGreenDeployment or Amazon.RDS.Model.CreateBlueGreenDeploymentResponse",
        "This cmdlet returns an Amazon.RDS.Model.BlueGreenDeployment object.",
        "The service call response (type Amazon.RDS.Model.CreateBlueGreenDeploymentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRDSBlueGreenDeploymentCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BlueGreenDeploymentName
        /// <summary>
        /// <para>
        /// <para>The name of the blue/green deployment.</para><para>Constraints:</para><ul><li><para>Can't be the same as an existing blue/green deployment name in the same account and
        /// Amazon Web Services Region.</para></li></ul>
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
        public System.String BlueGreenDeploymentName { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source production database.</para><para>Specify the database that you want to clone. The blue/green deployment creates this
        /// database in the green environment. You can make updates to the database in the green
        /// environment, such as an engine version upgrade. When you are ready, you can switch
        /// the database in the green environment to be the production database.</para>
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
        public System.String Source { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the blue/green deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetAllocatedStorage
        /// <summary>
        /// <para>
        /// <para>The amount of storage in gibibytes (GiB) to allocate for the green DB instance. You
        /// can choose to increase or decrease the allocated storage on the green DB instance.</para><para>This setting doesn't apply to Amazon Aurora blue/green deployments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TargetAllocatedStorage { get; set; }
        #endregion
        
        #region Parameter TargetDBClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The DB cluster parameter group associated with the Aurora DB cluster in the green
        /// environment.</para><para>To test parameter changes, specify a DB cluster parameter group that is different
        /// from the one associated with the source DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetDBClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter TargetDBInstanceClass
        /// <summary>
        /// <para>
        /// <para>Specify the DB instance class for the databases in the green environment.</para><para>This parameter only applies to RDS DB instances, because DB instances within an Aurora
        /// DB cluster can have multiple different instance classes. If you're creating a blue/green
        /// deployment from an Aurora DB cluster, don't specify this parameter. After the green
        /// environment is created, you can individually modify the instance classes of the DB
        /// instances within the green DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetDBInstanceClass { get; set; }
        #endregion
        
        #region Parameter TargetDBParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The DB parameter group associated with the DB instance in the green environment.</para><para>To test parameter changes, specify a DB parameter group that is different from the
        /// one associated with the source DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetDBParameterGroupName { get; set; }
        #endregion
        
        #region Parameter TargetEngineVersion
        /// <summary>
        /// <para>
        /// <para>The engine version of the database in the green environment.</para><para>Specify the engine version to upgrade to in the green environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetEngineVersion { get; set; }
        #endregion
        
        #region Parameter TargetIops
        /// <summary>
        /// <para>
        /// <para>The amount of Provisioned IOPS (input/output operations per second) to allocate for
        /// the green DB instance. For information about valid IOPS values, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Storage.html">Amazon
        /// RDS DB instance storage</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting doesn't apply to Amazon Aurora blue/green deployments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TargetIops { get; set; }
        #endregion
        
        #region Parameter TargetStorageThroughput
        /// <summary>
        /// <para>
        /// <para>The storage throughput value for the green DB instance.</para><para>This setting applies only to the <c>gp3</c> storage type.</para><para>This setting doesn't apply to Amazon Aurora blue/green deployments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TargetStorageThroughput { get; set; }
        #endregion
        
        #region Parameter TargetStorageType
        /// <summary>
        /// <para>
        /// <para>The storage type to associate with the green DB instance.</para><para>Valid Values: <c>gp2 | gp3 | io1 | io2</c></para><para>This setting doesn't apply to Amazon Aurora blue/green deployments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetStorageType { get; set; }
        #endregion
        
        #region Parameter UpgradeTargetStorageConfig
        /// <summary>
        /// <para>
        /// <para>Whether to upgrade the storage file system configuration on the green database. This
        /// option migrates the green DB instance from the older 32-bit file system to the preferred
        /// configuration. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_PIOPS.StorageTypes.html#USER_PIOPS.UpgradeFileSystem">Upgrading
        /// the storage file system for a DB instance</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UpgradeTargetStorageConfig { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BlueGreenDeployment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateBlueGreenDeploymentResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateBlueGreenDeploymentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BlueGreenDeployment";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BlueGreenDeploymentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSBlueGreenDeployment (CreateBlueGreenDeployment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateBlueGreenDeploymentResponse, NewRDSBlueGreenDeploymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BlueGreenDeploymentName = this.BlueGreenDeploymentName;
            #if MODULAR
            if (this.BlueGreenDeploymentName == null && ParameterWasBound(nameof(this.BlueGreenDeploymentName)))
            {
                WriteWarning("You are passing $null as a value for parameter BlueGreenDeploymentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Source = this.Source;
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TargetAllocatedStorage = this.TargetAllocatedStorage;
            context.TargetDBClusterParameterGroupName = this.TargetDBClusterParameterGroupName;
            context.TargetDBInstanceClass = this.TargetDBInstanceClass;
            context.TargetDBParameterGroupName = this.TargetDBParameterGroupName;
            context.TargetEngineVersion = this.TargetEngineVersion;
            context.TargetIops = this.TargetIops;
            context.TargetStorageThroughput = this.TargetStorageThroughput;
            context.TargetStorageType = this.TargetStorageType;
            context.UpgradeTargetStorageConfig = this.UpgradeTargetStorageConfig;
            
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
            var request = new Amazon.RDS.Model.CreateBlueGreenDeploymentRequest();
            
            if (cmdletContext.BlueGreenDeploymentName != null)
            {
                request.BlueGreenDeploymentName = cmdletContext.BlueGreenDeploymentName;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetAllocatedStorage != null)
            {
                request.TargetAllocatedStorage = cmdletContext.TargetAllocatedStorage.Value;
            }
            if (cmdletContext.TargetDBClusterParameterGroupName != null)
            {
                request.TargetDBClusterParameterGroupName = cmdletContext.TargetDBClusterParameterGroupName;
            }
            if (cmdletContext.TargetDBInstanceClass != null)
            {
                request.TargetDBInstanceClass = cmdletContext.TargetDBInstanceClass;
            }
            if (cmdletContext.TargetDBParameterGroupName != null)
            {
                request.TargetDBParameterGroupName = cmdletContext.TargetDBParameterGroupName;
            }
            if (cmdletContext.TargetEngineVersion != null)
            {
                request.TargetEngineVersion = cmdletContext.TargetEngineVersion;
            }
            if (cmdletContext.TargetIops != null)
            {
                request.TargetIops = cmdletContext.TargetIops.Value;
            }
            if (cmdletContext.TargetStorageThroughput != null)
            {
                request.TargetStorageThroughput = cmdletContext.TargetStorageThroughput.Value;
            }
            if (cmdletContext.TargetStorageType != null)
            {
                request.TargetStorageType = cmdletContext.TargetStorageType;
            }
            if (cmdletContext.UpgradeTargetStorageConfig != null)
            {
                request.UpgradeTargetStorageConfig = cmdletContext.UpgradeTargetStorageConfig.Value;
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
        
        private Amazon.RDS.Model.CreateBlueGreenDeploymentResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateBlueGreenDeploymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateBlueGreenDeployment");
            try
            {
                return client.CreateBlueGreenDeploymentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BlueGreenDeploymentName { get; set; }
            public System.String Source { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.Int32? TargetAllocatedStorage { get; set; }
            public System.String TargetDBClusterParameterGroupName { get; set; }
            public System.String TargetDBInstanceClass { get; set; }
            public System.String TargetDBParameterGroupName { get; set; }
            public System.String TargetEngineVersion { get; set; }
            public System.Int32? TargetIops { get; set; }
            public System.Int32? TargetStorageThroughput { get; set; }
            public System.String TargetStorageType { get; set; }
            public System.Boolean? UpgradeTargetStorageConfig { get; set; }
            public System.Func<Amazon.RDS.Model.CreateBlueGreenDeploymentResponse, NewRDSBlueGreenDeploymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BlueGreenDeployment;
        }
        
    }
}

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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates an Aurora global database spread across multiple Amazon Web Services Regions.
    /// The global database contains a single primary cluster with read-write capability,
    /// and a read-only secondary cluster that receives data from the primary cluster through
    /// high-speed replication performed by the Aurora storage subsystem.
    /// 
    ///  
    /// <para>
    /// You can create a global database that is initially empty, and then create the primary
    /// and secondary DB clusters in the global database. Or you can specify an existing Aurora
    /// cluster during the create operation, and this cluster becomes the primary cluster
    /// of the global database.
    /// </para><note><para>
    /// This operation applies only to Aurora DB clusters.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "RDSGlobalCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.GlobalCluster")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateGlobalCluster API operation.", Operation = new[] {"CreateGlobalCluster"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateGlobalClusterResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.GlobalCluster or Amazon.RDS.Model.CreateGlobalClusterResponse",
        "This cmdlet returns an Amazon.RDS.Model.GlobalCluster object.",
        "The service call response (type Amazon.RDS.Model.CreateGlobalClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRDSGlobalClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name for your database of up to 64 alphanumeric characters. If you don't specify
        /// a name, Amazon Aurora doesn't create a database in the global database cluster.</para><para>Constraints:</para><ul><li><para>Can't be specified if <c>SourceDBClusterIdentifier</c> is specified. In this case,
        /// Amazon Aurora uses the database name from the source DB cluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable deletion protection for the new global database cluster.
        /// The global database can't be deleted when deletion protection is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The database engine to use for this global database cluster.</para><para>Valid Values: <c>aurora-mysql | aurora-postgresql</c></para><para>Constraints:</para><ul><li><para>Can't be specified if <c>SourceDBClusterIdentifier</c> is specified. In this case,
        /// Amazon Aurora uses the engine of the source DB cluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineLifecycleSupport
        /// <summary>
        /// <para>
        /// <para>The life cycle type for this global database cluster.</para><note><para>By default, this value is set to <c>open-source-rds-extended-support</c>, which enrolls
        /// your global cluster into Amazon RDS Extended Support. At the end of standard support,
        /// you can avoid charges for Extended Support by setting the value to <c>open-source-rds-extended-support-disabled</c>.
        /// In this case, creating the global cluster will fail if the DB major version is past
        /// its end of standard support date.</para></note><para>This setting only applies to Aurora PostgreSQL-based global databases.</para><para>You can use this setting to enroll your global cluster into Amazon RDS Extended Support.
        /// With RDS Extended Support, you can run the selected major engine version on your global
        /// cluster past the end of standard support for that engine version. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/extended-support.html">Amazon
        /// RDS Extended Support with Amazon Aurora</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Valid Values: <c>open-source-rds-extended-support | open-source-rds-extended-support-disabled</c></para><para>Default: <c>open-source-rds-extended-support</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineLifecycleSupport { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The engine version to use for this global database cluster.</para><para>Constraints:</para><ul><li><para>Can't be specified if <c>SourceDBClusterIdentifier</c> is specified. In this case,
        /// Amazon Aurora uses the engine version of the source DB cluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter GlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The cluster identifier for this global database cluster. This parameter is stored
        /// as a lowercase string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GlobalClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceDBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) to use as the primary cluster of the global database.</para><para>If you provide a value for this parameter, don't specify values for the following
        /// settings because Amazon Aurora uses the values from the specified source DB cluster:</para><ul><li><para><c>DatabaseName</c></para></li><li><para><c>Engine</c></para></li><li><para><c>EngineVersion</c></para></li><li><para><c>StorageEncrypted</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceDBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter StorageEncrypted
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable storage encryption for the new global database cluster.</para><para>Constraints:</para><ul><li><para>Can't be specified if <c>SourceDBClusterIdentifier</c> is specified. In this case,
        /// Amazon Aurora uses the setting from the source DB cluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StorageEncrypted { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the global cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateGlobalClusterResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateGlobalClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GlobalCluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatabaseName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatabaseName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatabaseName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatabaseName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSGlobalCluster (CreateGlobalCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateGlobalClusterResponse, NewRDSGlobalClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatabaseName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DatabaseName = this.DatabaseName;
            context.DeletionProtection = this.DeletionProtection;
            context.Engine = this.Engine;
            context.EngineLifecycleSupport = this.EngineLifecycleSupport;
            context.EngineVersion = this.EngineVersion;
            context.GlobalClusterIdentifier = this.GlobalClusterIdentifier;
            context.SourceDBClusterIdentifier = this.SourceDBClusterIdentifier;
            context.StorageEncrypted = this.StorageEncrypted;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
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
            var request = new Amazon.RDS.Model.CreateGlobalClusterRequest();
            
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineLifecycleSupport != null)
            {
                request.EngineLifecycleSupport = cmdletContext.EngineLifecycleSupport;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.GlobalClusterIdentifier != null)
            {
                request.GlobalClusterIdentifier = cmdletContext.GlobalClusterIdentifier;
            }
            if (cmdletContext.SourceDBClusterIdentifier != null)
            {
                request.SourceDBClusterIdentifier = cmdletContext.SourceDBClusterIdentifier;
            }
            if (cmdletContext.StorageEncrypted != null)
            {
                request.StorageEncrypted = cmdletContext.StorageEncrypted.Value;
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
        
        private Amazon.RDS.Model.CreateGlobalClusterResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateGlobalClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateGlobalCluster");
            try
            {
                #if DESKTOP
                return client.CreateGlobalCluster(request);
                #elif CORECLR
                return client.CreateGlobalClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String DatabaseName { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineLifecycleSupport { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String GlobalClusterIdentifier { get; set; }
            public System.String SourceDBClusterIdentifier { get; set; }
            public System.Boolean? StorageEncrypted { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.RDS.Model.CreateGlobalClusterResponse, NewRDSGlobalClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalCluster;
        }
        
    }
}

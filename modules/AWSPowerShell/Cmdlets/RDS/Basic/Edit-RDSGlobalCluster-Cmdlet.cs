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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Modify a setting for an Amazon Aurora global cluster. You can change one or more
    /// database configuration parameters by specifying these parameters and the new values
    /// in the request. For more information on Amazon Aurora, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/CHAP_AuroraOverview.html">
    /// What Is Amazon Aurora?</a> in the <i>Amazon Aurora User Guide.</i><note><para>
    /// This action only applies to Aurora DB clusters.
    /// </para></note>
    /// </summary>
    [Cmdlet("Edit", "RDSGlobalCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.GlobalCluster")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyGlobalCluster API operation.", Operation = new[] {"ModifyGlobalCluster"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyGlobalClusterResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.GlobalCluster or Amazon.RDS.Model.ModifyGlobalClusterResponse",
        "This cmdlet returns an Amazon.RDS.Model.GlobalCluster object.",
        "The service call response (type Amazon.RDS.Model.ModifyGlobalClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRDSGlobalClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter AllowMajorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether major version upgrades are allowed.</para><para>Constraints: You must allow major version upgrades when specifying a value for the
        /// <code>EngineVersion</code> parameter that is a different major version than the DB
        /// cluster's current version.</para><para>If you upgrade the major version of a global database, the cluster and DB instance
        /// parameter groups are set to the default parameter groups for the new version. Apply
        /// any custom parameter groups after completing the upgrade.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowMajorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para> Indicates if the global database cluster has deletion protection enabled. The global
        /// database cluster can't be deleted when deletion protection is enabled. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the database engine to which you want to upgrade. Changing this
        /// parameter results in an outage. The change is applied during the next maintenance
        /// window unless <code>ApplyImmediately</code> is enabled.</para><para>To list all of the available engine versions for <code>aurora</code> (for MySQL 5.6-compatible
        /// Aurora), use the following command:</para><para><code>aws rds describe-db-engine-versions --engine aurora --query '*[]|[?SupportsGlobalDatabases
        /// == `true`].[EngineVersion]'</code></para><para>To list all of the available engine versions for <code>aurora-mysql</code> (for MySQL
        /// 5.7-compatible Aurora), use the following command:</para><para><code>aws rds describe-db-engine-versions --engine aurora-mysql --query '*[]|[?SupportsGlobalDatabases
        /// == `true`].[EngineVersion]'</code></para><para>To list all of the available engine versions for <code>aurora-postgresql</code>, use
        /// the following command:</para><para><code>aws rds describe-db-engine-versions --engine aurora-postgresql --query '*[]|[?SupportsGlobalDatabases
        /// == `true`].[EngineVersion]'</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter GlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para> The DB cluster identifier for the global cluster being modified. This parameter isn't
        /// case-sensitive. </para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing global database cluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GlobalClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter NewGlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para> The new cluster identifier for the global database cluster when modifying a global
        /// database cluster. This value is stored as a lowercase string. </para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens</para></li><li><para>The first character must be a letter</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens</para></li></ul><para>Example: <code>my-cluster2</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewGlobalClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyGlobalClusterResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyGlobalClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GlobalCluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GlobalClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GlobalClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GlobalClusterIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GlobalClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSGlobalCluster (ModifyGlobalCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyGlobalClusterResponse, EditRDSGlobalClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GlobalClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllowMajorVersionUpgrade = this.AllowMajorVersionUpgrade;
            context.DeletionProtection = this.DeletionProtection;
            context.EngineVersion = this.EngineVersion;
            context.GlobalClusterIdentifier = this.GlobalClusterIdentifier;
            context.NewGlobalClusterIdentifier = this.NewGlobalClusterIdentifier;
            
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
            var request = new Amazon.RDS.Model.ModifyGlobalClusterRequest();
            
            if (cmdletContext.AllowMajorVersionUpgrade != null)
            {
                request.AllowMajorVersionUpgrade = cmdletContext.AllowMajorVersionUpgrade.Value;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.GlobalClusterIdentifier != null)
            {
                request.GlobalClusterIdentifier = cmdletContext.GlobalClusterIdentifier;
            }
            if (cmdletContext.NewGlobalClusterIdentifier != null)
            {
                request.NewGlobalClusterIdentifier = cmdletContext.NewGlobalClusterIdentifier;
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
        
        private Amazon.RDS.Model.ModifyGlobalClusterResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyGlobalClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyGlobalCluster");
            try
            {
                #if DESKTOP
                return client.ModifyGlobalCluster(request);
                #elif CORECLR
                return client.ModifyGlobalClusterAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllowMajorVersionUpgrade { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String GlobalClusterIdentifier { get; set; }
            public System.String NewGlobalClusterIdentifier { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyGlobalClusterResponse, EditRDSGlobalClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalCluster;
        }
        
    }
}

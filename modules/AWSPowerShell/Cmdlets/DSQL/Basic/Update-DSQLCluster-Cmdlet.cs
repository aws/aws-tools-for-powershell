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
using Amazon.DSQL;
using Amazon.DSQL.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DSQL
{
    /// <summary>
    /// The <i>UpdateCluster</i> API allows you to modify both single-Region and multi-Region
    /// cluster configurations. With the <i>multiRegionProperties</i> parameter, you can add
    /// or modify witness Region support and manage peer relationships with clusters in other
    /// Regions.
    /// 
    ///  <note><para>
    /// Note that updating multi-Region clusters requires additional IAM permissions beyond
    /// those needed for standard cluster updates, as detailed in the Permissions section.
    /// </para></note><para><b>Required permissions</b></para><dl><dt>dsql:UpdateCluster</dt><dd><para>
    /// Permission to update a DSQL cluster.
    /// </para><para>
    /// Resources: <c>arn:aws:dsql:<i>region</i>:<i>account-id</i>:cluster/<i>cluster-id</i></c></para></dd></dl><dl><dt>dsql:PutMultiRegionProperties</dt><dd><para>
    /// Permission to configure multi-Region properties for a cluster.
    /// </para><para>
    /// Resources: <c>arn:aws:dsql:<i>region</i>:<i>account-id</i>:cluster/<i>cluster-id</i></c></para></dd></dl><dl><dt>dsql:GetCluster</dt><dd><para>
    /// Permission to retrieve cluster information.
    /// </para><para>
    /// Resources: <c>arn:aws:dsql:<i>region</i>:<i>account-id</i>:cluster/<i>cluster-id</i></c></para></dd><dt>dsql:AddPeerCluster</dt><dd><para>
    /// Permission to add peer clusters.
    /// </para><para>
    /// Resources:
    /// </para><ul><li><para>
    /// Local cluster: <c>arn:aws:dsql:<i>region</i>:<i>account-id</i>:cluster/<i>cluster-id</i></c></para></li><li><para>
    /// Each peer cluster: exact ARN of each specified peer cluster
    /// </para></li></ul></dd><dt>dsql:RemovePeerCluster</dt><dd><para>
    /// Permission to remove peer clusters. The <i>dsql:RemovePeerCluster</i> permission uses
    /// a wildcard ARN pattern to simplify permission management during updates.
    /// </para><para>
    /// Resources: <c>arn:aws:dsql:*:<i>account-id</i>:cluster/*</c></para></dd></dl><dl><dt>dsql:PutWitnessRegion</dt><dd><para>
    /// Permission to set a witness Region.
    /// </para><para>
    /// Resources: <c>arn:aws:dsql:<i>region</i>:<i>account-id</i>:cluster/<i>cluster-id</i></c></para><para>
    /// Condition Keys: dsql:WitnessRegion (matching the specified witness Region)
    /// </para><para><b>This permission is checked both in the cluster Region and in the witness Region.</b></para></dd></dl><important><ul><li><para>
    /// The witness region specified in <c>multiRegionProperties.witnessRegion</c> cannot
    /// be the same as the cluster's Region.
    /// </para></li><li><para>
    /// When updating clusters with peer relationships, permissions are checked for both adding
    /// and removing peers.
    /// </para></li><li><para>
    /// The <c>dsql:RemovePeerCluster</c> permission uses a wildcard ARN pattern to simplify
    /// permission management during updates.
    /// </para></li></ul></important>
    /// </summary>
    [Cmdlet("Update", "DSQLCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DSQL.Model.UpdateClusterResponse")]
    [AWSCmdlet("Calls the Amazon Aurora DSQL UpdateCluster API operation.", Operation = new[] {"UpdateCluster"}, SelectReturnType = typeof(Amazon.DSQL.Model.UpdateClusterResponse))]
    [AWSCmdletOutput("Amazon.DSQL.Model.UpdateClusterResponse",
        "This cmdlet returns an Amazon.DSQL.Model.UpdateClusterResponse object containing multiple properties."
    )]
    public partial class UpdateDSQLClusterCmdlet : AmazonDSQLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MultiRegionProperties_Cluster
        /// <summary>
        /// <para>
        /// <para>The set of peered clusters that form the multi-Region cluster configuration. Each
        /// peered cluster represents a database instance in a different Region.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiRegionProperties_Clusters")]
        public System.String[] MultiRegionProperties_Cluster { get; set; }
        #endregion
        
        #region Parameter DeletionProtectionEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable deletion protection in your cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtectionEnabled { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The ID of the cluster you want to update.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter KmsEncryptionKey
        /// <summary>
        /// <para>
        /// <para>The KMS key that encrypts and protects the data on your cluster. You can specify the
        /// ARN, ID, or alias of an existing key or have Amazon Web Services create a default
        /// key for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsEncryptionKey { get; set; }
        #endregion
        
        #region Parameter MultiRegionProperties_WitnessRegion
        /// <summary>
        /// <para>
        /// <para>The Region that serves as the witness region for a multi-Region cluster. The witness
        /// Region helps maintain cluster consistency and quorum.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MultiRegionProperties_WitnessRegion { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully. The subsequent
        /// retries with the same client token return the result from the original successful
        /// request and they have no additional effect.</para><para>If you don't specify a client token, the Amazon Web Services SDK automatically generates
        /// one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DSQL.Model.UpdateClusterResponse).
        /// Specifying the name of a property of type Amazon.DSQL.Model.UpdateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DSQLCluster (UpdateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DSQL.Model.UpdateClusterResponse, UpdateDSQLClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DeletionProtectionEnabled = this.DeletionProtectionEnabled;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsEncryptionKey = this.KmsEncryptionKey;
            if (this.MultiRegionProperties_Cluster != null)
            {
                context.MultiRegionProperties_Cluster = new List<System.String>(this.MultiRegionProperties_Cluster);
            }
            context.MultiRegionProperties_WitnessRegion = this.MultiRegionProperties_WitnessRegion;
            
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
            var request = new Amazon.DSQL.Model.UpdateClusterRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeletionProtectionEnabled != null)
            {
                request.DeletionProtectionEnabled = cmdletContext.DeletionProtectionEnabled.Value;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.KmsEncryptionKey != null)
            {
                request.KmsEncryptionKey = cmdletContext.KmsEncryptionKey;
            }
            
             // populate MultiRegionProperties
            var requestMultiRegionPropertiesIsNull = true;
            request.MultiRegionProperties = new Amazon.DSQL.Model.MultiRegionProperties();
            List<System.String> requestMultiRegionProperties_multiRegionProperties_Cluster = null;
            if (cmdletContext.MultiRegionProperties_Cluster != null)
            {
                requestMultiRegionProperties_multiRegionProperties_Cluster = cmdletContext.MultiRegionProperties_Cluster;
            }
            if (requestMultiRegionProperties_multiRegionProperties_Cluster != null)
            {
                request.MultiRegionProperties.Clusters = requestMultiRegionProperties_multiRegionProperties_Cluster;
                requestMultiRegionPropertiesIsNull = false;
            }
            System.String requestMultiRegionProperties_multiRegionProperties_WitnessRegion = null;
            if (cmdletContext.MultiRegionProperties_WitnessRegion != null)
            {
                requestMultiRegionProperties_multiRegionProperties_WitnessRegion = cmdletContext.MultiRegionProperties_WitnessRegion;
            }
            if (requestMultiRegionProperties_multiRegionProperties_WitnessRegion != null)
            {
                request.MultiRegionProperties.WitnessRegion = requestMultiRegionProperties_multiRegionProperties_WitnessRegion;
                requestMultiRegionPropertiesIsNull = false;
            }
             // determine if request.MultiRegionProperties should be set to null
            if (requestMultiRegionPropertiesIsNull)
            {
                request.MultiRegionProperties = null;
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
        
        private Amazon.DSQL.Model.UpdateClusterResponse CallAWSServiceOperation(IAmazonDSQL client, Amazon.DSQL.Model.UpdateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Aurora DSQL", "UpdateCluster");
            try
            {
                return client.UpdateClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Boolean? DeletionProtectionEnabled { get; set; }
            public System.String Identifier { get; set; }
            public System.String KmsEncryptionKey { get; set; }
            public List<System.String> MultiRegionProperties_Cluster { get; set; }
            public System.String MultiRegionProperties_WitnessRegion { get; set; }
            public System.Func<Amazon.DSQL.Model.UpdateClusterResponse, UpdateDSQLClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

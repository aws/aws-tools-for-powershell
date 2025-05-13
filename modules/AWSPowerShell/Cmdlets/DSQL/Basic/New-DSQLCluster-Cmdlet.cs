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
using Amazon.DSQL;
using Amazon.DSQL.Model;

namespace Amazon.PowerShell.Cmdlets.DSQL
{
    /// <summary>
    /// This operation creates a cluster in Amazon Aurora DSQL. You need the following permissions
    /// to use this operation.
    /// 
    ///  
    /// <para>
    /// Permission to create a cluster.
    /// </para><dl><dt>dsql:CreateCluster</dt><dd><para>
    /// Resources: arn:aws:dsql:<i>region</i>:<i>account-id</i>:cluster/*
    /// </para></dd></dl><para>
    ///  Permission to add tags to a resource.
    /// </para><dl><dt>dsql:TagResource</dt><dd><para>
    /// Resources: arn:aws:dsql:<i>region</i>:<i>account-id</i>:cluster/*
    /// </para></dd></dl><para>
    /// Permission to configure multi-region properties for a cluster.
    /// </para><dl><dt>dsql:PutMultiRegionProperties</dt><dd><para>
    /// Resources: arn:aws:dsql:<i>region</i>:<i>account-id</i>:cluster/*
    /// </para></dd></dl><para>
    /// When specifying multiRegionProperties.clusters.
    /// </para><dl><dt>dsql:AddPeerCluster</dt><dd><para>
    /// Permission to add peer clusters.
    /// </para><para>
    /// Resources:
    /// </para><ul><li><para>
    /// Local cluster: arn:aws:dsql:<i>region</i>:<i>account-id</i>:cluster/*
    /// </para></li><li><para>
    /// Each peer cluster: exact ARN of each specified peer cluster
    /// </para></li></ul></dd></dl><para>
    /// When specifying multiRegionProperties.witnessRegion.
    /// </para><dl><dt>dsql:PutWitnessRegion</dt><dd><para>
    /// Permission to set a witness region.
    /// </para><para>
    /// Resources: arn:aws:dsql:<i>region</i>:<i>account-id</i>:cluster/*
    /// </para><para>
    /// Condition Keys: <c>dsql:WitnessRegion</c> (matching the specified witness region)
    /// </para><note><para>
    /// This permission is checked both in the cluster Region and in the witness Region.
    /// </para></note></dd></dl><important><para><b>Important Notes for Multi-Region Operations</b></para><ul><li><para>
    /// The witness region specified in <c>multiRegionProperties.witnessRegion</c> cannot
    /// be the same as the cluster's Region.
    /// </para></li><li><para>
    /// When updating clusters with peer relationships, permissions are checked for both adding
    /// and removing peers.
    /// </para></li></ul></important>
    /// </summary>
    [Cmdlet("New", "DSQLCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DSQL.Model.CreateClusterResponse")]
    [AWSCmdlet("Calls the Amazon Aurora DSQL CreateCluster API operation.", Operation = new[] {"CreateCluster"}, SelectReturnType = typeof(Amazon.DSQL.Model.CreateClusterResponse))]
    [AWSCmdletOutput("Amazon.DSQL.Model.CreateClusterResponse",
        "This cmdlet returns an Amazon.DSQL.Model.CreateClusterResponse object containing multiple properties."
    )]
    public partial class NewDSQLClusterCmdlet : AmazonDSQLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MultiRegionProperties_Cluster
        /// <summary>
        /// <para>
        /// <para>The set of linked clusters that form the multi-Region cluster configuration. Each
        /// linked cluster represents a database instance in a different Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiRegionProperties_Clusters")]
        public System.String[] MultiRegionProperties_Cluster { get; set; }
        #endregion
        
        #region Parameter DeletionProtectionEnabled
        /// <summary>
        /// <para>
        /// <para>If enabled, you can't delete your cluster. You must first disable this property before
        /// you can delete your cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.Boolean? DeletionProtectionEnabled { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of key and value pairs to use to tag your cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter MultiRegionProperties_WitnessRegion
        /// <summary>
        /// <para>
        /// <para>The that serves as the witness region for a multi-Region cluster. The witness region
        /// helps maintain cluster consistency and quorum.</para>
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
        /// idempotent request, if the original request completes successfully, the subsequent
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DSQL.Model.CreateClusterResponse).
        /// Specifying the name of a property of type Amazon.DSQL.Model.CreateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DeletionProtectionEnabled parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DeletionProtectionEnabled' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DeletionProtectionEnabled' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeletionProtectionEnabled), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSQLCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DSQL.Model.CreateClusterResponse, NewDSQLClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DeletionProtectionEnabled;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.DeletionProtectionEnabled = this.DeletionProtectionEnabled;
            if (this.MultiRegionProperties_Cluster != null)
            {
                context.MultiRegionProperties_Cluster = new List<System.String>(this.MultiRegionProperties_Cluster);
            }
            context.MultiRegionProperties_WitnessRegion = this.MultiRegionProperties_WitnessRegion;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.DSQL.Model.CreateClusterRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeletionProtectionEnabled != null)
            {
                request.DeletionProtectionEnabled = cmdletContext.DeletionProtectionEnabled.Value;
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
        
        private Amazon.DSQL.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonDSQL client, Amazon.DSQL.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Aurora DSQL", "CreateCluster");
            try
            {
                #if DESKTOP
                return client.CreateCluster(request);
                #elif CORECLR
                return client.CreateClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Boolean? DeletionProtectionEnabled { get; set; }
            public List<System.String> MultiRegionProperties_Cluster { get; set; }
            public System.String MultiRegionProperties_WitnessRegion { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.DSQL.Model.CreateClusterResponse, NewDSQLClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

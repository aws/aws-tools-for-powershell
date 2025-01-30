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
using Amazon.DocDBElastic;
using Amazon.DocDBElastic.Model;

namespace Amazon.PowerShell.Cmdlets.DOCE
{
    /// <summary>
    /// Restores an elastic cluster from a snapshot.
    /// </summary>
    [Cmdlet("Restore", "DOCEClusterFromSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDBElastic.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon DocumentDB Elastic Clusters RestoreClusterFromSnapshot API operation.", Operation = new[] {"RestoreClusterFromSnapshot"}, SelectReturnType = typeof(Amazon.DocDBElastic.Model.RestoreClusterFromSnapshotResponse))]
    [AWSCmdletOutput("Amazon.DocDBElastic.Model.Cluster or Amazon.DocDBElastic.Model.RestoreClusterFromSnapshotResponse",
        "This cmdlet returns an Amazon.DocDBElastic.Model.Cluster object.",
        "The service call response (type Amazon.DocDBElastic.Model.RestoreClusterFromSnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RestoreDOCEClusterFromSnapshotCmdlet : AmazonDocDBElasticClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the elastic cluster.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key identifier to use to encrypt the new Amazon DocumentDB elastic clusters
        /// cluster.</para><para>The KMS key identifier is the Amazon Resource Name (ARN) for the KMS encryption key.
        /// If you are creating a cluster using the same Amazon account that owns this KMS encryption
        /// key, you can use the KMS key alias instead of the ARN as the KMS encryption key.</para><para>If an encryption key is not specified here, Amazon DocumentDB uses the default encryption
        /// key that KMS creates for your account. Your account has a different default encryption
        /// key for each Amazon Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ShardCapacity
        /// <summary>
        /// <para>
        /// <para>The capacity of each shard in the new restored elastic cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ShardCapacity { get; set; }
        #endregion
        
        #region Parameter ShardInstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of replica instances applying to all shards in the elastic cluster. A <c>shardInstanceCount</c>
        /// value of 1 means there is one writer instance, and any additional instances are replicas
        /// that can be used for reads and to improve availability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ShardInstanceCount { get; set; }
        #endregion
        
        #region Parameter SnapshotArn
        /// <summary>
        /// <para>
        /// <para>The ARN identifier of the elastic cluster snapshot.</para>
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
        public System.String SnapshotArn { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 subnet IDs for the elastic cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of the tag names to be assigned to the restored elastic cluster, in the form
        /// of an array of key-value pairs in which the key is the tag name and the value is the
        /// key value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of EC2 VPC security groups to associate with the elastic cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDBElastic.Model.RestoreClusterFromSnapshotResponse).
        /// Specifying the name of a property of type Amazon.DocDBElastic.Model.RestoreClusterFromSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SnapshotArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SnapshotArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SnapshotArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-DOCEClusterFromSnapshot (RestoreClusterFromSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDBElastic.Model.RestoreClusterFromSnapshotResponse, RestoreDOCEClusterFromSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SnapshotArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            context.ShardCapacity = this.ShardCapacity;
            context.ShardInstanceCount = this.ShardInstanceCount;
            context.SnapshotArn = this.SnapshotArn;
            #if MODULAR
            if (this.SnapshotArn == null && ParameterWasBound(nameof(this.SnapshotArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
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
            var request = new Amazon.DocDBElastic.Model.RestoreClusterFromSnapshotRequest();
            
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.ShardCapacity != null)
            {
                request.ShardCapacity = cmdletContext.ShardCapacity.Value;
            }
            if (cmdletContext.ShardInstanceCount != null)
            {
                request.ShardInstanceCount = cmdletContext.ShardInstanceCount.Value;
            }
            if (cmdletContext.SnapshotArn != null)
            {
                request.SnapshotArn = cmdletContext.SnapshotArn;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.DocDBElastic.Model.RestoreClusterFromSnapshotResponse CallAWSServiceOperation(IAmazonDocDBElastic client, Amazon.DocDBElastic.Model.RestoreClusterFromSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB Elastic Clusters", "RestoreClusterFromSnapshot");
            try
            {
                #if DESKTOP
                return client.RestoreClusterFromSnapshot(request);
                #elif CORECLR
                return client.RestoreClusterFromSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterName { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Int32? ShardCapacity { get; set; }
            public System.Int32? ShardInstanceCount { get; set; }
            public System.String SnapshotArn { get; set; }
            public List<System.String> SubnetId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.DocDBElastic.Model.RestoreClusterFromSnapshotResponse, RestoreDOCEClusterFromSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}

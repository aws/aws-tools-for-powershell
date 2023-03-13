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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// <note><para>
    /// This action creates an Amazon S3 on Outposts bucket's replication configuration. To
    /// create an S3 bucket's replication configuration, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketReplication.html">PutBucketReplication</a>
    /// in the <i>Amazon S3 API Reference</i>. 
    /// </para></note><para>
    /// Creates a replication configuration or replaces an existing one. For information about
    /// S3 replication on Outposts configuration, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/AmazonS3/latest/userguide/S3OutpostsReplication.html">Replicating
    /// objects for Amazon Web Services Outposts</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><note><para>
    /// It can take a while to propagate <code>PUT</code> or <code>DELETE</code> requests
    /// for a replication configuration to all S3 on Outposts systems. Therefore, the replication
    /// configuration that's returned by a <code>GET</code> request soon after a <code>PUT</code>
    /// or <code>DELETE</code> request might return a more recent result than what's on the
    /// Outpost. If an Outpost is offline, the delay in updating the replication configuration
    /// on that Outpost can be significant.
    /// </para></note><para>
    /// Specify the replication configuration in the request body. In the replication configuration,
    /// you provide the following information:
    /// </para><ul><li><para>
    /// The name of the destination bucket or buckets where you want S3 on Outposts to replicate
    /// objects
    /// </para></li><li><para>
    /// The Identity and Access Management (IAM) role that S3 on Outposts can assume to replicate
    /// objects on your behalf
    /// </para></li><li><para>
    /// Other relevant information, such as replication rules
    /// </para></li></ul><para>
    /// A replication configuration must include at least one rule and can contain a maximum
    /// of 100. Each rule identifies a subset of objects to replicate by filtering the objects
    /// in the source Outposts bucket. To choose additional subsets of objects to replicate,
    /// add a rule for each subset.
    /// </para><para>
    /// To specify a subset of the objects in the source Outposts bucket to apply a replication
    /// rule to, add the <code>Filter</code> element as a child of the <code>Rule</code> element.
    /// You can filter objects based on an object key prefix, one or more object tags, or
    /// both. When you add the <code>Filter</code> element in the configuration, you must
    /// also add the following elements: <code>DeleteMarkerReplication</code>, <code>Status</code>,
    /// and <code>Priority</code>.
    /// </para><para>
    /// Using <code>PutBucketReplication</code> on Outposts requires that both the source
    /// and destination buckets must have versioning enabled. For information about enabling
    /// versioning on a bucket, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3OutpostsManagingVersioning.html">Managing
    /// S3 Versioning for your S3 on Outposts bucket</a>.
    /// </para><para>
    /// For information about S3 on Outposts replication failure reasons, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/outposts-replication-eventbridge.html#outposts-replication-failure-codes">Replication
    /// failure reasons</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><para><b>Handling Replication of Encrypted Objects</b></para><para>
    /// Outposts buckets are encrypted at all times. All the objects in the source Outposts
    /// bucket are encrypted and can be replicated. Also, all the replicas in the destination
    /// Outposts bucket are encrypted with the same encryption key as the objects in the source
    /// Outposts bucket.
    /// </para><para><b>Permissions</b></para><para>
    /// To create a <code>PutBucketReplication</code> request, you must have <code>s3-outposts:PutReplicationConfiguration</code>
    /// permissions for the bucket. The Outposts bucket owner has this permission by default
    /// and can grant it to others. For more information about permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3OutpostsIAM.html">Setting
    /// up IAM with S3 on Outposts</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3OutpostsBucketPolicy.html">Managing
    /// access to S3 on Outposts buckets</a>. 
    /// </para><note><para>
    /// To perform this operation, the user or role must also have the <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_use_passrole.html">iam:PassRole</a>
    /// permission.
    /// </para></note><para>
    /// All Amazon S3 on Outposts REST API requests for this action require an additional
    /// parameter of <code>x-amz-outpost-id</code> to be passed with the request. In addition,
    /// you must use an S3 on Outposts endpoint hostname prefix instead of <code>s3-control</code>.
    /// For an example of the request syntax for Amazon S3 on Outposts that uses the S3 on
    /// Outposts endpoint hostname prefix and the <code>x-amz-outpost-id</code> derived by
    /// using the access point ARN, see the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetBucketLifecycleConfiguration.html#API_control_GetBucketLifecycleConfiguration_Examples">Examples</a>
    /// section.
    /// </para><para>
    /// The following operations are related to <code>PutBucketReplication</code>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetBucketReplication.html">GetBucketReplication</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_DeleteBucketReplication.html">DeleteBucketReplication</a></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "S3CBucketReplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Control PutBucketReplication API operation.", Operation = new[] {"PutBucketReplication"}, SelectReturnType = typeof(Amazon.S3Control.Model.PutBucketReplicationResponse))]
    [AWSCmdletOutput("None or Amazon.S3Control.Model.PutBucketReplicationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Control.Model.PutBucketReplicationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3CBucketReplicationCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the Outposts bucket.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Bucket
        /// <summary>
        /// <para>
        /// <para>Specifies the S3 on Outposts bucket to set the configuration for.</para><para>For using this parameter with Amazon S3 on Outposts with the REST API, you must specify
        /// the name and the x-amz-outpost-id as well.</para><para>For using this parameter with S3 on Outposts with the Amazon Web Services SDK and
        /// CLI, you must specify the ARN of the bucket accessed in the format <code>arn:aws:s3-outposts:&lt;Region&gt;:&lt;account-id&gt;:outpost/&lt;outpost-id&gt;/bucket/&lt;my-bucket-name&gt;</code>.
        /// For example, to access the bucket <code>reports</code> through Outpost <code>my-outpost</code>
        /// owned by account <code>123456789012</code> in Region <code>us-west-2</code>, use the
        /// URL encoding of <code>arn:aws:s3-outposts:us-west-2:123456789012:outpost/my-outpost/bucket/reports</code>.
        /// The value must be URL encoded. </para>
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
        public System.String Bucket { get; set; }
        #endregion
        
        #region Parameter ReplicationConfiguration_Role
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Identity and Access Management (IAM) role that
        /// S3 on Outposts assumes when replicating objects. For information about S3 replication
        /// on Outposts configuration, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/outposts-replication-how-setup.html">Setting
        /// up replication</a> in the <i>Amazon S3 User Guide</i>.</para>
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
        public System.String ReplicationConfiguration_Role { get; set; }
        #endregion
        
        #region Parameter ReplicationConfiguration_Rule
        /// <summary>
        /// <para>
        /// <para>A container for one or more replication rules. A replication configuration must have
        /// at least one rule and can contain an array of 100 rules at the most. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ReplicationConfiguration_Rules")]
        public Amazon.S3Control.Model.ReplicationRule[] ReplicationConfiguration_Rule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.PutBucketReplicationResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3CBucketReplication (PutBucketReplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.PutBucketReplicationResponse, WriteS3CBucketReplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Bucket = this.Bucket;
            #if MODULAR
            if (this.Bucket == null && ParameterWasBound(nameof(this.Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicationConfiguration_Role = this.ReplicationConfiguration_Role;
            #if MODULAR
            if (this.ReplicationConfiguration_Role == null && ParameterWasBound(nameof(this.ReplicationConfiguration_Role)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationConfiguration_Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ReplicationConfiguration_Rule != null)
            {
                context.ReplicationConfiguration_Rule = new List<Amazon.S3Control.Model.ReplicationRule>(this.ReplicationConfiguration_Rule);
            }
            #if MODULAR
            if (this.ReplicationConfiguration_Rule == null && ParameterWasBound(nameof(this.ReplicationConfiguration_Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationConfiguration_Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.S3Control.Model.PutBucketReplicationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.Bucket != null)
            {
                request.Bucket = cmdletContext.Bucket;
            }
            
             // populate ReplicationConfiguration
            var requestReplicationConfigurationIsNull = true;
            request.ReplicationConfiguration = new Amazon.S3Control.Model.ReplicationConfiguration();
            System.String requestReplicationConfiguration_replicationConfiguration_Role = null;
            if (cmdletContext.ReplicationConfiguration_Role != null)
            {
                requestReplicationConfiguration_replicationConfiguration_Role = cmdletContext.ReplicationConfiguration_Role;
            }
            if (requestReplicationConfiguration_replicationConfiguration_Role != null)
            {
                request.ReplicationConfiguration.Role = requestReplicationConfiguration_replicationConfiguration_Role;
                requestReplicationConfigurationIsNull = false;
            }
            List<Amazon.S3Control.Model.ReplicationRule> requestReplicationConfiguration_replicationConfiguration_Rule = null;
            if (cmdletContext.ReplicationConfiguration_Rule != null)
            {
                requestReplicationConfiguration_replicationConfiguration_Rule = cmdletContext.ReplicationConfiguration_Rule;
            }
            if (requestReplicationConfiguration_replicationConfiguration_Rule != null)
            {
                request.ReplicationConfiguration.Rules = requestReplicationConfiguration_replicationConfiguration_Rule;
                requestReplicationConfigurationIsNull = false;
            }
             // determine if request.ReplicationConfiguration should be set to null
            if (requestReplicationConfigurationIsNull)
            {
                request.ReplicationConfiguration = null;
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
        
        private Amazon.S3Control.Model.PutBucketReplicationResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.PutBucketReplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "PutBucketReplication");
            try
            {
                #if DESKTOP
                return client.PutBucketReplication(request);
                #elif CORECLR
                return client.PutBucketReplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String Bucket { get; set; }
            public System.String ReplicationConfiguration_Role { get; set; }
            public List<Amazon.S3Control.Model.ReplicationRule> ReplicationConfiguration_Rule { get; set; }
            public System.Func<Amazon.S3Control.Model.PutBucketReplicationResponse, WriteS3CBucketReplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

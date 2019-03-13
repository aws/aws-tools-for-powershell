/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Creates a new, empty file system. The operation requires a creation token in the request
    /// that Amazon EFS uses to ensure idempotent creation (calling the operation with same
    /// creation token has no effect). If a file system does not currently exist that is owned
    /// by the caller's AWS account with the specified creation token, this operation does
    /// the following:
    /// 
    ///  <ul><li><para>
    /// Creates a new, empty file system. The file system will have an Amazon EFS assigned
    /// ID, and an initial lifecycle state <code>creating</code>.
    /// </para></li><li><para>
    /// Returns with the description of the created file system.
    /// </para></li></ul><para>
    /// Otherwise, this operation returns a <code>FileSystemAlreadyExists</code> error with
    /// the ID of the existing file system.
    /// </para><note><para>
    /// For basic use cases, you can use a randomly generated UUID for the creation token.
    /// </para></note><para>
    ///  The idempotent operation allows you to retry a <code>CreateFileSystem</code> call
    /// without risk of creating an extra file system. This can happen when an initial call
    /// fails in a way that leaves it uncertain whether or not a file system was actually
    /// created. An example might be that a transport level timeout occurred or your connection
    /// was reset. As long as you use the same creation token, if the initial call had succeeded
    /// in creating a file system, the client can learn of its existence from the <code>FileSystemAlreadyExists</code>
    /// error.
    /// </para><note><para>
    /// The <code>CreateFileSystem</code> call returns while the file system's lifecycle state
    /// is still <code>creating</code>. You can check the file system creation status by calling
    /// the <a>DescribeFileSystems</a> operation, which among other things returns the file
    /// system state.
    /// </para></note><para>
    /// This operation also takes an optional <code>PerformanceMode</code> parameter that
    /// you choose for your file system. We recommend <code>generalPurpose</code> performance
    /// mode for most file systems. File systems using the <code>maxIO</code> performance
    /// mode can scale to higher levels of aggregate throughput and operations per second
    /// with a tradeoff of slightly higher latencies for most file operations. The performance
    /// mode can't be changed after the file system has been created. For more information,
    /// see <a href="https://docs.aws.amazon.com/efs/latest/ug/performance.html#performancemodes.html">Amazon
    /// EFS: Performance Modes</a>.
    /// </para><para>
    /// After the file system is fully created, Amazon EFS sets its lifecycle state to <code>available</code>,
    /// at which point you can create one or more mount targets for the file system in your
    /// VPC. For more information, see <a>CreateMountTarget</a>. You mount your Amazon EFS
    /// file system on an EC2 instances in your VPC by using the mount target. For more information,
    /// see <a href="https://docs.aws.amazon.com/efs/latest/ug/how-it-works.html">Amazon EFS:
    /// How it Works</a>. 
    /// </para><para>
    ///  This operation requires permissions for the <code>elasticfilesystem:CreateFileSystem</code>
    /// action. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "EFSFileSystem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.Model.CreateFileSystemResponse")]
    [AWSCmdlet("Calls the Amazon Elastic File System CreateFileSystem API operation.", Operation = new[] {"CreateFileSystem"})]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.CreateFileSystemResponse",
        "This cmdlet returns a Amazon.ElasticFileSystem.Model.CreateFileSystemResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEFSFileSystemCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        #region Parameter CreationToken
        /// <summary>
        /// <para>
        /// <para>A string of up to 64 ASCII characters. Amazon EFS uses this to ensure idempotent creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CreationToken { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>A Boolean value that, if true, creates an encrypted file system. When creating an
        /// encrypted file system, you have the option of specifying <a>CreateFileSystemRequest$KmsKeyId</a>
        /// for an existing AWS Key Management Service (AWS KMS) customer master key (CMK). If
        /// you don't specify a CMK, then the default CMK for Amazon EFS, <code>/aws/elasticfilesystem</code>,
        /// is used to protect the encrypted file system. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Encrypted { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS KMS CMK to be used to protect the encrypted file system. This parameter
        /// is only required if you want to use a nondefault CMK. If this parameter is not specified,
        /// the default CMK for Amazon EFS is used. This ID can be in one of the following formats:</para><ul><li><para>Key ID - A unique identifier of the key, for example <code>1234abcd-12ab-34cd-56ef-1234567890ab</code>.</para></li><li><para>ARN - An Amazon Resource Name (ARN) for the key, for example <code>arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code>.</para></li><li><para>Key alias - A previously created display name for a key, for example <code>alias/projectKey1</code>.</para></li><li><para>Key alias ARN - An ARN for a key alias, for example <code>arn:aws:kms:us-west-2:444455556666:alias/projectKey1</code>.</para></li></ul><para>If <code>KmsKeyId</code> is specified, the <a>CreateFileSystemRequest$Encrypted</a>
        /// parameter must be set to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter PerformanceMode
        /// <summary>
        /// <para>
        /// <para>The performance mode of the file system. We recommend <code>generalPurpose</code>
        /// performance mode for most file systems. File systems using the <code>maxIO</code>
        /// performance mode can scale to higher levels of aggregate throughput and operations
        /// per second with a tradeoff of slightly higher latencies for most file operations.
        /// The performance mode can't be changed after the file system has been created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ElasticFileSystem.PerformanceMode")]
        public Amazon.ElasticFileSystem.PerformanceMode PerformanceMode { get; set; }
        #endregion
        
        #region Parameter ProvisionedThroughputInMibp
        /// <summary>
        /// <para>
        /// <para>The throughput, measured in MiB/s, that you want to provision for a file system that
        /// you're creating. The limit on throughput is 1024 MiB/s. You can get these limits increased
        /// by contacting AWS Support. For more information, see <a href="https://docs.aws.amazon.com/efs/latest/ug/limits.html#soft-limits">Amazon
        /// EFS Limits That You Can Increase</a> in the <i>Amazon EFS User Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ProvisionedThroughputInMibps")]
        public System.Double ProvisionedThroughputInMibp { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A value that specifies to create one or more tags associated with the file system.
        /// Each tag is a user-defined key-value pair. Name your file system on creation by including
        /// a <code>"Key":"Name","Value":"{value}"</code> key-value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.ElasticFileSystem.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ThroughputMode
        /// <summary>
        /// <para>
        /// <para>The throughput mode for the file system to be created. There are two throughput modes
        /// to choose from for your file system: bursting and provisioned. You can decrease your
        /// file system's throughput in Provisioned Throughput mode or change between the throughput
        /// modes as long as it’s been more than 24 hours since the last decrease or throughput
        /// mode change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ElasticFileSystem.ThroughputMode")]
        public Amazon.ElasticFileSystem.ThroughputMode ThroughputMode { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EFSFileSystem (CreateFileSystem)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CreationToken = this.CreationToken;
            if (ParameterWasBound("Encrypted"))
                context.Encrypted = this.Encrypted;
            context.KmsKeyId = this.KmsKeyId;
            context.PerformanceMode = this.PerformanceMode;
            if (ParameterWasBound("ProvisionedThroughputInMibp"))
                context.ProvisionedThroughputInMibps = this.ProvisionedThroughputInMibp;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.ElasticFileSystem.Model.Tag>(this.Tag);
            }
            context.ThroughputMode = this.ThroughputMode;
            
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
            var request = new Amazon.ElasticFileSystem.Model.CreateFileSystemRequest();
            
            if (cmdletContext.CreationToken != null)
            {
                request.CreationToken = cmdletContext.CreationToken;
            }
            if (cmdletContext.Encrypted != null)
            {
                request.Encrypted = cmdletContext.Encrypted.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.PerformanceMode != null)
            {
                request.PerformanceMode = cmdletContext.PerformanceMode;
            }
            if (cmdletContext.ProvisionedThroughputInMibps != null)
            {
                request.ProvisionedThroughputInMibps = cmdletContext.ProvisionedThroughputInMibps.Value;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.ThroughputMode != null)
            {
                request.ThroughputMode = cmdletContext.ThroughputMode;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        #region AWS Service Operation Call
        
        private Amazon.ElasticFileSystem.Model.CreateFileSystemResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.CreateFileSystemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "CreateFileSystem");
            try
            {
                #if DESKTOP
                return client.CreateFileSystem(request);
                #elif CORECLR
                return client.CreateFileSystemAsync(request).GetAwaiter().GetResult();
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
            public System.String CreationToken { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.ElasticFileSystem.PerformanceMode PerformanceMode { get; set; }
            public System.Double? ProvisionedThroughputInMibps { get; set; }
            public List<Amazon.ElasticFileSystem.Model.Tag> Tags { get; set; }
            public Amazon.ElasticFileSystem.ThroughputMode ThroughputMode { get; set; }
        }
        
    }
}

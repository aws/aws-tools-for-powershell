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
    /// see <a href="http://docs.aws.amazon.com/efs/latest/ug/performance.html#performancemodes.html">Amazon
    /// EFS: Performance Modes</a>.
    /// </para><para>
    /// After the file system is fully created, Amazon EFS sets its lifecycle state to <code>available</code>,
    /// at which point you can create one or more mount targets for the file system in your
    /// VPC. For more information, see <a>CreateMountTarget</a>. You mount your Amazon EFS
    /// file system on an EC2 instances in your VPC via the mount target. For more information,
    /// see <a href="http://docs.aws.amazon.com/efs/latest/ug/how-it-works.html">Amazon EFS:
    /// How it Works</a>. 
    /// </para><para>
    ///  This operation requires permissions for the <code>elasticfilesystem:CreateFileSystem</code>
    /// action. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "EFSFileSystem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.Model.CreateFileSystemResponse")]
    [AWSCmdlet("Invokes the CreateFileSystem operation against Amazon Elastic File System.", Operation = new[] {"CreateFileSystem"})]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.CreateFileSystemResponse",
        "This cmdlet returns a Amazon.ElasticFileSystem.Model.CreateFileSystemResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEFSFileSystemCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        #region Parameter CreationToken
        /// <summary>
        /// <para>
        /// <para>String of up to 64 ASCII characters. Amazon EFS uses this to ensure idempotent creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CreationToken { get; set; }
        #endregion
        
        #region Parameter PerformanceMode
        /// <summary>
        /// <para>
        /// <para>The <code>PerformanceMode</code> of the file system. We recommend <code>generalPurpose</code>
        /// performance mode for most file systems. File systems using the <code>maxIO</code>
        /// performance mode can scale to higher levels of aggregate throughput and operations
        /// per second with a tradeoff of slightly higher latencies for most file operations.
        /// This can't be changed after the file system has been created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ElasticFileSystem.PerformanceMode")]
        public Amazon.ElasticFileSystem.PerformanceMode PerformanceMode { get; set; }
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
            context.PerformanceMode = this.PerformanceMode;
            
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
            if (cmdletContext.PerformanceMode != null)
            {
                request.PerformanceMode = cmdletContext.PerformanceMode;
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
            #if DESKTOP
            return client.CreateFileSystem(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateFileSystemAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String CreationToken { get; set; }
            public Amazon.ElasticFileSystem.PerformanceMode PerformanceMode { get; set; }
        }
        
    }
}

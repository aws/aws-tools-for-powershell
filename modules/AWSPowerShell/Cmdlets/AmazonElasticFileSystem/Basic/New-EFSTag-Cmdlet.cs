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
    /// Creates or overwrites tags associated with a file system. Each tag is a key-value
    /// pair. If a tag key specified in the request already exists on the file system, this
    /// operation overwrites its value with the value provided in the request. If you add
    /// the <code>Name</code> tag to your file system, Amazon EFS returns it in the response
    /// to the <a>DescribeFileSystems</a> operation. 
    /// 
    ///  
    /// <para>
    /// This operation requires permission for the <code>elasticfilesystem:CreateTags</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EFSTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","Amazon.ElasticFileSystem.Model.Tag")]
    [AWSCmdlet("Invokes the CreateTags operation against Amazon Elastic File System.", Operation = new[] {"CreateTags"})]
    [AWSCmdletOutput("None or Amazon.ElasticFileSystem.Model.Tag",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Tag parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ElasticFileSystem.Model.CreateTagsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEFSTagCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>ID of the file system whose tags you want to modify (String). This operation modifies
        /// the tags only, not the file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Array of <code>Tag</code> objects to add. Each <code>Tag</code> object is a key-value
        /// pair. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("Tags")]
        public Amazon.ElasticFileSystem.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Tag parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FileSystemId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EFSTag (CreateTags)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.FileSystemId = this.FileSystemId;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.ElasticFileSystem.Model.Tag>(this.Tag);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticFileSystem.Model.CreateTagsRequest();
            
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
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
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.Tag;
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
        
        private static Amazon.ElasticFileSystem.Model.CreateTagsResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.CreateTagsRequest request)
        {
            return client.CreateTags(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String FileSystemId { get; set; }
            public List<Amazon.ElasticFileSystem.Model.Tag> Tags { get; set; }
        }
        
    }
}

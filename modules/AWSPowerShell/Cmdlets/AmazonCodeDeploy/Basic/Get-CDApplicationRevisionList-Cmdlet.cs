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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Lists information about revisions for an application.
    /// </summary>
    [Cmdlet("Get", "CDApplicationRevisionList")]
    [OutputType("Amazon.CodeDeploy.Model.RevisionLocation")]
    [AWSCmdlet("Invokes the ListApplicationRevisions operation against AWS CodeDeploy.", Operation = new[] {"ListApplicationRevisions"})]
    [AWSCmdletOutput("Amazon.CodeDeploy.Model.RevisionLocation",
        "This cmdlet returns a collection of RevisionLocation objects.",
        "The service call response (type ListApplicationRevisionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetCDApplicationRevisionListCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of an existing AWS CodeDeploy application associated with the applicable
        /// IAM user or AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String ApplicationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether to list revisions based on whether the revision is the target revision of
        /// an deployment group:</para><ul><li>include: List revisions that are target revisions of a deployment group.</li><li>exclude: Do not list revisions that are target revisions of a deployment group.</li><li>ignore: List all revisions, regardless of whether they are target revisions of
        /// a deployment group.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public ListStateFilterAction Deployed { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A specific Amazon S3 bucket name to limit the search for revisions.</para><para>If set to null, then all of the user's buckets will be searched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String S3Bucket { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A specific key prefix for the set of Amazon S3 objects to limit the search for revisions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String S3KeyPrefix { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The column name to sort the list results by:</para><ul><li>registerTime: Sort the list results by when the revisions were registered
        /// with AWS CodeDeploy.</li><li>firstUsedTime: Sort the list results by when the revisions
        /// were first used by in a deployment.</li><li>lastUsedTime: Sort the list results by
        /// when the revisions were last used in a deployment.</li></ul><para>If not specified or set to null, the results will be returned in an arbitrary order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public ApplicationRevisionSortBy SortBy { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The order to sort the list results by:</para><ul><li>ascending: Sort the list of results in ascending order.</li><li>descending:
        /// Sort the list of results in descending order.</li></ul><para>If not specified, the results will be sorted in ascending order.</para><para>If set to null, the results will be sorted in an arbitrary order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public SortOrder SortOrder { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An identifier that was returned from the previous list application revisions call,
        /// which can be used to return the next set of applications in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ApplicationName = this.ApplicationName;
            context.Deployed = this.Deployed;
            context.NextToken = this.NextToken;
            context.S3Bucket = this.S3Bucket;
            context.S3KeyPrefix = this.S3KeyPrefix;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ListApplicationRevisionsRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.Deployed != null)
            {
                request.Deployed = cmdletContext.Deployed;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.S3Bucket != null)
            {
                request.S3Bucket = cmdletContext.S3Bucket;
            }
            if (cmdletContext.S3KeyPrefix != null)
            {
                request.S3KeyPrefix = cmdletContext.S3KeyPrefix;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListApplicationRevisions(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Revisions;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String ApplicationName { get; set; }
            public ListStateFilterAction Deployed { get; set; }
            public String NextToken { get; set; }
            public String S3Bucket { get; set; }
            public String S3KeyPrefix { get; set; }
            public ApplicationRevisionSortBy SortBy { get; set; }
            public SortOrder SortOrder { get; set; }
        }
        
    }
}

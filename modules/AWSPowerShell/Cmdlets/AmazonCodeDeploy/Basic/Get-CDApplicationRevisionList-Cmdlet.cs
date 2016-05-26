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
        "The service call response (type Amazon.CodeDeploy.Model.ListApplicationRevisionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetCDApplicationRevisionListCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of an AWS CodeDeploy application associated with the applicable IAM user
        /// or AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter Deployed
        /// <summary>
        /// <para>
        /// <para>Whether to list revisions based on whether the revision is the target revision of
        /// an deployment group:</para><ul><li>include: List revisions that are target revisions of a deployment group.</li><li>exclude: Do not list revisions that are target revisions of a deployment group.</li><li>ignore: List all revisions.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeDeploy.ListStateFilterAction")]
        public Amazon.CodeDeploy.ListStateFilterAction Deployed { get; set; }
        #endregion
        
        #region Parameter S3Bucket
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 bucket name to limit the search for revisions.</para><para>If set to null, all of the user's buckets will be searched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3Bucket { get; set; }
        #endregion
        
        #region Parameter S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>A key prefix for the set of Amazon S3 objects to limit the search for revisions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The column name to use to sort the list results:</para><ul><li>registerTime: Sort by the time the revisions were registered with AWS CodeDeploy.</li><li>firstUsedTime: Sort by the time the revisions were first used in a deployment.</li><li>lastUsedTime: Sort by the time the revisions were last used in a deployment.</li></ul><para>If not specified or set to null, the results will be returned in an arbitrary order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeDeploy.ApplicationRevisionSortBy")]
        public Amazon.CodeDeploy.ApplicationRevisionSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The order in which to sort the list results:</para><ul><li>ascending: ascending order.</li><li>descending: descending order.</li></ul><para>If not specified, the results will be sorted in ascending order.</para><para>If set to null, the results will be sorted in an arbitrary order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeDeploy.SortOrder")]
        public Amazon.CodeDeploy.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An identifier returned from the previous list application revisions call. It can be
        /// used to return the next set of applications in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
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
            var request = new Amazon.CodeDeploy.Model.ListApplicationRevisionsRequest();
            
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private static Amazon.CodeDeploy.Model.ListApplicationRevisionsResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.ListApplicationRevisionsRequest request)
        {
            return client.ListApplicationRevisions(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ApplicationName { get; set; }
            public Amazon.CodeDeploy.ListStateFilterAction Deployed { get; set; }
            public System.String NextToken { get; set; }
            public System.String S3Bucket { get; set; }
            public System.String S3KeyPrefix { get; set; }
            public Amazon.CodeDeploy.ApplicationRevisionSortBy SortBy { get; set; }
            public Amazon.CodeDeploy.SortOrder SortOrder { get; set; }
        }
        
    }
}

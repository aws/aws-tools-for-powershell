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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes one or more of your bundling tasks.
    /// 
    ///  <note><para>
    /// Completed bundle tasks are listed for only a limited time. If your bundle task is
    /// no longer in the list, you can still register an AMI from it. Just use <code>RegisterImage</code>
    /// with the Amazon S3 bucket name and image manifest name you provided to the bundle
    /// task.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "EC2BundleTask")]
    [OutputType("Amazon.EC2.Model.BundleTask")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud DescribeBundleTasks API operation.", Operation = new[] {"DescribeBundleTasks"})]
    [AWSCmdletOutput("Amazon.EC2.Model.BundleTask",
        "This cmdlet returns a collection of BundleTask objects.",
        "The service call response (type Amazon.EC2.Model.DescribeBundleTasksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2BundleTaskCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter BundleId
        /// <summary>
        /// <para>
        /// <para>One or more bundle task IDs.</para><para>Default: Describes all your bundle tasks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("BundleIds")]
        public System.String[] BundleId { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>bundle-id</code> - The ID of the bundle task.</para></li><li><para><code>error-code</code> - If the task failed, the error code returned.</para></li><li><para><code>error-message</code> - If the task failed, the error message returned.</para></li><li><para><code>instance-id</code> - The ID of the instance.</para></li><li><para><code>progress</code> - The level of task completion, as a percentage (for example,
        /// 20%).</para></li><li><para><code>s3-bucket</code> - The Amazon S3 bucket to store the AMI.</para></li><li><para><code>s3-prefix</code> - The beginning of the AMI name.</para></li><li><para><code>start-time</code> - The time the task started (for example, 2013-09-15T17:15:20.000Z).</para></li><li><para><code>state</code> - The state of the task (<code>pending</code> | <code>waiting-for-shutdown</code>
        /// | <code>bundling</code> | <code>storing</code> | <code>cancelling</code> | <code>complete</code>
        /// | <code>failed</code>).</para></li><li><para><code>update-time</code> - The time of the most recent update for the task.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.BundleId != null)
            {
                context.BundleIds = new List<System.String>(this.BundleId);
            }
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
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
            var request = new Amazon.EC2.Model.DescribeBundleTasksRequest();
            
            if (cmdletContext.BundleIds != null)
            {
                request.BundleIds = cmdletContext.BundleIds;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.BundleTasks;
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
        
        private Amazon.EC2.Model.DescribeBundleTasksResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeBundleTasksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeBundleTasks");
            try
            {
                #if DESKTOP
                return client.DescribeBundleTasks(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeBundleTasksAsync(request);
                return task.Result;
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
            public List<System.String> BundleIds { get; set; }
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
        }
        
    }
}

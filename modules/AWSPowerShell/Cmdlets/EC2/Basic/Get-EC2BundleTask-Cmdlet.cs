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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the specified bundle tasks or all of your bundle tasks.
    /// 
    ///  <note><para>
    /// Completed bundle tasks are listed for only a limited time. If your bundle task is
    /// no longer in the list, you can still register an AMI from it. Just use <c>RegisterImage</c>
    /// with the Amazon S3 bucket name and image manifest name you provided to the bundle
    /// task.
    /// </para></note><note><para>
    /// The order of the elements in the response, including those within nested structures,
    /// might vary. Applications should not assume the elements appear in a particular order.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "EC2BundleTask")]
    [OutputType("Amazon.EC2.Model.BundleTask")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeBundleTasks API operation.", Operation = new[] {"DescribeBundleTasks"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeBundleTasksResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.BundleTask or Amazon.EC2.Model.DescribeBundleTasksResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.BundleTask objects.",
        "The service call response (type Amazon.EC2.Model.DescribeBundleTasksResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2BundleTaskCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BundleId
        /// <summary>
        /// <para>
        /// <para>The bundle task IDs.</para><para>Default: Describes all your bundle tasks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("BundleIds")]
        public System.String[] BundleId { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><c>bundle-id</c> - The ID of the bundle task.</para></li><li><para><c>error-code</c> - If the task failed, the error code returned.</para></li><li><para><c>error-message</c> - If the task failed, the error message returned.</para></li><li><para><c>instance-id</c> - The ID of the instance.</para></li><li><para><c>progress</c> - The level of task completion, as a percentage (for example, 20%).</para></li><li><para><c>s3-bucket</c> - The Amazon S3 bucket to store the AMI.</para></li><li><para><c>s3-prefix</c> - The beginning of the AMI name.</para></li><li><para><c>start-time</c> - The time the task started (for example, 2013-09-15T17:15:20.000Z).</para></li><li><para><c>state</c> - The state of the task (<c>pending</c> | <c>waiting-for-shutdown</c>
        /// | <c>bundling</c> | <c>storing</c> | <c>cancelling</c> | <c>complete</c> | <c>failed</c>).</para></li><li><para><c>update-time</c> - The time of the most recent update for the task.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BundleTasks'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeBundleTasksResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeBundleTasksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BundleTasks";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BundleId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BundleId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BundleId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeBundleTasksResponse, GetEC2BundleTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BundleId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.BundleId != null)
            {
                context.BundleId = new List<System.String>(this.BundleId);
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
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
            
            if (cmdletContext.BundleId != null)
            {
                request.BundleIds = cmdletContext.BundleId;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
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
        
        private Amazon.EC2.Model.DescribeBundleTasksResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeBundleTasksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeBundleTasks");
            try
            {
                #if DESKTOP
                return client.DescribeBundleTasks(request);
                #elif CORECLR
                return client.DescribeBundleTasksAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> BundleId { get; set; }
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeBundleTasksResponse, GetEC2BundleTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BundleTasks;
        }
        
    }
}

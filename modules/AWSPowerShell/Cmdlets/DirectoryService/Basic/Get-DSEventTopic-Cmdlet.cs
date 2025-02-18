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
using System.Threading;
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Obtains information about which Amazon SNS topics receive status messages from the
    /// specified directory.
    /// 
    ///  
    /// <para>
    /// If no input parameters are provided, such as DirectoryId or TopicName, this request
    /// describes all of the associations in the account.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DSEventTopic")]
    [OutputType("Amazon.DirectoryService.Model.EventTopic")]
    [AWSCmdlet("Calls the AWS Directory Service DescribeEventTopics API operation.", Operation = new[] {"DescribeEventTopics"}, SelectReturnType = typeof(Amazon.DirectoryService.Model.DescribeEventTopicsResponse))]
    [AWSCmdletOutput("Amazon.DirectoryService.Model.EventTopic or Amazon.DirectoryService.Model.DescribeEventTopicsResponse",
        "This cmdlet returns a collection of Amazon.DirectoryService.Model.EventTopic objects.",
        "The service call response (type Amazon.DirectoryService.Model.DescribeEventTopicsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDSEventTopicCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The Directory ID for which to get the list of associated Amazon SNS topics. If this
        /// member is null, associations for all Directory IDs are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter TopicName
        /// <summary>
        /// <para>
        /// <para>A list of Amazon SNS topic names for which to obtain the information. If this member
        /// is null, all associations for the specified Directory ID are returned.</para><para>An empty list results in an <c>InvalidParameterException</c> being thrown.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("TopicNames")]
        public System.String[] TopicName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventTopics'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryService.Model.DescribeEventTopicsResponse).
        /// Specifying the name of a property of type Amazon.DirectoryService.Model.DescribeEventTopicsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventTopics";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryService.Model.DescribeEventTopicsResponse, GetDSEventTopicCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DirectoryId = this.DirectoryId;
            if (this.TopicName != null)
            {
                context.TopicName = new List<System.String>(this.TopicName);
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
            var request = new Amazon.DirectoryService.Model.DescribeEventTopicsRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.TopicName != null)
            {
                request.TopicNames = cmdletContext.TopicName;
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
        
        private Amazon.DirectoryService.Model.DescribeEventTopicsResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.DescribeEventTopicsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "DescribeEventTopics");
            try
            {
                return client.DescribeEventTopicsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DirectoryId { get; set; }
            public List<System.String> TopicName { get; set; }
            public System.Func<Amazon.DirectoryService.Model.DescribeEventTopicsResponse, GetDSEventTopicCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventTopics;
        }
        
    }
}

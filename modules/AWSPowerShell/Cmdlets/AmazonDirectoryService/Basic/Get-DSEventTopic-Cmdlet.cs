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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Obtains information about which SNS topics receive status messages from the specified
    /// directory.
    /// 
    ///  
    /// <para>
    /// If no input parameters are provided, such as DirectoryId or TopicName, this request
    /// describes all of the associations in the account.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DSEventTopic")]
    [OutputType("Amazon.DirectoryService.Model.EventTopic")]
    [AWSCmdlet("Invokes the DescribeEventTopics operation against AWS Directory Service.", Operation = new[] {"DescribeEventTopics"})]
    [AWSCmdletOutput("Amazon.DirectoryService.Model.EventTopic",
        "This cmdlet returns a collection of EventTopic objects.",
        "The service call response (type Amazon.DirectoryService.Model.DescribeEventTopicsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDSEventTopicCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The Directory ID for which to get the list of associated SNS topics. If this member
        /// is null, associations for all Directory IDs are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter TopicName
        /// <summary>
        /// <para>
        /// <para>A list of SNS topic names for which to obtain the information. If this member is null,
        /// all associations for the specified Directory ID are returned.</para><para>An empty list results in an <code>InvalidParameterException</code> being thrown.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TopicNames")]
        public System.String[] TopicName { get; set; }
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
            
            context.DirectoryId = this.DirectoryId;
            if (this.TopicName != null)
            {
                context.TopicNames = new List<System.String>(this.TopicName);
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
            if (cmdletContext.TopicNames != null)
            {
                request.TopicNames = cmdletContext.TopicNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EventTopics;
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
        
        private Amazon.DirectoryService.Model.DescribeEventTopicsResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.DescribeEventTopicsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "DescribeEventTopics");
            try
            {
                #if DESKTOP
                return client.DescribeEventTopics(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeEventTopicsAsync(request);
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
            public System.String DirectoryId { get; set; }
            public List<System.String> TopicNames { get; set; }
        }
        
    }
}

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
    /// Describes the ID format settings for your resources on a per-region basis, for example,
    /// to view which resource types are enabled for longer IDs. This request only returns
    /// information about resource types whose ID formats can be modified; it does not return
    /// information about other resource types.
    /// 
    ///  
    /// <para>
    /// The following resource types support longer IDs: <code>instance</code> | <code>reservation</code>
    /// | <code>snapshot</code> | <code>volume</code>. 
    /// </para><para>
    /// These settings apply to the IAM user who makes the request; they do not apply to the
    /// entire AWS account. By default, an IAM user defaults to the same settings as the root
    /// user, unless they explicitly override the settings by running the <a>ModifyIdFormat</a>
    /// command. Resources created with longer IDs are visible to all IAM users, regardless
    /// of these settings and provided that they have permission to use the relevant <code>Describe</code>
    /// command for the resource type.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2IdFormat")]
    [OutputType("Amazon.EC2.Model.IdFormat")]
    [AWSCmdlet("Invokes the DescribeIdFormat operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeIdFormat"})]
    [AWSCmdletOutput("Amazon.EC2.Model.IdFormat",
        "This cmdlet returns a collection of IdFormat objects.",
        "The service call response (type Amazon.EC2.Model.DescribeIdFormatResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2IdFormatCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The type of resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Resource { get; set; }
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
            
            context.Resource = this.Resource;
            
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
            var request = new Amazon.EC2.Model.DescribeIdFormatRequest();
            
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Statuses;
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
        
        private static Amazon.EC2.Model.DescribeIdFormatResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeIdFormatRequest request)
        {
            #if DESKTOP
            return client.DescribeIdFormat(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeIdFormatAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Resource { get; set; }
        }
        
    }
}

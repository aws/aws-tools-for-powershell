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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Lists the tags for the specified Amazon Kinesis stream.
    /// </summary>
    [Cmdlet("Get", "KINTagsForStream")]
    [OutputType("Amazon.Kinesis.Model.ListTagsForStreamResponse")]
    [AWSCmdlet("Invokes the ListTagsForStream operation against Amazon Kinesis.", Operation = new[] {"ListTagsForStream"})]
    [AWSCmdletOutput("Amazon.Kinesis.Model.ListTagsForStreamResponse",
        "This cmdlet returns a Amazon.Kinesis.Model.ListTagsForStreamResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetKINTagsForStreamCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The key to use as the starting point for the list of tags. If this parameter is set,
        /// <code>ListTagsForStream</code> gets all tags that occur after <code>ExclusiveStartTagKey</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExclusiveStartTagKey { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of tags to return. If this number is less than the total number of tags
        /// associated with the stream, <code>HasMoreTags</code> is set to <code>true</code>.
        /// To list additional tags, set <code>ExclusiveStartTagKey</code> to the last key in
        /// the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 Limit { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ExclusiveStartTagKey = this.ExclusiveStartTagKey;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.StreamName = this.StreamName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Kinesis.Model.ListTagsForStreamRequest();
            
            if (cmdletContext.ExclusiveStartTagKey != null)
            {
                request.ExclusiveStartTagKey = cmdletContext.ExclusiveStartTagKey;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListTagsForStream(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ExclusiveStartTagKey { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}

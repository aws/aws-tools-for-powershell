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
    /// Lists your streams.
    /// 
    ///  
    /// <para>
    ///  The number of streams may be too large to return from a single call to <code>ListStreams</code>.
    /// You can limit the number of returned streams using the <code>Limit</code> parameter.
    /// If you do not specify a value for the <code>Limit</code> parameter, Amazon Kinesis
    /// uses the default limit, which is currently 10.
    /// </para><para>
    ///  You can detect if there are more streams available to list by using the <code>HasMoreStreams</code>
    /// flag from the returned output. If there are more streams available, you can request
    /// more streams by using the name of the last stream returned by the <code>ListStreams</code>
    /// request in the <code>ExclusiveStartStreamName</code> parameter in a subsequent request
    /// to <code>ListStreams</code>. The group of stream names returned by the subsequent
    /// request is then added to the list. You can continue this process until all the stream
    /// names have been collected in the list. 
    /// </para><para><a>ListStreams</a> has a limit of 5 transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINStreams")]
    [OutputType("Amazon.Kinesis.Model.ListStreamsResponse")]
    [AWSCmdlet("Invokes the ListStreams operation against AWS Kinesis.", Operation = new[] {"ListStreams"})]
    [AWSCmdletOutput("Amazon.Kinesis.Model.ListStreamsResponse",
        "This cmdlet returns a Amazon.Kinesis.Model.ListStreamsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetKINStreamsCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter ExclusiveStartStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream to start the list with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ExclusiveStartStreamName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of streams to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 Limit { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ExclusiveStartStreamName = this.ExclusiveStartStreamName;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Kinesis.Model.ListStreamsRequest();
            
            if (cmdletContext.ExclusiveStartStreamName != null)
            {
                request.ExclusiveStartStreamName = cmdletContext.ExclusiveStartStreamName;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListStreams(request);
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
            public System.String ExclusiveStartStreamName { get; set; }
            public System.Int32? Limit { get; set; }
        }
        
    }
}

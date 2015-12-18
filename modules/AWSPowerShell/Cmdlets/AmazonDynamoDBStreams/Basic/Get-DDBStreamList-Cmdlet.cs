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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Returns an array of stream ARNs associated with the current account and endpoint.
    /// If the <code>TableName</code> parameter is present, then <i>ListStreams</i> will return
    /// only the streams ARNs for that table.
    /// 
    ///  <note><para>
    /// You can call <i>ListStreams</i> at a maximum rate of 5 times per second.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "DDBStreamList")]
    [OutputType("Amazon.DynamoDBv2.Model.ListStreamsResponse")]
    [AWSCmdlet("Invokes the ListStreams operation against Amazon DynamoDB.", Operation = new[] {"ListStreams"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.ListStreamsResponse",
        "This cmdlet returns a Amazon.DynamoDBv2.Model.ListStreamsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetDDBStreamListCmdlet : AmazonDynamoDBStreamsClientCmdlet, IExecutor
    {
        
        #region Parameter ExclusiveStartStreamArn
        /// <summary>
        /// <para>
        /// <para>The ARN (Amazon Resource Name) of the first item that this operation will evaluate.
        /// Use the value that was returned for <code>LastEvaluatedStreamArn</code> in the previous
        /// operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExclusiveStartStreamArn { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>If this parameter is provided, then only the streams associated with this table name
        /// are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of streams to return. The upper limit is 100.</para>
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
            
            context.ExclusiveStartStreamArn = this.ExclusiveStartStreamArn;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.TableName = this.TableName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DynamoDBv2.Model.ListStreamsRequest();
            
            if (cmdletContext.ExclusiveStartStreamArn != null)
            {
                request.ExclusiveStartStreamArn = cmdletContext.ExclusiveStartStreamArn;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
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
            public System.String ExclusiveStartStreamArn { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String TableName { get; set; }
        }
        
    }
}

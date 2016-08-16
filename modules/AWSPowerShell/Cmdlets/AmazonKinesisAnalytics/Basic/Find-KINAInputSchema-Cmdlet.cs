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
using Amazon.KinesisAnalytics;
using Amazon.KinesisAnalytics.Model;

namespace Amazon.PowerShell.Cmdlets.KINA
{
    /// <summary>
    /// Infers a schema by evaluating sample records on the specified streaming source (Amazon
    /// Kinesis stream or Amazon Kinesis Firehose delivery stream). In the response, the operation
    /// returns the inferred schema and also the sample records that the operation used to
    /// infer the schema.
    /// 
    ///  
    /// <para>
    ///  You can use the inferred schema when configuring a streaming source for your application.
    /// For conceptual information, see <a href="http://docs.aws.amazon.com/kinesisanalytics/latest/dev/how-it-works-input.html">Configuring
    /// Application Input</a>. Note that when you create an application using the Amazon Kinesis
    /// Analytics console, the console uses this operation to infer a schema and show it in
    /// the console user interface. 
    /// </para><para>
    ///  This operation requires permissions to perform the <code>kinesisanalytics:DiscoverInputSchema</code>
    /// action. 
    /// </para>
    /// </summary>
    [Cmdlet("Find", "KINAInputSchema")]
    [OutputType("Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse")]
    [AWSCmdlet("Invokes the DiscoverInputSchema operation against Amazon Kinesis Analytics.", Operation = new[] {"DiscoverInputSchema"})]
    [AWSCmdletOutput("Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse",
        "This cmdlet returns a Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class FindKINAInputSchemaCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        #region Parameter InputStartingPositionConfiguration_InputStartingPosition
        /// <summary>
        /// <para>
        /// <para>The starting position on the stream.</para><ul><li><para><code>LATEST</code> - Start reading just after the most recent record in the stream.</para></li><li><para><code>TRIM_HORIZON</code> - Start reading at the last untrimmed record in the stream,
        /// which is the oldest record available in the stream. This option is not available for
        /// an Amazon Kinesis Firehose delivery stream.</para></li><li><para><code>LAST_STOPPED_POINT</code> - Resume reading from where the application last
        /// stopped reading.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KinesisAnalytics.InputStartingPosition")]
        public Amazon.KinesisAnalytics.InputStartingPosition InputStartingPositionConfiguration_InputStartingPosition { get; set; }
        #endregion
        
        #region Parameter ResourceARN
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the streaming source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceARN { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role that Amazon Kinesis Analytics can assume to access the stream
        /// on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleARN { get; set; }
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
            
            context.InputStartingPositionConfiguration_InputStartingPosition = this.InputStartingPositionConfiguration_InputStartingPosition;
            context.ResourceARN = this.ResourceARN;
            context.RoleARN = this.RoleARN;
            
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
            var request = new Amazon.KinesisAnalytics.Model.DiscoverInputSchemaRequest();
            
            
             // populate InputStartingPositionConfiguration
            bool requestInputStartingPositionConfigurationIsNull = true;
            request.InputStartingPositionConfiguration = new Amazon.KinesisAnalytics.Model.InputStartingPositionConfiguration();
            Amazon.KinesisAnalytics.InputStartingPosition requestInputStartingPositionConfiguration_inputStartingPositionConfiguration_InputStartingPosition = null;
            if (cmdletContext.InputStartingPositionConfiguration_InputStartingPosition != null)
            {
                requestInputStartingPositionConfiguration_inputStartingPositionConfiguration_InputStartingPosition = cmdletContext.InputStartingPositionConfiguration_InputStartingPosition;
            }
            if (requestInputStartingPositionConfiguration_inputStartingPositionConfiguration_InputStartingPosition != null)
            {
                request.InputStartingPositionConfiguration.InputStartingPosition = requestInputStartingPositionConfiguration_inputStartingPositionConfiguration_InputStartingPosition;
                requestInputStartingPositionConfigurationIsNull = false;
            }
             // determine if request.InputStartingPositionConfiguration should be set to null
            if (requestInputStartingPositionConfigurationIsNull)
            {
                request.InputStartingPositionConfiguration = null;
            }
            if (cmdletContext.ResourceARN != null)
            {
                request.ResourceARN = cmdletContext.ResourceARN;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private static Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.DiscoverInputSchemaRequest request)
        {
            #if DESKTOP
            return client.DiscoverInputSchema(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DiscoverInputSchemaAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Amazon.KinesisAnalytics.InputStartingPosition InputStartingPositionConfiguration_InputStartingPosition { get; set; }
            public System.String ResourceARN { get; set; }
            public System.String RoleARN { get; set; }
        }
        
    }
}

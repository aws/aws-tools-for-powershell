/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.KinesisAnalyticsV2;
using Amazon.KinesisAnalyticsV2.Model;

namespace Amazon.PowerShell.Cmdlets.KINA2
{
    /// <summary>
    /// Infers a schema for an SQL-based Amazon Kinesis Data Analytics application by evaluating
    /// sample records on the specified streaming source (Kinesis data stream or Kinesis Data
    /// Firehose delivery stream) or Amazon S3 object. In the response, the operation returns
    /// the inferred schema and also the sample records that the operation used to infer the
    /// schema.
    /// 
    ///  
    /// <para>
    ///  You can use the inferred schema when configuring a streaming source for your application.
    /// When you create an application using the Kinesis Data Analytics console, the console
    /// uses this operation to infer a schema and show it in the console user interface. 
    /// </para>
    /// </summary>
    [Cmdlet("Find", "KINA2InputSchema")]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.DiscoverInputSchemaResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics (v2) DiscoverInputSchema API operation.", Operation = new[] {"DiscoverInputSchema"})]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.DiscoverInputSchemaResponse",
        "This cmdlet returns a Amazon.KinesisAnalyticsV2.Model.DiscoverInputSchemaResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class FindKINA2InputSchemaCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        #region Parameter InputStartingPositionConfiguration
        /// <summary>
        /// <para>
        /// <para>The point at which you want Kinesis Data Analytics to start reading records from the
        /// specified streaming source discovery purposes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KinesisAnalyticsV2.Model.InputStartingPositionConfiguration InputStartingPositionConfiguration { get; set; }
        #endregion
        
        #region Parameter InputLambdaProcessor_ResourceARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Lambda function that operates on records in the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InputProcessingConfiguration_InputLambdaProcessor_ResourceARN")]
        public System.String InputLambdaProcessor_ResourceARN { get; set; }
        #endregion
        
        #region Parameter ResourceARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the streaming source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ResourceARN { get; set; }
        #endregion
        
        #region Parameter S3Configuration
        /// <summary>
        /// <para>
        /// <para>Specify this parameter to discover a schema from data in an Amazon S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KinesisAnalyticsV2.Model.S3Configuration S3Configuration { get; set; }
        #endregion
        
        #region Parameter ServiceExecutionRole
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that is used to access the streaming source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceExecutionRole { get; set; }
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
            
            context.InputProcessingConfiguration_InputLambdaProcessor_ResourceARN = this.InputLambdaProcessor_ResourceARN;
            context.InputStartingPositionConfiguration = this.InputStartingPositionConfiguration;
            context.ResourceARN = this.ResourceARN;
            context.S3Configuration = this.S3Configuration;
            context.ServiceExecutionRole = this.ServiceExecutionRole;
            
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
            var request = new Amazon.KinesisAnalyticsV2.Model.DiscoverInputSchemaRequest();
            
            
             // populate InputProcessingConfiguration
            bool requestInputProcessingConfigurationIsNull = true;
            request.InputProcessingConfiguration = new Amazon.KinesisAnalyticsV2.Model.InputProcessingConfiguration();
            Amazon.KinesisAnalyticsV2.Model.InputLambdaProcessor requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor = null;
            
             // populate InputLambdaProcessor
            bool requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessorIsNull = true;
            requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor = new Amazon.KinesisAnalyticsV2.Model.InputLambdaProcessor();
            System.String requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN = null;
            if (cmdletContext.InputProcessingConfiguration_InputLambdaProcessor_ResourceARN != null)
            {
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN = cmdletContext.InputProcessingConfiguration_InputLambdaProcessor_ResourceARN;
            }
            if (requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN != null)
            {
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor.ResourceARN = requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN;
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessorIsNull = false;
            }
             // determine if requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor should be set to null
            if (requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessorIsNull)
            {
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor = null;
            }
            if (requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor != null)
            {
                request.InputProcessingConfiguration.InputLambdaProcessor = requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor;
                requestInputProcessingConfigurationIsNull = false;
            }
             // determine if request.InputProcessingConfiguration should be set to null
            if (requestInputProcessingConfigurationIsNull)
            {
                request.InputProcessingConfiguration = null;
            }
            if (cmdletContext.InputStartingPositionConfiguration != null)
            {
                request.InputStartingPositionConfiguration = cmdletContext.InputStartingPositionConfiguration;
            }
            if (cmdletContext.ResourceARN != null)
            {
                request.ResourceARN = cmdletContext.ResourceARN;
            }
            if (cmdletContext.S3Configuration != null)
            {
                request.S3Configuration = cmdletContext.S3Configuration;
            }
            if (cmdletContext.ServiceExecutionRole != null)
            {
                request.ServiceExecutionRole = cmdletContext.ServiceExecutionRole;
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
        
        private Amazon.KinesisAnalyticsV2.Model.DiscoverInputSchemaResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.DiscoverInputSchemaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics (v2)", "DiscoverInputSchema");
            try
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
            public System.String InputProcessingConfiguration_InputLambdaProcessor_ResourceARN { get; set; }
            public Amazon.KinesisAnalyticsV2.Model.InputStartingPositionConfiguration InputStartingPositionConfiguration { get; set; }
            public System.String ResourceARN { get; set; }
            public Amazon.KinesisAnalyticsV2.Model.S3Configuration S3Configuration { get; set; }
            public System.String ServiceExecutionRole { get; set; }
        }
        
    }
}

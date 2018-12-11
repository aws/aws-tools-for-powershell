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
    /// Adds an <a>InputProcessingConfiguration</a> to an SQL-based Kinesis Data Analytics
    /// application. An input processor pre-processes records on the input stream before the
    /// application's SQL code executes. Currently, the only input processor available is
    /// <a href="https://aws.amazon.com/documentation/lambda/">AWS Lambda</a>.
    /// </summary>
    [Cmdlet("Add", "KINA2ApplicationInputProcessingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics (v2) AddApplicationInputProcessingConfiguration API operation.", Operation = new[] {"AddApplicationInputProcessingConfiguration"})]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse",
        "This cmdlet returns a Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddKINA2ApplicationInputProcessingConfigurationCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application to which you want to add the input processing configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>The version of the application to which you want to add the input processing configuration.
        /// You can use the <a>DescribeApplication</a> operation to get the current application
        /// version. If the version specified is not the current version, the <code>ConcurrentModificationException</code>
        /// is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64 CurrentApplicationVersionId { get; set; }
        #endregion
        
        #region Parameter InputId
        /// <summary>
        /// <para>
        /// <para>The ID of the input configuration to add the input processing configuration to. You
        /// can get a list of the input IDs for an application using the <a>DescribeApplication</a>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InputId { get; set; }
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
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InputId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-KINA2ApplicationInputProcessingConfiguration (AddApplicationInputProcessingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ApplicationName = this.ApplicationName;
            if (ParameterWasBound("CurrentApplicationVersionId"))
                context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            context.InputId = this.InputId;
            context.InputProcessingConfiguration_InputLambdaProcessor_ResourceARN = this.InputLambdaProcessor_ResourceARN;
            
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
            var request = new Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CurrentApplicationVersionId != null)
            {
                request.CurrentApplicationVersionId = cmdletContext.CurrentApplicationVersionId.Value;
            }
            if (cmdletContext.InputId != null)
            {
                request.InputId = cmdletContext.InputId;
            }
            
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
        
        private Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.AddApplicationInputProcessingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics (v2)", "AddApplicationInputProcessingConfiguration");
            try
            {
                #if DESKTOP
                return client.AddApplicationInputProcessingConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AddApplicationInputProcessingConfigurationAsync(request);
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
            public System.String ApplicationName { get; set; }
            public System.Int64? CurrentApplicationVersionId { get; set; }
            public System.String InputId { get; set; }
            public System.String InputProcessingConfiguration_InputLambdaProcessor_ResourceARN { get; set; }
        }
        
    }
}

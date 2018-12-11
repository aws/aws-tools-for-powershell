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
    /// Deletes an Amazon CloudWatch log stream from an Amazon Kinesis Data Analytics application.
    /// </summary>
    [Cmdlet("Remove", "KINA2ApplicationCloudWatchLoggingOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.DeleteApplicationCloudWatchLoggingOptionResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics (v2) DeleteApplicationCloudWatchLoggingOption API operation.", Operation = new[] {"DeleteApplicationCloudWatchLoggingOption"})]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.DeleteApplicationCloudWatchLoggingOptionResponse",
        "This cmdlet returns a Amazon.KinesisAnalyticsV2.Model.DeleteApplicationCloudWatchLoggingOptionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveKINA2ApplicationCloudWatchLoggingOptionCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The application name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptionId
        /// <summary>
        /// <para>
        /// <para>The <code>CloudWatchLoggingOptionId</code> of the Amazon CloudWatch logging option
        /// to delete. You can get the <code>CloudWatchLoggingOptionId</code> by using the <a>DescribeApplication</a>
        /// operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CloudWatchLoggingOptionId { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>The version ID of the application. You can retrieve the application version ID using
        /// <a>DescribeApplication</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64 CurrentApplicationVersionId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CloudWatchLoggingOptionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-KINA2ApplicationCloudWatchLoggingOption (DeleteApplicationCloudWatchLoggingOption)"))
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
            context.CloudWatchLoggingOptionId = this.CloudWatchLoggingOptionId;
            if (ParameterWasBound("CurrentApplicationVersionId"))
                context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            
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
            var request = new Amazon.KinesisAnalyticsV2.Model.DeleteApplicationCloudWatchLoggingOptionRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CloudWatchLoggingOptionId != null)
            {
                request.CloudWatchLoggingOptionId = cmdletContext.CloudWatchLoggingOptionId;
            }
            if (cmdletContext.CurrentApplicationVersionId != null)
            {
                request.CurrentApplicationVersionId = cmdletContext.CurrentApplicationVersionId.Value;
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
        
        private Amazon.KinesisAnalyticsV2.Model.DeleteApplicationCloudWatchLoggingOptionResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.DeleteApplicationCloudWatchLoggingOptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics (v2)", "DeleteApplicationCloudWatchLoggingOption");
            try
            {
                #if DESKTOP
                return client.DeleteApplicationCloudWatchLoggingOption(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteApplicationCloudWatchLoggingOptionAsync(request);
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
            public System.String CloudWatchLoggingOptionId { get; set; }
            public System.Int64? CurrentApplicationVersionId { get; set; }
        }
        
    }
}

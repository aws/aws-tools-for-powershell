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
    /// Creates an Amazon Kinesis Data Analytics application. For information about creating
    /// a Kinesis Data Analytics application, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/Java/creating-app.html">Creating
    /// an Application</a>. 
    /// 
    ///  <note><para>
    /// SQL is not enabled for this private beta release. Using SQL parameters (such as <a>SqlApplicationConfiguration</a>)
    /// will result in an error.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "KINA2Application", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.ApplicationDetail")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics (v2) CreateApplication API operation.", Operation = new[] {"CreateApplication"})]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.ApplicationDetail",
        "This cmdlet returns a ApplicationDetail object.",
        "The service call response (type Amazon.KinesisAnalyticsV2.Model.CreateApplicationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKINA2ApplicationCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationConfiguration
        /// <summary>
        /// <para>
        /// <para>Use this parameter to configure the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KinesisAnalyticsV2.Model.ApplicationConfiguration ApplicationConfiguration { get; set; }
        #endregion
        
        #region Parameter ApplicationDescription
        /// <summary>
        /// <para>
        /// <para>A summary description of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ApplicationDescription { get; set; }
        #endregion
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of your application (for example, <code>sample-app</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOption
        /// <summary>
        /// <para>
        /// <para>Use this parameter to configure an Amazon CloudWatch log stream to monitor application
        /// configuration errors. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CloudWatchLoggingOptions")]
        public Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOption[] CloudWatchLoggingOption { get; set; }
        #endregion
        
        #region Parameter RuntimeEnvironment
        /// <summary>
        /// <para>
        /// <para>The runtime environment for the application (<code>SQL-1.0</code> or <code>JAVA-8-FLINK-1.5</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KinesisAnalyticsV2.RuntimeEnvironment")]
        public Amazon.KinesisAnalyticsV2.RuntimeEnvironment RuntimeEnvironment { get; set; }
        #endregion
        
        #region Parameter ServiceExecutionRole
        /// <summary>
        /// <para>
        /// <para>The IAM role used by the application to access Kinesis data streams, Kinesis Data
        /// Firehose delivery streams, Amazon S3 objects, and other external resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceExecutionRole { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KINA2Application (CreateApplication)"))
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
            
            context.ApplicationConfiguration = this.ApplicationConfiguration;
            context.ApplicationDescription = this.ApplicationDescription;
            context.ApplicationName = this.ApplicationName;
            if (this.CloudWatchLoggingOption != null)
            {
                context.CloudWatchLoggingOptions = new List<Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOption>(this.CloudWatchLoggingOption);
            }
            context.RuntimeEnvironment = this.RuntimeEnvironment;
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
            var request = new Amazon.KinesisAnalyticsV2.Model.CreateApplicationRequest();
            
            if (cmdletContext.ApplicationConfiguration != null)
            {
                request.ApplicationConfiguration = cmdletContext.ApplicationConfiguration;
            }
            if (cmdletContext.ApplicationDescription != null)
            {
                request.ApplicationDescription = cmdletContext.ApplicationDescription;
            }
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CloudWatchLoggingOptions != null)
            {
                request.CloudWatchLoggingOptions = cmdletContext.CloudWatchLoggingOptions;
            }
            if (cmdletContext.RuntimeEnvironment != null)
            {
                request.RuntimeEnvironment = cmdletContext.RuntimeEnvironment;
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
                object pipelineOutput = response.ApplicationDetail;
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
        
        private Amazon.KinesisAnalyticsV2.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics (v2)", "CreateApplication");
            try
            {
                #if DESKTOP
                return client.CreateApplication(request);
                #elif CORECLR
                return client.CreateApplicationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.KinesisAnalyticsV2.Model.ApplicationConfiguration ApplicationConfiguration { get; set; }
            public System.String ApplicationDescription { get; set; }
            public System.String ApplicationName { get; set; }
            public List<Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOption> CloudWatchLoggingOptions { get; set; }
            public Amazon.KinesisAnalyticsV2.RuntimeEnvironment RuntimeEnvironment { get; set; }
            public System.String ServiceExecutionRole { get; set; }
        }
        
    }
}

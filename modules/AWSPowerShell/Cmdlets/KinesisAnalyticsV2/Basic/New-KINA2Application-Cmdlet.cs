/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a Kinesis Data Analytics application. For information about creating a Kinesis
    /// Data Analytics application, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/java/getting-started.html">Creating
    /// an Application</a>.
    /// </summary>
    [Cmdlet("New", "KINA2Application", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.ApplicationDetail")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics V2 CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.KinesisAnalyticsV2.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.ApplicationDetail or Amazon.KinesisAnalyticsV2.Model.CreateApplicationResponse",
        "This cmdlet returns an Amazon.KinesisAnalyticsV2.Model.ApplicationDetail object.",
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisAnalyticsV2.Model.ApplicationConfiguration ApplicationConfiguration { get; set; }
        #endregion
        
        #region Parameter ApplicationDescription
        /// <summary>
        /// <para>
        /// <para>A summary description of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationDescription { get; set; }
        #endregion
        
        #region Parameter ApplicationMode
        /// <summary>
        /// <para>
        /// <para>Use the <code>STREAMING</code> mode to create a Kinesis Data Analytics Studio notebook.
        /// To create a Kinesis Data Analytics Studio notebook, use the <code>INTERACTIVE</code>
        /// mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisAnalyticsV2.ApplicationMode")]
        public Amazon.KinesisAnalyticsV2.ApplicationMode ApplicationMode { get; set; }
        #endregion
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of your application (for example, <code>sample-app</code>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOption
        /// <summary>
        /// <para>
        /// <para>Use this parameter to configure an Amazon CloudWatch log stream to monitor application
        /// configuration errors. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudWatchLoggingOptions")]
        public Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOption[] CloudWatchLoggingOption { get; set; }
        #endregion
        
        #region Parameter RuntimeEnvironment
        /// <summary>
        /// <para>
        /// <para>The runtime environment for the application (<code>SQL-1_0</code>, <code>FLINK-1_6</code>,
        /// <code>FLINK-1_8</code>, or <code>FLINK-1_11</code>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ServiceExecutionRole { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of one or more tags to assign to the application. A tag is a key-value pair
        /// that identifies an application. Note that the maximum number of application tags includes
        /// system tags. The maximum number of user-defined application tags is 50. For more information,
        /// see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/java/how-tagging.html">Using
        /// Tagging</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.KinesisAnalyticsV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalyticsV2.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalyticsV2.Model.CreateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationDetail";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KINA2Application (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalyticsV2.Model.CreateApplicationResponse, NewKINA2ApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationConfiguration = this.ApplicationConfiguration;
            context.ApplicationDescription = this.ApplicationDescription;
            context.ApplicationMode = this.ApplicationMode;
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CloudWatchLoggingOption != null)
            {
                context.CloudWatchLoggingOption = new List<Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOption>(this.CloudWatchLoggingOption);
            }
            context.RuntimeEnvironment = this.RuntimeEnvironment;
            #if MODULAR
            if (this.RuntimeEnvironment == null && ParameterWasBound(nameof(this.RuntimeEnvironment)))
            {
                WriteWarning("You are passing $null as a value for parameter RuntimeEnvironment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceExecutionRole = this.ServiceExecutionRole;
            #if MODULAR
            if (this.ServiceExecutionRole == null && ParameterWasBound(nameof(this.ServiceExecutionRole)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceExecutionRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.KinesisAnalyticsV2.Model.Tag>(this.Tag);
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
            var request = new Amazon.KinesisAnalyticsV2.Model.CreateApplicationRequest();
            
            if (cmdletContext.ApplicationConfiguration != null)
            {
                request.ApplicationConfiguration = cmdletContext.ApplicationConfiguration;
            }
            if (cmdletContext.ApplicationDescription != null)
            {
                request.ApplicationDescription = cmdletContext.ApplicationDescription;
            }
            if (cmdletContext.ApplicationMode != null)
            {
                request.ApplicationMode = cmdletContext.ApplicationMode;
            }
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CloudWatchLoggingOption != null)
            {
                request.CloudWatchLoggingOptions = cmdletContext.CloudWatchLoggingOption;
            }
            if (cmdletContext.RuntimeEnvironment != null)
            {
                request.RuntimeEnvironment = cmdletContext.RuntimeEnvironment;
            }
            if (cmdletContext.ServiceExecutionRole != null)
            {
                request.ServiceExecutionRole = cmdletContext.ServiceExecutionRole;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics V2", "CreateApplication");
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
            public Amazon.KinesisAnalyticsV2.ApplicationMode ApplicationMode { get; set; }
            public System.String ApplicationName { get; set; }
            public List<Amazon.KinesisAnalyticsV2.Model.CloudWatchLoggingOption> CloudWatchLoggingOption { get; set; }
            public Amazon.KinesisAnalyticsV2.RuntimeEnvironment RuntimeEnvironment { get; set; }
            public System.String ServiceExecutionRole { get; set; }
            public List<Amazon.KinesisAnalyticsV2.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.KinesisAnalyticsV2.Model.CreateApplicationResponse, NewKINA2ApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationDetail;
        }
        
    }
}

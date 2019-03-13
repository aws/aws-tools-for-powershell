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
using Amazon.WAFRegional;
using Amazon.WAFRegional.Model;

namespace Amazon.PowerShell.Cmdlets.WAFR
{
    /// <summary>
    /// Associates a <a>LoggingConfiguration</a> with a specified web ACL.
    /// 
    ///  
    /// <para>
    /// You can access information about all traffic that AWS WAF inspects using the following
    /// steps:
    /// </para><ol><li><para>
    /// Create an Amazon Kinesis Data Firehose . 
    /// </para><para>
    /// Create the data firehose with a PUT source and in the region that you are operating.
    /// However, if you are capturing logs for Amazon CloudFront, always create the firehose
    /// in US East (N. Virginia). 
    /// </para></li><li><para>
    /// Associate that firehose to your web ACL using a <code>PutLoggingConfiguration</code>
    /// request.
    /// </para></li></ol><para>
    /// When you successfully enable logging using a <code>PutLoggingConfiguration</code>
    /// request, AWS WAF will create a service linked role with the necessary permissions
    /// to write logs to the Amazon Kinesis Data Firehose. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/logging.html">Logging
    /// Web ACL Traffic Information</a> in the <i>AWS WAF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "WAFRLoggingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WAFRegional.Model.LoggingConfiguration")]
    [AWSCmdlet("Calls the AWS WAF Regional PutLoggingConfiguration API operation.", Operation = new[] {"PutLoggingConfiguration"})]
    [AWSCmdletOutput("Amazon.WAFRegional.Model.LoggingConfiguration",
        "This cmdlet returns a LoggingConfiguration object.",
        "The service call response (type Amazon.WAFRegional.Model.PutLoggingConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteWAFRLoggingConfigurationCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
        #region Parameter LoggingConfiguration_LogDestinationConfig
        /// <summary>
        /// <para>
        /// <para>An array of Amazon Kinesis Data Firehose ARNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LoggingConfiguration_LogDestinationConfigs")]
        public System.String[] LoggingConfiguration_LogDestinationConfig { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_RedactedField
        /// <summary>
        /// <para>
        /// <para>The parts of the request that you want redacted from the logs. For example, if you
        /// redact the cookie field, the cookie field in the firehose will be <code>xxx</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LoggingConfiguration_RedactedFields")]
        public Amazon.WAFRegional.Model.FieldToMatch[] LoggingConfiguration_RedactedField { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the web ACL that you want to associate with <code>LogDestinationConfigs</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String LoggingConfiguration_ResourceArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LoggingConfiguration_ResourceArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-WAFRLoggingConfiguration (PutLoggingConfiguration)"))
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
            
            if (this.LoggingConfiguration_LogDestinationConfig != null)
            {
                context.LoggingConfiguration_LogDestinationConfigs = new List<System.String>(this.LoggingConfiguration_LogDestinationConfig);
            }
            if (this.LoggingConfiguration_RedactedField != null)
            {
                context.LoggingConfiguration_RedactedFields = new List<Amazon.WAFRegional.Model.FieldToMatch>(this.LoggingConfiguration_RedactedField);
            }
            context.LoggingConfiguration_ResourceArn = this.LoggingConfiguration_ResourceArn;
            
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
            var request = new Amazon.WAFRegional.Model.PutLoggingConfigurationRequest();
            
            
             // populate LoggingConfiguration
            bool requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.WAFRegional.Model.LoggingConfiguration();
            List<System.String> requestLoggingConfiguration_loggingConfiguration_LogDestinationConfig = null;
            if (cmdletContext.LoggingConfiguration_LogDestinationConfigs != null)
            {
                requestLoggingConfiguration_loggingConfiguration_LogDestinationConfig = cmdletContext.LoggingConfiguration_LogDestinationConfigs;
            }
            if (requestLoggingConfiguration_loggingConfiguration_LogDestinationConfig != null)
            {
                request.LoggingConfiguration.LogDestinationConfigs = requestLoggingConfiguration_loggingConfiguration_LogDestinationConfig;
                requestLoggingConfigurationIsNull = false;
            }
            List<Amazon.WAFRegional.Model.FieldToMatch> requestLoggingConfiguration_loggingConfiguration_RedactedField = null;
            if (cmdletContext.LoggingConfiguration_RedactedFields != null)
            {
                requestLoggingConfiguration_loggingConfiguration_RedactedField = cmdletContext.LoggingConfiguration_RedactedFields;
            }
            if (requestLoggingConfiguration_loggingConfiguration_RedactedField != null)
            {
                request.LoggingConfiguration.RedactedFields = requestLoggingConfiguration_loggingConfiguration_RedactedField;
                requestLoggingConfigurationIsNull = false;
            }
            System.String requestLoggingConfiguration_loggingConfiguration_ResourceArn = null;
            if (cmdletContext.LoggingConfiguration_ResourceArn != null)
            {
                requestLoggingConfiguration_loggingConfiguration_ResourceArn = cmdletContext.LoggingConfiguration_ResourceArn;
            }
            if (requestLoggingConfiguration_loggingConfiguration_ResourceArn != null)
            {
                request.LoggingConfiguration.ResourceArn = requestLoggingConfiguration_loggingConfiguration_ResourceArn;
                requestLoggingConfigurationIsNull = false;
            }
             // determine if request.LoggingConfiguration should be set to null
            if (requestLoggingConfigurationIsNull)
            {
                request.LoggingConfiguration = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.LoggingConfiguration;
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
        
        private Amazon.WAFRegional.Model.PutLoggingConfigurationResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.PutLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "PutLoggingConfiguration");
            try
            {
                #if DESKTOP
                return client.PutLoggingConfiguration(request);
                #elif CORECLR
                return client.PutLoggingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> LoggingConfiguration_LogDestinationConfigs { get; set; }
            public List<Amazon.WAFRegional.Model.FieldToMatch> LoggingConfiguration_RedactedFields { get; set; }
            public System.String LoggingConfiguration_ResourceArn { get; set; }
        }
        
    }
}

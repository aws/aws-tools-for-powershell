/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.WAF;
using Amazon.WAF.Model;

namespace Amazon.PowerShell.Cmdlets.WAF
{
    /// <summary>
    /// <note><para>
    /// This is <b>AWS WAF Classic</b> documentation. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/classic-waf-chapter.html">AWS
    /// WAF Classic</a> in the developer guide.
    /// </para><para><b>For the latest version of AWS WAF</b>, use the AWS WAFV2 API and see the <a href="https://docs.aws.amazon.com/waf/latest/developerguide/waf-chapter.html">AWS
    /// WAF Developer Guide</a>. With the latest version, AWS WAF has a single set of endpoints
    /// for regional and global use. 
    /// </para></note><para>
    /// Associates a <a>LoggingConfiguration</a> with a specified web ACL.
    /// </para><para>
    /// You can access information about all traffic that AWS WAF inspects using the following
    /// steps:
    /// </para><ol><li><para>
    /// Create an Amazon Kinesis Data Firehose. 
    /// </para><para>
    /// Create the data firehose with a PUT source and in the region that you are operating.
    /// However, if you are capturing logs for Amazon CloudFront, always create the firehose
    /// in US East (N. Virginia). 
    /// </para><note><para>
    /// Do not create the data firehose using a <c>Kinesis stream</c> as your source.
    /// </para></note></li><li><para>
    /// Associate that firehose to your web ACL using a <c>PutLoggingConfiguration</c> request.
    /// </para></li></ol><para>
    /// When you successfully enable logging using a <c>PutLoggingConfiguration</c> request,
    /// AWS WAF will create a service linked role with the necessary permissions to write
    /// logs to the Amazon Kinesis Data Firehose. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/logging.html">Logging
    /// Web ACL Traffic Information</a> in the <i>AWS WAF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "WAFLoggingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WAF.Model.LoggingConfiguration")]
    [AWSCmdlet("Calls the AWS WAF PutLoggingConfiguration API operation.", Operation = new[] {"PutLoggingConfiguration"}, SelectReturnType = typeof(Amazon.WAF.Model.PutLoggingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.WAF.Model.LoggingConfiguration or Amazon.WAF.Model.PutLoggingConfigurationResponse",
        "This cmdlet returns an Amazon.WAF.Model.LoggingConfiguration object.",
        "The service call response (type Amazon.WAF.Model.PutLoggingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteWAFLoggingConfigurationCmdlet : AmazonWAFClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LoggingConfiguration_LogDestinationConfig
        /// <summary>
        /// <para>
        /// <para>An array of Amazon Kinesis Data Firehose ARNs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("LoggingConfiguration_LogDestinationConfigs")]
        public System.String[] LoggingConfiguration_LogDestinationConfig { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_RedactedField
        /// <summary>
        /// <para>
        /// <para>The parts of the request that you want redacted from the logs. For example, if you
        /// redact the cookie field, the cookie field in the firehose will be <c>xxx</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_RedactedFields")]
        public Amazon.WAF.Model.FieldToMatch[] LoggingConfiguration_RedactedField { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the web ACL that you want to associate with <c>LogDestinationConfigs</c>.</para>
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
        public System.String LoggingConfiguration_ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LoggingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAF.Model.PutLoggingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.WAF.Model.PutLoggingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LoggingConfiguration";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LoggingConfiguration_ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-WAFLoggingConfiguration (PutLoggingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAF.Model.PutLoggingConfigurationResponse, WriteWAFLoggingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.LoggingConfiguration_LogDestinationConfig != null)
            {
                context.LoggingConfiguration_LogDestinationConfig = new List<System.String>(this.LoggingConfiguration_LogDestinationConfig);
            }
            #if MODULAR
            if (this.LoggingConfiguration_LogDestinationConfig == null && ParameterWasBound(nameof(this.LoggingConfiguration_LogDestinationConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter LoggingConfiguration_LogDestinationConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LoggingConfiguration_RedactedField != null)
            {
                context.LoggingConfiguration_RedactedField = new List<Amazon.WAF.Model.FieldToMatch>(this.LoggingConfiguration_RedactedField);
            }
            context.LoggingConfiguration_ResourceArn = this.LoggingConfiguration_ResourceArn;
            #if MODULAR
            if (this.LoggingConfiguration_ResourceArn == null && ParameterWasBound(nameof(this.LoggingConfiguration_ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LoggingConfiguration_ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.WAF.Model.PutLoggingConfigurationRequest();
            
            
             // populate LoggingConfiguration
            var requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.WAF.Model.LoggingConfiguration();
            List<System.String> requestLoggingConfiguration_loggingConfiguration_LogDestinationConfig = null;
            if (cmdletContext.LoggingConfiguration_LogDestinationConfig != null)
            {
                requestLoggingConfiguration_loggingConfiguration_LogDestinationConfig = cmdletContext.LoggingConfiguration_LogDestinationConfig;
            }
            if (requestLoggingConfiguration_loggingConfiguration_LogDestinationConfig != null)
            {
                request.LoggingConfiguration.LogDestinationConfigs = requestLoggingConfiguration_loggingConfiguration_LogDestinationConfig;
                requestLoggingConfigurationIsNull = false;
            }
            List<Amazon.WAF.Model.FieldToMatch> requestLoggingConfiguration_loggingConfiguration_RedactedField = null;
            if (cmdletContext.LoggingConfiguration_RedactedField != null)
            {
                requestLoggingConfiguration_loggingConfiguration_RedactedField = cmdletContext.LoggingConfiguration_RedactedField;
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
        
        private Amazon.WAF.Model.PutLoggingConfigurationResponse CallAWSServiceOperation(IAmazonWAF client, Amazon.WAF.Model.PutLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF", "PutLoggingConfiguration");
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
            public List<System.String> LoggingConfiguration_LogDestinationConfig { get; set; }
            public List<Amazon.WAF.Model.FieldToMatch> LoggingConfiguration_RedactedField { get; set; }
            public System.String LoggingConfiguration_ResourceArn { get; set; }
            public System.Func<Amazon.WAF.Model.PutLoggingConfigurationResponse, WriteWAFLoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LoggingConfiguration;
        }
        
    }
}

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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Enables the specified <a>LoggingConfiguration</a>, to start logging from a web ACL,
    /// according to the configuration provided. 
    /// 
    ///  <note><para>
    /// This operation completely replaces any mutable specifications that you already have
    /// for a logging configuration with the ones that you provide to this call. 
    /// </para><para>
    /// To modify an existing logging configuration, do the following: 
    /// </para><ol><li><para>
    /// Retrieve it by calling <a>GetLoggingConfiguration</a></para></li><li><para>
    /// Update its settings as needed
    /// </para></li><li><para>
    /// Provide the complete logging configuration specification to this call
    /// </para></li></ol></note><note><para>
    /// You can define one logging destination per web ACL.
    /// </para></note><para>
    /// You can access information about the traffic that WAF inspects using the following
    /// steps:
    /// </para><ol><li><para>
    /// Create your logging destination. You can use an Amazon CloudWatch Logs log group,
    /// an Amazon Simple Storage Service (Amazon S3) bucket, or an Amazon Kinesis Data Firehose.
    /// 
    /// </para><para>
    /// The name that you give the destination must start with <c>aws-waf-logs-</c>. Depending
    /// on the type of destination, you might need to configure additional settings or permissions.
    /// 
    /// </para><para>
    /// For configuration requirements and pricing information for each destination type,
    /// see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/logging.html">Logging
    /// web ACL traffic</a> in the <i>WAF Developer Guide</i>.
    /// </para></li><li><para>
    /// Associate your logging destination to your web ACL using a <c>PutLoggingConfiguration</c>
    /// request.
    /// </para></li></ol><para>
    /// When you successfully enable logging using a <c>PutLoggingConfiguration</c> request,
    /// WAF creates an additional role or policy that is required to write logs to the logging
    /// destination. For an Amazon CloudWatch Logs log group, WAF creates a resource policy
    /// on the log group. For an Amazon S3 bucket, WAF creates a bucket policy. For an Amazon
    /// Kinesis Data Firehose, WAF creates a service-linked role.
    /// </para><para>
    /// For additional information about web ACL logging, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/logging.html">Logging
    /// web ACL traffic information</a> in the <i>WAF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "WAF2LoggingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WAFV2.Model.LoggingConfiguration")]
    [AWSCmdlet("Calls the AWS WAF V2 PutLoggingConfiguration API operation.", Operation = new[] {"PutLoggingConfiguration"}, SelectReturnType = typeof(Amazon.WAFV2.Model.PutLoggingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.WAFV2.Model.LoggingConfiguration or Amazon.WAFV2.Model.PutLoggingConfigurationResponse",
        "This cmdlet returns an Amazon.WAFV2.Model.LoggingConfiguration object.",
        "The service call response (type Amazon.WAFV2.Model.PutLoggingConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteWAF2LoggingConfigurationCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LoggingFilter_DefaultBehavior
        /// <summary>
        /// <para>
        /// <para>Default handling for logs that don't match any of the specified filtering conditions.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_LoggingFilter_DefaultBehavior")]
        [AWSConstantClassSource("Amazon.WAFV2.FilterBehavior")]
        public Amazon.WAFV2.FilterBehavior LoggingFilter_DefaultBehavior { get; set; }
        #endregion
        
        #region Parameter LoggingFilter_Filter
        /// <summary>
        /// <para>
        /// <para>The filters that you want to apply to the logs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_LoggingFilter_Filters")]
        public Amazon.WAFV2.Model.Filter[] LoggingFilter_Filter { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_LogDestinationConfig
        /// <summary>
        /// <para>
        /// <para>The logging destination configuration that you want to associate with the web ACL.</para><note><para>You can associate one logging destination to a web ACL.</para></note>
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
        
        #region Parameter LoggingConfiguration_LogScope
        /// <summary>
        /// <para>
        /// <para>The owner of the logging configuration, which must be set to <c>CUSTOMER</c> for the
        /// configurations that you manage. </para><para>The log scope <c>SECURITY_LAKE</c> indicates a configuration that is managed through
        /// Amazon Security Lake. You can use Security Lake to collect log and event data from
        /// various sources for normalization, analysis, and management. For information, see
        /// <a href="https://docs.aws.amazon.com/security-lake/latest/userguide/internal-sources.html">Collecting
        /// data from Amazon Web Services services</a> in the <i>Amazon Security Lake user guide</i>.
        /// </para><para>Default: <c>CUSTOMER</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WAFV2.LogScope")]
        public Amazon.WAFV2.LogScope LoggingConfiguration_LogScope { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_LogType
        /// <summary>
        /// <para>
        /// <para>Used to distinguish between various logging options. Currently, there is one option.</para><para>Default: <c>WAF_LOGS</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WAFV2.LogType")]
        public Amazon.WAFV2.LogType LoggingConfiguration_LogType { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_ManagedByFirewallManager
        /// <summary>
        /// <para>
        /// <para>Indicates whether the logging configuration was created by Firewall Manager, as part
        /// of an WAF policy configuration. If true, only Firewall Manager can modify or delete
        /// the configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoggingConfiguration_ManagedByFirewallManager { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_RedactedField
        /// <summary>
        /// <para>
        /// <para>The parts of the request that you want to keep out of the logs.</para><para>For example, if you redact the <c>SingleHeader</c> field, the <c>HEADER</c> field
        /// in the logs will be <c>REDACTED</c> for all rules that use the <c>SingleHeader</c><c>FieldToMatch</c> setting. </para><para>Redaction applies only to the component that's specified in the rule's <c>FieldToMatch</c>
        /// setting, so the <c>SingleHeader</c> redaction doesn't apply to rules that use the
        /// <c>Headers</c><c>FieldToMatch</c>.</para><note><para>You can specify only the following fields for redaction: <c>UriPath</c>, <c>QueryString</c>,
        /// <c>SingleHeader</c>, and <c>Method</c>.</para></note><note><para>This setting has no impact on request sampling. With request sampling, the only way
        /// to exclude fields is by disabling sampling in the web ACL visibility configuration.
        /// </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_RedactedFields")]
        public Amazon.WAFV2.Model.FieldToMatch[] LoggingConfiguration_RedactedField { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.PutLoggingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.PutLoggingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LoggingConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LoggingConfiguration_ResourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LoggingConfiguration_ResourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LoggingConfiguration_ResourceArn' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LoggingConfiguration_ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-WAF2LoggingConfiguration (PutLoggingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.PutLoggingConfigurationResponse, WriteWAF2LoggingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LoggingConfiguration_ResourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.LoggingFilter_DefaultBehavior = this.LoggingFilter_DefaultBehavior;
            if (this.LoggingFilter_Filter != null)
            {
                context.LoggingFilter_Filter = new List<Amazon.WAFV2.Model.Filter>(this.LoggingFilter_Filter);
            }
            context.LoggingConfiguration_LogScope = this.LoggingConfiguration_LogScope;
            context.LoggingConfiguration_LogType = this.LoggingConfiguration_LogType;
            context.LoggingConfiguration_ManagedByFirewallManager = this.LoggingConfiguration_ManagedByFirewallManager;
            if (this.LoggingConfiguration_RedactedField != null)
            {
                context.LoggingConfiguration_RedactedField = new List<Amazon.WAFV2.Model.FieldToMatch>(this.LoggingConfiguration_RedactedField);
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
            var request = new Amazon.WAFV2.Model.PutLoggingConfigurationRequest();
            
            
             // populate LoggingConfiguration
            var requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.WAFV2.Model.LoggingConfiguration();
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
            Amazon.WAFV2.LogScope requestLoggingConfiguration_loggingConfiguration_LogScope = null;
            if (cmdletContext.LoggingConfiguration_LogScope != null)
            {
                requestLoggingConfiguration_loggingConfiguration_LogScope = cmdletContext.LoggingConfiguration_LogScope;
            }
            if (requestLoggingConfiguration_loggingConfiguration_LogScope != null)
            {
                request.LoggingConfiguration.LogScope = requestLoggingConfiguration_loggingConfiguration_LogScope;
                requestLoggingConfigurationIsNull = false;
            }
            Amazon.WAFV2.LogType requestLoggingConfiguration_loggingConfiguration_LogType = null;
            if (cmdletContext.LoggingConfiguration_LogType != null)
            {
                requestLoggingConfiguration_loggingConfiguration_LogType = cmdletContext.LoggingConfiguration_LogType;
            }
            if (requestLoggingConfiguration_loggingConfiguration_LogType != null)
            {
                request.LoggingConfiguration.LogType = requestLoggingConfiguration_loggingConfiguration_LogType;
                requestLoggingConfigurationIsNull = false;
            }
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_ManagedByFirewallManager = null;
            if (cmdletContext.LoggingConfiguration_ManagedByFirewallManager != null)
            {
                requestLoggingConfiguration_loggingConfiguration_ManagedByFirewallManager = cmdletContext.LoggingConfiguration_ManagedByFirewallManager.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_ManagedByFirewallManager != null)
            {
                request.LoggingConfiguration.ManagedByFirewallManager = requestLoggingConfiguration_loggingConfiguration_ManagedByFirewallManager.Value;
                requestLoggingConfigurationIsNull = false;
            }
            List<Amazon.WAFV2.Model.FieldToMatch> requestLoggingConfiguration_loggingConfiguration_RedactedField = null;
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
            Amazon.WAFV2.Model.LoggingFilter requestLoggingConfiguration_loggingConfiguration_LoggingFilter = null;
            
             // populate LoggingFilter
            var requestLoggingConfiguration_loggingConfiguration_LoggingFilterIsNull = true;
            requestLoggingConfiguration_loggingConfiguration_LoggingFilter = new Amazon.WAFV2.Model.LoggingFilter();
            Amazon.WAFV2.FilterBehavior requestLoggingConfiguration_loggingConfiguration_LoggingFilter_loggingFilter_DefaultBehavior = null;
            if (cmdletContext.LoggingFilter_DefaultBehavior != null)
            {
                requestLoggingConfiguration_loggingConfiguration_LoggingFilter_loggingFilter_DefaultBehavior = cmdletContext.LoggingFilter_DefaultBehavior;
            }
            if (requestLoggingConfiguration_loggingConfiguration_LoggingFilter_loggingFilter_DefaultBehavior != null)
            {
                requestLoggingConfiguration_loggingConfiguration_LoggingFilter.DefaultBehavior = requestLoggingConfiguration_loggingConfiguration_LoggingFilter_loggingFilter_DefaultBehavior;
                requestLoggingConfiguration_loggingConfiguration_LoggingFilterIsNull = false;
            }
            List<Amazon.WAFV2.Model.Filter> requestLoggingConfiguration_loggingConfiguration_LoggingFilter_loggingFilter_Filter = null;
            if (cmdletContext.LoggingFilter_Filter != null)
            {
                requestLoggingConfiguration_loggingConfiguration_LoggingFilter_loggingFilter_Filter = cmdletContext.LoggingFilter_Filter;
            }
            if (requestLoggingConfiguration_loggingConfiguration_LoggingFilter_loggingFilter_Filter != null)
            {
                requestLoggingConfiguration_loggingConfiguration_LoggingFilter.Filters = requestLoggingConfiguration_loggingConfiguration_LoggingFilter_loggingFilter_Filter;
                requestLoggingConfiguration_loggingConfiguration_LoggingFilterIsNull = false;
            }
             // determine if requestLoggingConfiguration_loggingConfiguration_LoggingFilter should be set to null
            if (requestLoggingConfiguration_loggingConfiguration_LoggingFilterIsNull)
            {
                requestLoggingConfiguration_loggingConfiguration_LoggingFilter = null;
            }
            if (requestLoggingConfiguration_loggingConfiguration_LoggingFilter != null)
            {
                request.LoggingConfiguration.LoggingFilter = requestLoggingConfiguration_loggingConfiguration_LoggingFilter;
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
        
        private Amazon.WAFV2.Model.PutLoggingConfigurationResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.PutLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "PutLoggingConfiguration");
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
            public Amazon.WAFV2.FilterBehavior LoggingFilter_DefaultBehavior { get; set; }
            public List<Amazon.WAFV2.Model.Filter> LoggingFilter_Filter { get; set; }
            public Amazon.WAFV2.LogScope LoggingConfiguration_LogScope { get; set; }
            public Amazon.WAFV2.LogType LoggingConfiguration_LogType { get; set; }
            public System.Boolean? LoggingConfiguration_ManagedByFirewallManager { get; set; }
            public List<Amazon.WAFV2.Model.FieldToMatch> LoggingConfiguration_RedactedField { get; set; }
            public System.String LoggingConfiguration_ResourceArn { get; set; }
            public System.Func<Amazon.WAFV2.Model.PutLoggingConfigurationResponse, WriteWAF2LoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LoggingConfiguration;
        }
        
    }
}

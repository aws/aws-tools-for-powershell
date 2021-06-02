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
    ///  
    /// <para>
    /// You can access information about all traffic that WAF inspects using the following
    /// steps:
    /// </para><ol><li><para>
    /// Create an Amazon Kinesis Data Firehose. 
    /// </para><para>
    /// Create the data firehose with a PUT source and in the Region that you are operating.
    /// If you are capturing logs for Amazon CloudFront, always create the firehose in US
    /// East (N. Virginia). 
    /// </para><para>
    /// Give the data firehose a name that starts with the prefix <code>aws-waf-logs-</code>.
    /// For example, <code>aws-waf-logs-us-east-2-analytics</code>.
    /// </para><note><para>
    /// Do not create the data firehose using a <code>Kinesis stream</code> as your source.
    /// </para></note></li><li><para>
    /// Associate that firehose to your web ACL using a <code>PutLoggingConfiguration</code>
    /// request.
    /// </para></li></ol><para>
    /// When you successfully enable logging using a <code>PutLoggingConfiguration</code>
    /// request, WAF will create a service linked role with the necessary permissions to write
    /// logs to the Amazon Kinesis Data Firehose. For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/logging.html">Logging
    /// Web ACL Traffic Information</a> in the <i>WAF Developer Guide</i>.
    /// </para><note><para>
    /// This operation completely replaces the mutable specifications that you already have
    /// for the logging configuration with the ones that you provide to this call. To modify
    /// the logging configuration, retrieve it by calling <a>GetLoggingConfiguration</a>,
    /// update the settings as needed, and then provide the complete logging configuration
    /// specification to this call.
    /// </para></note>
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
        /// <para>The Amazon Kinesis Data Firehose Amazon Resource Name (ARNs) that you want to associate
        /// with the web ACL.</para>
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
        /// <para>The parts of the request that you want to keep out of the logs. For example, if you
        /// redact the <code>HEADER</code> field, the <code>HEADER</code> field in the firehose
        /// will be <code>xxx</code>. </para><note><para>You must use one of the following values: <code>URI</code>, <code>QUERY_STRING</code>,
        /// <code>HEADER</code>, or <code>METHOD</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_RedactedFields")]
        public Amazon.WAFV2.Model.FieldToMatch[] LoggingConfiguration_RedactedField { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the web ACL that you want to associate with <code>LogDestinationConfigs</code>.</para>
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
            public System.Boolean? LoggingConfiguration_ManagedByFirewallManager { get; set; }
            public List<Amazon.WAFV2.Model.FieldToMatch> LoggingConfiguration_RedactedField { get; set; }
            public System.String LoggingConfiguration_ResourceArn { get; set; }
            public System.Func<Amazon.WAFV2.Model.PutLoggingConfigurationResponse, WriteWAF2LoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LoggingConfiguration;
        }
        
    }
}

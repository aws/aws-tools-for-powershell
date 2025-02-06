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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Returns the <a>LoggingConfiguration</a> for the specified web ACL.
    /// </summary>
    [Cmdlet("Get", "WAF2LoggingConfiguration")]
    [OutputType("Amazon.WAFV2.Model.LoggingConfiguration")]
    [AWSCmdlet("Calls the AWS WAF V2 GetLoggingConfiguration API operation.", Operation = new[] {"GetLoggingConfiguration"}, SelectReturnType = typeof(Amazon.WAFV2.Model.GetLoggingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.WAFV2.Model.LoggingConfiguration or Amazon.WAFV2.Model.GetLoggingConfigurationResponse",
        "This cmdlet returns an Amazon.WAFV2.Model.LoggingConfiguration object.",
        "The service call response (type Amazon.WAFV2.Model.GetLoggingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetWAF2LoggingConfigurationCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LogScope
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
        public Amazon.WAFV2.LogScope LogScope { get; set; }
        #endregion
        
        #region Parameter LogType
        /// <summary>
        /// <para>
        /// <para>Used to distinguish between various logging options. Currently, there is one option.</para><para>Default: <c>WAF_LOGS</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WAFV2.LogType")]
        public Amazon.WAFV2.LogType LogType { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the web ACL for which you want to get the <a>LoggingConfiguration</a>.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LoggingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.GetLoggingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.GetLoggingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LoggingConfiguration";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.GetLoggingConfigurationResponse, GetWAF2LoggingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LogScope = this.LogScope;
            context.LogType = this.LogType;
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAFV2.Model.GetLoggingConfigurationRequest();
            
            if (cmdletContext.LogScope != null)
            {
                request.LogScope = cmdletContext.LogScope;
            }
            if (cmdletContext.LogType != null)
            {
                request.LogType = cmdletContext.LogType;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.WAFV2.Model.GetLoggingConfigurationResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.GetLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "GetLoggingConfiguration");
            try
            {
                #if DESKTOP
                return client.GetLoggingConfiguration(request);
                #elif CORECLR
                return client.GetLoggingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.WAFV2.LogScope LogScope { get; set; }
            public Amazon.WAFV2.LogType LogType { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.WAFV2.Model.GetLoggingConfigurationResponse, GetWAF2LoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LoggingConfiguration;
        }
        
    }
}

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
using System.Threading;
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APPC
{
    /// <summary>
    /// (Deprecated) Retrieves the latest deployed configuration.
    /// 
    ///  <important><para>
    /// Note the following important information.
    /// </para><ul><li><para>
    /// This API action is deprecated. Calls to receive configuration data should use the
    /// <a href="https://docs.aws.amazon.com/appconfig/2019-10-09/APIReference/API_appconfigdata_StartConfigurationSession.html">StartConfigurationSession</a>
    /// and <a href="https://docs.aws.amazon.com/appconfig/2019-10-09/APIReference/API_appconfigdata_GetLatestConfiguration.html">GetLatestConfiguration</a>
    /// APIs instead. 
    /// </para></li><li><para><a>GetConfiguration</a> is a priced call. For more information, see <a href="https://aws.amazon.com/systems-manager/pricing/">Pricing</a>.
    /// </para></li></ul></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Get", "APPCConfiguration")]
    [OutputType("Amazon.AppConfig.Model.GetConfigurationResponse")]
    [AWSCmdlet("Calls the AWS AppConfig GetConfiguration API operation.", Operation = new[] {"GetConfiguration"}, SelectReturnType = typeof(Amazon.AppConfig.Model.GetConfigurationResponse))]
    [AWSCmdletOutput("Amazon.AppConfig.Model.GetConfigurationResponse",
        "This cmdlet returns an Amazon.AppConfig.Model.GetConfigurationResponse object containing multiple properties."
    )]
    [System.ObsoleteAttribute("This API has been deprecated in favor of the GetLatestConfiguration API used in conjunction with StartConfigurationSession.")]
    public partial class GetAPPCConfigurationCmdlet : AmazonAppConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Application
        /// <summary>
        /// <para>
        /// <para>The application to get. Specify either the application name or the application ID.</para>
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
        public System.String Application { get; set; }
        #endregion
        
        #region Parameter ClientConfigurationVersion
        /// <summary>
        /// <para>
        /// <para>The configuration version returned in the most recent <a>GetConfiguration</a> response.</para><important><para>AppConfig uses the value of the <c>ClientConfigurationVersion</c> parameter to identify
        /// the configuration version on your clients. If you don’t send <c>ClientConfigurationVersion</c>
        /// with each call to <a>GetConfiguration</a>, your clients receive the current configuration.
        /// You are charged each time your clients receive a configuration.</para><para>To avoid excess charges, we recommend you use the <a href="https://docs.aws.amazon.com/appconfig/2019-10-09/APIReference/StartConfigurationSession.html">StartConfigurationSession</a>
        /// and <a href="https://docs.aws.amazon.com/appconfig/2019-10-09/APIReference/GetLatestConfiguration.html">GetLatestConfiguration</a>
        /// APIs, which track the client configuration version on your behalf. If you choose to
        /// continue using <a>GetConfiguration</a>, we recommend that you include the <c>ClientConfigurationVersion</c>
        /// value with every call to <a>GetConfiguration</a>. The value to use for <c>ClientConfigurationVersion</c>
        /// comes from the <c>ConfigurationVersion</c> attribute returned by <a>GetConfiguration</a>
        /// when there is new or updated data, and should be saved for subsequent calls to <a>GetConfiguration</a>.</para></important><para>For more information about working with configurations, see <a href="http://docs.aws.amazon.com/appconfig/latest/userguide/retrieving-feature-flags.html">Retrieving
        /// feature flags and configuration data in AppConfig</a> in the <i>AppConfig User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientConfigurationVersion { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The clientId parameter in the following command is a unique, user-specified ID to
        /// identify the client for the configuration. This ID enables AppConfig to deploy the
        /// configuration in intervals, as defined in the deployment strategy. </para>
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
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>The configuration to get. Specify either the configuration name or the configuration
        /// ID.</para>
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
        public System.String Configuration { get; set; }
        #endregion
        
        #region Parameter Environment
        /// <summary>
        /// <para>
        /// <para>The environment to get. Specify either the environment name or the environment ID.</para>
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
        public System.String Environment { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.GetConfigurationResponse).
        /// Specifying the name of a property of type Amazon.AppConfig.Model.GetConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.GetConfigurationResponse, GetAPPCConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Application = this.Application;
            #if MODULAR
            if (this.Application == null && ParameterWasBound(nameof(this.Application)))
            {
                WriteWarning("You are passing $null as a value for parameter Application which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientConfigurationVersion = this.ClientConfigurationVersion;
            context.ClientId = this.ClientId;
            #if MODULAR
            if (this.ClientId == null && ParameterWasBound(nameof(this.ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Configuration = this.Configuration;
            #if MODULAR
            if (this.Configuration == null && ParameterWasBound(nameof(this.Configuration)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Environment = this.Environment;
            #if MODULAR
            if (this.Environment == null && ParameterWasBound(nameof(this.Environment)))
            {
                WriteWarning("You are passing $null as a value for parameter Environment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppConfig.Model.GetConfigurationRequest();
            
            if (cmdletContext.Application != null)
            {
                request.Application = cmdletContext.Application;
            }
            if (cmdletContext.ClientConfigurationVersion != null)
            {
                request.ClientConfigurationVersion = cmdletContext.ClientConfigurationVersion;
            }
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.Configuration != null)
            {
                request.Configuration = cmdletContext.Configuration;
            }
            if (cmdletContext.Environment != null)
            {
                request.Environment = cmdletContext.Environment;
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
        
        private Amazon.AppConfig.Model.GetConfigurationResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.GetConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "GetConfiguration");
            try
            {
                return client.GetConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Application { get; set; }
            public System.String ClientConfigurationVersion { get; set; }
            public System.String ClientId { get; set; }
            public System.String Configuration { get; set; }
            public System.String Environment { get; set; }
            public System.Func<Amazon.AppConfig.Model.GetConfigurationResponse, GetAPPCConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

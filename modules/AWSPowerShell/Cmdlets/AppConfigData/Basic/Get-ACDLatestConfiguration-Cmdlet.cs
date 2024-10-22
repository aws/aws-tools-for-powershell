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
using Amazon.AppConfigData;
using Amazon.AppConfigData.Model;

namespace Amazon.PowerShell.Cmdlets.ACD
{
    /// <summary>
    /// Retrieves the latest deployed configuration. This API may return empty configuration
    /// data if the client already has the latest version. For more information about this
    /// API action and to view example CLI commands that show how to use it with the <a>StartConfigurationSession</a>
    /// API action, see <a href="http://docs.aws.amazon.com/appconfig/latest/userguide/appconfig-retrieving-the-configuration">Retrieving
    /// the configuration</a> in the <i>AppConfig User Guide</i>. 
    /// 
    ///  <important><para>
    /// Note the following important information.
    /// </para><ul><li><para>
    /// Each configuration token is only valid for one call to <c>GetLatestConfiguration</c>.
    /// The <c>GetLatestConfiguration</c> response includes a <c>NextPollConfigurationToken</c>
    /// that should always replace the token used for the just-completed call in preparation
    /// for the next one. 
    /// </para></li><li><para><c>GetLatestConfiguration</c> is a priced call. For more information, see <a href="https://aws.amazon.com/systems-manager/pricing/">Pricing</a>.
    /// </para></li></ul></important>
    /// </summary>
    [Cmdlet("Get", "ACDLatestConfiguration")]
    [OutputType("Amazon.AppConfigData.Model.GetLatestConfigurationResponse")]
    [AWSCmdlet("Calls the AWS AppConfig Data GetLatestConfiguration API operation.", Operation = new[] {"GetLatestConfiguration"}, SelectReturnType = typeof(Amazon.AppConfigData.Model.GetLatestConfigurationResponse))]
    [AWSCmdletOutput("Amazon.AppConfigData.Model.GetLatestConfigurationResponse",
        "This cmdlet returns an Amazon.AppConfigData.Model.GetLatestConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetACDLatestConfigurationCmdlet : AmazonAppConfigDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationToken
        /// <summary>
        /// <para>
        /// <para>Token describing the current state of the configuration session. To obtain a token,
        /// first call the <a>StartConfigurationSession</a> API. Note that every call to <c>GetLatestConfiguration</c>
        /// will return a new <c>ConfigurationToken</c> (<c>NextPollConfigurationToken</c> in
        /// the response) and <i>must</i> be provided to subsequent <c>GetLatestConfiguration</c>
        /// API calls.</para><important><para>This token should only be used once. To support long poll use cases, the token is
        /// valid for up to 24 hours. If a <c>GetLatestConfiguration</c> call uses an expired
        /// token, the system returns <c>BadRequestException</c>.</para></important>
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
        public System.String ConfigurationToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfigData.Model.GetLatestConfigurationResponse).
        /// Specifying the name of a property of type Amazon.AppConfigData.Model.GetLatestConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.AppConfigData.Model.GetLatestConfigurationResponse, GetACDLatestConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationToken = this.ConfigurationToken;
            #if MODULAR
            if (this.ConfigurationToken == null && ParameterWasBound(nameof(this.ConfigurationToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppConfigData.Model.GetLatestConfigurationRequest();
            
            if (cmdletContext.ConfigurationToken != null)
            {
                request.ConfigurationToken = cmdletContext.ConfigurationToken;
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
        
        private Amazon.AppConfigData.Model.GetLatestConfigurationResponse CallAWSServiceOperation(IAmazonAppConfigData client, Amazon.AppConfigData.Model.GetLatestConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig Data", "GetLatestConfiguration");
            try
            {
                #if DESKTOP
                return client.GetLatestConfiguration(request);
                #elif CORECLR
                return client.GetLatestConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationToken { get; set; }
            public System.Func<Amazon.AppConfigData.Model.GetLatestConfigurationResponse, GetACDLatestConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the details of one or more remediation configurations.
    /// </summary>
    [Cmdlet("Get", "CFGRemediationConfiguration")]
    [OutputType("Amazon.ConfigService.Model.RemediationConfiguration")]
    [AWSCmdlet("Calls the AWS Config DescribeRemediationConfigurations API operation.", Operation = new[] {"DescribeRemediationConfigurations"}, SelectReturnType = typeof(Amazon.ConfigService.Model.DescribeRemediationConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.RemediationConfiguration or Amazon.ConfigService.Model.DescribeRemediationConfigurationsResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.RemediationConfiguration objects.",
        "The service call response (type Amazon.ConfigService.Model.DescribeRemediationConfigurationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFGRemediationConfigurationCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigRuleName
        /// <summary>
        /// <para>
        /// <para>A list of Config rule names of remediation configurations for which you want details.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ConfigRuleNames")]
        public System.String[] ConfigRuleName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RemediationConfigurations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.DescribeRemediationConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.DescribeRemediationConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RemediationConfigurations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfigRuleName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfigRuleName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfigRuleName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.DescribeRemediationConfigurationsResponse, GetCFGRemediationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfigRuleName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ConfigRuleName != null)
            {
                context.ConfigRuleName = new List<System.String>(this.ConfigRuleName);
            }
            #if MODULAR
            if (this.ConfigRuleName == null && ParameterWasBound(nameof(this.ConfigRuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigRuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConfigService.Model.DescribeRemediationConfigurationsRequest();
            
            if (cmdletContext.ConfigRuleName != null)
            {
                request.ConfigRuleNames = cmdletContext.ConfigRuleName;
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
        
        private Amazon.ConfigService.Model.DescribeRemediationConfigurationsResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.DescribeRemediationConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "DescribeRemediationConfigurations");
            try
            {
                #if DESKTOP
                return client.DescribeRemediationConfigurations(request);
                #elif CORECLR
                return client.DescribeRemediationConfigurationsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ConfigRuleName { get; set; }
            public System.Func<Amazon.ConfigService.Model.DescribeRemediationConfigurationsResponse, GetCFGRemediationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RemediationConfigurations;
        }
        
    }
}

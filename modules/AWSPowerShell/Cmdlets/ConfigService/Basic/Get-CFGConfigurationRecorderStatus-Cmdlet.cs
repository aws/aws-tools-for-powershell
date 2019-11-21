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
    /// Returns the current status of the specified configuration recorder. If a configuration
    /// recorder is not specified, this action returns the status of all configuration recorders
    /// associated with the account.
    /// 
    ///  <note><para>
    /// Currently, you can specify only one configuration recorder per region in your account.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGConfigurationRecorderStatus")]
    [OutputType("Amazon.ConfigService.Model.ConfigurationRecorderStatus")]
    [AWSCmdlet("Calls the AWS Config DescribeConfigurationRecorderStatus API operation.", Operation = new[] {"DescribeConfigurationRecorderStatus"}, SelectReturnType = typeof(Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConfigurationRecorderStatus or Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.ConfigurationRecorderStatus objects.",
        "The service call response (type Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGConfigurationRecorderStatusCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationRecorderName
        /// <summary>
        /// <para>
        /// <para>The name(s) of the configuration recorder. If the name is not specified, the action
        /// returns the current status of all the configuration recorders associated with the
        /// account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ConfigurationRecorderNames")]
        public System.String[] ConfigurationRecorderName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfigurationRecordersStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfigurationRecordersStatus";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfigurationRecorderName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfigurationRecorderName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfigurationRecorderName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusResponse, GetCFGConfigurationRecorderStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfigurationRecorderName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ConfigurationRecorderName != null)
            {
                context.ConfigurationRecorderName = new List<System.String>(this.ConfigurationRecorderName);
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
            var request = new Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusRequest();
            
            if (cmdletContext.ConfigurationRecorderName != null)
            {
                request.ConfigurationRecorderNames = cmdletContext.ConfigurationRecorderName;
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
        
        private Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "DescribeConfigurationRecorderStatus");
            try
            {
                #if DESKTOP
                return client.DescribeConfigurationRecorderStatus(request);
                #elif CORECLR
                return client.DescribeConfigurationRecorderStatusAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ConfigurationRecorderName { get; set; }
            public System.Func<Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusResponse, GetCFGConfigurationRecorderStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfigurationRecordersStatus;
        }
        
    }
}

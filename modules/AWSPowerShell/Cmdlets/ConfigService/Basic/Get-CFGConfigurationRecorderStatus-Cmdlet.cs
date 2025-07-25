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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the current status of the configuration recorder you specify as well as the
    /// status of the last recording event for the configuration recorders.
    /// 
    ///  
    /// <para>
    /// For a detailed status of recording events over time, add your Config events to Amazon
    /// CloudWatch metrics and use CloudWatch metrics.
    /// </para><para>
    /// If a configuration recorder is not specified, this operation returns the status for
    /// the customer managed configuration recorder configured for the account, if applicable.
    /// </para><note><para>
    /// When making a request to this operation, you can only specify one configuration recorder.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGConfigurationRecorderStatus")]
    [OutputType("Amazon.ConfigService.Model.ConfigurationRecorderStatus")]
    [AWSCmdlet("Calls the AWS Config DescribeConfigurationRecorderStatus API operation.", Operation = new[] {"DescribeConfigurationRecorderStatus"}, SelectReturnType = typeof(Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConfigurationRecorderStatus or Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.ConfigurationRecorderStatus objects.",
        "The service call response (type Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFGConfigurationRecorderStatusCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the configuration recorder that you want to specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter ConfigurationRecorderName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration recorder. If the name is not specified, the operation
        /// returns the status for the customer managed configuration recorder configured for
        /// the account, if applicable.</para><note><para>When making a request to this operation, you can only specify one configuration recorder.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ConfigurationRecorderNames")]
        public System.String[] ConfigurationRecorderName { get; set; }
        #endregion
        
        #region Parameter ServicePrincipal
        /// <summary>
        /// <para>
        /// <para>For service-linked configuration recorders, you can use the service principal of the
        /// linked Amazon Web Services service to specify the configuration recorder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServicePrincipal { get; set; }
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
            this._AWSSignerType = "v4";
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
            context.Arn = this.Arn;
            if (this.ConfigurationRecorderName != null)
            {
                context.ConfigurationRecorderName = new List<System.String>(this.ConfigurationRecorderName);
            }
            context.ServicePrincipal = this.ServicePrincipal;
            
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
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.ConfigurationRecorderName != null)
            {
                request.ConfigurationRecorderNames = cmdletContext.ConfigurationRecorderName;
            }
            if (cmdletContext.ServicePrincipal != null)
            {
                request.ServicePrincipal = cmdletContext.ServicePrincipal;
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
            public System.String Arn { get; set; }
            public List<System.String> ConfigurationRecorderName { get; set; }
            public System.String ServicePrincipal { get; set; }
            public System.Func<Amazon.ConfigService.Model.DescribeConfigurationRecorderStatusResponse, GetCFGConfigurationRecorderStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfigurationRecordersStatus;
        }
        
    }
}

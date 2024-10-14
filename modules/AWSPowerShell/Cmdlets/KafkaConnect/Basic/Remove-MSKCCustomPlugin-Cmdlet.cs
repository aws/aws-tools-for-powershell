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
using Amazon.KafkaConnect;
using Amazon.KafkaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.MSKC
{
    /// <summary>
    /// Deletes a custom plugin.
    /// </summary>
    [Cmdlet("Remove", "MSKCCustomPlugin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.KafkaConnect.Model.DeleteCustomPluginResponse")]
    [AWSCmdlet("Calls the Managed Streaming for Kafka Connect DeleteCustomPlugin API operation.", Operation = new[] {"DeleteCustomPlugin"}, SelectReturnType = typeof(Amazon.KafkaConnect.Model.DeleteCustomPluginResponse))]
    [AWSCmdletOutput("Amazon.KafkaConnect.Model.DeleteCustomPluginResponse",
        "This cmdlet returns an Amazon.KafkaConnect.Model.DeleteCustomPluginResponse object containing multiple properties."
    )]
    public partial class RemoveMSKCCustomPluginCmdlet : AmazonKafkaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CustomPluginArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the custom plugin that you want to delete.</para>
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
        public System.String CustomPluginArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KafkaConnect.Model.DeleteCustomPluginResponse).
        /// Specifying the name of a property of type Amazon.KafkaConnect.Model.DeleteCustomPluginResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CustomPluginArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CustomPluginArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CustomPluginArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomPluginArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-MSKCCustomPlugin (DeleteCustomPlugin)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KafkaConnect.Model.DeleteCustomPluginResponse, RemoveMSKCCustomPluginCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CustomPluginArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CustomPluginArn = this.CustomPluginArn;
            #if MODULAR
            if (this.CustomPluginArn == null && ParameterWasBound(nameof(this.CustomPluginArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomPluginArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KafkaConnect.Model.DeleteCustomPluginRequest();
            
            if (cmdletContext.CustomPluginArn != null)
            {
                request.CustomPluginArn = cmdletContext.CustomPluginArn;
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
        
        private Amazon.KafkaConnect.Model.DeleteCustomPluginResponse CallAWSServiceOperation(IAmazonKafkaConnect client, Amazon.KafkaConnect.Model.DeleteCustomPluginRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed Streaming for Kafka Connect", "DeleteCustomPlugin");
            try
            {
                #if DESKTOP
                return client.DeleteCustomPlugin(request);
                #elif CORECLR
                return client.DeleteCustomPluginAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomPluginArn { get; set; }
            public System.Func<Amazon.KafkaConnect.Model.DeleteCustomPluginResponse, RemoveMSKCCustomPluginCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

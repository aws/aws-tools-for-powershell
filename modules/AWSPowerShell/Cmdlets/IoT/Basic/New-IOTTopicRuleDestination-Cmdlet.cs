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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates a topic rule destination. The destination must be confirmed prior to use.
    /// </summary>
    [Cmdlet("New", "IOTTopicRuleDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.TopicRuleDestination")]
    [AWSCmdlet("Calls the AWS IoT CreateTopicRuleDestination API operation.", Operation = new[] {"CreateTopicRuleDestination"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateTopicRuleDestinationResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.TopicRuleDestination or Amazon.IoT.Model.CreateTopicRuleDestinationResponse",
        "This cmdlet returns an Amazon.IoT.Model.TopicRuleDestination object.",
        "The service call response (type Amazon.IoT.Model.CreateTopicRuleDestinationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTTopicRuleDestinationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter HttpUrlConfiguration_ConfirmationUrl
        /// <summary>
        /// <para>
        /// <para>The URL AWS IoT uses to confirm ownership of or access to the topic rule destination
        /// URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("DestinationConfiguration_HttpUrlConfiguration_ConfirmationUrl")]
        public System.String HttpUrlConfiguration_ConfirmationUrl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TopicRuleDestination'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateTopicRuleDestinationResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateTopicRuleDestinationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TopicRuleDestination";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HttpUrlConfiguration_ConfirmationUrl parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HttpUrlConfiguration_ConfirmationUrl' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HttpUrlConfiguration_ConfirmationUrl' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HttpUrlConfiguration_ConfirmationUrl), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTTopicRuleDestination (CreateTopicRuleDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateTopicRuleDestinationResponse, NewIOTTopicRuleDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HttpUrlConfiguration_ConfirmationUrl;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HttpUrlConfiguration_ConfirmationUrl = this.HttpUrlConfiguration_ConfirmationUrl;
            
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
            var request = new Amazon.IoT.Model.CreateTopicRuleDestinationRequest();
            
            
             // populate DestinationConfiguration
            var requestDestinationConfigurationIsNull = true;
            request.DestinationConfiguration = new Amazon.IoT.Model.TopicRuleDestinationConfiguration();
            Amazon.IoT.Model.HttpUrlDestinationConfiguration requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration = null;
            
             // populate HttpUrlConfiguration
            var requestDestinationConfiguration_destinationConfiguration_HttpUrlConfigurationIsNull = true;
            requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration = new Amazon.IoT.Model.HttpUrlDestinationConfiguration();
            System.String requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration_httpUrlConfiguration_ConfirmationUrl = null;
            if (cmdletContext.HttpUrlConfiguration_ConfirmationUrl != null)
            {
                requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration_httpUrlConfiguration_ConfirmationUrl = cmdletContext.HttpUrlConfiguration_ConfirmationUrl;
            }
            if (requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration_httpUrlConfiguration_ConfirmationUrl != null)
            {
                requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration.ConfirmationUrl = requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration_httpUrlConfiguration_ConfirmationUrl;
                requestDestinationConfiguration_destinationConfiguration_HttpUrlConfigurationIsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_HttpUrlConfigurationIsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration != null)
            {
                request.DestinationConfiguration.HttpUrlConfiguration = requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration;
                requestDestinationConfigurationIsNull = false;
            }
             // determine if request.DestinationConfiguration should be set to null
            if (requestDestinationConfigurationIsNull)
            {
                request.DestinationConfiguration = null;
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
        
        private Amazon.IoT.Model.CreateTopicRuleDestinationResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateTopicRuleDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateTopicRuleDestination");
            try
            {
                #if DESKTOP
                return client.CreateTopicRuleDestination(request);
                #elif CORECLR
                return client.CreateTopicRuleDestinationAsync(request).GetAwaiter().GetResult();
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
            public System.String HttpUrlConfiguration_ConfirmationUrl { get; set; }
            public System.Func<Amazon.IoT.Model.CreateTopicRuleDestinationResponse, NewIOTTopicRuleDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TopicRuleDestination;
        }
        
    }
}
